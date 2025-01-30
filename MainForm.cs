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
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnDescargar(object sender, EventArgs e)
        {
            Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();

            // Agregar tablas con sus nombres correspondientes
            tables.Add("Anomalias_Con_Datos", gridAnomaliasConDatos.DataSource as DataTable);
            tables.Add("Anomalias_Sin_Datos", gridAnomaliasSinDatos.DataSource as DataTable);
            tables.Add("Constrains", gridConstrains.DataSource as DataTable);
            tables.Add("Triggers", gridTriggers.DataSource as DataTable);

            // Crear el exportador y llamar al método para exportar
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                FileName = "Exportado.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var exporter = new ExcelExporter();
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
                case 3:
                    // Crear instancia de la clase TriggerChecker
                    TriggerChecker triggerChecker = new TriggerChecker(_con);

                    // Obtener triggers y constraints
                    DataTable triggersData = triggerChecker.ObtenerTriggersYConstraints();

                    // Asignar el DataTable al DataGridView de Triggers
                    gridTriggers.DataSource = triggersData;
                    break;  // Siempre se debe agregar un 'break' para evitar que el código continúe con otros casos
            }
        }


        private void BtnAuditarTodo_Click(object sender, EventArgs e)
        {
            // Lógica para la auditoría completa
            MessageBox.Show("Iniciando auditoría completa...");

            // Crear instancia de la clase TriggerChecker
            TriggerChecker triggerChecker = new TriggerChecker(_con);

            // Obtener triggers y constraints
            DataTable triggersData = triggerChecker.ObtenerTriggersYConstraints();

            // Asignar el DataTable al DataGridView de Triggers
            gridTriggers.DataSource = triggersData;
        }
    }
}
