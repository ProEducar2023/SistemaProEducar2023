using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_COMISIONES_X_PERSONA : Form
    {
        progNivelBLL prnBLL = new progNivelBLL();
        progNivelTo prnTo = new progNivelTo();
        comisionesDetalleBLL codBLL = new comisionesDetalleBLL();
        comisionesDetalleTo codTo = new comisionesDetalleTo();
        public CONSULTA_COMISIONES_X_PERSONA()
        {
            InitializeComponent();
        }

        private void cbo_tipo_planilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CONSULTA_COMISIONES_X_PERSONA_Load(object sender, EventArgs e)
        {

            CARGAR_PROGRAMAS();
            CARGAR_NIVEL();
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cboPrograma.ValueMember = "COD_PROGRAMA";
            cboPrograma.DisplayMember = "DESC_PROGRAMA";
            cboPrograma.DataSource = dt;
            cboPrograma.SelectedIndex = 0;
        }
        private void CARGAR_NIVEL()
        {
            nivelBLL niBLL = new nivelBLL();
            DataTable dt = niBLL.obtenerNivelBLL();
            DataRow rw = dt.NewRow();
            rw["COD_NIVEL"] = "0";
            rw["DESC_NIVEL"] = "TODOS";
            dt.Rows.InsertAt(rw, 0);
            cboNivel.ValueMember = "COD_NIVEL";
            cboNivel.DisplayMember = "DESC_NIVEL";
            cboNivel.DataSource = dt;
            cboNivel.SelectedIndex = 0;
        }

        private void cboNivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            prnTo.COD_NIVEL = cboNivel.SelectedValue.ToString();
            DataTable dt = prnBLL.obtenerPersonasParaConsultaMetasBLL(prnTo);
            DataRow rw = dt.NewRow();
            rw["COD_PER"] = "0";
            rw["DESC_PER"] = "TODOS";
            rw["NRO_DOC"] = "";
            rw["COD_PROGRAMA"] = "";
            rw["DESC_PROGRAMA"] = "";
            dt.Rows.InsertAt(rw, 0);
            cboPersona.ValueMember = "COD_PER";
            cboPersona.DisplayMember = "DESC_PER";
            cboPersona.DataSource = dt;
            cboPersona.SelectedIndex = 0;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgw1.Rows.Clear();
            codTo.COD_PROGRAMA = Convert.ToString(cboPrograma.SelectedValue);
            codTo.COD_NIVEL = Convert.ToString(cboNivel.SelectedValue);
            codTo.COD_PER_SUP = Convert.ToString(cboPersona.SelectedValue) == "0" ? null : Convert.ToString(cboPersona.SelectedValue);
            DataTable dt = codBLL.obtener_Detalle_Comisiones_x_PersonaBLL(codTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["VENDEDOR"].Value = rw["VENDEDOR"].ToString();
                    row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["COD_PER_SUP"].Value = rw["COD_PER_SUP"].ToString();
                    row.Cells["SUPERIOR"].Value = rw["SUPERIOR"].ToString();
                    row.Cells["CUOTA"].Value = rw["CUOTA"].ToString();
                    row.Cells["IMPORTE"].Value = rw["IMPORTE"].ToString();
                    if (codTo.COD_NIVEL == "04")
                        dgw1.Columns["SUPERIOR"].Visible = false;
                    else
                        dgw1.Columns["SUPERIOR"].Visible = true;
                }
            }
        }
    }
}
