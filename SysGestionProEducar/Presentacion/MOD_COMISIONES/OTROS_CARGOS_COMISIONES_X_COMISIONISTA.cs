using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.MOD_COMISIONES
{
    public partial class OTROS_CARGOS_COMISIONES_X_COMISIONISTA : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", COD_USU = "", TIPO_USU = "";
        DateTime FECHA_INI, FECHA_GRAL;
        string boton;
        DataTable dtOtros;
        DataTable dtCptoCargos = new DataTable();
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        directorioBLL dirBLL = new directorioBLL();
        directorioTo dirTo = new directorioTo();
        otrosCargosComisionesBLL occBLL = new otrosCargosComisionesBLL();
        otrosCargosComisionesTo occTo = new otrosCargosComisionesTo();
        public OTROS_CARGOS_COMISIONES_X_COMISIONISTA(string AÑO, string MES, DateTime FECHA_INI, DateTime FECHA_GRAL, string COD_MOD, string TIPO_USU, string COD_USU)
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

        private void OTROS_CARGOS_COMISIONES_X_COMISIONISTA_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_SUCURSAL();
            CARGAR_CONCEPTOS_CARGOS();
            CARGAR_VENDEDOR();
            CARGAR_DEBE_HABER();
            CARGAR_GRID_CARGOS_HECHOS();
            visibilizarPorcentaje(false);// oculta controles
        }
        private void CARGAR_DEBE_HABER()
        {
            var items = new[] { new { cod = "D", val = "Debe" }, new { cod = "H", val = "Haber" } };
            cbo_debe_haber.ValueMember = "cod";
            cbo_debe_haber.DisplayMember = "val";
            cbo_debe_haber.DataSource = items;
            cbo_debe_haber.SelectedIndex = 1;
        }
        private void CARGAR_GRID_CARGOS_HECHOS()
        {
            occTo.FE_AÑO = AÑO;
            occTo.FE_MES = MES;
            dtOtros = occBLL.obtenerOtrosCargosComisionesBLL(occTo);
            dgw.Rows.Clear();
            if (dtOtros.Rows.Count > 0)
            {
                DataTable dt1 = dtOtros.AsEnumerable()
                   .GroupBy(r => new
                   {
                       Col01 = r["COD_SUCURSAL"],
                       Col02 = r["COD_PER"]
                   })
                   .Select(g => g.OrderBy(r => r["COD_PER"]).First())
                   .CopyToDataTable();
                //
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt1.Rows)
                    {
                        int rowId = dgw.Rows.Add();
                        DataGridViewRow row = dgw.Rows[rowId];
                        row.Cells["cod_sucursal2"].Value = rw["COD_SUCURSAL"].ToString();
                        row.Cells["desc_sucursal2"].Value = rw["DESC_SUCURSAL"].ToString();
                        row.Cells["FE_AÑO2"].Value = rw["FE_AÑO"].ToString();
                        row.Cells["FE_MES2"].Value = rw["FE_MES"].ToString();
                        row.Cells["cod_per2"].Value = rw["COD_PER"].ToString();
                        row.Cells["nom_per2"].Value = rw["DESC_PER"].ToString();
                        row.Cells["importe2"].Value = sumaImportesCab();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private decimal sumaImportesCab()
        {
            decimal sum = 0;
            foreach (DataRow row in dtOtros.Rows)
            {
                if (row["COD_D_H"].ToString() == "D")
                    sum += Convert.ToDecimal(row["IMP_TOT"]);
                else if (row["COD_D_H"].ToString() == "H")
                    sum -= Convert.ToDecimal(row["IMP_TOT"]);
            }
            return sum;
        }
        private void CARGAR_SUCURSAL()
        {
            helTo.CODIGO = COD_USU;
            DataTable dt = helBLL.CBO_SUCURSALBLL(helTo);
            cbo_sucursal.ValueMember = "COD_SUCURSAL";
            cbo_sucursal.DisplayMember = "DESC_sucursal";
            cbo_sucursal.DataSource = dt;
            //cbo_sucursal.SelectedIndex = -1;
        }
        private void CARGAR_VENDEDOR()
        {
            progNivelBLL prnBLL = new progNivelBLL();
            DataTable dt = prnBLL.obtenerVendedoresparaCrearEqVentasBLL();
            dgw_per2.DataSource = dt;
            dgw_per2.Columns[0].Width = 55;
            dgw_per2.Columns[1].Width = 240;
        }
        private void OTROS_CARGOS_COMISIONES_X_COMISIONISTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void CARGAR_CONCEPTOS_CARGOS()
        {
            //dirTo.TABLA_COD = "TOCC";
            //DataTable dt = dirBLL.MOSTRAR_DIRECTORIO_DATO_BLL(dirTo);
            cargosAbonosComisionesBLL cacBLL = new cargosAbonosComisionesBLL();
            dtCptoCargos = cacBLL.obtenerCargosAbonosComisionesBLL();
            //DataTable dt = cacBLL.obtenerCargosAbonosComisionesBLL();
            cbo_concepto.ValueMember = "COD_CONCEPTO";
            cbo_concepto.DisplayMember = "DESC_CONCEPTO";
            cbo_concepto.DataSource = dtCptoCargos;
            //cbo_concepto.DataSource = dt;
            cbo_concepto.SelectedIndex = -1;
        }

        private void btn_agregar1_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = true;
            btn_mod1.Visible = false;
            Panel1.Visible = true;
            LIMPIAR_CONTACTO();
            txt_nro_doc.Focus();
        }
        private void LIMPIAR_CONTACTO()
        {
            txt_nro_doc.Clear();
            cbo_concepto.SelectedIndex = -1;
            txt_importe.Clear();
            txt_porc.Clear();
            txt_obs.Clear();
            txt_nro_doc.ReadOnly = false;
            cbo_concepto.Enabled = true;
            txt_importe.ReadOnly = false;
            txt_porc.ReadOnly = false;
            txt_obs.ReadOnly = false;
            visibilizarPorcentaje(false);
        }

        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            btn_guardar2.Visible = false;
            btn_mod1.Visible = true;
            //item1.Text = dgw1.CurrentRow.Index.ToString
            LIMPIAR_CONTACTO();
            CARGAR_CONTACTO();
            Panel1.Visible = true;
            cbo_concepto.Focus();
        }
        private void CARGAR_CONTACTO()
        {
            if (dgw1.Rows.Count > 0)
            {
                txt_nro_doc.Text = dgw1.CurrentRow.Cells["NRO_DOC"].Value.ToString();
                dtp_fec_doc.Value = Convert.ToDateTime(dgw1.CurrentRow.Cells["FECHA_DOC"].Value);
                cbo_debe_haber.SelectedValue = dgw1.CurrentRow.Cells["COD_D_H"].Value;
                cbo_concepto.SelectedValue = dgw1.CurrentRow.Cells["COD_CPTO"].Value;
                txt_importe.Text = dgw1.CurrentRow.Cells["importe"].Value.ToString();
                txt_obs.Text = dgw1.CurrentRow.Cells["obs"].Value.ToString();
                txt_porc.Text = dgw1.CurrentRow.Cells["IMP_RETENCION"].Value.ToString();
            }
        }

        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
            }
        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarOtrosDescuentos())
                return;
            dgw1.Rows.Add(cbo_sucursal.SelectedValue.ToString(), FE_AÑO, FE_MES, txt_cod2.Text, txt_nro_doc.Text,
                dtp_fec_doc.Value.ToShortDateString(), cbo_concepto.SelectedValue.ToString(), cbo_concepto.Text,
                cbo_debe_haber.SelectedValue.ToString(), txt_importe.Text, txt_obs.Text, txt_porc.Text);
            Panel1.Visible = false;
            item1.Focus();
        }
        private bool validaGuardarModificarOtrosDescuentos()
        {
            bool result = true;
            if (txt_nro_doc.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nro Documento !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_nro_doc.Focus();
                return result = false;
            }
            if (cbo_concepto.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija el concepto !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_concepto.Focus();
                return result = false;
            }
            if (txt_importe.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el importe !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            decimal imp = 0;
            if (!decimal.TryParse(txt_importe.Text, out imp))
            {
                MessageBox.Show("Importe no válido !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_importe.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_mod1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarOtrosDescuentos())
                return;
            dgw1.CurrentRow.Cells["NRO_DOC"].Value = txt_nro_doc.Text;
            dgw1.CurrentRow.Cells["FECHA_DOC"].Value = dtp_fec_doc.Value.ToShortDateString();
            dgw1.CurrentRow.Cells["COD_D_H"].Value = cbo_debe_haber.SelectedValue;
            dgw1.CurrentRow.Cells["COD_CPTO"].Value = cbo_concepto.SelectedValue.ToString();
            dgw1.CurrentRow.Cells["concepto"].Value = cbo_concepto.Text;
            dgw1.CurrentRow.Cells["importe"].Value = txt_importe.Text;
            dgw1.CurrentRow.Cells["obs"].Value = txt_obs.Text;
            dgw1.CurrentRow.Cells["IMP_RETENCION"].Value = txt_porc.Text;
            Panel1.Visible = false;
            item1.Focus();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        private void txt_importe_Leave(object sender, EventArgs e)
        {
            txt_importe.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_importe.Text.Trim());
        }

        private void txt_cod2_Leave(object sender, EventArgs e)
        {
            if (txt_cod2.Text.Trim() != "")
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count - 1;
                    do
                    {
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower())
                        {
                            txt_cod2.Text = dgw_per2[0, i].Value.ToString();
                            txt_desc2.Text = dgw_per2[1, i].Value.ToString();
                            return;
                        }
                        if (txt_cod2.Text.ToLower() == dgw_per2[0, i].Value.ToString().ToLower().Substring(0, txt_cod2.TextLength))
                        {
                            dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                            break;
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i <= num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }

        private void txt_desc2_Leave(object sender, EventArgs e)
        {
            if (txt_desc2.Text == "")
            {
                txt_cod2.Focus();
            }
            else
            {
                if (dgw_per2.Rows.Count > 0)
                {
                    dgw_per2.Sort(dgw_per2.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                    int i = 0, num2 = 0;
                    num2 = dgw_per2.Rows.Count;
                    do
                    {
                        if (dgw_per2[1, i].Value.ToString().Length >= txt_desc2.TextLength)
                        {
                            if (txt_desc2.Text.ToLower() == dgw_per2[1, i].Value.ToString().ToLower().Substring(0, txt_desc2.TextLength).ToLower())
                            {
                                dgw_per2.CurrentCell = dgw_per2.Rows[i].Cells[0];
                                break;
                            }
                        }
                        dgw_per2.CurrentCell = dgw_per2.Rows[0].Cells[0];
                        i += 1;
                    }
                    while (i < num2);
                    panel_per2.Visible = true;
                    dgw_per2.Visible = true;
                    dgw_per2.Focus();
                }
            }
        }

        private void dgw_per2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int idx = dgw_per2.CurrentRow.Index;
                txt_cod2.Text = dgw_per2[0, idx].Value.ToString();
                txt_desc2.Text = dgw_per2[1, idx].Value.ToString();
                panel_per2.Visible = false;
                //item1.Focus();
                dgw1.Select();
                //groupBox1.Select();
                //VerificaNumeracionContrato();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //Panel_PER.Visible = false;
                panel_per2.Visible = false;
                txt_cod2.Clear();
                txt_desc2.Clear();
                //txt_doc_per.Clear();
                txt_cod2.Focus();

            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            LIMPIAR_CABECERA();
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            //cbo_tipo_planilla.Enabled = true;
            //cbo_prog.Enabled = true;
            txt_cod2.Enabled = true;
            txt_desc2.Enabled = true;
            tabControl1.SelectedTab = tabPage2;
            //cbo_prog.SelectedIndex = 0;
            //cbo_tipo_planilla.SelectedIndex = 0;
            txt_cod2.Focus();
        }
        private void LIMPIAR_CABECERA()
        {

            txt_cod2.Clear();
            txt_desc2.Clear();
            dgw1.Rows.Clear();
            Panel1.Visible = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("guardar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Grabar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                occTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                occTo.FE_AÑO = AÑO;
                occTo.FE_MES = MES;
                occTo.COD_PER = txt_cod2.Text;
                occTo.FECHA_DOC = DateTime.Now;
                occTo.COD_CREA = COD_USU;
                occTo.FECHA_CREA = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw1);
                if (!occBLL.grabarOtrosCargosComisionesBLL(occTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    decimal tot_imp = sumaImportes();
                    dgw.Rows.Add(cbo_sucursal.SelectedValue.ToString(), cbo_sucursal.Text, AÑO, MES, txt_cod2.Text, txt_desc2.Text, tot_imp);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
        }
        private decimal sumaImportes()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dgw1.Rows)
            {
                if (row.Cells["COD_D_H"].Value.ToString() == "D")
                    sum += Convert.ToDecimal(row.Cells["importe"].Value);
                else if (row.Cells["COD_D_H"].Value.ToString() == "H")
                    sum -= Convert.ToDecimal(row.Cells["importe"].Value);
            }
            return sum;
        }
        private bool validaGuardar(string op)
        {
            bool result = true;
            if (cbo_sucursal.SelectedIndex <= -1)
            {
                MessageBox.Show("Elija la Sucursal !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_sucursal.Focus();
                return result = false;
            }
            if (txt_cod2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo del Comisionista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod2.Focus();
                return result = false;
            }
            if (txt_desc2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Comisionista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc2.Focus();
                return result = false;
            }
            //if (op == "guardar")
            //{
            //    foreach (DataGridViewRow row in dgw1.Rows)
            //    {
            //        if (row.Cells["cod_pers"].Value.ToString() == txt_cod2.Text.Trim())
            //        {
            //            MessageBox.Show("El Vendedor ya existe en la lista !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            txt_cod2.Focus();
            //            return result = false;
            //        }
            //    }
            //}
            ////
            return result;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            boton = "MODIFICAR";
            //INDICE = dgw.CurrentRow.Index
            LIMPIAR_CABECERA();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            CARGAR_CABECERA();
            CARGAR_DETALLES();
            //CARGAR_SUSTITUTO();
            cbo_sucursal.Enabled = false;
            txt_cod2.Enabled = false;
            txt_desc2.Enabled = false;
            tabControl1.SelectedTab = tabPage2;
            cbo_sucursal.Focus();
        }
        private void CARGAR_CABECERA()
        {
            cbo_sucursal.SelectedValue = dgw.CurrentRow.Cells["cod_sucursal2"].Value;
            txt_cod2.Text = dgw.CurrentRow.Cells["cod_per2"].Value.ToString();
            txt_desc2.Text = dgw.CurrentRow.Cells["nom_per2"].Value.ToString();
        }
        private void CARGAR_DETALLES()
        {
            occTo.COD_SUCURSAL = dgw.CurrentRow.Cells["cod_sucursal2"].Value.ToString();
            occTo.FE_AÑO = dgw.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
            occTo.FE_MES = dgw.CurrentRow.Cells["FE_MES2"].Value.ToString();
            occTo.COD_PER = dgw.CurrentRow.Cells["cod_per2"].Value.ToString();
            DataTable dt = occBLL.obtenerOtrosCargosComisionesDetalleBLL(occTo);
            dgw1.Rows.Clear();
            foreach (DataRow rw in dt.Rows)
            {
                int rowId = dgw1.Rows.Add();
                DataGridViewRow row = dgw1.Rows[rowId];
                row.Cells["COD_SUCURSAL"].Value = rw["COD_SUCURSAL"].ToString();
                row.Cells["FE_AÑO"].Value = rw["FE_AÑO"].ToString();
                row.Cells["FE_MES"].Value = rw["FE_MES"].ToString();
                row.Cells["COD_PER"].Value = rw["COD_PER"].ToString();
                row.Cells["NRO_DOC"].Value = rw["NRO_DOC"].ToString();
                row.Cells["FECHA_DOC"].Value = rw["FECHA_DOC"].ToString().Substring(0, 10);
                row.Cells["COD_CPTO"].Value = rw["COD_CPTO"].ToString();
                row.Cells["concepto"].Value = rw["DESC_CPTO"].ToString();
                row.Cells["COD_D_H"].Value = rw["COD_D_H"].ToString();
                row.Cells["importe"].Value = rw["IMP_TOT"].ToString();
                row.Cells["obs"].Value = rw["OBSERVACIONES"].ToString();
                row.Cells["IMP_RETENCION"].Value = rw["IMP_RETENCION"].ToString();
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            if (!validaGuardar("modificar"))
                return;

            DialogResult rs = MessageBox.Show("¿ Esta seguro de Modificar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                occTo.COD_SUCURSAL = cbo_sucursal.SelectedValue.ToString();
                occTo.FE_AÑO = AÑO;
                occTo.FE_MES = MES;
                occTo.COD_PER = txt_cod2.Text;
                occTo.FECHA_DOC = DateTime.Now;
                occTo.COD_CREA = COD_USU;
                occTo.FECHA_CREA = DateTime.Now;
                DataTable dtDetalle = HelpersBLL.obtenerDT(dgw1);
                if (!occBLL.modificarOtrosCargosComisionesBLL(occTo, dtDetalle, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    decimal tot_imp = sumaImportes();
                    //dgw.Rows.Add(cbo_sucursal.SelectedValue.ToString(), AÑO, MES, txt_cod2.Text, txt_desc2.Text, tot_imp);
                    dgw.CurrentRow.Cells["importe2"].Value = tot_imp.ToString();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ Esta seguro de Eliminar ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = "";
                occTo.COD_SUCURSAL = dgw.CurrentRow.Cells["cod_sucursal2"].Value.ToString();
                occTo.FE_AÑO = dgw.CurrentRow.Cells["FE_AÑO2"].Value.ToString();
                occTo.FE_MES = dgw.CurrentRow.Cells["FE_MES2"].Value.ToString();
                occTo.COD_PER = dgw.CurrentRow.Cells["cod_per2"].Value.ToString();

                if (!occBLL.quitarOtrosCargosComisionesBLL(occTo, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dgw.Rows.Remove(dgw.CurrentRow);
                    tabControl1.SelectedTab = tabPage1;
                }
            }
        }

        private void cbo_concepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_concepto.SelectedValue != null)
            {
                DataRow[] foundRow;
                foundRow = dtCptoCargos.Select("COD_CONCEPTO = '" + cbo_concepto.SelectedValue.ToString() + "'");
                foreach (DataRow rw in foundRow)
                {
                    if (Convert.ToBoolean(rw["STATUS_IMPUESTOS"]))
                    {
                        //MessageBox.Show("BINGO");
                        visibilizarPorcentaje(true);
                        txt_porc.Focus();
                    }
                    else
                    {
                        visibilizarPorcentaje(false);
                    }
                }
            }
        }
        private void visibilizarPorcentaje(bool val)
        {
            if (val == false)
            {
                txt_porc.Visible = false;
                lbl_porc.Visible = false;
            }
            else
            {
                txt_porc.Visible = true;
                lbl_porc.Visible = true;
            }
            txt_porc.Clear();
        }

        private void txt_porc_Leave(object sender, EventArgs e)
        {
            decimal p = 0;
            if (!decimal.TryParse(txt_porc.Text, out p))
            {
                MessageBox.Show("Porcentaje no válido !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_porc.Focus();
                txt_porc.Text = "0";
                return;
            }

            pLiquidacionBLL pliqBLL = new pLiquidacionBLL();
            pLiquidacionTo pliqTo = new pLiquidacionTo();
            pLiqAdelantoBLL plaBLL = new pLiqAdelantoBLL();
            pLiqAdelantoTo plaTo = new pLiqAdelantoTo();
            pLiqDevolucionBLL pldBLL = new pLiqDevolucionBLL();
            pLiqDevolucionTo pldTo = new pLiqDevolucionTo();
            pliqTo.FE_AÑO = AÑO;
            pliqTo.FE_MES = MES;
            pliqTo.COD_COMISIONANTE = txt_cod2.Text.Trim();
            plaTo.FE_AÑO = pliqTo.FE_AÑO;
            plaTo.FE_MES = pliqTo.FE_MES;
            plaTo.COD_PER = txt_cod2.Text.Trim();
            pldTo.FE_AÑO = pliqTo.FE_AÑO;
            pldTo.FE_MES = pliqTo.FE_MES;
            pldTo.COD_COMISIONANTE = txt_cod2.Text.Trim();
            occTo.FE_AÑO = AÑO;
            occTo.FE_MES = MES;
            occTo.COD_PER = txt_cod2.Text.Trim();

            decimal sumaComision = pliqBLL.sumaComision_Comisiones_X_Periodo_X_ComisionistaBLL(pliqTo);
            decimal sumaDevolucion = pldBLL.sumaDevolucion_Comisiones_X_Periodo_X_ComisionistaBLL(pldTo);
            decimal sumaAdelanto = plaBLL.sumaAdelanto_Comisiones_X_Periodo_X_ComisionistaBLL(plaTo);
            decimal sumaOtros = occBLL.sumaOtrosCargos_Comisiones_X_Periodo_X_ComisionistaBLL(occTo);
            decimal imp_neto = sumaComision - sumaDevolucion - sumaAdelanto - sumaOtros;
            decimal porc = Convert.ToDecimal(txt_porc.Text.Trim()) * 0.01M;
            txt_importe.Text = (imp_neto * porc).ToString();
            txt_importe.Text = HelpersBLL.OBTIENE_PRECIO_DOS_DECIMALES(txt_importe.Text);
        }

    }
}
