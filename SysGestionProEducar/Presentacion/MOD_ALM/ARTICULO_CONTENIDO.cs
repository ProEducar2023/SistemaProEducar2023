using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM
{
    public partial class ARTICULO_CONTENIDO : Form
    {
        public string COD_ARTI;
        public string NRO_NOTA_ING;
        public string SITUACION_ARTICULO;
        //public DataTable dtTablaContenido;
        public ARTICULO_CONTENIDO()
        {
            InitializeComponent();
        }

        private void ARTICULO_CONTENIDO_Load(object sender, EventArgs e)
        {
            CARGA_COMBO_DEV();
            //CrearTablaContenido();
        }


        private void CARGA_COMBO_DEV()
        {
            DataGridViewComboBoxColumn comboboxColumn = DGW_DET.Columns["SITUACION"] as DataGridViewComboBoxColumn;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TDEVO";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Descripción"] = "";
            rw["Codigo"] = "";
            dt.Rows.InsertAt(rw, 0);
            comboboxColumn.DataSource = dt;
            comboboxColumn.DisplayMember = "Descripción";
            comboboxColumn.ValueMember = "Codigo";
            DGW_DET.AutoGenerateColumns = false;
        }
        public void CARGAR_ARTICULO_CONTENIDO(DataTable dtArti)
        {
            articuloContenidoBLL atcBLL = new articuloContenidoBLL();
            articuloContenidoTo atcTo = new articuloContenidoTo();
            atcTo.COD_ARTICULO = COD_ARTI;
            DataTable dt = atcBLL.obtenerArticuloContenidoBLL(atcTo);
            DGW_DET.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                int i = 0; string situacion;
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    i++;
                    row.Cells["ITEM"].Value = i.ToString().PadLeft(2, '0');
                    row.Cells["COD_ARTICULO"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["COD_ART_CONTENIDO"].Value = rw["COD_ART_CONTENIDO"].ToString();
                    row.Cells["DESC_ARTICULO"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CANTIDAD"].Value = "1";
                    situacion = devuelveSituacion(COD_ARTI, row.Cells["COD_ART_CONTENIDO"].Value.ToString(), dtArti);
                    row.Cells["SITUACION"].Value = situacion == "" ? "" : situacion;//SITUACION_ARTICULO=="01" ? "01" : "";

                }
            }
        }
        private string devuelveSituacion(string cod_articulo, string cod_art_contenido, DataTable dt)
        {
            string sit = "";
            DataRow[] rows = dt.Select("COD_ARTICULO = '" + cod_articulo + "' AND COD_ART_CONTENIDO = '" + cod_art_contenido + "'");
            foreach (DataRow rw in rows)
                sit = rw["SITUACION"].ToString();
            return sit;
        }
        public void CARGAR_ARTICULO_CONTENIDO_MOVIMIENTO()
        {
            articuloContenidoMovimientoBLL acmBLL = new articuloContenidoMovimientoBLL();
            articuloContenidoMovimientoTo acmTo = new articuloContenidoMovimientoTo();
            acmTo.NRO_NOTA_ING = NRO_NOTA_ING;
            acmTo.COD_ARTICULO = COD_ARTI;
            DataTable dt = acmBLL.obtenerArticuloContenidoMovimientoBLL(acmTo);
            DGW_DET.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    i++;
                    row.Cells["ITEM"].Value = i.ToString().PadLeft(2, '0');
                    row.Cells["COD_ARTICULO"].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells["COD_ART_CONTENIDO"].Value = rw["COD_ART_CONTENIDO"].ToString();
                    row.Cells["DESC_ARTICULO"].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells["CANTIDAD"].Value = rw["CANTIDAD"].ToString();
                    row.Cells["SITUACION"].Value = rw["SITUACION"].ToString();
                }
            }
        }
    }
}
