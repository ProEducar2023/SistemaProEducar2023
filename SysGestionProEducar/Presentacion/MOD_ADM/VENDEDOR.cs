using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class VENDEDOR : Form
    {
        string boton; DataTable dtVen;
        vendedorBLL venBLL = new vendedorBLL();
        vendedorTo venTo = new vendedorTo();
        public VENDEDOR()
        {
            InitializeComponent();
        }

        private void VENDEDOR_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtVen = venBLL.obtenerVendedorBLL();
            cargaDataGrid();
            llenaComboDirNac();
            llenaComboDir();
            llenaSupervisor();
            btn_nuevo.Select();
        }
        private void llenaComboDirNac()
        {
            directorNacBLL dinBLL = new directorNacBLL();
            DataTable dt = dinBLL.obtenerDirectorNacBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_clase.ValueMember = "COD_DIRNAC";//director nacional
                cbo_clase.DisplayMember = "DESC_DIRNAC";
                cbo_clase.DataSource = dt;
            }
        }
        private void llenaComboDir()
        {
            directorBLL dirBLL = new directorBLL();
            DataTable dt = dirBLL.obtenerDirectorBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_grupo.ValueMember = "COD_DIR";
                cbo_grupo.DisplayMember = "DESC_DIR";
                cbo_grupo.DataSource = dt;
            }
        }
        private void llenaSupervisor()
        {
            supervisorBLL supBLL = new supervisorBLL();
            DataTable dt = supBLL.obtenerSupervisorBLL();
            if (dt.Rows.Count > 0)
            {
                cbosup.ValueMember = "COD_SUP";
                cbosup.DisplayMember = "DESC_SUP";
                cbosup.DataSource = dt;
            }
        }
        private void cargaDataGrid()
        {
            if (dtVen.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtVen.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["coddirnac"].Value = rw["COD_DIRNAC"].ToString();
                    row.Cells["coddir"].Value = rw["COD_DIR"].ToString();
                    row.Cells["codsup"].Value = rw["COD_SUP"].ToString();
                    row.Cells["cod"].Value = rw["COD_VEND"].ToString();
                    row.Cells["desc"].Value = rw["DESC_VEND"].ToString();
                    row.Cells["abr"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["act"].Value = Convert.ToBoolean(rw["STATUS_ACT"]);
                }
            }
        }

        private void VENDEDOR_KeyDown(object sender, KeyEventArgs e)
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
            cbosup.SelectedIndex = -1;
            ch_act.Checked = false;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
            cbo_clase.Enabled = true;
            cbo_grupo.Enabled = true;
            cbosup.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            ch_act.Checked = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_clase.Enabled = true;
            cbo_grupo.Enabled = true;
            cbosup.Enabled = true;
            cbo_clase.Focus();
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
            //
            //if(!Convert.ToBoolean((dgw1[6, dgw1.CurrentRow.Index].Value)))
            //{
            //    cbo_clase.Enabled = true;
            //    cbo_grupo.Enabled = true;
            //    cbosup.Enabled = true;
            //}
            //else
            //{
            //    cbo_clase.Enabled = false;
            //    cbo_grupo.Enabled = false;
            //    cbosup.Enabled = false;
            //}
            //
            cbo_clase.Enabled = false;
            cbo_grupo.Enabled = false;
            cbosup.Enabled = false;
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;

            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            cbo_clase.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            cbo_grupo.SelectedValue = dgw1[1, dgw1.CurrentRow.Index].Value;
            cbosup.SelectedValue = dgw1[2, dgw1.CurrentRow.Index].Value;
            txt_cod.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            ch_act.Checked = Convert.ToBoolean(dgw1[6, dgw1.CurrentRow.Index].Value);

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
                    cbo_grupo.Enabled = false;
                    cbosup.Enabled = false;
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_desc2.ReadOnly = true;
                    //cbo_clase.Enabled = false;
                    //cbo_grupo.Enabled = false;
                    //txtdescc.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR EL NUEVO VENDEDOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                venTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                venTo.COD_DIR = cbo_grupo.SelectedValue.ToString();
                venTo.COD_SUP = cbosup.SelectedValue.ToString();
                venTo.COD_VEND = txt_cod.Text;
                venTo.DESC_VEND = txt_desc.Text;
                venTo.DESC_CORTA = txt_desc2.Text;
                venTo.STATUS_ACT = ch_act.Checked;

                if (!venBLL.insertarVendedorBLL(venTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL VENDEDOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_grupo.SelectedValue.ToString(), cbosup.SelectedValue.ToString(), txt_cod.Text, txt_desc.Text, txt_desc2.Text, true);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL NUEVO VENDEDOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                venTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                venTo.COD_DIR = cbo_grupo.SelectedValue.ToString();
                venTo.COD_SUP = cbosup.SelectedValue.ToString();
                venTo.COD_VEND = txt_cod.Text;
                venTo.DESC_VEND = txt_desc.Text;
                venTo.DESC_CORTA = txt_desc2.Text;
                venTo.STATUS_ACT = ch_act.Checked;

                if (!venBLL.modificarVendedorBLL(venTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL VENDEDOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    //dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_grupo.SelectedValue.ToString(), cbosup.SelectedValue.ToString(), txt_cod.Text, txt_desc.Text, txt_desc2.Text, true);
                    dgw1.CurrentRow.Cells["coddirnac"].Value = cbo_clase.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["coddir"].Value = cbo_grupo.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["codsup"].Value = cbosup.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["act"].Value = ch_act.Checked;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL VENDEDOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                venTo.COD_DIRNAC = dgw1.CurrentRow.Cells["coddirnac"].Value.ToString();
                venTo.COD_DIR = dgw1.CurrentRow.Cells["coddir"].Value.ToString();
                venTo.COD_SUP = dgw1.CurrentRow.Cells["codsup"].Value.ToString();
                venTo.COD_VEND = dgw1.CurrentRow.Cells["cod"].Value.ToString();

                if (!venBLL.eliminarVendedorBLL(venTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL SUPERVISOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
