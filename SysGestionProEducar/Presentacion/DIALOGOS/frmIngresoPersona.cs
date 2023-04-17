using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.DIALOGOS
{
    public partial class frmIngresoPersona : Form
    {
        DataTable dtP;
        personaSustitutoBLL pesBLL = new personaSustitutoBLL();
        personaSustitutoTo pesTo = new personaSustitutoTo();
        personaMaestroBLL pemBLL = new personaMaestroBLL();
        personaMaestroTo pemTo = new personaMaestroTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        multiUsoBLL mulBLL = new multiUsoBLL();
        multiUsoTo mulTo = new multiUsoTo();
        DataTable dtInstitucion;
        int form;
        int fila;
        string BOTON = "NUEVO";
        string DNI_C;
        DataTable dtContactos, dtTelefono, dtDirec, dtClsePer, dtBeneficiario, dtWebUsu;
        public frmIngresoPersona(string DNI_C)
        {
            InitializeComponent();
            KeyPreview = true;
            dtP = pemBLL.obtenerMaestroPersonaBLL();
            //dgw.DataSource = dtP;
            //cargaDataGrid();-------------------
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
            cargaNuevoCodPer();
            this.DNI_C = DNI_C;
        }
        private void cargaNuevoCodPer()
        {
            txt_cod.Text = pemBLL.obtenerNuevoCodPerBLL();
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
        private void cargaClase()
        {
            DataTable dt = helBLL.obtenerClaseBLL();
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = -1;
        }
        private void cargaTipoDir()
        {
            DataTable dt = helBLL.obtenerTIpo_DirBLL();
            cbo_tipo_dir.ValueMember = "COD_TIPO";
            cbo_tipo_dir.DisplayMember = "DESC_TIPO";
            cbo_tipo_dir.DataSource = dt;
            cbo_tipo_dir.SelectedIndex = -1;
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
        private void frmIngresoPersona_Load(object sender, EventArgs e)
        {
            txt_nro_doc.Text = DNI_C;
        }

        private void frmIngresoPersona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void LIMPIAR_CABECERA()
        {
            txt_cod.Clear();
            txt_desc.Clear();

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

            txt_mail.Clear();
            cbo_codsit.SelectedIndex = -1;
            cbo_cargocliente.SelectedIndex = -1;
            cbo_tipvivienda.SelectedIndex = -1;
            cbocodcon.SelectedIndex = -1;
            txt_usuario.Clear();
            txt_pwd.Clear();
            txt_nc.Clear();
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
            //if (cbo_institucion.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Elija la institucion !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cbo_institucion.Focus();
            //    return result = false;
            //}
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

            return result;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            bool op = false;
            LBL.Text = "SI";
            if (!validaGuardarModificar())
            {
                //if(form !=1)
                //{
                //    op = false;
                //    return;
                //}
                //else if(form == 1)
                //{
                //    op = true;
                //    LBL.Text = "NO";
                //}

                op = true;
                LBL.Text = "NO";
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
                    pemTo.NOMBRE = txt_nom.Text;
                    pemTo.PATERNO = txt_pat.Text;
                    pemTo.MATERNO = txt_mat.Text;
                    pemTo.NOM_COMERCIAL = txt_nc.Text;
                    pemTo.MAIL = txt_mail.Text;
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
                    pemTo.COD_USUARIO = txt_usuario.Text;
                    pemTo.PWD_USUARIO = txt_pwd.Text;
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
                    //
                    pesTo.COD_PER = txt_cod.Text;
                    pesTo.NOMBRE_SUS = txt_nom_sus.Text;
                    pesTo.DIRECCION_SUS = txt_dir_sus.Text;
                    pesTo.EMAIL_SUS = txt_email_sus.Text;
                    pesTo.TELEFONO_SUS = txt_tel_sus.Text;
                    pesTo.OBS_SUS = txt_obs_sus.Text;
                    //
                    DNI_C = txt_nro_doc.Text;
                    string cod_persona = "";
                    if (!pemBLL.adicionaNuevoMaestroPersonaBLL(pemTo, dtContactos, dtTelefono, dtDirec, dtClsePer, pesTo, dtBeneficiario, dtWebUsu, ref cod_persona, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (form == 1)
                        {
                            Properties.Settings.Default.PER = "1";
                            Properties.Settings.Default.Save();
                            return;
                        }
                        MessageBox.Show("Se adicionó correctamente a la Persona !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        string nomc, emailc, obsc; string tipot, nrot; string tipod, direcd, paisd;
                        string clasep, catep, lincrep, forpagp, convtap, ndiasp;
                        string codid, desid, codpro, despro;
                        string codsit, codins, codcar, codviv, codcon, codus, pwdus, imagen;
                        string nro_contrato, nomb, dnib, fecnacb, emailb, telconb, plzactb;
                        string desc_inst, des_identidad, des_proceso;
                        if (dgw1.CurrentRow != null)
                        {
                            nomc = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
                            emailc = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                            obsc = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();

                        }
                        else
                        {
                            nomc = "";
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
                        codid = cboidentidad.SelectedIndex == -1 ? "" : cboidentidad.SelectedValue.ToString();
                        desid = txtcodid.Text;
                        codpro = cboproceso.SelectedIndex == -1 ? "" : cboproceso.SelectedValue.ToString();
                        despro = txtcodproc.Text;
                        codsit = cbo_codsit.SelectedIndex == -1 ? "" : cbo_codsit.SelectedValue.ToString();
                        codins = cbo_institucion.SelectedIndex == -1 ? "" : cbo_institucion.SelectedValue.ToString();
                        codcar = cbo_cargocliente.SelectedIndex == -1 ? "" : cbo_cargocliente.SelectedValue.ToString();
                        codviv = cbo_tipvivienda.SelectedIndex == -1 ? "" : cbo_tipvivienda.SelectedValue.ToString();
                        codcon = cbocodcon.SelectedIndex == -1 ? "" : cbocodcon.SelectedValue.ToString();
                        codus = txt_usuario.Text;
                        pwdus = txt_pwd.Text;
                        imagen = txt_img.Text;
                        desc_inst = cbo_institucion.Text;
                        des_identidad = txtcodid.Text.Trim();
                        des_proceso = txtcodproc.Text.Trim();
                        txt_cod.Text = cod_persona;
                        //dgw.Rows.Add(txt_cod.Text, txt_desc.Text, txt_nro_doc.Text, txt_nc.Text, cbo_tipo.SelectedValue.ToString(),
                        //    cbo_tipo.Text, cbo_tipo_doc.SelectedValue.ToString(), cbo_tipo_doc.Text, txt_nom.Text, txt_pat.Text,
                        //    txt_mat.Text, txt_mail.Text, codid, desid, codpro, despro, codsit, codins, codcar, codviv, codcon, codus, pwdus,
                        //    imagen, "", "", desc_inst, des_identidad, des_proceso);

                    }
                }
            }
        }
        private void LIMPIAR_CONTACTO()
        {
            txt_desc_cont.Clear();
            txt_mail_cont.Clear();
            txt_obs_cont.Clear();
            txt_desc_cont.ReadOnly = false;
            txt_mail_cont.ReadOnly = false;
            txt_obs_cont.ReadOnly = false;
            chkCorreoElectronico.Checked = false;
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
        private string obtieneItem(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarContacto())
                return;
            string status = chkCorreoElectronico.Checked ? "1" : "0";
            dgw1.Rows.Add(obtieneItem(dgw1.Rows.Count), txt_desc_cont.Text, txt_mail_cont.Text, txt_obs_cont.Text, status);
            Panel1.Visible = false;
            txt_mail.Focus();
        }
        private void CARGAR_CONTACTO()
        {
            if (dgw1.Rows.Count > 0)
            {
                txt_desc_cont.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
                txt_mail_cont.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
                txt_obs_cont.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
                chkCorreoElectronico.Checked = dgw1[4, dgw1.CurrentRow.Index].Value.ToString() == "1" ? true : false;
            }
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
            dgw1[2, FILA].Value = txt_mail_cont.Text;
            dgw1[3, FILA].Value = txt_obs_cont.Text;
            dgw1[4, FILA].Value = chkCorreoElectronico.Checked ? "1" : "0";
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

        private void btn_modificar4_Click(object sender, EventArgs e)
        {
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
        private void LIMPIAR_DIRECCION()
        {
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
            CBO_PAGO.SelectedIndex = 1;
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
            //if (form == 1)
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

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            //
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

        private void txt_nom_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text + " " + txt_mat.Text + " " + txt_nom.Text;
        }

        private void txt_pat_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text + " " + txt_mat.Text + " " + txt_nom.Text;
        }

        private void txt_mat_Leave(object sender, EventArgs e)
        {
            txt_desc.Text = txt_pat.Text + " " + txt_mat.Text + " " + txt_nom.Text;
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
                //if (form == 1)
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
            LIMPIAR_BENEFICIARIO();
            btnGuardar_be.Visible = true;
            btnModificar_be.Visible = false;
            panel_be.Visible = true;
            txt_contrato.Focus();
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
            //artTo.DESC_APLICACION = "TDEFA";
            //artTo.DESC_ARTICULO = "IMAART";
            string RSLT = "C:\\";//artBLL.obtenerImagenBLL(artTo);//SE COMENTÒ PORQUE DEMORA MUCHO CUANDO BUSCA EN LA TABLA DIRECTORIO, DEVUELVE UNA RUTA  
            string RutaArchivo = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = RSLT;
            ofd.Filter = "Image Files (*.png;*.jpg;)|*.png;*.jpg; | All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RutaArchivo = ofd.SafeFileName;
                txt_img.Text = RutaArchivo;
            }
            txt_nc.Focus();
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            MOD_ADM.VER_IMAGEN frm = new MOD_ADM.VER_IMAGEN(txt_img.Text);
            frm.ShowDialog();
        }
    }
}
