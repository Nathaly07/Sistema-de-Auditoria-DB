using Microsoft.Data.SqlClient;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Cierra completamente la aplicaci�n
        }

        private void IngresaButton_Click(object sender, EventArgs e)
        {
            string server = txtserver.Text.Trim();
            string user = txtuser.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener la ejecuci�n si hay campos vac�os
            }

            string connectionString = $"Server={server};Database=master;User Id={user};Password={password};TrustServerCertificate=True;";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexi�n exitosa", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexi�n: " + ex.Message, "Login Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
