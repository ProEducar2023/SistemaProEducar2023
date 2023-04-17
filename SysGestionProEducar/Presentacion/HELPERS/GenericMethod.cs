using Presentacion.HELPERS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class GenericMethod
    {
        private const string FORMAT_MILES = "N2";

        public static bool ValidarImporteAplicarSaldo(decimal importeDoc, decimal importeOld,
            decimal importeNew, ref decimal _importe)
        {
            decimal importe = importeOld + importeDoc;
            if (importe >= importeNew)
            {
                _importe = importe - importeNew;
                return true;
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid">DataGridView al cual se va agregar las columnas</param>
        /// <param name="dt">Data origen</param>
        /// <param name="defaulDataType">si es true el tipo de dato de los valores va ser string de lo contrario el del origen de datos</param>
        public static void AddRangeColumnsDataGridView(this DataGridView dataGrid, DataTable dt, bool defaulDataType)
        {
            if (dt != null)
            {
                if (dataGrid.Columns.Count == 0)
                {
                    DataGridViewColumn[] arrColumns = new DataGridViewColumn[dt.Columns.Count];
                    DataGridViewColumn col;
                    int io = 0;
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.DataType == typeof(bool))
                            col = new DataGridViewCheckBoxColumn
                            {
                                Name = column.ColumnName,
                                ValueType = column.DataType
                            };
                        else
                            col = new DataGridViewTextBoxColumn
                            {
                                Name = column.ColumnName,
                                ValueType = defaulDataType ? typeof(string) : column.DataType
                            };
                        arrColumns[io] = col;
                        io += 1;
                    }
                    dataGrid.Columns.AddRange(arrColumns);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid">DataGridView al cual se va agregar las columnas</param>
        /// <param name="dt">Data origen</param>
        public static void AddRangeRowsDataGridView(this DataGridView dataGrid, DataTable dt)
        {
            if (dt != null)
            {
                int io = 0;
                DataGridViewRow[] arrRow = new DataGridViewRow[dt.Rows.Count];
                foreach (DataRow row in dt.Rows)
                {
                    DataGridViewRow rowTemplate = (DataGridViewRow)dataGrid.RowTemplate.Clone();
                    rowTemplate.CreateCells(dataGrid);
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        rowTemplate.Cells[i].Value = row[i];
                    }
                    arrRow[io] = rowTemplate;
                    io += 1;
                }
                dataGrid.Rows.AddRange(arrRow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="dt"></param>
        /// <param name="nameColumnGroup">Nombre de la columna => por cada grupo de valores de esta columna va mostrarse un total</param>
        /// <param name="nameColumnText">Nombre de la columna donde se va mostrar el texto del parametro textTotales</param>
        /// <param name="textTotales">Texto que se va mostrar ejemplo "Totales"</param>
        public static void AddRowsAndTotalesDataGridView(this DataGridView dataGrid, DataTable dt, string nameColumnGroup, string nameColumnText, string textTotales)
        {
            int io;
            string nroPllaEnv = string.Empty;
            bool acces = true;
            DataTable dtTotales = new DataTable();
            AddColumnsTotales();
            AddRowsTotales();

            dataGrid.Rows.Clear();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (acces)
                        nroPllaEnv = row[nameColumnGroup].ToString();
                    if (nroPllaEnv == row[nameColumnGroup].ToString())
                    {
                        AddRows(row);
                    }
                    else
                    {
                        AddRowTotales();
                        AddRows(row);
                    }

                    acces = false;
                    nroPllaEnv = row[nameColumnGroup].ToString();
                }
                AddRowTotales();
            }

            else
                _ = MessageBox.Show("No hay datos para listar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            void AddRows(DataRow row)
            {
                io = dataGrid.Rows.Add();
                DataGridViewRow rw = dataGrid.Rows[io];
                rw.DefaultCellStyle.BackColor = Color.LightGray;
                foreach (DataColumn column in dt.Columns)
                {
                    rw.Cells[column.ColumnName].Value = row[column.ColumnName];
                }

                foreach (DataColumn column in dt.Columns)
                {
                    foreach (DataColumn column2 in dtTotales.Columns)
                    {
                        if (column.ColumnName == column2.ColumnName)
                        {
                            string a = dtTotales.Rows[0][column.ColumnName].ToString();
                            string b = row[column.ColumnName].ToString();
                            dtTotales.Rows[0][column.ColumnName] = Convert.ToDecimal(dtTotales.Rows[0][column.ColumnName]) + Convert.ToDecimal(row[column.ColumnName]);
                        }
                    }
                }
            }

            void AddRowTotales()
            {
                io = dataGrid.Rows.Add();
                DataGridViewRow rw = dataGrid.Rows[io];
                rw.DefaultCellStyle.BackColor = Color.PaleTurquoise;
                rw.Cells[nameColumnText].Value = textTotales;
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    foreach (DataColumn column2 in dtTotales.Columns)
                    {
                        if (column.Name == column2.ColumnName)
                            rw.Cells[column.Name].Value = dtTotales.Rows[0][column2.ColumnName];
                    }
                }
                AddRowsTotales();
            }

            void AddColumnsTotales()
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.DataType == typeof(decimal))
                        _ = dtTotales.Columns.Add(column.ColumnName, column.DataType);
                }
            }

            void AddRowsTotales()
            {
                dtTotales.Clear();
                _ = dtTotales.Rows.Add();
                foreach (DataColumn column in dtTotales.Columns)
                {
                    dtTotales.Rows[0][column.ColumnName] = 0;
                }
            }
        }

        public static void MantenerColorSeleccionado(this DataGridView dataGrid, Color colorTextoFilas)
        {
            dataGrid.DefaultCellStyle.SelectionBackColor = dataGrid.CurrentRow.DefaultCellStyle.BackColor;
            dataGrid.DefaultCellStyle.SelectionForeColor = colorTextoFilas;
        }

        public static string FormatoMiles(this object number) => Convert.ToDecimal(number).ToString(FORMAT_MILES);

        public static DataTable ConvertToDataTable(this DataGridView dataGrid)
        {
            if (dataGrid != null)
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    _ = dt.Columns.Add(column.Name, column.ValueType);
                }

                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    DataRow rw = dt.NewRow();
                    foreach (DataGridViewColumn col in dataGrid.Columns)
                    {
                        rw[col.Name] = row.Cells[col.Name].Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(rw);
                }
                return dt;
            }
            return null;
        }

        public static object UtilMeses()
        {
            var mes = new[]
            {
                new { value = "01", name = "ENERO" },
                new { value = "02", name = "FEBRERO" },
                new { value = "03", name = "MARZO" },
                new { value = "04", name = "ABRIL" },
                new { value = "05", name = "MAYO" },
                new { value = "06", name = "JUNIO" },
                new { value = "07", name = "JULIO" },
                new { value = "08", name = "AGOSTO" },
                new { value = "09", name = "SEPTIEMBRE" },
                new { value = "10", name = "OCTUBRE" },
                new { value = "11", name = "NOVIEMBRE" },
                new { value = "12", name = "DICIEMBRE" }
            };
            return mes;
        }

        public static List<dynamic> UtilNroCuotas()
        {
            List<dynamic> lista = new List<dynamic>();
            var cuotas = new[]
            {
                new { value = "001", name = "001" },
                new { value = "002", name = "002" },
                new { value = "003", name = "003" },
                new { value = "004", name = "004" },
                new { value = "005", name = "005" },
                new { value = "006", name = "006" },
                new { value = "007", name = "007" },
                new { value = "008", name = "008" },
                new { value = "009", name = "009" },
                new { value = "010", name = "010" },
                new { value = "011", name = "011" },
                new { value = "012", name = "012" },
                new { value = "013", name = "013" },
                new { value = "014", name = "014" },
                new { value = "015", name = "015" },
                new { value = "016", name = "016" },
                new { value = "017", name = "017" },
                new { value = "018", name = "018" }
            };
            lista.AddRange(cuotas);

            return lista;
        }

        public static DataGridViewColumn CloneColumn(this DataGridViewColumn column)
        {
            DataGridViewColumn cloneColumn = (DataGridViewColumn)column.Clone();
            cloneColumn.ValueType = column.ValueType ?? typeof(string);
            return cloneColumn;
        }

        public static DataGridViewRow CloneWithValues(this DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (int index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        public static DataGridViewRow[] CloneWithValues(this DataGridViewRow[] arrRow)
        {
            DataGridViewRow[] arrRow2 = null;
            if (arrRow != null)
            {
                arrRow2 = new DataGridViewRow[arrRow.Length];
                for (int io = 0; io < arrRow.Length; io++)
                {
                    DataGridViewRow clonedRow = (DataGridViewRow)arrRow[io].Clone();
                    for (int index = 0; index < arrRow[io].Cells.Count; index++)
                    {
                        clonedRow.Cells[index].Value = arrRow[io].Cells[index].Value;
                    }
                    arrRow2[io] = clonedRow;
                }
            }
            return arrRow2;
        }

        public static void AddCloneRowWithValues(this DataTable dt, DataRow row)
        {
            if (dt != null && row != null)
            {
                Array array = (Array)row.ItemArray.Clone();
                DataRow clonedRow = dt.NewRow();
                for (int index = 0; index < array.Length; index++)
                {
                    clonedRow[index] = row[index];
                }
                dt.Rows.Add(clonedRow);
            }

        }

        public static void AddCloneRowsWithValues(this DataTable dt, DataTable dt2)
        {
            if (dt != null && dt.Columns.Count > 0 && dt2 != null && dt2.Columns.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    DataRow clonedRow = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        clonedRow[column.ColumnName] = row[column.ColumnName];
                    }
                    dt.Rows.Add(clonedRow);
                }
            }
        }

        public static int ToInt32(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal ToDecimal(this object value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ToBoolean(this object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DateTime ToDateTime(this object value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void TxtContratoFormato(this TextBox txtNroContrato)
        {
            if (!string.IsNullOrEmpty(txtNroContrato.Text.Trim()))
            {
                txtNroContrato.Text = txtNroContrato.Text.Trim().PadLeft(7, Convert.ToChar("0"));
            }
        }

        public static FrmLoading StartLoadingForm(this FrmLoading frmLoading, Form owner)
        {
            if (frmLoading is null)
            {
                frmLoading = new FrmLoading();
            }
            frmLoading.Owner = owner;
            frmLoading.ShowInTaskbar = false;
            frmLoading.Show();
            return frmLoading;
        }

        public static void CloseLoadingForm(this FrmLoading frmLoading)
        {
            if (frmLoading != null)
                frmLoading.Close();
        }

        public static void FormatTxtNroCuota(this TextBox txtNroCuota)
        {
            try
            {
                int num = Convert.ToInt32(txtNroCuota.Text.Trim());
                if (!string.IsNullOrEmpty(txtNroCuota.Text.Trim()))
                {
                    if (num <= 18)
                    {
                        txtNroCuota.Text = num.ToString().PadLeft(3, Convert.ToChar("0"));
                    }
                    else
                    {
                        _ = MessageBox.Show("El numero máximo de cuotas es 18", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCuota.Text = "000";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    txtNroCuota.Text = "000";
            }
        }

        /// <summary>
        /// Crea un clone de la lista actual
        /// </summary>
        /// <typeparam name="T">Objeto de la lista</typeparam>
        /// <param name="oldList"></param>
        /// <returns>nueva lista</returns>
        public static IList<T> CloneList<T>(this IList<T> oldList)
        {
            List<T> newList = new List<T>();
            foreach (ICloneable item in oldList)
            {
                newList.Add((T)item.Clone());
            }
            return newList;
        }

        /// <summary>
        /// Crea un clone de la lista actual
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldList">Objeto de la lista</param>
        /// <returns>nueva lista</returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Obtiene una lista solo de los valores distintos que se pasa por el parámetro [selector]
        /// Esto es similar a un group by, dónde solo va mostrar las columnas pasadas en el parámetro [selector]
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="selector">Prámetro función Ejmplo: [x => new { COD_PER = x.Field<string>("COD_PER"), DESC_PER = x.Field<string>("DESC_PER") }]
        /// o [x => x.Field<string>("COD_PER")]
        /// </param>
        /// <returns></returns>
        public static List<dynamic> ToDistinct(this DataTable dt, Func<DataRow, string> selector)
        {
            List<dynamic> lista = new List<dynamic>();
            if (dt != null)
            {
                var sortedTable = dt.AsEnumerable().Select(selector).Distinct();

                foreach (var item in sortedTable)
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtiene una lista solo de los valores distintos que se pasa por el parámetro [selector]
        /// Esto es similar a un group by, dónde solo va mostrar las columnas pasadas en el parámetro [selector]
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="selector">Prámetro función Ejmplo: [x => new { COD_PER = x.Field<string>("COD_PER"), DESC_PER = x.Field<string>("DESC_PER") }]
        /// o [x => x.Field<string>("COD_PER")]
        /// </param>
        /// <returns></returns>
        public static List<dynamic> ToDistinct(this DataTable dt, Func<DataRow, dynamic> selector)
        {
            List<dynamic> lista = new List<dynamic>();
            if (dt != null)
            {
                var sortedTable = dt.AsEnumerable().Select(selector).Distinct();

                foreach (var item in sortedTable)
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        #region ListView Totales
        /// <summary>
        /// Elimina las columnas del listView
        /// </summary>
        /// <param name="lst">ListView</param>
        public static void RemoveColumnsLstvTotales(this ListView lst)
        {
            foreach (ColumnHeader column in lst.Columns)
            {
                lst.Columns.Remove(column);
            }
        }

        /// <summary>
        /// Crea columnas pasadas por el parámetro [columns]
        /// </summary>
        /// <param name="lst">ListView</param>
        /// <param name="columns">Columnas</param>
        public static void CrearColumnasLstvTotales(this ListView lst, dynamic columns)
        {
            if (lst.Columns.Count == 0)
            {
                foreach (var item in columns)
                {
                    ColumnHeader head = lst.Columns.Add(item.headerText, item.width);
                    head.Tag = item.stringFormat;
                }
            }
        }

        public static void ColorListViewHeader(this ListView list, Color backColor, Color foreColor)
        {
            list.OwnerDraw = true;
            list.GridLines = true;
            list.DrawColumnHeader +=
                new DrawListViewColumnHeaderEventHandler
                (
                    (sender, e) => HeaderDraw(sender, e, backColor, foreColor)
                );
            list.DrawItem += new DrawListViewItemEventHandler(BodyDraw);
        }

        private static void HeaderDraw(object sender, DrawListViewColumnHeaderEventArgs e, Color backColor, Color foreColor)
        {
            using (SolidBrush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, new Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height));
            }

            using (SolidBrush foreBrush = new SolidBrush(foreColor))
            {
                //> StringFormat siver para alinear el texto
                StringFormat format = e.Header.Tag as StringFormat;
                e.Graphics.DrawString(e.Header.Text, e.Font, foreBrush, e.Bounds, format);
                format = null;
            }
            //string text = e.Header.Text;
            //TextFormatFlags cFlag = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            //TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, Color.Black, cFlag);
        }

        private static void BodyDraw(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /// <summary>
        /// [Devuelve datos de un List<T> en un dataTable]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            if (data is null)
            {
                throw new NullReferenceException();
            }
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }
            return table;
        }
        #endregion 
    }
}
