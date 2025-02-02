using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaAuditoria.Clases
{
    public class DatabaseConnection
    {
        private string _server = "localhost";
        private string _database = "BDD_PoliMusic_Song";
        private string _user = "usr_polimusic_gr1";
        private string _password = "Politecnica1";

        // Método para inicializar la conexión

        public DatabaseConnection(string server, string database, string user, string password)
        {
            if (string.IsNullOrWhiteSpace(server) || 
                string.IsNullOrWhiteSpace(database) || 
                string.IsNullOrWhiteSpace(user) || 
                string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Todos los parámetros de la conexión son obligatorios.");
            }

            _server = server;
            _database = database;
            _user = user;
            _password = password;


        }
        // Método para obtener la conexión
        public SqlConnection GetConnection()
        {
            string connectionString = $"Server={_server};Database={_database};User Id={_user};Password={_password};Encrypt=False;";
            SqlConnection _connection = new SqlConnection(connectionString);
            // Verifica si la conexión está configurada correctamente
            if (_connection == null)
            {
                throw new InvalidOperationException("La conexión no ha sido inicializada. Llama a SetConnectionInfo antes de usar la conexión.");
            }

            // Si la conexión está cerrada, abrirla
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        // Método para cerrar la conexión
        public void CloseConnection(SqlConnection _connection)
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
