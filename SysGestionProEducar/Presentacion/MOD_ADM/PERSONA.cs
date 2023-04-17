using BLL;
using Entidades;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PERSONA : Form
    {
        string BOTON; DataTable dtP, dtF;
        personaSustitutoBLL pesBLL = new personaSustitutoBLL();
        personaSustitutoTo pesTo = new personaSustitutoTo();
        personaMaestroBLL pemBLL = new personaMaestroBLL();
        personaMaestroTo pemTo = new personaMaestroTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        multiUsoBLL mulBLL = new multiUsoBLL();
        multiUsoTo mulTo = new multiUsoTo();
        DataTable dtInstitucion, dtInstitucion2;
        int form; string cod_per;
        int fila;
        DataTable dtContactos, dtTelefono, dtDirec, dtClsePer, dtBeneficiario, dtWebUsu;
        public PERSONA(int form, string cod_per)
        {
            InitializeComponent();
            this.form = form;
            this.cod_per = cod_per;
        }

        private void PERSONA_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtP = pemBLL.obtenerMaestroPersonaBLL();
            //dgw.DataSource = dtP;
            cargaDataGrid();
            cargaTipoDoc();
            cargaTipoPer();
            //cargaCodIdentidad();
            //cargaCodProceso();
            //detalles
            cargaTipoFono();
            cargaPais();
            cargaTipoDir();
            cargaClase();
            cargaCategoria();
            cargaFormaPago();
            cargaCondicionVenta();
            cargaInstituciones();
            cargaCargosClientes();
            cargaTiposVivienda();
            cargaCondicion();
            cargaSituacion();
            cargaCategoriaFiltro();
            cargaClaseFiltro();
            btn_guardar.DialogResult = DialogResult.None;
            if (form == 1)
            {
                btn_nuevo_Click(sender, e);
                //se quiere que al comienzo ya tenga un registro hecho por defecto
                DGW4.Rows.Add("2", "POR COBRAR", "1", "COMERCIAL", "0.00",
                "03", "CREDITO", "01", "LETRA A 30 DIAS", "30");
            }
            //esto es para cuando se necesite de ver la informacion desde llamadas descuento directa
            else if (form == 2)
            {
                ch_cod.Checked = true;
                txt_letra.Text = cod_per;
                btn_modificar_Click(sender, e);
                btn_guardar.Visible = false;
                btn_modificar2.Visible = false;
            }
            else
                btn_nuevo.Select();
        }
        private void cargaSituacion()
        {
            //mulTo.COD_GRUPO = "06";//SITUACION
            //DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            //cbo_codsit.ValueMember = "COD_SUBGRUPO";
            //cbo_codsit.DisplayMember = "DES_SUBGRUPO";
            //cbo_codsit.DataSource = dt;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TSITP";//TABLA DE SITUACION DE CLIENTES
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Codigo"] = "";
            rw["Descripción"] = "";
            dt.Rows.InsertAt(rw, 0);
            cbo_codsit.ValueMember = "Codigo";
            cbo_codsit.DisplayMember = "Descripción";
            cbo_codsit.DataSource = dt;
        }
        private void cargaCondicion()
        {
            //mulTo.COD_GRUPO = "05";//CONDICION - ESTRUCTURA
            //DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            //cbocodcon.ValueMember = "COD_SUBGRUPO";
            //cbocodcon.DisplayMember = "DES_SUBGRUPO";
            //cbocodcon.DataSource = dt;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TCONP";//TABLA DE SITUACION DE CLIENTES
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Codigo"] = "";
            rw["Descripción"] = "";
            dt.Rows.InsertAt(rw, 0);
            cbocodcon.ValueMember = "Codigo";
            cbocodcon.DisplayMember = "Descripción";
            cbocodcon.DataSource = dt;
        }
        private void cargaTiposVivienda()
        {
            //mulTo.COD_GRUPO = "01";//TIPO VIVIENDA
            //DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            //cbo_tipvivienda.ValueMember = "COD_SUBGRUPO";
            //cbo_tipvivienda.DisplayMember = "DES_SUBGRUPO";
            //cbo_tipvivienda.DataSource = dt;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TVIVP";//TABLA DE SITUACION DE CLIENTES
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Codigo"] = "";
            rw["Descripción"] = "";
            dt.Rows.InsertAt(rw, 0);
            cbo_tipvivienda.ValueMember = "Codigo";
            cbo_tipvivienda.DisplayMember = "Descripción";
            cbo_tipvivienda.DataSource = dt;
        }
        private void cargaCargosClientes()
        {
            //mulTo.COD_GRUPO = "02";//CARGOS CLIENTE
            //DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            //cbo_cargocliente.ValueMember = "COD_SUBGRUPO";
            //cbo_cargocliente.DisplayMember = "DES_SUBGRUPO";
            //cbo_cargocliente.DataSource = dt;

            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TCARC";//TABLA DE CARGOS DE CLIENTES
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            DataRow rw = dt.NewRow();
            rw["Codigo"] = "";
            rw["Descripción"] = "";
            dt.Rows.InsertAt(rw, 0);
            cbo_cargocliente.ValueMember = "Codigo";
            cbo_cargocliente.DisplayMember = "Descripción";
            cbo_cargocliente.DataSource = dt;
        }
        private void cargaInstituciones()
        {
            institucionesBLL insBLL = new institucionesBLL();
            dtInstitucion = insBLL.obtenerInstitucionesBLL();
            //dtInstitucion2 = insBLL.obtenerInstitucionesBLL();
            DataRow rw = dtInstitucion.NewRow();
            rw["COD_INST"] = "0";
            rw["DESC_INST"] = "";
            dtInstitucion.Rows.InsertAt(rw, 0);
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dtInstitucion;
        }
        private void cargaCondicionVenta()
        {
            DataTable dt = helBLL.obtenerCondicionVentaBLL();
            cbo_VENTA.ValueMember = "COD_TIPO";
            cbo_VENTA.DisplayMember = "DESC_TIPO";
            cbo_VENTA.DataSource = dt;
            cbo_VENTA.SelectedIndex = -1;
        }
        private void cargaFormaPago()
        {
            DataTable dt = helBLL.obtenerFormaPagoBLL();
            CBO_PAGO.ValueMember = "COD_TIPO";
            CBO_PAGO.DisplayMember = "DESC_TIPO";
            CBO_PAGO.DataSource = dt;
            CBO_PAGO.SelectedIndex = -1;
        }
        private void cargaCategoria()
        {
            DataTable dt = helBLL.obtenerCategoriaBLL();
            cbo_cat.ValueMember = "COD_CAT";
            cbo_cat.DisplayMember = "DESC_CAT";
            cbo_cat.DataSource = dt;
            cbo_cat.SelectedIndex = -1;
        }
        private void cargaCategoriaFiltro()
        {
            DataTable dt = helBLL.obtenerCategoriaBLL();
            cboCategorias.ValueMember = "COD_CAT";
            cboCategorias.DisplayMember = "DESC_CAT";
            cboCategorias.DataSource = dt;
            cboCategorias.SelectedIndex = -1;
        }
        private void cargaClase()
        {
            DataTable dt = helBLL.obtenerClaseBLL();
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = -1;
        }
        private void cargaClaseFiltro()
        {
            DataTable dt = helBLL.obtenerClaseBLL();
            cboClase.ValueMember = "COD_CLASE";
            cboClase.DisplayMember = "DESC_CLASE";
            cboClase.DataSource = dt;
            cboClase.SelectedIndex = -1;
        }
        private void cargaTipoDir()
        {
            DataTable dt = helBLL.obtenerTIpo_DirBLL();
            cbo_tipo_dir.ValueMember = "COD_TIPO";
            cbo_tipo_dir.DisplayMember = "DESC_TIPO";
            cbo_tipo_dir.DataSource = dt;
            cbo_tipo_dir.SelectedIndex = -1;
            if (form == 1)
                cbo_tipo_dir.SelectedIndex = 2;//cobrannza
        }
        private void cargaPais()
        {
            DataTable dt = helBLL.obtenerPaisBLL();
            cbo_pais.ValueMember = "COD_PAIS";
            cbo_pais.DisplayMember = "DESC_PAIS";
            cbo_pais.DataSource = dt;
        }
        private void cargaTipoFono()
        {

            DataTable dt = helBLL.obtenerTipo_FonoBLL();
            cbo_tipo_fono.ValueMember = "COD_TIPO";
            cbo_tipo_fono.DisplayMember = "DESC_TIPO";
            cbo_tipo_fono.DataSource = dt;
        }
        private void cargaCodIdentidad()
        {

            mulTo.COD_GRUPO = "03";//IDENTIDAD
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cboidentidad.ValueMember = "COD_SUBGRUPO";
            cboidentidad.DisplayMember = "DES_SUBGRUPO";
            cboidentidad.DataSource = dt;
        }
        private void cargaCodProceso()
        {
            mulTo.COD_GRUPO = "04";//PROCESO
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cboproceso.ValueMember = "COD_SUBGRUPO";
            cboproceso.DisplayMember = "DES_SUBGRUPO";
            cboproceso.DataSource = dt;
        }
        private void cargaTipoDoc()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerTipo_Doc_PersonalBLL();
            cbo_tipo_doc.ValueMember = "COD_TIPO";
            cbo_tipo_doc.DisplayMember = "DESC_TIPO";
            cbo_tipo_doc.DataSource = dt;
            cbo_tipo_doc.SelectedIndex = 2;
        }
        public void cargaTipoPer()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerTipo_PersonaBLL();
            cbo_tipo.ValueMember = "cod";
            cbo_tipo.DisplayMember = "des";
            cbo_tipo.DataSource = dt;
            cbo_tipo.SelectedIndex = 0;
        }
        private void cargaDataGrid()
        {
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            if (dtP.Rows.Count > 0)
            {
                lbl_nro_reg_docs.Text = "Nro de Registros : " + dtP.Rows.Count.ToString();
                dgw.Rows.Clear();
                foreach (DataRow rw in dtP.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells["cod"].Value = rw["Codigo"].ToString();
                    row.Cells["razs"].Value = rw["Razon Social"].ToString();
                    row.Cells["nrodoc"].Value = rw["Nroº Doc."].ToString();
                    row.Cells["DESC_CAT"].Value = rw["DESC_CAT"].ToString();
                    row.Cells["nomcom"].Value = rw["Nom. Comercial"].ToString();
                    row.Cells["codtipper"].Value = rw["COD_TIPO_PER"].ToString();
                    row.Cells["tipper"].Value = rw["TIPO_PER"].ToString();
                    row.Cells["codtipdoc"].Value = rw["COD_TIPO_DOC"].ToString();
                    row.Cells["tipdoc"].Value = rw["COD_TIPO_DOC"].ToString();
                    row.Cells["nom"].Value = rw["NOMBRE"].ToString();
                    row.Cells["app"].Value = rw["PATERNO"].ToString();
                    row.Cells["apm"].Value = rw["MATERNO"].ToString();
                    row.Cells["email"].Value = rw["MAIL"].ToString();
                    row.Cells["codid"].Value = rw["COD_IDENTIDAD"].ToString();
                    row.Cells["desid"].Value = rw["DES_IDENTIDAD"].ToString();
                    row.Cells["codpro"].Value = rw["COD_PROCESO"].ToString();//
                    row.Cells["despro"].Value = rw["DES_PROCESO"].ToString();
                    row.Cells["codsit"].Value = rw["COD_SITUACION"].ToString();
                    row.Cells["codins"].Value = rw["COD_INSTITUCION"].ToString();
                    row.Cells["codcar"].Value = rw["COD_CARGO"].ToString();
                    row.Cells["codviv"].Value = rw["COD_VIVIENDA"].ToString();
                    row.Cells["codcon"].Value = rw["COD_CONDICION"].ToString();
                    row.Cells["codus"].Value = rw["COD_USUARIO"].ToString();
                    row.Cells["pwdus"].Value = rw["PWD_USUARIO"].ToString();
                    row.Cells["imagen"].Value = rw["IMAGEN"].ToString();
                    row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                    row.Cells["COD_CAT"].Value = rw["COD_CAT"].ToString();
                    row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                    row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString();
                    row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                    row.Cells["NRO_BENEFICIARIOS"].Value = rw["NRO_BENEFICIARIOS"].ToString();
                }
            }
        }
        private void PERSONA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_CABECERA()
        {
            if (dgw.Rows.Count > 0)
            {
                txt_cod.Text = dgw[0, dgw.CurrentRow.Index].Value.ToString();
                txt_desc.Text = dgw[1, dgw.CurrentRow.Index].Value.ToString();
                txt_nro_doc.Text = dgw[2, dgw.CurrentRow.Index].Value.ToString();
                txt_nc.Text = dgw[4, dgw.CurrentRow.Index].Value.ToString();
                cbo_tipo.SelectedValue = dgw[5, dgw.CurrentRow.Index].Value;
                //cbo_tipo_doc.SelectedValue = dgw[7, dgw.CurrentRow.Index].Value;
                cbo_tipo_doc.SelectedValue = dgw.CurrentRow.Cells["tipdoc"].Value;
                txt_nom.Text = dgw[9, dgw.CurrentRow.Index].Value.ToString();
                txt_pat.Text = dgw[10, dgw.CurrentRow.Index].Value.ToString();
                txt_mat.Text = dgw[11, dgw.CurrentRow.Index].Value.ToString();
                txt_mail.Text = dgw[12, dgw.CurrentRow.Index].Value.ToString();
                cboidentidad.SelectedValue = dgw[13, dgw.CurrentRow.Index].Value;
                txtcodid.Text = dgw[14, dgw.CurrentRow.Index].Value.ToString();
                cboproceso.SelectedValue = dgw[15, dgw.CurrentRow.Index].Value;
                txtcodproc.Text = dgw[16, dgw.CurrentRow.Index].Value.ToString();
                cbo_codsit.SelectedValue = dgw[17, dgw.CurrentRow.Index].Value;
                cbo_institucion.SelectedValue = dgw[18, dgw.CurrentRow.Index].Value;
                cbo_cargocliente.SelectedValue = dgw[19, dgw.CurrentRow.Index].Value;
                cbo_tipvivienda.SelectedValue = dgw[20, dgw.CurrentRow.Index].Value;
                cbocodcon.SelectedValue = dgw[21, dgw.CurrentRow.Index].Value;
                //txt_usuario.Text = dgw[21, dgw.CurrentRow.Index].Value.ToString();
                //txt_pwd.Text = dgw[22, dgw.CurrentRow.Index].Value.ToString();
                txt_img.Text = dgw[24, dgw.CurrentRow.Index].Value.ToString();
                txt_nro_beneficiaros.Text = dgw.CurrentRow.Cells["NRO_BENEFICIARIOS"].Value.ToString();
            }

        }
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();
            if (form != 1)
            {
                txt_nom.Clear();//
                txt_pat.Clear();//
                txt_mat.Clear();//
                txt_nro_doc.Clear();//

                cboidentidad.SelectedIndex = -1;//
                cboproceso.SelectedIndex = -1;//
                cbo_institucion.SelectedIndex = -1;//

                txtcodid.Clear();//
                txtcodproc.Clear();//

                DGW4.Rows.Clear();//
            }
            txt_mail.Clear();
            //txt_nro_beneficiaros.Clear();
            txt_nro_beneficiaros.Text = "0";
            cbo_codsit.SelectedIndex = -1;
            cbo_cargocliente.SelectedIndex = -1;
            cbo_tipvivienda.SelectedIndex = -1;
            cbocodcon.SelectedIndex = -1;
            //txt_usuario.Clear();
            //txt_pwd.Clear();
            txt_nc.Clear();
            txt_dni_sus.Clear();
            txt_nom_sus.Clear();
            txt_dir_sus.Clear();
            txt_email_sus.Clear();
            txt_obs_sus.Clear();
            txt_tel_sus.Clear();
            txt_img.Clear();

            //HABILITAS
            txt_cod.ReadOnly = true;
            txt_desc.ReadOnly = false;
            txt_nom.ReadOnly = false;
            txt_pat.ReadOnly = false;
            txt_mat.ReadOnly = false;
            txt_nro_doc.ReadOnly = false;
            txt_mail.ReadOnly = false;
            txt_nro_beneficiaros.ReadOnly = false;
            txt_nc.ReadOnly = false;
            cbo_tipo_doc.Enabled = true;
            cbo_tipo.Enabled = true;
            btnConsultaSunat.Enabled = true;
            //LIMPIAR LOS DGW
            dgw1.Rows.Clear();
            DGW2.Rows.Clear();
            DGW3.Rows.Clear();
            //DGW4.Rows.Clear();//
            DGW5.Rows.Clear();//Beneficiarios
            //'PANELES
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            panel_be.Visible = false;
        }

        private void cbo_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_tipo.SelectedIndex > -1)
            {
                switch (cbo_tipo.SelectedIndex)
                {
                    case 0:
                        {
                            txt_nom.Enabled = true;
                            txt_pat.Enabled = true;
                            txt_mat.Enabled = true;
                            txt_desc.Enabled = false;
                            break;
                        }
                    case 1:
                        {
                            txt_nom.Enabled = false;
                            txt_pat.Enabled = false;
                            txt_mat.Enabled = false;
                            txt_desc.Enabled = true;
                            break;
                        }
                    case 2:
                        {
                            txt_nom.Enabled = false;
                            txt_pat.Enabled = false;
                            txt_mat.Enabled = false;
                            txt_desc.Enabled = true;
                            break;
                        }
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            cbo_pais.SelectedValue = "9589";
            TabControl1.SelectedTab = TabPage2;
            //txt_cod.Text = "";// 
            txt_cod.Text = dgw.Rows.Count == 0 ? "00001" : obtieneCodigo(Convert.ToInt32(dgw.Rows[dgw.Rows.Count - 1].Cells["cod"].Value));
            txt_cod.Focus();
        }
        private string obtieneCodigo(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(5, '0');
        }
        private DataTable obtieneDT(DataGridView DGW)
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            string errMensaje = "";
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (cbo_tipo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el tipo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo.Focus();
                return result = false;
            }
            if (cbo_tipo_doc.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el tipo de documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                return result = false;
            }
            if (cbo_tipo.Text == "NATURAL")
            {
                if (txt_nom.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Nombre !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nom.Focus();
                    return result = false;
                }
                if (txt_pat.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Apellido Paterno !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_pat.Focus();
                    return result = false;
                }
                if (txt_mat.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Apellido Materno !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_mat.Focus();
                    return result = false;
                }
            }
            else if (cbo_tipo.Text == "JURIDICA")
            {
                if (txt_nc.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el Nombre Comercial !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_nc.Focus();
                    return result = false;
                }
            }
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nro de documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_doc.Focus();
                return result = false;
            }
            else
            {
                if (btn_guardar.Visible)
                {
                    bool val = false;
                    pemTo.NRO_DOC = txt_nro_doc.Text;
                    if (!pemBLL.verificaNroRucDniPersonaBLL(pemTo, ref val, ref errMensaje))
                    {
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return result = false;
                    }
                    else
                    {
                        if (val)
                        {
                            MessageBox.Show("Documento Dni ó Ruc ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_nro_doc.Focus();
                            return result = false;
                        }
                    }
                }
            }
            if (DGW4.Rows.Count > 0)
            {
                if (DGW4.Rows[0].Cells["codclase"].Value.ToString() == "2" && DGW4.Rows[0].Cells["codcat"].Value.ToString() == "1" && cbo_institucion.SelectedIndex <= 0)
                {
                    MessageBox.Show("Ingrese la Institución !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_institucion.Focus();
                    return result = false;
                }
            }

            if (cbo_institucion.SelectedIndex > 0)
            {
                if (txtcodid.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el codigo identidad !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcodid.Focus();
                    return result = false;
                }
                //if (txtcodproc.Text.Trim() == "")
                //{
                //    MessageBox.Show("Ingrese el codigo proceso !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    txtcodproc.Focus();
                //    return result = false;
                //}
                if (btn_guardar.Visible)
                {
                    pemTo.COD_IDENTIDAD = txtcodid.Text;
                    if (pemBLL.verificaCodigoIdentidadBLL(pemTo, ref errMensaje))
                    {
                        MessageBox.Show("El codigo de la institucion ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtcodid.Focus();
                        return result = false;
                    }
                    else
                    {
                        if (errMensaje != "")
                            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            if (cbo_tipo_doc.SelectedIndex > 0)
            {
                if (cbo_tipo_doc.SelectedValue != null)
                {
                    if (cbo_tipo_doc.SelectedValue.ToString() == "01" && !(txt_nro_doc.Text.Trim().Length == 8))//o sea si es dni
                    {
                        MessageBox.Show("DNI debe tener 8 dígitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_nro_doc.Focus();
                        return result = false;
                    }
                    else if (cbo_tipo_doc.SelectedValue.ToString() == "06" && !(txt_nro_doc.Text.Trim().Length == 11))//o sea si es ruc
                    {
                        MessageBox.Show("RUC debe tener 11 dígitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_nro_doc.Focus();
                        return result = false;
                    }
                }
            }
            if (DGW4.Rows.Count <= 0)
            {
                MessageBox.Show("Ingrese algun registro en Clase Persona !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TabControl2.SelectedTab = TabPage6;
                return result = false;
            }
            int s = 0;
            if (!int.TryParse(txt_nro_beneficiaros.Text, out s))
            {
                MessageBox.Show("El nro ingresado no es válido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_beneficiaros.Focus();
                return result = false;
            }
            if (DGW5.Rows.Count > Convert.ToInt32(txt_nro_beneficiaros.Text))
            {
                MessageBox.Show("Se rebazó la cantidad máxima de beneficiarios permitidos !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool op = false;
            LBL.Text = "SI";
            if (!validaGuardarModificar())
            {
                if (form != 1)
                {
                    op = false;
                    return;
                }
                else if (form == 1)
                {
                    op = true;
                    LBL.Text = "NO";
                    DialogResult = DialogResult.None;
                }
            }
            if (op == false)
            {
                DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar a una nueva Persona ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    string errMensaje = string.Empty;
                    //
                    pemTo.COD_PER = txt_cod.Text;
                    pemTo.TIPO_PER = cbo_tipo.SelectedValue.ToString();
                    pemTo.COD_TIPO_DOC = cbo_tipo_doc.SelectedValue.ToString();
                    pemTo.NRO_DOC = txt_nro_doc.Text;
                    pemTo.DESC_PER = txt_desc.Text;
                    pemTo.NOMBRE = txt_nom.Text.Trim();
                    pemTo.PATERNO = txt_pat.Text.Trim();
                    pemTo.MATERNO = txt_mat.Text.Trim();
                    pemTo.NOM_COMERCIAL = txt_nc.Text;
                    pemTo.MAIL = txt_mail.Text;
                    pemTo.NRO_BENEFICIARIOS = Convert.ToInt32(txt_nro_beneficiaros.Text);
                    pemTo.NOM_AVAL = "";
                    pemTo.NRO_DOC_AVAL = "";
                    pemTo.DIR_AVAL = "";
                    pemTo.FONO_AVAL = "";
                    pemTo.ST_CONTRIBUYENTE = "0";
                    pemTo.ST_RETENEDOR = "0";
                    pemTo.ST_PERCEPTOR = "0";
                    pemTo.COD_INSTITUCION = cbo_institucion.SelectedValue == null ? "" : cbo_institucion.SelectedValue.ToString();
                    pemTo.COD_IDENTIDAD = cboidentidad.SelectedValue == null ? "" : cboidentidad.SelectedValue.ToString();
                    pemTo.DES_IDENTIDAD = txtcodid.Text;
                    pemTo.COD_PROCESO = cboproceso.SelectedValue == null ? "" : cboproceso.SelectedValue.ToString();
                    pemTo.DES_PROCESO = txtcodproc.Text;
                    pemTo.COD_SITUACION = cbo_codsit.SelectedValue == null ? "" : cbo_codsit.SelectedValue.ToString();
                    pemTo.COD_USUARIO = "";// txt_usuario.Text;
                    pemTo.PWD_USUARIO = "";// txt_pwd.Text;
                    pemTo.COD_CARGO = cbo_cargocliente.SelectedValue == null ? "" : cbo_cargocliente.SelectedValue.ToString();
                    pemTo.COD_VIVIENDA = cbo_tipvivienda.SelectedValue == null ? "" : cbo_tipvivienda.SelectedValue.ToString();
                    pemTo.COD_CONDICION = cbocodcon.SelectedValue == null ? "" : cbocodcon.SelectedValue.ToString();
                    pemTo.IMAGEN = txt_img.Text;
                    //
                    dtContactos = obtieneDT(dgw1);
                    dtTelefono = obtieneDT(DGW2);
                    dtDirec = obtieneDT(DGW3);
                    dtClsePer = obtieneDT(DGW4);
                    dtBeneficiario = obtieneDT(DGW5);
                    dtWebUsu = obtieneDT(dgw_usu_web);
                    //
                    pesTo.COD_PER = txt_cod.Text;
                    pesTo.DNI_SUS = txt_dni_sus.Text;
                    pesTo.NOMBRE_SUS = txt_nom_sus.Text;
                    pesTo.DIRECCION_SUS = txt_dir_sus.Text;
                    pesTo.EMAIL_SUS = txt_email_sus.Text;
                    pesTo.TELEFONO_SUS = txt_tel_sus.Text;
                    pesTo.OBS_SUS = txt_obs_sus.Text;
                    string cod_persona = "";
                    if (!pemBLL.adicionaNuevoMaestroPersonaBLL(pemTo, dtContactos, dtTelefono, dtDirec, dtClsePer, pesTo, dtBeneficiario, dtWebUsu, ref cod_persona, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (form == 1)
                        {
                            txt_cod.Text = cod_persona;
                            Properties.Settings.Default.PER = "1";
                            Properties.Settings.Default.Save();
                            DialogResult = DialogResult.OK;
                            Hide();
                            //return;
                        }
                        else
                        {
                            MessageBox.Show("Se adicionó correctamente a la Persona !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            string nomc, dni_c, telf_c, emailc, obsc; string tipot, nrot; string tipod, direcd, paisd;
                            string clasep, catep, lincrep, forpagp, convtap, ndiasp;
                            string codid, desid, codpro, despro;
                            string codsit, codins, codcar, codviv, codcon, codus, pwdus, imagen;
                            string nro_contrato, nomb, dnib, fecnacb, emailb, telconb, plzactb, nro_contrato_usu_web, usuarioWeb, passwordWeb;
                            string desc_inst, des_identidad, des_proceso;
                            if (dgw1.CurrentRow != null)
                            {
                                nomc = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
                                dni_c = dgw1.CurrentRow.Cells["dni_cc"].Value.ToString();
                                telf_c = dgw1.CurrentRow.Cells["telf_cc"].Value.ToString();
                                emailc = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
                                obsc = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();

                            }
                            else
                            {
                                nomc = "";
                                dni_c = "";
                                telf_c = "";
                                emailc = "";
                                obsc = "";

                            }
                            if (DGW2.CurrentRow != null)
                            {
                                tipot = DGW2[2, DGW2.CurrentRow.Index].Value.ToString();
                                nrot = DGW2[3, DGW2.CurrentRow.Index].Value.ToString();
                            }
                            else
                            {
                                tipot = "";
                                nrot = "";
                            }
                            if (DGW3.CurrentRow != null)
                            {
                                tipod = DGW3[1, DGW3.CurrentRow.Index].Value.ToString();
                                direcd = DGW3[2, DGW3.CurrentRow.Index].Value.ToString();
                                paisd = DGW3[5, DGW3.CurrentRow.Index].Value.ToString();
                            }
                            else
                            {
                                tipod = "";
                                direcd = "";
                                paisd = "";
                            }
                            if (DGW4.CurrentRow != null)
                            {
                                clasep = DGW4[1, DGW4.CurrentRow.Index].Value.ToString();
                                catep = DGW4[3, DGW4.CurrentRow.Index].Value.ToString();
                                lincrep = DGW4[4, DGW4.CurrentRow.Index].Value.ToString();
                                forpagp = DGW4[6, DGW4.CurrentRow.Index].Value.ToString();
                                convtap = DGW4[8, DGW4.CurrentRow.Index].Value.ToString();
                                ndiasp = DGW4[9, DGW4.CurrentRow.Index].Value.ToString();
                            }
                            else
                            {
                                clasep = "";
                                catep = "";
                                lincrep = "";
                                forpagp = "";
                                convtap = "";
                                ndiasp = "";
                            }
                            if (DGW5.CurrentRow != null)
                            {
                                nro_contrato = DGW5.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                                nomb = DGW5.CurrentRow.Cells["nom_ape_be"].Value.ToString();
                                dnib = DGW5.CurrentRow.Cells["dni_be"].Value.ToString();
                                fecnacb = DGW5.CurrentRow.Cells["fec_nac_be"].Value.ToString();
                                emailb = DGW5.CurrentRow.Cells["email_be"].Value.ToString();
                                telconb = DGW5.CurrentRow.Cells["telef_be"].Value.ToString();
                                plzactb = DGW5.CurrentRow.Cells["plz_act_be"].Value.ToString();
                            }
                            else
                            {
                                nro_contrato = ""; nomb = ""; dnib = ""; fecnacb = ""; emailb = ""; telconb = ""; plzactb = "";
                            }
                            if (dgw_usu_web.CurrentRow != null)
                            {
                                nro_contrato_usu_web = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_contrato"].Value);
                                usuarioWeb = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_usuario"].Value);
                                passwordWeb = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_password"].Value);
                            }
                            else
                            {
                                nro_contrato_usu_web = ""; usuarioWeb = ""; passwordWeb = "";
                            }
                            codid = cboidentidad.SelectedIndex == -1 ? "" : cboidentidad.SelectedValue.ToString();
                            desid = txtcodid.Text;
                            codpro = cboproceso.SelectedIndex == -1 ? "" : cboproceso.SelectedValue.ToString();
                            despro = txtcodproc.Text;
                            codsit = cbo_codsit.SelectedIndex == -1 ? "" : cbo_codsit.SelectedValue.ToString();
                            codins = cbo_institucion.SelectedIndex == -1 ? "" : cbo_institucion.SelectedValue.ToString();
                            codcar = cbo_cargocliente.SelectedIndex == -1 ? "" : cbo_cargocliente.SelectedValue.ToString();
                            codviv = cbo_tipvivienda.SelectedIndex == -1 ? "" : cbo_tipvivienda.SelectedValue.ToString();
                            codcon = cbocodcon.SelectedIndex == -1 ? "" : cbocodcon.SelectedValue.ToString();
                            codus = "";// txt_usuario.Text;
                            pwdus = "";// txt_pwd.Text;
                            imagen = txt_img.Text;
                            desc_inst = cbo_institucion.Text;
                            des_identidad = txtcodid.Text.Trim();
                            des_proceso = txtcodproc.Text.Trim();
                            txt_cod.Text = cod_persona;
                            dgw.Rows.Add(txt_cod.Text, txt_desc.Text, txt_nro_doc.Text, Convert.ToString(DGW4.Rows[0].Cells["catepp"].Value),
                                txt_nc.Text, cbo_tipo.SelectedValue.ToString(),
                                cbo_tipo.Text, cbo_tipo_doc.SelectedValue.ToString(), cbo_tipo_doc.Text, txt_nom.Text, txt_pat.Text,
                                txt_mat.Text, txt_mail.Text, codid, desid, codpro, despro, codsit, codins, codcar, codviv, codcon, codus, pwdus,
                                imagen, "", "", desc_inst, des_identidad, des_proceso, txt_nro_beneficiaros.Text);

                            //if (form == 1)//PARA QUE DESAPARESCA Y CONTINUE HACIENDO EL CONTRATO
                            //    this.Dispose();

                            TabControl1.SelectedTab = TabPage1;
                            FOCO_NUEVO_REG2(txt_cod.Text);
                            //btn_nuevo.Select();
                        }
                    }
                }
            }

        }
        private void FOCO_NUEVO_REG2(string cont2)
        {
            int i, cont = 0;
            cont = dgw.Columns.Count - 1;
            string nrocon = cont2;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw[0, i].Value.ToString().ToLower())
                {
                    dgw.CurrentCell = dgw.Rows[i].Cells[0];
                    return;
                }
            }
        }
        private void LIMPIAR_CONTACTO()
        {
            txt_desc_cont.Clear();
            txt_dni_cont.Clear();
            txt_telf_cont.Clear();
            txt_mail_cont.Clear();
            txt_obs_cont.Clear();
            txt_desc_cont.ReadOnly = false;
            txt_dni_cont.ReadOnly = false;
            txt_telf_cont.ReadOnly = false;
            txt_mail_cont.ReadOnly = false;
            txt_obs_cont.ReadOnly = false;
            chkCorreoElectronico.Checked = false;
        }

        private void CARGAR_CONTACTO()
        {
            if (dgw1.Rows.Count > 0)
            {
                txt_desc_cont.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
                txt_dni_cont.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                txt_telf_cont.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
                txt_mail_cont.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
                txt_obs_cont.Text = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
                chkCorreoElectronico.Checked = dgw1[6, dgw1.CurrentRow.Index].Value.ToString() == "1" ? true : false;
            }
        }

        private void btn_agregar1_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = true;
            btn_mod1.Visible = false;
            Panel1.Visible = true;
            LIMPIAR_CONTACTO();
            txt_desc_cont.Focus();
        }
        private bool validaGuardarModificarContacto()
        {
            bool result = true;
            if (txt_desc_cont.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del contacto", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc_cont.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarContacto())
                return;
            string status = chkCorreoElectronico.Checked ? "1" : "0";
            dgw1.Rows.Add(obtieneItem(dgw1.Rows.Count), txt_desc_cont.Text, txt_dni_cont.Text, txt_telf_cont.Text, txt_mail_cont.Text,
                txt_obs_cont.Text, status);
            Panel1.Visible = false;
            txt_mail.Focus();
        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = false;
            btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            txt_desc_cont.Focus();
        }

        private void btn_mod1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarContacto())
                return;
            int FILA = dgw1.CurrentRow.Index;
            dgw1[1, FILA].Value = txt_desc_cont.Text;
            dgw1[2, FILA].Value = txt_dni_cont.Text;
            dgw1[3, FILA].Value = txt_telf_cont.Text;
            dgw1[4, FILA].Value = txt_mail_cont.Text;
            dgw1[5, FILA].Value = txt_obs_cont.Text;
            dgw1[6, FILA].Value = chkCorreoElectronico.Checked ? "1" : "0";
            Panel1.Visible = false;
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
                dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
        }

        private void LIMPIAR_FONO()
        {
            cbo_tipo_fono.SelectedIndex = -1;
            txt_nro_fono.Clear();
            cbo_tipo_fono.Enabled = true;
            txt_nro_fono.ReadOnly = false;
        }

        private void btn_agregar2_Click(object sender, EventArgs e)
        {
            LIMPIAR_FONO();
            btn_guardar3.Visible = true;
            btn_mod2.Visible = false;
            Panel2.Visible = true;
            cbo_tipo_fono.Focus();
        }

        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }
        private void CARGAR_FONO()
        {
            if (DGW2.Rows.Count > 0)
            {
                cbo_tipo_fono.SelectedValue = DGW2[1, DGW2.CurrentRow.Index].Value;
                txt_nro_fono.Text = DGW2[3, DGW2.CurrentRow.Index].Value.ToString();
            }
        }
        private void CARGAR_BENEFICIARIO()
        {
            if (DGW5.Rows.Count > 0)
            {
                txt_contrato.Text = DGW5.CurrentRow.Cells["NRO_CONTRATO"].Value.ToString();
                txt_nom_ape_be.Text = DGW5.CurrentRow.Cells["nom_ape_be"].Value.ToString();
                txt_dni_be.Text = DGW5.CurrentRow.Cells["dni_be"].Value.ToString();
                dtp_fec_nac_be.Value = Convert.ToDateTime(DGW5.CurrentRow.Cells["fec_nac_be"].Value);
                txt_email_be.Text = DGW5.CurrentRow.Cells["email_be"].Value.ToString();
                txt_tel_be.Text = DGW5.CurrentRow.Cells["telef_be"].Value.ToString();
                txt_plazo_act_be.Text = DGW5.CurrentRow.Cells["plz_act_be"].Value.ToString();
            }
        }
        private bool validaGuardarModificarTelefono()
        {
            bool result = true;
            if (cbo_tipo_fono.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el tipo de telefono !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_fono.Focus();
                return result = false;
            }
            if (txt_nro_fono.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el numero de telefono !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_fono.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar3_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarTelefono())
                return;
            DGW2.Rows.Add(obtieneItem(DGW2.Rows.Count), cbo_tipo_fono.SelectedValue.ToString(), cbo_tipo_fono.Text, txt_nro_fono.Text);
            Panel2.Visible = false;
            //txt_mail.Focus();
            TabControl2.SelectedTab = TabPage5;
        }
        private string obtieneItem(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_modificar4_Click(object sender, EventArgs e)
        {
            //ITEM2.Text = DGW2.CurrentRow.Index.ToString
            LIMPIAR_FONO();
            CARGAR_FONO();
            btn_guardar3.Visible = false;
            btn_mod2.Visible = true;
            Panel2.Visible = true;
            cbo_tipo_fono.Focus();
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarTelefono())
                return;
            int FILA = DGW2.CurrentRow.Index;
            //DGW2[0, FILA].Value = obtieneItem(DGW2.Rows.Count);
            DGW2[1, FILA].Value = cbo_tipo_fono.SelectedValue.ToString();
            DGW2[2, FILA].Value = cbo_tipo_fono.Text;
            DGW2[3, FILA].Value = txt_nro_fono.Text;
            Panel2.Visible = false;
        }

        private void btn_eliminar3_Click(object sender, EventArgs e)
        {
            if (DGW2.Rows.Count > 0)
                DGW2.Rows.RemoveAt(DGW2.CurrentRow.Index);
        }

        private void btn_eliminar4_Click(object sender, EventArgs e)
        {
            if (DGW3.Rows.Count > 0)
                DGW3.Rows.RemoveAt(DGW3.CurrentRow.Index);
        }

        private void btn_eliminar5_Click(object sender, EventArgs e)
        {
            if (DGW4.Rows.Count > 0)
                DGW4.Rows.RemoveAt(DGW4.CurrentRow.Index);
        }

        private void btn_agregar3_Click(object sender, EventArgs e)
        {
            LIMPIAR_DIRECCION();
            btn_guardar4.Visible = true;
            btn_mod3.Visible = false;
            Panel3.Visible = true;
            cbo_pais.Focus();
        }
        private bool validaGuardarModificarDireccion()
        {
            bool result = true;
            if (cbo_pais.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Pais !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_pais.Focus();
                return result = false;
            }
            if (txt_dir.Text == "")
            {
                MessageBox.Show("Ingrese la direccion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_dir.Focus();
                return result = false;
            }
            if (cbo_tipo_dir.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el tipo de direccion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_dir.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_guardar4_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarDireccion())
                return;
            string coddep = cbo_dep.SelectedValue == null ? "" : cbo_dep.SelectedValue.ToString();
            string codprovi = cbo_pro.SelectedValue == null ? "" : cbo_pro.SelectedValue.ToString();
            string coddistri = cbo_dist.SelectedValue == null ? "" : cbo_dist.SelectedValue.ToString();

            DGW3.Rows.Add(cbo_tipo_dir.SelectedValue.ToString(), cbo_tipo_dir.Text, txt_dir.Text, txt_ref.Text, cbo_pais.SelectedValue.ToString(),
                cbo_pais.Text, coddep, codprovi, coddistri);
            Panel3.Visible = false;
            //txt_mail.Focus();
            TabControl2.SelectedTab = TabPage6;
        }
        private void LIMPIAR_DIRECCION()
        {
            if (form == 1)
                cbo_tipo_dir.SelectedIndex = 2;
            else
                cbo_tipo_dir.SelectedIndex = -1;
            cbo_tipo_dir.Enabled = true;
            cbo_pais.SelectedIndex = -1;
            cbo_dep.SelectedIndex = -1;
            cbo_pro.SelectedIndex = -1;
            cbo_dist.SelectedIndex = -1;
            cbo_pais.SelectedValue = "9589";
            cbo_dep.SelectedValue = "15";
            cbo_pro.SelectedValue = "01";
            cargaDistritos();


            txt_dir.Clear();
            txt_ref.Clear();
            if (form == 1)
                txt_ref.Text = "NO ESPECIFICA";
        }
        private void CARGAR_DIRECCION0()
        {
            if (DGW3.Rows.Count > 0)
            {
                cbo_tipo_dir.SelectedValue = DGW3[0, DGW3.CurrentRow.Index].Value.ToString();
                txt_dir.Text = DGW3[2, DGW3.CurrentRow.Index].Value.ToString();
                txt_ref.Text = DGW3[3, DGW3.CurrentRow.Index].Value.ToString();
                cbo_pais.SelectedValue = DGW3[4, DGW3.CurrentRow.Index].Value;
                cbo_dep.SelectedValue = DGW3[6, DGW3.CurrentRow.Index].Value;
                cbo_pro.SelectedValue = DGW3[7, DGW3.CurrentRow.Index].Value;
                cbo_dist.SelectedValue = DGW3[8, DGW3.CurrentRow.Index].Value;
            }
        }
        private void btn_modificar5_Click(object sender, EventArgs e)
        {
            LIMPIAR_DIRECCION();
            CARGAR_DIRECCION0();
            btn_guardar4.Visible = false;
            btn_mod3.Visible = true;
            Panel3.Visible = true;
            cbo_tipo_dir.Enabled = false;
            cbo_pais.Focus();
        }

        private void btn_mod3_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarDireccion())
                return;
            int FILA = DGW3.CurrentRow.Index;
            //'------------------
            DGW3[0, FILA].Value = cbo_tipo_dir.SelectedValue.ToString();
            DGW3[1, FILA].Value = cbo_tipo_dir.Text;
            DGW3[2, FILA].Value = txt_dir.Text;
            DGW3[3, FILA].Value = txt_ref.Text;
            DGW3[4, FILA].Value = cbo_pais.SelectedValue.ToString();
            DGW3[5, FILA].Value = cbo_pais.Text;
            DGW3[6, FILA].Value = cbo_dep.SelectedValue.ToString();
            DGW3[7, FILA].Value = cbo_pro.SelectedValue.ToString();
            DGW3[8, FILA].Value = cbo_dist.SelectedValue.ToString();
            Panel3.Visible = false;
        }
        private void LIMPIAR_CLASE()
        {
            cbo_clase.SelectedIndex = -1;
            cbo_clase.Enabled = true;
            cbo_cat.SelectedIndex = -1;
            txt_linea.Text = "0.00";
            CBO_PAGO.SelectedIndex = -1;
            cbo_VENTA.SelectedIndex = -1;
        }
        private void btn_agregar4_Click(object sender, EventArgs e)
        {
            LIMPIAR_CLASE();
            btn_guardar5.Visible = true;
            btn_mod4.Visible = false;
            Panel4.Visible = true;
            cbo_clase.Focus();
            //'Agregado para que muestre por default
            //'tipo de dirección Fiscal DPTO: Lima PROV: Lima
            cbo_clase.SelectedIndex = 1;
            cbo_cat.SelectedIndex = 0;
            CBO_PAGO.SelectedIndex = 2;

        }
        private void CARGAR_CLASE0()
        {
            if (DGW4.Rows.Count > 0)
            {
                int idx = DGW4.CurrentRow.Index;
                //COD_CLASE = DGW4.Item(0, idx).Value.ToString
                cbo_clase.SelectedValue = DGW4[0, idx].Value;
                //COD_CAT = DGW4.Item(2, idx).Value.ToString
                cbo_cat.SelectedValue = DGW4[2, idx].Value;
                txt_linea.Text = DGW4[4, idx].Value.ToString();
                CBO_PAGO.SelectedValue = DGW4[5, idx].Value;
                cbo_VENTA.SelectedValue = DGW4[7, idx].Value;
                TXT_DIA1.Text = DGW4[9, idx].Value.ToString();
            }
        }

        private void btn_modificar6_Click(object sender, EventArgs e)
        {
            if (DGW4.Rows.Count <= 0)
                return;
            LIMPIAR_CLASE();
            CARGAR_CLASE0();
            btn_guardar5.Visible = false;
            btn_mod4.Visible = true;
            Panel4.Visible = true;
            cbo_clase.Enabled = false;
            cbo_cat.Focus();
        }

        private void btn_guardar5_Click(object sender, EventArgs e)
        {
            if (!VALIDAR_CLASE_PER())
                return;
            string condvta = cbo_VENTA.SelectedValue == null ? "" : cbo_VENTA.SelectedValue.ToString();
            DGW4.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_clase.Text, cbo_cat.SelectedValue.ToString(), cbo_cat.Text, txt_linea.Text,
                CBO_PAGO.SelectedValue.ToString(), CBO_PAGO.Text, condvta, cbo_VENTA.Text, TXT_DIA1.Text);
            Panel4.Visible = false;
            //txt_mail.Focus();
            if (form == 1)
                TabControl2.SelectedTab = TabPage7;
        }
        private bool VALIDAR_CLASE_PER()
        {
            bool result = true;
            int i = 0, c = 0;
            c = DGW4.Rows.Count - 1;
            for (i = 0; i <= c; i++)
            {
                if (cbo_clase.SelectedValue.ToString() == DGW4[0, i].Value.ToString() && cbo_cat.SelectedValue.ToString() == DGW4[2, i].Value.ToString())
                {
                    MessageBox.Show("Este Tipo de Clase ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return result = false;
                }
            }
            return result;
        }
        private void btn_mod4_Click(object sender, EventArgs e)
        {
            int FILA = DGW4.CurrentRow.Index;
            DGW4[0, FILA].Value = cbo_clase.SelectedValue.ToString();
            DGW4[1, FILA].Value = cbo_clase.Text;
            DGW4[2, FILA].Value = cbo_cat.SelectedValue.ToString();
            DGW4[3, FILA].Value = cbo_cat.Text;
            DGW4[4, FILA].Value = txt_linea.Text;
            DGW4[5, FILA].Value = CBO_PAGO.SelectedValue.ToString();
            DGW4[6, FILA].Value = CBO_PAGO.Text;
            DGW4[7, FILA].Value = cbo_VENTA.SelectedValue == null ? "" : cbo_VENTA.SelectedValue.ToString();
            DGW4[8, FILA].Value = cbo_VENTA.Text;
            DGW4[9, FILA].Value = TXT_DIA1.Text;
            //'--------------------------------
            Panel4.Visible = false;
        }

        private void btn_cancelar5_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
        }

        private void btn_cancelar4_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
        private void CARGAR_SUSTITUTO()
        {
            pesTo.COD_PER = dgw.CurrentRow.Cells["cod"].Value.ToString();
            DataTable dt = pesBLL.obtenerPersonaSustitutoBLL(pesTo);
            if (dt.Rows.Count > 0)
            {
                txt_dni_sus.Text = dt.Rows[0]["DNI_SUS"].ToString();
                txt_nom_sus.Text = dt.Rows[0]["NOMBRE_SUS"].ToString();
                txt_dir_sus.Text = dt.Rows[0]["DIRECCION_SUS"].ToString();
                txt_tel_sus.Text = dt.Rows[0]["TELEFONO_SUS"].ToString();
                txt_email_sus.Text = dt.Rows[0]["EMAIL_SUS"].ToString();
                txt_obs_sus.Text = dt.Rows[0]["OBS_SUS"].ToString();
            }
        }
        private void CARGAR_DETALLES()
        {
            int idx = dgw.CurrentRow.Index;
            personaContactoBLL pecBLL = new personaContactoBLL();
            personaContactoTo pecTo = new personaContactoTo();
            dgw1.Rows.Clear();
            pecTo.COD_PER = dgw[0, idx].Value.ToString();
            dtContactos = pecBLL.obtenerPersonaContactoBLL(pecTo);
            foreach (DataRow rw in dtContactos.Rows)
            {
                int rowId = dgw1.Rows.Add();
                DataGridViewRow row = dgw1.Rows[rowId];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
            }
            personaFonoBLL pefBLL = new personaFonoBLL();
            personaFonoTo pefTo = new personaFonoTo();
            DGW2.Rows.Clear();
            pefTo.COD_PER = dgw[0, idx].Value.ToString();
            dtTelefono = pefBLL.obtenerPersonaFonoBLL(pefTo);
            foreach (DataRow rw in dtTelefono.Rows)
            {
                int rowId = DGW2.Rows.Add();
                DataGridViewRow row = DGW2.Rows[rowId];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
            }
            personaDireccionBLL pedBLL = new personaDireccionBLL();
            personaDireccionTo pedTo = new personaDireccionTo();
            DGW3.Rows.Clear();
            pedTo.COD_PER = dgw[0, idx].Value.ToString();
            dtDirec = pedBLL.obtenerPersonaDireccionBLL(pedTo);
            foreach (DataRow rw in dtDirec.Rows)
            {
                int rowId = DGW3.Rows.Add();
                DataGridViewRow row = DGW3.Rows[rowId];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
                row.Cells[7].Value = rw[8].ToString();
                row.Cells[8].Value = rw[10].ToString();

            }
            personaClaseBLL pelBLL = new personaClaseBLL();
            personaClaseTo pelTo = new personaClaseTo();
            DGW4.Rows.Clear();
            pelTo.COD_PER = dgw[0, idx].Value.ToString();
            dtClsePer = pelBLL.obtenerPersonaClaseBLL(pelTo);
            foreach (DataRow rw in dtClsePer.Rows)
            {
                int rowId = DGW4.Rows.Add();
                DataGridViewRow row = DGW4.Rows[rowId];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString();
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
                row.Cells[7].Value = rw[7].ToString();
                row.Cells[8].Value = rw[8].ToString();
                row.Cells[9].Value = rw[9].ToString();
            }
            personaBeneficiarioBLL pebBLL = new personaBeneficiarioBLL();
            personaBeneficiarioTo pebTo = new personaBeneficiarioTo();
            DGW5.Rows.Clear();
            pebTo.COD_PER = dgw[0, idx].Value.ToString();
            dtBeneficiario = pebBLL.obtenerPersonaBeneficiarioBLL(pebTo);
            foreach (DataRow rw in dtBeneficiario.Rows)
            {
                int rowId = DGW5.Rows.Add();
                DataGridViewRow row = DGW5.Rows[rowId];
                row.Cells[0].Value = rw[0].ToString();
                row.Cells[1].Value = rw[1].ToString();
                row.Cells[2].Value = rw[2].ToString();
                row.Cells[3].Value = rw[3].ToString();
                row.Cells[4].Value = rw[4].ToString().Substring(0, 10);
                row.Cells[5].Value = rw[5].ToString();
                row.Cells[6].Value = rw[6].ToString();
                row.Cells[7].Value = rw[7].ToString();
            }
            UsuarioWebBLL uswBLL = new UsuarioWebBLL();
            usuarioWebTo uswTo = new usuarioWebTo();
            dgw_usu_web.Rows.Clear();
            uswTo.COD_PER = dgw[0, idx].Value.ToString();
            dtWebUsu = uswBLL.obtenerUsuarioWebBLL(uswTo);
            foreach (DataRow rw in dtWebUsu.Rows)
            {
                int rowId = dgw_usu_web.Rows.Add();
                DataGridViewRow row = dgw_usu_web.Rows[rowId];
                row.Cells["usu_web_item"].Value = rw["ITEM"].ToString();
                row.Cells["usu_web_contrato"].Value = rw["NRO_CONTRATO"].ToString();
                row.Cells["usu_web_usuario"].Value = rw["USUARIO"].ToString();
                row.Cells["usu_web_password"].Value = rw["PASSWORD"].ToString();
            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            //INDICE = dgw.CurrentRow.Index
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            CARGAR_SUSTITUTO();
            txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_desc.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (form == 1 || form == 2)
                Hide();//btn_salir_Click(sender, e);

            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar a la Persona ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                pemTo.COD_PER = txt_cod.Text;
                pemTo.TIPO_PER = cbo_tipo.SelectedValue.ToString();
                pemTo.COD_TIPO_DOC = cbo_tipo_doc.SelectedValue.ToString();
                pemTo.NRO_DOC = txt_nro_doc.Text;
                pemTo.DESC_PER = txt_desc.Text;
                pemTo.NOMBRE = txt_nom.Text.Trim();
                pemTo.PATERNO = txt_pat.Text.Trim();
                pemTo.MATERNO = txt_mat.Text.Trim();
                pemTo.NOM_COMERCIAL = txt_nc.Text;
                pemTo.MAIL = txt_mail.Text;
                pemTo.NRO_BENEFICIARIOS = Convert.ToInt32(txt_nro_beneficiaros.Text);
                pemTo.NOM_AVAL = "";
                pemTo.NRO_DOC_AVAL = "";
                pemTo.DIR_AVAL = "";
                pemTo.FONO_AVAL = "";
                pemTo.ST_CONTRIBUYENTE = "0";
                pemTo.ST_RETENEDOR = "0";
                pemTo.ST_PERCEPTOR = "0";
                pemTo.COD_INSTITUCION = cbo_institucion.SelectedValue == null ? "" : cbo_institucion.SelectedValue.ToString();
                pemTo.COD_IDENTIDAD = cboidentidad.SelectedValue == null ? "" : cboidentidad.SelectedValue.ToString();
                pemTo.DES_IDENTIDAD = txtcodid.Text;
                pemTo.COD_PROCESO = cboproceso.SelectedValue == null ? "" : cboproceso.SelectedValue.ToString();
                pemTo.DES_PROCESO = txtcodproc.Text;
                pemTo.COD_SITUACION = cbo_codsit.SelectedValue == null ? "" : cbo_codsit.SelectedValue.ToString();
                pemTo.COD_USUARIO = "";// txt_usuario.Text;
                pemTo.PWD_USUARIO = "";// txt_pwd.Text;
                pemTo.COD_CARGO = cbo_cargocliente.SelectedValue == null ? "" : cbo_cargocliente.SelectedValue.ToString();
                pemTo.COD_VIVIENDA = cbo_tipvivienda.SelectedValue == null ? "" : cbo_tipvivienda.SelectedValue.ToString();
                pemTo.COD_CONDICION = cbocodcon.SelectedValue == null ? "" : cbocodcon.SelectedValue.ToString();
                pemTo.IMAGEN = txt_img.Text;
                //
                dtContactos = obtieneDT(dgw1);
                dtTelefono = obtieneDT(DGW2);
                dtDirec = obtieneDT(DGW3);
                dtClsePer = obtieneDT(DGW4);
                dtBeneficiario = obtieneDT(DGW5);
                dtWebUsu = obtieneDT(dgw_usu_web);
                //
                pesTo.COD_PER = txt_cod.Text;
                pesTo.DNI_SUS = txt_dni_sus.Text;
                pesTo.NOMBRE_SUS = txt_nom_sus.Text;
                pesTo.DIRECCION_SUS = txt_dir_sus.Text;
                pesTo.EMAIL_SUS = txt_email_sus.Text;
                pesTo.TELEFONO_SUS = txt_tel_sus.Text;
                pesTo.OBS_SUS = txt_obs_sus.Text;

                if (!pemBLL.modificaMaestroPersonaBLL(pemTo, dtContactos, dtTelefono, dtDirec, dtClsePer, pesTo, dtBeneficiario, dtWebUsu, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE modificó correctamente a la Persona !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw.CurrentRow.Index;
                    dgw.Rows[idx].Cells["cod"].Value = txt_cod.Text;//0
                    dgw.Rows[idx].Cells["razs"].Value = txt_desc.Text;//1
                    dgw.Rows[idx].Cells["nrodoc"].Value = txt_nro_doc.Text;//2
                    dgw.Rows[idx].Cells["nomcom"].Value = txt_nc.Text;//4
                    dgw.Rows[idx].Cells["DESC_CAT"].Value = Convert.ToString(DGW4.Rows[0].Cells["catepp"].Value);//5
                    dgw[6, idx].Value = cbo_tipo.SelectedValue.ToString();//6
                    dgw[7, idx].Value = cbo_tipo.Text;//7
                    dgw[8, idx].Value = cbo_tipo_doc.SelectedValue.ToString();//8
                    dgw[9, idx].Value = cbo_tipo_doc.Text;//9
                    dgw[10, idx].Value = txt_nom.Text;//10
                    dgw[11, idx].Value = txt_pat.Text;//11
                    dgw[12, idx].Value = txt_mat.Text;//12
                    dgw[13, idx].Value = txt_mail.Text;//13
                    dgw[14, idx].Value = cboidentidad.SelectedValue == null ? "" : cboidentidad.SelectedValue.ToString();//14
                    dgw[15, idx].Value = txtcodid.Text;//15
                    dgw[16, idx].Value = cboproceso.SelectedValue == null ? "" : cboproceso.SelectedValue.ToString();//16
                    dgw[17, idx].Value = txtcodproc.Text;//17
                    dgw[18, idx].Value = cbo_codsit.SelectedValue == null ? "" : cbo_codsit.SelectedValue.ToString();//18
                    dgw[19, idx].Value = cbo_institucion.SelectedValue == null ? "" : cbo_institucion.SelectedValue.ToString();//19
                    dgw[20, idx].Value = cbo_cargocliente.SelectedValue == null ? "" : cbo_cargocliente.SelectedValue.ToString();//20
                    dgw[21, idx].Value = cbo_tipvivienda.SelectedValue == null ? "" : cbo_tipvivienda.SelectedValue.ToString();//21
                    dgw[22, idx].Value = cbocodcon.SelectedValue == null ? "" : cbocodcon.SelectedValue.ToString();//22
                    dgw[23, idx].Value = "";// txt_usuario.Text;//23
                    dgw[24, idx].Value = "";// txt_pwd.Text;//24
                    dgw[25, idx].Value = txt_img.Text;//25
                    dgw.Rows[idx].Cells["DESC_INST"].Value = cbo_institucion.Text;
                    dgw.Rows[idx].Cells["DES_IDENTIDAD"].Value = txtcodid.Text;
                    dgw.Rows[idx].Cells["DES_PROCESO"].Value = txtcodproc.Text;
                    dgw.Rows[idx].Cells["NRO_BENEFICIARIOS"].Value = txt_nro_beneficiaros.Text;

                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }


        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            //aqui debe haber una validacion para que no elimine a una persona cliente que ya tenga historico  
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Persona ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pemTo.COD_PER = dgw.CurrentRow.Cells[0].Value.ToString();
                if (!pemBLL.eliminaPersonaBLL(pemTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La Persona se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargaDataGrid();//No se necesita si se remueve del grid con RemoveAt
                    dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
                    btn_nuevo.Select();
                }
            }

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (BOTON == "NUEVO")
                {
                    BOTON = "DETALLES1";
                }
                else if (BOTON == "MODIFICAR")
                {
                    BOTON = "DETALLES2";
                }
                else
                {
                    BOTON = "DETALLES";
                    LIMPIAR_CABECERA();
                    CARGAR_SUSTITUTO();
                    if (dgw.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        CARGAR_CABECERA();
                        CARGAR_DETALLES();
                    }
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                    txt_cod.ReadOnly = true;
                    txt_desc.ReadOnly = true;
                    txt_nom.ReadOnly = true;
                    txt_pat.ReadOnly = true;
                    txt_mat.ReadOnly = true;
                    txt_nro_doc.ReadOnly = true;
                    txt_mail.ReadOnly = true;
                    txt_nro_beneficiaros.ReadOnly = true;
                    cbo_tipo_doc.Enabled = false;
                    cbo_tipo.Enabled = false;
                    //cbo_codsit.Enabled = false;
                    //cbo_institucion.Enabled = false;
                    //cbo_cargocliente.Enabled = false;
                    //cbo_tipvivienda.Enabled = false;
                    //cbocodcon.Enabled = false;
                    btnConsultaSunat.Enabled = false;
                }
            }
        }

        private void cbo_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589")
                    cargaDepartamentos();
                else
                {
                    cbo_dep.SelectedIndex = -1;
                    cbo_pro.SelectedIndex = -1;
                    cbo_dist.SelectedIndex = -1;
                }
            }
        }
        private void cargaDepartamentos()
        {
            DataTable dt = helBLL.obtenerDepartamentoBLL();
            cbo_dep.ValueMember = "COD_DEP";
            cbo_dep.DisplayMember = "DESC_DEP";
            cbo_dep.DataSource = dt;

        }

        private void cbo_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589" && cbo_dep.SelectedValue != null)
                    cargaProvincias();
                else
                    cbo_dep.SelectedIndex = -1;
            }

        }
        private void cargaProvincias()
        {
            helTo.CODIGO = cbo_dep.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerPro_PaisBLL(helTo);
            cbo_pro.ValueMember = "COD_PRO";
            cbo_pro.DisplayMember = "DESC_PRO";
            cbo_pro.DataSource = dt;
        }

        private void cbo_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589" && cbo_dep.SelectedValue != null && cbo_pro.SelectedValue != null)
                    cargaDistritos();
                else
                    cbo_dep.SelectedIndex = -1;
            }

        }
        private void cargaDistritos()
        {
            helTo.CODIGO = cbo_dep.SelectedValue.ToString();
            helTo.CODIGO2 = cbo_pro.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerDist_Pro_PaisBLL(helTo);
            cbo_dist.ValueMember = "COD_DIST";
            cbo_dist.DisplayMember = "DESC_DIST";
            cbo_dist.DataSource = dt;
        }

        private void CBO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_PAGO.SelectedValue != null)
            {
                if (CBO_PAGO.SelectedValue.ToString() == "03")
                    cbo_VENTA.Enabled = true;
                else
                {
                    cbo_VENTA.SelectedIndex = -1;
                    cbo_VENTA.Enabled = false;
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_nom_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text.Trim() + " " + txt_mat.Text.Trim() + " " + txt_nom.Text.Trim();
        }

        private void txt_pat_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text.Trim() + " " + txt_mat.Text.Trim() + " " + txt_nom.Text.Trim();
        }

        private void txt_mat_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text.Trim() + " " + txt_mat.Text.Trim() + " " + txt_nom.Text.Trim();
        }

        private void cbo_institucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_institucion.SelectedIndex > 0)
            {
                //cboidentidad.Items.RemoveAt(0);
                DataRow[] r = dtInstitucion.Select("COD_INST = '" + cbo_institucion.SelectedValue.ToString() + "' ");
                cboidentidad.ValueMember = "value";
                cboidentidad.DisplayMember = "display";
                var itemr = new[] {
                new { value = r[0][4].ToString(), display = r[0][5].ToString() }//3,4
            
                };
                cboidentidad.DataSource = itemr;
                //
                //cboproceso.Items.RemoveAt(0);
                //DataRow[] s = dtInstitucion2.Select("COD_PROCESO = '" + cbo_institucion.SelectedValue.ToString() + "' ");
                cboproceso.ValueMember = "value";
                cboproceso.DisplayMember = "display";
                var items = new[] {
                new { value = r[0][6].ToString(), display = r[0][7].ToString() }//5,6
            
                };
                cboproceso.DataSource = items;
            }
            else if (cbo_institucion.SelectedIndex == 0)
            {
                txtcodid.Text = "";
                txtcodproc.Text = "";
                cboidentidad.SelectedIndex = -1;
                cboproceso.SelectedIndex = -1;
            }
        }

        private void btnConsultaSunat_Click(object sender, EventArgs e)
        {
            CONSULTAS.frmConsultaRuc frm = CONSULTAS.frmConsultaRuc.ObtenerInstancia();
            frm.Cargar_Datos(txt_nro_doc.Text, BOTON, "mantenimiento");
            frm.btnConsultar.Focus();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                try
                {
                    txt_nro_doc.Text = frm.txtRuc.Text;
                    txt_desc.Text = frm.txtNombre.Text;
                    DGW3.Rows.Add("01", "FISCAL", frm.txtDireccion.Text, "", "", "", "", "", "", "", "", "");
                    int tipDoc;
                    tipDoc = frm.txtTipo.Text.IndexOf("NATURAL", 1);
                    cbo_tipo.Text = tipDoc > 0 ? "NATURAL" : "JURIDICA";
                    //'Nombre Persona Natural
                    if (tipDoc > 0)
                    {
                        string words = frm.txtNombre.Text;
                        string[] split = words.Split(' ', ',', '.', ':');
                        int cont = 0;
                        txt_nom.Clear();
                        foreach (string s in split)
                        {
                            if (s.Trim() != "")
                            {
                                if (cont == 0)
                                    txt_pat.Text = s;
                                else if (cont == 1)
                                    txt_mat.Text = s;
                                else if (cont > 1)
                                    txt_nom.Text = txt_nom.Text + s + " ";
                                cont += 1;
                            }
                        }
                        txt_nom.Text = txt_nom.Text.Trim();
                        cbo_tipo_doc.Text = "REGISTRO UNICO CONTRIBUYENTE";
                        if (cbo_tipo.Text == "NATURAL")
                        {
                            txt_nc.Text = frm.txtNombreComercial.Text;
                        }

                    }
                }
                catch (Exception)
                {
                    txt_desc.Clear();
                }
                frm.Hide();
            }
            frm.Dispose();
        }

        private void PERSONA_Shown(object sender, EventArgs e)
        {
            if (form == 1)
                txt_cod.Focus();
        }

        private void txt_mail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TabControl2.SelectedTab = TabPage4;
                //btn_agregar2.Focus();
            }
        }

        private void cbocodcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form == 1)
                    btn_cancelar.Focus();
            }
        }

        private void txt_nro_doc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbo_tipo.SelectedValue.ToString() == "N")
                {
                    GroupBox2.Focus();
                }
            }
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            break;
                        }
                    }
                }
            }
            else if (ch_nc.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[3, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[3, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[3];
                            break;
                        }
                    }
                }
            }
            else if (ch_doc.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw[2, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[2, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[2];
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
                dgw.Sort(dgw.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
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
                dgw.Sort(dgw.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_nc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_nc.Checked)
            {
                dgw.Sort(dgw.Columns[3], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_doc_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_doc.Checked)
            {
                dgw.Sort(dgw.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
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
            for (i = 0; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
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
            for (i = fila; i < dgw.Rows.Count; i++)
            {
                for (f = 0; f <= dgw[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw.CurrentCell = dgw.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnMod_be_Click(object sender, EventArgs e)
        {
            LIMPIAR_BENEFICIARIO();
            CARGAR_BENEFICIARIO();
            btnGuardar_be.Visible = false;
            btnModificar_be.Visible = true;
            panel_be.Visible = true;
            txt_contrato.Focus();
        }
        private void LIMPIAR_BENEFICIARIO()
        {
            txt_nom_ape_be.Clear();
            txt_dni_be.Clear();
            txt_email_be.Clear();
            txt_tel_be.Clear();
            txt_plazo_act_be.Clear();
            txt_nom_ape_be.ReadOnly = false;
            txt_dni_be.ReadOnly = false;
            txt_email_be.ReadOnly = false;
            txt_tel_be.ReadOnly = false;
            txt_plazo_act_be.ReadOnly = false;
        }
        private void btnAgre_be_Click(object sender, EventArgs e)
        {
            if (!validaAgregarBeneficiarios())
                return;
            LIMPIAR_BENEFICIARIO();
            btnGuardar_be.Visible = true;
            btnModificar_be.Visible = false;
            panel_be.Visible = true;
            txt_contrato.Focus();
        }
        private bool validaAgregarBeneficiarios()
        {
            bool result = true;
            int s = 0;
            if (!int.TryParse(txt_nro_beneficiaros.Text, out s))
            {
                MessageBox.Show("El nro ingresado no es válido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_beneficiaros.Focus();
                return result = false;
            }
            if (DGW5.Rows.Count >= Convert.ToInt32(txt_nro_beneficiaros.Text))
            {
                MessageBox.Show("Se rebazó la cantidad máxima de beneficiarios permitidos !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btnEle_be_Click(object sender, EventArgs e)
        {
            if (DGW5.Rows.Count > 0)
                DGW5.Rows.RemoveAt(DGW5.CurrentRow.Index);
        }

        private void btnGuardar_be_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarBeneficiario())
                return;
            DGW5.Rows.Add(obtieneItem(DGW5.Rows.Count), txt_contrato.Text, txt_nom_ape_be.Text, txt_dni_be.Text,
                dtp_fec_nac_be.Value.ToShortDateString(), txt_email_be.Text, txt_tel_be.Text, txt_plazo_act_be.Text);
            panel_be.Visible = false;
            //TabControl2.SelectedTab = TabPage5;
        }
        private bool validaGuardarModificarBeneficiario()
        {
            bool result = true;

            return result;
        }

        private void btnModificar_be_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarBeneficiario())
                return;
            int FILA = DGW5.CurrentRow.Index;
            //DGW2[0, FILA].Value = obtieneItem(DGW2.Rows.Count);
            DGW5[1, FILA].Value = txt_contrato.Text;
            DGW5[2, FILA].Value = txt_nom_ape_be.Text;
            DGW5[3, FILA].Value = txt_dni_be.Text;
            DGW5[4, FILA].Value = dtp_fec_nac_be.Value.ToShortDateString();
            DGW5[5, FILA].Value = txt_email_be.Text;
            DGW5[6, FILA].Value = txt_tel_be.Text;
            DGW5[7, FILA].Value = txt_plazo_act_be.Text;
            panel_be.Visible = false;
        }

        private void btn_Cancelar_be_Click(object sender, EventArgs e)
        {
            panel_be.Visible = false;
        }

        private void BTN_IMG_Click(object sender, EventArgs e)
        {
            //string RSLT = "C:\\";//artBLL.obtenerImagenBLL(artTo);//SE COMENTÒ PORQUE DEMORA MUCHO CUANDO BUSCA EN LA TABLA DIRECTORIO, DEVUELVE UNA RUTA  
            //string RutaArchivo = "";
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = RSLT;
            //ofd.Filter = "Image Files (*.png;*.jpg;)|*.png;*.jpg; | All Files (*.*)|*.*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    RutaArchivo = ofd.SafeFileName;
            //    txt_img.Text = RutaArchivo;
            //}
            //txt_nc.Focus();
            OpenFileDialog buscar = new OpenFileDialog();
            if (buscar.ShowDialog() == DialogResult.OK)
                txt_img.Text = buscar.FileName;
        }

        private void ch_todos_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_todos.Checked)
            {
                cargaDataGrid();
                cboClase.SelectedIndex = -1;
                cboCategorias.SelectedIndex = -1;
            }
        }

        private void ch_clientes_CheckedChanged(object sender, EventArgs e)
        {
            FiltroMaestroPersonas("2", "1");
        }

        private void ch_personal_CheckedChanged(object sender, EventArgs e)
        {
            FiltroMaestroPersonas("1", "2");
        }

        private void ch_proveedores_CheckedChanged(object sender, EventArgs e)
        {
            FiltroMaestroPersonas("1", "1");
        }
        private void FiltroMaestroPersonas(string cod_clase, string cod_cat)
        {
            dgw.Rows.Clear();
            lbl_nro_reg_docs.Text = "Nro de Registros : 0";
            DataRow[] rs = dtP.Select("COD_CLASE = '" + cod_clase + "' AND COD_CAT = '" + cod_cat + "'");
            if (rs.Length > 0) dgw.Rows.Clear();
            lbl_nro_reg_docs.Text = "Nro de Registros : " + rs.Length.ToString();
            foreach (DataRow rw in rs)
            {
                int rowId = dgw.Rows.Add();
                DataGridViewRow row = dgw.Rows[rowId];
                row.Cells["cod"].Value = rw["Codigo"].ToString();
                row.Cells["razs"].Value = rw["Razon Social"].ToString();
                row.Cells["nrodoc"].Value = rw["Nroº Doc."].ToString();
                row.Cells["DESC_CAT"].Value = rw["DESC_CAT"].ToString();
                row.Cells["nomcom"].Value = rw["Nom. Comercial"].ToString();
                row.Cells["codtipper"].Value = rw["COD_TIPO_PER"].ToString();
                row.Cells["tipper"].Value = rw["TIPO_PER"].ToString();
                row.Cells["codtipdoc"].Value = rw["COD_TIPO_DOC"].ToString();
                row.Cells["tipdoc"].Value = rw["COD_TIPO_DOC"].ToString();
                row.Cells["nom"].Value = rw["NOMBRE"].ToString();
                row.Cells["app"].Value = rw["PATERNO"].ToString();
                row.Cells["apm"].Value = rw["MATERNO"].ToString();
                row.Cells["email"].Value = rw["MAIL"].ToString();
                row.Cells["codid"].Value = rw["COD_IDENTIDAD"].ToString();
                row.Cells["desid"].Value = rw["DES_IDENTIDAD"].ToString();
                row.Cells["codpro"].Value = rw["COD_PROCESO"].ToString();//
                row.Cells["despro"].Value = rw["DES_PROCESO"].ToString();
                row.Cells["codsit"].Value = rw["COD_SITUACION"].ToString();
                row.Cells["codins"].Value = rw["COD_INSTITUCION"].ToString();
                row.Cells["codcar"].Value = rw["COD_CARGO"].ToString();
                row.Cells["codviv"].Value = rw["COD_VIVIENDA"].ToString();
                row.Cells["codcon"].Value = rw["COD_CONDICION"].ToString();
                row.Cells["codus"].Value = rw["COD_USUARIO"].ToString();
                row.Cells["pwdus"].Value = rw["PWD_USUARIO"].ToString();
                row.Cells["imagen"].Value = rw["IMAGEN"].ToString();
                row.Cells["COD_CLASE"].Value = rw["COD_CLASE"].ToString();
                row.Cells["COD_CAT"].Value = rw["COD_CAT"].ToString();
                row.Cells["DESC_INST"].Value = rw["DESC_INST"].ToString();
                row.Cells["DES_IDENTIDAD"].Value = rw["DES_IDENTIDAD"].ToString();
                row.Cells["DES_PROCESO"].Value = rw["DES_PROCESO"].ToString();
                row.Cells["NRO_BENEFICIARIOS"].Value = rw["NRO_BENEFICIARIOS"].ToString();
            }

        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            //MOD_ADM.VER_IMAGEN frm = new VER_IMAGEN(txt_img.Text);
            //frm.ShowDialog();
            if (txt_img.Text.Trim() != "")
                Process.Start(txt_img.Text);
            else
            {
                MessageBox.Show("No se ingresó la ruta del archivo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_img.Focus();
            }
        }

        private void txt_nro_doc_Validated(object sender, EventArgs e)
        {
            string errMensaje = "";
            bool result = false;
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nro de documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_doc.Focus();
                result = false;
            }
            else
            {
                if (btn_guardar.Visible)
                {
                    if (cbo_tipo_doc.SelectedValue != null)
                    {
                        if (cbo_tipo_doc.SelectedValue.ToString() == "01" && !(txt_nro_doc.Text.Trim().Length == 8))//o sea si es dni
                        {
                            MessageBox.Show("DNI debe tener 8 dígitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cbo_tipo_doc.Focus();
                            result = false;
                        }
                        else if (cbo_tipo_doc.SelectedValue.ToString() == "06" && !(txt_nro_doc.Text.Trim().Length == 11))//o sea si es ruc
                        {
                            MessageBox.Show("RUC debe tener 11 dígitos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cbo_tipo_doc.Focus();
                            result = false;
                        }
                    }
                    ////////////////////////////////////////////////////
                    bool val = false;
                    pemTo.NRO_DOC = txt_nro_doc.Text;
                    if (!pemBLL.verificaNroRucDniPersonaBLL(pemTo, ref val, ref errMensaje))
                    {
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                    else
                    {
                        if (val)
                        {
                            MessageBox.Show("Documento Dni ó Ruc ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cbo_tipo_doc.Focus();
                            result = false;
                        }
                    }
                }
            }

            if (result)
                cbo_tipo_doc.Focus();
        }

        private void cbo_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_VENTA.SelectedValue != null)
            {
                string cod_venta = cbo_VENTA.SelectedValue.ToString();
                TXT_DIA1.Text = helBLL.NRO_DIAS_CONDICION_VENTABLL(cod_venta);
            }
        }

        private void btn_refresh_situacion_Click(object sender, EventArgs e)
        {
            cargaSituacion();
        }

        private void btn_refresh_cargo_cliente_Click(object sender, EventArgs e)
        {
            cargaCargosClientes();
        }

        private void btn_refresh_tipo_vivienda_Click(object sender, EventArgs e)
        {
            cargaTiposVivienda();
        }

        private void btn_refresh_condicion_Click(object sender, EventArgs e)
        {
            cargaCondicion();
        }

        private void txt_nro_beneficiaros_Leave(object sender, EventArgs e)
        {
            int s = 0;
            if (!int.TryParse(txt_nro_beneficiaros.Text, out s))
                MessageBox.Show("El nro ingresado no es válido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txt_contrato_Leave(object sender, EventArgs e)
        {
            txt_contrato.Text = txt_contrato.Text.PadLeft(7, '0');
            //txt_nro_rep.Text = "";
            if (txt_contrato.Text == "0000000")
                txt_contrato.Text = "";
        }
        private void btn_usu_web_agregar_Click(object sender, EventArgs e)
        {
            //if (!validaAgregarBeneficiarios())
            //    return;
            LIMPIAR_USUARIO_WEB();
            btn_usu_web_grab.Visible = true;
            btn_usu_web_mod.Visible = false;
            panel_usu_web.Visible = true;
            txt_usu_web_contrato.Focus();
        }
        private void LIMPIAR_USUARIO_WEB()
        {
            txt_usu_web_contrato.Clear();
            txt_usu_web_usuario.Clear();
            txt_usu_web_password.Clear();
        }

        private void btn_usu_web_modificar_Click(object sender, EventArgs e)
        {
            LIMPIAR_USUARIO_WEB();
            CARGAR_USUARIO_WEB();
            btn_usu_web_grab.Visible = false;
            btn_usu_web_mod.Visible = true;
            panel_usu_web.Visible = true;
            txt_usu_web_contrato.Focus();
        }
        private void CARGAR_USUARIO_WEB()
        {
            if (dgw_usu_web.Rows.Count > 0)
            {
                txt_usu_web_contrato.Text = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_contrato"].Value);
                txt_usu_web_usuario.Text = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_usuario"].Value);
                txt_usu_web_password.Text = Convert.ToString(dgw_usu_web.CurrentRow.Cells["usu_web_password"].Value);
            }
        }

        private void btn_usu_web_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw_usu_web.Rows.Count > 0)
                dgw_usu_web.Rows.RemoveAt(dgw_usu_web.CurrentRow.Index);
        }

        private void btn_usu_web_grab_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarUsuarioWeb())
                return;
            dgw_usu_web.Rows.Add(obtieneItem(dgw_usu_web.Rows.Count), txt_usu_web_contrato.Text, txt_usu_web_usuario.Text, txt_usu_web_password.Text);
            panel_usu_web.Visible = false;
            //TabControl2.SelectedTab = TabPage5;
        }
        private bool validaGuardarModificarUsuarioWeb()
        {
            bool result = true;
            if (txt_usu_web_contrato.Text == "")
            {
                MessageBox.Show("Ingrese el Contrato !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_usu_web_contrato.Focus();
                return result = false;
            }
            if (txt_usu_web_usuario.Text == "")
            {
                MessageBox.Show("Ingrese el Usuario !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_usu_web_usuario.Focus();
                return result = false;
            }
            if (txt_usu_web_password.Text == "")
            {
                MessageBox.Show("Ingrese el Password !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_usu_web_password.Focus();
                return result = false;
            }
            return result;
        }
        private void btn_usu_web_mod_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarUsuarioWeb())
                return;
            int FILA = dgw_usu_web.CurrentRow.Index;
            dgw_usu_web[1, FILA].Value = txt_usu_web_contrato.Text;
            dgw_usu_web[2, FILA].Value = txt_usu_web_usuario.Text;
            dgw_usu_web[3, FILA].Value = txt_usu_web_password.Text;

            panel_usu_web.Visible = false;
        }
        private void btn_usu_web_canc_Click(object sender, EventArgs e)
        {
            panel_usu_web.Visible = false;
        }

        private void txt_usu_web_contrato_Leave(object sender, EventArgs e)
        {
            if (txt_usu_web_contrato.Text != "")
                txt_usu_web_contrato.Text = txt_usu_web_contrato.Text.PadLeft(7, '0');
        }

        private void btn_Cancelar_be_Click_1(object sender, EventArgs e)
        {
            panel_be.Visible = false;
        }

        private void btnFiltar_Click(object sender, EventArgs e)
        {
            string clase = Convert.ToString(cboClase.SelectedValue);
            string categoria = Convert.ToString(cboCategorias.SelectedValue);
            FiltroMaestroPersonas(clase, categoria);
            ch_todos.Checked = false;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboproceso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
