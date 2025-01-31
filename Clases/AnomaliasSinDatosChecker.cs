using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace SistemaAuditoria.Clases
{
    public class AnomaliasSinDatosChecker
    {
        private readonly DatabaseConnection _dbConnection;

        public AnomaliasSinDatosChecker(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public DataTable ObtenerAnomaliasSinDatos()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT * FROM (
                    -- Tablas sin clave primaria
                    SELECT 
                        t.name AS Tabla,
                        'Falta clave primaria' AS Anomalia,
                        '' AS Detalle,
                        'Alta' AS Criticidad
                    FROM sys.tables t
                    LEFT JOIN sys.indexes i ON t.object_id = i.object_id AND i.is_primary_key = 1
                    WHERE i.object_id IS NULL

                    UNION ALL

                    -- FK inválidas
                    SELECT 
                        OBJECT_NAME(fkc.parent_object_id) AS Tabla,
                        'FK inválida' AS Anomalia,
                        fk.name + ' referencia a columna no PK/Unique' AS Detalle,
                        'Crítica' AS Criticidad
                    FROM sys.foreign_keys fk
                    JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM sys.index_columns ic
                        WHERE ic.object_id = fk.referenced_object_id
                        AND ic.column_id = fkc.referenced_column_id
                        AND ic.index_id IN (
                            SELECT index_id 
                            FROM sys.indexes 
                            WHERE is_primary_key = 1 OR is_unique = 1
                        )
                    )

                    UNION ALL

                    -- Tipos incompatibles
                    SELECT
                        OBJECT_NAME(fkc.parent_object_id) AS Tabla,
                        'Incompatibilidad de tipos' AS Anomalia,
                        'Columna ' + pc.name + ' (' + pt.name + ') vs ' + rc.name + ' (' + rt.name + ')' AS Detalle,
                        'Media' AS Criticidad
                    FROM sys.foreign_keys fk
                    JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                    JOIN sys.columns pc ON fkc.parent_object_id = pc.object_id AND fkc.parent_column_id = pc.column_id
                    JOIN sys.columns rc ON fkc.referenced_object_id = rc.object_id AND fkc.referenced_column_id = rc.column_id
                    JOIN sys.types pt ON pc.system_type_id = pt.system_type_id
                    JOIN sys.types rt ON rc.system_type_id = rt.system_type_id
                    WHERE pt.name != rt.name

                    UNION ALL

                    -- Cascada no definida
                    SELECT
                        OBJECT_NAME(fk.parent_object_id) AS Tabla,
                        'Acción de cascada faltante' AS Anomalia,
                        fk.name + ' - Sin ON DELETE/UPDATE ACTION' AS Detalle,
                        'Media' AS Criticidad
                    FROM sys.foreign_keys fk
                    WHERE delete_referential_action = 0 AND update_referential_action = 0

                    UNION ALL

                    -- Nomenclatura
                    SELECT
                        OBJECT_NAME(fk.parent_object_id) AS Tabla,
                        'Nombre no estándar' AS Anomalia,
                        fk.name + ' no sigue convención FK_TablaOrigen_TablaDestino' AS Detalle,
                        'Baja' AS Criticidad
                    FROM sys.foreign_keys fk
                    WHERE fk.name NOT LIKE 'FK_' + OBJECT_NAME(fk.parent_object_id) + '_' + OBJECT_NAME(fk.referenced_object_id) + '%'

                    UNION ALL

                    -- Relaciones circulares
                    SELECT
                        OBJECT_NAME(fk1.parent_object_id) AS Tabla,
                        'Posible relación circular' AS Anomalia,
                        'Relación entre ' + OBJECT_NAME(fk1.parent_object_id) + ' y ' + OBJECT_NAME(fk1.referenced_object_id) AS Detalle,
                        'Alta' AS Criticidad
                    FROM sys.foreign_keys fk1
                    JOIN sys.foreign_keys fk2 ON fk1.referenced_object_id = fk2.parent_object_id
                    WHERE fk2.referenced_object_id = fk1.parent_object_id
                ) AS Resultados  -- ¡Este cierre estaba faltando!
                ORDER BY 
                    CASE Criticidad
                        WHEN 'Crítica' THEN 1
                        WHEN 'Alta' THEN 2
                        WHEN 'Media' THEN 3
                        ELSE 4
                    END, 
                    Tabla;";


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
                throw new InvalidOperationException("Error al obtener anomalías sin datos", ex);
            }

            return dt;
        }
    }
}