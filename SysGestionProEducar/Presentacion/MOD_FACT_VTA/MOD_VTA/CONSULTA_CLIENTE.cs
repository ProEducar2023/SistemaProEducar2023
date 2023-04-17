using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class CONSULTA_CLIENTE : Form
    {
        string codcli;
        DataTable dtContactos, dtTelefono, dtDirec, dtClsePer;
        DataTable dtP;
        personaMaestroBLL pemBLL = new personaMaestroBLL();
        personaMaestroTo pemTo = new personaMaestroTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        multiUsoBLL mulBLL = new multiUsoBLL();
        multiUsoTo mulTo = new multiUsoTo();
        public CONSULTA_CLIENTE(string codcli)
        {
            InitializeComponent();
            this.codcli = codcli;
        }
        private void CONSULTA_CLIENTE_Load(object sender, EventArgs e)
        {
            cargaTipoDoc();
            cargaTipoPer();
            cargaCodIdentidad();
            cargaCodProceso();
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
            CARGA_CABECERA();
            CARGA_DETALLE();
        }
        private void cargaSituacion()
        {
            mulTo.COD_GRUPO = "06";//SITUACION
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cbo_codsit.ValueMember = "COD_SUBGRUPO";
            cbo_codsit.DisplayMember = "DES_SUBGRUPO";
            cbo_codsit.DataSource = dt;
        }
        private void cargaCondicion()
        {
            mulTo.COD_GRUPO = "05";//CONDICION
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cbocodcon.ValueMember = "COD_SUBGRUPO";
            cbocodcon.DisplayMember = "DES_SUBGRUPO";
            cbocodcon.DataSource = dt;
        }
        private void cargaTiposVivienda()
        {
            mulTo.COD_GRUPO = "01";//TIPO VIVIENDA
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cbo_tipvivienda.ValueMember = "COD_SUBGRUPO";
            cbo_tipvivienda.DisplayMember = "DES_SUBGRUPO";
            cbo_tipvivienda.DataSource = dt;
        }
        private void cargaCargosClientes()
        {
            mulTo.COD_GRUPO = "02";//CARGOS CLIENTE
            DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            cbo_cargocliente.ValueMember = "COD_SUBGRUPO";
            cbo_cargocliente.DisplayMember = "DES_SUBGRUPO";
            cbo_cargocliente.DataSource = dt;
        }
        private void cargaInstituciones()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dt = insBLL.obtenerInstitucionesBLL();
            cbo_institucion.ValueMember = "COD_INST";
            cbo_institucion.DisplayMember = "DESC_INST";
            cbo_institucion.DataSource = dt;
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
        }
        public void cargaTipoPer()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerTipo_PersonaBLL();
            cbo_tipo.ValueMember = "cod";
            cbo_tipo.DisplayMember = "des";
            cbo_tipo.DataSource = dt;
        }
        private void CARGA_CABECERA()
        {
            pemTo.COD_PER = codcli;
            dtP = pemBLL.obtenerMaestroPersonaporCOD_PERBLL(pemTo);
            if (dtP.Rows.Count > 0)
            {
                //dgw.Rows.Clear();
                foreach (DataRow rw in dtP.Rows)
                {
                    txt_cod.Text = rw["Codigo"].ToString();
                    txt_desc.Text = rw["Razon Social"].ToString();
                    txt_nro_doc.Text = rw["Nroº Doc."].ToString();
                    txt_nc.Text = rw["Nom. Comercial"].ToString();
                    cbo_tipo.SelectedValue = rw["COD_TIPO_PER"];
                    //cbo_tipo.Text = rw["TIPO_PER"].ToString();
                    cbo_tipo_doc.SelectedValue = rw["COD_TIPO_DOC"];
                    //row.Cells["tipdoc"].Value = rw["COD_TIPO_DOC"].ToString();
                    txt_nom.Text = rw["NOMBRE"].ToString();
                    txt_pat.Text = rw["PATERNO"].ToString();
                    txt_mat.Text = rw["MATERNO"].ToString();
                    txt_mail.Text = rw["MAIL"].ToString();
                    cboidentidad.SelectedValue = rw["COD_IDENTIDAD"];
                    txtcodid.Text = rw["DES_IDENTIDAD"].ToString();
                    cboproceso.SelectedValue = rw["COD_PROCESO"];//
                    txtcodproc.Text = rw["DES_PROCESO"].ToString();
                    cbo_codsit.SelectedValue = rw["COD_SITUACION"].ToString();
                    cbo_institucion.SelectedValue = rw["COD_INSTITUCION"].ToString();
                    cbo_cargocliente.SelectedValue = rw["COD_CARGO"].ToString();
                    cbo_tipvivienda.SelectedValue = rw["COD_VIVIENDA"].ToString();
                    cbocodcon.SelectedValue = rw["COD_CONDICION"].ToString();
                }
            }
        }
        private void CARGA_DETALLE()
        {
            //int idx = dgw.CurrentRow.Index;
            personaContactoBLL pecBLL = new personaContactoBLL();
            personaContactoTo pecTo = new personaContactoTo();
            dgw1.Rows.Clear();
            pecTo.COD_PER = codcli;
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
            }
            personaFonoBLL pefBLL = new personaFonoBLL();
            personaFonoTo pefTo = new personaFonoTo();
            DGW2.Rows.Clear();
            pefTo.COD_PER = codcli;
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
            pedTo.COD_PER = codcli;
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
            pelTo.COD_PER = codcli;
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
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            //btn_guardar2.Visible = false;
            //btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            txt_desc_cont.Focus();
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

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void btn_modificar4_Click(object sender, EventArgs e)
        {
            LIMPIAR_FONO();
            CARGAR_FONO();
            //btn_guardar3.Visible = false;
            //btn_mod2.Visible = true;
            Panel2.Visible = true;
            cbo_tipo_fono.Focus();
        }
        private void LIMPIAR_FONO()
        {
            cbo_tipo_fono.SelectedIndex = -1;
            txt_nro_fono.Clear();
            cbo_tipo_fono.Enabled = true;
            txt_nro_fono.ReadOnly = false;
        }
        private void CARGAR_FONO()
        {
            if (DGW2.Rows.Count > 0)
            {
                cbo_tipo_fono.SelectedValue = DGW2[1, DGW2.CurrentRow.Index].Value;
                txt_nro_fono.Text = DGW2[3, DGW2.CurrentRow.Index].Value.ToString();
            }
        }

        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        private void btn_modificar5_Click(object sender, EventArgs e)
        {
            LIMPIAR_DIRECCION();
            CARGAR_DIRECCION0();
            //btn_guardar4.Visible = false;
            //btn_mod3.Visible = true;
            Panel3.Visible = true;
            cbo_tipo_dir.Enabled = false;
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

        private void btn_cancelar4_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
        }

        private void btn_modificar6_Click(object sender, EventArgs e)
        {
            LIMPIAR_CLASE();
            CARGAR_CLASE0();
            //btn_guardar5.Visible = false;
            //btn_mod4.Visible = true;
            Panel4.Visible = true;
            cbo_clase.Enabled = false;
            cbo_cat.Focus();
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

        private void btn_cancelar5_Click(object sender, EventArgs e)
        {
            Panel4.Visible = false;
        }
    }
}
