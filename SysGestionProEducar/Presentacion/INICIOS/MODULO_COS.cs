using System;
using System.Windows.Forms;

namespace Presentacion.INICIOS
{
    public partial class MODULO_COS : Form
    {
        string AÑO = "", MES = "", COD_MOD, TIPO_USU = "", COD_USU = "", NOM_EMPRESA, NOM_USU;
        DateTime FECHA_INI, FECHA_GRAL;

        public MODULO_COS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string NOM_EMPRESA, string NOM_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            this.NOM_EMPRESA = NOM_EMPRESA;
            this.NOM_USU = NOM_USU;
        }
        private void MODULO_COS_Load(object sender, EventArgs e)
        {
            tsstlUsuario.Text = NOM_USU;
            tsslEmpresa.Text = NOM_EMPRESA;
            tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString();
        }
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void GestionComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COS.COSTO_TRANSFERENCIA frm = new MOD_COS.COSTO_TRANSFERENCIA(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void CostoPromedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MOD_COS.COSTO_PROMEDIO frm = new MOD_COS.COSTO_PROMEDIO(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuValorizacion_Click(object sender, EventArgs e)
        {
            MOD_COS.frmValorizacion frm = new MOD_COS.frmValorizacion(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MovimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COS.REPORTE_VAL frm = new MOD_COS.REPORTE_VAL(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void DocumentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MOD_COS.REPORTE_I_COSTOS frm = new MOD_COS.REPORTE_I_COSTOS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void KardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOD_COS.CONSULTA_KARDEX_ARTICULO frm = MOD_COS.CONSULTA_KARDEX_ARTICULO.ObtenerInstancia(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            MOD_COS.CONSULTA_KARDEX_ARTICULO frm = new MOD_COS.CONSULTA_KARDEX_ARTICULO(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_AÑO_MES frm = new REPORTES.FORM_REPORTES.REPORTE_AÑO_MES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ResumenMensualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REPORTE_RESUMEN_MES frm = new REPORTES.FORM_REPORTES.REPORTE_RESUMEN_MES(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU);
            frm.MdiParent = this;
            frm.Show();
        }


    }
}
