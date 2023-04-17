using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class TIPO_PLANILLA_CREACION : Form
    {
        tipoPlanillaCreacionBLL tpllaBLL = new tipoPlanillaCreacionBLL();
        tipoPlanillaCreacionTo tpllaTo = new tipoPlanillaCreacionTo();
        DataTable dtTipPllaCrea;
        string boton;
        string COD_USU;
        public TIPO_PLANILLA_CREACION(string COD_USU)
        {
            InitializeComponent();
            this.COD_USU = COD_USU;
        }

        private void TIPO_PLANILLA_CREACION_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGA_TIPO_OPERACION();
            CARGAR_TIPO_VENTA();
            dtTipPllaCrea = tpllaBLL.obtenerTipoPlanillaCreacionBLL();
            cargaDataGrid();
            btn_nuevo.Select();
        }
        private void CARGAR_TIPO_VENTA()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("val", typeof(string));
            DataRow rw = dt.NewRow();
            rw["cod"] = "VTA";
            rw["val"] = "VENTA";
            dt.Rows.Add(rw);
            DataRow rw1 = dt.NewRow();
            rw1["cod"] = "DEV";
            rw1["val"] = "DEVOLUCION";
            dt.Rows.Add(rw1);
            DataRow rw2 = dt.NewRow();
            rw2["cod"] = "APL";
            rw2["val"] = "APLICACION";
            dt.Rows.Add(rw2);
            cbo_cod_venta.ValueMember = "cod";
            cbo_cod_venta.DisplayMember = "val";
            cbo_cod_venta.DataSource = dt;
            cbo_cod_venta.SelectedIndex = 0;
        }
        private void CARGA_TIPO_OPERACION()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("val", typeof(string));
            DataRow rw = dt.NewRow();
            rw["cod"] = "P";
            rw["val"] = "P";
            dt.Rows.Add(rw);
            DataRow rw1 = dt.NewRow();
            rw1["cod"] = "D";
            rw1["val"] = "D";
            dt.Rows.Add(rw1);
            cbo_tipo_ope.ValueMember = "cod";
            cbo_tipo_ope.DisplayMember = "val";
            cbo_tipo_ope.DataSource = dt;
            cbo_tipo_ope.SelectedIndex = 0;
        }
        private void cargaDataGrid()
        {
            if (dtTipPllaCrea.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtTipPllaCrea.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["CODIGO"].Value = rw["CODIGO"].ToString();
                    row.Cells["COD_TIPO_PLLA"].Value = rw["COD_TIPO_PLLA"].ToString();
                    row.Cells["COD_TIPO_OPERACION"].Value = rw["COD_TIPO_OPERACION"].ToString();
                    row.Cells["DESC_TIPO"].Value = rw["DESC_TIPO"].ToString();
                    row.Cells["DESC_CORTA"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["COD_VENTA"].Value = rw["COD_VENTA"].ToString();
                    row.Cells["OBSERVACION"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["STATUS_GENERACION"].Value = rw["STATUS_GENERACION"].ToString();
                    row.Cells["STATUS_CTACTE"].Value = rw["STATUS_CTACTE"].ToString();
                }
            }
        }

        private void TIPO_PLANILLA_CREACION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txt_cod.Clear();
            txt_tipo_plla.Clear();
            //txt_tipo_ope.Clear();
            cbo_tipo_ope.SelectedIndex = 0;
            txt_desc.Clear();
            txtdescc.Clear();
            cbo_cod_venta.SelectedIndex = 0;
            txt_observacion.Clear();
            txt_cod.ReadOnly = false;
            txt_tipo_plla.ReadOnly = false;
            //txt_tipo_ope.ReadOnly = false;
            cbo_tipo_ope.Enabled = true;
            cbo_cod_venta.Enabled = true;
            txt_desc.ReadOnly = false;
            txtdescc.ReadOnly = false;
            txt_observacion.ReadOnly = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["CODIGO"].Value));
            TabControl1.SelectedTab = TabPage2;
            txt_tipo_plla.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
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
            txt_cod.Text = dgw1.CurrentRow.Cells["CODIGO"].Value.ToString();
            txt_tipo_plla.Text = dgw1.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString();
            //txt_tipo_ope.Text = dgw1.CurrentRow.Cells["COD_TIPO_OPERACION"].Value.ToString();
            cbo_tipo_ope.SelectedValue = dgw1.CurrentRow.Cells["COD_TIPO_OPERACION"].Value.ToString();
            txt_desc.Text = dgw1.CurrentRow.Cells["DESC_TIPO"].Value.ToString();
            txtdescc.Text = dgw1.CurrentRow.Cells["DESC_CORTA"].Value.ToString();
            cbo_cod_venta.SelectedValue = dgw1.CurrentRow.Cells["COD_VENTA"].Value.ToString();
            txt_observacion.Text = dgw1.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            chk_st_gen.Checked = dgw1.CurrentRow.Cells["STATUS_GENERACION"].Value.ToString() == "1" ? true : false;
            chk_st_cta_cte.Checked = dgw1.CurrentRow.Cells["STATUS_CTACTE"].Value.ToString() == "1" ? true : false;

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
                    cbo_cod_venta.Enabled = false;
                    cbo_tipo_ope.Enabled = false;
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Tipo de Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tpllaTo.CODIGO = txt_cod.Text;
                tpllaTo.COD_TIPO_PLLA = txt_tipo_plla.Text;
                tpllaTo.COD_TIPO_OPERACION = cbo_tipo_ope.SelectedValue.ToString();//txt_tipo_ope.Text;
                tpllaTo.DESC_TIPO = txt_desc.Text;
                tpllaTo.DESC_CORTA = txtdescc.Text;
                tpllaTo.COD_VENTA = cbo_cod_venta.SelectedValue.ToString();
                tpllaTo.OBSERVACION = txt_observacion.Text;
                tpllaTo.STATUS_GENERACION = chk_st_gen.Checked ? "1" : "0";
                tpllaTo.STATUS_CTACTE = chk_st_cta_cte.Checked ? "1" : "0";
                tpllaTo.COD_CREACION = COD_USU;
                tpllaTo.FEC_CREACION = DateTime.Now;
                if (!tpllaBLL.insertarTipoPlanillaCreacionBLL(tpllaTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el Tipo de Planilla !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.Rows.Add(txt_cod.Text, txt_tipo_plla.Text, cbo_tipo_ope.SelectedValue.ToString(), txt_desc.Text, txtdescc.Text, cbo_cod_venta.SelectedValue.ToString(),
                    txt_observacion.Text, chk_st_gen.Checked ? "1" : "0", chk_st_cta_cte.Checked ? "1" : "0");
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
                MessageBox.Show("Ingresar el codigo !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_tipo_plla.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar el Tipo de Planilla !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tipo_plla.Focus();
                return result = false;
            }
            //if(txt_tipo_ope.Text.Trim() == "")
            //{
            //    MessageBox.Show("Ingresar el Tipo de Operacion !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txt_tipo_ope.Focus();
            //    return result = false;
            //}
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar la descripcion de la Planilla !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txtdescc.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar la descripcion corta de Planilla !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdescc.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Tipo de Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tpllaTo.CODIGO = txt_cod.Text;
                tpllaTo.COD_TIPO_PLLA = txt_tipo_plla.Text;
                tpllaTo.COD_TIPO_OPERACION = cbo_tipo_ope.SelectedValue.ToString();//txt_tipo_ope.Text;
                tpllaTo.DESC_TIPO = txt_desc.Text;
                tpllaTo.DESC_CORTA = txtdescc.Text;
                tpllaTo.COD_VENTA = cbo_cod_venta.SelectedValue.ToString();
                tpllaTo.OBSERVACION = txt_observacion.Text;
                tpllaTo.STATUS_GENERACION = chk_st_gen.Checked ? "1" : "0";
                tpllaTo.STATUS_CTACTE = chk_st_cta_cte.Checked ? "1" : "0";
                tpllaTo.COD_MODIFICACION = COD_USU;
                tpllaTo.FEC_MODIFICACION = DateTime.Now;

                if (!tpllaBLL.modificarTipoPlanillaCreacionBLL(tpllaTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente el Tipo de Planilla !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgw1.CurrentRow.Cells["CODIGO"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["COD_TIPO_PLLA"].Value = txt_tipo_plla.Text;
                    dgw1.CurrentRow.Cells["COD_TIPO_OPERACION"].Value = cbo_tipo_ope.SelectedValue.ToString();//txt_tipo_ope.Text;
                    dgw1.CurrentRow.Cells["DESC_TIPO"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["DESC_CORTA"].Value = txtdescc.Text;
                    dgw1.CurrentRow.Cells["COD_VENTA"].Value = cbo_cod_venta.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["OBSERVACION"].Value = txt_observacion.Text;
                    dgw1.CurrentRow.Cells["STATUS_GENERACION"].Value = chk_st_gen.Checked ? "1" : "0";
                    dgw1.CurrentRow.Cells["STATUS_CTACTE"].Value = chk_st_cta_cte.Checked ? "1" : "0";
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
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el tipo de Planilla ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                tpllaTo.CODIGO = dgw1.CurrentRow.Cells["CODIGO"].Value.ToString();
                tpllaTo.COD_TIPO_PLLA = dgw1.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString();
                if (!tpllaBLL.eliminarTipoPlanillaCreacionBLL(tpllaTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente el tipo de Planilla !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
