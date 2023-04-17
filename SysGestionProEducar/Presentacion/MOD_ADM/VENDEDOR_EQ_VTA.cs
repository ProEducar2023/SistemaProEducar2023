using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class VENDEDOR_EQ_VTA : Form
    {
        string boton; DataTable dtVen;
        supervisorBLL supBLL = new supervisorBLL();
        supervisorTo supTo = new supervisorTo();
        public VENDEDOR_EQ_VTA()
        {
            InitializeComponent();
        }

        private void VENDEDOR_EQ_VTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //dgw1.Rows.Insert(0, "01", "PROGRAMA 1", "PROG");
            dtVen = supBLL.obtenerSupervisorBLL();
            cargaDataGrid();
            llenaComboDirNac();
            llenaComboDir();
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
                    row.Cells["cod"].Value = rw["COD_SUP"].ToString();
                    row.Cells["desc"].Value = rw["DESC_SUP"].ToString();
                    row.Cells["abr"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["act"].Value = Convert.ToBoolean(rw["STATUS_ACT"]);
                }
            }
        }
        private void VENDEDOR_EQ_VTA_KeyDown(object sender, KeyEventArgs e)
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
            ch_act.Checked = false;
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
            //txt_cod.Text = "0" + (dgw1.Rows.Count + 1).ToString();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            ch_act.Checked = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_clase.Enabled = true;
            cbo_grupo.Enabled = true;
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
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_clase.Enabled = false;
            cbo_grupo.Enabled = false;
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            cbo_clase.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            cbo_grupo.SelectedValue = dgw1[1, dgw1.CurrentRow.Index].Value;
            txt_cod.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            ch_act.Checked = Convert.ToBoolean(dgw1[5, dgw1.CurrentRow.Index].Value);

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

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR EL NUEVO SUPERVISOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                supTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                supTo.COD_DIR = cbo_grupo.SelectedValue.ToString();
                supTo.COD_SUP = txt_cod.Text;
                supTo.DESC_SUP = txt_desc.Text;
                supTo.DESC_CORTA = txt_desc2.Text;
                supTo.STATUS_ACT = ch_act.Checked;

                if (!supBLL.insertarSupervisorBLL(supTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL SUPERVISOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_grupo.SelectedValue.ToString(), txt_cod.Text, txt_desc.Text, txt_desc2.Text, true);
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL SUPERVISOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                supTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                supTo.COD_DIR = cbo_grupo.SelectedValue.ToString();
                supTo.COD_SUP = txt_cod.Text;
                supTo.DESC_SUP = txt_desc.Text;
                supTo.DESC_CORTA = txt_desc2.Text;
                supTo.STATUS_ACT = ch_act.Checked;

                if (!supBLL.modificarSupervisorBLL(supTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL SUPERVISOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["coddirnac"].Value = cbo_clase.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["coddir"].Value = cbo_grupo.SelectedValue.ToString();
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL SUPERVISOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                supTo.COD_DIRNAC = dgw1.CurrentRow.Cells["coddirnac"].Value.ToString();
                supTo.COD_DIR = dgw1.CurrentRow.Cells["coddir"].Value.ToString();
                supTo.COD_SUP = dgw1.CurrentRow.Cells["cod"].Value.ToString();

                if (!supBLL.eliminarSupervisorBLL(supTo, ref errMensaje))
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
