using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class Cambio : Form
    {
        string mes5, año5, boton;
        string mes2, año2, dia2, cod_tipo, cod_moneda;
        tipoCambioBLL tpcBLL = new tipoCambioBLL();
        tipoCambioTo tpcTo = new tipoCambioTo();
        public Cambio()
        {
            InitializeComponent();
        }

        private void Cambio_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            cargar_monedas();
            cargar_año();
            cargar_mes();
            //mes5 = DateTime.Now.ToString("MM");
            //año5 = DateTime.Now.Year.ToString();
            mes5 = null;
            año5 = null;
            //cbo_mes.SelectedValue = mes5;
            //cbo_año.SelectedValue = año5;
            //'------------------------
            //cbo_año.Text = DateTime.Now.Year.ToString();
            ////cbo_mes.Text = DateTime.Now.ToString("MM");
            //cbo_mes.SelectedValue = DateTime.Now.ToString("MM");
            dtp1.Value = DateTime.Now;
            btn_Nuevo.Select();
        }

        private void Cambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void cargar_mes()
        {
            var months = new[] { new { cod = "01", val = "Enero" }, new { cod = "02", val = "Febrero" },
                                new { cod = "03", val = "Marzo" }, new { cod = "04", val = "Abril" },
                                new { cod = "05", val = "Mayo" }, new { cod = "06", val = "Junio" },
                                new { cod = "07", val = "Julio" }, new { cod = "08", val = "Agosto" },
                                new { cod = "09", val = "Septiembre" }, new { cod = "10", val = "Octubre" },
                                new { cod = "11", val = "Noviembre" }, new { cod = "12", val = "Diciembre" }};
            cbo_mes.ValueMember = "cod";
            cbo_mes.DisplayMember = "val";
            cbo_mes.DataSource = months;
            cbo_mes.SelectedIndex = 0;
        }
        public void cargar_monedas()
        {
            DataTable dt = tpcBLL.obtenerMonedasBLL();
            cbo_moneda1.ValueMember = "cod_moneda";
            cbo_moneda1.DisplayMember = "desc_moneda";
            cbo_moneda1.DataSource = dt;
            //
            cbo_moneda2.ValueMember = "cod_moneda";
            cbo_moneda2.DisplayMember = "desc_moneda";
            cbo_moneda2.DataSource = dt;
        }
        private void cargar_año()
        {
            DataTable dt = tpcBLL.obtenerAnnioBLL();
            if (dt.Rows.Count > 0)
            {
                cbo_año.ValueMember = "año";
                cbo_año.DisplayMember = "año";
                cbo_año.DataSource = dt;
                cbo_año.SelectedIndex = 0;
            }
            else
            {
                var aa = new[] { new { cod = DateTime.Now.Year, val = DateTime.Now.Year } };
                cbo_año.ValueMember = "cod";
                cbo_año.DisplayMember = "val";
                cbo_año.DataSource = aa;
                cbo_año.SelectedIndex = 0;
            }
        }

        private void cbo_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_mes.SelectedValue != null)
            {
                //if ((cbo_mes.SelectedIndex > -1 && cbo_año.SelectedIndex > -1))
                //{
                //    mes5 = cbo_mes.SelectedValue.ToString();
                //    datagrid();
                //    if (dgw1.Rows.Count == 0)
                //        MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                mes5 = cbo_mes.SelectedValue.ToString();
                datagrid();
            }
        }
        private void datagrid()
        {
            if (mes5 != null && año5 != null)
            {
                dgw1.DataSource = null;
                tpcTo.Mes = mes5;
                tpcTo.Año = año5;
                DataTable dt = tpcBLL.mostrarTipoCambioBLL(tpcTo);
                if (dt.Rows.Count > 0)
                {
                    dgw1.DataSource = dt;
                    dgw1.Columns[0].Width = 30;
                    dgw1.Columns[1].Visible = false;
                    dgw1.Columns[2].Width = 140;
                    dgw1.Columns[3].Width = 50;
                    dgw1.Columns[4].Width = 50;
                    dgw1.Columns[5].Visible = false;
                    dgw1.Columns[6].Visible = false;
                    dgw1.Columns[7].Visible = false;
                    dgw1.Columns[8].Visible = false;
                }
                else
                    MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbo_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_año.SelectedValue != null)
            {
                //if ((cbo_mes.SelectedIndex > -1 && cbo_año.SelectedIndex > -1))
                //{
                //    año5 = cbo_año.SelectedValue.ToString();
                //    datagrid();
                //    if (dgw1.Rows.Count == 0)
                //        MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                año5 = cbo_año.SelectedValue.ToString();
                datagrid();
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            limpiar();
            cbo_moneda1.Enabled = true;
            dtp1.Enabled = true;
            if (cbo_mes.SelectedValue != null && cbo_año.SelectedValue != null)
            {
                dtp1.Value = Convert.ToDateTime("01/" + cbo_mes.SelectedValue.ToString() + "/" + cbo_año.SelectedValue.ToString());
                btn_guardar.Visible = true;
                btn_modificar2.Visible = false;
                TabControl1.SelectedTab = TabPage2;
            }
            else
                MessageBox.Show("Elija el mes y el año !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void limpiar()
        {
            dtp1.Enabled = true;
            cbo_moneda1.SelectedIndex = -1;
            txt_compra.Clear();
            txt_venta.Clear();
            txt_compra_paralelo.Text = "0.00";
            txt_venta_paralelo.Text = "0.00";
            cbo_moneda1.Enabled = true;
            txt_compra.ReadOnly = false;
            txt_venta.ReadOnly = false;
            txt_compra_paralelo.ReadOnly = false;
            txt_venta_paralelo.ReadOnly = false;
            cbo_moneda1.Focus();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            boton = "MODIFICAR";
            limpiar();
            cargar_datos();
            cbo_moneda1.Enabled = false;
            dtp1.Enabled = false;
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            TabControl1.SelectedTab = TabPage2;
        }
        private void cargar_datos()
        {
            string tipo, dia3, mes3, año3;
            dia3 = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            tipo = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            cbo_moneda1.Text = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            txt_venta.Text = dgw1[3, dgw1.CurrentRow.Index].Value.ToString();
            txt_compra.Text = dgw1[4, dgw1.CurrentRow.Index].Value.ToString();
            año3 = dgw1[5, dgw1.CurrentRow.Index].Value.ToString();
            mes3 = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            txt_venta_paralelo.Text = dgw1[7, dgw1.CurrentRow.Index].Value.ToString();
            txt_compra_paralelo.Text = dgw1[8, dgw1.CurrentRow.Index].Value.ToString();
            string f;
            f = dia3 + "/" + mes3 + "/" + año3;
            DateTime d;
            d = System.DateTime.Parse(f);
            dtp1.Value = d;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de grabar el Tipo de Cambio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                tpcTo.Cod_Moneda = cbo_moneda1.SelectedValue.ToString();
                tpcTo.Año = dtp1.Value.Year.ToString();
                tpcTo.Mes = dtp1.Value.ToString("MM");
                tpcTo.Dia = dtp1.Value.ToString("dd");
                tpcTo.Tipo_Compra = Convert.ToDecimal(txt_compra.Text);
                tpcTo.Tipo_Venta = Convert.ToDecimal(txt_venta.Text);
                tpcTo.Tipo_Compra_Paralelo = Convert.ToDecimal(txt_compra_paralelo.Text);
                tpcTo.Tipo_Venta_Paralelo = Convert.ToDecimal(txt_venta_paralelo.Text);
                if (!tpcBLL.insertarTipoCambioBLL(tpcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Tipo de Cambio se grabo correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagrid();
                    limpiar();
                    dtp1.Value = dtp1.Value.AddDays(1);
                    TabControl1.SelectedTab = TabPage1;
                }
            }
        }
        private bool validaGuardarModificar()
        {
            bool result = true;
            string errMensaje = "";
            if (cbo_moneda1.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Moneda !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_moneda1.Focus();
                return result = false;
            }
            if (!HelpersBLL.esNumeroDecimal(txt_compra.Text, false))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_compra.Focus();
                return result = false;
            }
            if (!HelpersBLL.esNumeroDecimal(txt_venta.Text, false))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_venta.Focus();
                return result = false;
            }
            if (!HelpersBLL.esNumeroDecimal(txt_compra_paralelo.Text, false))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_compra_paralelo.Focus();
                return result = false;
            }
            if (!HelpersBLL.esNumeroDecimal(txt_venta_paralelo.Text, false))
            {
                MessageBox.Show("Cantidad no válida !!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_venta_paralelo.Focus();
                return result = false;
            }
            if (btn_guardar.Visible)
            {
                tpcTo.Cod_Moneda = cbo_moneda1.SelectedValue.ToString();
                tpcTo.Año = dtp1.Value.ToString("yyyy");
                tpcTo.Mes = dtp1.Value.ToString("MM");
                tpcTo.Dia = dtp1.Value.ToString("dd");
                if (!tpcBLL.VerificarTipoCambioBLL(tpcTo, ref errMensaje))
                {
                    MessageBox.Show("Este registro ya existe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbo_moneda1.Focus();
                    return result = false;
                }
                else
                {
                    if (errMensaje != "")
                        MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_Nuevo.Select();
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar el Tipo de Cambio ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                tpcTo.Cod_Moneda = cbo_moneda1.SelectedValue.ToString();
                tpcTo.Año = dtp1.Value.Year.ToString();
                tpcTo.Mes = dtp1.Value.ToString("MM");
                tpcTo.Dia = dtp1.Value.ToString("dd");
                tpcTo.Tipo_Compra = Convert.ToDecimal(txt_compra.Text);
                tpcTo.Tipo_Venta = Convert.ToDecimal(txt_venta.Text);
                tpcTo.Tipo_Compra_Paralelo = Convert.ToDecimal(txt_compra_paralelo.Text);
                tpcTo.Tipo_Venta_Paralelo = Convert.ToDecimal(txt_venta_paralelo.Text);
                if (!tpcBLL.modificarTipoCambioBLL(tpcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Tipo de Cambio se modifico correctamente !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    datagrid();
                    TabControl1.SelectedTab = TabPage1;
                    btn_Nuevo.Select();
                }
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_Nuevo.Select();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de eliminar el Tipo de Cambio elegido ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                //string errMensaje = "";
                //pemTo.COD_PER = dgw.CurrentRow.Cells[0].Value.ToString();
                string errMensaje = "";
                tpcTo.Cod_Moneda = dgw1.CurrentRow.Cells[1].Value.ToString();
                tpcTo.Año = dgw1.CurrentRow.Cells[5].Value.ToString();
                tpcTo.Mes = dgw1.CurrentRow.Cells[6].Value.ToString();
                tpcTo.Dia = dgw1.CurrentRow.Cells[0].Value.ToString();

                if (!tpcBLL.eliminaTipodeCambioBLL(tpcTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("El Tipo de Cambio se eliminó correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cargaDataGrid();//No se necesita si se remueve del grid con RemoveAt
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                    btn_Nuevo.Select();
                }
            }
        }
    }
}
