using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.MOD_COS
{
    public partial class frmValorizacion : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        iCostosBLL cosBLL = new iCostosBLL();
        iCostosTo cosTo = new iCostosTo();
        tCostosBLL tcosBLL = new tCostosBLL();
        tCostosTo tcosTo = new tCostosTo();
        public frmValorizacion(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tcGeneral.SelectedTab = tpListado;
            btn_aceptar1.Focus();
        }
        private void frmValorizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void frmValorizacion_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            tpDetalle.Parent = null;
            CargarClase();
            CargarSucursal();
            CargarMovimiento();
            CARGAR_AÑO();
            CBO_AÑO.Text = AÑO;
            CBO_MES.Text = MES;
            CARGAR_MOVIMIENTO();//CARGAR_MOVIMIENTO
            CARGAR_CLASE_ARTICULO();
        }
        private void CargarMovimiento()
        {
            movimientosBLL movBLL = new movimientosBLL();
            movimientosTo movTo = new movimientosTo();
            //
            cbo_mov.Items.Clear();
            DataTable dt = movBLL.obtenerMovimientosCostosBLL();
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.DataSource = dt;
            cbo_mov.SelectedIndex = -1;
            //
            cboMovimiento.ValueMember = "COD_MOV";
            cboMovimiento.DisplayMember = "DESC_MOV";
            cboMovimiento.DataSource = dt;
            cboMovimiento.SelectedIndex = -1;
        }
        private void CARGAR_AÑO()
        {
            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            //
            CBO_AÑO.Items.Clear();
            perTo.COD_MODULO = "COS";
            DataTable dt = perBLL.obtenerAñoPeriodoBLL(perTo);
            CBO_AÑO.ValueMember = "AÑO";
            CBO_AÑO.DisplayMember = "AÑO";
            CBO_AÑO.DataSource = dt;
        }
        private void CARGAR_CLASE_ARTICULO()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            articuloClaseTo clsTo = new articuloClaseTo();
            clsTo.COD_USU = COD_USU;
            clsTo.TIPO_USU = TIPO_USU;
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostosBLL(clsTo);
            cbo_clase.DataSource = dt;
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.SelectedIndex = -1;

        }
        private void CARGAR_MOVIMIENTO()
        {
            movimientosBLL movBLL = new movimientosBLL();
            DataTable dt = movBLL.obtenerMovimientosCostosPromedioBLL();
            cbo_mov.DataSource = dt;
            cbo_mov.ValueMember = "COD_MOV";
            cbo_mov.DisplayMember = "DESC_MOV";
            cbo_mov.SelectedIndex = -1;
        }
        private void CargarClase()
        {
            articuloClaseBLL clsBLL = new articuloClaseBLL();
            //articuloClaseTo clsTo = new articuloClaseTo();
            DataTable dt = clsBLL.obtenerArticuloClaseparaCostoPromedioBLL();
            cbo_clase.DataSource = dt;
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.SelectedIndex = -1;
            //
            cboClase.DataSource = dt;
            cboClase.DisplayMember = "DESC_CLASE";
            cboClase.ValueMember = "COD_CLASE";
            cboClase.SelectedIndex = -1;

        }
        private void CargarSucursal()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cboSucursal.ValueMember = "COD_SUCURSAL";
            cboSucursal.DisplayMember = "DESC_sucursal";
            cboSucursal.DataSource = dt;
            cboSucursal.SelectedIndex = -1;
        }

        private void CBO_MES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBO_MES.SelectedIndex > -1)
            {
                LBL_MES.Text = HelpersBLL.OBTENER_NOM_MES(CBO_MES.Text);
            }
        }

        private void btn_aceptar1_Click(object sender, EventArgs e)
        {
            if (!validaAceptar("Aceptar"))
                return;

            CARGAR_DETALLE();
        }
        private void CARGAR_DETALLE()
        {
            cosTo.FE_AÑO = CBO_AÑO.Text;//AÑO;
            cosTo.FE_MES = CBO_MES.Text;//MES;
            cosTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            cosTo.COD_MOV = cbo_mov.SelectedValue.ToString();
            DataTable dt = cosBLL.MOSTRAR_I_COSTOS_DEVOLUCION(cosTo);
            if (dt.Rows.Count > 0)
            {
                DGW_DET.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowid = DGW_DET.Rows.Add();
                    DataGridViewRow row = DGW_DET.Rows[rowid];
                    row.Cells[0].Value = rw["COD_SUCURSAL"].ToString();
                    row.Cells[1].Value = rw["DESC_SUCURSAL"].ToString();
                    row.Cells[2].Value = rw["COD_CLASE"].ToString();
                    row.Cells[3].Value = rw["COD_PER"].ToString();
                    row.Cells[4].Value = rw["DESC_PER"].ToString();
                    row.Cells[5].Value = rw["NRO_DOC"].ToString();
                    row.Cells[6].Value = rw["COD_DOC_INV"].ToString();
                    row.Cells[7].Value = rw["NRO_DOC_INV"].ToString();
                    row.Cells[8].Value = rw["FECHA_DOC_INV"].ToString();
                    row.Cells[9].Value = rw["COD_MOV"].ToString();
                    row.Cells[10].Value = rw["DESC_MOV"].ToString();
                    row.Cells[11].Value = rw["FE_AÑO"].ToString();
                    row.Cells[12].Value = rw["FE_MES"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se a encontrado registros", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_clase.Focus();
            }
        }

        private bool validaAceptar(string op)
        {
            string errMensaje = "";
            bool result = true;
            if (CBO_MES.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_MES.Focus();
                return result = false;
            }
            if (CBO_AÑO.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CBO_AÑO.Focus();
                return result = false;
            }
            if (cbo_clase.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Clase de Articulos !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (cbo_mov.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el Movimiento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_mov.Focus();
                return result = false;
            }
            if (op == "Aceptar")
            {
                if (!VERIFICAR_CIERRE_PERIODO(CBO_AÑO.SelectedValue.ToString(), CBO_MES.Text, "COS", ref errMensaje))
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("No se puede realizar ningún proceso, el periodo se encuentra cerrado !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }

            return result;
        }
        private bool VERIFICAR_CIERRE_PERIODO(string AÑO0, string MES0, string MOD0, ref string errMensaje)
        {
            bool result = true;

            periodoBLL perBLL = new periodoBLL();
            periodoTo perTo = new periodoTo();
            perTo.AÑO = AÑO0;
            perTo.MES = MES0;
            perTo.COD_MODULO = MOD0;
            if (!perBLL.VERIFICAR_CIERRE_PERIODO_BLL(perTo, ref errMensaje))
                return result = false;
            return result;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!validaAceptar("Aceptar"))
                return;

            tpDetalle.Parent = tcGeneral;
            tcGeneral.SelectedTab = tpDetalle;
            LimpiarCab();
            CargarDatos();
            Sum_Total();
        }
        private void LimpiarCab()
        {
            cboClase.SelectedIndex = -1;
            cboSucursal.SelectedIndex = -1;
            cboSucursal.SelectedIndex = -1;
        }
        private void CargarDatos()
        {
            int i;
            if (DGW_DET.Rows.Count > 0)
            {
                i = DGW_DET.CurrentRow.Index;
                cboSucursal.SelectedValue = DGW_DET[0, i].Value;
                cboClase.SelectedValue = DGW_DET[2, i].Value;
                txtCodigoProv.Text = DGW_DET[3, i].Value.ToString();
                txtDescripcionProv.Text = DGW_DET[4, i].Value.ToString();
                txtDocumentoProv.Text = DGW_DET[5, i].Value.ToString();
                txtCodDoc.Text = DGW_DET[6, i].Value.ToString();
                txtSerie.Text = DGW_DET[7, i].Value.ToString().Substring(0, 3);
                txtNumero.Text = DGW_DET[7, i].Value.ToString().Substring(4);
                dtpFechaInventario.Value = Convert.ToDateTime(DGW_DET[8, i].Value);
                cboMovimiento.SelectedValue = DGW_DET[9, i].Value;

                CargarDetalle(DGW_DET[0, i].Value.ToString(), DGW_DET[2, i].Value.ToString(), DGW_DET[9, i].Value.ToString(), DGW_DET[6, i].Value.ToString(), DGW_DET[7, i].Value.ToString(),
                txtCodigoProv.Text, AÑO, MES);
                CargarAlmacen(DGW_DET[2, i].Value.ToString(), DGW_DET[0, i].Value.ToString());
            }
        }
        private void CargarAlmacen(string cod_clase, string cod_sucursal)
        {
            almacenesBLL almBLL = new almacenesBLL();
            almacenTo almTo = new almacenTo();
            almTo.COD_CLASE = cod_clase;
            almTo.COD_SUCURSAL = cod_sucursal;
            cboAlmacen.ValueMember = "COD_ALMACEN";
            cboAlmacen.DisplayMember = "DESC_CORTA";
            cboAlmacen.DataSource = almBLL.obtenerAlmacenesparaInventarioBLL(almTo);
        }
        private void CargarDetalle(string Sucursal00, string Clase00, string Movimiento00, string CodDocInv00, string NroDocInv00,
        string CodPer00, string Año00, string Mes00)
        {
            dgvDetalle.Rows.Clear();
            tcosTo.COD_SUCURSAL = Sucursal00;
            tcosTo.COD_CLASE = Clase00;
            tcosTo.COD_MOV = Movimiento00;
            tcosTo.COD_DOC_INV = CodDocInv00;
            tcosTo.NRO_DOC_INV = NroDocInv00;
            tcosTo.COD_PER = CodPer00;
            tcosTo.FE_AÑO = Año00;
            tcosTo.FE_MES = Mes00;
            DataTable dt = tcosBLL.MOSTRAR_T_COSTOS_DEVOLUCION(tcosTo);
            if (dt.Rows.Count > 0)
            {
                dgvDetalle.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowid = dgvDetalle.Rows.Add();
                    DataGridViewRow row = dgvDetalle.Rows[rowid];
                    row.Cells[0].Value = rw["ITEM"].ToString();
                    row.Cells[1].Value = rw["COD_ARTICULO"].ToString();
                    row.Cells[2].Value = rw["DESC_ARTICULO"].ToString();
                    row.Cells[3].Value = rw["NRO_PARTE"].ToString();
                    row.Cells[4].Value = rw["CANTIDAD"].ToString();
                    row.Cells[5].Value = rw["PRECIO_CON"].ToString();
                    row.Cells[6].Value = rw["VALOR_CON"].ToString();
                    row.Cells[7].Value = rw["COD_ALMACEN"].ToString();
                    row.Cells[8].Value = rw["DESC_CORTA"].ToString();
                    row.Cells[9].Value = rw["COD_MONEDA"].ToString();
                    row.Cells[10].Value = rw["COD_D_H"].ToString();
                    row.Cells[11].Value = rw["CANTIDAD"].ToString();
                    row.Cells[12].Value = rw["NRO_ITEM"].ToString();
                }
            }
        }
        private void Sum_Total()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                total += Convert.ToDecimal(row.Cells[6].Value);
            }
            TXT_TT.Text = string.Format(total.ToString(), "###,###,##0.00");
        }

        private void btn_grabar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                int num = DGW_DET.Rows.Count - 1;
                int num3 = num;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgvDetalle);
                cosTo.COD_SUCURSAL = cboSucursal.SelectedValue.ToString();
                cosTo.COD_CLASE = cboClase.SelectedValue.ToString();
                cosTo.COD_MOV = cbo_mov.SelectedValue.ToString();
                cosTo.COD_DOC_INV = txtCodDoc.Text;
                cosTo.NRO_DOC_INV = txtSerie.Text + "-" + txtNumero.Text;
                cosTo.COD_PER = txtCodigoProv.Text;
                tcosTo.FE_AÑO = CBO_AÑO.Text;
                tcosTo.FE_MES = CBO_MES.Text;
                if (!tcosBLL.ACTUALIZAR_T_COSTOS_DEVOLUCION(cosTo, dtDetalle, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Se grabaron correctamente los datos !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //TabControl1.SelectedTab = TabPage3;

                }
            }
        }

        private void btn_mod_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                int idx = dgvDetalle.CurrentRow.Index;
                txtCodProducto.Text = dgvDetalle[1, idx].Value.ToString();
                txtDescProducto.Text = dgvDetalle[2, idx].Value.ToString();
                TXT_NRO_PARTE.Text = dgvDetalle[3, idx].Value.ToString();
                txtCantidad.Text = dgvDetalle[4, idx].Value.ToString();
                txtPrecio.Text = dgvDetalle[5, idx].Value.ToString();
                txtTotal.Text = dgvDetalle[6, idx].Value.ToString();
                cboAlmacen.SelectedValue = dgvDetalle[7, idx].Value;
            }
        }

        private void btnAceptaModifica_Click(object sender, EventArgs e)
        {
            int idx = dgvDetalle.CurrentRow.Index;
            dgvDetalle[5, idx].Value = txtPrecio.Text;
            dgvDetalle[6, idx].Value = txtTotal.Text;
            Sum_Total();
            CancelarModificacion();
        }
        public void CancelarModificacion()
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
        }

        private void btnCancelaModifica_Click(object sender, EventArgs e)
        {
            CancelarModificacion();
        }

        private void tcGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                CancelarModificacion();
                tpDetalle.Parent = null;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecio.Text = HelpersBLL.OBTIENE_PRECIO_TRES_DECIMALES(txtPrecio.Text);
                txtTotal.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES((Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text)).ToString());
            }
            catch (Exception)
            {
                txtPrecio.Text = "0.000";
            }
        }
    }
}
