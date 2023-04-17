using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class ALMACENES : Form
    {
        string boton; DataTable dtAlm;
        almacenesBLL almBLL = new almacenesBLL();
        almacenTo almTo = new almacenTo();
        public ALMACENES()
        {
            InitializeComponent();
        }

        private void ALMACENES_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtAlm = almBLL.obtenerAlmacenesBLL();
            cargaDataGrid();
            CARGAR_TIPO();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            btn_nuevo.Select();
        }
        private void CARGAR_TIPO()
        {
            DataTable dtTipo = almBLL.obtenerTipoAlmacenesBLL();
            CBO_TIPO.ValueMember = "Cod";
            CBO_TIPO.DisplayMember = "Descripción";
            CBO_TIPO.DataSource = dtTipo;
        }
        private void CARGAR_CLASE()
        {
            claseBLL claBLL = new claseBLL();
            DataTable dtClase = claBLL.obtenerClaseArticuloBLL();
            CBO_CLASE.ValueMember = "Cod";
            CBO_CLASE.DisplayMember = "Descripción";
            CBO_CLASE.DataSource = dtClase;
        }
        private void CARGAR_SUCURSAL()
        {
            sucursalBLL sucBLL = new sucursalBLL();
            DataTable dtSuc = sucBLL.obtenerSucursalBLL();
            cbo_sucursal.ValueMember = "Cod";
            cbo_sucursal.DisplayMember = "Descripción";
            cbo_sucursal.DataSource = dtSuc;
        }
        private void cargaDataGrid()
        {
            if (dtAlm.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtAlm.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["tipalm"].Value = rw["COD_TIPO"].ToString();
                    row.Cells["codcla"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["sucdes"].Value = rw["Sucursal"].ToString();
                    row.Cells["succod"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["loc"].Value = rw["LOCALIDAD"].ToString();
                    row.Cells["dir"].Value = rw["DIRECCION"].ToString();
                    row.Cells["tel"].Value = rw["TELEFONO"].ToString();
                    row.Cells["stsuc"].Value = rw["STATUS_SUCURSAL"].ToString();
                    row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["DESC_CLASE"].Value = rw["DESC_CLASE"].ToString();
                }
            }
        }
        private void ALMACENES_KeyDown(object sender, KeyEventArgs e)
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
            txt_dir.Clear();
            txt_localidad.Clear();
            txt_fono.Clear();
            CBO_TIPO.SelectedIndex = -1;
            CBO_CLASE.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            txt_dir.ReadOnly = false;
            txt_localidad.ReadOnly = false;
            txt_fono.ReadOnly = false;
            CBO_TIPO.Enabled = true;
            CBO_CLASE.Enabled = true;
            ch_sucursal.Checked = false;
            ch_sucursal.Enabled = true;
            cbo_sucursal.SelectedIndex = -1;
            cbo_sucursal.Enabled = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "0001" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["Cod"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(4, '0');
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
            CBO_TIPO.SelectedValue = dgw1[3, dgw1.CurrentRow.Index].Value;
            CBO_CLASE.SelectedValue = dgw1[4, dgw1.CurrentRow.Index].Value;
            if (dgw1[10, dgw1.CurrentRow.Index].Value.ToString() == "1")
            {
                cbo_sucursal.SelectedValue = dgw1[5, dgw1.CurrentRow.Index].Value;
                ch_sucursal.Checked = true;
            }
            else
            {
                ch_sucursal.Checked = false;
                cbo_sucursal.SelectedIndex = -1;
            }
            txt_localidad.Text = dgw1[7, dgw1.CurrentRow.Index].Value.ToString();
            txt_dir.Text = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            txt_fono.Text = dgw1[9, dgw1.CurrentRow.Index].Value.ToString();
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
                    txt_localidad.ReadOnly = true;
                    txt_dir.ReadOnly = true;
                    txt_fono.ReadOnly = true;
                    CBO_CLASE.Enabled = false;
                    CBO_TIPO.Enabled = false;
                    ch_sucursal.Enabled = false;
                    cbo_sucursal.Enabled = false;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO ALMACEN ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                almTo.COD_ALMACEN = txt_cod.Text;
                almTo.DESC_ALMACEN = txt_desc.Text;
                almTo.DESC_CORTA = txt_desc2.Text;
                almTo.COD_TIPO = CBO_TIPO.SelectedValue.ToString();
                almTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                almTo.STATUS_SUCURSAL = ch_sucursal.Checked == true ? "1" : "0";
                //almTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                almTo.COD_SUCURSAL = ch_sucursal.Checked ? cbo_sucursal.SelectedValue.ToString() : "0";
                almTo.LOCALIDAD = txt_localidad.Text;
                almTo.DIRECCION = txt_dir.Text;
                almTo.TELEFONO = txt_fono.Text;
                almTo.STATUS_PICKING = "0";//siempre tendrá este valor 
                if (!almBLL.insertaAlmacenBLL(almTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Almacén !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    string stsuc = ch_sucursal.Checked == true ? "1" : "0";
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_desc2.Text, CBO_TIPO.SelectedValue.ToString(),
                        CBO_CLASE.SelectedValue.ToString(), cbo_sucursal.SelectedValue.ToString(), cbo_sucursal.Text,
                        txt_localidad.Text, txt_dir.Text, txt_fono.Text, stsuc, CBO_TIPO.Text, CBO_CLASE.Text);
                    TabControl1.SelectedTab = TabPage1;
                    FOCO_NUEVO_REG2(txt_cod.Text.Trim());
                    //btn_nuevo.Select();
                }
            }

        }
        private void FOCO_NUEVO_REG2(string cont2)
        {
            int i, cont = 0;
            cont = dgw1.Columns.Count - 1;
            string nrocon = cont2;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1[0, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                    return;
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
            if (txt_cod.Text.Length < 4)
            {
                MessageBox.Show("El codigo es de 2 caracteres !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txt_desc2.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion corta !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            if (CBO_TIPO.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Tipo de Almacen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_TIPO.Focus();
                return result = false;
            }
            if (CBO_CLASE.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_CLASE.Focus();
                return result = false;
            }
            if (ch_sucursal.Checked)
            {
                if (cbo_sucursal.SelectedIndex < 0)
                {
                    MessageBox.Show("Elija la sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_sucursal.Focus();
                    return result = false;
                }
            }
            if (btn_guardar.Visible)
            {
                string errMensaje = string.Empty;
                almTo.COD_ALMACEN = txt_cod.Text;
                int cant = almBLL.verificaAlmacenBLL(almTo, ref errMensaje);
                if (cant < 0)
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
                else if (cant > 0)
                {
                    MessageBox.Show(errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }

            return result;
        }
        private void ch_sucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_sucursal.Checked)
                cbo_sucursal.Enabled = true;
            else
            {
                cbo_sucursal.SelectedIndex = -1;
                cbo_sucursal.Enabled = false;
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!verifica())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL ALMACEN ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                almTo.COD_ALMACEN = txt_cod.Text;
                almTo.DESC_ALMACEN = txt_desc.Text;
                almTo.DESC_CORTA = txt_desc2.Text;
                almTo.COD_TIPO = CBO_TIPO.SelectedValue.ToString();
                almTo.COD_CLASE = CBO_CLASE.SelectedValue.ToString();
                almTo.STATUS_SUCURSAL = ch_sucursal.Checked == true ? "1" : "0";
                almTo.COD_SUCURSAL = ch_sucursal.Checked ? cbo_sucursal.SelectedValue.ToString() : "0";
                almTo.LOCALIDAD = txt_localidad.Text;
                almTo.DIRECCION = txt_dir.Text;
                almTo.TELEFONO = txt_fono.Text;
                almTo.STATUS_PICKING = "0";//siempre tendrá este valor 

                if (!almBLL.modificaAlmacenBLL(almTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL ALMACEN !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["tipalm"].Value = CBO_TIPO.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["codcla"].Value = CBO_CLASE.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["sucdes"].Value = cbo_sucursal.Text;
                    dgw1.CurrentRow.Cells["succod"].Value = ch_sucursal.Checked ? cbo_sucursal.SelectedValue.ToString() : "0";
                    dgw1.CurrentRow.Cells["loc"].Value = txt_localidad.Text;
                    dgw1.CurrentRow.Cells["dir"].Value = txt_dir.Text;
                    dgw1.CurrentRow.Cells["tel"].Value = txt_fono.Text;
                    dgw1.CurrentRow.Cells["stsuc"].Value = ch_sucursal.Checked == true ? "1" : "0";
                    dgw1.CurrentRow.Cells["DESC_TIPO"].Value = CBO_TIPO.Text;
                    dgw1.CurrentRow.Cells["DESC_CLASE"].Value = CBO_CLASE.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE ALMACEN ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                almTo.COD_ALMACEN = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                if (!almBLL.eliminaAlmacenBLL(almTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL ALMACEN !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
