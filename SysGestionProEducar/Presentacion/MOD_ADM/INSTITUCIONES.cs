using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class INSTITUCIONES : Form
    {
        multiUsoBLL mulBLL = new multiUsoBLL();
        multiUsoTo mulTo = new multiUsoTo();
        string boton; DataTable dtInst; DataTable dtTipoPlla; DataTable dtNiveles;
        institucionesBLL insBLL = new institucionesBLL();
        institucionesTo insTo = new institucionesTo();
        public INSTITUCIONES()
        {
            InitializeComponent();
        }

        private void INSTITUCIONES_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtInst = insBLL.obtenerInstitucionesBLL();
            CARGA_COD_ID();
            CARGA_COD_PROC();
            cargaDataGrid();
            cargaTipoPlanilla();
            btn_nuevo.Select();
        }
        private void cargaTipoPlanilla()
        {
            //tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
            //tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
            //tpllaTo.STATUS_GENERACION = "1";
            //tpllaTo.COD_VENTA = "VTA";
            //dtTipoPlla = tpllaBLL.obtenerTipoPlanillaOperacionBLL(tpllaTo);
            //if (dtTipoPlla.Rows.Count > 0)
            //{
            //    cbo_tipo_pla.ValueMember = "COD_TIPO_PLLA";
            //    cbo_tipo_pla.DisplayMember = "DESC_TIPO";
            //    cbo_tipo_pla.DataSource = dtTipoPlla;
            //    cbo_tipo_pla.SelectedIndex = 0;
            //}
            var planilla = new[] {  new { val = "DESCUENTO", cod = "P" },
                                    new { val = "DIRECTA", cod = "D" }};

            cbo_tipo_pla.ValueMember = "cod";
            cbo_tipo_pla.DisplayMember = "val";
            cbo_tipo_pla.DataSource = planilla;
            cbo_tipo_pla.SelectedIndex = -1;
        }
        private void cargaDataGrid()
        {
            if (dtInst.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtInst.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["COD_INST"].ToString();
                    row.Cells["desc"].Value = rw["DESC_INST"].ToString();
                    row.Cells["descc"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["tip_pla"].Value = rw["TIPO_PLANILLA"].ToString();
                    row.Cells["codid"].Value = rw["COD_IDENTIDAD"].ToString();
                    row.Cells["codpro"].Value = rw["COD_PROCESO"].ToString();
                }
            }
        }
        private void CARGA_COD_ID()
        {
            mulTo.COD_GRUPO = "03";//IDENTIDAD
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cboidentidad.ValueMember = "COD_SUBGRUPO";
            cboidentidad.DisplayMember = "DES_SUBGRUPO";
            cboidentidad.DataSource = dt;
        }
        private void CARGA_COD_PROC()
        {
            mulTo.COD_GRUPO = "04";//PROCESO
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cboproceso.ValueMember = "COD_SUBGRUPO";
            cboproceso.DisplayMember = "DES_SUBGRUPO";
            cboproceso.DataSource = dt;
        }
        private void INSTITUCIONES_KeyDown(object sender, KeyEventArgs e)
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
            cbo_tipo_pla.SelectedIndex = -1;
            cboidentidad.SelectedIndex = -1;
            cboproceso.SelectedIndex = -1;
            dgwNiveles_ni.Rows.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txtdescc.ReadOnly = false;
            panelNiveles.Visible = false;
            btnAgre_ni.Visible = true;
            btnMod_ni.Visible = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
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
            CargarDetalles();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txtdescc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            cboidentidad.SelectedValue = dgw1[3, dgw1.CurrentRow.Index].Value;
            cboproceso.SelectedValue = dgw1[4, dgw1.CurrentRow.Index].Value;
            cbo_tipo_pla.SelectedValue = dgw1.Rows[dgw1.CurrentRow.Index].Cells["tip_pla"].Value;
        }
        private void CargarDetalles()
        {
            institucionesNivelesBLL inBLL = new institucionesNivelesBLL();
            institucionesNivelesTo inTo = new institucionesNivelesTo();
            inTo.CODIGO = Convert.ToString(dgw1.CurrentRow.Cells["cod"].Value);
            dtNiveles = inBLL.obtenerInstitucionesNivelesBLL(inTo);
            foreach (DataRow rw in dtNiveles.Rows)
            {
                int rowId = dgwNiveles_ni.Rows.Add();
                DataGridViewRow row = dgwNiveles_ni.Rows[rowId];
                row.Cells["CODIGO"].Value = Convert.ToString(rw["CODIGO"]);
                row.Cells["DESCRIPCION"].Value = Convert.ToString(rw["DESCRIPCION"]);
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UNA NUEVA INSTITUCION ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                insTo.COD_INST = txt_cod.Text;
                insTo.DESC_INST = txt_desc.Text;
                insTo.DESC_CORTA = txtdescc.Text;
                insTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                insTo.COD_IDENTIDAD = cboidentidad.SelectedValue.ToString();
                insTo.DES_IDENTIDAD = cboidentidad.Text;
                insTo.COD_PROCESO = cboproceso.SelectedValue.ToString();
                insTo.DES_PROCESO = cboproceso.Text;
                dtNiveles = HelpersBLL.obtenerDT(dgwNiveles_ni);
                if (!insBLL.insertarInstitucionesBLL(insTo, dtNiveles, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE LA INSTITUCION !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txtdescc.Text, cboidentidad.SelectedValue.ToString(), cboproceso.SelectedValue.ToString(), cbo_tipo_pla.SelectedValue.ToString());
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
            if (cbo_tipo_pla.SelectedIndex == -1)
            {
                MessageBox.Show("ELIJE EL TIPO !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_pla.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCIÓN !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txtdescc.Text.Trim() == "")
            {
                MessageBox.Show("INGRESAR LA DESCRIPCIÓN CORTA !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescc.Focus();
                return result = false;
            }
            if (cbo_tipo_pla.SelectedValue.ToString() == "P")
            {
                if (cboidentidad.SelectedIndex == -1)
                {
                    MessageBox.Show("ELIJE EL CODIGO DE IDENTIDAD !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboidentidad.Focus();
                    return result = false;
                }
                if (cboproceso.SelectedIndex == -1)
                {
                    MessageBox.Show("ELIJE EL CODIGO DE PROCESO !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboproceso.Focus();
                    return result = false;
                }
            }

            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR LA INSTITUCION ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                insTo.COD_INST = txt_cod.Text;
                insTo.DESC_INST = txt_desc.Text;
                insTo.DESC_CORTA = txtdescc.Text;
                insTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                insTo.COD_IDENTIDAD = cboidentidad.SelectedValue.ToString();
                insTo.DES_IDENTIDAD = cboidentidad.Text;
                insTo.COD_PROCESO = cboproceso.SelectedValue.ToString();
                insTo.DES_PROCESO = cboproceso.Text;
                dtNiveles = HelpersBLL.obtenerDT(dgwNiveles_ni);
                if (!insBLL.modificarInstitucionesBLL(insTo, dtNiveles, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE LA INSTITUCION !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["descc"].Value = txtdescc.Text;
                    dgw1.CurrentRow.Cells["codid"].Value = cboidentidad.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["codpro"].Value = cboproceso.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["tip_pla"].Value = cbo_tipo_pla.SelectedValue.ToString();
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTA INSTITUCION ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                insTo.COD_INST = dgw1.CurrentRow.Cells["cod"].Value.ToString();
                if (!insBLL.eliminarInstitucionesBLL(insTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA INSTITUCION !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DGW5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgre_ni_Click(object sender, EventArgs e)
        {
            limpiarInstitucionesNiveles();
            int codigo = dgwNiveles_ni.Rows.Count == 0 ? 0 : Convert.ToInt32(dgwNiveles_ni.Rows[dgwNiveles_ni.Rows.Count - 1].Cells["CODIGO"].Value);
            txtCodigo_ni.Text = obtieneItem(codigo);
            btnGuardar_ni.Visible = true;
            btnModificar_ni.Visible = false;
            panelNiveles.Visible = true;
            txtDescripcion_ni.Focus();
        }
        private void limpiarInstitucionesNiveles()
        {
            txtCodigo_ni.Clear();
            txtDescripcion_ni.Clear();
        }
        private string obtieneItem(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }

        private void btnGuardar_ni_Click(object sender, EventArgs e)
        {
            if (!validaIngresoModificaNiveles())
                return;
            dgwNiveles_ni.Rows.Add(txtCodigo_ni.Text, txtDescripcion_ni.Text);
            panelNiveles.Visible = false;
        }

        private void btnCancelar_ni_Click(object sender, EventArgs e)
        {
            panelNiveles.Visible = false;
        }

        private void btnMod_ni_Click(object sender, EventArgs e)
        {
            if (dgwNiveles_ni.Rows.Count > 0)
            {
                limpiarInstitucionesNiveles();
                cargarInstitucionesNiveles();
                btnGuardar_ni.Visible = false;
                btnModificar_ni.Visible = true;
                panelNiveles.Visible = true;
                txtDescripcion_ni.Focus();
            }
        }
        private void cargarInstitucionesNiveles()
        {
            if (dgwNiveles_ni.Rows.Count > 0)
            {
                txtCodigo_ni.Text = Convert.ToString(dgwNiveles_ni.CurrentRow.Cells["CODIGO"].Value);
                txtDescripcion_ni.Text = Convert.ToString(dgwNiveles_ni.CurrentRow.Cells["DESCRIPCION"].Value);
            }
        }

        private void btnEle_ni_Click(object sender, EventArgs e)
        {
            if (dgwNiveles_ni.Rows.Count > 0)
                dgwNiveles_ni.Rows.RemoveAt(dgwNiveles_ni.CurrentRow.Index);
        }

        private void btnModificar_ni_Click(object sender, EventArgs e)
        {
            if (!validaIngresoModificaNiveles())
                return;
            dgwNiveles_ni.CurrentRow.Cells["CODIGO"].Value = txtCodigo_ni.Text;
            dgwNiveles_ni.CurrentRow.Cells["DESCRIPCION"].Value = txtDescripcion_ni.Text;
            panelNiveles.Visible = false;
        }
        private bool validaIngresoModificaNiveles()
        {
            bool result = true;
            if (txtDescripcion_ni.Text == "")
            {
                MessageBox.Show("Ingrese el Nivel !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion_ni.Focus();
                return result = false;
            }
            return result;
        }
    }
}
