using System;
using System.IO;

namespace SistemaAuditoria.Clases
{
    public static class AuditLogger
    {
        // Ruta del archivo de log (se creará en el directorio de la aplicación)
        private static readonly string logFilePath = "AuditLog.txt";

        /// <summary>
        /// Registra una entrada de log.
        /// </summary>
        /// <param name="contexto">El módulo o parte de la auditoría.</param>
        /// <param name="mensaje">Descripción de la anomalía o acción.</param>
        /// <param name="criticidad">Nivel de criticidad.</param>
        public static void Log(string contexto, string mensaje, string criticidad)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Contexto: {contexto} | Criticidad: {criticidad} | {mensaje}";
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // En caso de fallo al escribir el log, se muestra el error en consola.
                Console.WriteLine("Error al escribir en el log: " + ex.Message);
            }
        }
    }
}
