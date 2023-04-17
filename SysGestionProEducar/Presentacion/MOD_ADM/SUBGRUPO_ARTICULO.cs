using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class SUBGRUPO_ARTICULO : Form
    {
        string boton; string codgrupo;
        DataTable dtSubGrupo, dtGrupo;
        subGrupoBLL sgruBLL = new subGrupoBLL();
        subGrupoTo sgruTo = new subGrupoTo();
        claseBLL claBLL = new claseBLL();
        grupoBLL gruBLL = new grupoBLL();

        public SUBGRUPO_ARTICULO()
        {
            InitializeComponent();
        }

        private void SUBGRUPO_ARTICULO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtSubGrupo = sgruBLL.obtenerSubGrupoBLL();
            cargaDataGrid();
            cargaComboClase();
            //cargaComboGrupo();
            btn_nuevo.Select();
        }
        private void cargaComboClase()
        {
            DataTable dtCla = claBLL.obtenerClaseArticuloparaGrupoBLL();
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DataSource = dtCla;
        }
        //private void cargaComboGrupo()
        //{
        //    grupoBLL gruBLL = new grupoBLL();
        //    DataTable dtGrupo = gruBLL.obtenerGrupoBLL ;
        //    cbo_grupo.DisplayMember = "";
        //}
        private void cargaDataGrid()
        {
            if (dtSubGrupo.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtSubGrupo.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codcla"].Value = rw["Clase"].ToString();
                    row.Cells["codgru"].Value = rw["Grupo"].ToString();
                    row.Cells["cod"].Value = rw["Cod"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["abr"].Value = rw["Abrev."].ToString();
                    row.Cells["desgru"].Value = rw["GRUPO1"].ToString();
                }
            }
        }
        private void SUBGRUPO_ARTICULO_KeyDown(object sender, KeyEventArgs e)
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
            cbo_clase.SelectedIndex = -1;
            cbo_grupo.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            cbo_clase.Enabled = true;
            cbo_grupo.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
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
            cbo_clase.Enabled = false;
            cbo_grupo.Enabled = false;
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            cbo_clase.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            cbo_grupo.Text = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            txt_cod.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
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
                    cbo_clase.Enabled = false;
                    cbo_grupo.Enabled = false;
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
            if (cbo_clase.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (cbo_grupo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Grupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_grupo.Focus();
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
                MessageBox.Show("La cantidad de caracteres del codigo es de 3, completalo  !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                sgruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                sgruTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
                sgruTo.COD_SUBGRUPO = txt_cod.Text;
                if (sgruBLL.ValidarSubGrupoBLL(sgruTo) > 0)
                {
                    MessageBox.Show("El codigo de clase, codigo de grupo y el subgrupo ya existen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_clase.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo SubGrupo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                sgruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                sgruTo.COD_GRUPO = codgrupo;
                sgruTo.COD_SUBGRUPO = txt_cod.Text;
                sgruTo.DESC_SUBGRUPO = txt_desc.Text;
                sgruTo.DESC_CORTA = txt_desc2.Text;
                if (!sgruBLL.insertaSubGrupoBLL(sgruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Sel adiciono correctament el SubGrupo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), codgrupo, txt_cod.Text, txt_desc.Text, txt_desc2.Text, cbo_grupo.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el SubGrupo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                sgruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                sgruTo.COD_GRUPO = codgrupo;
                sgruTo.COD_SUBGRUPO = txt_cod.Text;
                sgruTo.DESC_SUBGRUPO = txt_desc.Text;
                sgruTo.DESC_CORTA = txt_desc2.Text;
                if (!sgruBLL.modificaSubGrupoBLL(sgruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modifico correctament el SubGrupo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["codcla"].Value = cbo_clase.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["codgru"].Value = codgrupo;
                    dgw1.CurrentRow.Cells["Cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["desgru"].Value = cbo_grupo.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE SUBGRUPO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                sgruTo.COD_CLASE = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
                sgruTo.COD_GRUPO = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
                //sgruTo.DESC_SUBGRUPO = txt_desc.Text;
                sgruTo.COD_SUBGRUPO = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                if (!sgruBLL.eliminaSubGrupoBLL(sgruTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL SUBGRUPO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex > -1)
            {
                dtGrupo = gruBLL.obtenerGrupoClaseBLL(cbo_clase.SelectedValue.ToString());
                cbo_grupo.DisplayMember = "DESC_GRUPO";
                cbo_grupo.ValueMember = "DESC_GRUPO ";
                cbo_grupo.DataSource = dtGrupo;
            }
        }

        private void cbo_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex == -1 || cbo_grupo.SelectedIndex == -1)
            { }
            else
            {
                codgrupo = gruBLL.obtieneCodGrupoBLL(cbo_grupo.Text, cbo_clase.SelectedValue.ToString());
                txt_cod.Text = sgruBLL.obtenerCodSubGrupoBLL(cbo_clase.SelectedValue.ToString(), codgrupo) == "" ? "001" : sgruBLL.obtenerCodSubGrupoBLL(cbo_clase.SelectedValue.ToString(), codgrupo);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
