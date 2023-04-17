using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class CARGOS_ABONOS_COMISIONES : Form
    {
        string boton; DataTable dtCac;
        cargosAbonosComisionesBLL cacBLL = new cargosAbonosComisionesBLL();
        cargosAbonosComisionesTo cacTo = new cargosAbonosComisionesTo();
        public CARGOS_ABONOS_COMISIONES()
        {
            InitializeComponent();
        }

        private void CARGOS_ABONOS_COMISIONES_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtCac = cacBLL.obtenerCargosAbonosComisionesBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtCac.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtCac.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_CONCEPTO"].ToString();
                    row.Cells["desc"].Value = rw["DESC_CONCEPTO"].ToString();
                    row.Cells["descc"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["st_imp"].Value = Convert.ToBoolean(rw["STATUS_IMPUESTOS"]);
                }
            }
        }
        private void CARGOS_ABONOS_COMISIONES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txtdescc.Clear();
            chk_status.Checked = false;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txtdescc.ReadOnly = false;
            chk_status.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
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
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txtdescc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            chk_status.Checked = Convert.ToBoolean(dgw1[3, dgw1.CurrentRow.Index].Value);
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
                    txt_desc.ReadOnly = true;
                    txtdescc.ReadOnly = true;
                    chk_status.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Concepto ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                cacTo.COD_CONCEPTO = txt_cod.Text;
                cacTo.DESC_CONCEPTO = txt_desc.Text;
                cacTo.DESC_CORTA = txtdescc.Text;
                cacTo.STATUS_IMPUESTOS = chk_status.Checked;
                if (!cacBLL.insertarCargosAbonosComisionesBLL(cacTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Concepto !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Insert(dgw1.Rows.Count, txt_cod.Text, txt_desc.Text, txtdescc.Text, chk_status.Checked);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Cogido !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txtdescc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Descripcion Corta!!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescc.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar el Concepto?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                cacTo.COD_CONCEPTO = txt_cod.Text;
                cacTo.DESC_CONCEPTO = txt_desc.Text;
                cacTo.DESC_CORTA = txtdescc.Text;
                cacTo.STATUS_IMPUESTOS = chk_status.Checked;
                if (!cacBLL.modificarCargosAbonosComisionesBLL(cacTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente el Concepto !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txtdescc.Text;
                    dgw1.CurrentRow.Cells["st_imp"].Value = chk_status.Checked;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar el Concepto ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                cacTo.COD_CONCEPTO = dgw1.CurrentRow.Cells["cod"].Value.ToString();
                if (!cacBLL.eliminarCargosAbonosComisionesBLL(cacTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente el Concepto !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
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
