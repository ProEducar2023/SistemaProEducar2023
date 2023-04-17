using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class FormatDataGridViewColumns
    {
        private const string V = "N2";
        private const string F = "dd/MM/yyyy";
        public static void AjusteColumnasTextBox(DataGridView gridView, string nameColumn, int width, string headerText = null)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (!string.IsNullOrEmpty(nameColumn))
                {
                    if (headerText != null)
                        gridView.Columns[nameColumn].HeaderText = headerText;
                    gridView.Columns[nameColumn].Width = width;
                }
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void AjusteColumnasDecimal(DataGridView gridView, string nameColumn, int width, string headerText = null, string formatDecimal = null)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (!string.IsNullOrEmpty(nameColumn))
                {
                    if (headerText != null)
                        gridView.Columns[nameColumn].HeaderText = headerText;
                    gridView.Columns[nameColumn].Width = width;
                    gridView.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gridView.Columns[nameColumn].DefaultCellStyle.Format = string.IsNullOrEmpty(formatDecimal) ? V : formatDecimal;
                }
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void FormatColumnasFecha(this DataGridView gridView, string nameColumn)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (!string.IsNullOrEmpty(nameColumn))
                {
                    gridView.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gridView.Columns[nameColumn].DefaultCellStyle.Format = F;
                }
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public static void InvisibleColumna(DataGridView gridView, string nameColumn)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (!string.IsNullOrEmpty(nameColumn))
                {
                    gridView.Columns[nameColumn].Visible = false;
                }
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void InvisibleColumna2(this DataGridView gridView, string nameColumn)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (!string.IsNullOrEmpty(nameColumn))
                {
                    gridView.Columns[nameColumn].Visible = false;
                }
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void InvisibleColumna(this DataGridView gridView, string[] nameColumns)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                foreach (string nameColumn in nameColumns)
                {
                    if (!string.IsNullOrEmpty(nameColumn))
                    {
                        gridView.Columns[nameColumn].Visible = false;
                    }
                }
            }
        }

        public static void AlingHeaderTextCenter(this DataGridView gridView)
        {
            if (gridView != null)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        public static void AlignmentTextContent(DataGridView gridView, string columnName, DataGridViewContentAlignment alignment)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (columnName != null)
                    gridView.Columns[columnName].DefaultCellStyle.Alignment = alignment;
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void AlignmentTextContent2(this DataGridView gridView, string columnName, DataGridViewContentAlignment alignment)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                if (columnName != null)
                    gridView.Columns[columnName].DefaultCellStyle.Alignment = alignment;
                else
                    _ = MessageBox.Show("El nombre de la columna no debe ser nulo o vacío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void AlingmentTextContentAll(DataGridView gridView, DataGridViewContentAlignment alignment)
        {
            if (gridView != null)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.DefaultCellStyle.Alignment = alignment;
                }
            }
        }

        public static void Style1(this DataGridView gridView)
        {
            if (gridView != null)
            {
                gridView.AllowUserToAddRows = false;
                gridView.AllowUserToDeleteRows = false;
                gridView.AllowUserToOrderColumns = false;
                gridView.ReadOnly = true;
                gridView.EnableHeadersVisualStyles = false;
                gridView.RowHeadersVisible = false;
                gridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                gridView.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;
                gridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Blue;
                gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridView.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        public static void Style2(this DataGridView gridView)
        {
            if (gridView != null)
            {
                gridView.AllowUserToAddRows = false;
                gridView.AllowUserToDeleteRows = false;
                gridView.AllowUserToOrderColumns = false;
                gridView.ReadOnly = true;
                gridView.EnableHeadersVisualStyles = false;
                gridView.RowHeadersVisible = false;
                gridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                gridView.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.White;
                gridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Blue;
                gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        public static void Style3(this DataGridView gridView)
        {
            if (gridView != null)
            {
                gridView.DefaultCellStyle.Font = new Font(gridView.Font, FontStyle.Regular);
                gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                gridView.DefaultCellStyle.SelectionBackColor = Color.White;
                gridView.DefaultCellStyle.SelectionForeColor = Color.Blue;
                gridView.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                gridView.RowHeadersVisible = false;
            }
        }

        public static void Style4(this DataGridView gridView, bool editarFila, bool agregarFilas, bool eliminarFilas, bool ordenarColumns, bool visibleColumnaSeleccion, bool stiloDefecto, DataGridViewTriState truncarTextoColumna,
            DataGridViewColumnHeadersHeightSizeMode autoAjusteTextColumna, DataGridViewTriState truncarTextoCelda, DataGridViewAutoSizeRowsMode autoAjusteTextoCelda, Color colorTextoSeleccionado, Color colorFondoSeleccionado, DataGridViewSelectionMode modoSeleccionFila)
        {
            if (gridView != null)
            {
                gridView.ReadOnly = !editarFila;
                gridView.AllowUserToAddRows = agregarFilas;
                gridView.AllowUserToDeleteRows = eliminarFilas;
                gridView.AllowUserToOrderColumns = ordenarColumns;
                gridView.EnableHeadersVisualStyles = stiloDefecto;
                gridView.RowHeadersVisible = visibleColumnaSeleccion;
                gridView.ColumnHeadersDefaultCellStyle.WrapMode = truncarTextoColumna;
                gridView.ColumnHeadersHeightSizeMode = autoAjusteTextColumna;
                gridView.RowsDefaultCellStyle.WrapMode = truncarTextoCelda;
                gridView.AutoSizeRowsMode = autoAjusteTextoCelda;
                gridView.RowTemplate.DefaultCellStyle.SelectionBackColor = colorFondoSeleccionado;
                gridView.RowTemplate.DefaultCellStyle.SelectionForeColor = colorTextoSeleccionado;
                gridView.SelectionMode = modoSeleccionFila;
                gridView.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }

        public static void Style5(this DataGridView gridView, bool agregarFilas, bool eliminarFilas, bool ordenarColumns, bool visibleColumnaSeleccion, bool stiloDefecto, DataGridViewTriState truncarTextoColumna,
            DataGridViewColumnHeadersHeightSizeMode autoAjusteTextColumna, DataGridViewTriState truncarTextoCelda, DataGridViewAutoSizeRowsMode autoAjusteTextoCelda, DataGridViewSelectionMode modoSeleccionFila,
            bool editarFila = true)
        {
            if (gridView != null)
            {
                gridView.AllowUserToAddRows = agregarFilas;
                gridView.AllowUserToDeleteRows = eliminarFilas;
                gridView.AllowUserToOrderColumns = ordenarColumns;
                gridView.EnableHeadersVisualStyles = stiloDefecto;
                gridView.RowHeadersVisible = visibleColumnaSeleccion;
                gridView.ColumnHeadersDefaultCellStyle.WrapMode = truncarTextoColumna;
                gridView.ColumnHeadersHeightSizeMode = autoAjusteTextColumna;
                gridView.RowsDefaultCellStyle.WrapMode = truncarTextoCelda;
                gridView.AutoSizeRowsMode = autoAjusteTextoCelda;
                gridView.SelectionMode = modoSeleccionFila;
                gridView.ReadOnly = !editarFila;
            }
        }

        /// <summary>
        /// Establece color de fondo y color de texto a todas las columnas del dataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView a la cual se va aplicar</param>
        /// <param name="backColor">Color de fondo</param>
        /// <param name="foreColor">Color de texto</param>
        public static void ColorCabeceraDataGridView(this DataGridView dataGrid, Color backColor, Color foreColor)
        {
            if (dataGrid is null)
                throw new NullReferenceException("Error en ColorCabeceraDataGridView");
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                column.HeaderCell.Style.BackColor = backColor;
                column.HeaderCell.Style.ForeColor = foreColor;
            }
        }

        /// <summary>
        /// Aliena a la derecha todas los valores de las columnas que sea de tipo decimal, además le agrega un formato de separador de miles
        /// </summary>
        /// <param name="gridView"></param>
        public static void AlignmentDecimalColumns(this DataGridView gridView)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    if (column.ValueType == typeof(decimal))
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        column.DefaultCellStyle.Format = V;
                    }
                }
            }
        }

        /// <summary>
        /// Establece en modo lectura las columnas especificadas en el parametro [columns]
        /// </summary>
        /// <param name="gridView">DataGridView a la cual se va aplicar</param>
        /// <param name="columns">Arreglo de nombre de columnas</param>
        public static void ColumnsReadOnly(this DataGridView gridView, string[] columns)
        {
            if (gridView != null && gridView.Columns.Count > 0 && columns.Length > 0)
            {
                foreach (string columnName in columns)
                {
                    gridView.Columns[columnName].ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// Establece en modo lectura todas las columnas excepto los especificados en el parámetro [columns]
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="columns"></param>
        public static void ColumnsReadOnlyExcept(this DataGridView gridView, string[] columns)
        {
            if (gridView != null && gridView.Columns.Count > 0 && columns.Length > 0)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.ReadOnly = true;
                }

                foreach (string columnName in columns)
                {
                    gridView.Columns[columnName].ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// Deshabilita la opción de ordenar las filas al hacer click en las columnas
        /// </summary>
        /// <param name="gridView"></param>
        public static void NotSort(this DataGridView gridView)
        {
            if (gridView != null)
            {
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        public static void ColumnasFormatoMiles(this DataGridView dataGrid, string[] columns)
        {
            if (dataGrid != null && dataGrid.Columns.Count > 0)
            {
                foreach (string column in columns)
                {
                    dataGrid.Columns[column].DefaultCellStyle.Format = V;
                }
            }
        }

        public static void ColumnasAlinear(this DataGridView dataGrid, string[] columns, DataGridViewContentAlignment alignment)
        {
            if (dataGrid != null && dataGrid.Columns.Count > 0)
            {
                foreach (string column in columns)
                {
                    dataGrid.Columns[column].DefaultCellStyle.Alignment = alignment;
                }
            }
        }

        public static void ColumnasFormatoFecha(this DataGridView gridView, string[] columns, string dateFormat = null)
        {
            if (gridView != null && gridView.Columns.Count > 0)
            {
                foreach (string nameColumn in columns)
                {
                    gridView.Columns[nameColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gridView.Columns[nameColumn].DefaultCellStyle.Format = string.IsNullOrEmpty(dateFormat) ? F : dateFormat;
                }
            }
        }

        /// <summary>
        /// Cambia el color de fondo y letra de las columnas del dataGridView
        /// </summary>
        /// <param name="dataGrid">DataGridView al cual se va aplicar</param>
        /// <param name="arrIndexColumns">Intervalo de indices a la cual se va aplicar  los colores</param>
        /// <param name="backColor1">Color de fondo que se va aplicar en el primer intervalo y luego se va intercalar de acuerdo a los demás indices de las columnas</param>
        /// <param name="foreColor1">Color de tecto que se va aplicar en el primer intervalo y luego se va intercalar de acuerdo a los demás indices de las columnas</param>
        /// <param name="backColor2">Color de fondo que se va aplicar en el segundo intervalo y luego se va intercalar de acuerdo a los demás indices de las columnas</param>
        /// <param name="foreColor2">Color de texto que se va aplicar en el segundo intervalo y luego se va intercalar de acuerdo a los demás indices de las columnas</param>
        public static void ColorCabeceraDataGridView(this DataGridView dataGrid, int[] arrIndexColumns, Color backColor1, Color foreColor1, Color backColor2, Color foreColor2)
        {
            if (dataGrid is null)
                throw new NullReferenceException("Error en ColorCabeceraDataGridView");
            bool acc = false;
            for (int io = 0; io < dataGrid.Columns.Count; io++)
            {
                dataGrid.Columns[io].HeaderCell.Style.BackColor = acc ? backColor2 : backColor1;
                dataGrid.Columns[io].HeaderCell.Style.ForeColor = acc ? foreColor2 : foreColor1;
                acc = arrIndexColumns.FirstOrDefault(x => x == io) != 0 ? !acc : acc;
            }
        }
    }
}
