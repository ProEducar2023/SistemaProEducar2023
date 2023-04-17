using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class CLASE_ARTICULO : Form
    {
        string boton;
        DataTable dtClaArticulo;
        claseBLL claBLL = new claseBLL();
        claseTo claTo = new claseTo();
        public CLASE_ARTICULO()
        {
            InitializeComponent();
        }

        private void CLASE_ARTICULO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //dgw1.Rows.Add("01", "MERCADERIAS", "MERCADERIAS","Producto",false,false);
            //dgw1.Rows.Add("02", "PRODUCTO TERMINADO", "PT", "Producto", false, false);
            //dgw1.Rows.Add("03", "ACTIVOS", "ACT", "Producto", false, false);
            dtClaArticulo = claBLL.obtenerClaseArticuloBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtClaArticulo.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtClaArticulo.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["tipo"].Value = rw["COD_TIPO"].ToString();
                    row.Cells["uvta"].Value = rw["COD_D_H"].ToString() == "H" ? true : false;
                    row.Cells["ucom"].Value = rw["COD_TIPO_COMPRAS"].ToString() == "1" ? true : false;
                }
            }
        }
        private void CLASE_ARTICULO_KeyDown(object sender, KeyEventArgs e)
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
            txt_desc2.Clear();
            cbo_tipo.SelectedIndex = -1;
            chkVentas.Checked = false;
            chkCompras.Checked = false;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            cbo_tipo.Enabled = true;
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
            txt_desc2.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            //cbo_tipo.SelectedItem = dgw1[3, dgw1.CurrentRow.Index].Value;
            if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "P")
                cbo_tipo.Text = "Producto";
            else if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "S")
                cbo_tipo.Text = "Servicio";
            else if (dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "T")
                cbo_tipo.Text = "Terminado";
            else cbo_tipo.SelectedIndex = -1;
            chkVentas.Checked = Convert.ToBoolean(dgw1[4, dgw1.CurrentRow.Index].Value);
            chkCompras.Checked = Convert.ToBoolean(dgw1[5, dgw1.CurrentRow.Index].Value);
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
                    txt_desc2.ReadOnly = true;
                    cbo_tipo.Enabled = false;
                    chkVentas.Enabled = false;
                    chkCompras.Enabled = false;
                    //txtdescc.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_cod.Text.Length < 2)
            {
                MessageBox.Show("La cantidad de caracteres del codigo es de 2, completalo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (cbo_tipo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el tipo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo.Focus();
                return result = false;
            }
            if (btn_guardar.Visible == true)
            {
                claTo.COD_CLASE = txt_cod.Text.Trim();
                if (claBLL.ValidaClaseBLL(claTo) > 0)
                {
                    MessageBox.Show("Codigo ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }

            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;

            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UNA NUEVA CLASE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                string v = chkVentas.Checked ? "H" : "D";
                string c = chkCompras.Checked ? "1" : "0";
                string cbo = cbo_tipo.Text.Substring(0, 1);
                if (!claBLL.insertaClaseArticuloBLL(txt_cod.Text, txt_desc.Text, txt_desc2.Text, cbo, v, c, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adiciono correctamente la clase !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_desc2.Text, cbo_tipo.SelectedItem, chkVentas.Checked, chkCompras.Checked);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la clase?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                claTo.COD_CLASE = txt_cod.Text;
                claTo.DESC_CLASE = txt_desc.Text;
                claTo.DESC_CORTA = txt_desc2.Text;
                claTo.COD_TIPO = cbo_tipo.Text.Substring(0, 1);
                claTo.COD_D_H = chkVentas.Checked ? "H" : "D";
                claTo.COD_TIPO_COMPRAS = chkCompras.Checked ? "1" : "0";
                if (!claBLL.modificaClaseArticuloBLL(claTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE LA CLASE !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["tipo"].Value = cbo_tipo.SelectedItem;
                    dgw1.CurrentRow.Cells["uvta"].Value = chkVentas.Checked;
                    dgw1.CurrentRow.Cells["ucom"].Value = chkCompras.Checked;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTA CLASE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                claTo.COD_CLASE = dgw1.CurrentRow.Cells["cod"].Value.ToString();
                if (!claBLL.eliminaClaseArticuloBLL(claTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA CLASE !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
