using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_COS
{
    public partial class REPORTE_VAL : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        public REPORTE_VAL(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void REPORTE_VAL_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_MESES();
            CARGAR_CLASE();
            cbo_año.Text = AÑO;
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
            CBO_CLASE.DataSource = dt;
            CBO_CLASE.DisplayMember = "DESC_CLASE";
            CBO_CLASE.ValueMember = "COD_CLASE";
            CBO_CLASE.SelectedIndex = -1;
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;
        }
        private bool validaPantalla()
        {
            bool result = true;
            if (ch_suc.Checked)
            {
                if (cbo_sucursal.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_sucursal.Focus();
                    return result = false;
                }
            }
            if (cbo_año.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_año.Focus();
                return result = false;
            }
            if (cbo_mes.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mes.Focus();
                return result = false;
            }
            if (CBO_CLASE.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }

            return result;
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
    }
}
