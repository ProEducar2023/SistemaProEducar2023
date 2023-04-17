using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_COS
{
    public partial class REPORTE_I_COSTOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        public REPORTE_I_COSTOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void REPORTE_I_COSTOS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_MOV();
            CARGAR_SUCURSAL();
            CARGAR_MESES();
            CARGAR_CLASE();
            cbo_año.Text = AÑO;
            cbo_clase.Focus();
            cbo_mes.SelectedValue = MES;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }
        private void CARGAR_MOV()
        {
            movimientosBLL movBLL = new movimientosBLL();
            movimientosTo movTo = new movimientosTo();
            //
            cbo_mov.Items.Clear();
            DataTable dt = movBLL.obtenerMovimientosCostosBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = -1;
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
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            perTo.COD_MODULO = "COS";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
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
            cbo_clase.SelectedIndex = -1;
        }

        private void ch_suc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_suc.Checked)
            {
                cbo_sucursal.Enabled = true;
            }
            else
            {
                cbo_sucursal.Enabled = false;
                cbo_sucursal.SelectedIndex = -1;
            }
        }

        private void ch_clase_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_clase.Checked)
                cbo_clase.Enabled = true;
            else
            {
                cbo_clase.Enabled = false;
                cbo_clase.SelectedIndex = -1;
            }
        }

        private void ch_mov_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_mov.Checked)
                cbo_mov.Enabled = true;
            else
            {
                cbo_mov.Enabled = false;
                cbo_mov.SelectedIndex = -1;
            }
        }
    }
}
