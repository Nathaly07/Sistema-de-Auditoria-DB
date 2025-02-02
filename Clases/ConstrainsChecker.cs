using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SistemaAuditoria.Clases
{
    internal class ConstrainsChecker
    {
        private readonly DatabaseConnection _dbConnection;

        public ConstrainsChecker(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DataTable ObtenerConstraints()
        {
            DataTable dt = new DataTable();
            string query = @"
SELECT 
    tc.TABLE_NAME AS 'Tabla',
    tc.CONSTRAINT_NAME AS 'Nombre_Restriccion',
    tc.CONSTRAINT_TYPE AS 'Tipo_Restriccion',
    kcu.COLUMN_NAME AS 'Columna_Afectada',
    fk_tabla.name AS 'Tabla_Referenciada',
    fk_columna.name AS 'Columna_Referenciada',
    cc.definition AS 'Condicion_Check',
    CASE 
        WHEN fk.is_disabled = 1 OR cc.is_disabled = 1 THEN 'No'
        ELSE 'Sí'
    END AS 'Esta_Activo'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu 
    ON tc.CONSTRAINT_NAME = kcu.CONSTRAINT_NAME 
    AND tc.TABLE_NAME = kcu.TABLE_NAME
LEFT JOIN sys.check_constraints cc 
    ON tc.CONSTRAINT_NAME = cc.name
LEFT JOIN sys.foreign_keys fk 
    ON tc.CONSTRAINT_NAME = fk.name
LEFT JOIN sys.foreign_key_columns fkc 
    ON fk.object_id = fkc.constraint_object_id
LEFT JOIN sys.columns fk_columna 
    ON fkc.referenced_object_id = fk_columna.object_id 
    AND fkc.referenced_column_id = fk_columna.column_id
LEFT JOIN sys.tables fk_tabla 
    ON fk.referenced_object_id = fk_tabla.object_id
WHERE tc.TABLE_CATALOG = DB_NAME();";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                // Loguear cada restricción obtenida
                foreach (DataRow row in dt.Rows)
                {
                    string msg = $"Restricción: {row["Nombre_Restriccion"]} en tabla {row["Tabla"]} (Tipo: {row["Tipo_Restriccion"]})";
                    AuditLogger.Log("Constraints", msg, "Info");
                }
            }
            catch (Exception ex)
            {
                AuditLogger.Log("Constraints", "Error al obtener constraints: " + ex.Message, "Crítica");
                throw new InvalidOperationException("Error al ejecutar la consulta para obtener constraints.", ex);
            }
            return dt;
        }
    }
}
