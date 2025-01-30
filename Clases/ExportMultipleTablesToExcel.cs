using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaAuditoria.Clases
{
    public class ExcelExporter
    {
        public void ExportMultipleTablesToExcel(Dictionary<string, DataTable> tables, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                bool addedWorksheet = false; // Para verificar si se han agregado hojas

                foreach (var table in tables)
                {
                    // Verificar si la tabla tiene datos
                    if (table.Value != null && table.Value.Rows.Count > 0)
                    {
                        var worksheet = workbook.AddWorksheet(table.Key); // Usamos el nombre de la tabla como el nombre de la hoja
                        addedWorksheet = true; // Se agrega una hoja al libro

                        // Escribir los encabezados de las columnas
                        for (int col = 0; col < table.Value.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = table.Value.Columns[col].ColumnName;
                        }

                        // Escribir las filas de datos
                        for (int row = 0; row < table.Value.Rows.Count; row++)
                        {
                            for (int col = 0; col < table.Value.Columns.Count; col++)
                            {
                                // Controlar valores nulos y escribir solo valores válidos
                                worksheet.Cell(row + 2, col + 1).Value = table.Value.Rows[row][col] != DBNull.Value
                                    ? table.Value.Rows[row][col].ToString()
                                    : string.Empty; // En caso de valor nulo, dejar vacío
                            }
                        }
                    }
                }

                // Verificar si se agregaron hojas, si no, agregar una hoja vacía
                if (!addedWorksheet)
                {
                    var worksheet = workbook.AddWorksheet("EmptySheet"); // Hoja vacía si no hay datos
                    worksheet.Cell(1, 1).Value = "No hay datos disponibles"; // Mensaje en la primera celda
                }

                // Guardar el archivo de Excel
                workbook.SaveAs(fileName);
            }

            MessageBox.Show("Todas las tablas han sido exportadas a un único archivo Excel.");
        }
    }
}
