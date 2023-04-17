using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PUNTO_COBRANZA_GENERAR : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string boton;
        int fila; string ultimo_codigo;
        puntoCobranzaBLL pcoBLL = new puntoCobranzaBLL();
        puntoCobranzaTo pcoTo = new puntoCobranzaTo();
        zonasEmpresaBLL zonBLL = new zonasEmpresaBLL();
        zonasEmpresaTo zonTo = new zonasEmpresaTo();
        public PUNTO_COBRANZA_GENERAR(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
        }

        private void PUNTO_COBRANZA_GENERAR_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            CARGAR_SUCURSAL();
            //CARGAR_CANAL_DSCTO();
            CARGAR_SECTORISTA();
            CARGAR_INSTITUCIONES();
            CARGAR_CONVENIO();
            cargaSituacion();
            cargaPais();
            CARGA_FORMATOS();
            DATAGRID();
            CARGAR_TIPO_PLANILLA();
            btn_nuevo.Select();
        }
        private void CARGAR_TIPO_PLANILLA()
        {
            var planilla = new[] {  new { val = "DESCUENTO", cod = "P" },
                                    new { val = "DIRECTA", cod = "D" }};

            cbo_tipo_pla.ValueMember = "cod";
            cbo_tipo_pla.DisplayMember = "val";
            cbo_tipo_pla.DataSource = planilla;
            cbo_tipo_pla.SelectedIndex = -1;

        }
        private void CARGA_FORMATOS()
        {
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TDEFO";
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cbo_formato.ValueMember = "Codigo";
            cbo_formato.DisplayMember = "Descripción";
            cbo_formato.DataSource = dt;
            cbo_formato.SelectedIndex = 0;
        }
        private void DATAGRID()
        {
            lbl_nro_reg.Text = "Nro de Registros : 0";
            DataTable dt = pcoBLL.obtenerTodosPuntosCobranzaBLL();
            lbl_nro_reg.Text = "Nro de Registros : " + dt.Rows.Count.ToString();
            dgw.DataSource = dt;
            dgw.Columns["COD_PTO_COB"].HeaderText = "Cod";
            dgw.Columns["COD_PTO_COB"].Width = 40;
            dgw.Columns["DESC_PTO_COB"].HeaderText = "Punto de Cobranza";
            dgw.Columns["DESC_PTO_COB"].Width = 240;
            dgw.Columns["COD_CANAL_DSCTO"].Visible = false;
            //dgw.Columns["DESC_CANAL_DSCTO"].HeaderText = "Entidad de Descuento";
            //dgw.Columns["DESC_CANAL_DSCTO"].Width = 150;
            dgw.Columns["DESC_CANAL_DSCTO"].Visible = false;//esto ya no ingresa aqui, se hace desde el Preventa.
            dgw.Columns["TIPO_PLANILLA"].HeaderText = "Tip";
            dgw.Columns["TIPO_PLANILLA"].Width = 35;
            dgw.Columns["COD_INSTITUCION"].Visible = false;
            //dgw.Columns["DESC_INSTITUCION"].Visible = false;
            dgw.Columns["DESC_INSTITUCION"].HeaderText = "Institucion";
            dgw.Columns["DESC_INSTITUCION"].Width = 130;
            dgw.Columns["PAIS"].Visible = false;
            dgw.Columns["DEPARTAMENTO"].Visible = false;
            dgw.Columns["PROVINCIA"].Visible = false;
            dgw.Columns["DISTRITO"].Visible = false;
            dgw.Columns["DIRECCION"].Visible = false;
            dgw.Columns["SITUACION"].Visible = false;
            dgw.Columns["CONVENIO"].Visible = false;
            dgw.Columns["DIA_PRESENTACION"].Visible = false;
            dgw.Columns["STATUS_CONSOLIDADO"].HeaderText = "Pro";
            dgw.Columns["STATUS_CONSOLIDADO"].Width = 35;
            dgw.Columns["STATUS_CONSOLIDADO_INFORMATIVO"].HeaderText = "Inf";
            dgw.Columns["STATUS_CONSOLIDADO_INFORMATIVO"].Width = 35;
            dgw.Columns["COD_SECTORISTA"].Visible = false;
            dgw.Columns["COD_FORMATO"].Visible = false;
            dgw.Columns["COD_SUCURSAL"].Visible = false;
            dgw.Columns["DESC_SUCURSAL"].Visible = false;
            dgw.Columns["COD_ZONA"].Visible = false;
            ultimo_codigo = dgw.Rows[dgw.Rows.Count - 1].Cells["COD_PTO_COB"].Value.ToString();
        }
        private void CARGAR_CONVENIO()
        {
            //pcoTo.STATUS_CONSOLIDADO = false;
            //DataTable dt = pcoBLL.obtenerPuntosCobranzaBLL(pcoTo);
            //cboconvenio.ValueMember = "COD_PTO_COB";
            //cboconvenio.DisplayMember = "DESC_PTO_COB";
            //cboconvenio.DataSource = dt;
            var sConvenio = new[] { new {cod="SI",val="SI" },
                                    new {cod="NO",val="NO" }
                                    };
            cboconvenio.ValueMember = "cod";
            cboconvenio.DisplayMember = "val";
            cboconvenio.DataSource = sConvenio;
        }
        private void cargaSituacion()
        {
            //multiUsoBLL mulBLL = new multiUsoBLL();
            //multiUsoTo mulTo = new multiUsoTo();
            //mulTo.COD_GRUPO = "08";//SITUACION - ESTRUCTURA
            //DataTable dt = mulBLL.obtenerTablaPorGrupoBLL(mulTo);
            //cbosituacion.ValueMember = "COD_SUBGRUPO";
            //cbosituacion.DisplayMember = "DES_SUBGRUPO";
            //cbosituacion.DataSource = dt;
            directorioBLL dirBLL = new directorioBLL();
            directorioTo dirTo = new directorioTo();
            dirTo.TABLA_COD = "TSITUACION";//TABLA DE CARGOS DE CLIENTES
            DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cbosituacion.ValueMember = "Codigo";
            cbosituacion.DisplayMember = "Descripción";
            cbosituacion.DataSource = dt;
        }
        private void CARGAR_INSTITUCIONES()
        {
            institucionesBLL insBLL = new institucionesBLL();
            DataTable dtInst = insBLL.obtenerInstitucionesBLL();
            cboinst.ValueMember = "COD_INST";
            cboinst.DisplayMember = "DESC_INST";
            cboinst.DataSource = dtInst;
        }
        private void CARGAR_SUCURSAL()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbosucursal.ValueMember = "COD_SUCURSAL";
            cbosucursal.DisplayMember = "DESC_sucursal";
            cbosucursal.DataSource = dt;
            cbosucursal.SelectedIndex = -1;
        }
        //SE QUITO EL CANAL DE DESCUENTO, SE AGREGA MANUALMENTE DESDE LA CREACION DEL CONTRATO
        //private void CARGAR_CANAL_DSCTO()
        //{
        //    canalDescuentoBLL cdscBLL = new canalDescuentoBLL();
        //    DataTable dt = cdscBLL.ObtenerCanalDescuentoBLL();
        //    cbocanaldesc.ValueMember = "COD_CANAL_DSCTO";
        //    cbocanaldesc.DisplayMember = "DESCRIPCION";
        //    cbocanaldesc.DataSource = dt;
        //}
        private void cargaPais()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerPaisBLL();
            cbopais.ValueMember = "COD_PAIS";
            cbopais.DisplayMember = "DESC_PAIS";
            cbopais.DataSource = dt;
        }
        private void CARGAR_SECTORISTA()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dtEqc = prnBLL.obtenerSectoristasparaCrearEqCobradoresBLL("01");//02 Cobradores
            cbo_sectorista.ValueMember = "COD_EQCOB";
            cbo_sectorista.DisplayMember = "DESC_EQVTA";
            cbo_sectorista.DataSource = dtEqc;
        }
        private void PUNTO_COBRANZA_GENERAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void Limpiar()
        {
            txtcod.Text = "";
            //cbocanaldesc.SelectedIndex = -1;
            cboinst.SelectedIndex = -1;
            txtptocob.Text = "";
            cbo_tipo_pla.SelectedIndex = -1;
            cbopais.SelectedIndex = -1;
            cbodep.SelectedIndex = -1;
            cboprov.SelectedIndex = -1;
            cbodist.SelectedIndex = -1;
            cbopais.SelectedValue = "9589";
            cbodep.SelectedValue = "15";
            cboprov.SelectedValue = "01";
            cargaDistritos();
            txt_dir.Text = "";
            cbosituacion.SelectedIndex = -1;
            cboconvenio.SelectedIndex = -1;
            txtplanilla.Text = "";
            chbconsolidado.Checked = true;
            chb_st_inf.Checked = false;
            cbo_sectorista.SelectedIndex = -1;
            cbosucursal.SelectedIndex = -1;
            cbo_zonas.SelectedIndex = -1;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //txtcod.Text = (dgw.Rows.Count + 1).ToString().PadLeft(3,'0');
            txtcod.Text = (Convert.ToInt32(ultimo_codigo) + 1).ToString().PadLeft(3, '0');
            TabControl1.SelectedTab = TabPage2;
            cbosucursal.Select();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            int i = dgw.CurrentRow.Index;
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();
            CargarDatos();
            //txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            //cbocanaldesc.Select();
            cboinst.Select();
        }

        private void CargarDatos()
        {
            int idx = dgw.CurrentRow.Index;
            txtcod.Text = dgw.Rows[idx].Cells["COD_PTO_COB"].Value.ToString();
            //cbocanaldesc.SelectedValue = dgw.Rows[idx].Cells["COD_CANAL_DSCTO"].Value;
            cboinst.SelectedValue = dgw.Rows[idx].Cells["COD_INSTITUCION"].Value;
            cbosucursal.SelectedValue = dgw.Rows[idx].Cells["COD_SUCURSAL"].Value;
            txtptocob.Text = dgw.Rows[idx].Cells["DESC_PTO_COB"].Value.ToString();
            cbopais.SelectedValue = dgw.Rows[idx].Cells["PAIS"].Value;
            cbodep.SelectedValue = dgw.Rows[idx].Cells["DEPARTAMENTO"].Value;
            cboprov.SelectedValue = dgw.Rows[idx].Cells["PROVINCIA"].Value;
            cbodist.SelectedValue = dgw.Rows[idx].Cells["DISTRITO"].Value;
            txt_dir.Text = dgw.Rows[idx].Cells["DIRECCION"].Value.ToString();
            cbosituacion.SelectedValue = dgw.Rows[idx].Cells["SITUACION"].Value;
            cboconvenio.SelectedValue = dgw.Rows[idx].Cells["CONVENIO"].Value;
            txtplanilla.Text = dgw.Rows[idx].Cells["DIA_PRESENTACION"].Value.ToString();
            chbconsolidado.Checked = Convert.ToBoolean(dgw.Rows[idx].Cells["STATUS_CONSOLIDADO"].Value);
            chb_st_inf.Checked = Convert.ToBoolean(dgw.Rows[idx].Cells["STATUS_CONSOLIDADO_INFORMATIVO"].Value);
            cbo_sectorista.SelectedValue = chbconsolidado.Checked ? dgw.Rows[idx].Cells["COD_SECTORISTA"].Value : "";
            cbo_formato.SelectedValue = chbconsolidado.Checked ? dgw.Rows[idx].Cells["COD_FORMATO"].Value : "";
            cbo_tipo_pla.SelectedValue = dgw.Rows[idx].Cells["TIPO_PLANILLA"].Value;
            cbo_zonas.SelectedValue = dgw.Rows[idx].Cells["COD_ZONA"].Value;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaAdicionar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pcoTo.COD_PTO_COB = txtcod.Text.Trim();
                pcoTo.DESC_PTO_COB = txtptocob.Text;
                pcoTo.COD_CANAL_DSCTO = ""; //cbocanaldesc.SelectedValue.ToString();
                pcoTo.DESC_CANAL_DSCTO = ""; //cbocanaldesc.Text;
                pcoTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                pcoTo.DESC_INSTITUCION = cboinst.Text;
                pcoTo.PAIS = cbopais.SelectedValue.ToString();
                pcoTo.DEPARTAMENTO = cbodep.SelectedValue.ToString();
                pcoTo.PROVINCIA = cboprov.SelectedValue.ToString();
                pcoTo.DISTRITO = cbodist.SelectedValue.ToString();
                pcoTo.DIRECCION = txt_dir.Text;
                pcoTo.CONVENIO = cboconvenio.SelectedValue.ToString();
                pcoTo.SITUACION = cbosituacion.SelectedValue.ToString();
                pcoTo.DIA_PRESENTACION = txtplanilla.Text;
                pcoTo.STATUS_CONSOLIDADO = chbconsolidado.Checked;
                pcoTo.STATUS_CONSOLIDADO_INFORMATIVO = chb_st_inf.Checked;
                pcoTo.COD_SECTORISTA = chbconsolidado.Checked ? cbo_sectorista.SelectedValue.ToString() : "";
                pcoTo.COD_FORMATO = chbconsolidado.Checked ? cbo_formato.SelectedValue.ToString() : "";
                pcoTo.COD_SUCURSAL = cbosucursal.SelectedValue.ToString();
                pcoTo.DESC_SUCURSAL = cbosucursal.Text;
                pcoTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                pcoTo.COD_ZONA = cbo_zonas.SelectedValue.ToString();

                if (!pcoBLL.insertarPuntoCobranzaBLL(pcoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Cobranza se creo correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (pcoTo.SITUACION == "01")
                        CARGAR_CONVENIO();
                    DATAGRID();
                    TabControl1.SelectedTab = TabPage1;
                    FOCO_NUEVO_REG2(txtcod.Text.Trim());
                    //btn_nuevo.Select();
                }
            }

            //dgw.Rows.Add(txtcod.Text, txtptocob.Text, cboinst.Text, txtplanilla.Text,chbconsolidado.Checked);
            //TabControl1.SelectedTab = TabPage1;
            //btn_nuevo.Select();
        }
        private bool validaAdicionar()
        {
            bool result = true;
            if (txtcod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Codigo !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcod.Focus();
                return result = false;
            }
            if (cbosucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbosucursal.Focus();
                return result = false;
            }
            //if(cbocanaldesc.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Elija el Canal de Descuento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cbocanaldesc.Focus();
            //    return result = false;
            //}
            if (cboinst.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Institucion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboinst.Focus();
                return result = false;
            }
            if (cbo_tipo_pla.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Tipo de Planilla !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_tipo_pla.Focus();
                return result = false;
            }
            if (txtptocob.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Punto de Cobranza !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtptocob.Focus();
                return result = false;
            }
            if (cbopais.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Pais !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbopais.Focus();
                return result = false;
            }
            if (cbodep.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Departamento !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbodep.Focus();
                return result = false;
            }
            if (cboprov.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Provincia !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboprov.Focus();
                return result = false;
            }
            if (cboconvenio.SelectedIndex == -1)
            {
                MessageBox.Show("Elija si tiene Convenio !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboconvenio.Focus();
                return result = false;
            }
            if (cbosituacion.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Situacion !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbosituacion.Focus();
                return result = false;
            }
            if (cbodist.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Distrito !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbodist.Focus();
                return result = false;
            }
            if (cbo_zonas.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Zona !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_zonas.Focus();
                return result = false;
            }
            if (chbconsolidado.Checked)
            {
                if (cbo_sectorista.SelectedIndex == -1)
                {
                    MessageBox.Show("Elija el Sectorista !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_sectorista.Focus();
                    return result = false;
                }
            }
            if (btn_guardar.Visible)
            {
                pcoTo.COD_PTO_COB = txtcod.Text;
                if (pcoBLL.verificaPuntoCobranzaBLL(pcoTo) > 0)
                {
                    MessageBox.Show("El Codigo ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcod.Focus();
                    return result = false;
                }
            }
            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaAdicionar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pcoTo.COD_PTO_COB = txtcod.Text.Trim();
                pcoTo.DESC_PTO_COB = txtptocob.Text;
                pcoTo.COD_CANAL_DSCTO = "";// cbocanaldesc.SelectedValue.ToString();
                pcoTo.DESC_CANAL_DSCTO = "";// cbocanaldesc.Text;
                pcoTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                pcoTo.DESC_INSTITUCION = cboinst.Text;
                pcoTo.PAIS = cbopais.SelectedValue.ToString();
                pcoTo.DEPARTAMENTO = cbodep.SelectedValue.ToString();
                pcoTo.PROVINCIA = cboprov.SelectedValue.ToString();
                pcoTo.DISTRITO = cbodist.SelectedValue.ToString();
                pcoTo.DIRECCION = txt_dir.Text;
                pcoTo.SITUACION = cbosituacion.SelectedValue != null ? cbosituacion.SelectedValue.ToString() : "";
                pcoTo.CONVENIO = pcoTo.SITUACION != "" ? (pcoTo.SITUACION == "01" ? cboconvenio.SelectedValue.ToString() : "") : "";
                pcoTo.DIA_PRESENTACION = txtplanilla.Text;
                pcoTo.STATUS_CONSOLIDADO = chbconsolidado.Checked;
                pcoTo.STATUS_CONSOLIDADO_INFORMATIVO = chb_st_inf.Checked;
                pcoTo.COD_SECTORISTA = chbconsolidado.Checked ? cbo_sectorista.SelectedValue.ToString() : "";
                pcoTo.COD_FORMATO = chbconsolidado.Checked ? cbo_formato.SelectedValue.ToString() : "";
                pcoTo.COD_SUCURSAL = cbosucursal.SelectedValue.ToString();
                pcoTo.DESC_SUCURSAL = cbosucursal.Text;
                pcoTo.TIPO_PLANILLA = cbo_tipo_pla.SelectedValue.ToString();
                pcoTo.COD_ZONA = cbo_zonas.SelectedValue.ToString();

                if (!pcoBLL.modificarPuntoCobranzaBLL(pcoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Cobranza se modifico correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    TabControl1.SelectedTab = TabPage1;
                    //btn_nuevo.Select();
                    FOCO_NUEVO_REG2(txtcod.Text.Trim());
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
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Punto de Cobranza ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                pcoTo.COD_PTO_COB = dgw.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();//txtcod.Text.Trim();
                pcoTo.STATUS_CONSOLIDADO = Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO"].Value);

                if (!pcoBLL.eliminarPuntoCobranzaBLL(pcoTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El punto de Cobranza se elimino correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DATAGRID();
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
            //dgw.Rows.RemoveAt(dgw.CurrentRow.Index);
        }
        private bool validaEliminar()
        {
            bool result = true;
            string errMensaje = "";

            pcoTo.COD_PTO_COB = dgw.CurrentRow.Cells[0].Value.ToString();
            if (pcoBLL.validaHistoricoPedidoBLL(pcoTo, ref errMensaje))
            {
                MessageBox.Show("No se puede Eliminar \nEste Punto de Cobranza ya tiene Historico !!!", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            else
            {
                if (errMensaje != "")
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
            }
            return result;
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
                    if (dgw.Rows.Count == 0)
                    {


                    }
                    else
                        CargarDatos();


                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();

        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_rs.Checked)
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
        private void chbconsolidado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbconsolidado.Checked)
            {
                chbconsolidado.Checked = true;
                cbo_sectorista.SelectedIndex = -1;
                cbo_sectorista.Enabled = true;
                cbo_formato.SelectedIndex = 0;
                cbo_formato.Enabled = true;
            }
            //else
            //{
            //    cbo_sectorista.SelectedIndex = -1;
            //    cbo_sectorista.Enabled = false;
            //    cbo_formato.SelectedIndex = -1;
            //    cbo_formato.Enabled = false;
            //}
            chbconsolidado.Checked = true;
        }

        private void cbopais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589")
                    cargaDepartamentos();
                else
                {
                    cbodep.SelectedIndex = -1;
                    cboprov.SelectedIndex = -1;
                    cbodist.SelectedIndex = -1;
                }
            }
        }
        private void cargaDepartamentos()
        {
            HelpersBLL helBLL = new HelpersBLL();
            DataTable dt = helBLL.obtenerDepartamentoBLL();
            cbodep.ValueMember = "COD_DEP";
            cbodep.DisplayMember = "DESC_DEP";
            cbodep.DataSource = dt;
        }

        private void cbodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589" && cbodep.SelectedValue != null)
                    cargaProvincias();
                else
                    cbodep.SelectedIndex = -1;
            }
        }
        private void cargaProvincias()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = cbodep.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerPro_PaisBLL(helTo);
            cboprov.ValueMember = "COD_PRO";
            cboprov.DisplayMember = "DESC_PRO";
            cboprov.DataSource = dt;
        }

        private void cboprov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbopais.SelectedValue != null)
            {
                if (cbopais.SelectedValue.ToString() == "9589" && cbodep.SelectedValue != null && cboprov.SelectedValue != null)
                    cargaDistritos();
                else
                    cbodep.SelectedIndex = -1;
            }
        }
        private void cargaDistritos()
        {
            HelpersBLL helBLL = new HelpersBLL();
            HelpersTo helTo = new HelpersTo();
            helTo.CODIGO = cbodep.SelectedValue.ToString();
            helTo.CODIGO2 = cboprov.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerDist_Pro_PaisBLL(helTo);
            cbodist.ValueMember = "COD_DIST";
            cbodist.DisplayMember = "DESC_DIST";
            cbodist.DataSource = dt;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Vincular_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO"].Value) || Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO_INFORMATIVO"].Value))
            {
                int opk = 0;
                //if (Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO"].Value))
                //    opk = 1;
                if (Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO_INFORMATIVO"].Value))
                    opk = 2;
                else if (Convert.ToBoolean(dgw.CurrentRow.Cells["STATUS_CONSOLIDADO"].Value))
                    opk = 1;
                string cod = dgw.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                string cod_institucion = dgw.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString();
                PUNTO_COBRANZA_CONSOLIDADOS frm = new PUNTO_COBRANZA_CONSOLIDADOS(cod, cod_institucion, opk);
                frm.ShowDialog();
            }
        }

        private void cboinst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboinst.SelectedValue != null)
            {
                zonTo.COD_INSTITUCION = cboinst.SelectedValue.ToString();
                DataTable dt = zonBLL.obtenerZonasEmpresaBLL(zonTo);
                if (dt.Rows.Count > 0)
                {
                    cbo_zonas.ValueMember = "COD_ZONA";
                    cbo_zonas.DisplayMember = "DESC_ZONA";
                    cbo_zonas.DataSource = dt;
                    cbo_zonas.SelectedIndex = -1;
                }
            }
        }
    }
}
