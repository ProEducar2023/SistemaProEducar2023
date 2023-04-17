using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class GRUPO_ARTICULO : Form
    {
        string boton; DataTable dtGrupo;
        grupoBLL gruBLL = new grupoBLL();
        grupoTo gruTo = new grupoTo();
        claseBLL claBLL = new claseBLL();
        public GRUPO_ARTICULO()
        {
            InitializeComponent();
        }

        private void GRUPO_ARTICULO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtGrupo = gruBLL.obtenerGrupoBLL();
            cargaDataGrid();
            cargaCombo();
            BTN_NUEVO.Select();
        }
        private void cargaCombo()
        {
            DataTable dtCombo = claBLL.obtenerClaseArticuloparaGrupoBLL();
            if (dtCombo.Rows.Count > 0)
            {
                cbo_clase.DisplayMember = "DESC_CLASE";
                cbo_clase.ValueMember = "COD_CLASE";
                cbo_clase.DataSource = dtCombo;
            }

        }
        private void cargaDataGrid()
        {
            if (dtGrupo.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtGrupo.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codclase"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["clase"].Value = rw["Clase"].ToString();
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["codsu"].Value = rw["Cod Sunat"].ToString();
                }
            }
        }
        private void GRUPO_ARTICULO_KeyDown(object sender, KeyEventArgs e)
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
            txtCodSunat.Clear();
            cbo_clase.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            txtCodSunat.ReadOnly = false;
            cbo_clase.Enabled = true;
        }

        private void BTN_NUEVO_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = obtieneCodigo(cbo_clase.SelectedValue.ToString());
            TabControl1.SelectedTab = TabPage2;
            cbo_clase.Focus();
        }
        private string obtieneCodigo(string it)
        {
            //string ite = (it + 1).ToString();
            //return ite.PadLeft(2, '0');
            string nu = "";
            DataTable dt = obtieneDetalleDG();
            //DataRow[] rs = dt.Select("codclase like '"+ it + "%'");
            DataRow[] rs = dt.Select("codclase = '" + it + "'");
            if (rs.Length > 0)
            {
                nu = rs[rs.Length - 1].ItemArray[2].ToString();
                nu = (Convert.ToInt32(nu) + 1).ToString();
            }

            return nu.PadLeft(3, '0');
        }
        private DataTable obtieneDetalleDG()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in dgw1.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in dgw1.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : string.Empty;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            cbo_clase.Enabled = false;
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }

        private void CargarDatos()
        {
            cbo_clase.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            txt_cod.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            txtCodSunat.Text = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
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

                    cbo_clase.Enabled = false;
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_desc2.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                BTN_NUEVO.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO GRUPO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                gruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                gruTo.COD_GRUPO = txt_cod.Text;
                gruTo.DESC_GRUPO = txt_desc.Text;
                gruTo.DESC_CORTA = txt_desc2.Text;
                gruTo.COD_SUNAT = txtCodSunat.Text;
                if (!gruBLL.insertarGrupoBLL(gruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL GRUPO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_clase.Text, txt_cod.Text, txt_desc.Text, txt_desc2.Text, txtCodSunat.Text);
                    TabControl1.SelectedTab = TabPage1;
                    BTN_NUEVO.Select();
                }
            }

        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (cbo_clase.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_cod.Text.Length < 3)
            {
                MessageBox.Show("La cantidad de caracteres del codigo es de 3, completalo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (btn_guardar.Visible == true)
            {
                gruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                gruTo.COD_GRUPO = txt_cod.Text;
                if (gruBLL.VerificarGrupoBLL(gruTo) > 0)
                {
                    MessageBox.Show("El codigo de clase y codigo de grupo ya existen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_clase.Focus();
                    return result = false;
                }
            }

            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL GRUPO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                gruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                gruTo.COD_GRUPO = txt_cod.Text;
                gruTo.DESC_GRUPO = txt_desc.Text;
                gruTo.DESC_CORTA = txt_desc2.Text;
                gruTo.COD_SUNAT = txtCodSunat.Text;
                if (!gruBLL.modificaGrupoBLL(gruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL GRUPO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    //dgw1.CurrentRow.Cells["clase"].Value = cbo_clase.SelectedItem;
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["codsu"].Value = txtCodSunat.Text;
                    TabControl1.SelectedTab = TabPage1;
                    BTN_NUEVO.Select();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            BTN_NUEVO.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE GRUPO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                gruTo.COD_CLASE = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                gruTo.COD_GRUPO = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                if (!gruBLL.eliminaGrupoBLL(gruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL GRUPO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }

        }

        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex > -1)
            {
                txt_cod.Text = obtieneCodigo(cbo_clase.SelectedValue.ToString());
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
