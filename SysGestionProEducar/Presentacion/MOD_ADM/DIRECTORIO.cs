using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class DIRECTORIO : Form
    {
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        string boton, btn;
        public DIRECTORIO()
        {
            InitializeComponent();
        }
        private void DIRECTORIO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            //dgw.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
            btn_nuevo.Select();
            DATAGRID();
        }
        private void DATAGRID()
        {
            DataTable dt = dirBLL.obtenerDirectorioBLL();
            dgw1.DataSource = dt;
            dgw1.Columns[1].Visible = false;
            dgw1.Columns[3].Visible = false;
            dgw1.Columns[0].Width = 50;
        }
        private void DIRECTORIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        public void datagrid1()
        {
            dgw.Rows.Clear();
            dirTo.TABLA_COD = txt_cod.Text;
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            foreach (DataRow rw in dt.Rows)
            {
                int idx = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[idx];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            LIMPIAR_detalle();
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            BTN_CANCELAR.Visible = true;
            BTN_CANCELAR.Text = "&Cancelar";
            txt_cod.Focus();
        }
        public void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            nup_obs.Value = 0;
            j1.Enabled = true;
            //BTN_CANCELAR.Visible = true;
            BTN_CANCELAR.Visible = true;
            Panel1.Enabled = true;
            dgw.Rows.Clear();
        }
        public void LIMPIAR_detalle()
        {
            TXT_COD_det.Clear();
            TXT_DESC_det.Clear();
            txt_obs_det.Clear();
            btn_modificar2.Visible = true;
            btn_guardar2.Visible = true;
            btn_cancelar2.Visible = true;
            TXT_COD_det.ReadOnly = false;
            TXT_DESC_det.ReadOnly = false;
        }
        private void btn_mod2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgw.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btn = "MODIFICAR";
            LIMPIAR_detalle();
            btn_guardar2.Visible = false;
            BTN_CANCELAR.Visible = false;
            btn_modificar2.Visible = true;
            item1.Text = dgw.CurrentRow.Index.ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;
            CARGAR_detalle();
            TXT_COD_det.ReadOnly = true;
            TXT_DESC_det.Focus();
        }
        private void CARGAR_detalle()
        {
            int idx = dgw.CurrentRow.Index;
            TXT_COD_det.Text = dgw[0, idx].Value.ToString();
            TXT_DESC_det.Text = dgw[1, idx].Value.ToString();
            txt_obs_det.Text = dgw[2, idx].Value.ToString();
        }
        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            if (!validaNuevo2())
                return;
            if (boton == "NUEVO" && dgw.Rows.Count == 0 && j1.Enabled == true)
            {
                string errMensaje = "";
                dirTo.TABLA_COD = txt_cod.Text;
                dirTo.DESCRIPCION = txt_desc.Text;
                dirTo.OBSERVACION = nup_obs.Value.ToString();
                if (!dirBLL.insertarDirectorioBLL(dirTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btn = "NUEVO";
            LIMPIAR_detalle();
            btn_guardar2.Visible = true;
            btn_modificar2.Visible = false;
            BTN_CANCELAR.Visible = false;
            //Panel1.Visible = false;
            //Panel2.Visible = true;
            Panel1.Visible = true;
            Panel1.SendToBack();
            Panel2.BringToFront();
            Panel2.Visible = true;
            j1.Enabled = false;
            TXT_COD_det.Focus();
        }
        private bool validaNuevo2()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "" || txt_desc.Text.Trim() == "" || nup_obs.Value == 0)
            {
                MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (boton == "NUEVO" && dgw.Rows.Count == 0 && j1.Enabled == true)
            {
                if (verificar_TABLA() > 0)
                {
                    MessageBox.Show("El Codigo de Tabla ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_cod.Focus();
                    return result = false;
                }
            }

            return result;
        }
        private int verificar_TABLA()
        {
            int cant = -1;
            dirTo.TABLA_COD = txt_cod.Text;
            cant = dirBLL.VERIFICAR_DIRECTORIO_TABLA_BLL(dirTo);
            return cant;
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elgir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            CARGAR_CABECERA();
            datagrid1();
            TabControl1.SelectedTab = TabPage2;
            Panel1.Visible = true;
            Panel2.Visible = false;
            j1.Enabled = false;
            BTN_CANCELAR.Visible = true;
            BTN_CANCELAR.Text = "&Cancelar";
            btn_nuevo2.Select();
        }
        public void CARGAR_CABECERA()
        {
            int idx = dgw1.CurrentRow.Index;
            txt_cod.Text = dgw1[0, idx].Value.ToString();
            txt_desc.Text = dgw1[2, idx].Value.ToString();
            decimal nup = 3;
            nup_obs.Value = nup;
            if (decimal.TryParse(dgw1.Rows[idx].Cells["observación"].Value.ToString(), out nup))
                nup_obs.Value = Convert.ToDecimal(dgw1.Rows[idx].Cells["observación"].Value);

        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgw1.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string cod = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            DialogResult rs = MessageBox.Show("Eliminar: " + cod + " " + dgw1[1, dgw1.CurrentRow.Index].Value.ToString(), "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                dirTo.TABLA_COD = cod;
                if (!dirBLL.eliminarDirectorioBLL(dirTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DATAGRID();
                    btn_nuevo.Select();
                }
            }
        }
        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dgw.CurrentRow.Index;
            }
            catch (Exception)
            {
                MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //string cod = dgw[0, dgw1.CurrentRow.Index].Value.ToString();
            string cod = dgw[0, dgw.CurrentRow.Index].Value.ToString();
            DialogResult rs = MessageBox.Show("Eliminar: " + cod + " " + dgw[1, dgw.CurrentRow.Index].Value.ToString(), "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                dirTo.TABLA_COD = txt_cod.Text;
                dirTo.CODIGO = cod;
                if (!dirBLL.eliminarDirectorioDetBLL(dirTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                    btn_nuevo2.Select();
                }
            }
        }
        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            DATAGRID();
            btn_nuevo.Select();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (boton == "NUEVO")
                {
                    //boton = "DETALLES1";
                }
                else if (boton == "MODIFICAR")
                {
                    //boton = "DETALLES2";
                }
                else
                {
                    boton = "DETALLES";
                    if (dgw1.Rows.Count > 0)
                    {
                        LIMPIAR_CABECERA();
                        CARGAR_CABECERA();
                        LIMPIAR_detalle();
                        datagrid1();
                    }
                    Panel1.Visible = true;
                    Panel1.Enabled = false;
                    Panel2.Visible = false;
                    j1.Enabled = false;
                    BTN_CANCELAR.Visible = true;
                    BTN_CANCELAR.Text = "&Cancelar";
                }
            }
            else
                btn_nuevo.Select();
        }
        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            BTN_CANCELAR.Visible = true;
            BTN_CANCELAR.Text = "&Salir";
            btn_nuevo2.Select();
        }
        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardar2())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo registro al Directorio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                dgw.Rows.Add(TXT_COD_det.Text, TXT_DESC_det.Text, txt_obs_det.Text);
                int idx = dgw.Rows.Count - 1;
                dirTo.TABLA_COD = txt_cod.Text;
                dirTo.CODIGO = dgw[0, idx].Value.ToString();
                dirTo.DESCRIPCION = dgw[1, idx].Value.ToString();
                dirTo.OBSERVACION = dgw[2, idx].Value.ToString();
                if (!dirBLL.insertarDirectorioDatoBLL(dirTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Exito al guardar, se adiciono un registro en el Detalle", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LIMPIAR_detalle();
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                    BTN_CANCELAR.Visible = true;
                    BTN_CANCELAR.Text = "&Salir";
                    btn_nuevo2.Select();
                }
            }
        }
        private bool validaGuardar2()
        {
            bool result = true;
            if (TXT_COD_det.Text.Trim() == "" || TXT_DESC_det.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_det.Focus();
                return result = false;
            }
            int i1 = 0, cont1 = 0;
            cont1 = dgw.Rows.Count - 1;
            for (i1 = 0; i1 <= cont1; i1++)
            {
                if (dgw[0, i1].Value.ToString() == TXT_COD_det.Text)
                {
                    MessageBox.Show("El codigo de Dato ya existe", "YA EXISTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TXT_COD_det.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaModificar2())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el registro del Directorio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw.Rows.Count - 1;
                dirTo.TABLA_COD = txt_cod.Text;
                dirTo.CODIGO = TXT_COD_det.Text;
                dirTo.DESCRIPCION = TXT_DESC_det.Text;
                dirTo.OBSERVACION = txt_obs_det.Text;
                if (!dirBLL.modificarDirectorioBLL(dirTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Exito al guardar", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    int FILA = Convert.ToInt32(item1.Text);
                    dgw[0, FILA].Value = TXT_COD_det.Text;
                    dgw[1, FILA].Value = TXT_DESC_det.Text;
                    dgw[2, FILA].Value = txt_obs_det.Text;
                    LIMPIAR_detalle();
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                    BTN_CANCELAR.Visible = true;
                    BTN_CANCELAR.Text = "&Salir";
                    btn_nuevo2.Select();
                }
            }
        }
        private bool validaModificar2()
        {
            bool result = true;
            if (TXT_COD_det.Text.Trim() == "" && TXT_DESC_det.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los datos", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_det.Focus();
                return result = false;
            }
            return result;
        }

        private void nup_obs_ValueChanged(object sender, EventArgs e)
        {
            if (nup_obs.Value == 1)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 1;
            }
            else if (nup_obs.Value == 2)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 2;
            }
            else if (nup_obs.Value == 3)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 3;
            }
            else if (nup_obs.Value == 4)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 4;
            }
            else if (nup_obs.Value == 5)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 5;
            }
            else if (nup_obs.Value == 6)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 6;
            }
            else if (nup_obs.Value == 7)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 7;
            }
            else if (nup_obs.Value == 8)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 8;
            }
            else if (nup_obs.Value == 9)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 9;
            }
            else if (nup_obs.Value == 10)
            {
                TXT_COD_det.Clear();
                TXT_COD_det.MaxLength = 10;
            }
        }

    }
}
