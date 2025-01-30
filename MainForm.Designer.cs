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
            tabAnomaliasConDatos = new TabPage();
            gridAnomaliasConDatos = new DataGridView();
            tabControl1 = new TabControl();
            tabAnomaliasSinDatos = new TabPage();
            gridAnomaliasSinDatos = new DataGridView();
            tabConstrains = new TabPage();
            gridConstrains = new DataGridView();
            tabTriggers = new TabPage();
            gridTriggers = new DataGridView();
            button1 = new Button();
            tabAnomaliasConDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasConDatos).BeginInit();
            tabControl1.SuspendLayout();
            tabAnomaliasSinDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasSinDatos).BeginInit();
            tabConstrains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConstrains).BeginInit();
            tabTriggers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTriggers).BeginInit();
            SuspendLayout();
            // 
            // btnAuditar
            // 
            btnAuditar.BackColor = Color.LightGray;
            btnAuditar.Location = new Point(121, 107);
            btnAuditar.Name = "btnAuditar";
            btnAuditar.Size = new Size(248, 36);
            btnAuditar.TabIndex = 0;
            btnAuditar.Text = "Comprobar Actual ";
            btnAuditar.UseVisualStyleBackColor = false;
            btnAuditar.Click += BtnAuditar_Click;
            // 
            // btnAuditarTodo
            // 
            btnAuditarTodo.BackColor = Color.LightGray;
            btnAuditarTodo.Location = new Point(442, 107);
            btnAuditarTodo.Name = "btnAuditarTodo";
            btnAuditarTodo.Size = new Size(248, 36);
            btnAuditarTodo.TabIndex = 1;
            btnAuditarTodo.Text = "Comprobar todos los apartados ";
            btnAuditarTodo.UseVisualStyleBackColor = false;
            btnAuditarTodo.Click += BtnAuditarTodo_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI Historic", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(156, 47);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(501, 48);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Auditoría de bases de datos";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabAnomaliasConDatos
            // 
            tabAnomaliasConDatos.Controls.Add(gridAnomaliasConDatos);
            tabAnomaliasConDatos.Location = new Point(4, 29);
            tabAnomaliasConDatos.Name = "tabAnomaliasConDatos";
            tabAnomaliasConDatos.Padding = new Padding(3);
            tabAnomaliasConDatos.Size = new Size(716, 184);
            tabAnomaliasConDatos.TabIndex = 0;
            tabAnomaliasConDatos.Text = "Anomalías con Datos";
            tabAnomaliasConDatos.UseVisualStyleBackColor = true;
            // 
            // gridAnomaliasConDatos
            // 
            gridAnomaliasConDatos.BackgroundColor = SystemColors.ButtonHighlight;
            gridAnomaliasConDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAnomaliasConDatos.Location = new Point(6, 6);
            gridAnomaliasConDatos.Name = "gridAnomaliasConDatos";
            gridAnomaliasConDatos.RowHeadersWidth = 51;
            gridAnomaliasConDatos.Size = new Size(704, 172);
            gridAnomaliasConDatos.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabAnomaliasConDatos);
            tabControl1.Controls.Add(tabAnomaliasSinDatos);
            tabControl1.Controls.Add(tabConstrains);
            tabControl1.Controls.Add(tabTriggers);
            tabControl1.Location = new Point(40, 163);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(724, 217);
            tabControl1.TabIndex = 2;
            // 
            // tabAnomaliasSinDatos
            // 
            tabAnomaliasSinDatos.Controls.Add(gridAnomaliasSinDatos);
            tabAnomaliasSinDatos.Location = new Point(4, 29);
            tabAnomaliasSinDatos.Name = "tabAnomaliasSinDatos";
            tabAnomaliasSinDatos.Padding = new Padding(3);
            tabAnomaliasSinDatos.Size = new Size(716, 184);
            tabAnomaliasSinDatos.TabIndex = 1;
            tabAnomaliasSinDatos.Text = "Anomalías sin Datos";
            tabAnomaliasSinDatos.UseVisualStyleBackColor = true;
            // 
            // gridAnomaliasSinDatos
            // 
            gridAnomaliasSinDatos.BackgroundColor = SystemColors.ButtonHighlight;
            gridAnomaliasSinDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridAnomaliasSinDatos.Location = new Point(6, 6);
            gridAnomaliasSinDatos.Name = "gridAnomaliasSinDatos";
            gridAnomaliasSinDatos.RowHeadersWidth = 51;
            gridAnomaliasSinDatos.Size = new Size(704, 172);
            gridAnomaliasSinDatos.TabIndex = 1;
            // 
            // tabConstrains
            // 
            tabConstrains.Controls.Add(gridConstrains);
            tabConstrains.Location = new Point(4, 29);
            tabConstrains.Name = "tabConstrains";
            tabConstrains.Padding = new Padding(3);
            tabConstrains.Size = new Size(716, 184);
            tabConstrains.TabIndex = 2;
            tabConstrains.Text = "Constrains";
            tabConstrains.UseVisualStyleBackColor = true;
            // 
            // gridConstrains
            // 
            gridConstrains.BackgroundColor = SystemColors.ButtonHighlight;
            gridConstrains.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridConstrains.Location = new Point(6, 6);
            gridConstrains.Name = "gridConstrains";
            gridConstrains.RowHeadersWidth = 51;
            gridConstrains.Size = new Size(704, 172);
            gridConstrains.TabIndex = 1;
            // 
            // tabTriggers
            // 
            tabTriggers.Controls.Add(gridTriggers);
            tabTriggers.Location = new Point(4, 29);
            tabTriggers.Name = "tabTriggers";
            tabTriggers.Padding = new Padding(3);
            tabTriggers.Size = new Size(716, 184);
            tabTriggers.TabIndex = 3;
            tabTriggers.Text = "Triggers";
            tabTriggers.UseVisualStyleBackColor = true;
            // 
            // gridTriggers
            // 
            gridTriggers.BackgroundColor = SystemColors.ButtonHighlight;
            gridTriggers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTriggers.Location = new Point(6, 6);
            gridTriggers.Name = "gridTriggers";
            gridTriggers.RowHeadersWidth = 51;
            gridTriggers.Size = new Size(704, 172);
            gridTriggers.TabIndex = 1;
            // 
            // Descargar
            // 
            button1.BackColor = Color.Chartreuse;
            button1.Location = new Point(290, 386);
            button1.Name = "button1";
            button1.Size = new Size(183, 29);
            button1.TabIndex = 3;
            button1.Text = "Descargar Auditoria ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BtnDescargar;
            // 
            // Principal
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Controls.Add(lblTitulo);
            Controls.Add(btnAuditar);
            Controls.Add(btnAuditarTodo);
            Name = "Principal";
            Text = "Auditoría de Base de Datos";
            tabAnomaliasConDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasConDatos).EndInit();
            tabControl1.ResumeLayout(false);
            tabAnomaliasSinDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridAnomaliasSinDatos).EndInit();
            tabConstrains.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConstrains).EndInit();
            tabTriggers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridTriggers).EndInit();
            ResumeLayout(false);
        }

   

        #endregion

        private Button btnAuditar;
        private Button btnAuditarTodo;
        private Label lblTitulo;
        private TabPage tabAnomaliasConDatos;
        private DataGridView gridAnomaliasConDatos;
        private TabControl tabControl1;
        private TabPage tabAnomaliasSinDatos;
        private DataGridView gridAnomaliasSinDatos;
        private TabPage tabConstrains;
        private DataGridView gridConstrains;
        private TabPage tabTriggers;
        private DataGridView gridTriggers;
        private Button button1;
    }
}