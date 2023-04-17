using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class PERIODO : Form
    {
        int tipo; string mes5; string codmod; string boton;
        DataTable dtPeriodo;
        periodoBLL prdBLL = new periodoBLL();
        periodoTo prdTo = new periodoTo();
        public PERIODO(int tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        private void PERIODO_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cbo_año.Value = DateTime.Now.Year;
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
            llenacomboMes();
            cargaGrid();
        }
        private void llenacomboMes()
        {
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "nom";
            cbo_mes.DataSource = HelpersBLL.OBTENER_MESES();
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
                    row.Cells["mess"].Value = rw["mess"].ToString();
                }
            }
        }
        private void PERIODO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
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

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL PERIODO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                //prdTo.COD_MODULO = "VTA";
                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = cbo_año.Value.ToString(); ;
                prdTo.MES = mes5;
                prdTo.FECHA_INICIO = dtp1.Value;
                prdTo.FECHA_CIERRE = dtp2.Value;
                if (!prdBLL.modificarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL PERIODO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw1.CurrentRow.Index;
                    dgw1[0, idx].Value = cbo_año.Value;
                    dgw1[1, idx].Value = cbo_mes.SelectedItem.ToString();
                    dgw1[2, idx].Value = dtp1.Value.ToShortDateString();
                    dgw1[3, idx].Value = dtp2.Value.ToShortDateString();
                    //dgw1[4, idx].Value = true;
                    TabControl1.SelectedTab = TabPage1;
                }
            }

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgw1.Rows)
                {
                    row.Cells[4].Value = false;
                }
            }
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ADICIONAR UN NUEVO PERIODO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                //string tipo_doc = perBLL.obtenerCodTipoDocBLL(cbo_tipo_doc.Text);
                //prdTo.COD_MODULO = "VTA";
                prdTo.COD_MODULO = codmod;
                prdTo.AÑO = cbo_año.Value.ToString(); ;
                prdTo.MES = mes5;
                prdTo.FECHA_INICIO = dtp1.Value;
                prdTo.FECHA_CIERRE = dtp2.Value;
                if (!prdBLL.insertarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL PERIODO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.Add(cbo_año.Value.ToString(), cbo_mes.SelectedItem.ToString(), dtp1.Value.ToShortDateString(), dtp2.Value.ToShortDateString(),
                        true, mes5);
                    TabControl1.SelectedTab = TabPage1;
                }
            }

        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ACTIVAR ESTE PERIODO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                //prdTo.STATUS_ACTIVO = "1";
                if (!prdBLL.activarPeriodoBLL(prdTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ACTIVÓ CORRECTAMENTE EL PERIODO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    int idx = dgw1.CurrentRow.Index;
                    //dgw1[0, idx].Value = cbo_año.Value;
                    //dgw1[1, idx].Value = cbo_mes.SelectedItem.ToString();
                    //dgw1[2, idx].Value = dtp1.Value.ToShortDateString();
                    //dgw1[3, idx].Value = dtp2.Value.ToShortDateString();
                    dgw1[4, idx].Value = true;
                    TabControl1.SelectedTab = TabPage1;
                }
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
        }

        private void cbo_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = cbo_mes.SelectedIndex;
            DateTime fechaPrimerDiaPeriodo;
            switch (m)
            {
                case 0: mes5 = "01"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 1: mes5 = "02"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 2: mes5 = "03"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 3: mes5 = "04"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 4: mes5 = "05"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 5: mes5 = "06"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 6: mes5 = "07"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 7: mes5 = "08"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 8: mes5 = "09"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 9: mes5 = "10"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 10: mes5 = "11"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
                case 11: mes5 = "12"; fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString()); mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo); break;
            }
            // fechaPrimerDiaPeriodo = Convert.ToDateTime("01" + mes5 + cbo_año.Value.ToString());
            //mostrarPrimerUltimoPeriodo(fechaPrimerDiaPeriodo);
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
    }
}
