using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_ADM
{
    public partial class PERIODO_COSTOS : Form
    {
        int tipo; string mes5; string codmod; string boton; string COD_USU;
        DataTable dtPeriodo;
        periodoBLL prdBLL = new periodoBLL();
        periodoTo prdTo = new periodoTo();
        public PERIODO_COSTOS(int tipo, string COD_USU)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.COD_USU = COD_USU;
        }

        private void PERIODO_COSTOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cbo_año.Value = DateTime.Now.Year;
            //
            if (tipo == 1)
            {
                this.Text = "Periodo de Modulo de Ventas";
                codmod = "VTA";
            }
            else if (tipo == 2)
            {
                this.Text = "Periodo de Modulo de Almacen";
                codmod = "ALM";
            }
            else if (tipo == 3)
            {
                this.Text = "Periodo de Modulo de Comisiones";
                codmod = "COM";
                btn_cierre.Enabled = true;
                BTN_CIERRE2.Enabled = true;
            }
            else if (tipo == 4)
            {
                this.Text = "Periodo de Modulo de Cuentas por Cobrar";
                codmod = "CXC";
            }
            else if (tipo == 5)
                this.Text = "Periodo de Modulo de Facturacion de Compras";
            else if (tipo == 6)
            {
                this.Text = "Periodo de Modulo de Facturacion de Ventas";
                codmod = "FVT";
            }
            else if (tipo == 7)
            {
                this.Text = "Periodo de Modulo de Costos";
                codmod = "COS";
                btn_cierre.Enabled = true;
                BTN_CIERRE2.Enabled = true;
            }
            //codmod = "COS";
            llenacomboMes();
            cargaGrid();
        }
        private void llenacomboMes()
        {
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "nom";
            cbo_mes.DataSource = HelpersBLL.OBTENER_MESES();
        }
        private void PERIODO_COSTOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cargaGrid()
        {
            //prdTo.COD_MODULO = "VTA";
            prdTo.COD_MODULO = codmod;
            dtPeriodo = prdBLL.obtenerPeriodoBLL(prdTo);
            if (dtPeriodo.Rows.Count > 0)
            {
                foreach (DataRow rw in dtPeriodo.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["annio"].Value = rw["Año"].ToString();
                    row.Cells["mes"].Value = rw["Mes"].ToString();
                    row.Cells["ini"].Value = rw["Inicio"].ToString().Substring(0, 10);
                    row.Cells["fin"].Value = rw["Final"].ToString().Substring(0, 10);
                    row.Cells["act"].Value = rw["Activo"].ToString();
                    row.Cells["cer"].Value = rw["Cerrado"].ToString();
                    row.Cells["mess"].Value = rw["mess"].ToString();
                }
                dgw1.Rows[dgw1.Rows.Count - 1].Selected = true;
                dgw1.CurrentCell = dgw1.Rows[dgw1.Rows.Count - 1].Cells[0];
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            //if (!validaNuevoPeriodo(codmod))//para crear uno nuevo tienes que cerrar el actual.
            //    return;
            boton = "NUEVO";
            limpiar();
            grvDatos.Enabled = true;
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            TabControl1.SelectedTab = TabPage2;
            cbo_año.Focus();
        }
        private void limpiar()
        {
            cbo_mes.SelectedIndex = -1;
            cbo_año.Enabled = true;
            cbo_mes.Enabled = true;
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            limpiar();
            grvDatos.Enabled = true;
            CARGAR_DATOS();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            TabControl1.SelectedTab = TabPage2;
            cbo_año.Enabled = false;
            cbo_mes.Enabled = false;
        }
        private void CARGAR_DATOS()
        {
            cbo_año.Value = Convert.ToDecimal(dgw1[0, dgw1.CurrentRow.Index].Value);
            cbo_mes.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            dtp1.Value = Convert.ToDateTime(dgw1[2, dgw1.CurrentRow.Index].Value);
            dtp2.Value = Convert.ToDateTime(dgw1[3, dgw1.CurrentRow.Index].Value);
        }
        private void cbo_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = cbo_mes.SelectedIndex;
            DateTime fechaPrimerDiaPeriodo;
            switch (m)
            {
                case 0: mes5 = "01"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 1: mes5 = "02"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 2: mes5 = "03"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 3: mes5 = "04"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 4: mes5 = "05"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 5: mes5 = "06"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 6: mes5 = "07"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 7: mes5 = "08"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 8: mes5 = "09"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 9: mes5 = "10"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 10: mes5 = "11"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 11: mes5 = "12"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01/" + mes5 + "/" + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
            }
        }
        private void mostrarPrimerUltimoPeriodo(DateTime fecha)
        {
            dtp1.Value = fecha;
            dtp2.Value = fecha.AddMonths(1).AddDays(-1);
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                    limpiar();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                        CARGAR_DATOS();

                    grvDatos.Enabled = false;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaNuevoPeriodo(codmod))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = cbo_año.Value.ToString(); ;
                prdTo.MES = mes5;
                prdTo.FECHA_INICIO = dtp1.Value;
                prdTo.FECHA_CIERRE = dtp2.Value;
                if (!prdBLL.insertarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionó correctamente el periodo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    foreach (DataGridViewRow row in dgw1.Rows)
                        row.Cells["act"].Value = false;
                    dgw1.Rows.Add(cbo_año.Value.ToString(), cbo_mes.Text, dtp1.Value.ToShortDateString(), dtp2.Value.ToShortDateString(),
                        true, false, mes5);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private bool validaNuevoPeriodo(string cod_mod)
        {
            bool result = true;
            var query = from DataGridViewRow row in dgw1.Rows
                        where row.Cells[0].Value.ToString() == cbo_año.Value.ToString() && row.Cells["mess"].Value.ToString() == cbo_mes.SelectedValue.ToString()
                        select row;
            if (query.Count() > 0)
            {
                MessageBox.Show("Ya existe el periodo " + cbo_mes.Text + " " + cbo_año.Value.ToString() + " !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_año.Focus();
                return result = false;
            }
            else if (cod_mod == "COM")
            {
                if (dgw1.Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(dgw1.Rows[dgw1.Rows.Count - 1].Cells["cer"].Value))
                    {
                        MessageBox.Show("El último periodo aún no ha sido cerrado \n Ciérralo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }

            return result;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = cbo_año.Value.ToString(); ;
                prdTo.MES = mes5;
                prdTo.FECHA_INICIO = dtp1.Value;
                prdTo.FECHA_CIERRE = dtp2.Value;
                if (!prdBLL.modificarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificó correctamente el Periodo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw1.CurrentRow.Index;
                    dgw1[0, idx].Value = cbo_año.Value;
                    dgw1[1, idx].Value = cbo_mes.Text;
                    dgw1[2, idx].Value = dtp1.Value.ToShortDateString();
                    dgw1[3, idx].Value = dtp2.Value.ToShortDateString();
                    //dgw1[4, idx].Value = true;
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Activar este Periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    row.Cells[4].Value = false;
                }
                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = dgw1.CurrentRow.Cells[0].Value.ToString();
                prdTo.MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                if (!prdBLL.activarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se Activó correctamente el Periodo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw1.CurrentRow.Index;
                    dgw1[4, idx].Value = true;
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_cierre_Click(object sender, EventArgs e)
        {
            if (!validaCierrePeriodoActual(codmod))
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Cerrar este Periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //foreach (DataGridViewRow row in dgw1.Rows)
                //{
                //    row.Cells[5].Value = false;
                //}
                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = dgw1.CurrentRow.Cells[0].Value.ToString();
                prdTo.MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                prdTo.TIPO_MODULO = tipo;
                prdTo.COD_USU = COD_USU;
                //if (!prdBLL.cerrarPeriodoBLL(prdTo, ref errMensaje))
                if (!prdBLL.procesoCerrarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se Cerró correctamente el Periodo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw1.CurrentRow.Index;
                    dgw1[5, idx].Value = true;
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private bool validaCierrePeriodoActual(string cod_mod)
        {
            bool result = true;
            string errMensaje = "";
            bool val = false;
            if (cod_mod == "COM")//solo cuando son Comisiones
            {
                //Generacion de Comisiones Contratos
                pComisionBLL pcomBLL = new pComisionBLL();
                pComisionTo pcomTo = new pComisionTo();
                pcomTo.FE_AÑO = dgw1.CurrentRow.Cells["annio"].Value.ToString();
                pcomTo.FE_MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                if (!pcomBLL.validaCierrePeriodoComisionGeneradaBLL(pcomTo, ref val, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
                else
                {
                    if (val)
                    {
                        MessageBox.Show("No se cerró el Periodo, porque \nNo se han generado todos los Contratos del Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
                //Generacion de  Devoluciones Contratos
                val = false; errMensaje = "";
                pDevolucionBLL pdevBLL = new pDevolucionBLL();
                pDevolucionTo pdevTo = new pDevolucionTo();
                pdevTo.FE_AÑO = dgw1.CurrentRow.Cells["annio"].Value.ToString();
                pdevTo.FE_MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                if (!pdevBLL.validaCierrePeriodoDevolucionGeneradaBLL(pdevTo, ref val, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
                else
                {
                    if (val)
                    {
                        MessageBox.Show("No se cerró el Periodo, porque \nNo se han generado todas las Devoluciones del Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
                //Generacion de Adelantos
                val = false; errMensaje = "";
                pAdelantoBLL padeBLL = new pAdelantoBLL();
                pAdelantoTo padeTo = new pAdelantoTo();
                padeTo.FE_AÑO = dgw1.CurrentRow.Cells["annio"].Value.ToString();
                padeTo.FE_MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                if (!padeBLL.validaCierrePeriodoAdelantoGeneradoBLL(padeTo, ref val, ref errMensaje))
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
                else
                {
                    if (val)
                    {
                        MessageBox.Show("No se cerró el Periodo, porque \nNo se han generado todos los Adelantos del Periodo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return result = false;
                    }
                }
            }

            return result;
        }
        private void BTN_CIERRE2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Regresar el Cierre de Periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //foreach (DataGridViewRow row in dgw1.Rows)
                //{
                //    row.Cells[5].Value = false;
                //}
                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = dgw1.CurrentRow.Cells[0].Value.ToString();
                prdTo.MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                prdTo.TIPO_MODULO = tipo;
                if (!prdBLL.regresarCerrarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se Regresó correctamente el Periodo Cerrado !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Periodo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = dgw1.CurrentRow.Cells[0].Value.ToString();
                prdTo.MES = dgw1.CurrentRow.Cells["mess"].Value.ToString();
                //prdTo.TIPO_MODULO = tipo;
                if (!prdBLL.eliminarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se eliminó correctamente el Periodo !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dgw1.Rows.Count >= 2)
                    {
                        int idx = dgw1.Rows[dgw1.Rows.Count - 2].Index;
                        dgw1[4, idx].Value = true;
                    }
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

    }
}
