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
                WHERE NOT EXISTS (
                    SELECT 1 FROM sys.foreign_key_columns fkc
                    WHERE fkc.constraint_object_id = fk.object_id
                )

                UNION ALL

                -- Duplicidad de Datos (Registros repetidos en columnas clave)
                SELECT 
                    'Duplicidad de Datos' AS TipoAnomalia,
                    t.name AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen registros duplicados en ' + t.name AS Descripcion,
                    'Alta' AS Criticidad
                FROM sys.tables t
                WHERE EXISTS (
                    SELECT 1 FROM (
                        SELECT c.name, COUNT(*) OVER(PARTITION BY c.name) AS Duplicados
                        FROM sys.columns c WHERE c.object_id = t.object_id
                    ) AS temp WHERE Duplicados > 1
                )

                UNION ALL

                -- Registros No Utilizados (Datos en tabla padre sin uso en la tabla hija)
                SELECT 
                    'Registros No Utilizados' AS TipoAnomalia,
                    OBJECT_NAME(fk.referenced_object_id) AS TablaOrigen,
                    OBJECT_NAME(fk.parent_object_id) AS TablaDestino,
                    'Registros en ' + OBJECT_NAME(fk.referenced_object_id) + ' no tienen referencias en ' + OBJECT_NAME(fk.parent_object_id) AS Descripcion,
                    'Media' AS Criticidad
                FROM sys.foreign_keys fk
                WHERE NOT EXISTS (
                    SELECT 1 FROM sys.foreign_key_columns fkc
                    WHERE fkc.parent_object_id = fk.parent_object_id
                )

                UNION ALL

                -- Inconsistencias en Relaciones Muchos a Muchos (Duplicados en tablas intermedias)
                SELECT 
                    'Inconsistencias en Relaciones N:N' AS TipoAnomalia,
                    t.name AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen combinaciones duplicadas en ' + t.name AS Descripcion,
                    'Alta' AS Criticidad
                FROM sys.tables t
                WHERE EXISTS (
                    SELECT 1 FROM (
                        SELECT c.name, COUNT(*) OVER(PARTITION BY c.name) AS Duplicados
                        FROM sys.columns c WHERE c.object_id = t.object_id
                    ) AS temp WHERE Duplicados > 1
                )

                UNION ALL

                -- Valores Nulos en Claves Foráneas
                SELECT 
                    'Valores Nulos en Claves Foráneas' AS TipoAnomalia,
                    OBJECT_NAME(fkc.parent_object_id) AS TablaOrigen,
                    OBJECT_NAME(fkc.referenced_object_id) AS TablaDestino,
                    'Existen valores nulos en la clave foránea de ' + OBJECT_NAME(fkc.parent_object_id) AS Descripcion,
                    'Media' AS Criticidad
                FROM sys.foreign_key_columns fkc
                JOIN sys.columns c ON fkc.parent_object_id = c.object_id AND fkc.parent_column_id = c.column_id
                WHERE c.is_nullable = 1

                UNION ALL

                -- Fechas y Estados Inconsistentes
                SELECT 
                    'Fechas y Estados Inconsistentes' AS TipoAnomalia,
                    t.name AS TablaOrigen,
                    '' AS TablaDestino,
                    'Existen fechas inconsistentes en ' + t.name AS Descripcion,
                    'Media' AS Criticidad
                FROM sys.tables t
                JOIN sys.columns c ON t.object_id = c.object_id
                WHERE c.system_type_id IN (40, 41, 42) -- Tipos de fecha
                AND EXISTS (
                    SELECT 1 FROM sys.columns c
                    WHERE c.object_id = t.object_id
                    AND c.name LIKE '%date%'
                    AND TRY_CAST(c.name AS DATE) IS NOT NULL
                    AND (TRY_CAST(c.name AS DATE) < '2000-01-01' OR TRY_CAST(c.name AS DATE) > GETDATE())
                )

                UNION ALL

                -- Errores en Claves Compuestas
                SELECT 
                    'Errores en Claves Compuestas' AS TipoAnomalia,
                    OBJECT_NAME(fkc.parent_object_id) AS TablaOrigen,
                    OBJECT_NAME(fkc.referenced_object_id) AS TablaDestino,
                    'Existen inconsistencias en la clave compuesta de ' + OBJECT_NAME(fkc.parent_object_id) AS Descripcion,
                    'Alta' AS Criticidad
                FROM sys.foreign_key_columns fkc
                WHERE EXISTS (
                    SELECT 1 FROM sys.columns c WHERE fkc.parent_object_id = c.object_id AND c.is_nullable = 1
                )
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
