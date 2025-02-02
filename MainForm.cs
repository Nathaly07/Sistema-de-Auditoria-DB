using SistemaAuditoria.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAuditoria
{
    public partial class MainForm : Form
    {
        DatabaseConnection _con;
        public MainForm(DatabaseConnection connection)
        {
            _con = connection;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuración de DataGridView para auditorías
            gridAnomaliasSinDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridAnomaliasConDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridConstrains.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTriggers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRelaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ejemplo de resaltado por criticidad
            DataGridViewRowPrePaintEventHandler resaltar = (sender, e) =>
            {
                var grid = sender as DataGridView;
                if (grid.Rows[e.RowIndex].Cells["Criticidad"]?.Value == null) return;
                var criticidad = grid.Rows[e.RowIndex].Cells["Criticidad"].Value.ToString();
                grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = criticidad switch
                {
                    "Crítica" => Color.LightCoral,
                    "Alta" => Color.LightSalmon,
                    "Media" => Color.LightGoldenrodYellow,
                    _ => Color.White
                };
            };

            gridAnomaliasSinDatos.RowPrePaint += resaltar;
            gridAnomaliasConDatos.RowPrePaint += resaltar;
            gridRelaciones.RowPrePaint += resaltar;
        }
        


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnDescargar(object sender, EventArgs e)
        {
            // 1. Determinar la pestaña activa y asignar un contexto de log.
            TabPage activeTab = tabControl1.SelectedTab;
            string logContext = "";
            // Puedes ajustar este mapeo según tus convenciones
            switch (activeTab.Name)
            {
                case "tabAnomaliasConDatos":
                    logContext = "AnomaliasConDatos";
                    break;
                case "tabAnomaliasSinDatos":
                    logContext = "AnomaliasSinDatos";
                    break;
                case "tabConstrains":
                    logContext = "Constraints";
                    break;
                case "tabTriggers":
                    logContext = "Triggers";
                    break;
                case "tabRelaciones":
                    logContext = "Relaciones";
                    break;
                default:
                    logContext = "";
                    break;
            }

            // 2. Obtener el DataGridView que está en la pestaña activa.
            DataGridView activeGrid = activeTab.Controls.OfType<DataGridView>().FirstOrDefault();

            // 3. Crear un diccionario para exportar: una hoja con los datos de la pestaña activa.
            Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();
            if (activeGrid != null && activeGrid.DataSource is DataTable activeDataTable)
            {
                tables.Add(activeTab.Text, activeDataTable);
            }
            else
            {
                DataTable dtEmpty = new DataTable();
                dtEmpty.Columns.Add("Mensaje", typeof(string));
                dtEmpty.Rows.Add("No hay datos en esta pestaña.");
                tables.Add(activeTab.Text, dtEmpty);
            }

            // 4. Filtrar el log para incluir solo las entradas correspondientes al contexto.
            string logPath = "AuditLog.txt";
            DataTable dtLog = new DataTable();
            dtLog.Columns.Add("Registro", typeof(string));
            if (File.Exists(logPath) && !string.IsNullOrEmpty(logContext))
            {
                string[] allLines = File.ReadAllLines(logPath);
                foreach (string line in allLines)
                {
                    if (line.Contains($"Contexto: {logContext}"))
                    {
                        dtLog.Rows.Add(line);
                    }
                }
                if (dtLog.Rows.Count == 0)
                {
                    dtLog.Rows.Add($"No hay entradas de log para el contexto '{logContext}'.");
                }
            }
            else
            {
                dtLog.Rows.Add("No se encontró el log de auditoría.");
            }
            tables.Add("Log", dtLog);

            // 5. Mostrar un SaveFileDialog con nombre sugerido según la pestaña y marca de tiempo.
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                FileName = activeTab.Text + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelExporter exporter = new ExcelExporter();
                exporter.ExportMultipleTablesToExcel(tables, saveFileDialog.FileName);
            }
        }
        private void BtnAuditar_Click(object sender, EventArgs e)
        {
            // Lógica para la auditoría individual
            MessageBox.Show("Iniciando auditoría individual...");

            int activeTabIndex = tabControl1.SelectedIndex;
            switch (activeTabIndex)
            {
                case 0:
                    var anomaliasConDatosChecker = new AnomaliasConDatosChecker(_con);
                    DataTable anomaliasConDatosData = anomaliasConDatosChecker.ObtenerAnomaliasConDatos();

                    if (anomaliasConDatosData.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron anomalías con datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    gridAnomaliasConDatos.DataSource = anomaliasConDatosData;
                    gridAnomaliasConDatos.Refresh();
                    break;
                case 1:
                    var anomaliasChecker = new AnomaliasSinDatosChecker(_con);
                    DataTable anomaliasData = anomaliasChecker.ObtenerAnomaliasSinDatos();
                    gridAnomaliasSinDatos.DataSource = anomaliasData;
                    break;
                case 2:
                    var constrains = new ConstrainsChecker(_con);
                    DataTable anomaliasC = constrains.ObtenerConstraints();

                    gridConstrains.DataSource = anomaliasC;
                    break;

                case 3:
                    // Crear instancia de la clase TriggerChecker
                    TriggerChecker triggerChecker = new TriggerChecker(_con);

                    // Obtener triggers y constraints
                    DataTable triggersData = triggerChecker.ObtenerTriggersYConstraints();

                    // Asignar el DataTable al DataGridView de Triggers
                    gridTriggers.DataSource = triggersData;
                    break;  // Siempre se debe agregar un 'break' para evitar que el código continúe con otros casos
                case 4:
                    var relacionesChecker = new RelacionesChecker(_con);
                    DataTable relacionesData = relacionesChecker.ObtenerRelacionesIntegridadReferencial();
                    gridRelaciones.DataSource = relacionesData;
                    break;
                default:
                    MessageBox.Show("Pestaña no reconocida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void BtnDescargarTodo(object sender, EventArgs e)
        {
            Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

            // Recorrer todas las pestañas y obtener los DataGridView.
            foreach (TabPage tab in tabControl1.TabPages)
            {
                DataGridView grid = tab.Controls.OfType<DataGridView>().FirstOrDefault();
                if (grid != null && grid.DataSource is DataTable dt)
                {
                    tables.Add(tab.Text, dt);
                }
                else
                {
                    DataTable dtEmpty = new DataTable();
                    dtEmpty.Columns.Add("Mensaje", typeof(string));
                    dtEmpty.Rows.Add("No hay datos en esta pestaña.");
                    tables.Add(tab.Text, dtEmpty);
                }
            }

            // Agregar el log completo (sin filtrar).
            string logPath = "AuditLog.txt";
            DataTable dtLog = new DataTable();
            dtLog.Columns.Add("Registro", typeof(string));
            if (File.Exists(logPath))
            {
                string[] lines = File.ReadAllLines(logPath);
                foreach (string line in lines)
                {
                    dtLog.Rows.Add(line);
                }
                if (dtLog.Rows.Count == 0)
                {
                    dtLog.Rows.Add("El log de auditoría está vacío.");
                }
            }
            else
            {
                dtLog.Rows.Add("No se encontró el log de auditoría.");
            }
            tables.Add("Log", dtLog);

            // SaveFileDialog con nombre sugerido para "Todo"
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                FileName = "Exportado_Todo_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelExporter exporter = new ExcelExporter();
                exporter.ExportMultipleTablesToExcel(tables, saveFileDialog.FileName);
            }
        }



        private void BtnAuditarTodo_Click(object sender, EventArgs e)
        {
            // Lógica para la auditoría completa
            MessageBox.Show("Iniciando auditoría completa...");

            var anomaliasChecker = new AnomaliasSinDatosChecker(_con);
            DataTable anomaliasData = anomaliasChecker.ObtenerAnomaliasSinDatos();
            gridAnomaliasSinDatos.DataSource = anomaliasData;

            // Auditoría de anomalías con datos
            var anomaliasConDatosChecker = new AnomaliasConDatosChecker(_con);
            DataTable anomaliasConDatosData = anomaliasConDatosChecker.ObtenerAnomaliasConDatos();
            gridAnomaliasConDatos.DataSource = anomaliasConDatosData;

            var constrains = new ConstrainsChecker(_con);
            DataTable anomaliasC = constrains.ObtenerConstraints();

            gridConstrains.DataSource = anomaliasC;
            // Crear instancia de la clase TriggerChecker
            TriggerChecker triggerChecker = new TriggerChecker(_con);

            // Obtener triggers y constraints
            DataTable triggersData = triggerChecker.ObtenerTriggersYConstraints();

            // Asignar el DataTable al DataGridView de Triggers
            gridTriggers.DataSource = triggersData;

            // Relaciones de integridad referencial
            var relacionesChecker = new RelacionesChecker(_con);
            gridRelaciones.DataSource = relacionesChecker.ObtenerRelacionesIntegridadReferencial();
        }
    }
}
