using Microsoft.Data.SqlClient;
using SistemaAuditoria.Clases;
using System.Data;
using System.Windows.Forms;

namespace SistemaAuditoria
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAuditar = new Button();
            btnAuditarTodo = new Button();
            lblTitulo = new Label();
            button1 = new Button();
            tabTriggers = new TabPage();
            gridTriggers = new DataGridView();
            tabConstrains = new TabPage();
            gridConstrains = new DataGridView();
            tabAnomaliasSinDatos = new TabPage();
            gridAnomaliasSinDatos = new DataGridView();
            tabAnomaliasConDatos = new TabPage();
            gridAnomaliasConDatos = new DataGridView();
            btnDescargarTodo = new Button();
            ///
            /// btnDescargarTodo
            ///     
            btnDescargarTodo.BackColor = Color.LightBlue;
            btnDescargarTodo.Location = new Point(442, 386);
            btnDescargarTodo.Name = "btnDescargarTodo";
            btnDescargarTodo.Size = new Size(183, 29);
            btnDescargarTodo.TabIndex = 4;
            btnDescargarTodo.Text = "Descargar Todo";
            btnDescargarTodo.UseVisualStyleBackColor = false;
            btnDescargarTodo.Click += BtnDescargarTodo;
            Controls.Add(btnDescargarTodo);

            // Nueva pestaña para Relaciones
            tabRelaciones = new TabPage();
            gridRelaciones = new DataGridView();
            tabControl1 = new TabControl();
            tabTriggers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTriggers).BeginInit();
            tabConstrains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConstrains).BeginInit();
            tabAnomaliasSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasSinDatos).BeginInit();
            tabAnomaliasConDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasConDatos).BeginInit();
            tabRelaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRelaciones).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAuditar
            // 
            btnAuditar.BackColor = System.Drawing.Color.LightGray;
            btnAuditar.Location = new System.Drawing.Point(121, 107);
            btnAuditar.Name = "btnAuditar";
            btnAuditar.Size = new System.Drawing.Size(248, 36);
            btnAuditar.TabIndex = 0;
            btnAuditar.Text = "Comprobar Actual ";
            btnAuditar.UseVisualStyleBackColor = false;
            btnAuditar.Click += BtnAuditar_Click;
            // 
            // btnAuditarTodo
            // 
            btnAuditarTodo.BackColor = System.Drawing.Color.LightGray;
            btnAuditarTodo.Location = new System.Drawing.Point(442, 107);
            btnAuditarTodo.Name = "btnAuditarTodo";
            btnAuditarTodo.Size = new System.Drawing.Size(248, 36);
            btnAuditarTodo.TabIndex = 1;
            btnAuditarTodo.Text = "Comprobar todos los apartados ";
            btnAuditarTodo.UseVisualStyleBackColor = false;
            btnAuditarTodo.Click += BtnAuditarTodo_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font("Segoe UI Historic", 20F, System.Drawing.FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(156, 47);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(501, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Auditoría de bases de datos";
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Chartreuse;
            button1.Location = new System.Drawing.Point(190, 386);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(183, 29);
            button1.TabIndex = 3;
            button1.Text = "Descargar Auditoria ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnDescargar;
            // 
            // tabTriggers
            // 
            tabTriggers.Controls.Add(gridTriggers);
            tabTriggers.Location = new System.Drawing.Point(4, 24);
            tabTriggers.Name = "tabTriggers";
            tabTriggers.Padding = new System.Windows.Forms.Padding(3);
            tabTriggers.Size = new System.Drawing.Size(716, 189);
            tabTriggers.TabIndex = 3;
            tabTriggers.Text = "Triggers";
            tabTriggers.UseVisualStyleBackColor = true;
            // 
            // gridTriggers
            // 
            gridTriggers.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            gridTriggers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTriggers.Location = new System.Drawing.Point(6, 6);
            gridTriggers.Name = "gridTriggers";
            gridTriggers.RowHeadersWidth = 51;
            gridTriggers.Size = new System.Drawing.Size(704, 172);
            gridTriggers.TabIndex = 1;
            // 
            // tabConstrains
            // 
            tabConstrains.Controls.Add(gridConstrains);
            tabConstrains.Location = new System.Drawing.Point(4, 24);
            tabConstrains.Name = "tabConstrains";
            tabConstrains.Padding = new System.Windows.Forms.Padding(3);
            tabConstrains.Size = new System.Drawing.Size(716, 189);
            tabConstrains.TabIndex = 2;
            tabConstrains.Text = "Constrains";
            tabConstrains.UseVisualStyleBackColor = true;
            // 
            // gridConstrains
            // 
            gridConstrains.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            gridConstrains.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridConstrains.Location = new System.Drawing.Point(6, 6);
            gridConstrains.Name = "gridConstrains";
            gridConstrains.RowHeadersWidth = 51;
            gridConstrains.Size = new System.Drawing.Size(704, 172);
            gridConstrains.TabIndex = 1;
            // 
            // tabAnomaliasSinDatos
            // 
            tabAnomaliasSinDatos.Controls.Add(gridAnomaliasSinDatos);
            tabAnomaliasSinDatos.Location = new System.Drawing.Point(4, 24);
            tabAnomaliasSinDatos.Name = "tabAnomaliasSinDatos";
            tabAnomaliasSinDatos.Padding = new System.Windows.Forms.Padding(3);
            tabAnomaliasSinDatos.Size = new System.Drawing.Size(716, 189);
            tabAnomaliasSinDatos.TabIndex = 1;
            tabAnomaliasSinDatos.Text = "Anomalías sin Datos";
            tabAnomaliasSinDatos.UseVisualStyleBackColor = true;
            // 
            // gridAnomaliasSinDatos
            // 
            gridAnomaliasSinDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            gridAnomaliasSinDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAnomaliasSinDatos.Location = new System.Drawing.Point(6, 6);
            gridAnomaliasSinDatos.Name = "gridAnomaliasSinDatos";
            gridAnomaliasSinDatos.RowHeadersWidth = 51;
            gridAnomaliasSinDatos.Size = new System.Drawing.Size(704, 172);
            gridAnomaliasSinDatos.TabIndex = 1;
            // 
            // tabAnomaliasConDatos
            // 
            tabAnomaliasConDatos.Controls.Add(gridAnomaliasConDatos);
            tabAnomaliasConDatos.Location = new System.Drawing.Point(4, 24);
            tabAnomaliasConDatos.Name = "tabAnomaliasConDatos";
            tabAnomaliasConDatos.Padding = new System.Windows.Forms.Padding(3);
            tabAnomaliasConDatos.Size = new System.Drawing.Size(716, 189);
            tabAnomaliasConDatos.TabIndex = 0;
            tabAnomaliasConDatos.Text = "Anomalías con Datos";
            tabAnomaliasConDatos.UseVisualStyleBackColor = true;
            // 
            // gridAnomaliasConDatos
            // 
            gridAnomaliasConDatos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            gridAnomaliasConDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAnomaliasConDatos.Location = new System.Drawing.Point(6, 6);
            gridAnomaliasConDatos.Name = "gridAnomaliasConDatos";
            gridAnomaliasConDatos.RowHeadersWidth = 51;
            gridAnomaliasConDatos.Size = new System.Drawing.Size(704, 172);
            gridAnomaliasConDatos.TabIndex = 0;
            // 
            // tabRelaciones
            // 
            tabRelaciones.Controls.Add(gridRelaciones);
            tabRelaciones.Location = new System.Drawing.Point(4, 24);
            tabRelaciones.Name = "tabRelaciones";
            tabRelaciones.Padding = new System.Windows.Forms.Padding(3);
            tabRelaciones.Size = new System.Drawing.Size(716, 189);
            tabRelaciones.TabIndex = 4; // Se asigna un índice adecuado
            tabRelaciones.Text = "Relaciones";
            tabRelaciones.UseVisualStyleBackColor = true;
            // 
            // gridRelaciones
            // 
            gridRelaciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            gridRelaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRelaciones.Location = new System.Drawing.Point(6, 6);
            gridRelaciones.Name = "gridRelaciones";
            gridRelaciones.RowHeadersWidth = 51;
            gridRelaciones.Size = new System.Drawing.Size(704, 172);
            gridRelaciones.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabAnomaliasConDatos);
            tabControl1.Controls.Add(tabAnomaliasSinDatos);
            tabControl1.Controls.Add(tabConstrains);
            tabControl1.Controls.Add(tabTriggers);
            tabControl1.Controls.Add(tabRelaciones); // Se añade la nueva pestaña
            tabControl1.Location = new System.Drawing.Point(40, 163);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(724, 217);
            tabControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Controls.Add(lblTitulo);
            Controls.Add(btnAuditar);
            Controls.Add(btnAuditarTodo);
            Name = "MainForm";
            Text = "Auditoría de Base de Datos";
            tabTriggers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridTriggers).EndInit();
            tabConstrains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConstrains).EndInit();
            tabAnomaliasSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasSinDatos).EndInit();
            tabAnomaliasConDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasConDatos).EndInit();
            tabRelaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRelaciones).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAuditar;
        private Button btnAuditarTodo;
        private Button btnDescargarTodo;
        private Label lblTitulo;
        private Button button1;
        private TabPage tabTriggers;
        private DataGridView gridTriggers;
        private TabPage tabConstrains;
        private DataGridView gridConstrains;
        private TabPage tabAnomaliasSinDatos;
        private DataGridView gridAnomaliasSinDatos;
        private TabPage tabAnomaliasConDatos;
        private DataGridView gridAnomaliasConDatos;
        // Declaramos la nueva pestaña y grid para relaciones
        private TabPage tabRelaciones;
        private DataGridView gridRelaciones;
        private TabControl tabControl1;
    }
}
