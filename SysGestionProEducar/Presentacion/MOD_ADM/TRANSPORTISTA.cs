using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class TRANSPORTISTA : Form
    {
        string boton = string.Empty;
        DataTable dtTransportista, dtConductor, dtVehiculo = new DataTable();
        DataSet dsTransportista;
        transportistaBLL traBLL = new transportistaBLL();
        transportistaTo traTo = new transportistaTo();
        int fila;
        public TRANSPORTISTA()
        {
            InitializeComponent();
        }
        private void TRANSPORTISTA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            btn_nuevo.Select();
            //CARGAR_TIPO_VEHICULO()//estoy llenando el combo en el control tiene que ser de BD
            //se traen todas las tablas para llenar los grids
            dsTransportista = traBLL.obtenerTransportista_Conductor_VehiculoBLL();
            dtTransportista = dsTransportista.Tables[0];
            dtConductor = dsTransportista.Tables[1];
            dtConductor.Columns.Add("st", typeof(bool));
            foreach (DataRow rw in dtConductor.Rows) rw["st"] = true;
            dtVehiculo = dsTransportista.Tables[2];
            dtVehiculo.Columns.Add("st", typeof(bool));
            foreach (DataRow rw in dtVehiculo.Rows) rw["st"] = true;
            //
            dtConductor.PrimaryKey = new DataColumn[] { dtConductor.Columns["COD_TRANSPORTISTA"], dtConductor.Columns["ITEM"] };
            dtVehiculo.PrimaryKey = new DataColumn[] { dtVehiculo.Columns["COD_TRANSPORTISTA"], dtVehiculo.Columns["ITEM"] };
            //
            cargaComboTipoVehiculo();
            cargaDataGrid();
        }
        private void cargaComboTipoVehiculo()
        {
            tipoVehiculoBLL tpvBLL = new tipoVehiculoBLL();
            DataTable dtTPV = tpvBLL.obtenerTipoVehiculoBLL();//OBTIENE TIPO_VEHICULO
            cbo_tipo.DisplayMember = "DESC_VEHICULO";
            cbo_tipo.ValueMember = "COD_VEHICULO";
            cbo_tipo.DataSource = dtTPV;
        }
        private void cargaDataGrid()
        {
            if (dtTransportista.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtTransportista.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["codt"].Value = rw["COD_TRANSPORTISTA"].ToString();
                    row.Cells["nomt"].Value = rw["NOMBRE"].ToString();
                    row.Cells["ruct"].Value = rw["RUC"].ToString();
                    row.Cells["dirt"].Value = rw["DIRECCION"].ToString();
                }
            }

        }
        private void TRANSPORTISTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_CABECERA()//llena la etiqueta detalle del tab
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            txt_ruc.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_dir.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
        }
        private void cargaDGVehiculo()
        {
            DataRow[] rs = dtVehiculo.Select("COD_TRANSPORTISTA = " + dgw1.CurrentRow.Cells["codt"].Value.ToString());
            if (rs.Count() > 0)
            {
                dgw.Rows.Clear();
                foreach (DataRow r in rs)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["codtv"].Value = r[0].ToString();
                    row.Cells["itemv1"].Value = r[1].ToString();
                    row.Cells["marv1"].Value = r[2].ToString();
                    row.Cells["nplav1"].Value = r[3].ToString();
                    row.Cells["tipv1"].Value = r[4].ToString();
                    row.Cells["certv1"].Value = r[5].ToString();
                }
            }
        }
        private void cargaDGConductor()
        {
            DataRow[] rs = dtConductor.Select("COD_TRANSPORTISTA = " + dgw1.CurrentRow.Cells["codt"].Value.ToString());
            if (rs.Count() > 0)
            {
                dgw0.Rows.Clear();
                foreach (DataRow r in rs)
                {
                    int rowId = dgw0.Rows.Add();
                    DataGridViewRow row = dgw0.Rows[rowId];
                    row.Cells["codtc"].Value = r[0].ToString();
                    row.Cells["itemc1"].Value = r[1].ToString();
                    row.Cells["nomc1"].Value = r[2].ToString();
                    row.Cells["dirc1"].Value = r[3].ToString();
                    row.Cells["nlicc1"].Value = r[4].ToString();
                    row.Cells["ndocc1"].Value = r[5].ToString();
                }
            }
        }
        private void CARGAR_detalle()
        {
            //DESC_TIPO_VEHICULO();
            txt_marca.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
            txt_nro_placa.Text = dgw[3, dgw.CurrentRow.Index].Value.ToString();
            //cbo_tipo.Text = DESC_TIPO();
            //cbo_tipo.SelectedText = dgw[3, dgw.CurrentRow.Index].Value.ToString();
            cbo_tipo.SelectedValue = dgw[4, dgw.CurrentRow.Index].Value.ToString();
            txt_cert_ins.Text = dgw[5, dgw.CurrentRow.Index].Value.ToString();
        }
        private void CARGAR_detalle0()
        {
            txt_conductor.Text = dgw0[2, dgw0.CurrentRow.Index].Value.ToString();
            txt_direccion.Text = dgw0[3, dgw0.CurrentRow.Index].Value.ToString();
            txt_nro_licencia.Text = dgw0[4, dgw0.CurrentRow.Index].Value.ToString();
            txt_nro_documento.Text = dgw0[5, dgw0.CurrentRow.Index].Value.ToString();
        }
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            txt_dir.Clear();
            txt_ruc.Clear();
            txt_cod.ReadOnly = false;
            txt_desc.ReadOnly = false;
            txt_dir.ReadOnly = false;
            txt_ruc.ReadOnly = false;
            btn_mod.Visible = true;
            btn_guardar.Visible = true;
            btn_cancelar.Visible = true;
            dgw.Rows.Clear();
            dgw0.Rows.Clear();
        }
        private void LIMPIAR_detalle()
        {
            txt_marca.Clear();
            txt_nro_placa.Clear();
            cbo_tipo.SelectedIndex = -1;
            txt_cert_ins.Clear();
            txt_marca.ReadOnly = false;
            txt_nro_placa.ReadOnly = false;
            txt_cert_ins.ReadOnly = false;
            cbo_tipo.Enabled = true;
            btn_modificar2.Visible = true;
            btn_guardar2.Visible = true;
            btn_cancelar2.Visible = true;
        }
        private void LIMPIAR_detalle0()
        {
            txt_conductor.Clear();
            txt_direccion.Clear();
            txt_nro_licencia.Clear();
            txt_nro_documento.Clear();
            txt_conductor.ReadOnly = false;
            txt_direccion.ReadOnly = false;
            txt_nro_licencia.ReadOnly = false;
            txt_nro_documento.ReadOnly = false;
            btn_modificar3.Visible = true;
            btn_guardar3.Visible = true;
            btn_cancelar3.Visible = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            LIMPIAR_detalle();
            LIMPIAR_detalle0();
            //btn_guardar.Visible = true;
            //btn_mod.Visible = false;
            TabControl1.SelectedTab = TabPage2;
            if (TabControl2.SelectedTab == TabPage3)
            {
                Panel_v0.Visible = true;
                Panel_v1.Visible = false;
            }
            else if (TabControl2.SelectedTab == TabPage4)
            {
                Panel_c0.Visible = true;
                Panel_c1.Visible = false;
            }
            txt_cod.Text = dgw1.Rows.Count == 0 ? "00001" : obtieneCodigo(Convert.ToInt32(dgw1.Rows[dgw1.Rows.Count - 1].Cells["codt"].Value));
            btn_guardar.Visible = true;
            btn_mod.Visible = false;

            txt_ruc.Focus();
        }

        private void btn_nuevo2_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle();
            btn_guardar2.Visible = true;
            btn_modificar2.Visible = false;
            Panel_v0.Visible = false;
            Panel_v1.Visible = true;
            txt_marca.Focus();
        }

        private void btn_nuevo3_Click(object sender, EventArgs e)
        {
            LIMPIAR_detalle0();
            btn_guardar3.Visible = true;
            btn_modificar3.Visible = false;
            Panel_c0.Visible = false;
            Panel_c1.Visible = true;
            txt_conductor.Focus();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            LIMPIAR_CABECERA();
            //btn_guardar.Visible = false;
            //btn_mod.Visible = true;
            CARGAR_CABECERA();
            cargaDGVehiculo();
            cargaDGConductor();
            //datagrid1()
            //datagrid2()
            TabControl1.SelectedTab = TabPage2;

            if (TabControl2.SelectedTab == TabPage3)
            {
                Panel_v0.Visible = true;
                Panel_v1.Visible = false;
            }
            else if (TabControl2.SelectedTab == TabPage4)
            {
                Panel_c0.Visible = true;
                Panel_c1.Visible = false;
            }
            txt_cod.ReadOnly = true;
            btn_guardar.Visible = false;
            btn_mod.Visible = true;
            txt_desc.Focus();
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                int i = dgw.CurrentRow.Index;
                LIMPIAR_detalle();
                btn_guardar2.Visible = false;
                btn_modificar2.Visible = true;
                item1.Text = dgw.CurrentRow.Index.ToString();
                Panel_v0.Visible = false;
                Panel_v1.Visible = true;
                CARGAR_detalle();
                txt_marca.Focus();
            }
        }

        private void btn_mod3_Click(object sender, EventArgs e)
        {
            if (dgw0.Rows.Count > 0)
            {
                int i = dgw0.CurrentRow.Index;
                LIMPIAR_detalle0();
                btn_guardar3.Visible = false;
                btn_modificar3.Visible = true;
                item2.Text = dgw0.CurrentRow.Index.ToString();
                Panel_c0.Visible = false;
                Panel_c1.Visible = true;
                CARGAR_detalle0();
                txt_conductor.Focus();
            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE TRANSPORTISTA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                int id = dgw1.CurrentRow.Index;
                DataRow rw = dtTransportista.Rows[id];
                //elimina todos los Vehiculos relacionados con este transportista
                DataRow[] rk = dtVehiculo.Select("COD_TRANSPORTISTA LIKE '" + rw[0].ToString() + "%'");
                foreach (DataRow r in rk)
                    r.Delete();
                //elimina todos los Conductores relacionados con este transportista
                DataRow[] rm = dtConductor.Select("COD_TRANSPORTISTA LIKE '" + rw[0].ToString() + "%'");
                foreach (DataRow r in rm)
                    r.Delete();
                //elimina el transportista
                dtTransportista.Rows[id].Delete();
                //
                if (!traBLL.adicionaInsertaTransportistaBLL(dtTransportista, dtConductor, dtVehiculo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL TRANSPORTISTA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                    btn_nuevo.Select();
                }

            }
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE REGISTRO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                object[] id = new object[2];
                id[0] = dgw.CurrentRow.Cells["codtv"].Value;
                id[1] = dgw.CurrentRow.Cells["itemv1"].Value;
                dtVehiculo.Rows.Find(id).Delete();
                dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
            }
        }

        private void btn_eliminar3_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE REGISTRO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                object[] id = new object[2];
                id[0] = dgw0.CurrentRow.Cells["codtc"].Value;
                id[1] = dgw0.CurrentRow.Cells["itemc1"].Value;
                dtConductor.Rows.Find(id).Delete();
                dgw0.Rows.RemoveAt(dgw0.CurrentRow.Index);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            eliminaFalseDT();
            TabControl1.SelectedTab = TabPage1;
            //boton = string.Empty;
            btn_nuevo.Select();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
            btn_nuevo2.Select();
        }
        private void eliminaFalseDT()
        {
            for (int i = dtVehiculo.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dtVehiculo.Rows[i]["st"]) == false)
                    dtVehiculo.Rows[i].Delete();
            }
            //
            for (int i = dtConductor.Rows.Count - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dtConductor.Rows[i]["st"]) == false)
                    dtConductor.Rows[i].Delete();
            }
            //
            cargaDGVehiculo();
            cargaDGConductor();
        }
        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            Panel_c1.Visible = false;
            Panel_c0.Visible = true;
            btn_nuevo3.Select();
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_ruc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Ruc !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ruc.Focus();
                return result = false;
            }
            if (txt_desc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (txt_dir.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Direccion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_dir.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                traTo.COD_TRANSPORTISTA = txt_cod.Text;
                if (traBLL.verificaTransportistaBLL(traTo) > 0)
                {
                    MessageBox.Show("El codigo ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO TRANSPORTISTA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                adicionDTTransportista();
                if (!traBLL.adicionaInsertaTransportistaBLL(dtTransportista, dtConductor, dtVehiculo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL TRANSPORTISTA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    string marv = dgw.CurrentRow == null ? "" : dgw[1, dgw.CurrentRow.Index].Value.ToString();
                    string nplav = dgw.CurrentRow == null ? "" : dgw[2, dgw.CurrentRow.Index].Value.ToString();
                    string tipv = dgw.CurrentRow == null ? "" : dgw[3, dgw.CurrentRow.Index].Value.ToString();
                    string certv = dgw.CurrentRow == null ? "" : dgw[4, dgw.CurrentRow.Index].Value.ToString();
                    string nomc = dgw0.CurrentRow == null ? "" : dgw0[1, dgw0.CurrentRow.Index].Value.ToString();
                    string dirc = dgw0.CurrentRow == null ? "" : dgw0[2, dgw0.CurrentRow.Index].Value.ToString();
                    string nlicc = dgw0.CurrentRow == null ? "" : dgw0[3, dgw0.CurrentRow.Index].Value.ToString();
                    string ndocc = dgw0.CurrentRow == null ? "" : dgw0[4, dgw0.CurrentRow.Index].Value.ToString();

                    PoneTrueaDTS();//pone True a todos los registros que tenian false, o sea que se confirma que se acepta los registros adicionados
                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, txt_ruc.Text, txt_dir.Text, marv, nplav, tipv,
                    certv, nomc, dirc, nlicc, ndocc);
                    LIMPIAR_CABECERA();
                    LIMPIAR_detalle();
                    LIMPIAR_detalle0();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }
        private bool validaGuardarVehiculo()
        {
            bool result = true;
            if (txt_marca.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la marcha del vehiculo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_marca.Focus();
                return result = false;
            }
            if (txt_nro_placa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la placa del vehiculo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_placa.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarVehiculo())
                return;
            DataRow[] rs = null; string m = ""; string cad;
            if (dgw.Rows.Count > 0)
            {
                cad = @"COD_TRANSPORTISTA LIKE '" + txt_cod.Text.Trim() + "%'";
                rs = dtVehiculo.Select(cad);
                foreach (DataRow r in rs)
                    m = r[1].ToString();
            }
            string itex = dgw.Rows.Count == 0 ? "01" : obtieneItem(Convert.ToInt32(m));//crea el item
            //adiciona al datatable Vehiculo
            adicionaDTVehiculo(itex);
            //adiciona al grid Vehiculo
            adicionaDGVehiculo(itex);
            LIMPIAR_detalle();
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
            btn_nuevo2.Select();
        }
        private void adicionDTTransportista()
        {
            DataRow rw = dtTransportista.NewRow();
            //rw["COD_TRANSPORTISTA"] = boton == "DETALLES1" ? txt_cod.Text : dgw1.CurrentRow.Cells["codt"].Value.ToString();//boton Nuevo se convierte en DETALLES1
            rw["COD_TRANSPORTISTA"] = txt_cod.Text;
            rw["NOMBRE"] = txt_desc.Text;
            rw["DIRECCION"] = txt_dir.Text;
            rw["RUC"] = txt_ruc.Text;

            dtTransportista.Rows.Add(rw);
        }
        private void adicionaDTVehiculo(string id)
        {
            DataRow rw = dtVehiculo.NewRow();
            rw["COD_TRANSPORTISTA"] = boton == "DETALLES1" ? txt_cod.Text : dgw1.CurrentRow.Cells["codt"].Value.ToString();//boton Nuevo se convierte en DETALLES1
            rw["ITEM"] = id;
            rw["MARCA"] = txt_marca.Text;
            rw["NRO_PLACA"] = txt_nro_placa.Text;
            rw["COD_TIPO"] = cbo_tipo.SelectedValue.ToString();
            rw["CER_INS"] = txt_cert_ins.Text;
            rw["st"] = false;
            dtVehiculo.Rows.Add(rw);
        }
        private void adicionaDGVehiculo(string id)
        {
            int rowId = dgw.Rows.Add();
            DataGridViewRow row = dgw.Rows[rowId];
            row.Cells["codtv"].Value = boton == "DETALLES1" ? txt_cod.Text : dgw1.CurrentRow.Cells["codt"].Value.ToString();
            row.Cells["itemv1"].Value = id;
            row.Cells["marv1"].Value = txt_marca.Text;
            row.Cells["nplav1"].Value = txt_nro_placa.Text;
            row.Cells["tipv1"].Value = cbo_tipo.SelectedValue.ToString();
            row.Cells["certv1"].Value = txt_cert_ins.Text;
        }
        private bool validaGuardarConductores()
        {
            bool result = true;
            if (txt_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del conductor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_conductor.Focus();
                return result = false;
            }
            if (txt_direccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Direccion del conductor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_direccion.Focus();
                return result = false;
            }
            if (txt_nro_licencia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro de licencia del conductor !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_licencia.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar3_Click(object sender, EventArgs e)
        {
            if (!validaGuardarConductores())
                return;
            DataRow[] rs = null; string m = ""; string cad;
            if (dgw.Rows.Count > 0)
            {
                cad = @"COD_TRANSPORTISTA LIKE '" + txt_cod.Text.Trim() + "%'";
                rs = dtConductor.Select(cad);
                foreach (DataRow r in rs)
                    m = r[1].ToString();
            }
            string itex = dgw0.Rows.Count == 0 ? "01" : obtieneItem(Convert.ToInt32(m));//crea el item
            //adiciona al datatable Conductor
            adicionaDataTableConductor(itex);
            //adiciona al grid Conductor
            adicionaDGConductor(itex);
            LIMPIAR_detalle0();
            Panel_c1.Visible = false;
            Panel_c0.Visible = true;
            btn_nuevo3.Select();
        }
        private string obtieneItem(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private string obtieneCodigo(int it)
        {
            //int it = Convert.ToInt32(dgw0.Rows[dgw0.Rows.Count].Cells["codtc"].Value);
            string ite = (it + 1).ToString();
            return ite.PadLeft(5, '0');
        }
        private void adicionaDataTableConductor(string id)
        {
            DataRow rw = dtConductor.NewRow();
            rw["COD_TRANSPORTISTA"] = boton == "DETALLES1" ? txt_cod.Text : dgw1.CurrentRow.Cells["codt"].Value.ToString();//boton Nuevo se convierte en DETALLES1
            rw["ITEM"] = id;
            rw["NOMBRE_CONDUCTOR"] = txt_conductor.Text;
            rw["DIRECCION"] = txt_direccion.Text;
            rw["NRO_LICENCIA"] = txt_nro_licencia.Text;
            rw["NRO_DOCUMENTO"] = txt_nro_documento.Text;
            rw["st"] = false;
            dtConductor.Rows.Add(rw);
        }
        private void adicionaDGConductor(string id)
        {
            int rowId = dgw0.Rows.Add();
            DataGridViewRow row = dgw0.Rows[rowId];
            row.Cells["codtc"].Value = boton == "DETALLES1" ? txt_cod.Text : dgw1.CurrentRow.Cells["codt"].Value.ToString();
            row.Cells["itemc1"].Value = id;
            row.Cells["nomc1"].Value = txt_conductor.Text;
            row.Cells["dirc1"].Value = txt_direccion.Text;
            row.Cells["nlicc1"].Value = txt_nro_licencia.Text;
            row.Cells["ndocc1"].Value = txt_nro_documento.Text;
        }
        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL TRANSPORTISTA ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                modificaDTTransportista();
                if (!traBLL.adicionaInsertaTransportistaBLL(dtTransportista, dtConductor, dtVehiculo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL TRANSPORTISTA !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    string marv = dgw.CurrentRow == null ? "" : dgw[1, dgw.CurrentRow.Index].Value.ToString();
                    string nplav = dgw.CurrentRow == null ? "" : dgw[2, dgw.CurrentRow.Index].Value.ToString();
                    string tipv = dgw.CurrentRow == null ? "" : dgw[3, dgw.CurrentRow.Index].Value.ToString();
                    string certv = dgw.CurrentRow == null ? "" : dgw[4, dgw.CurrentRow.Index].Value.ToString();
                    string nomc = dgw0.CurrentRow == null ? "" : dgw0[1, dgw0.CurrentRow.Index].Value.ToString();
                    string dirc = dgw0.CurrentRow == null ? "" : dgw0[2, dgw0.CurrentRow.Index].Value.ToString();
                    string nlicc = dgw0.CurrentRow == null ? "" : dgw0[3, dgw0.CurrentRow.Index].Value.ToString();
                    string ndocc = dgw0.CurrentRow == null ? "" : dgw0[4, dgw0.CurrentRow.Index].Value.ToString();

                    dgw1.CurrentRow.Cells["codt"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["nomt"].Value = txt_desc.Text;
                    dgw1.CurrentRow.Cells["ruct"].Value = txt_ruc.Text;
                    dgw1.CurrentRow.Cells["dirt"].Value = txt_dir.Text;
                    dgw1.CurrentRow.Cells["marv"].Value = marv;
                    dgw1.CurrentRow.Cells["nplav"].Value = nplav;
                    dgw1.CurrentRow.Cells["tipv"].Value = tipv;
                    dgw1.CurrentRow.Cells["certv"].Value = certv;
                    dgw1.CurrentRow.Cells["nomc"].Value = nomc;
                    dgw1.CurrentRow.Cells["dirc"].Value = dirc;
                    dgw1.CurrentRow.Cells["nlicc"].Value = nlicc;
                    dgw1.CurrentRow.Cells["ndocc"].Value = ndocc;

                    PoneTrueaDTS();//pone True a todos los registros que tenian false, o sea que se confirma que se acepta los registros modificados
                    LIMPIAR_CABECERA();
                    LIMPIAR_detalle();
                    LIMPIAR_detalle0();
                    TabControl1.SelectedTab = TabPage1;
                    boton = string.Empty;
                    btn_nuevo.Select();
                }
            }
        }
        private void PoneTrueaDTS()
        {
            //para DTVehiculo
            foreach (DataRow rw in dtVehiculo.Rows) rw["st"] = true;
            //para DTConductor 
            foreach (DataRow rw in dtConductor.Rows) rw["st"] = true;
        }
        private void modificaDTTransportista()
        {
            int id = dgw1.CurrentRow.Index;
            DataRow rw = dtTransportista.Rows[id];
            rw["NOMBRE"] = txt_desc.Text;
            rw["DIRECCION"] = txt_dir.Text;
            rw["RUC"] = txt_ruc.Text;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            modificaDTVehiculo();
            modificaDGVehiculo();
            LIMPIAR_detalle();
            Panel_v1.Visible = false;
            Panel_v0.Visible = true;
            btn_nuevo2.Select();
        }
        private void modificaDTVehiculo()
        {
            object[] id = new object[2];
            id[0] = dgw.CurrentRow.Cells["codtv"].Value;
            id[1] = dgw.CurrentRow.Cells["itemv1"].Value;
            DataRow rw = dtVehiculo.Rows.Find(id);
            rw["MARCA"] = txt_marca.Text;
            rw["NRO_PLACA"] = txt_nro_placa.Text;
            rw["COD_TIPO"] = cbo_tipo.SelectedValue.ToString();
            rw["CER_INS"] = txt_cert_ins.Text;
            rw["st"] = false;
        }
        private void modificaDGVehiculo()
        {
            dgw.CurrentRow.Cells["marv1"].Value = txt_marca.Text;
            dgw.CurrentRow.Cells["nplav1"].Value = txt_nro_placa.Text;
            dgw.CurrentRow.Cells["tipv1"].Value = cbo_tipo.SelectedValue.ToString();
            dgw.CurrentRow.Cells["certv1"].Value = txt_cert_ins.Text;
        }
        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            modificaDtConductor();//modifica DataTable CONDUCTOR
            modificaDGCondutor();//modifica datagrid CONDUCTOR
            LIMPIAR_detalle0();
            Panel_c1.Visible = false;
            Panel_c0.Visible = true;
            btn_nuevo3.Select();
        }
        private void modificaDtConductor()
        {
            //int id = dgw0.CurrentRow.Cells["codt"].RowIndex;
            object[] id = new object[2];
            id[0] = dgw0.CurrentRow.Cells["codtc"].Value;
            id[1] = dgw0.CurrentRow.Cells["itemc1"].Value;
            DataRow rw = dtConductor.Rows.Find(id);
            rw["NOMBRE_CONDUCTOR"] = txt_conductor.Text;
            rw["DIRECCION"] = txt_direccion.Text;
            rw["NRO_LICENCIA"] = txt_nro_licencia.Text;
            rw["NRO_DOCUMENTO"] = txt_nro_documento.Text;
        }
        private void modificaDGCondutor()
        {
            dgw0.CurrentRow.Cells["nomc1"].Value = txt_conductor.Text;
            dgw0.CurrentRow.Cells["dirc1"].Value = txt_direccion.Text;
            dgw0.CurrentRow.Cells["nlicc1"].Value = txt_nro_licencia.Text;
            dgw0.CurrentRow.Cells["ndocc1"].Value = txt_nro_documento.Text;
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                eliminaFalseDT();
                if (boton == "NUEVO")
                {
                    boton = "DETALLES1";
                    dgw.Rows.Clear();
                    dgw0.Rows.Clear();
                }
                else if (boton == "MODIFICAR")
                {
                    boton = "DETALLES2";
                }
                else
                {

                    boton = "DETALLES";
                    if (dgw1.Rows.Count == 0)
                    { }
                    else
                    {
                        LIMPIAR_CABECERA();
                        CARGAR_CABECERA();
                        LIMPIAR_detalle();
                        LIMPIAR_detalle0();
                        cargaDGVehiculo();
                        cargaDGConductor();

                        btn_guardar.Visible = false;
                        btn_mod.Visible = false;
                        txt_cod.ReadOnly = true;
                        txt_desc.ReadOnly = true;
                        txt_dir.ReadOnly = true;
                        txt_ruc.ReadOnly = true;
                    }
                }
            }
            else
            {
                btn_nuevo.Select();

            }
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            break;
                        }
                    }
                }
            }
            else if (ch_ruc.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[2, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[2];
                            break;
                        }
                    }
                }
            }
        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                dgw1.Sort(dgw1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw1.Sort(dgw1.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ruc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ruc.Checked)
            {
                dgw1.Sort(dgw1.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ca_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca.Checked)
            {
                btn_buscar.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
