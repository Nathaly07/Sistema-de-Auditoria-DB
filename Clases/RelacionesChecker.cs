using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaAuditoria.Clases
{
    public class RelacionesChecker
    {
        private readonly DatabaseConnection _dbConnection;

        public RelacionesChecker(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DataTable ObtenerRelacionesIntegridadReferencial()
        {
            DataTable dt = new DataTable();
            string query = @"
            -- Relaciones existentes
            SELECT 
                'Existente' AS TipoRelacion,
                OBJECT_NAME(fk.parent_object_id) AS TablaOrigen,
                COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS ColumnaOrigen,
                OBJECT_NAME(fk.referenced_object_id) AS TablaDestino,
                'Relación existente entre ' + OBJECT_NAME(fk.parent_object_id) + ' y ' + OBJECT_NAME(fk.referenced_object_id) AS Descripcion,
                'N/A' AS Criticidad
            FROM sys.foreign_keys fk
            JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id

            UNION ALL

            -- Relaciones faltantes (según convención: columna que termina en ''Id'' cuyo prefijo corresponda a un nombre de tabla existente)
            SELECT 
                'Faltante' AS TipoRelacion,
                t.name AS TablaOrigen,
                c.name AS ColumnaOrigen,
                rt.name AS TablaDestino,
                'Se espera que la columna ' + c.name + ' en la tabla ' + t.name + ' tenga una relación con la tabla ' + rt.name AS Descripcion,
                'Crítica' AS Criticidad
            FROM sys.tables t
            JOIN sys.columns c ON t.object_id = c.object_id
            JOIN sys.tables rt ON rt.name = LEFT(c.name, LEN(c.name) - 2)
            WHERE c.name LIKE '%Id' 
              AND c.name <> 'Id'
              AND NOT EXISTS (
                  SELECT 1 
                  FROM sys.foreign_key_columns fkc 
                  WHERE fkc.parent_object_id = t.object_id
                    AND fkc.parent_column_id = c.column_id
              )
            ORDER BY TipoRelacion, TablaOrigen;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                // Loguear cada relación encontrada
                foreach (DataRow row in dt.Rows)
                {
                    AuditLogger.Log("Relaciones", row["Descripcion"].ToString(), row["Criticidad"].ToString());
                }
            }
            catch (Exception ex)
            {
                AuditLogger.Log("Relaciones", "Error al obtener relaciones: " + ex.Message, "Crítica");
                throw new InvalidOperationException("Error al obtener relaciones de integridad referencial.", ex);
            }
            return dt;
        }
    }
}
