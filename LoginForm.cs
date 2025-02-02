using Microsoft.Data.SqlClient;
using SistemaAuditoria.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaAuditoria
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Cierra completamente la aplicación
        }

        private void IngresaButton_Click(object sender, EventArgs e)
        {
            string server = txtserver.Text.Trim();
            string database = txtBase.Text.Trim();
            string user = txtuser.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(server) ||
                string.IsNullOrWhiteSpace(database) ||
                string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection database_con = new DatabaseConnection(server, database, user, password);
             

                // Intentar abrir la conexión
                using (SqlConnection conn = database_con.GetConnection())
                {
                    MessageBox.Show("Conexión exitosa", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                // Ocultar el login y abrir MainForm
                this.Hide();
                MainForm mainForm = new MainForm(database_con);
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message, "Login Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
    

