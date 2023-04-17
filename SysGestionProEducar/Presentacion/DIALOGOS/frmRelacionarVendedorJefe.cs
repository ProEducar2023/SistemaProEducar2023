using BLL;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.DIALOGOS
{
    public partial class frmRelacionarVendedorJefe : Form
    {
        DataTable dt = new DataTable();
        progNivelBLL prniBLL = new progNivelBLL();
        almacenesBLL almBLL = new almacenesBLL();
        public string codpro;
        public string codalm;
        public frmRelacionarVendedorJefe()
        {
            InitializeComponent();
        }
        private void frmRelacionarVendedorJefe_Load(object sender, EventArgs e)
        {
            //cargaCombo();
        }
        private void cargaComboAlmacen()
        {
            DataTable dtA = almBLL.obtenerAlmacenesBLL();
            cbo_alm.ValueMember = "Cod";
            cbo_alm.DisplayMember = "Descripción";
            cbo_alm.DataSource = dtA;
        }
        private void cargaComboEncargadoNumeracionContrato()
        {
            //eq_vta_nivel_progBLL eqvBLL = new eq_vta_nivel_progBLL();
            //DataTable dt = eqvBLL.obtenerEquipoBLL();
            //if(dt.Rows.Count > 0)
            //{
            //    cbo_enc_num_contrato.DataSource = dt;
            //    cbo_enc_num_contrato.ValueMember = "COD_EQVTA";
            //    cbo_enc_num_contrato.DisplayMember = "DESC_EQVTA";
            //}
        }
        public void CargarDatos(DataGridViewRow fila)
        {
            dt = prniBLL.obtenerPersonalparaRelacionarBLL(codpro);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_PER"].ToString();
                    row.Cells["nom"].Value = rw["DESC_PER"].ToString();
                    row.Cells["codn"].Value = rw["COD_NIVEL"].ToString();
                    row.Cells["desn"].Value = rw["DESC_NIVEL"].ToString();
                }
                for (int i = 5; i < 8; i++)//para checkear los niveles ya elegidos antes
                {
                    foreach (DataGridViewRow row in dgw.Rows)
                    {
                        if (fila.Cells[i].Value != null)
                        {
                            if (fila.Cells[i].Value.ToString() == row.Cells["cod"].Value.ToString())
                            {
                                row.Cells["op"].Value = true;
                                break;
                            }
                        }
                    }
                }
                cargaComboAlmacen();
                if (fila.Cells[8].Value != null)//checkear el combo almacen
                    cbo_alm.SelectedValue = fila.Cells[8].Value;
                else
                    cbo_alm.SelectedIndex = -1;

                //cargaComboEncargadoNumeracionContrato();     /////esto era cuando se queria controlar la numeracion con un responsable de la numeracion de contratos
                //if (fila.Cells[9].Value != null)//checkear el combo codigo encargado numeracion contrato
                //    cbo_enc_num_contrato.SelectedValue = fila.Cells[9].Value;
                //else
                //    cbo_enc_num_contrato.SelectedIndex = -1;
            }

        }

    }
}
