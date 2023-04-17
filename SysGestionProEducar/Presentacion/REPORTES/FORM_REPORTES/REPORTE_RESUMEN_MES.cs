using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.REPORTES.FORM_REPORTES
{
    public partial class REPORTE_RESUMEN_MES : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        public REPORTE_RESUMEN_MES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void REPORTE_RESUMEN_MES_Load(object sender, EventArgs e)
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
            cbo_mes1.ValueMember = "cod";
            cbo_mes1.DisplayMember = "val";
            cbo_mes1.DataSource = months;
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

        private void CBO_CLASE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_CLASE.SelectedIndex != -1)
            {
                grupoBLL gruBLL = new grupoBLL();
                DataTable dtGrupo = gruBLL.obtenerGrupoClaseBLL(CBO_CLASE.SelectedValue.ToString());
                cbo_grupo.DisplayMember = "DESC_GRUPO";
                cbo_grupo.ValueMember = "COD_GRUPO";
                cbo_grupo.DataSource = dtGrupo;
            }
        }

        private void ch_gru_CheckedChanged(object sender, EventArgs e)
        {
            cbo_grupo.Enabled = ch_gru.Checked;
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;


        }
        private bool validaPantalla()
        {
            bool result = true;
            if (cbo_año.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_año.Focus();
                return result = false;
            }
            if (cbo_mes1.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mes1.Focus();
                return result = false;
            }
            if (CBO_CLASE.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }
            if (ch_gru.Checked)
            {
                if (cbo_grupo.SelectedIndex <= -1)
                {
                    MessageBox.Show("Elija el Grupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_grupo.Focus();
                    return result = false;
                }
            }

            return result;
        }
    }
}
