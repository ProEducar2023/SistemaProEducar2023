using System;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public static class AutoCompleClass
    {
        public static AutoCompleteStringCollection AutoComplete(DataTable dt)
        {
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
                coleccion.Add(Convert.ToString(row[1]));
            return coleccion;
        }
    }
}
