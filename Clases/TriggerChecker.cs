using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SistemaAuditoria.Clases
{
    public class TriggerChecker
    {
        private readonly DatabaseConnection _dbConnection;

        public TriggerChecker(DatabaseConnection dbConnection)
        {
            Console.WriteLine(dbConnection);
            _dbConnection = dbConnection;
        }

        public DataTable ObtenerTriggersYConstraints()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT 
                    t.name AS NombreTrigger,
                    p.name AS TablaAsociada,
                    CASE 
                        WHEN t.is_instead_of_trigger = 1 THEN 'INSTEAD OF'
                        ELSE 'AFTER'
                    END AS TipoTrigger,
                    e.type_desc AS Evento,
                    CASE 
                        WHEN t.is_disabled = 1 THEN 'Deshabilitado' 
                        ELSE 'Habilitado' 
                    END AS Estado
                FROM sys.triggers t
                JOIN sys.tables p ON t.parent_id = p.object_id
                JOIN sys.trigger_events e ON t.object_id = e.object_id
                ORDER BY p.name, t.name, e.type_desc;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
               ;
            }
            catch (Exception ex)
            {
                // Puedes loggear el error o lanzar una excepción personalizada
                throw new InvalidOperationException("Error al ejecutar la consulta para obtener triggers y constraints.", ex);
            }

            return dt;
        }
    }
}
