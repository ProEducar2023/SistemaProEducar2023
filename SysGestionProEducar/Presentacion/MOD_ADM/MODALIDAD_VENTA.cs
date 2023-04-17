using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class MODALIDAD_VENTA : Form
    {
        string boton; DataTable dtMV;
        modalidadVentaBLL mvBLL = new modalidadVentaBLL();
        modalidadVentaTo mvTo = new modalidadVentaTo();
        public MODALIDAD_VENTA()
        {
            InitializeComponent();
        }

        private void MODALIDAD_VENTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtMV = mvBLL.obtenerModalidadVentaBLL();
            cargaDataGrid();
            cargaComboTipoVenta();
            btn_nuevo.Select();
        }

        private void MODALIDAD_VENTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cargaDataGrid()
        {
            if (dtMV.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtMV.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["COD_MODALIDAD_VTA"].Value = rw["COD_MODALIDAD_VTA"].ToString();
                    row.Cells["DESC_MODALIDAD_VTA"].Value = rw["DESC_MODALIDAD_VTA"].ToString();
                    row.Cells["DESC_CORTA"].Value = rw["DESC_CORTA"].ToString();
                }
            }
        }
        private void cargaComboTipoVenta()
        {
            tipoVentaBLL tvBLL = new tipoVentaBLL();
            DataTable dt = tvBLL.obtenerTipoVentaBLL();
            cbo_tipo_venta.ValueMember = "COD_TIPO_VENTA";
            cbo_tipo_venta.DisplayMember = "DESC_TIPO_VENTA";
            cbo_tipo_venta.DataSource = dt;
        }
        private void Limpiar()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_descc.Clear();
            dgw.Rows.Clear();
            cbo_tipo_venta.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_descc.ReadOnly = false;
            cbo_tipo_venta.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : (Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["COD_MODALIDAD_VTA"].Value) + 1).ToString().PadLeft(2, '0');
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            CargarDatosDetalle();
            cbo_tipo_venta.Enabled = false;
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            int idx = dgw1.CurrentRow.Index;
            txt_cod.Text = dgw1.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value.ToString();
            txt_desc.Text = dgw1.Rows[idx].Cells["DESC_MODALIDAD_VTA"].Value.ToString();
            txt_descc.Text = dgw1.Rows[idx].Cells["DESC_CORTA"].Value.ToString();
        }
        private void CargarDatosDetalle()
        {
            mvTo.COD_MODALIDAD_VTA = dgw1.CurrentRow.Cells["COD_MODALIDAD_VTA"].Value.ToString();
            DataTable dt = mvBLL.obtenerTipoVentaporCodBLL(mvTo);
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["codcc"].Value = rw["COD_TIPO_VENTA"];
                    row.Cells["tipocc"].Value = rw["DESC_TIPO_VENTA"];
                }
            }
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
                    {
                        CargarDatos();
                        CargarDatosDetalle();
                    }

                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_descc.ReadOnly = true;
                    cbo_tipo_venta.Enabled = false;
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar una nueva Modalidad ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mvTo.COD_MODALIDAD_VTA = txt_cod.Text;
                mvTo.DESC_MODALIDAD_VTA = txt_desc.Text;
                mvTo.DESC_CORTA = txt_descc.Text;
                DataTable dtTVta = HelpersBLL.obtenerDT(dgw);
                if (!mvBLL.insertarModalidadVentaBLL(mvTo, dtTVta, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adiciono correctamente la Modalidad !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_descc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            //string errMensaje = "";

            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_cod.Text.Length < 2)
            {
                MessageBox.Show("La cantidad de caracteres del codigo es de 2, completalo  !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }

            //if (btn_guardar.Visible == true)
            //{
            //    mvTo.COD_TIPO_VENTA = cbo_tipo_venta.SelectedValue.ToString();
            //    mvTo.COD_MODALIDAD_VTA = txt_cod.Text;
            //    if (!mvBLL.ValidarModalidadVentaBLL(mvTo,ref errMensaje))
            //    {
            //        MessageBox.Show("El codigo de Tipo de Venta y Modalidad ya existen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        cbo_tipo_venta.Focus();
            //        return result = false;
            //    }
            //    else
            //    {
            //        if(errMensaje != "")
            //        {
            //            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return result = false;
            //        }
            //    }
            //}
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Modalidad ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mvTo.COD_MODALIDAD_VTA = txt_cod.Text;
                mvTo.DESC_MODALIDAD_VTA = txt_desc.Text;
                mvTo.DESC_CORTA = txt_descc.Text;
                DataTable dtTVta = HelpersBLL.obtenerDT(dgw);
                if (!mvBLL.modificarModalidadVentaBLL(mvTo, dtTVta, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modifico correctamente la Modalidad !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["COD_MODALIDAD_VTA"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["DESC_MODALIDAD_VTA"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["DESC_CORTA"].Value = txt_descc.Text;
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
            if (dgw1.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Modalidad ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                int idx = dgw1.CurrentRow.Index;
                mvTo.COD_MODALIDAD_VTA = dgw1.Rows[idx].Cells["COD_MODALIDAD_VTA"].Value.ToString();
                if (!mvBLL.eliminarModalidadVentaBLL(mvTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se elimino correctamente la Modalidad !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(idx);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle();
            Panel_v0.Visible = false;
            Panel_v1.Visible = true;
            cbo_tipo_venta.Select();
        }
        private void LIMPIAR_detalle()
        {
            cbo_tipo_venta.SelectedIndex = -1;
            cbo_tipo_venta.Enabled = true;
            btn_guardar2.Visible = true;
            btn_cancelar2.Visible = true;
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionaTipoVenta())
                return;
            dgw.Rows.Add(cbo_tipo_venta.SelectedValue.ToString(), cbo_tipo_venta.Text);
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
        }
        private bool validaAdicionaTipoVenta()
        {
            bool result = true;
            if (cbo_tipo_venta.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Tipo de Venta", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_venta.Focus();
                return result = false;
            }
            var query = from DataGridViewRow row in dgw.Rows
                        where row.Cells["codcc"].Value.ToString() == cbo_tipo_venta.SelectedValue.ToString()
                        select row;
            int cant = query.Count();
            if (cant > 0)
            {
                MessageBox.Show("El mismo Tipo de Venta ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_venta.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Tipo de Venta ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
            }
        }
    }
}
