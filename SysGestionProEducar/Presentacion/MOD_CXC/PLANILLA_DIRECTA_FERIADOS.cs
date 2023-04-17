using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.MOD_CXC
{
    public partial class PLANILLA_DIRECTA_FERIADOS : Form
    {
        string AÑO, MES, COD_MOD, TIPO_USU, COD_USU, boton, TIPO;
        DateTime FECHA_INI, FECHA_GRAL, fecha_activa;
        calendarioBLL calBLL = new calendarioBLL();
        calendarioTo calTo = new calendarioTo();
        public PLANILLA_DIRECTA_FERIADOS(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU, string TIPO)
        {
            InitializeComponent();
            this.AÑO = AÑO;
            this.MES = MES;
            this.FECHA_INI = FECHA_INI;
            this.FECHA_GRAL = FECHA_GRAL;
            this.COD_MOD = COD_MOD;
            this.TIPO_USU = TIPO_USU;
            this.COD_USU = COD_USU;
            this.TIPO = TIPO;
        }

        private void PLANILLA_DIRECTA_FERIADOS_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            DATAGRID();
            numAño.Value = Convert.ToDecimal(DateTime.Now.Year);
            CARGA_MESES();
            CARGA_FECHA_ACTIVA();
            btn_nuevo.Select();
        }
        private void CARGA_FECHA_ACTIVA()
        {
            calTo.TIPO = TIPO;
            dtp_fecha_activa.Value = Convert.ToDateTime(calBLL.obtenerFechaActivaBLL(calTo));
            fecha_activa = dtp_fecha_activa.Value;//Convert.ToDateTime(calBLL.obtenerFechaActivaBLL());
        }
        private void DATAGRID()
        {
            calTo.TIPO = TIPO;//D o P
            DataTable dt = calBLL.obtenerCalendarioBLL(calTo);
            if (dt.Rows.Count > 0)
            {
                dgvCalendario.Rows.Clear();
                foreach (DataRow rw in dt.Rows)
                {
                    int rowId = dgvCalendario.Rows.Add();
                    DataGridViewRow row = dgvCalendario.Rows[rowId];
                    row.Cells[0].Value = rw[0].ToString();
                    row.Cells[1].Value = HelpersBLL.OBTENER_NOM_MES(rw[0].ToString());
                    row.Cells[2].Value = rw[1].ToString();
                }
            }
        }
        private void PLANILLA_DIRECTA_FERIADOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGA_MESES()
        {
            var meses = new[] { new {cod="00", val=""},
                                new {cod="01", val="Enero"},
                                new {cod="02", val="Febrero"},
                                new {cod="03", val="Marzo"},
                                new {cod="04", val="Abril"},
                                new {cod="05", val="Mayo"},
                                new {cod="06", val="Junio"},
                                new {cod="07", val="Julio"},
                                new {cod="08", val="Agosto"},
                                new {cod="09", val="Septiembre"},
                                new {cod="10", val="Octubre"},
                                new {cod="11", val="Noviembre"},
                                new {cod="12", val="Diciembre"},
                                };
            cboMes.ValueMember = "cod";
            cboMes.DisplayMember = "val";
            cboMes.DataSource = meses;
        }
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            TabControl1.SelectedTab = TabPage2;
            cboMes.Focus();
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            Limpiar();

            CargarDatos();
            TabControl1.SelectedTab = TabPage2;
            cboMes.Focus();
        }
        private void Limpiar()
        {
            cboMes.SelectedIndex = 0;
            numAño.Value = Convert.ToDecimal(DateTime.Now.Year);
            foreach (var item in gbMes.Controls)
            {
                var chk = (CheckBox)item;
                chk.Checked = false;
            }
        }
        private void CargarDatos()
        {
            calTo.NuAño = dgvCalendario.CurrentRow.Cells[2].Value.ToString();
            calTo.NuMes = dgvCalendario.CurrentRow.Cells[0].Value.ToString();
            calTo.TIPO = TIPO;
            DataTable dt = calBLL.obtenerCalendarioDiasBLL(calTo);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    foreach (var item in gbMes.Controls)
                    {
                        var chk = (CheckBox)item;
                        if (chk.Text == rw[0].ToString())
                        {
                            chk.Checked = true;
                        }
                    }
                }
            }
            cboMes.SelectedValue = calTo.NuMes;
            numAño.Value = int.Parse(calTo.NuAño);
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de ingresar estos feriados ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                DataTable dt = obtenerFeriados();
                if (!calBLL.insertarCalendarioBLL(dt, TIPO, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se adicionaron correctamente los feriados !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TabControl1.SelectedTab = TabPage1;
                    dgvCalendario.Rows.Add(cboMes.SelectedValue, cboMes.Text.ToString().ToUpper(), numAño.Value.ToString());
                    btn_nuevo.Select();
                }
            }
        }
        private DataTable obtenerFeriados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NuAño", typeof(string));
            dt.Columns.Add("NuMes", typeof(string));
            dt.Columns.Add("NuDia", typeof(int));
            if (chkDia1.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia1.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia2.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia2.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia3.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia3.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia4.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia4.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia5.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia5.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia6.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia6.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia7.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia7.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia8.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia8.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia9.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia9.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia10.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia10.Text);
                dt.Rows.Add(rw);
            }

            if (chkDia11.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia11.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia12.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia12.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia13.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia13.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia14.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia14.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia15.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia15.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia16.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia16.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia17.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia17.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia18.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia18.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia19.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia19.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia20.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia20.Text);
                dt.Rows.Add(rw);
            }


            if (chkDia21.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia21.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia22.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia22.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia23.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia23.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia24.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia24.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia25.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia25.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia26.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia26.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia27.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia27.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia28.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia28.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia29.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia29.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia30.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia30.Text);
                dt.Rows.Add(rw);
            }
            if (chkDia31.Checked)
            {
                DataRow rw = dt.NewRow();
                rw["NuAño"] = numAño.Value.ToString();
                rw["NuMes"] = cboMes.SelectedValue.ToString();
                rw["NuDia"] = int.Parse(chkDia31.Text);
                dt.Rows.Add(rw);
            }
            return dt;
        }
        private bool valida()
        {
            bool result = true;
            if (cboMes.SelectedIndex <= 0)
            {
                MessageBox.Show("Elija el Mes !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMes.Focus();
                return result = false;
            }
            return result;
        }
        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedIndex > 0)
            {
                habilitaDias();
            }
            else if (cboMes.SelectedIndex == 0)
            {
                chkDia29.Visible = true;
                chkDia30.Visible = true;
                chkDia31.Visible = true;
            }
        }
        private void habilitaDias()
        {
            int Año = Convert.ToInt32(numAño.Value);
            int Mes = Convert.ToInt32(cboMes.SelectedValue);
            int dias = DateTime.DaysInMonth(Año, Mes);
            if (dias == 31)
            {
                chkDia29.Visible = true;
                chkDia30.Visible = true;
                chkDia31.Visible = true;
            }
            else if (dias == 30)
            {
                chkDia29.Visible = true;
                chkDia30.Visible = true;
                chkDia31.Visible = false;
            }
            else if (dias == 29)
            {
                chkDia29.Visible = true;
                chkDia30.Visible = false;
                chkDia31.Visible = false;
            }
            else if (dias == 28)
            {
                chkDia29.Visible = false;
                chkDia30.Visible = false;
                chkDia31.Visible = false;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!valida())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar los feriados del mes ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                calTo.NuAño = dgvCalendario.CurrentRow.Cells[2].Value.ToString();
                calTo.NuMes = dgvCalendario.CurrentRow.Cells[0].Value.ToString();
                calTo.TIPO = TIPO;
                DataTable dt = obtenerFeriados();
                if (!calBLL.modificarActualizarCalendarioBLL(calTo, dt, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modificaron correctamente los feriados !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }
        }

        private void btn_grabar_activo_Click(object sender, EventArgs e)
        {
            if (!validaFechaActiva())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de modificar la Fecha Activa ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                calTo.FECHA_ACTIVA = dtp_fecha_activa.Value;
                calTo.COD_MOD = COD_USU;
                calTo.FECHA_MOD = DateTime.Now;
                calTo.TIPO = TIPO;
                if (!calBLL.modificarFechaActivaBLL(calTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Se modifico correctamente la Fecha Activa !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_salirActivo.Focus();
                }
            }
        }
        private bool validaFechaActiva()
        {
            string errMensaje = "";
            bool result = true;
            calTo.FECHA_ACTIVA = dtp_fecha_activa.Value;
            calTo.TIPO = TIPO;
            if (calBLL.caeFeriadoBLL(calTo, ref errMensaje))
            {
                MessageBox.Show("La Fecha " + dtp_fecha_activa.Value.ToShortDateString() + " \nque se desea actualizar cae en dia Feriado !!!", "No se Actualizo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtp_fecha_activa.Value = fecha_activa;
                dtp_fecha_activa.Focus();
                return result = false;
            }
            else
            {
                if (errMensaje != "")
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        private void btn_salirActivo_Click(object sender, EventArgs e)
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
                    Limpiar();
                    if (dgvCalendario.Rows.Count == 0)
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


    }
}
