using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class SUPERVISOR_EQ_VTA : Form
    {
        string boton; DataTable dtDir;
        directorBLL dirBLL = new directorBLL();
        directorTo dirTo = new directorTo();
        public SUPERVISOR_EQ_VTA()
        {
            InitializeComponent();
        }

        private void SUPERVISOR_EQ_VTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //dgw1.Rows.Insert(0, "01", "PROGRAMA 1", "PROG");
            dtDir = dirBLL.obtenerDirectorBLL();
            cargaDataGrid();
            llenaComboDirNac();
            BTN_NUEVO.Select();
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
        private void cargaDataGrid()
        {
            if (dtDir.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtDir.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["coddirnac"].Value = rw["COD_DIRNAC"].ToString();
                    row.Cells["cod"].Value = rw["COD_DIR"].ToString();
                    row.Cells["desc"].Value = rw["DESC_DIR"].ToString();
                    row.Cells["abr"].Value = rw["DESC_CORTA"].ToString();
                    row.Cells["act"].Value = Convert.ToBoolean(rw["STATUS_ACT"]);
                }
            }
        }
        private void SUPERVISOR_EQ_VTA_KeyDown(object sender, KeyEventArgs e)
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
            ch_act.Checked = false;
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_desc2.ReadOnly = false;
        }

        private void BTN_NUEVO_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            txt_cod.Text = dgw1.Rows.Count == 0 ? "01" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cod"].Value));
            ch_act.Checked = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_clase.Enabled = true;
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
            txt_desc.Focus();
        }
        private void CargarDatos()
        {
            cbo_clase.SelectedValue = dgw1[0, dgw1.CurrentRow.Index].Value;
            txt_cod.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc2.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            ch_act.Checked = Convert.ToBoolean(dgw1[4, dgw1.CurrentRow.Index].Value);
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR EL NUEVO DIRECTOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                dirTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                dirTo.COD_DIR = txt_cod.Text;
                dirTo.DESC_DIR = txt_desc.Text;
                dirTo.DESC_CORTA = txt_desc2.Text;

                if (!dirBLL.insertarDirectorBLL(dirTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL DIRECTOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_clase.SelectedValue.ToString(), txt_cod.Text, txt_desc.Text, txt_desc2.Text, true);
                    TabControl1.SelectedTab = TabPage1;
                    BTN_NUEVO.Select();
                }
            }

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL NUEVO DIRECTOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                dirTo.COD_DIRNAC = cbo_clase.SelectedValue.ToString();
                dirTo.COD_DIR = txt_cod.Text;
                dirTo.DESC_DIR = txt_desc.Text;
                dirTo.DESC_CORTA = txt_desc2.Text;
                dirTo.STATUS_ACT = ch_act.Checked;

                if (!dirBLL.modificarDirectorBLL(dirTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL DIRECTOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["coddirnac"].Value = cbo_clase.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["abr"].Value = txt_desc2.Text;
                    dgw1.CurrentRow.Cells["act"].Value = ch_act.Checked;
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR EL NUEVO DIRECTOR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                dirTo.COD_DIRNAC = dgw1.CurrentRow.Cells["coddirnac"].Value.ToString(); ;
                dirTo.COD_DIR = dgw1.CurrentRow.Cells["cod"].Value.ToString();

                if (!dirBLL.eliminarDirectorBLL(dirTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL DIRECTOR !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
