using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.REPORTES.FORM_REPORTES
{
    public partial class REPORTE_AÑO_MES : Form
    {
        string MES5, COD_CLASE1, COD_GRUPO, COD_SUBGRUPO, ST_GRUPO, ST_SUBGRUPO, AGRU, NEGATIVO, ORD, SALDOCERO;
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        public REPORTE_AÑO_MES(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void REPORTE_AÑO_MES_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_AÑO();
            CARGAR_CLASE();
            cbo_año.Select();
            cbo_año.Text = AÑO;
        }

        private void REPORTE_AÑO_MES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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

        private void cbo_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_grupo.SelectedIndex != -1)
                CARGAR_SUBGRUPO();
        }
        private void CARGAR_SUBGRUPO()
        {
            subGrupoBLL sgruBLL = new subGrupoBLL();
            subGrupoTo sgruTo = new subGrupoTo();
            sgruTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
            sgruTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
            DataTable dtSGrupo = sgruBLL.obtenerSubGrupoClaseGrupoDAL(sgruTo);
            cbo_subgrupo.DisplayMember = "DESC_SUBGRUPO";
            cbo_subgrupo.ValueMember = "COD_SUBGRUPO";
            cbo_subgrupo.DataSource = dtSGrupo;
        }

        private void ch_sub_CheckedChanged(object sender, EventArgs e)
        {
            cbo_subgrupo.Enabled = ch_sub.Checked;
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ch_negativo_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_negativo.Checked)
                chk_saldo0.Enabled = false;
            else
                chk_saldo0.Enabled = true;
        }

        private void chk_saldo0_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_saldo0.Checked)
                ch_negativo.Enabled = false;
            else
                ch_negativo.Enabled = true;
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;

            ST_GRUPO = "1"; COD_GRUPO = "";
            ST_SUBGRUPO = "1"; COD_SUBGRUPO = "";
            if (ch_gru.Checked)
            {
                ST_GRUPO = "0";
                COD_GRUPO = cbo_grupo.SelectedValue.ToString();
            }
            if (ch_sub.Checked)
            {
                ST_SUBGRUPO = "0";
                COD_SUBGRUPO = cbo_subgrupo.SelectedValue.ToString();
            }
            AGRU = "0"; NEGATIVO = "0"; ORD = "0"; SALDOCERO = "0";
            if (CH_AGRU.Checked) AGRU = "1";
            if (ch_negativo.Checked) NEGATIVO = "1";
            if (CH_ALF.Checked) ORD = "1";
            if (chk_saldo0.Checked) SALDOCERO = "1";
            //---------------------------


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
            if (CBO_CLASE.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }
            if (cbo_grupo.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Grupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_grupo.Focus();
                return result = false;
            }
            if (cbo_subgrupo.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el SubGrupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_subgrupo.Focus();
                return result = false;
            }
            return result;
        }
    }
}
