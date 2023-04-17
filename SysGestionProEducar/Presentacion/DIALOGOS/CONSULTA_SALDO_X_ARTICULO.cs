using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class CONSULTA_SALDO_X_ARTICULO : Form
    {
        string CodigoClase = "", CodigoArticulo = "", DescripcionArticulo = "", strDescripcionArticulo = "", TIPO_USU = "", COD_USU = "";
        articulosBLL arBLL = new articulosBLL();
        claseBLL claBLL = new claseBLL();
        public CONSULTA_SALDO_X_ARTICULO(string strCodigoClase, string strCodigoArticulo, string strDescripcionArticulo, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            CodigoClase = strCodigoClase;
            CodigoArticulo = strCodigoArticulo;
            this.strDescripcionArticulo = strDescripcionArticulo;
            //CARGAR_LABEL();
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;

        }

        private void CONSULTA_SALDO_X_ARTICULO_Load(object sender, EventArgs e)
        {
            CBO_CLASE.Items.Clear();
            CargarClase();
            CargarSaldos();
            TXT_ART.Text = strDescripcionArticulo;
            TXT_UM.Text = arBLL.HALLAR_UM_ARTICULO_BLL(CodigoArticulo);
            CBO_CLASE.Items.Add(claBLL.HALLAR_CLASE_COD_BLL(CodigoClase));
            CBO_CLASE.SelectedIndex = 0;
        }
        private void CargarClase()
        {
            DataTable table = new DataTable();
            HelpersBLL helBLL = new HelpersBLL();
            table = helBLL.CBO_CLASE_USU_TIPO(true, TIPO_USU, COD_USU, "P");
        }
        private void CargarSaldos()
        {
            dgw1.Rows.Clear();
            DataTable dt = arBLL.CARGAR_SALDOS_CLASE_ARTICULO(CodigoClase, CodigoArticulo);
            foreach (DataRow rw in dt.Rows)
            {
                int idx = dgw1.Rows.Add();
                DataGridViewRow row = dgw1.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();

            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CBO_CLASE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_CLASE.SelectedIndex > -1)
            {
                CargarSaldos();
            }
        }
    }
}
