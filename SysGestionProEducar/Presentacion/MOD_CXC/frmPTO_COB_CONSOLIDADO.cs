using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class frmPTO_COB_CONSOLIDADO : Form
    {
        planillaCabeceraBLL plcBLL = new planillaCabeceraBLL();
        planillaCabeceraTo plcTo = new planillaCabeceraTo();
        string MES, AÑO = ""; DateTime FECHA_GRAL;
        //bool resultado = false;
        public frmPTO_COB_CONSOLIDADO(string MES, string AÑO, DateTime FECHA_GRAL)
        {
            InitializeComponent();
            this.MES = MES;
            this.AÑO = AÑO;
            this.FECHA_GRAL = FECHA_GRAL;
        }
        private void frmPTO_COB_CONSOLIDADO_Load(object sender, EventArgs e)
        {
            CARGAR_INSTITUCIONES();
            CARGAR_SECTORISTA();
            CARGAR_CANAL_DSCTO();
            CARGAR_TIPO_PLANILLA();
            CARGAR_PROGRAMAS();
        }
        private void CARGAR_PROGRAMAS()
        {
            programaBLL prgBLL = new programaBLL();
            DataTable dt = prgBLL.obtenerProgramaBLL();
            cbo_programa.ValueMember = "COD_PROGRAMA";
            cbo_programa.DisplayMember = "DESC_PROGRAMA";
            cbo_programa.DataSource = dt;
            cbo_programa.SelectedIndex = 0;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInst;
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            //tpllaTo.STATUS_GENERACION = "1";
            tpllaTo.STATUS_CTACTE = "1";
            tpllaTo.COD_VENTA = "VTA";
            DataTable dtTipoPlla = tpllaBLL.obtenerTipoPlanillaCreacionGeneracionPllaBLL(tpllaTo);
            if (dtTipoPlla.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dtTipoPlla;
                cbo_tipo_planilla.SelectedIndex = 0;
            }
        }
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dtEqc;
        }
        private void CARGAR_CANAL_DSCTO()
        {
            canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
            DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
            cbo_canaldscto.ValueMember = "COD_CANAL_DSCTO";
            cbo_canaldscto.DisplayMember = "DESCRIPCION";
            cbo_canaldscto.DataSource = dt;
        }
        public void MOSTRAR_DATOS(string MES, string AÑO, string COD_INSTITUCION)//institucion
        {
            puntoCobranzaBLL ptoBLL = new puntoCobranzaBLL();
            puntoCobranzaTo ptoTo = new puntoCobranzaTo();
            ptoTo.STATUS_CONSOLIDADO = true;
            ptoTo.COD_INSTITUCION = COD_INSTITUCION;
            DataTable dt = ptoBLL.obtenerPuntosCobranzaBLL(ptoTo);
            DataTable dt0 = ptoBLL.obtenerPuntosCobranzaHastaFecVenBLL(FECHA_GRAL, cbo_sectorista.SelectedValue.ToString(),
                cbo_canaldscto.SelectedValue.ToString(), cbo_tipo_planilla.SelectedValue.ToString(), cbo_programa.SelectedValue.ToString());//sectorista,canal_descuento,tipo_planilla

            dgw.Rows.Clear();
            if (dt0.Rows.Count > 0)
            {
                foreach (DataRow rw0 in dt0.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow rw in dt.Rows)
                        {
                            if (rw0["COD_PTO_COB"].ToString() == rw["COD_PTO_COB"].ToString())
                            {
                                int rowId = dgw.Rows.Add();
                                DataGridViewRow row = dgw.Rows[rowId];
                                row.Cells[0].Value = rw["COD_PTO_COB"].ToString();
                                row.Cells[1].Value = rw["DESC_PTO_COB"].ToString();
                                row.Cells[2].Value = false;
                                row.Cells[3].Value = rw["COD_SUCURSAL"].ToString();
                                row.Cells[4].Value = rw["COD_INSTITUCION"].ToString();
                                row.Cells[5].Value = rw["COD_CANAL_DSCTO"].ToString();
                                row.Cells[6].Value = "0";
                                break;
                            }
                        }
                        //break;
                    }
                }
            }
        }
        private bool validaExistePtoCobranza()
        {
            bool result = true;
            if (dgw.Rows.Count <= 0)
            {
                MessageBox.Show("No hay Puntos de Cobranza a seleccionar !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (dgw.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["op"].Value) == true).Count() == 0)
            {
                MessageBox.Show("Elija algun Punto de Cobranza !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            if (!validaExistePtoCobranza())
                return;
            plcTo.COD_PTO_COB_CONSOLIDADO = dgw.CurrentRow.Cells[0].Value.ToString();
            plcTo.TIPO_PLANILLA = cbo_tipo_planilla.SelectedValue.ToString();
            DataTable dt = plcBLL.obtenerPlanillaNoEnviadaBLLporPtoCobranzaBLL(plcTo);
            if (dt.Rows.Count > 0)//esto debe ser mayor que cero > 0
            {
                MessageBox.Show("Pendiente de Envío - Planilla Nº " + dt.Rows[0]["NRO_PLANILLA_COB"].ToString() + " del " + dt.Rows[0]["FECHA_PLANILLA_COB"].ToString().Substring(0, 10), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgw.CurrentRow.Cells[2].Value = false;
            }
            else
                DialogResult = DialogResult.OK;

        }

        private void dgw_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgw.IsCurrentCellDirty)
            {
                dgw.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            MOSTRAR_DATOS(MES, AÑO, cbo_institucion.SelectedValue.ToString());
        }
    }
}
