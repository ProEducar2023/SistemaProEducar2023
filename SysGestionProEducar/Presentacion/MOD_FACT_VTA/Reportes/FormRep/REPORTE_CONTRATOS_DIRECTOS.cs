using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.Reportes.FormRep
{
    public partial class REPORTE_CONTRATOS_DIRECTOS : Form
    {
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        contratoCabeceraBLL ccBLL = new contratoCabeceraBLL();
        contratoCabeceraTo ccTo = new contratoCabeceraTo();
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        public REPORTE_CONTRATOS_DIRECTOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
        }

        private void REPORTE_CONTRATOS_DIRECTOS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_SUCURSAL();
            CARGAR_MESES();
            CARGAR_CLASE();
            cbo_año.Text = AÑO;
            cbo_clase.Focus();
            cbo_mes.SelectedValue = MES;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "FVT";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
        }
        private void CARGAR_MESES()
        {
            var months = new[] { new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" } };
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = 0;
        }
        private void CARGAR_CLASE()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            articuloClaseTo clsTo = new articuloClaseTo();
            clsTo.COD_USU = COD_USU;
            clsTo.TIPO_USU = TIPO_USU;
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            cbo_clase.DataSource = dt;
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.SelectedIndex = 0;
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            ccTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            ccTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            ccTo.FE_AÑO = cbo_año.SelectedValue.ToString();
            ccTo.FE_MES = cbo_mes.SelectedValue.ToString();
            DataTable dt = ccBLL.obtenerContratosparaReporteContratosDirectosBLL(ccTo);
            if (dt.Rows.Count > 0)
            {
                List<contratoCabeceraTo> lcc = new List<contratoCabeceraTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    decimal pre_ref = 0;
                    contratoCabeceraTo cc = new contratoCabeceraTo();
                    cc.NRO_PRESUPUESTO = rw["NRO_PRESUPUESTO"].ToString();
                    cc.FECHA_PRE = Convert.ToDateTime(rw["FECHA_PRE"]);
                    cc.COD_PER = rw["COD_PER"].ToString();
                    cc.NOM_CLI = rw["NOM_CLI"].ToString();
                    cc.DNI_RUC = rw["DNI_RUC"].ToString();
                    cc.PRE_VTA = Convert.ToDecimal(rw["PRE_VTA"]);
                    cc.PRE_REF = decimal.TryParse(rw["PRE_REF"].ToString(), out pre_ref) ? Convert.ToDecimal(rw["PRE_REF"]) : 0;
                    cc.SUM_TOTAL_CONTRATO = Convert.ToDecimal(rw["SUM_TOTAL_CONTRATO"]);
                    cc.COD_INSTITUCION = rw["COD_INSTITUCION"].ToString();
                    lcc.Add(cc);
                }

                MOD_FACT_VTA.Reportes.FormRep.REP_CONTRATOS_DIRECTOS frm = new MOD_FACT_VTA.Reportes.FormRep.REP_CONTRATOS_DIRECTOS();
                frm.Empresa = "EDICIONES AMERICANAS SAC";
                frm.fe_año = cbo_año.SelectedValue.ToString();
                frm.fe_mes = cbo_mes.Text;
                frm.lstcc = lcc;
                frm.Show();
            }
        }
    }
}
