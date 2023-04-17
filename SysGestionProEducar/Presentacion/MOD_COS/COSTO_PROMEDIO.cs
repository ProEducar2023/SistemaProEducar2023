using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COS
{
    public partial class COSTO_PROMEDIO : Form
    {
        private delegate string Procesar(string año, string mes, string clase);
        private delegate string ProcesarArticulo(string año, string mes, string clase, string otro);
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        Procesar oProcesar = new Procesar(COSTO_PROMEDIO1);
        ProcesarArticulo oProceso2 = new ProcesarArticulo(COSTO_PROMEDIO_ARTICULO);
        ProcesarArticulo oProceso3 = new ProcesarArticulo(COSTO_PROMEDIO_MOV);
        DateTime FECHA_INI, FECHA_GRAL;
        periodoBLL perBLL = new periodoBLL();
        periodoTo perTo = new periodoTo();
        iCostosBLL cosBLL = new iCostosBLL();
        iCostosTo cosTo = new iCostosTo();
        //string año00; string mes00; string clase00;
        public COSTO_PROMEDIO(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void COSTO_PROMEDIO_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.KeyPreview = true;
            CARGAR_AÑO();
            cargar_mes();
            CARGAR_CLASE();
            MOVXOPERACION_VALORCOSTO();
            cbo_año.Text = AÑO;
            cbo_mes1.Text = HelpersBLL.OBTENER_NOM_MES(MES);
            cbo_clase.Focus();
            TabControl1.TabPages.Remove(TabPage2);//ya habia hecho todos los tabpage, cuando Don Miguel me dijo que solo el primero iba.
            TabControl1.TabPages.Remove(TabPage3);
            TabControl1.TabPages.Remove(TabPage4);
        }
        private void MOVXOPERACION_VALORCOSTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosCostosPromedioBLL();
            cbo_mov.DataSource = dt;
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.SelectedIndex = -1;
        }
        private void COSTO_PROMEDIO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cargar_mes()
        {
            var months1 = new[] { new { cod = "00", val = "INICIO" }, new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }, new { cod = "13", val = "CIERRE" }};
            var months2 = new[] { new { cod = "00", val = "INICIO" }, new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }, new { cod = "13", val = "CIERRE" }};
            var months3 = new[] { new { cod = "00", val = "INICIO" }, new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }, new { cod = "13", val = "CIERRE" }};
            var months4 = new[] { new { cod = "00", val = "INICIO" }, new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }, new { cod = "13", val = "CIERRE" }};
            cbo_mes1.ValueMember = "cod";
            cbo_mes1.DisplayMember = "val";
            cbo_mes1.DataSource = months1;
            cbo_mes2.ValueMember = "cod";
            cbo_mes2.DisplayMember = "val";
            cbo_mes2.DataSource = months2;
            cbo_mes3.ValueMember = "cod";
            cbo_mes3.DisplayMember = "val";
            cbo_mes3.DataSource = months3;
            cbo_mes4.ValueMember = "cod";
            cbo_mes4.DisplayMember = "val";
            cbo_mes4.DataSource = months4;
            //cbo_mes.SelectedIndex = -1;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cbo_año.Items.Clear();
            cbo_año2.Items.Clear();
            cbo_año3.Items.Clear();
            cbo_año4.Items.Clear();
            perTo.COD_MODULO = "COS";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            //DataTable dt1 = perBLL.obtenerAñoPeriodoBLL(perTo);
            cbo_año.ValueMember = "AÑO";
            cbo_año.DisplayMember = "AÑO";
            cbo_año.DataSource = dt;
            cbo_año2.ValueMember = "AÑO";
            cbo_año2.DisplayMember = "AÑO";
            cbo_año2.DataSource = dt;
            cbo_año3.ValueMember = "AÑO";
            cbo_año3.DisplayMember = "AÑO";
            cbo_año3.DataSource = dt;
            cbo_año4.ValueMember = "AÑO";
            cbo_año4.DisplayMember = "AÑO";
            cbo_año4.DataSource = dt;
        }
        private void CARGAR_CLASE()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            //articuloClaseTo clsTo = new articuloClaseTo();
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostoPromedioBLL();
            //DataTable dt1 = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            cbo_clase.DataSource = dt;
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.SelectedIndex = -1;
            cbo_clase2.DataSource = dt;
            cbo_clase2.DisplayMember = "DESC_CLASE";
            cbo_clase2.ValueMember = "COD_CLASE";
            cbo_clase2.SelectedIndex = -1;
            cbo_clase3.DataSource = dt;
            cbo_clase3.DisplayMember = "DESC_CLASE";
            cbo_clase3.ValueMember = "COD_CLASE";
            cbo_clase3.SelectedIndex = -1;
            cbo_clase4.DataSource = dt;
            cbo_clase4.DisplayMember = "DESC_CLASE";
            cbo_clase4.ValueMember = "COD_CLASE";
            cbo_clase4.SelectedIndex = -1;
        }

        private void cbo_clase3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase3.SelectedIndex != -1)
            {
                CARGAR_PRODUCTOS();
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            arcTo.COD_CLASE = cbo_clase3.SelectedValue.ToString();
            DataTable dt = arcBLL.obtenerArticuloClaseparaCostoPromedioUMBLL(arcTo);
            if (dt.Rows.Count > 0)
            {
                DGW_ART.DataSource = dt;
                DGW_ART.Columns[3].Width = 40;
                DGW_ART.Columns[1].Width = 215;
                DGW_ART.Columns[0].Width = 80;
            }
        }

        private void cod_art_Leave(object sender, EventArgs e)
        {
            if (cod_art.Text.Trim() != "")
            {
                if (DGW_ART.Rows.Count > 0)
                {
                    DGW_ART.Sort(DGW_ART.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = DGW_ART.Rows.Count - 1;
                    do
                    {
                        if (cod_art.Text.ToLower() == DGW_ART[0, i].Value.ToString().ToLower())
                        {
                            cod_art.Text = DGW_ART[0, i].Value.ToString();
                            des_art.Text = DGW_ART[1, i].Value.ToString();
                            cod0_art.Text = DGW_ART[2, i].Value.ToString();
                            //
                            //CARGAR_CONTACTO();
                            //MostrarFormaPago();
                            //cbo_ni.Focus();
                            return;
                        }
                        if (cod_art.Text.ToLower() == DGW_ART[0, i].Value.ToString().ToLower().Substring(0, cod_art.TextLength))
                        {
                            DGW_ART.CurrentCell = DGW_ART.Rows[i].Cells[0];
                            break;
                        }
                        DGW_ART.CurrentCell = DGW_ART.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    //Panel1.Visible = true;
                    //Panel1.SendToBack();
                    //Panel_PER.BringToFront();
                    Panel_ART.Visible = true;
                    DGW_ART.Visible = true;
                    DGW_ART.Focus();
                }
            }
        }

        private void des_art_Leave(object sender, EventArgs e)
        {
            if (des_art.Text == "")
            {
                cod0_art.Focus();
            }
            else
            {
                if (DGW_ART.Rows.Count > 0)
                {
                    DGW_ART.Sort(DGW_ART.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = DGW_ART.Rows.Count;
                    do
                    {
                        if (DGW_ART[1, i].Value.ToString().Length >= des_art.TextLength)
                        {
                            if (des_art.Text.ToLower() == DGW_ART[1, i].Value.ToString().ToLower().Substring(0, des_art.TextLength).ToLower())
                            {
                                DGW_ART.CurrentCell = DGW_ART.Rows[i].Cells[0];
                                break;
                            }
                        }
                        DGW_ART.CurrentCell = DGW_ART.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_ART.Visible = true;
                    DGW_ART.Visible = true;
                    DGW_ART.Focus();
                }
            }
        }

        private void cod0_art_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cod0_art.Text.Trim() == "")
                {
                    //btnNuevoCliente_Click(sender, e);
                }
                else if (DGW_ART.Rows.Count > 0)
                {
                    DGW_ART.Sort(DGW_ART.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = DGW_ART.Rows.Count;
                    do
                    {
                        if (DGW_ART[2, i].Value.ToString().Length >= cod0_art.TextLength)
                        {
                            if (cod0_art.Text.ToLower() == DGW_ART[2, i].Value.ToString().ToLower().Substring(0, cod0_art.TextLength).ToLower())
                            {
                                DGW_ART.CurrentCell = DGW_ART.Rows[i].Cells[0];
                                break;
                            }
                        }
                        DGW_ART.CurrentCell = DGW_ART.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    Panel_ART.Visible = true;
                    DGW_ART.Visible = true;
                    DGW_ART.Focus();
                }
            }
        }

        private void DGW_ART_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = DGW_ART.CurrentRow.Index;
                cod_art.Text = DGW_ART[0, idx].Value.ToString();
                des_art.Text = DGW_ART[1, idx].Value.ToString();
                cod0_art.Text = DGW_ART[2, idx].Value.ToString();
                Panel_ART.Visible = false;
                //MostrarFormaPago();
                TabControl1.SelectedTab = TabPage3;
                //gb_oc.Focus();
                //txt_numero.Focus();
                cod0_art.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Panel_ART.Visible = false;
                cod_art.Clear();
                des_art.Clear();
                cod0_art.Clear();
                cod_art.Focus();
            }
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            if (!valida1())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el proceso de Costo Promedio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cosTo.FE_AÑO = cbo_año.Text;
                cosTo.FE_MES = cbo_mes1.SelectedValue.ToString();
                cosTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                //inicial costo promedio
                if (!cosBLL.inicialCostoPromedioBLL(cosTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //verifica proceso del periodo
                    if (!cosBLL.VERIFICAR_PROCESO_PERIODO_BLL(cosTo, ref errMensaje))
                    {
                        if (errMensaje != "")
                            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("EL PERIODO ACTUAL AUN NO SE HA CERRADO !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        GroupBox1.Enabled = false;
                        AsyncCallback callback = new AsyncCallback(FinProceso);
                        oProcesar.BeginInvoke(cbo_año.Text, cbo_mes1.SelectedValue.ToString(), cbo_clase.SelectedValue.ToString(), callback, null);
                    }
                }
            }
        }
        private static string COSTO_PROMEDIO1(string año, string mes, string clase)
        {
            int AÑO0 = 0, MES0 = 0;
            string ESTADO0 = "EXITO";
            int MES1 = Convert.ToInt32(mes);
            if (mes == "00")
            {
                AÑO0 = Convert.ToInt32(Math.Round(Convert.ToDouble(año) - 1));
                MES0 = 13;
            }
            else
            {
                AÑO0 = Convert.ToInt32(año);
                MES0 = MES1 - 1;
            }
            BLL.iCostosBLL cosBLL = new iCostosBLL();
            Entidades.iCostosTo cosTo = new iCostosTo();
            cosTo.FE_AÑO = AÑO0.ToString();
            cosTo.FE_MES = MES0.ToString();
            cosTo.FE_AÑOI = AÑO0;
            cosTo.FE_MESI = MES0;
            cosTo.COD_CLASE = clase;
            if (cosBLL.CALCULAR_COSTO_PROMEDIO(cosTo) == "FALLO")
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private static string COSTO_PROMEDIO_ARTICULO(string año, string mes, string clase, string cod_articulo)
        {
            int AÑO0 = 0, MES0 = 0;
            string ESTADO0 = "EXITO";
            int MES1 = Convert.ToInt32(mes);
            if (mes == "00")
            {
                AÑO0 = Convert.ToInt32(Math.Round(Convert.ToDouble(año) - 1));
                MES0 = 13;
            }
            else
            {
                AÑO0 = Convert.ToInt32(año);
                MES0 = MES1 - 1;
            }
            BLL.iCostosBLL cosBLL = new iCostosBLL();
            Entidades.iCostosTo cosTo = new iCostosTo();
            cosTo.FE_AÑO = AÑO0.ToString();
            cosTo.FE_MES = MES0.ToString();
            cosTo.FE_AÑOI = AÑO0;
            cosTo.FE_MESI = MES0;
            cosTo.COD_CLASE = clase;
            cosTo.COD_ARTICULO = cod_articulo;
            if (cosBLL.CALCULAR_COSTO_PROMEDIO_ARTICULO(cosTo) == "FALLO")
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private static string COSTO_PROMEDIO_MOV(string año, string mes, string clase, string cod_mov)
        {
            int AÑO0 = 0, MES0 = 0;
            string ESTADO0 = "EXITO";
            int MES1 = Convert.ToInt32(mes);
            if (mes == "00")
            {
                AÑO0 = Convert.ToInt32(Math.Round(Convert.ToDouble(año) - 1));
                MES0 = 13;
            }
            else
            {
                AÑO0 = Convert.ToInt32(año);
                MES0 = MES1 - 1;
            }
            BLL.iCostosBLL cosBLL = new iCostosBLL();
            Entidades.iCostosTo cosTo = new iCostosTo();
            cosTo.FE_AÑO = AÑO0.ToString();
            cosTo.FE_MES = MES0.ToString();
            cosTo.FE_AÑOI = AÑO0;
            cosTo.FE_MESI = MES0;
            cosTo.COD_CLASE = clase;
            cosTo.COD_MOV = cod_mov;
            if (cosBLL.CALCULAR_COSTO_PROMEDIO_MOV(cosTo) == "FALLO")
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private string COSTO_PROMEDIO2(string año, string mes, string clase)
        {
            int AÑO0 = 0, MES0 = 0;
            string ESTADO0 = "EXITO";
            int MES1 = Convert.ToInt32(mes);
            if (mes == "00")
            {
                AÑO0 = Convert.ToInt32(Math.Round(Convert.ToDouble(año) - 1));
                MES0 = 13;
            }
            else
            {
                AÑO0 = Convert.ToInt32(año);
                MES0 = MES1 - 1;
            }
            BLL.iCostosBLL cosBLL = new iCostosBLL();
            Entidades.iCostosTo cosTo = new iCostosTo();
            cosTo.FE_AÑO = AÑO0.ToString();
            cosTo.FE_MES = MES0.ToString();
            cosTo.FE_AÑOI = AÑO0;
            cosTo.FE_MESI = MES0;
            cosTo.COD_CLASE = clase;
            if (cosBLL.CALCULAR_COSTO_PROMEDIO2(cosTo) == "FALLO")
                return ESTADO0 = "FALLO";
            return ESTADO0;
        }
        private void FinProceso(IAsyncResult iar)
        {
            string errMensaje = "";
            string estado = oProcesar.EndInvoke(iar);
            if (estado == "EXITO")
            {
                MessageBox.Show("El calculo de costo promedio se realizó satisfactoriamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cosTo.FE_AÑO = cbo_año.Text;
                cosTo.FE_MES = cbo_mes1.SelectedValue.ToString();
                if (!cosBLL.VALIDAR_NEGATIVOS_BLL(cosTo, ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Existe Saldos negativos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else if (estado == "FALLO")
                MessageBox.Show("Vuelva a intentarlo.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show(("Ocurrieron problemas con los artículos : " + estado), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            GroupBox1.Enabled = true;
        }
        private bool valida1()
        {
            bool result = true;
            if (cbo_clase.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }

            return result;
        }

        private void btn_aceptar2_Click(object sender, EventArgs e)
        {
            if (!valida2())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el proceso de Costo Promedio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cosTo.FE_AÑO = cbo_año2.Text;
                cosTo.FE_MES = cbo_mes2.SelectedValue.ToString();
                cosTo.COD_CLASE = cbo_clase2.SelectedValue.ToString();
                //inicial costo promedio
                if (!cosBLL.inicialCostoPromedioBLL(cosTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //verifica proceso del periodo
                    if (!cosBLL.VERIFICAR_PROCESO_PERIODO_BLL(cosTo, ref errMensaje))
                    {
                        if (errMensaje != "")
                            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string estado = COSTO_PROMEDIO2(cbo_año2.Text, cbo_mes2.SelectedValue.ToString(), cbo_clase2.ToString());
                        if (estado == "EXITO")
                        {
                            MessageBox.Show("El calculo de costo promedio se realizó satisfactoriamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cosTo.FE_AÑO = cbo_año.Text;
                            cosTo.FE_MES = cbo_mes1.SelectedValue.ToString();
                            if (!cosBLL.VALIDAR_NEGATIVOS_BLL(cosTo, ref errMensaje))
                            {
                                if (errMensaje != "")
                                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                    MessageBox.Show("Existe Saldos negativos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else if (estado == "FALLO")
                            MessageBox.Show("Vuelva a intentarlo.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        else
                            MessageBox.Show(("Ocurrieron problemas con los artículos : " + estado), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
        }
        private bool valida2()
        {
            bool result = true;
            if (cbo_clase2.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase2.Focus();
                return result = false;
            }

            return result;
        }
        private bool valida3()
        {
            bool result = true;
            if (cbo_clase3.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase3.Focus();
                return result = false;
            }
            if (cod_art.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Articulo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cod_art.Focus();
                return result = false;
            }
            return result;
        }
        private bool valida4()
        {
            bool result = true;
            if (cbo_clase4.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase4.Focus();
                return result = false;
            }
            if (cbo_mov.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el Movimiento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mov.Focus();
                return result = false;
            }
            return result;
        }
        private void btncospro_articulo_Click(object sender, EventArgs e)
        {
            if (!valida3())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el proceso de Costo Promedio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cosTo.FE_AÑO = cbo_año3.Text;
                cosTo.FE_MES = cbo_mes3.SelectedValue.ToString();
                cosTo.COD_CLASE = cbo_clase3.SelectedValue.ToString();
                //inicial costo promedio
                if (!cosBLL.inicialCostoPromedioBLL(cosTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GroupBox3.Enabled = false;
                    //verifica proceso del periodo
                    if (!cosBLL.VERIFICAR_PROCESO_PERIODO_BLL(cosTo, ref errMensaje))
                    {
                        if (errMensaje != "")
                            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        AsyncCallback callback = new AsyncCallback(FinProceso_Articulo);
                        oProceso2.BeginInvoke(cbo_año3.Text, cbo_mes3.SelectedValue.ToString(), cbo_clase3.SelectedValue.ToString(), cod_art.Text, callback, null);

                    }
                }
            }
        }
        private void FinProceso_Articulo(IAsyncResult iar)
        {
            string errMensaje = "";
            string estado = oProceso2.EndInvoke(iar);
            if (estado == "EXITO")
            {
                MessageBox.Show("El calculo de costo promedio se realizó satisfactoriamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cosTo.FE_AÑO = cbo_año3.Text;
                cosTo.FE_MES = cbo_mes3.SelectedValue.ToString();
                if (!cosBLL.VALIDAR_NEGATIVOS_BLL(cosTo, ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Existe Saldos negativos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else if (estado == "FALLO")
                MessageBox.Show("Vuelva a intentarlo.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show(("Ocurrieron problemas con los artículos : " + estado), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            GroupBox3.Enabled = true;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_sal2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla4_Click(object sender, EventArgs e)
        {
            if (!valida4())
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de realizar el proceso de Costo Promedio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                cosTo.FE_AÑO = cbo_año4.Text;
                cosTo.FE_MES = cbo_mes4.SelectedValue.ToString();
                cosTo.COD_CLASE = cbo_clase4.SelectedValue.ToString();
                //inicial costo promedio
                if (!cosBLL.inicialCostoPromedioBLL(cosTo, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GroupBox4.Enabled = false;
                    //verifica proceso del periodo
                    if (!cosBLL.VERIFICAR_PROCESO_PERIODO_BLL(cosTo, ref errMensaje))
                    {
                        if (errMensaje != "")
                            MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        AsyncCallback callback = new AsyncCallback(FinProceso_Mov);
                        oProceso3.BeginInvoke(cbo_año4.Text, cbo_mes4.SelectedValue.ToString(), cbo_clase4.SelectedValue.ToString(), cbo_mov.SelectedValue.ToString(), callback, null);

                    }
                }
            }
        }
        private void FinProceso_Mov(IAsyncResult iar)
        {
            string errMensaje = "";
            string estado = oProceso3.EndInvoke(iar);
            if (estado == "EXITO")
            {
                MessageBox.Show("El calculo de costo promedio se realizó satisfactoriamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cosTo.FE_AÑO = cbo_año4.Text;
                cosTo.FE_MES = cbo_mes4.SelectedValue.ToString();
                if (!cosBLL.VALIDAR_NEGATIVOS_BLL(cosTo, ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Existe Saldos negativos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else if (estado == "FALLO")
                MessageBox.Show("Vuelva a intentarlo.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show(("Ocurrieron problemas con los artículos : " + estado), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            GroupBox4.Enabled = true;
        }
        private void btn_salir4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

}
