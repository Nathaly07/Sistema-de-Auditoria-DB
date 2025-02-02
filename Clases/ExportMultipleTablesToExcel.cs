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
                bool addedWorksheet = false;

                foreach (var table in tables)
                {
                    if (table.Value != null && table.Value.Rows.Count > 0)
                    {
                        var worksheet = workbook.AddWorksheet(table.Key);
                        addedWorksheet = true;

                        // Escribir encabezados
                        for (int col = 0; col < table.Value.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = table.Value.Columns[col].ColumnName;
                        }
                        // Escribir datos
                        for (int row = 0; row < table.Value.Rows.Count; row++)
                        {
                            for (int col = 0; col < table.Value.Columns.Count; col++)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = table.Value.Rows[row][col] != DBNull.Value
                                    ? table.Value.Rows[row][col].ToString()
                                    : string.Empty;
                            }
                        }
                    }
                }

                if (!addedWorksheet)
                {
                    var worksheet = workbook.AddWorksheet("EmptySheet");
                    worksheet.Cell(1, 1).Value = "No hay datos disponibles";
                }

                workbook.SaveAs(fileName);
            }

            MessageBox.Show("Todas las tablas han sido exportadas a un único archivo Excel.");
        }
    }
}
