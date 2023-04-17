using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COS
{
    public partial class CONSULTA_KARDEX_ARTICULO : Form
    {
        //private static CONSULTA_KARDEX_ARTICULO frm;
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string codClase, codSucursal, mesInicio, mesFinal, mesAnterior, añoKardex, articulo;
        decimal Saldo, Costo;
        //private delegate void Consultar(string codSucursal0, string codClase0, string articulo0, string mesInicio0, string mesFinal0, string mesAnterior0, string añoKardex0, DataGridView dgw);
        private delegate void ResumenCallBack();
        //Consultar oConsultar = new Consultar(CargarDatos);
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();

        //public static CONSULTA_KARDEX_ARTICULO ObtenerInstancia(string AÑO0, string MES0, DateTime FECHA_INI0, DateTime FECHA_GRAL0, string COD_MOD0, string TIPO_USU0, string COD_USU0)
        //{ 
        //    if(frm == null || frm.IsDisposed )
        //    {
        //        frm = new CONSULTA_KARDEX_ARTICULO();
        //        AÑO = AÑO0;
        //        MES = MES0;
        //        FECHA_INI = FECHA_INI0;
        //        FECHA_GRAL = FECHA_GRAL0;
        //        COD_MOD = COD_MOD0;
        //        TIPO_USU = TIPO_USU0;
        //        COD_USU = COD_USU0;
        //        //frm.KeyDown += new KeyEventHandler(CONSULTA_KARDEX_ARTICULO_KeyDown);
        //    }
        //    frm.BringToFront();
        //    return frm;
        //}
        public CONSULTA_KARDEX_ARTICULO(string AÑO0, string MES0, DateTime FECHA_INI0, DateTime FECHA_GRAL0, string COD_MOD0, string TIPO_USU0, string COD_USU0)
        {
            InitializeComponent();
            this.AÑO = AÑO0;
            this.MES = MES0;
            this.FECHA_INI = FECHA_INI0;
            this.FECHA_GRAL = FECHA_GRAL0;
            this.COD_MOD = COD_MOD0;
            this.TIPO_USU = TIPO_USU0;
            this.COD_USU = COD_USU0;
            this.KeyDown += new KeyEventHandler(Pulsar);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CONSULTA_KARDEX_ARTICULO_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_CLASE();
            CARGAR_SUCURSAL();
            CARGAR_AÑO();
            cargar_mesIni_Fin();
        }
        private void Pulsar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
        private void cargar_mesIni_Fin()
        {
            var months1 = new[] { new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};
            var months2 = new[] { new { cod = "01", val = "ENERO" }, new { cod = "02", val = "FEBRERO" },
                                new { cod = "03", val = "MARZO" }, new { cod = "04", val = "ABRIL" },
                                new { cod = "05", val = "MAYO" }, new { cod = "06", val = "JUNIO" },
                                new { cod = "07", val = "JULIO" }, new { cod = "08", val = "AGOSTO" },
                                new { cod = "09", val = "SEPTIEMBRE" }, new { cod = "10", val = "OCTUBRE" },
                                new { cod = "11", val = "NOVIEMBRE" }, new { cod = "12", val = "DICIEMBRE" }};

            cboMesInicio.ValueMember = "cod";
            cboMesInicio.DisplayMember = "val";
            cboMesInicio.DataSource = months1;
            cboMesInicio.SelectedIndex = -1;
            cboMesFinal.ValueMember = "cod";
            cboMesFinal.DisplayMember = "val";
            cboMesFinal.DataSource = months2;
            cboMesFinal.SelectedIndex = -1;
        }
        private void CARGAR_CLASE()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            articuloClaseTo clsTo = new articuloClaseTo();
            clsTo.COD_USU = COD_USU;
            clsTo.TIPO_USU = TIPO_USU;
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            cboClase.DataSource = dt;
            cboClase.DisplayMember = "DESC_CLASE";
            cboClase.ValueMember = "COD_CLASE";
            cboClase.SelectedIndex = -1;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cboSucursal.ValueMember = "COD_SUCURSAL";
            cboSucursal.DisplayMember = "DESC_sucursal";
            cboSucursal.DataSource = dt;
            cboSucursal.SelectedIndex = -1;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            cboAño.Items.Clear();
            perTo.COD_MODULO = "COS";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            cboAño.ValueMember = "AÑO";
            cboAño.DisplayMember = "AÑO";
            cboAño.DataSource = dt;
        }
        private void CargarDatos(string codSucursal0, string codClase0, string articulo0, string mesInicio0, string mesFinal0, string mesAnterior0, string añoKardex0, DataGridView dgw)
        {
            tCostosBLL tcosBLL = new tCostosBLL();
            tCostosTo tcosTo = new tCostosTo();
            tcosTo.COD_SUCURSAL = codSucursal0;
            tcosTo.COD_CLASE = codClase0;
            tcosTo.COD_ARTICULO = articulo0;
            tcosTo.MES1 = mesInicio0;
            tcosTo.MES2 = mesFinal0;
            tcosTo.MES_ANTERIOR = mesAnterior0;
            tcosTo.AÑO = añoKardex0;
            DataTable dt = tcosBLL.CONSULTA_KARDEX_SALDO_ARTICULO(tcosTo);
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgw.Rows.Add();
                    DataGridViewRow row = dgw.Rows[rowId];
                    row.Cells[0].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells[1].Value = rw["FECHA_DOC_INV"].ToString();
                    row.Cells[2].Value = rw["COD_MOV"].ToString();
                    row.Cells[3].Value = rw["INGRESO"].ToString();
                    row.Cells[4].Value = rw["SALIDA"].ToString();
                    row.Cells[5].Value = "0";
                    row.Cells[6].Value = rw["PRECIO_CON"].ToString();
                    row.Cells[7].Value = rw["VALOR_CON_DEBE"].ToString();
                    row.Cells[8].Value = rw["VALOR_CON_HABER"].ToString();
                    row.Cells[9].Value = "0";
                    row.Cells[10].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells[11].Value = rw["COD_DOC"].ToString();
                    row.Cells[12].Value = rw["NRO_DOC"].ToString();
                    row.Cells[13].Value = rw["FECHA_DOC"].ToString();
                    row.Cells[14].Value = rw["CC/OP"].ToString();
                    //row.Cells[15].Value = rw["COD_D_H"].ToString();
                    row.Cells[15].Value = rw["SALDO_INICIAL"].ToString();
                    row.Cells[16].Value = rw["COSTO_PROMEDIO"].ToString();
                }
            }
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim() != "")
            {
                if (dgvArticulo.Rows.Count > 0)
                {
                    dgvArticulo.Sort(dgvArticulo.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgvArticulo.Rows.Count - 1;
                    do
                    {
                        if (txtCodigo.Text.ToLower() == dgvArticulo[0, i].Value.ToString().ToLower())
                        {
                            txtCodigo.Text = dgvArticulo[0, i].Value.ToString();
                            txtDescripcion.Text = dgvArticulo[1, i].Value.ToString();
                            txtNroParte.Text = dgvArticulo[2, i].Value.ToString();
                            //
                            //CARGAR_CONTACTO();
                            //MostrarFormaPago();
                            //cbo_ni.Focus();
                            return;
                        }
                        if (txtCodigo.Text.ToLower() == dgvArticulo[0, i].Value.ToString().ToLower().Substring(0, txtCodigo.TextLength))
                        {
                            dgvArticulo.CurrentCell = dgvArticulo.Rows[i].Cells[0];
                            break;
                        }
                        dgvArticulo.CurrentCell = dgvArticulo.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    pnlArticulo.Visible = true;
                    dgvArticulo.Visible = true;
                    dgvArticulo.Focus();
                }
            }
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtNroParte.Focus();
            }
            else
            {
                if (dgvArticulo.Rows.Count > 0)
                {
                    dgvArticulo.Sort(dgvArticulo.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgvArticulo.Rows.Count;
                    do
                    {
                        if (dgvArticulo[1, i].Value.ToString().Length >= txtDescripcion.TextLength)
                        {
                            if (txtDescripcion.Text.ToLower() == dgvArticulo[1, i].Value.ToString().ToLower().Substring(0, txtDescripcion.TextLength).ToLower())
                            {
                                dgvArticulo.CurrentCell = dgvArticulo.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgvArticulo.CurrentCell = dgvArticulo.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    pnlArticulo.Visible = true;
                    dgvArticulo.Visible = true;
                    dgvArticulo.Focus();
                }
            }
        }

        private void txtNroParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNroParte.Text.Trim() == "")
                {
                    //btnNuevoCliente_Click(sender, e);
                }
                else if (dgvArticulo.Rows.Count > 0)
                {
                    dgvArticulo.Sort(dgvArticulo.Columns[2], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgvArticulo.Rows.Count;
                    do
                    {
                        if (dgvArticulo[2, i].Value.ToString().Length >= txtNroParte.TextLength)
                        {
                            if (txtNroParte.Text.ToLower() == dgvArticulo[2, i].Value.ToString().ToLower().Substring(0, txtNroParte.TextLength).ToLower())
                            {
                                dgvArticulo.CurrentCell = dgvArticulo.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgvArticulo.CurrentCell = dgvArticulo.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    pnlArticulo.Visible = true;
                    dgvArticulo.Visible = true;
                    dgvArticulo.Focus();
                }
            }
        }

        private void dgvArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgvArticulo.CurrentRow.Index;
                txtCodigo.Text = dgvArticulo[0, idx].Value.ToString();
                txtDescripcion.Text = dgvArticulo[1, idx].Value.ToString();
                txtNroParte.Text = dgvArticulo[2, idx].Value.ToString();
                txtUnidadMedida.Text = dgvArticulo[5, idx].Value.ToString();
                pnlArticulo.Visible = false;
                //MostrarFormaPago();
                tcKardex.SelectedTab = tpGeneral;
                //gb_oc.Focus();
                //txt_numero.Focus();
                txtNroParte.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                pnlArticulo.Visible = false;
                txtCodigo.Clear();
                txtDescripcion.Clear();
                txtNroParte.Clear();
                txtCodigo.Focus();
            }
        }

        private void cboClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClase.SelectedIndex != -1)
            {
                CARGAR_PRODUCTOS();
            }
        }
        private void CARGAR_PRODUCTOS()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            arcTo.COD_CLASE = cboClase.SelectedValue.ToString();
            DataTable dt = arcBLL.obtenerArticuloClaseparaInventarioBLL(arcTo);
            if (dt.Rows.Count > 0)
            {
                dgvArticulo.DataSource = dt;
                dgvArticulo.Columns[2].Visible = false;
                dgvArticulo.Columns[3].Visible = false;
                dgvArticulo.Columns[4].Visible = false;
                dgvArticulo.Columns[5].Width = 40;
                dgvArticulo.Columns[1].Width = 215;
                dgvArticulo.Columns[0].Width = 80;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!validaConsultar())
                return;

            mesInicio = cboMesInicio.SelectedValue.ToString();
            mesFinal = cboMesFinal.SelectedValue.ToString();
            añoKardex = cboAño.SelectedValue.ToString();
            articulo = txtCodigo.Text;
            mesAnterior = (Convert.ToInt32(mesInicio) - 1).ToString("00");
            dgvKardex.Rows.Clear();
            gbGeneral.Enabled = false;
            gb1.Enabled = false;
            CargarDatos(cboSucursal.SelectedValue.ToString(), cboClase.SelectedValue.ToString(), articulo, mesInicio, mesFinal, mesAnterior, añoKardex, dgvKardex);
            mostrar();
            //AsyncCallback oCallback = new AsyncCallback(MostrarResumenConsulta);
            //oConsultar.BeginInvoke(cboSucursal.SelectedValue.ToString(), cboClase.SelectedValue.ToString(), articulo, mesInicio, mesFinal, 
            //    mesAnterior, añoKardex, dgvKardex, oCallback, null);
        }
        private void MostrarResumenConsulta(IAsyncResult iar)
        {
            ResumenCallBack d = new ResumenCallBack(mostrar);
            this.Invoke(d);
        }
        private void mostrar()
        {
            gbGeneral.Enabled = true;
            if (dgvKardex.Rows.Count > 0)
            {
                Saldo = Convert.ToDecimal(dgvKardex[15, 0].Value);
                Costo = Convert.ToDecimal(dgvKardex[16, 0].Value);
                Costo *= Saldo;
                gb1.Enabled = true;

            }
            txtSaldoInicial.Text = Saldo.ToString();
            foreach (DataGridViewRow row in dgvKardex.Rows)
            {
                Saldo += Convert.ToDecimal(row.Cells[3].Value) - Convert.ToDecimal(row.Cells[4].Value);
                Costo += Convert.ToDecimal(row.Cells[7].Value) - Convert.ToDecimal(row.Cells[8].Value);
                row.Cells[5].Value = Saldo;
                row.Cells[9].Value = Costo;
            }

            txtSaldoFinal.Text = Saldo.ToString();
        }
        private bool validaConsultar()
        {
            bool result = true;
            if (cboSucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija Sucursal !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSucursal.Focus();
                return result = false;
            }
            if (cboClase.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboClase.Focus();
                return result = false;
            }
            if (txtCodigo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Código !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                return result = false;
            }
            if (cboMesInicio.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes de Inicio !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMesInicio.Focus();
                return result = false;
            }
            if (cboMesFinal.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes de Fin !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMesFinal.Focus();
                return result = false;
            }
            if (cboAño.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAño.Focus();
                return result = false;
            }

            return result;
        }

        private void btn_archivo1_Click(object sender, EventArgs e)
        {

        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            REPORTES.FORM_REPORTES.REP_KARDEX_SALDO2 ofrmReporte = new REPORTES.FORM_REPORTES.REP_KARDEX_SALDO2();
            foreach (DataGridViewRow row in dgvKardex.Rows)
            {
                ofrmReporte.LLENAR_DATASET(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), txtCodigo.Text, txtDescripcion.Text, txtNroParte.Text,
                    row.Cells[2].Value.ToString(), Convert.ToDecimal(row.Cells[3].Value), Convert.ToDecimal(row.Cells[4].Value), Convert.ToDecimal(row.Cells[5].Value), row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), row.Cells[13].Value.ToString(), Convert.ToDecimal(row.Cells[7].Value), Convert.ToDecimal(row.Cells[8].Value),
                    Convert.ToDecimal(row.Cells[15].Value), row.Cells[14].Value.ToString(), Convert.ToDecimal(row.Cells[16].Value), row.Cells[9].Value.ToString(), Convert.ToDecimal(row.Cells[9].Value), Convert.ToDecimal(row.Cells[16].Value),
                    txtUnidadMedida.Text);
            }
            ofrmReporte.CREAR_REPORTE("EDICIONES AMERICANAS SAC", "20515538373", cboClase.SelectedValue.ToString(), cboMesInicio.SelectedValue.ToString(), cboMesFinal.SelectedValue.ToString(), "1", "AV. LAS NAZARENAS NRO. 912 URB. LAS GARDENIAS", cboAño.SelectedValue.ToString());
            ofrmReporte.ShowDialog();
        }

        private void btn_imprimir1_Click(object sender, EventArgs e)
        {

        }
    }
}
