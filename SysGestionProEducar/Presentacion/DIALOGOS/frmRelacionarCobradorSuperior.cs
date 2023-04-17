using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class frmRelacionarCobradorSuperior : Form
    {
        DataTable dt = new DataTable();
        DataTable dtR = new DataTable();
        progNivelRelacionBLL prnirBLL = new progNivelRelacionBLL();
        progNivelBLL pnirBLL = new progNivelBLL();
        public string codni; public string codprog; public string codsup;
        public frmRelacionarCobradorSuperior()
        {
            InitializeComponent();
        }

        private void frmRelacionarCobradorSuperior_Load(object sender, EventArgs e)
        {
            creadtR();
        }
        private void creadtR()
        {
            dtR.Columns.Add("COD_PROG", typeof(string));
            dtR.Columns.Add("COD_COB", typeof(string));
            dtR.Columns.Add("COD_SUPERIOR", typeof(string));
            dtR.Columns.Add("COD_NIVEL", typeof(string));
            //dtR.Columns.Add("COD_ALM", typeof(string));
        }
        public void CargarDatos(DataTable dt1)
        {
            dt = pnirBLL.obtenerPersonalparaRelacionarCobradoresBLL(codni);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_EQCOB"].ToString();
                    row.Cells["nom"].Value = rw["DESC_EQVTA"].ToString();
                    row.Cells["codn"].Value = rw["NRO_DOC"].ToString();
                    row.Cells["desn"].Value = rw["DESC_NIVEL"].ToString();
                }
                foreach (DataRow rw in dt1.Rows)
                {
                    foreach (DataGridViewRow row in dgw.Rows)
                    {
                        if (rw["COD_COB"].ToString() == row.Cells["cod"].Value.ToString())
                        {
                            row.Cells["op"].Value = true;
                            break;
                        }
                    }
                }
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de relacionar estos cobradores con este sectorista ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";

                DataTable dtRe = obtieneDatos();
                if (!prnirBLL.adicionaProgNivelRelacionCobranzaBLL(dtRe, codprog, codsup, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se grabó correctamente !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtR.Rows.Clear();
                }
            }
        }
        private DataTable obtieneDatos()
        {
            foreach (DataGridViewRow row in dgw.Rows)
            {
                if (Convert.ToBoolean(row.Cells["op"].Value))
                {
                    DataRow rw = dtR.NewRow();
                    rw["COD_PROG"] = codprog;
                    rw["COD_COB"] = row.Cells["cod"].Value.ToString();
                    rw["COD_SUPERIOR"] = codsup;
                    rw["COD_NIVEL"] = "01";//nivel del sectorista
                    dtR.Rows.Add(rw);
                }
            }
            return dtR;
        }
    }
}
