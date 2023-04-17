using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class TIPOS_VIVIENDA : Form
    {
        string boton; DataTable dtV;
        multiUsoBLL mulBLL = new multiUsoBLL();
        multiUsoTo mulTo = new multiUsoTo();
        public TIPOS_VIVIENDA()
        {
            InitializeComponent();
        }

        private void TIPOS_VIVIENDA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            mulTo.COD_GRUPO = "01";//TIPO DE VIVIENDA
            dtV = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtV.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtV.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_SUBGRUPO"].ToString();
                    row.Cells["desc"].Value = rw["DES_SUBGRUPO"].ToString();
                    row.Cells["descc"].Value = rw["DES_CORTA"].ToString();
                }
            }
        }
        private void TIPOS_VIVIENDA_KeyDown(object sender, KeyEventArgs e)
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
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txtdescc.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["Cod"].Value));
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
            txtdescc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();

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
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO TIPO DE VIVIENDA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mulTo.COD_GRUPO = "01";
                mulTo.DES_GRUPO = "TIPOS_VIVIENDA";
                mulTo.COD_SUBGRUPO = txt_cod.Text;
                mulTo.DES_SUBGRUPO = txt_desc.Text;
                mulTo.DES_CORTA = txtdescc.Text;
                if (!mulBLL.insertaTablaPorGrupoBLL(mulTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL TIPO DE VIVIENDA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txtdescc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        private bool valida()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR EL CODIGO !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCION !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txtdescc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCION CORTA !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescc.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL TIPO DE VIVIENDA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mulTo.COD_GRUPO = "01";
                mulTo.DES_GRUPO = "TIPOS_VIVIENDA";
                mulTo.COD_SUBGRUPO = txt_cod.Text;
                mulTo.DES_SUBGRUPO = txt_desc.Text;
                mulTo.DES_CORTA = txtdescc.Text;
                if (!mulBLL.modificarTablaPorGrupoBLL(mulTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL TIPO DE VIVIENDA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txtdescc.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL TIPO DE VIVIENDA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                mulTo.COD_GRUPO = "01";
                mulTo.DES_GRUPO = "TIPOS_VIVIENDA";
                mulTo.COD_SUBGRUPO = dgw1.CurrentRow.Cells["cod"].Value.ToString();
                if (!mulBLL.eliminarTablaPorGrupoBLL(mulTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL TIPO DE VIVIENDA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
