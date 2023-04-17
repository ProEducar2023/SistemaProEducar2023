using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_ALM
{
    public partial class NOTA_SALIDAS : Form
    {
        public string ST_SERIE, STATUS_PARTE, COD_ARTICULO, ST_COSTOS, STATUS_AREA;
        string COD_DH, BOTON, COD_CLASE;
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        decimal igv0;
        DateTime FECHA_INI, FECHA_GRAL;
        DataTable DT00 = new DataTable();
        DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        inventariosBLL invBLL = new inventariosBLL();
        inventariosTo invTo = new inventariosTo();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        movimientosBLL movBLL = new movimientosBLL();
        movimientosTo movTo = new movimientosTo();
        movimientoSerieBLL mosBLL = new movimientoSerieBLL();
        movimientoSerieTo mosTo = new movimientoSerieTo();
        serieDocumentoBLL srdBLL = new serieDocumentoBLL();
        serieDocumentosTo srdTo = new serieDocumentosTo();
        articulosBLL artBLL = new articulosBLL();
        articulosTo artTo = new articulosTo();
        string NOMBRE_PC = System.Environment.MachineName;
        public NOTA_SALIDAS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void NOTA_SALIDAS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_PERSONAS();
            CARGAR_MOVIMIENTO();
            CARGAR_PERSONAS_PERSONAL();
            DIRECTORIO_CONFIGURACION();//VAMOS A VER SI EN EL FUTURO SE USA NO LO SÈ AÙN
            COD_DH = "H";
            EstadoEnabledAnular();
            igv0 = helBLL.obtenerImpuestoBLL("IGV");
            DT00.Columns.Add("sucursal");
            DT00.Columns.Add("Clase");
            DT00.Columns.Add("Cod_per");
            DT00.Columns.Add("COD_DOC");
            DT00.Columns.Add("NRO_DOC_INV");
            DT00.Columns.Add("Fe_año");
            DT00.Columns.Add("Fe_mes");
            DT00.Columns.Add("Item");
            DT00.Columns.Add("Item2");
            DT00.Columns.Add("Articulo");
            DT00.Columns.Add("Cantidad");
            DT00.Columns.Add("Cantidad_anul");
            DT00.Columns.Add("COD_D_H");
            DT00.Columns.Add("COD_MONEDA");
            DT00.Columns.Add("COD_ALMACEN");
            DT00.Columns.Add("Precio_Unit");
            DT00.Columns.Add("Valor_COmpra");
            DT00.Columns.Add("Por_igv");
            DT00.Columns.Add("Por_Dscto");
            DT00.Columns.Add("Status_igv");
            DT00.Columns.Add("Valor_IGV");
            DT00.Columns.Add("Valor_Dscto");
            DT00.Columns.Add("Ajuste_igv");
            DT00.Columns.Add("Ajuste_Bi");
            DT00.Columns.Add("COD_AREA");
            DT00.Columns.Add("STATUS_FACT");
            DT00.Columns.Add("Nombre_pc");
            DT00.Columns.Add("NRO_PEDIDO");//*****************
            DT00.Columns.Add("FECHA_PEDIDO");//******************
            DT00.Columns.Add("OBSERVACION");

            btn_nuevo.Focus();
        }
        private void EstadoEnabledAnular()
        {
            dirTo.TABLA_COD = "ELIBOT";
            dirTo.CODIGO = "TDEFA";
            btn_eliminar.Enabled = dirBLL.DIR_TABLA_DESC(dirTo) != "SI" ? true : false;
        }
        private void DIRECTORIO_CONFIGURACION()
        {
            string FECHA_DIR = "", SUC_DIR = "", CLASE_DIR = "";

            dirTo.CODIGO = "FECHA_DIR";
            dirTo.TABLA_COD = "TDEFC";
            FECHA_DIR = dirBLL.DIR_TABLA_DESC(dirTo);
            dtp_inv.Enabled = FECHA_DIR == "SI" ? false : true;
            dirTo.CODIGO = "SUCURSAL";
            dirTo.TABLA_COD = "TDEFC";
            SUC_DIR = dirBLL.DIR_TABLA_DESC(dirTo);

            dirTo.CODIGO = "CALMINV";
            dirTo.TABLA_COD = "TDEFC";
            CLASE_DIR = dirBLL.DIR_TABLA_DESC(dirTo);
            cbo_clase.Text = CLASE_DIR != "" ? CLASE_DIR : "";
        }
        private void CARGAR_PERSONAS_PERSONAL()
        {
            //cbo_elab.Items.Clear();
            personalBLL perBLL = new personalBLL();
            DataTable dt = perBLL.obtenerPersonalparaInventarioBLL();
            cbo_elab.ValueMember = "COD_PER";
            cbo_elab.DisplayMember = "DESC_PER";
            cbo_elab.DataSource = dt;
            cbo_elab.SelectedIndex = -1;
        }
        private void DATAGRID()
        {
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            invTo.TIPO_USU = TIPO_USU;
            invTo.COD_USU = COD_USU;
            DataTable dt = invBLL.obtenerMostrar_Nota_Salida_BLL(invTo);
            dgw1.DataSource = dt;
        }
        private void CARGAR_SUCURSAL()
        {
            //string COD_USU = "0000";
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            cbo_sucursal.SelectedIndex = -1;
        }
        private void CARGAR_PERSONAS()
        {
            DataTable dt = helBLL.MOSTRAR_PERSONAS_XPAGAR_BLL();
            dgw_per.DataSource = dt;

        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosparaInventarioSalidaBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = -1;
        }
        private void CARGAR_CLASE()
        {
            //string TIPO_USU = "MS";
            //string COD_USU = "0000";
            bool validarTipo = true;
            string tipo = "P";
            bool validarDebeHaber = true;
            string debeHaber = "H";

            helTo.CODIGO = TIPO_USU;
            helTo.CODIGO2 = COD_USU;
            helTo.CODIGO3 = validarTipo == true ? "0" : "1";
            helTo.CODIGO4 = tipo;
            helTo.CODIGO5 = validarDebeHaber == true ? "0" : "1";
            helTo.CODIGO6 = debeHaber;
            DataTable dt = helBLL.CBO_CLASE_USU_TIPO_BLL(helTo);
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = -1;
        }
        private void NOTA_SALIDAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLES();
            btn_mod.Visible = true;
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            cbo_sucursal.Focus();
        }
        private void LIMPIAR_CABECERA()
        {
            cbo_sucursal.SelectedIndex = -1;
            cbo_clase.SelectedIndex = -1;
            TXT_COD.Clear();
            TXT_DESC.Clear();
            txt_doc_per.Clear();
            TXT_NI.Clear();
            txt_obs.Clear();
            txt_obs.Enabled = true;
            Panel_PER.Visible = false;
            gb_cab.Enabled = true;
            DGW_DET.Rows.Clear();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel1.Enabled = true;
            dtp_inv.Value = DateTime.Now;
            cbo_elab.SelectedIndex = -1;
        }
        private void LIMPIAR_DETALLES()
        {
            txt_um.Clear();
            btn_consulta.Enabled = true;
            TXT_COD_PRO.Enabled = true;
            TXT_DESC_PRO.Enabled = true;
            TXT_NRO_PARTE.Enabled = true;
            txt_cant.Enabled = true;
            CBO_ALMACEN.Enabled = true;
            //txt_req.Clear();
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            txt_cant.Text = "0.00";
            Panel_PRO.Visible = false;
        }

        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex != -1)
            {
                COD_CLASE = cbo_clase.SelectedValue.ToString();
                CARGAR_PRODUCTOS();
                if (cbo_sucursal.SelectedIndex != -1)
                    CARGAR_ALMACEN();
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL artclaBLL = new articuloClaseBLL();
            articuloClaseTo artclaTo = new articuloClaseTo();
            artclaTo.COD_CLASE = COD_CLASE;
            DataTable dt = artclaBLL.MOSTRAR_DGW_ARTICULOS_CLASE_GRUPO_BLL(artclaTo);
            DGW_PRO.DataSource = dt;
        }
        private void CARGAR_ALMACEN()
        {
            almacenesBLL almBLL = new almacenesBLL();
            almacenTo almTo = new almacenTo();
            almTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            almTo.COD_CLASE = COD_CLASE;
            CBO_ALMACEN.DataSource = null;
            DataTable dt = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
            CBO_ALMACEN.DataSource = dt;
            CBO_ALMACEN.ValueMember = "COD_ALMACEN";
            CBO_ALMACEN.DisplayMember = "DESC_CORTA";
        }

        private void TXT_COD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_COD.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[0, i].Value.ToString().Length >= TXT_COD.TextLength)
                        {
                            if (TXT_COD.Text.ToLower() == dgw_per[0, i].Value.ToString().ToLower().Substring(0, TXT_COD.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TXT_DESC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_DESC.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[1, i].Value.ToString().Length >= TXT_DESC.TextLength)
                        {
                            if (TXT_DESC.Text.ToLower() == dgw_per[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }

                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txt_doc_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_doc_per.Text.Trim() != "")
            {
                if (dgw_per.Rows.Count > 0)
                {
                    dgw_per.Sort(dgw_per.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = dgw_per.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (dgw_per[2, i].Value.ToString().Length >= txt_doc_per.TextLength)
                        {
                            if (txt_doc_per.Text.ToLower() == dgw_per[2, i].Value.ToString().ToLower().Substring(0, txt_doc_per.TextLength))
                            {
                                dgw_per.CurrentCell = dgw_per.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per.CurrentCell = dgw_per.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PER.Visible = true;
                    dgw_per.Visible = true;
                    Panel_PER.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Persona X Pagar !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgw_per_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per.CurrentRow.Index;
                TXT_COD.Text = dgw_per[0, idx].Value.ToString();
                TXT_DESC.Text = dgw_per[1, idx].Value.ToString();
                txt_doc_per.Text = dgw_per[2, idx].Value.ToString();
                Panel_PER.Visible = false;
                k.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PER.Visible = false;
                TXT_COD.Clear();
                TXT_DESC.Clear();
                txt_doc_per.Clear();
                TXT_COD.Focus();
            }
        }

        private void TXT_DESC_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_DESC_PRO.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = DGW_PRO.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (DGW_PRO[1, i].Value.ToString().Length >= TXT_DESC_PRO.TextLength)
                        {
                            if (TXT_DESC_PRO.Text.ToLower() == DGW_PRO[1, i].Value.ToString().ToLower().Substring(0, TXT_DESC_PRO.TextLength))
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }

                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PRO.Visible = true;
                    Panel_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void TXT_NRO_PARTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_NRO_PARTE.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = DGW_PRO.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (DGW_PRO[2, i].Value.ToString().Length >= TXT_NRO_PARTE.TextLength)
                        {
                            if (TXT_NRO_PARTE.Text.ToLower() == DGW_PRO[2, i].Value.ToString().ToLower().Substring(0, TXT_NRO_PARTE.TextLength))
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }

                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PRO.Visible = true;
                    Panel_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (!validaAgregar())
                return;

            movTo.COD_MOV = cbo_mov.SelectedValue.ToString();
            ST_COSTOS = movBLL.HALLAR_STATUS_COSTOS_BLL(movTo);
            LIMPIAR_DETALLES0();
            gb_cab.Enabled = false;
            btn_guardar2.Visible = true;
            btn_mod2.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
            TXT_COD_PRO.Focus();
        }
        private void LIMPIAR_DETALLES0()
        {
            if (ST_COSTOS == "1")
            {
                txt_pu.Enabled = true;
                Label20.Visible = true;
                txt_vc.Visible = true;
            }

            else
            {
                txt_pu.Clear();
                txt_pu.Text = "0.000";
                txt_pu.Enabled = false;
                Label20.Visible = false;
                txt_vc.Visible = false;
            }
            txt_um.Clear();
            btn_consulta.Enabled = true;
            TXT_COD_PRO.Enabled = true;
            TXT_DESC_PRO.Enabled = true;
            TXT_NRO_PARTE.Enabled = true;
            txt_cant.Enabled = true;
            CBO_ALMACEN.Enabled = true;
            TXT_COD_PRO.Clear();
            TXT_DESC_PRO.Clear();
            TXT_NRO_PARTE.Clear();
            txt_cant.Text = "0.00";
            txt_pu.Text = "0.000";
            txt_vc.Text = "";
            txt_um.Text = "";
            //txt_req.Clear();
            //'txt_nro_req.Text = ""
            //'CBO_AREA.SelectedIndex = -1
            Panel_PRO.Visible = false;
            obs.txt_obs.Clear();
        }
        private bool validaAgregar()
        {
            bool result = true;
            string mss = "";
            if (cbo_mov.SelectedIndex == -1)
            {
                MessageBox.Show("Eliga un Tipo de Movimiento", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mov.Focus();
                return result = false;
            }
            if (cbo_sucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Eliga la SUCURSAL", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex == -1)
            {
                MessageBox.Show("Eliga la CLASE DE ARTICULO", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (TXT_COD.Text.Trim() == "")
            {
                MessageBox.Show("Eliga un Solicitante", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD.Focus();
                return result = false;
            }
            if (Panel_PER.Visible)
            {
                MessageBox.Show("Eliga un Solicitante", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgw_per.Focus();
                return result = false;
            }
            if (cbo_ni.SelectedIndex == -1 && BOTON == "NUEVO")
            {
                MessageBox.Show("Debe elegir el Nro de Serie", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ni.Focus();
                return result = false;
            }
            if (txt_numero.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese en Nroº Nota de Salida", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ni.Focus();
                return result = false;
            }
            if (HelpersBLL.VALIDAR_FECHA(dtp_inv.Value, FECHA_GRAL, FECHA_INI, ref mss) == "0")
            {
                MessageBox.Show(mss, "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_inv.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            ITEM.Text = DGW_DET.CurrentRow.Index.ToString();
            btn_guardar2.Visible = false;
            btn_mod2.Visible = true;
            LIMPIAR_DETALLES();
            btn_consulta.Enabled = false;
            TXT_COD_PRO.Enabled = false;
            TXT_DESC_PRO.Enabled = false;
            TXT_NRO_PARTE.Enabled = false;
            txt_cant.Enabled = false;
            CBO_ALMACEN.Enabled = false;
            CARGAR_DETALLE1();
            Panel1.Visible = false;
            Panel2.Visible = true;
            //txt_req.Focus();
        }
        private void CARGAR_DETALLE1()
        {
            TXT_COD_PRO.Text = DGW_DET[1, DGW_DET.CurrentRow.Index].Value.ToString();
            TXT_DESC_PRO.Text = DGW_DET[2, DGW_DET.CurrentRow.Index].Value.ToString();
            Panel_PRO.Visible = false;
            txt_cant.Text = DGW_DET[3, DGW_DET.CurrentRow.Index].Value.ToString();
            //COD_ALMACEN = DGW_DET[4, DGW_DET.CurrentRow.Index].Value.ToString();
            CBO_ALMACEN.SelectedValue = DGW_DET[4, DGW_DET.CurrentRow.Index].Value;
            //COD_ORD = DGW_DET[6, DGW_DET.CurrentRow.Index].Value.ToString();
            //txt_nro_req.Text = COD_ORD;
            //txt_des_or.Text = OBJ.DESC_ORD(COD_ORD, con00, AÑO, MES)
            //CBO_AREA.Text = DGW_DET.Item(10, DGW_DET.CurrentRow.Index).Value
            //COD_MAQ = DGW_DET.Item(11, DGW_DET.CurrentRow.Index).Value
            //CBO_MAQ.Text = DGW_DET.Item(12, DGW_DET.CurrentRow.Index).Value
            //CBO_PARTE.Text = DGW_DET.Item(14, DGW_DET.CurrentRow.Index).Value
            TXT_NRO_PARTE.Text = DGW_DET[6, DGW_DET.CurrentRow.Index].Value.ToString();
            //TXT_SERIE.Text = DGW_DET.Item(20, DGW_DET.CurrentRow.Index).Value
            //COD_PROY = DGW_DET.Item(17, DGW_DET.CurrentRow.Index).Value
            //COD_ACT = DGW_DET.Item(8, DGW_DET.CurrentRow.Index).Value
            //cbo_act.Text = OBJ.DESC_ACTIVIDAD(COD_ACT, con00)
            //txt_req.Text = DGW_DET[18, DGW_DET.CurrentRow.Index].Value.ToString();
            obs.txt_obs.Text = DGW_DET[7, DGW_DET.CurrentRow.Index].Value.ToString();
            txt_um.Text = DGW_DET[8, DGW_DET.CurrentRow.Index].Value.ToString();
            //TXT_SERIE.Text = DGW_DET.Item(20, DGW_DET.CurrentRow.Index).Value
            txt_pu.Text = DGW_DET[9, DGW_DET.CurrentRow.Index].Value.ToString();
            txt_vc.Text = DGW_DET[10, DGW_DET.CurrentRow.Index].Value.ToString();
            //ST_SERIE = OBJ.HALLAR_STATUS_SERIE_ARTICULO(TXT_COD_PRO.Text);
            //btn_serie.Enabled = IIf(ST_SERIE = "1", True, False)

        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
        }

        private void cbo_mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mov.SelectedIndex != -1)
            {
                txt_numero.Clear();
                //COD_MOV = OBJ.COD_MOV(cbo_mov.Text);
                //CARGAR_STATUS();
                if (cbo_sucursal.SelectedIndex != -1)
                    CARGAR_NRO_SALIDA();
            }
        }
        private void CARGAR_NRO_SALIDA()
        {
            cbo_ni.DataSource = null;
            mosTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            mosTo.COD_MOV = cbo_mov.SelectedValue.ToString();
            mosTo.STATUS_DOC = "0";
            mosTo.COD_DOC = "02";
            DataTable dt = mosBLL.CBO_NRO_MOVIMIENTO_SERIE_BLL(mosTo);
            cbo_ni.DataSource = dt;
            cbo_ni.ValueMember = "SERIE";
            cbo_ni.DisplayMember = "SERIE";
        }

        private void cbo_ni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_ni.SelectedValue != null)
            {
                if (cbo_ni.SelectedIndex != -1)
                {
                    txt_numero.Text = HALLAR_NRO_ING(cbo_ni.SelectedValue.ToString());
                }
            }

        }
        public string HALLAR_NRO_ING(string serie0)
        {
            int sr = -1;
            srdTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            srdTo.SERIE = serie0;
            srdTo.COD_DOC = "02";
            sr = srdBLL.obtenerNro_IngBLL(srdTo);
            return sr.ToString("0000000");
        }

        private void cbo_sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sucursal.SelectedIndex != -1)
            {
                cbo_ni.Enabled = true;
                if (cbo_mov.SelectedIndex != -1)
                    CARGAR_NRO_SALIDA();
                if (cbo_clase.SelectedIndex != -1)
                    CARGAR_ALMACEN();
            }
        }

        private void DGW_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TXT_COD_PRO.Text = DGW_PRO[0, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_DESC_PRO.Text = DGW_PRO[1, DGW_PRO.CurrentRow.Index].Value.ToString();
                TXT_NRO_PARTE.Text = DGW_PRO[2, DGW_PRO.CurrentRow.Index].Value.ToString();
                txt_um.Text = DGW_PRO[5, DGW_PRO.CurrentRow.Index].Value.ToString();
                ST_SERIE = DGW_PRO[4, DGW_PRO.CurrentRow.Index].Value.ToString();
                Panel_PRO.Visible = false;
                if (CBO_ALMACEN.SelectedIndex != -1)
                {
                    SALDO_PRODUCTO();
                    //txt_cant.Focus();
                }
                txt_cant.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_PRO.Visible = false;
                TXT_COD_PRO.Clear();
                TXT_DESC_PRO.Clear();
                TXT_NRO_PARTE.Clear();
                TXT_COD_PRO.Focus();
            }
        }
        private void SALDO_PRODUCTO()
        {
            string s = "0.00";
            artTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            artTo.COD_ALMACEN = CBO_ALMACEN.SelectedValue.ToString();
            artTo.COD_ARTICULO = TXT_COD_PRO.Text;
            s = artBLL.OBTENER_SALDO_BLL(artTo);
            if (s == "")
            {
                MessageBox.Show("No existe Saldo en ese Almacén", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cant.Text = "0.00";
            }
            else if (decimal.Compare(Convert.ToDecimal(s), Convert.ToDecimal(txt_cant.Text)) < 0)
            {
                MessageBox.Show("No tiene Stock", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cant.Text = s;
            }
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.ShowDialog();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            if (!validaConsulta())
                return;

            DIALOGOS.CONSULTA_SALDO_X_ARTICULO frm = new DIALOGOS.CONSULTA_SALDO_X_ARTICULO(cbo_clase.SelectedValue.ToString(), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, TIPO_USU, COD_USU);
            frm.ShowDialog();
            SendKeys.Send("{TAB}");
        }
        private bool validaConsulta()
        {
            bool result = true;
            if (cbo_clase.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir la Clase de Artículo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Debe elegir un Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible)
            {
                MessageBox.Show("Debe elegir un Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaAgregarItem())
                return;

            SALDO_PRODUCTO();
            txt_vc.Text = txt_vc.Text == "" ? "0.00" : txt_vc.Text;
            DGW_DET.Rows.Add(hallar_item(DGW_DET.Rows.Count), TXT_COD_PRO.Text, TXT_DESC_PRO.Text, txt_cant.Text, CBO_ALMACEN.SelectedValue.ToString(),
                CBO_ALMACEN.Text, TXT_NRO_PARTE.Text, obs.txt_obs.Text, txt_um.Text, txt_pu.Text, txt_vc.Text);
            LIMPIAR_DETALLES0();
            TXT_COD_PRO.Focus();
        }
        private string hallar_item(int it)
        {
            string ite = (it + 1).ToString();
            return ite.PadLeft(2, '0');
        }
        private bool validaAgregarItem()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Elija el Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
                return result = false;
            }
            if (Panel_PRO.Visible)
            {
                MessageBox.Show("Elija el Producto.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
                return result = false;
            }
            if (txt_cant.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese una Cantidad.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cant.Focus();
                return result = false;
            }
            if (CBO_ALMACEN.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elgir el Almacén.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_ALMACEN.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            LIMPIAR_DETALLES();
            Panel1.Visible = true;
            Panel2.Visible = false;
            btn_agregar.Focus();
        }

        private void txt_cant_Leave(object sender, EventArgs e)
        {
            txt_cant.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_cant.Text);
        }

        private void txt_pu_Leave(object sender, EventArgs e)
        {
            txt_pu.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_pu.Text);
            HALLAR_VALOR_VENTA();
        }
        private void HALLAR_VALOR_VENTA()
        {
            if (!(txt_cant.Text == "" || txt_pu.Text == ""))
            {
                txt_vc.Text = (Convert.ToDecimal(txt_cant.Text) * Convert.ToDecimal(txt_pu.Text)).ToString();
                txt_vc.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txt_vc.Text);
            }
        }

        private void btn_mod2_Click(object sender, EventArgs e)
        {
            if (!validaModificarItem())
                return;

            SALDO_PRODUCTO();
            int idx = DGW_DET.CurrentRow.Index;
            DGW_DET[1, idx].Value = TXT_COD_PRO.Text;
            DGW_DET[2, idx].Value = TXT_DESC_PRO.Text;
            DGW_DET[3, idx].Value = txt_cant.Text;
            DGW_DET[4, idx].Value = CBO_ALMACEN.SelectedValue.ToString();
            DGW_DET[5, idx].Value = CBO_ALMACEN.Text;
            DGW_DET[6, idx].Value = TXT_NRO_PARTE.Text;
            DGW_DET[7, idx].Value = obs.txt_obs.Text;
            DGW_DET[8, idx].Value = txt_um.Text;
            DGW_DET[9, idx].Value = txt_pu.Text;
            DGW_DET[10, idx].Value = txt_vc.Text;

            LIMPIAR_DETALLES0();
            Panel2.Visible = false;
            Panel1.Visible = true;
            btn_agregar.Focus();
        }
        private bool validaModificarItem()
        {
            bool result = true;
            if (TXT_COD_PRO.Text.Trim() == "")
            {
                MessageBox.Show("Eliga el Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TXT_COD_PRO.Focus();
            }
            if (Panel_PRO.Visible)
            {
                MessageBox.Show("Eliga el Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DGW_PRO.Focus();
            }
            if (txt_cant.Text == "")
            {
                MessageBox.Show("Ingrese una Cantidad", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cant.Focus();
            }
            if (CBO_ALMACEN.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elgir el Almacén", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_ALMACEN.Focus();
            }
            return result;
        }

        private void CBO_ALMACEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedValue != null)
            {
                if (cbo_clase.SelectedIndex != -1)
                {
                    if (TXT_COD_PRO.Text.Trim() != "")
                        SALDO_PRODUCTO();
                }
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            if (!validaAgregar())
                return;
            if (!validaGrabar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de crear un Documento de Salida ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                string COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }

                invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "02";//02 salida , 01 ingreso
                invTo.NRO_DOC_INV = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
                invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = cbo_mov.SelectedValue.ToString();
                invTo.COD_MONEDA = "S";
                invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = null;
                invTo.COD_DOC = "";
                invTo.NRO_DOC = "";
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = 0;
                invTo.STATUS_PV = "";
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_CREA = DateTime.Now;
                invTo.AREA = "";
                DT00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    DT00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), TXT_COD.Text, "02",
                        cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text, AÑO, MES, DGW_DET[0, i].Value.ToString(), DGW_DET[0, i].Value.ToString(),
                        DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, COD_DH, "S", DGW_DET[4, i].Value.ToString(), DGW_DET[9, i].Value.ToString(),
                        DGW_DET[10, i].Value.ToString(), igv0.ToString(), "0.00", "1", ((igv0 / 100) * Convert.ToDecimal(DGW_DET[10, i].Value)).ToString(), "0.00",
                        "0.00", "0.00", "", "0", NOMBRE_PC, "", DateTime.Now, DGW_DET[7, i].Value.ToString());
                    i++;
                }

                if (!invBLL.adicionaSalidaInventarioBLL(invTo, DT00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Se adiciono correctamente el Documento de Salida !!!" + errMensaje, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //xt_numero.Text = obj.HALLAR_NRO_ACTUAL(COD_SUCURSAL, "04", "0", cbo_ni.Text)
                    //gb_oc.Enabled = false;
                    //gb_DEntrega.Enabled = false;
                    DATAGRID(); FOCO_NUEVO_REG();
                    Panel1.Visible = true;
                    btn_grabar.Enabled = false;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_imprimir.Select();
                }
            }
        }
        private void FOCO_NUEVO_REG()
        {
            int i, cont = 0;
            cont = dgw1.Rows.Count - 1;
            string nrocon = cbo_ni.Text.Substring(0, 3) + "-" + txt_numero.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1[4, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
                    return;
                }
            }
        }
        private bool validaGrabar()
        {
            bool result = true;

            if (DGW_DET.Rows.Count == 0)
            {
                MessageBox.Show("Nota de Salida sin detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (!VERIFICAR_DOC_INVENTARIO())
            {
                MessageBox.Show("El numero de documento ya existe, verifique la numeración de la serie.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_ni.Focus();
                return result = false;
            }
            return result;
        }
        private bool VERIFICAR_DOC_INVENTARIO()
        {
            string errMensaje = "";
            bool existe = false;
            invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            invTo.COD_DOC_INV = "02";
            invTo.NRO_DOC_INV = string.Format("{0}-{1}", cbo_ni.Text.Substring(0, 3), txt_numero.Text);
            invBLL.VERIFICAR_DOC_INVENTARIOBLL(invTo, ref existe, ref errMensaje);
            return existe;
        }

        private void BTN_NUEVO2_Click(object sender, EventArgs e)
        {
            BOTON = "NUEVO";
            btn_grabar.Visible = true;
            btn_grabar2.Visible = false;
            btn_grabar.Enabled = true;
            btn_imprimir.Enabled = false;
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLES();
            btn_mod.Visible = true;
            cbo_ni.Visible = true;
            TXT_NI.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            cbo_sucursal.Focus();
        }

        private void BTN_CANCELAR_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Focus();
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar un Documento de Salida ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                //txt_numero.Text = HALLAR_NRO_ING(cbo_ni.Text);
                string COD_ELABORADO = "";
                if (cbo_elab.SelectedIndex != -1)
                {
                    COD_ELABORADO = cbo_elab.SelectedValue.ToString();
                }

                invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                invTo.COD_PER = TXT_COD.Text;
                invTo.COD_CLASE_PER = "1";
                invTo.NRO_DOC_PER = txt_doc_per.Text;
                invTo.COD_DOC_INV = "02";//02 salida , 01 ingreso
                invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
                invTo.SERIE = cbo_ni.Text.Substring(0, 3);
                invTo.NUMERO = txt_numero.Text;
                invTo.FE_AÑO = AÑO;
                invTo.FE_MES = MES;
                invTo.COD_MOV = cbo_mov.SelectedValue.ToString();
                invTo.COD_MONEDA = "S";
                invTo.FECHA_DOC_INV = dtp_inv.Value;
                invTo.FECHA_DOC = null;
                invTo.COD_DOC = "";
                invTo.NRO_DOC = "";
                invTo.OBSERVACION = txt_obs.Text;
                invTo.TIPO_CAMBIO = 0;
                invTo.STATUS_PV = "";
                invTo.COD_USU = COD_USU;
                invTo.FECHA = DateTime.Now;
                invTo.NOMBRE_PC = NOMBRE_PC;
                invTo.COD_ELABORADO = COD_ELABORADO;
                invTo.FECHA_CREA = DateTime.Now;
                invTo.AREA = "";
                DT00.Rows.Clear();
                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                int i = 0;
                while (i <= num3)
                {
                    DT00.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), TXT_COD.Text, "02",
                        TXT_NI.Text.Substring(0, 3) + "-" + txt_numero.Text, AÑO, MES, DGW_DET[0, i].Value.ToString(), DGW_DET[0, i].Value.ToString(),
                        DGW_DET[1, i].Value.ToString(), DGW_DET[3, i].Value.ToString(), 0, COD_DH, "S", DGW_DET[4, i].Value.ToString(), DGW_DET[9, i].Value.ToString(),
                        DGW_DET[10, i].Value.ToString(), igv0.ToString(), "0.00", "1", ((igv0 / 100) * Convert.ToDecimal(DGW_DET[10, i].Value)).ToString(), "0.00",
                        "0.00", "0.00", "", "0", NOMBRE_PC, "", DateTime.Now, DGW_DET[7, i].Value.ToString());
                    i++;
                }

                if (!invBLL.modificaSalidaInventarioBLL(invTo, DT00, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!helBLL.ELIMINAR_TEMPORAL("INV", NOMBRE_PC, ref errMensaje))
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("La Nota de Salida se Actualizó !!!" + errMensaje, "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //xt_numero.Text = obj.HALLAR_NRO_ACTUAL(COD_SUCURSAL, "04", "0", cbo_ni.Text)
                    //gb_oc.Enabled = false;
                    //gb_DEntrega.Enabled = false;
                    DATAGRID(); FOCO_NUEVO_REG2();
                    Panel1.Visible = true;
                    btn_grabar2.Enabled = false;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    btn_imprimir.Enabled = true;
                    btn_imprimir.Select();
                }
            }
        }
        private void FOCO_NUEVO_REG2()
        {
            int i, cont = 0;
            cont = dgw1.Rows.Count - 1;
            string nrocon = TXT_NI.Text.Substring(0, 3) + "-" + txt_numero.Text;
            for (i = 0; i <= cont; i++)
            {
                if (nrocon == dgw1[4, i].Value.ToString().ToLower())
                {
                    dgw1.CurrentCell = dgw1.Rows[i].Cells[4];
                    return;
                }
            }
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (!validaModificar())
                return;

            BOTON = "MODIFICAR";
            btn_imprimir.Enabled = false;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            btn_grabar.Visible = false;
            btn_grabar2.Visible = true;
            btn_grabar2.Enabled = true;
            gb_cab.Enabled = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = true;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            btn_mod.Visible = true;
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            cbo_sucursal.Focus();
        }
        private bool validaModificar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgw1[14, dgw1.CurrentRow.Index].Value))
            {
                MessageBox.Show("La Nota de Salida tiene Guía", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private void CARGAR_DATOS()
        {
            cbo_ni.SelectedIndex = -1;
            int idx = dgw1.CurrentRow.Index;
            //cboArea.SelectedIndex = -1
            //COD_SUCURSAL = dgw1.Item(0, dgw1.CurrentRow.Index).Value
            cbo_sucursal.SelectedValue = dgw1.Rows[idx].Cells["COD_SUCURSAL"].Value;
            //COD_CLASE = dgw1.Item(2, dgw1.CurrentRow.Index).Value
            cbo_clase.SelectedValue = dgw1.Rows[idx].Cells["cod_clase"].Value;
            //COD_MOV = dgw1.Item(8, dgw1.CurrentRow.Index).Value
            cbo_mov.SelectedValue = dgw1.Rows[idx].Cells["cod_mov"].Value;
            string str = dgw1[4, idx].Value.ToString();
            TXT_NI.Text = str.Substring(0, 3).ToString();
            txt_numero.Text = str.Substring(4, 7).ToString();
            TXT_COD.Text = dgw1.Rows[idx].Cells["cod_per"].Value.ToString();
            TXT_DESC.Text = dgw1.Rows[idx].Cells["Solicitante"].Value.ToString();
            txt_doc_per.Text = dgw1.Rows[idx].Cells["nro_doc_per"].Value.ToString();

            //AREA = dgw1.Item(17, dgw1.CurrentRow.Index).Value
            //cboArea.Text = dgw1.Item(18, dgw1.CurrentRow.Index).Value
            //CARGAR_STATUS();
            dtp_inv.Value = Convert.ToDateTime(dgw1.Rows[idx].Cells["Fecha"].Value);
            txt_obs.Text = dgw1.Rows[idx].Cells["observacion"].Value.ToString();
            //COD_ELABORADO = dgw1.Item(13, dgw1.CurrentRow.Index).Value
            cbo_elab.SelectedValue = dgw1.Rows[idx].Cells["COD_ELABORADO"].Value;
        }
        private void CARGAR_DETALLES_DGW()
        {
            //DGW_DET.Rows.Clear();
            invTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            invTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
            invTo.COD_PER = TXT_COD.Text;
            invTo.NRO_DOC_INV = TXT_NI.Text + "-" + txt_numero.Text;
            invTo.FE_AÑO = AÑO;
            invTo.FE_MES = MES;
            DataTable dt = invBLL.obtenerInventariosSalidaDetalleBLL(invTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowId];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[2].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["CANTIDAD"].ToString();
                    row.Cells[4].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells[5].Value = rw["DESC_CORTA"].ToString();
                    row.Cells[6].Value = rw["NRO_PARTE"].ToString();
                    row.Cells[7].Value = rw["OBSERVACION"].ToString();
                    row.Cells[8].Value = rw["UNIDAD_MEDIDA"].ToString();
                    row.Cells[9].Value = rw["precio_unitario"].ToString();
                    row.Cells[10].Value = rw["valor_compra"].ToString();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BOTON = "MODIFICAR";
            btn_grabar.Visible = false;
            btn_grabar2.Visible = false;
            btn_grabar2.Enabled = true;
            btn_imprimir.Enabled = true;
            TabControl1.SelectedTab = TabPage2;
            LIMPIAR_CABECERA();
            gb_cab.Enabled = false;
            //cboArea.Enabled = False
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel0.Enabled = false;
            CARGAR_DATOS();
            CARGAR_DETALLES_DGW();
            btn_mod.Visible = false;
            cbo_ni.Visible = false;
            TXT_NI.Visible = true;
            btn_imprimir.Focus();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar la Nota de Salida Nº " + dgw1[4, dgw1.CurrentRow.Index].Value.ToString() + " ?", "ESTA SEGURO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                if (TIPO_USU != "MS")
                {
                    DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                    frm.Label2.Visible = false;
                    frm.txtObservacion.Visible = false;
                    frm.cargar_usuario("ALM");
                    frm.cboUsuario.Focus();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        string codigo = helBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        int RSLT = helBLL.ValidarDirectorioDesaprobarBLL(codigo, "ALM");
                        if (RSLT > 0)
                        {
                            eliminaNotaSalida(dgw1[0, idx].Value.ToString(), dgw1[2, idx].Value.ToString(), dgw1[5, idx].Value.ToString(), "02", dgw1[4, idx].Value.ToString(), AÑO, MES, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    frm.Dispose();
                }
                else
                {
                    eliminaNotaSalida(dgw1[0, idx].Value.ToString(), dgw1[2, idx].Value.ToString(), dgw1[5, idx].Value.ToString(), "02", dgw1[4, idx].Value.ToString(), AÑO, MES, ref errMensaje);
                }
                DATAGRID();
            }
            btn_nuevo.Select();
        }
        private void eliminaNotaSalida(string COD_SUCURSAL, string COD_CLASE, string COD_PER, string COD_DOC_INV, string NRO_DOC_INV, string FE_AÑO, string FE_MES, ref string errMensaje)
        {
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_PER = COD_PER;
            invTo.COD_DOC_INV = COD_DOC_INV;
            invTo.NRO_DOC_INV = NRO_DOC_INV;
            invTo.FE_AÑO = FE_AÑO;
            invTo.FE_MES = FE_MES;
            if (!invBLL.ELIMINAR_NOTA_SALIDA_BLL(invTo, ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("La Nota de Salida se elimino con exito !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private bool validaEliminar()
        {
            bool result = true;
            if (Convert.ToBoolean(dgw1[14, dgw1.CurrentRow.Index].Value))
            {
                MessageBox.Show("La Nota de Salida tiene Guía", "No se puede Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }

            return result;
        }
        private bool validaAnular()
        {
            bool result = true;
            if (Convert.ToBoolean(dgw1[14, dgw1.CurrentRow.Index].Value))
            {
                MessageBox.Show("La Nota de Salida tiene Guía", "No se puede Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            if (Convert.ToBoolean(dgw1.Rows[dgw1.CurrentRow.Index].Cells["Anul."].Value))
            {
                MessageBox.Show("La Nota de Salida ya esta Anulada", "No se puede Anular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false;
            }
            return result;
        }
        private void btn_anul_Click(object sender, EventArgs e)
        {
            if (!validaAnular())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Anular la Nota de Salida Nº " + dgw1[4, dgw1.CurrentRow.Index].Value.ToString() + " ?", "ESTA SEGURO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                int idx = dgw1.CurrentRow.Index;
                DIALOGOS.frmValidarEliminarAnular frm = new DIALOGOS.frmValidarEliminarAnular();
                frm.Label2.Visible = true;
                frm.txtObservacion.Visible = true;
                frm.txtContraseña.Text = "";
                frm.txtObservacion.Text = "";
                frm.cargar_usuario("ALM");

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (TIPO_USU != "MS")
                    {
                        string pass = frm.txtContraseña.Text;
                        string claveEncriptada = HelpersBLL.ENCRIPTAR(pass.ToUpper());
                        string codigo = helBLL.ValidarUsuarioEliminacionAnulacionBLL(claveEncriptada, frm.cboUsuario.Text);
                        int RSLT = helBLL.ValidarDirectorioDesaprobarBLL(codigo, "ALM");
                        if (RSLT > 0)
                        {
                            anulaNotaSalida(dgw1[0, idx].Value.ToString(), dgw1[2, idx].Value.ToString(), dgw1[5, idx].Value.ToString(), "02", dgw1[4, idx].Value.ToString(), AÑO, MES, "1", frm.txtObservacion.Text, codigo, DateTime.Now, ref errMensaje);
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("USTED NO TIENE PERMISOS !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        frm.Dispose();

                    }
                    else
                    {
                        anulaNotaSalida(dgw1[0, idx].Value.ToString(), dgw1[2, idx].Value.ToString(), dgw1[5, idx].Value.ToString(), "02", dgw1[4, idx].Value.ToString(), AÑO, MES, "01", "", "", DateTime.Now, ref errMensaje);
                    }
                    DATAGRID();
                }
            }
            btn_nuevo.Select();
        }
        private void anulaNotaSalida(string COD_SUCURSAL, string COD_CLASE, string COD_PER, string COD_DOC_INV, string NRO_DOC_INV, string FE_AÑO, string FE_MES, string TIPOUSU, string OBS, string USUMOD, DateTime FECMOD, ref string errMensaje)
        {
            invTo.COD_SUCURSAL = COD_SUCURSAL;
            invTo.COD_CLASE = COD_CLASE;
            invTo.COD_PER = COD_PER;
            invTo.COD_DOC_INV = COD_DOC_INV;
            invTo.NRO_DOC_INV = NRO_DOC_INV;
            invTo.FE_AÑO = FE_AÑO;
            invTo.FE_MES = FE_MES;
            invTo.TIPO_USU = TIPOUSU;
            invTo.OBSERVACION = OBS;
            invTo.COD_USU_MOD = USUMOD;
            invTo.FECHA_MOD = FECMOD;
            if (!invBLL.ANULAR_NOTA_SALIDA_BLL(invTo, ref errMensaje))
                MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("La Nota de Salida se Anulo con exito !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TXT_COD_PRO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TXT_COD_PRO.Text.Trim() != "")
            {
                if (DGW_PRO.Rows.Count > 0)
                {
                    DGW_PRO.Sort(DGW_PRO.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int num2 = DGW_PRO.Rows.Count - 1;
                    int i = 0;
                    while (i <= num2)
                    {
                        if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower())
                        {
                            TXT_COD_PRO.Text = DGW_PRO[0, i].Value.ToString();
                            TXT_DESC_PRO.Text = DGW_PRO[1, i].Value.ToString();
                            TXT_NRO_PARTE.Text = DGW_PRO[2, i].Value.ToString();
                            txt_um.Text = DGW_PRO[5, i].Value.ToString();

                            Panel_PRO.Visible = false;
                            txt_cant.Focus();
                            return;
                        }
                        if (DGW_PRO[0, i].Value.ToString().Length >= TXT_COD_PRO.TextLength)
                        {
                            if (TXT_COD_PRO.Text.ToLower() == DGW_PRO[0, i].Value.ToString().ToLower().Substring(0, TXT_COD_PRO.TextLength))
                            {
                                Panel_PRO.Visible = true;
                                DGW_PRO.Focus();
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }
                        else if (HelpersBLL.IsNumeric(TXT_COD_PRO.Text.Trim()) && HelpersBLL.IsNumeric(DGW_PRO[0, i].Value.ToString()))
                        {
                            if (Int64.Parse(TXT_COD_PRO.Text.Trim()) == Int64.Parse(DGW_PRO[0, i].Value.ToString()))
                            {
                                DGW_PRO.CurrentCell = DGW_PRO.Rows[i].Cells[0];
                                break;
                            }
                        }
                        DGW_PRO.CurrentCell = DGW_PRO.Rows[0].Cells[0];
                        i += 1;
                    }
                    Panel_PRO.Visible = true;
                    DGW_PRO.Visible = true;
                    DGW_PRO.Focus();
                }
                else
                {
                    MessageBox.Show("No existen Productos de la Clase: " + cbo_clase.Text + " !!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    LIMPIAR_DETALLES();
                    cbo_ni.Visible = false;
                    TXT_NI.Visible = true;
                    if (dgw1.Rows.Count > 0)
                    {
                        CARGAR_DATOS();
                        CARGAR_DETALLES_DGW();
                    }
                    btn_grabar.Visible = false;
                    btn_grabar2.Visible = false;
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel0.Enabled = false;
                    gb_cab.Enabled = false;
                    txt_obs.Enabled = false;
                }
            }
        }
        public static bool Numero(KeyPressEventArgs e, ref TextBox cajas)
        {
            bool result = false;
            if (e.KeyChar.ToString().ToUpper().Contains("[!0-9.]"))
            {
                return result = true;
            }
            if (e.KeyChar.ToString().ToUpper().Contains("[.]"))
            {
                if (cajas.Text.Contains("."))
                    return result = true;
                else
                    return result = false;
            }
            return result;
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox cajasTexto = txt_cant;
            txt_cant = cajasTexto;
            e.Handled = Numero(e, ref cajasTexto);
        }
    }
}
