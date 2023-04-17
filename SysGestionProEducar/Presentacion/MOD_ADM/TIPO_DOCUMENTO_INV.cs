using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class TIPO_DOCUMENTO_INV : Form
    {
        string boton;
        DataTable dtDocInv;
        tipoDocInvBLL tdiBLL = new tipoDocInvBLL();
        tipoDocInvTo tdiTo = new tipoDocInvTo();
        public TIPO_DOCUMENTO_INV()
        {
            InitializeComponent();
        }

        private void TIPO_DOCUMENTO_INV_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtDocInv = tdiBLL.obtenerTipoDocInvBLL();
            cargaDataGrid();
            CARGAR_TIPO_PLANILLA();
            btn_nuevo.Select();
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            tipoPlanillaCreacionBLL tpcBLL = new tipoPlanillaCreacionBLL();
            DataTable dt = tpcBLL.obtenerTipoPlanillaCreacionxTransferenciaBLL();
            //
            DataRow rw = dt.NewRow();
            rw["COD_TIPO_PLLA"] = "0";
            rw["DESC_TIPO"] = "Elija";
            dt.Rows.InsertAt(rw, 0);
            if (dt.Rows.Count > 0)
            {
                cbo_tipo_planilla.ValueMember = "COD_TIPO_PLLA";
                cbo_tipo_planilla.DisplayMember = "DESC_TIPO";
                cbo_tipo_planilla.DataSource = dt;
                cbo_tipo_planilla.SelectedValue.ToString();

            }
        }
        private void cargaDataGrid()
        {
            if (dtDocInv.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtDocInv.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["dh"].Value = rw["D/H"].ToString();
                    row.Cells["TIPO_DOC"].Value = rw["TIPO_DOC"].ToString();
                }
            }
        }
        private void TIPO_DOCUMENTO_INV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txt_cod.Clear();
            txt_nom.Clear();
            txt_nom2.Clear();
            txt_cod.ReadOnly = false;
            txt_nom.ReadOnly = false;
            txt_nom2.ReadOnly = false;
            cbo_tipo_planilla.SelectedIndex = 0;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "00001" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_nom.Focus();
        }
        private string obtieneCodigo(int it)
        {
            //int it = Convert.ToInt32(dgw0.Rows[dgw0.Rows.Count].Cells["codtc"].Value);
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_nom.Focus();
        }
        private void CargarDatos()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_nom.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_nom2.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "D")
                rdebe.Checked = true;
            else if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "H")
                rhaber.Checked = true;
            cbo_tipo_planilla.SelectedValue = dgw1.CurrentRow.Cells["TIPO_DOC"].Value.ToString();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (boton == "NUEVO")
                {
                    boton = "DETALLES1";
                }
                else if (boton == "MODIFICAR")
                {
                    boton = "DETALLES2";
                }
                else
                {
                    boton = "DETALLES";
                    Limpiar();
                    if (dgw1.Rows.Count == 0)
                    {


                    }
                    else
                        CargarDatos();

                    txt_cod.ReadOnly = true;
                    txt_nom.ReadOnly = true;
                    txt_nom2.ReadOnly = true;
                    cbo_tipo_planilla.Enabled = false;

                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO TIPO DE DOCUMENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tdiTo.COD_DOC_INV = txt_cod.Text;
                tdiTo.DESC_DOC_INV = txt_nom.Text;
                tdiTo.DESC_CORTA = txt_nom2.Text;
                tdiTo.COD_D_H = rdebe.Checked == true ? "D" : "H";
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();

                if (!tdiBLL.insertarTipoDocInvBLL(tdiTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL TIPO DE DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    string dh = rdebe.Checked == true ? "D" : "H";
                    dgw1.Rows.Add(txt_cod.Text, txt_nom.Text, txt_nom2.Text, dh, cbo_tipo_planilla.SelectedValue.ToString());
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool verifica()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_nom.Text == "")
            {
                MessageBox.Show("INGRESE LA DESCRIPCION !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nom.Focus();
                return result = false;
            }
            if (txt_nom2.Text == "")
            {
                MessageBox.Show("INGRESE LA DESCRIPCION CORTA !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nom2.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                tdiTo.COD_DOC_INV = txt_cod.Text;
                if (tdiBLL.ValidarTipoDocumentoInventarioBLL(tdiTo) > 0)
                {
                    MessageBox.Show("El codigo ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL TIPO DE DOCUMENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tdiTo.COD_DOC_INV = txt_cod.Text;
                tdiTo.DESC_DOC_INV = txt_nom.Text;
                tdiTo.DESC_CORTA = txt_nom2.Text;
                tdiTo.COD_D_H = rdebe.Checked == true ? "D" : "H";
                tdiTo.TIPO_DOC = cbo_tipo_planilla.SelectedValue.ToString();

                if (!tdiBLL.modificarTipoDocInvBLL(tdiTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL TIPO DE DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //string dh = rdebe.Checked == true ? "D" : "H";
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_nom.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_nom2.Text;
                    dgw1.CurrentRow.Cells["dh"].Value = tdiTo.COD_D_H;
                    dgw1.CurrentRow.Cells["TIPO_DOC"].Value = cbo_tipo_planilla.SelectedValue.ToString();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void BTN_ELIMINAR_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL TIPO DE DOCUMENTO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                string COD_DOC_INV = txt_cod.Text;

                if (!tdiBLL.eliminarTipoDocInvBLL(COD_DOC_INV, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL TIPO DE DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);

                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
