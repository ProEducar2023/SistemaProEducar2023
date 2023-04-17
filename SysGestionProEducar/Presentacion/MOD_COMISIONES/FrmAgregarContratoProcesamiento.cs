using BLL;
using Presentacion.HELPERS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Presentacion.HELPERS.AppearanceUtil;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmAgregarContratoProcesamiento : Form
    {
        private readonly string codPrograma, codInstitucion, codTipoPlla, nroCuota;
        private readonly DateTime fechaCobranzaIni;

        public FrmAgregarContratoProcesamiento(string codPrograma, string codInstitucion, string codTipoPlla, string nroCuota,
            DateTime fechaCobranzaIni)
        {
            InitializeComponent();
            this.codPrograma = codPrograma;
            this.codInstitucion = codInstitucion;
            this.codTipoPlla = codTipoPlla;
            this.nroCuota = nroCuota;
            this.fechaCobranzaIni = fechaCobranzaIni;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        internal delegate void delPasarData(DataGridView dataGrid);
        internal event delPasarData EventPasarData;

        private void FrmAgregarContratoProcesamiento_Load(object sender, EventArgs e)
        {
            StartControls();
        }

        private void StartControls()
        {
            _ = txtNroContrato.Focus();
            dgvContratos.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect, false);

            btnBuscar.StyleButtonFlat();
            btnAgregar.StyleButtonFlat();

            lstvComisionGen.View = View.Details;
            lstvComisionExcluido.View = View.Details;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarContrato();
            BuscarContratoGenerado();
            BuscarContratosExcluidos();
        }

        private void BuscarContrato()
        {
            DataTable dt = BLComision.ObtenerContratoParaGenerarComision(txtNroContrato.Text, codPrograma, codInstitucion, codTipoPlla, nroCuota, fechaCobranzaIni);
            if (dt == null || dt.Rows.Count == 0)
                dt = BLComision.ObtenerContratoMostrarAgregarComision(txtNroContrato.Text, codPrograma, codInstitucion, codTipoPlla, nroCuota);
            dgvContratos.DataSource = dt;
            AjsuteColumnas();
        }

        private void AjsuteColumnas()
        {
            InvisibleColumn();
            RenamerHeaderText();
            WithColumn();
            AlignTextContentCell();
            dgvContratos.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dgvContratos.AlingHeaderTextCenter();

            if (dgvContratos.Rows.Count > 0)
            {
                dgvContratos.CurrentCell = dgvContratos.Rows[0].Cells["NRO_CONTRATO"];
            }
        }

        private void InvisibleColumn()
        {
            string[] arrColumns = {
                "ID_COMISION_VEND", "ID_COMISION_SUP", "ID_COMISION_DIR_VTAS",
                "ID_COMISION_DIR_NCNAL", "COD_SUCURSAL", "COD_CLASE",
                "FE_AÑO", "FE_MES", "CH",
                "PERIODO_PROCESO", "IMP_CTA_COBRADA",
                "FECHA_CUOTA", "PTO_COBRANZA", "UBICACION",
                "GRUPO_UBICACION", "GESTOR", "FECHA_COBRA_INI", "FECHA_COBRA_FIN",
                "ID_PROCESO", "IMP_COUTA_MES", "TOT_CUOTAS", "ID_CONF_SUP", "ID_CONF_DIR_VTAS",
                "ID_CONF_DIR_NCNAL", "ID_CONF_VEND"
            };

            if (dgvContratos.Columns.Count > 0)
            {
                foreach (string item in arrColumns)
                {
                    dgvContratos.InvisibleColumna2(item);
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarAgregar())
                return;

            EventPasarData(PasarDataSeleccionado());
            Close();
        }

        private bool ValidarAgregar()
        {
            if (dgvContratos.Rows.Count == 0 || dgvContratos.CurrentCell == null)
                return false;

            if (string.IsNullOrEmpty(dgvContratos.CurrentRow.Cells["NRO_CUOTA"].Value?.ToString()))
            {
                _ = MessageBox.Show("1. Este contrato no tiene nro de cuotas pendientes por comisionar. \n" +
                    "2. Asegúrese de que el vendedor, supervisor, director de ventas o director nacional de este contrato tenga una comisión registrada " +
                    "anterior o igual a la fecha de aprobación \n" +
                    "3. Si el contrato esta excluído agregar desde la pestaña de excluidos.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvContratos.CurrentRow.Cells["NRO_CUOTA"].Value?.ToString() != "000"
                && dgvContratos.CurrentRow.Cells["SALDO_CUOTA_MES"].Value.ToDecimal() > 0)
            {
                DialogResult dr = MessageBox.Show("Este numero de cuota no se ha terminado de pagar.\n ¿Esta seguro de que desea agregar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    return true;
                else return false;
            }

            return true;
        }

        private DataGridView PasarDataSeleccionado()
        {
            int index = dgvContratos.CurrentRow.Index;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvContratos.Rows)
            {
                if (row.Index != index)
                    rows.Add(row);
            }

            foreach (DataGridViewRow row in rows)
            {
                dgvContratos.Rows.Remove(row);
            }

            //>Se remueve la columna SALDO_CUOTA_MES ya que no se necestia para agregar
            dgvContratos.Columns.RemoveAt(dgvContratos.Columns["SALDO_CUOTA_MES"].Index);
            return dgvContratos;
        }

        private void TxtContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtNroContrato.Text.Trim()))
                {
                    txtNroContrato.Text = txtNroContrato.Text.Trim().PadLeft(7, Convert.ToChar("0"));
                }
                BuscarContrato();
                BuscarContratoGenerado();
                BuscarContratosExcluidos();
            }
        }

        private void RenamerHeaderText()
        {
            if (dgvContratos.Columns.Count > 0)
            {
                dgvContratos.Columns["CH"].HeaderText = "¿No Gen. Comisión?";
                dgvContratos.Columns["NRO_CONTRATO"].HeaderText = "N° Contrato";
                dgvContratos.Columns["FECHA_CONTRATO"].HeaderText = "Fec.Contrato";
                dgvContratos.Columns["FECHA_APROBACION"].HeaderText = "Fec.Aprob";
                dgvContratos.Columns["TIPO_PLANILLA"].HeaderText = "Tipo Plla";
                dgvContratos.Columns["CLIENTE"].HeaderText = "Cliente";
                dgvContratos.Columns["IMP_DOC"].HeaderText = "Imp. Contrato";
                dgvContratos.Columns["TOT_CUOTAS"].HeaderText = "N° Cuotas";
                dgvContratos.Columns["IMP_COUTA_MES"].HeaderText = "Imp. Cuota Mensual";
                dgvContratos.Columns["FEC_PRIMER_VENC"].HeaderText = "Fec. Primer Vcto";
                dgvContratos.Columns["NRO_CUOTA"].HeaderText = "N° Ctas Cobradas";
                dgvContratos.Columns["SALDO_CUOTA_MES"].HeaderText = "Saldo por Pagar Cuota";
                dgvContratos.Columns["IMP_CTA_COBRADA"].HeaderText = "Imp. Ctas Cobradas";
                dgvContratos.Columns["FECHA_CUOTA"].HeaderText = "Fec.Cuota";
                dgvContratos.Columns["PTO_COBRANZA"].HeaderText = "Pto. Cobranza";
                dgvContratos.Columns["UBICACION"].HeaderText = "Ubicación";
                dgvContratos.Columns["GRUPO_UBICACION"].HeaderText = "Grupo Ubicación";
                dgvContratos.Columns["GESTOR"].HeaderText = "Gestor";
                dgvContratos.Columns["VENDEDOR"].HeaderText = "Vendedor";
                dgvContratos.Columns["IMP_COM_VEND"].HeaderText = "Imp. Comisión Vend.";
                dgvContratos.Columns["SUPERVISOR"].HeaderText = "Supervisor";
                dgvContratos.Columns["IMP_COM_SUP"].HeaderText = "Imp. Comisión Super.";
                dgvContratos.Columns["DIRECTOR_VTAS"].HeaderText = "Director Vtas";
                dgvContratos.Columns["IMP_COM_DIR_VTAS"].HeaderText = "Imp. Comisión Dir. Vtas";
                dgvContratos.Columns["DIRECTOR_NCNAL"].HeaderText = "Director Nacional";
                dgvContratos.Columns["IMP_COM_DIR_NCNAL"].HeaderText = "Imp. Comisión Dir. Nac.";
            }
        }

        private void WithColumn()
        {
            if (dgvContratos.Columns.Count > 0)
            {
                dgvContratos.Columns["CH"].Width = 60;
                dgvContratos.Columns["NRO_CONTRATO"].Width = 65;
                dgvContratos.Columns["FECHA_CONTRATO"].Width = 70;
                dgvContratos.Columns["FECHA_APROBACION"].Width = 70;
                dgvContratos.Columns["TIPO_PLANILLA"].Width = 40;
                dgvContratos.Columns["CLIENTE"].Width = 120;
                dgvContratos.Columns["IMP_DOC"].Width = 65;
                dgvContratos.Columns["TOT_CUOTAS"].Width = 55;
                dgvContratos.Columns["IMP_COUTA_MES"].Width = 70;
                dgvContratos.Columns["FEC_PRIMER_VENC"].Width = 75;
                dgvContratos.Columns["NRO_CUOTA"].Width = 65;
                dgvContratos.Columns["SALDO_CUOTA_MES"].Width = 80;
                dgvContratos.Columns["IMP_CTA_COBRADA"].Width = 73;
                dgvContratos.Columns["FECHA_CUOTA"].Width = 70;
                dgvContratos.Columns["PTO_COBRANZA"].Width = 120;
                dgvContratos.Columns["UBICACION"].Width = 90;
                dgvContratos.Columns["GRUPO_UBICACION"].Width = 90;
                dgvContratos.Columns["GESTOR"].Width = 100;
                dgvContratos.Columns["VENDEDOR"].Width = 120;
                dgvContratos.Columns["IMP_COM_VEND"].Width = 70;
                dgvContratos.Columns["SUPERVISOR"].Width = 120;
                dgvContratos.Columns["IMP_COM_SUP"].Width = 70;
                dgvContratos.Columns["DIRECTOR_VTAS"].Width = 120;
                dgvContratos.Columns["IMP_COM_DIR_VTAS"].Width = 75;
                dgvContratos.Columns["DIRECTOR_NCNAL"].Width = 120;
                dgvContratos.Columns["IMP_COM_DIR_NCNAL"].Width = 75;
            }
        }

        private void AlignTextContentCell()
        {
            dgvContratos.AlignmentTextContent2("TIPO_PLANILLA", DataGridViewContentAlignment.MiddleCenter);
            dgvContratos.AlignmentTextContent2("NRO_CONTRATO", DataGridViewContentAlignment.MiddleCenter);
            dgvContratos.AlignmentTextContent2("FECHA_CONTRATO", DataGridViewContentAlignment.MiddleCenter);
            dgvContratos.AlignmentTextContent2("FECHA_APROBACION", DataGridViewContentAlignment.MiddleCenter);
            dgvContratos.AlignmentDecimalColumns();
        }

        private void BuscarContratoGenerado()
        {
            DataTable dt = BLComision.ObtenerContratoComisonGenerado(txtNroContrato.Text);
            CrearColumnasListView(lstvComisionGen);
            AgregarFilasListView(lstvComisionGen, dt);
        }

        private void BuscarContratosExcluidos()
        {
            DataTable dt = BLComision.ObtenerContratoComisonExcluido(txtNroContrato.Text);
            CrearColumnasListView(lstvComisionExcluido);
            AgregarFilasListView(lstvComisionExcluido, dt);
        }

        private void CrearColumnasListView(ListView list)
        {
            var columns = new[]
            {
                new {name = "NRO_CONTRATO", headerText = "Nro. Contrato", with = 80, textAlign = HorizontalAlignment.Center},
                new {name = "NRO_CUOTA", headerText = "Nro. Cuota", with = 80, textAlign = HorizontalAlignment.Center},
                new {name = "PERIODO", headerText = "Período", with = 100, textAlign = HorizontalAlignment.Center},
                new {name = "VENDEDOR", headerText = "Vendedor", with = 140, textAlign = HorizontalAlignment.Left},
                new {name = "IMP_COM_VEND", headerText = "Com.Vend.", with = 80, textAlign = HorizontalAlignment.Right},
                new {name = "SUPERVISOR", headerText = "Supervisor", with = 140, textAlign = HorizontalAlignment.Left},
                new {name = "IMP_COM_SUP", headerText = "Com. Super.", with = 80, textAlign = HorizontalAlignment.Right},
                new {name = "DIRECTOR_VTAS", headerText = "Dir. Vtas.", with = 140, textAlign = HorizontalAlignment.Left},
                new {name = "IMP_COM_DIR_VTAS", headerText = "Com.Dir.Vtas.", with = 80, textAlign = HorizontalAlignment.Right},
                new {name = "DIRECTOR_NCNAL", headerText = "Dir. Nacional", with = 140, textAlign = HorizontalAlignment.Left},
                new {name = "IMP_COM_DIR_NCNAL", headerText = "Com.Dir.Nac.", with = 80, textAlign = HorizontalAlignment.Right},
            };

            if (list.Columns.Count == 0)
            {
                foreach (var item in columns)
                {
                    _ = list.Columns.Add(item.name, item.headerText, item.with, item.textAlign, 0);
                }
            }
        }

        private void AgregarFilasListView(ListView list, DataTable dt)
        {
            list.Items.Clear();
            
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["NRO_CONTRATO"].ToString());
                    item.SubItems.Add(row["NRO_CUOTA"].ToString());
                    item.SubItems.Add(row["PERIODO_TEXT"].ToString());
                    item.SubItems.Add(row["VENDEDOR"].ToString());
                    item.SubItems.Add(row["IMP_COM_VEND"].ToString());
                    item.SubItems.Add(row["SUPERVISOR"].ToString());
                    item.SubItems.Add(row["IMP_COM_SUP"].ToString());
                    item.SubItems.Add(row["DIRECTOR_VTAS"].ToString());
                    item.SubItems.Add(row["IMP_COM_DIR_VTAS"].ToString());
                    item.SubItems.Add(row["DIRECTOR_NCNAL"].ToString());
                    item.SubItems.Add(row["IMP_COM_DIR_NCNAL"].ToString());
                    _ = list.Items.Add(item);
                }
            }
        }
    }
}
