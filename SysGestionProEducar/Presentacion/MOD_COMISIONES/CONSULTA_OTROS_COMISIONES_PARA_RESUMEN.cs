using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CONSULTA_OTROS_COMISIONES_PARA_RESUMEN : Form
    {
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        string cod_sucursal, fe_año, fe_mes, cod_per;
        public CONSULTA_OTROS_COMISIONES_PARA_RESUMEN(string cod_sucursal, string fe_año, string fe_mes, string cod_per)
        {
            InitializeComponent();
            this.cod_sucursal = cod_sucursal;
            this.fe_año = fe_año;
            this.fe_mes = fe_mes;
            this.cod_per = cod_per;
        }

        private void CONSULTA_OTROS_COMISIONES_PARA_RESUMEN_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_CONCEPTOS_CARGOS();
        }
        private void CARGAR_CONCEPTOS_CARGOS()
        {
            dirTo.TABLA_COD = "TOCC";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cbo_concepto.ValueMember = "Codigo";
            cbo_concepto.DisplayMember = "Descripción";
            cbo_concepto.DataSource = dt;
            cbo_concepto.SelectedIndex = -1;

        }
        private void CONSULTA_OTROS_COMISIONES_PARA_RESUMEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btn_agregar1_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = true;
            btn_mod1.Visible = false;
            Panel1.Visible = true;
            LIMPIAR_CONTACTO();
            txt_nro_doc.Focus();
        }
        private void LIMPIAR_CONTACTO()
        {
            txt_nro_doc.Clear();
            cbo_concepto.SelectedIndex = -1;
            txt_importe.Clear();
            txt_obs.Clear();
            txt_nro_doc.ReadOnly = false;
            cbo_concepto.Enabled = true;
            txt_importe.ReadOnly = false;
            txt_obs.ReadOnly = false;
        }
        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = false;
            btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            cbo_concepto.Focus();
        }
        private void CARGAR_CONTACTO()
        {
            if (dgw1.Rows.Count > 0)
            {
                txt_nro_doc.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
                dtp_fec_doc.Value = Convert.ToDateTime(dgw1[5, dgw1.CurrentRow.Index].Value);
                cbo_concepto.SelectedValue = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
                txt_importe.Text = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
                txt_obs.Text = dgw1[9, dgw1.CurrentRow.Index].Value.ToString();
            }
        }
        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
                dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarOtrosDescuentos())
                return;
            dgw1.Rows.Add(cod_sucursal, fe_año, fe_mes, cod_per, txt_nro_doc.Text, dtp_fec_doc.Value.ToShortDateString(), cbo_concepto.SelectedValue.ToString(), cbo_concepto.Text, txt_importe.Text, txt_obs.Text);
            Panel1.Visible = false;
            txt_nro_doc.Focus();
        }
        private bool validaGuardarModificarOtrosDescuentos()
        {
            bool result = true;
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro Documento", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_doc.Focus();
                return result = false;
            }
            if (cbo_concepto.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el concepto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_concepto.Focus();
                return result = false;
            }
            if (txt_importe.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el importe", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_mod1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarOtrosDescuentos())
                return;
            int FILA = dgw1.CurrentRow.Index;
            dgw1[4, FILA].Value = txt_nro_doc.Text;
            dgw1[5, FILA].Value = dtp_fec_doc.Value.ToShortDateString();
            dgw1[6, FILA].Value = cbo_concepto.SelectedValue.ToString();
            dgw1[7, FILA].Value = cbo_concepto.Text;
            dgw1[8, FILA].Value = txt_importe.Text;
            dgw1[9, FILA].Value = txt_obs.Text;
            Panel1.Visible = false;
            txt_nro_doc.Focus();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void txt_importe_Leave(object sender, EventArgs e)
        {
            txt_importe.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_importe.Text.Trim());
        }
    }
}
