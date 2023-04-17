using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class ErrorPrint
    {
        private const int ID_ERROR_DELETE_FOREIGNKEY = 547;
        private const int ID_ERROR_INSERT_DUPLICATE = 2627;

        public static void PrintStackTrace(Exception ex) =>
            _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void PrintException(this Exception ex) =>
            _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>
        /// Muestra errores en general.
        /// Además muestra errores de inserción de datos duplicado(primary key o unique infration), eliminación de registros en uso (foreign key infration)
        /// </summary>
        /// <param name="ex"></param>
        public static void PrintException2(this Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                if (sqlEx.Number == ID_ERROR_INSERT_DUPLICATE)
                    _ = MessageBox.Show("Este registro ya existe, no se puede insertar duplicados. Actualice la lista para verificar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(sqlEx.Number == ID_ERROR_DELETE_FOREIGNKEY)
                    _ = MessageBox.Show("Este registro ya esta asociado o en uso\n " +
                        "No se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    ex.PrintException();
            }
            else
                ex.PrintException();
        }
    }
}
