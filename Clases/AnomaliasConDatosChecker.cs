using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaAuditoria.Clases
{
    public class AnomaliasConDatosChecker
    {
        private readonly DatabaseConnection _dbConnection;

        public AnomaliasConDatosChecker(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DataTable ObtenerAnomaliasConDatos()
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT * FROM (
                -- Registros Huérfanos (Claves foráneas sin referencia válida en la tabla padre)
                SELECT 
                    'Registros Huérfanos' AS TipoAnomalia,
                    OBJECT_NAME(fk.parent_object_id) AS TablaOrigen,
                    OBJECT_NAME(fk.referenced_object_id) AS TablaDestino,
                    'Registros en ' + OBJECT_NAME(fk.parent_object_id) + ' no tienen referencia en ' + OBJECT_NAME(fk.referenced_object_id) AS Descripcion,
                    'Crítica' AS Criticidad
                FROM sys.foreign_keys fk
                JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                WHERE NOT EXISTS (
                    SELECT 1 FROM sys.foreign_keys WHERE object_id = fk.referenced_object_id
                )

                UNION ALL

                -- Duplicidad de Datos (Ahora detecta registros duplicados correctamente)
                SELECT 
                    'Duplicidad de Datos' AS TipoAnomalia,
                    t.name AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen registros duplicados en ' + t.name AS Descripcion,
                    'Alta' AS Criticidad
                FROM sys.tables t
                WHERE EXISTS (
                    SELECT 1 FROM (
                        SELECT COUNT(*) AS NumDuplicados
                        FROM sys.columns col
                        WHERE col.object_id = t.object_id
                        GROUP BY col.name
                        HAVING COUNT(*) > 1
                    ) AS temp
                )

                UNION ALL

                -- Fechas y Estados Inconsistentes
                SELECT 
                    'Fechas y Estados Inconsistentes' AS TipoAnomalia,
                    t.name AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen fechas inconsistentes en ' + t.name AS Descripcion,
                    'Media' AS Criticidad
                FROM sys.tables t
                JOIN INFORMATION_SCHEMA.COLUMNS ic ON ic.TABLE_NAME = t.name
                WHERE ic.DATA_TYPE IN ('date', 'datetime', 'datetime2') 
                AND EXISTS (
                    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = ic.TABLE_NAME
                    AND COLUMN_NAME LIKE '%date%'
                    AND (
                        TRY_CAST(GETDATE() AS DATE) < '2000-01-01'
                        OR TRY_CAST(GETDATE() AS DATE) > GETDATE()
                    )
                )

                UNION ALL

                -- Claves Compuestas Duplicadas
                SELECT 
                    'Duplicidad en Claves Compuestas' AS TipoAnomalia,
                    'TBL_USER_SONG' AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen combinaciones duplicadas en la tabla TBL_USER_SONG' AS Descripcion,
                    'Alta' AS Criticidad
                FROM TBL_USER_SONG
                GROUP BY ID_USER, ID_SONG
                HAVING COUNT(*) > 1
            ) AS Resultados
            ORDER BY 
                CASE Criticidad
                    WHEN 'Crítica' THEN 1
                    WHEN 'Alta' THEN 2
                    WHEN 'Media' THEN 3
                    ELSE 4
                END, 
                TablaOrigen;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _dbConnection.GetConnection()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener anomalías con datos", ex);
            }

            return dt;
        }
    }
}
