using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class SERIE_DOCUMENTOS : Form
    {
        string boton;
        DataTable dtSerDoc;
        serieDocumentoBLL sdoBLL = new serieDocumentoBLL();
        serieDocumentosTo sdoTo = new serieDocumentosTo();
        public SERIE_DOCUMENTOS()
        {
            InitializeComponent();
        }

        private void SERIE_DOCUMENTOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtSerDoc = sdoBLL.obtenerSerieDocumentoBLL();
            cargaDataGrid();
            CARGAR_SUCURSAL();
            CARGAR_TIPO_DOC_INV();
            btn_nuevo.Select();
        }
        private void CARGAR_SUCURSAL()
        {
            sucursalBLL sucBLL = new sucursalBLL();
            DataTable dt = sucBLL.obtenerSucursalBLL();
            CBO_SUCURSAL.ValueMember = "Cod";
            CBO_SUCURSAL.DisplayMember = "Descripción";
            CBO_SUCURSAL.DataSource = dt;
        }
        private void CARGAR_TIPO_DOC_INV()
        {
            tipoDocInvBLL tidBLL = new tipoDocInvBLL();
            DataTable dt = tidBLL.obtenerTipoDocInvBLL();
            CBO_TIPO_DOC.ValueMember = "Cod";
            CBO_TIPO_DOC.DisplayMember = "Descripción";
            CBO_TIPO_DOC.DataSource = dt;
        }
        private void cargaDataGrid()
        {
            if (dtSerDoc.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtSerDoc.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codsuc"].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells["suc"].Value = rw["Sucursal"].ToString();
                    row.Cells["stadoc"].Value = rw["STATUS_DOC"].ToString();
                    row.Cells["coddoc"].Value = rw["Cod Doc"].ToString();
                    row.Cells["doc"].Value = rw["Documento"].ToString();
                    row.Cells["ser"].Value = rw["Serie"].ToString();
                    row.Cells["num"].Value = rw["Número"].ToString();
                    //row.Cells["op"].Value = rw["Opcion"].ToString();
                    //row.Cells["sele"].Value = Convert.ToBoolean(rw["Selec."]);
                    //row.Cells["blo"].Value = Convert.ToBoolean(rw["Bloq."]);
                }
            }
        }
        private void SERIE_DOCUMENTOS_KeyDown(object sender, KeyEventArgs e)
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
            CBO_SUCURSAL.SelectedIndex = -1;
            CBO_TIPO_DOC.SelectedIndex = -1;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            CBO_SUCURSAL.Enabled = true;
            CBO_TIPO_DOC.Enabled = true;
            TIPO_DOC.Checked = false;
            TIPO_DOC.Enabled = true;

            txt_cod.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "00" + (dgw1.Rows.Count + 1).ToString();
            TabControl1.SelectedTab = TabPage2;
            CBO_SUCURSAL.Focus();
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
            int i = dgw1.CurrentRow.Index;
            CBO_SUCURSAL.SelectedValue = dgw1[0, i].Value.ToString();
            TIPO_DOC.Checked = dgw1[2, i].Value.ToString() == "1" ? true : false;
            if (TIPO_DOC.Checked == true)
                CARGAR_TIPO_DOC();
            else
                CARGAR_TIPO_DOC_INV();
            CBO_TIPO_DOC.SelectedValue = dgw1[3, i].Value.ToString();
            txt_cod.Text = dgw1[5, i].Value.ToString();
            txt_desc.Text = dgw1[6, i].Value.ToString();
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
                    CBO_TIPO_DOC.Enabled = false;
                    CBO_SUCURSAL.Enabled = false;
                    TIPO_DOC.Enabled = false;

                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                    txt_cod.Enabled = false;
                }
            }
            else
                btn_nuevo.Select();
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (CBO_SUCURSAL.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_SUCURSAL.Focus();
                return result = false;
            }

            if (CBO_TIPO_DOC.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Tipo Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_TIPO_DOC.Focus();
                return result = false;
            }
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Serie !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_cod.Text.Length < 3)
            {
                MessageBox.Show("Complete a 3 digitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Numero de la Serie !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txt_desc.Text.Length < 7)
            {
                MessageBox.Show("Complete a 7 digitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                sdoTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                sdoTo.STATUS_DOC = TIPO_DOC.Checked == true ? "1" : "0";
                sdoTo.COD_DOC = CBO_TIPO_DOC.SelectedValue.ToString();
                sdoTo.SERIE = txt_cod.Text;
                sdoTo.NUMERO = txt_desc.Text;
                if (sdoBLL.verificaSerieDocumentoBLL(sdoTo) > 0)
                {
                    MessageBox.Show("Ya existen Sucursal, Codigo, Serie, Numero !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVA SERIE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                sdoTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                sdoTo.STATUS_DOC = TIPO_DOC.Checked == true ? "1" : "0";
                sdoTo.COD_DOC = CBO_TIPO_DOC.SelectedValue.ToString();
                sdoTo.SERIE = txt_cod.Text;
                sdoTo.NUMERO = txt_desc.Text;
                sdoTo.COD_OPCION = "";
                sdoTo.STATUS_SERIE = "0";
                sdoTo.STATUS_BLOQUE = "0";
                if (!sdoBLL.insertarSerieDocumentoBLL(sdoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE LA SERIE DEL DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(CBO_SUCURSAL.SelectedValue.ToString(), CBO_SUCURSAL.Text, sdoTo.STATUS_DOC, CBO_TIPO_DOC.SelectedValue.ToString(),
                        CBO_TIPO_DOC.Text, txt_cod.Text, txt_desc.Text);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR LA SERIE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                sdoTo.COD_SUCURSAL = CBO_SUCURSAL.SelectedValue.ToString();
                sdoTo.STATUS_DOC = TIPO_DOC.Checked == true ? "1" : "0";
                sdoTo.COD_DOC = CBO_TIPO_DOC.SelectedValue.ToString();
                sdoTo.SERIE = txt_cod.Text;
                sdoTo.NUMERO = txt_desc.Text;
                sdoTo.COD_OPCION = "";
                sdoTo.STATUS_SERIE = "0";
                sdoTo.STATUS_BLOQUE = "0";
                if (!sdoBLL.modificarSerieDocumentoBLL(sdoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE LA SERIE DEL DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["codsuc"].Value = sdoTo.COD_SUCURSAL;
                    dgw1.CurrentRow.Cells["suc"].Value = CBO_SUCURSAL.Text;
                    dgw1.CurrentRow.Cells["stadoc"].Value = sdoTo.STATUS_DOC;
                    dgw1.CurrentRow.Cells["coddoc"].Value = CBO_TIPO_DOC.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["doc"].Value = CBO_TIPO_DOC.Text;
                    dgw1.CurrentRow.Cells["ser"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["num"].Value = txt_desc.Text;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR LA SERIE ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                sdoTo.COD_SUCURSAL = dgw1.CurrentRow.Cells["codsuc"].Value.ToString();//CBO_SUCURSAL.SelectedValue.ToString();
                sdoTo.STATUS_DOC = dgw1.CurrentRow.Cells["stadoc"].Value.ToString();//TIPO_DOC.Checked == true ? "1" : "0";
                sdoTo.COD_DOC = dgw1.CurrentRow.Cells["coddoc"].Value.ToString();//CBO_TIPO_DOC.SelectedValue.ToString();
                sdoTo.SERIE = dgw1.CurrentRow.Cells["ser"].Value.ToString();//txt_cod.Text;

                if (!sdoBLL.eliminarSerieDocumentoBLL(sdoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE LA SERIE DEL DOCUMENTO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);

                }
            }
        }

        private void TIPO_DOC_CheckedChanged(object sender, EventArgs e)
        {
            if (TIPO_DOC.Checked == true)
                CARGAR_TIPO_DOC();
            else
                CARGAR_TIPO_DOC_INV();
        }
        private void CARGAR_TIPO_DOC()
        {
            tipoDocInvBLL tidBLL = new tipoDocInvBLL();
            DataTable dt = tidBLL.obtenerTipoDocGestionBLL();
            CBO_TIPO_DOC.ValueMember = "Cod";
            CBO_TIPO_DOC.DisplayMember = "Descripción";
            CBO_TIPO_DOC.DataSource = dt;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
