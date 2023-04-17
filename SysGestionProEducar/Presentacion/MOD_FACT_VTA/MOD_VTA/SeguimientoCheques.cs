using BLL;
using Entidades;
using SysSeguimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Entidades.ConstClass;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.GenericMethod;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class SeguimientoCheques : Form
    {
        public static string COD_USUARIO { get; set; }
        public static string AÑO, MES;
        public static int Del_operacion;
        public SeguimientoCheques(string año, string mes, string codUsuario)
        {
            InitializeComponent();
            COD_USUARIO = codUsuario;
            AÑO = año;
            MES = mes;
        }

        private static readonly puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();
        private static readonly ChequeBLL BLCheque = new ChequeBLL();

        private int idExCheque, indexDgv1, indexDgv2;
        private const string N = "N2";
        private static string codPtoCob;
        private static bool acc;

        private void SeguimientoCheques_Load(object sender, EventArgs e)
        {
            StartControls();
            ColumnasDataGridView(dgv1);
            ColumnasDataGridView(dgv2);
            FormatGridViewLlamada();
            FormatGridViewCheques();
            ListarPuntoCobranza();
            StyleHeaderTextDataGridView(dgv1);
            StyleHeaderTextDataGridView(dgv2);
            ListarLlamadasPendientes(CHEQUE_ENVIADO);
            FormatGridPuntoCobranza();
        }

        private void StartControls()
        {
            dgvLlamadas.DefaultCellStyle.Font = new Font(dgvLlamadas.Font, FontStyle.Regular);

            dgvCheques.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCheques.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCheques.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvCheques.DefaultCellStyle.SelectionForeColor = Color.Blue;
        }

        private void ListarPuntoCobranza()
        {
            DataTable dt = BLPuntoCobranza.ListarPtoCobranzaCheques(EmpresaSistema.CodPais);
            foreach (DataColumn column in dt.Columns)
            {
                column.ReadOnly = false;
            }

            dgvPuntoCobranza.DataSource = dt;

            if (dgvPuntoCobranza.Rows.Count > 0)
            {
                dgvPuntoCobranza.Columns["COD_PTO_COB"].HeaderText = "Código";
                dgvPuntoCobranza.Columns["COD_PTO_COB"].Width = 50;
                dgvPuntoCobranza.Columns["COD_PTO_COB"].Visible = false;
                dgvPuntoCobranza.Columns["DESC_PTO_COB"].HeaderText = "Pto. Cobranza";
                dgvPuntoCobranza.Columns["DESC_PTO_COB"].Width = 160;
                dgvPuntoCobranza.Columns["Desc_dep"].HeaderText = "Departamento";
                dgvPuntoCobranza.Columns["Desc_dep"].Width = 100;
                dgvPuntoCobranza.Columns["CANT"].HeaderText = "Cant. Pllas.";
                dgvPuntoCobranza.Columns["CANT"].Width = 45;
                dgvPuntoCobranza.Columns["IMPORTE_NETO_ENTIDAD"].HeaderText = "X Cobrar Entidad";
                dgvPuntoCobranza.Columns["IMPORTE_NETO_ENTIDAD"].Width = 95;
                dgvPuntoCobranza.Columns["IMP_COBRADO"].HeaderText = "Cobrado Entidad";
                dgvPuntoCobranza.Columns["IMP_COBRADO"].Width = 75;
                dgvPuntoCobranza.Columns["RETENCION"].HeaderText = "Ret.Ent. a Cliente";
                dgvPuntoCobranza.Columns["RETENCION"].Width = 65;
                dgvPuntoCobranza.Columns["IMPORTE_REEMBOLSO"].HeaderText = "Reembolso";
                dgvPuntoCobranza.Columns["IMPORTE_REEMBOLSO"].Width = 65;
                dgvPuntoCobranza.Columns["AJUSTE"].HeaderText = "Ajuste";
                dgvPuntoCobranza.Columns["AJUSTE"].Width = 55;
                dgvPuntoCobranza.Columns["IMPORTE_APLICADO"].HeaderText = "Importe Aplicado";
                dgvPuntoCobranza.Columns["IMPORTE_APLICADO"].Width = 58;
                dgvPuntoCobranza.Columns["SALDO_ENTIDAD"].HeaderText = "Saldo X Cobrar";
                dgvPuntoCobranza.Columns["SALDO_ENTIDAD"].Width = 95;
                dgvPuntoCobranza.Columns["EXCESO_COBRANZA"].HeaderText = "Exceso Cobranza";
                dgvPuntoCobranza.Columns["EXCESO_COBRANZA"].Width = 65;
                dgvPuntoCobranza.Columns["SALDO"].HeaderText = "Saldo Final";
                dgvPuntoCobranza.Columns["SALDO"].Width = 80;

                dgvPuntoCobranza.Columns["IMPORTE_REEMBOLSO"].Visible = false;
                dgvPuntoCobranza.Columns["IMPORTE_APLICADO"].Visible = false;
                dgvPuntoCobranza.Columns["AJUSTE"].Visible = false;
                dgvPuntoCobranza.Columns["RETENCION"].Visible = false;
                dgvPuntoCobranza.Columns["IMP_NETO"].Visible = false;
            }

            DataGridViewRow row = dgvPuntoCobranza.Rows.Cast<DataGridViewRow>()
                             .Where(x => x.Cells["COD_PTO_COB"].Value.ToString() == codPtoCob).FirstOrDefault();
            if (row != null)
                dgvPuntoCobranza.CurrentCell = dgvPuntoCobranza["DESC_PTO_COB", row.Index];

            //> InvisibleColumna(dgvPuntoCobranza, "IMPORTE_REEMBOLSO");
        }

        private void FormatGridPuntoCobranza()
        {
            dgvPuntoCobranza.MultiSelect = false;
            dgvPuntoCobranza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPuntoCobranza.RowHeadersVisible = false;
            dgvPuntoCobranza.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPuntoCobranza.DefaultCellStyle.SelectionForeColor = Color.Blue;
            dgvPuntoCobranza.DefaultCellStyle.Font = new Font(dgvPuntoCobranza.Font, FontStyle.Regular);

            dgvPuntoCobranza.Columns["CANT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPuntoCobranza.Columns["IMP_NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["IMP_COBRADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["RETENCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["AJUSTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["IMPORTE_APLICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPuntoCobranza.Columns["IMPORTE_REEMBOLSO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvPuntoCobranza.AlingHeaderTextCenter();
            dgvPuntoCobranza.AlignmentTextContent2("IMP_COBRADO", DataGridViewContentAlignment.MiddleRight);
            dgvPuntoCobranza.AlignmentTextContent2("IMPORTE_NETO_ENTIDAD", DataGridViewContentAlignment.MiddleRight);
            dgvPuntoCobranza.AlignmentTextContent2("SALDO_ENTIDAD", DataGridViewContentAlignment.MiddleRight);
            dgvPuntoCobranza.AlignmentTextContent2("EXCESO_COBRANZA", DataGridViewContentAlignment.MiddleRight);

            dgvPuntoCobranza.Columns["IMP_NETO"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["IMP_COBRADO"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["RETENCION"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["SALDO"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["IMPORTE_APLICADO"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["IMPORTE_REEMBOLSO"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["IMPORTE_NETO_ENTIDAD"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["SALDO_ENTIDAD"].DefaultCellStyle.Format = N;
            dgvPuntoCobranza.Columns["EXCESO_COBRANZA"].DefaultCellStyle.Format = N;

            dgvPuntoCobranza.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPuntoCobranza.ColumnHeadersDefaultCellStyle.Padding = new Padding { All = 0 };
        }

        private void ColumnasDataGridView(DataGridView gridView)
        {
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IG",
                HeaderText = "Tipo",
                Width = 40
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ESTADO",
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB_CONSOLIDADO",
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_PTO_COB",
                HeaderText = "Pto. Cobranza",
                Width = 130
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA",
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                HeaderText = "Año",
                Width = 50,
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                HeaderText = "Mes",
                Width = 50,
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_COB",
                HeaderText = "N° Plla. Generada",
                Width = 95
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLLA_ENV",
                HeaderText = "N° Plla. enviada",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "Periodo",
                Width = 70
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_EJECUTADO",
                HeaderText = "Importe ejecutado",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_CASILLERO",
                HeaderText = "Importe Casill",
                Width = 70
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_NETO",
                HeaderText = "Neto a Cobrar",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RETENIDO",
                HeaderText = "Reten.Ent. Cliente",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AJUSTE",
                HeaderText = "Ajuste",
                Width = 70
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_NETO_ENTIDAD",
                HeaderText = "X Cobrar Entidad",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_VERIFICADO",
                HeaderText = "Cobrado Entidad",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO_ENTIDAD",
                HeaderText = "Saldo Cobrar en Planilla",
                Width = 90
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EXCESO_COBRANZA",
                HeaderText = "Exceso Cobranza (Saldo Cheque)",
                Width = 80
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO_ENV",
                HeaderText = "Aplic.Enviada a Otras Pllas",
                Width = 90,
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO_REC",
                HeaderText = "Aplic.Recib. de Otras Pllas",
                Width = 90,
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_REEMBOLSO",
                HeaderText = "Reembolsos a Entidad",
                Visible = false
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO",
                HeaderText = "Saldo Final",
                Width = 70
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_APL",
                HeaderText = "Tipo Apl",
                Width = 70,
                Visible = false
            });

            DataGridViewCellStyle style = gridView.ColumnHeadersDefaultCellStyle;
            style.Font = new Font(gridView.Font, FontStyle.Regular);


            gridView.Columns["IMP_NETO"].DefaultCellStyle.Format = N;
            gridView.Columns["IMP_VERIFICADO"].DefaultCellStyle.Format = N;
            gridView.Columns["IMP_RETENIDO"].DefaultCellStyle.Format = N;
            gridView.Columns["SALDO"].DefaultCellStyle.Format = N;
            gridView.Columns["IMPORTE_APLICADO_ENV"].DefaultCellStyle.Format = N;
            gridView.Columns["IMPORTE_APLICADO_REC"].DefaultCellStyle.Format = N;
            gridView.Columns["IMPORTE_EJECUTADO"].DefaultCellStyle.Format = N;
            gridView.Columns["IMPORTE_CASILLERO"].DefaultCellStyle.Format = N;
            gridView.Columns["IMPORTE_NETO_ENTIDAD"].DefaultCellStyle.Format = N;
            gridView.Columns["SALDO_ENTIDAD"].DefaultCellStyle.Format = N;
            gridView.Columns["EXCESO_COBRANZA"].DefaultCellStyle.Format = N;

            gridView.Columns["PERIODO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns["IMP_NETO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["IMP_VERIFICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns["IMP_RETENIDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["AJUSTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns["IMPORTE_APLICADO_ENV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["IMPORTE_APLICADO_REC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["IMPORTE_EJECUTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["IMPORTE_CASILLERO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["IMPORTE_NETO_ENTIDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["SALDO_ENTIDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.Columns["EXCESO_COBRANZA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            AjusteColumnasDecimal(gridView, "IMPORTE_REEMBOLSO", 90);
            AlignmentTextContent(gridView, "IG", DataGridViewContentAlignment.MiddleCenter);
        }

        private void FormatGridViewLlamada()
        {
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_LLAMADA",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ESTADO",
                Visible = false,
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_PERSONA",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "N.Planilla",
                Width = 77
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLLA_ENV",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_LLAMADA",
                HeaderText = "F.Llamada",
                Width = 70
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HORA_LLAMADA",
                HeaderText = "H.Llamada",
                Width = 70
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NOMBRE",
                HeaderText = "Nombres",
                Width = 130,
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AREA_LABOR",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TELEFONO",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OBSERVACION",
                HeaderText = "Observación",
                Width = 190
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB",
                Visible = false
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DAY",
                Visible = false
            });
        }

        private void FormatGridViewCheques()
        {
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO",
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FL_GEN_APL",
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_OPERACION",
                HeaderText = "Tipo.Oper",
                Width = 70
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_OPERACION",
                HeaderText = "N° Oper",
                Width = 80
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCUMENTO",
                HeaderText = "N° Doc",
                Width = 80
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_ENVIO",
                HeaderText = "Fec.Env",
                Width = 70
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_RECEPCION",
                HeaderText = "Fec.Rec",
                Width = 70,
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_DEPOSITO",
                HeaderText = "Fec.Dep",
                Width = 70
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_TRANSFERENCIA",
                HeaderText = "Fec.Trans",
                Width = 100,
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_VERIFICACION",
                HeaderText = "Fec.Verif",
                Width = 70
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_COBRADO",
                HeaderText = "Imp.Cheque",
                Width = 80
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_PROPIO_PLLA",
                HeaderText = "Pago esta Plla",
                Width = 90
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_APLICADO",
                HeaderText = "Aplic.Otras Pllas",
                Width = 90
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DEVOLUCION",
                HeaderText = "Imp. Devol",
                Width = 90
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO_PAGO",
                HeaderText = "Saldo",
                Width = 80
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ESTADO",
                Visible = false
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_ESTADO",
                HeaderText = "Estado",
                Width = 80
            });
            _ = dgvCheques.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_SEL",
                HeaderText = "N° Plla.Apl",
                Width = 80
            });

            dgvCheques.Columns["FECHA_DEPOSITO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheques.Columns["FECHA_ENVIO"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheques.Columns["FECHA_RECEPCION"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheques.Columns["FECHA_TRANSFERENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheques.Columns["FECHA_VERIFICACION"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCheques.Columns["IMP_COBRADO"].DefaultCellStyle.Format = N;
            dgvCheques.Columns["IMP_COBRADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCheques.Columns["FECHA_DEPOSITO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["FECHA_ENVIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["FECHA_RECEPCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["FECHA_TRANSFERENCIA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["FECHA_VERIFICACION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["IMPORTE_PROPIO_PLLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCheques.Columns["DEVOLUCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCheques.Columns["IMPORTE_APLICADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCheques.Columns["SALDO_PAGO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            HeaderTextColumnDataGridView(dgvCheques);
        }

        private void HeaderTextColumnDataGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.HeaderCell.Style.Font = new Font(dataGridView.Font, FontStyle.Bold);
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void ObtenerPlanillasXPuntoCobranza()
        {
            try
            {
                dgvCheques.Rows.Clear();
                if (dgvPuntoCobranza.CurrentCell != null)
                {
                    string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                    DataTable dt;
                    switch (tbPrincipal.SelectedIndex)
                    {
                        case (int)EtapaSeguiChequeGrid.Planillas_Pendientes:
                            dt = BLCheque.ListarPlanillasPendientesCheque(codPtoCob);
                            AgregarFilasDataGridView(dgv1, dt);
                            break;
                        case (int)EtapaSeguiChequeGrid.Planillas_Cerradas:
                            dt = BLCheque.ListarPlanillasPendientesChequeCerrados(codPtoCob);
                            AgregarFilasDataGridView(dgv2, dt);
                            break;
                    }

                    CurrentCell();
                }
                MostarTotalesCheque();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CurrentCell()
        {
            Control.ControlCollection control = tbPrincipal.SelectedTab.Controls;
            DataGridView gridView = control.OfType<DataGridView>().First();
            int index = 0;
            if (tbPrincipal.SelectedIndex == 0)
                index = indexDgv1;
            else if (tbPrincipal.SelectedIndex == 1)
                index = indexDgv2;

            if (gridView.CurrentCell != null && gridView.Rows.Count > index)
                gridView.CurrentCell = gridView["NRO_PLANILLA_COB", index];
        }

        private void BtnRegistrarCheDep_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            DataGridView gridView = ObtenerDataGridView(button);
            if (gridView != null && gridView.CurrentCell != null && dgvCheques.CurrentCell != null)
            {
                idExCheque = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID"].Value);
                if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value)).Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSeguimiento = Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                int id = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID"].Value);
                string codPtoCob = gridView.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
                string nombrePC = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                string nroPlanilla = gridView.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string nroPllaEnv = gridView.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                Tipo_Movimiento_Cheque tipo;
                string tipoMovimiento = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString();

                switch (tipoMovimiento)
                {
                    case Env_Rec_Dep: tipo = Tipo_Movimiento_Cheque.Envio; break;
                    case Deposito: tipo = Tipo_Movimiento_Cheque.Deposito; break;
                    case Transferencia: tipo = Tipo_Movimiento_Cheque.Transferencia; break;
                    default: throw new ArgumentException();
                }

                RegistroCheque cheques = new RegistroCheque(id, tipo, idSeguimiento, nombrePC, nroPlanilla, nroPllaEnv, codPtoCob)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Pas = !string.IsNullOrEmpty(dgvCheques.CurrentRow.Cells["ESTADO"].Value.ToString()) && Convert.ToInt32(dgvCheques.CurrentRow.Cells["ESTADO"].Value) == 2 ? 1 : 0
                };
                _ = cheques.ShowDialog();
                ActualizarRegistroActualPtoCobranza();
                ActualizarRegistroActualPlanilla();
                ObtenerCheques(dgv1);
            }
        }

        private DataGridView ObtenerDataGridView(ToolStripButton button)
        {
            switch (button.Name)
            {
                case "btnNuevoCheque":
                case "btnRegistrarSegui":
                    return dgv1;
                case "btnRegistrarCheque2":
                    return dgv2;
                default:
                    return null;
            }
        }

        private void TbPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbPrincipal.SelectedIndex == (int)EtapaSeguiChequeGrid.Planillas_Pendientes)
            {
                btnEliminar.Visible = true;
                btnNuevoCheque.Visible = true;
                btnRegistrarSegui.Visible = true;
                sp1.Visible = true;
                sp2.Visible = true;
            }
            else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiChequeGrid.Planillas_Cerradas)
            {
                btnEliminar.Visible = false;
                btnNuevoCheque.Visible = false;
                btnRegistrarSegui.Visible = false;
                sp1.Visible = false;
                sp2.Visible = false;
            }
            ObtenerPlanillasXPuntoCobranza();
            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
        }

        private void BtnProgramar_Click(object sender, EventArgs e)
        {
            Control.ControlCollection control = tbPrincipal.SelectedTab.Controls;
            DataGridView gridView = control.OfType<DataGridView>().First();
            if (gridView.CurrentCell != null)
            {
                int idSeguimiento = Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                int idEstado = ObtenerEstadoXTabPage();
                string nroPlanilla = gridView.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string nombrePuntoCobranaza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                string nroPllaEnv = gridView.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                string estado = tbPrincipal.SelectedTab.Text;
                int idOption = BLSeguimiento.ObtenerLlamdasXIdSeguimiento(idSeguimiento).Rows.Count == 0 ? Programado : Reprogramado;
                int idLlamadaBase = 0;
                int act = 0;

                ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloProgramado, idSeguimiento, idEstado, nroPlanilla, nroPllaEnv, nombrePuntoCobranaza, estado, idLlamadaBase)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                llamada.act = act;
                _ = llamada.ShowDialog();
                ObtenerPlanillasXPuntoCobranza();
                ListarLlamadasPendientes(ObtenerEstadoXTabPage());
            }
        }

        private void BtnResultado_Click(object sender, EventArgs e)
        {
            if (dgvLlamadas.CurrentCell != null && dgv1.CurrentCell != null)
            {
                if (Convert.ToDateTime(dgvLlamadas.CurrentRow.Cells["FECHA_LLAMADA"].Value) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    int idSeguimiento = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                    int idEstado = ObtenerEstadoXTabPage();
                    string nroPlanilla = dgvLlamadas.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString();
                    string nombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                    string estado = tbPrincipal.SelectedTab.Text;
                    int idOption = Resultado;
                    int idLlamadaBase = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_LLAMADA"].Value);
                    int idPersona = string.IsNullOrEmpty(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value.ToString()) ? 0 : Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value);
                    string tipoLlamada = dgvLlamadas.CurrentRow.Cells["TIPO"].Value.ToString();
                    string nroPllaEnv = dgvLlamadas.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                    //> CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
                    ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloRegistrado, idSeguimiento, idEstado, nroPlanilla, nroPllaEnv, nombrePuntoCobranza, estado, idLlamadaBase, tipoLlamada, idPersona)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    _ = llamada.ShowDialog();
                    ListarPuntoCobranza();
                    ObtenerPlanillasXPuntoCobranza();
                    ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                }
                else
                    _ = MessageBox.Show("Esta llamada no fue programada para el día de hoy", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnOtrosRes_Click(object sender, EventArgs e)
        {

        }

        private void ListarLlamadasPendientes(int idEstado)
        {
            dgvLlamadas.Rows.Clear();
            foreach (DataRow row in BLSeguimiento.ListarLlamadasPendienetesXEtapa(idEstado).Rows)
            {
                _ = dgvLlamadas.Rows.Add
                    (
                    row["ID_LLAMADA"].ToString(),
                    row["ID_SEGUIMIENTO"].ToString(),
                    row["ID_ESTADO"].ToString(),
                    row["ID_PERSONA"].ToString(),
                    row["TIPO"].ToString(),
                    row["NRO_PLANILLA"].ToString(),
                    row["NRO_PLLA_ENV"].ToString(),
                    Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                    row["HORA_LLAMADA"].ToString(),
                    row["NOMBRE"]?.ToString(),
                    row["AREA_LABOR"]?.ToString(),
                    row["TELEFONO"]?.ToString(),
                    row["OBSERVACION"].ToString(),
                    row["COD_PTO_COB_CONSOLIDADO"].ToString(),
                    row["Day"].ToString()
                    );
            }

            foreach (DataGridViewRow row in dgvLlamadas.Rows)
            {
                if (row.Cells["Day"].Value.ToString() == "0 días")
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private int ObtenerEstadoXTabPage()
        {
            if (tbPrincipal.SelectedIndex == 0)
                return CHEQUE_ENVIADO;
            else if (tbPrincipal.SelectedIndex == 1)
                return CHEQUE_RECEPCIONADO;
            return 0;
        }

        private void AgregarFilasDataGridView(DataGridView dataGridView, DataTable dt)
        {
            acc = dt.Rows.Count != 0;
            if (dataGridView != null && dt != null)
            {
                dataGridView.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    _ = dataGridView.Rows.Add
                        (
                        row["ID_SEGUIMIENTO"],
                        row["TIPO"],
                        row["ID_ESTADO"],
                        row["COD_PTO_COB_CONSOLIDADO"],
                        row["DESC_PTO_COB"],
                        row["TIPO_PLANILLA"],
                        row["FE_AÑO"],
                        row["FE_MES"],
                        row["NRO_PLANILLA"],
                        row["NRO_PLLA_ENV"],
                        row["PERIODO"],
                        row["IMPORTE_EJECUTADO"],
                        row["IMPORTE_CASILLERO"],
                        row["IMP_NETO"],
                        row["IMP_RETENIDO"],
                        row["AJUSTE"],
                        row["IMPORTE_NETO_ENTIDAD"],
                        row["IMP_VERIFICADO"],
                        row["SALDO_ENTIDAD"],
                        row["IMPORTE_EXC_INI"], //55
                        row["IMPORTE_APLICADO_ENV"],
                        row["IMPORTE_APLICADO_REC"],
                        row["IMPORTE_REEMBOLSO"],
                        Convert.ToDecimal(row["SALDO"]) >= 0 ? Convert.ToDecimal(row["SALDO"]) : Convert.ToDecimal(row["SALDO"]) * -1,
                        row["TIPO_APL"]
                        );
                }
            }
        }

        private void DgvConfirmCobrado_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.Name == dgv1.Name)
                indexDgv1 = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            else if (dataGrid.Name == dgv2.Name)
                indexDgv2 = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            ObtenerCheques(dataGrid);
            MostarTotalesCheque();
        }

        private void ObtenerCheques(DataGridView dataGrid)
        {
            dgvCheques.Rows.Clear();
            if (dataGrid.CurrentCell != null && acc)
            {
                int idSeguimiento = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                DataTable dt = BLCheque.ListarSeguimientoChequeXIdSeguimiento(idSeguimiento);
                decimal saldoPago;
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        saldoPago = row["IMPORTE"].ToDecimal() - row["IMPORTE_PROPIO_PLLA"].ToDecimal() - row["DEVOLUCION"].ToDecimal() - row["IMPORTE_APLICADO"].ToDecimal();
                        dgvCheques.Rows.Add
                        (
                            row["ID_SEGUIMIENTO"],
                            row["ID"],
                            row["TIPO"],
                            row["FL_GEN_APL"],
                            row["TIPO_OPER"],
                            row["NRO_OPERACION"],
                            row["NRO_DOCUMENTO"],
                            row["FECHA_ENVIO"],
                            row["FECHA_RECEPCION"],
                            row["FECHA_DEPOSITO"],
                            row["FECHA_TRANSFERENCIA"],
                            row["FECHA_VERIFICADO"],
                            row["IMPORTE"],
                            row["IMPORTE_PROPIO_PLLA"],
                            row["IMPORTE_APLICADO"],
                            row["DEVOLUCION"],
                            saldoPago,
                            row["ESTADO"],
                            row["DESC_ESTADO"],
                            row["NRO_PLANILLA_SEL"]
                        );
                    }
                }
            }
            CurrentCellDgvCheques();
        }

        private void MostarTotalesCheque()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCheques.Rows)
            {
                total += string.IsNullOrEmpty(row.Cells["IMP_COBRADO"].Value.ToString()) ? 0 : Convert.ToDecimal(row.Cells["IMP_COBRADO"].Value);
            }
            lblTotCobCheque.Text = "Total Importe : " + total.ToString(N);
        }

        private void DgvLlamadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLlamadas.CurrentCell != null)
            {
                DialogResult dr = MessageBox.Show("¿Esta seguro de elimianar esta llamada?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        LLamadas llamada = ObtenerDatosEliminar();
                        _ = BLSeguimiento.EliminarLlamada(llamada)
                            ? _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : _ = MessageBox.Show("Ocurrió un problema al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private LLamadas ObtenerDatosEliminar()
        {
            return new LLamadas
            {
                ID_LLAMADA_BASE = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_LLAMADA"].Value),
                SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                {
                    PersonaEnvio = new PersonaEnvioTo
                    {
                        ID_PERSONA = string.IsNullOrEmpty(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value.ToString())
                        ? 0
                        : Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value)
                    }
                }
            };
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ListarPuntoCobranza();
            ObtenerPlanillasXPuntoCobranza();
            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
        }

        private void BtnNuevoCheque_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentCell != null)
            {
                idExCheque = dgvCheques.CurrentCell != null ? Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID"].Value) : 0;
                if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(Convert.ToInt32(dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value)).Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idSeguimiento = Convert.ToInt32(dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                string nombrePC = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                string nroPlanilla = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string nroPllaEnv = dgv1.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                RegistroCheque cheques = new RegistroCheque(-1, idSeguimiento, nombrePC, nroPlanilla, nroPllaEnv)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                _ = cheques.ShowDialog();
                ObtenerCheques(dgv1);
            }
        }

        private void BtnCerrarPlanilla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.CurrentCell != null)
                {
                    if (dgvCheques.Rows.Count == 0)
                    {
                        _ = MessageBox.Show("Esta planilla aún no tiene operaciones registradas", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (VerificarChequesCerrados())
                    {
                        int idSeguimiento = Convert.ToInt32(dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                        decimal impEjec = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMPORTE_EJECUTADO"].Value);
                        decimal impCasillero = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMPORTE_CASILLERO"].Value);
                        decimal impNetoPlanilla = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMP_NETO"].Value);
                        decimal impCobrado = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMP_VERIFICADO"].Value);
                        decimal saldo = Convert.ToDecimal(dgv1.CurrentRow.Cells["SALDO_ENTIDAD"].Value);
                        decimal impExceso = Convert.ToDecimal(dgv1.CurrentRow.Cells["EXCESO_COBRANZA"].Value);
                        decimal impAplicEnv = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMPORTE_APLICADO_ENV"].Value);
                        decimal impAplicRec = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMPORTE_APLICADO_REC"].Value);
                        decimal impReembolso = Convert.ToDecimal(dgv1.CurrentRow.Cells["IMPORTE_REEMBOLSO"].Value);
                        string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                        string nroPlanillaEnv = dgv1.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                        string nroPlanillaCob = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                        string feAño = dgv1.CurrentRow.Cells["FE_AÑO"].Value.ToString();
                        string feMes = dgv1.CurrentRow.Cells["FE_MES"].Value.ToString();
                        string tipoPlanilla = dgv1.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString();
                        string ent_pag_che = dgv1.CurrentRow.Cells["IG"].Value.ToString();
                        FinalizarCobranzaPlanilla frmFinalizarCobranzaPlla = new FinalizarCobranzaPlanilla(idSeguimiento, impEjec, impCasillero, impNetoPlanilla, impCobrado, saldo, impExceso,
                            impAplicEnv, impAplicRec, impReembolso, codPtoCob, nroPlanillaEnv, nroPlanillaCob, feAño, feMes, tipoPlanilla,
                            ent_pag_che, COD_USUARIO)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        frmFinalizarCobranzaPlla.EncabezadoForm
                            (
                                dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString(),
                                dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString()
                            );
                        _ = frmFinalizarCobranzaPlla.ShowDialog();
                        ActualizarRegistroActualPtoCobranza();
                        if (frmFinalizarCobranzaPlla.EsCerrar)
                            ObtenerPlanillasXPuntoCobranza();
                        else
                            ActualizarRegistroActualPlanilla();
                        ObtenerCheques(dgv1);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private bool VerificarChequesCerrados()
        {
            foreach (DataGridViewRow row in dgvCheques.Rows)
            {
                if (Convert.ToInt32(row.Cells["ESTADO"].Value) == (int)Resultado_Cheque.Pendiente)
                {
                    _ = MessageBox.Show("Existen cheques que aún estan pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void BtnVerChqueAprobado_Click(object sender, EventArgs e)
        {

        }

        private void StyleHeaderTextDataGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.Style1();
                dataGridView.AlingHeaderTextCenter();
                dataGridView.Columns["PERIODO"].Frozen = true;
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.HeaderCell.Style.Font = new Font(dataGridView.Font, FontStyle.Bold);
                }

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (column.Index <= 10)
                        column.HeaderCell.Style.BackColor = Color.White;
                    else if (column.Index <= 13)
                        column.HeaderCell.Style.BackColor = Color.MediumSpringGreen;
                    else if (column.Index <= 17)
                        column.HeaderCell.Style.BackColor = Color.SkyBlue;
                    else
                        column.HeaderCell.Style.BackColor = Color.PeachPuff;
                }
            }
        }
        private void abrirventana(bool inhabilitar)
        {
            decimal saldo = dgvCheques.CurrentRow.Cells["SALDO_PAGO"].Value.ToDecimal();
            decimal depositoplanilla = dgvCheques.CurrentRow.Cells["importe_propio_plla"].Value.ToDecimal();
            decimal importeaplicado = dgvCheques.CurrentRow.Cells["IMPORTE_APLICADO"].Value.ToDecimal();

            decimal devolucionentidad = dgvCheques.CurrentRow.Cells["DEVOLUCION"].Value.ToDecimal();
            //int id_seguimiento = dgvCheques.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32();
            //int id_pago = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32();



            //if (devolucionentidad > 0)
            //{
            //    MessageBox.Show("El registro ya cuenta con una devolución de " + devolucionentidad.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}



            if ((saldo > 0) || (importeaplicado > 0) || (depositoplanilla > 0))
            {
                ChequesPlanillaTo chequeplanilla = new ChequesPlanillaTo
                {
                    ID_PAGO = 0,
                    SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                    {
                        ID_SEGUIMIENTO = dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32(),
                        NRO_PLANILLA = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),  //NRO_PLLA_ENV



                        IMPORTE_NETO = dgvCheques.CurrentRow.Cells["IMP_COBRADO"].Value.ToDecimal(),

                        TIPO_PAGO = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString(),

                        PERIODO = dgv1.CurrentRow.Cells["PERIODO"].Value.ToString(),  //NRO_PLLA_ENV
                        ID_PAGO = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32(),

                        IMPORTE_EXC_DOC = (saldo > 0) ? saldo : (importeaplicado > 0) ? importeaplicado : 0,

                        SALDO_X_COBRAR = saldo,
                        CHEQUE_APLICADO_SALDO = (saldo > 0) ? 1 : (importeaplicado > 0) ? 2 : 0,
                        INHABILITAR = inhabilitar,
                        TEXTODESCRIPTIVOGRILLA = "Al eliminar el cheque se anularán los siguientes elementos",
                        TEXTOMSJELIMINACION = "Mensaje"
                    }
                };

                FrmDevolucionExcesoEntidad frmdevolucion = new FrmDevolucionExcesoEntidad(chequeplanilla);
                //ListaPlanillasAplicarSaldo frmAplica = new ListaPlanillasAplicarSaldo(true, Tipo_APL_SALDO.Planilla_Imp_Exceso, se, idPago, tipoOperacionCobranza)
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }
                _ = frmdevolucion.ShowDialog();
                if (frmdevolucion.DialogResult == DialogResult.OK)
                {
                    ObtenerCheques(dgv1);
                    ActualizarRegistroActualPlanilla();
                }
            }
            else
            {
                MessageBox.Show("No es posible realizar devoluciones.\n El campo 'Saldo' o 'Aplicado a planilla' 0 'Cobro Planilla' deben ser mayor a 0", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //DataTable dt = BLCheque.ObtenerDespositoChequeXIdSeguimiento(43434, 43434);
            //string a = dt.Rows[0]["hhaha"].ToString();
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCheques.CurrentCell != null)
                {
                    if (!ValidarEliminarPago())
                        return;

                    if (!string.IsNullOrEmpty(dgvCheques.CurrentRow.Cells["ESTADO"].Value.ToString()) && Convert.ToInt32(dgvCheques.CurrentRow.Cells["ESTADO"].Value) == 2)
                    {
                        _ = MessageBox.Show("!CUIDADO! Este cheque ya esta aprobado", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    abrirventana(false);
                    if (Del_operacion == 1)
                    {
                        ChequesPlanillaTo chequePllaTo = ObtenerChequesPlanillaToEliminar();
                        if (chequePllaTo != null)
                        {
                            _ = BLCheque.EliminarCobranzaPlanilla(chequePllaTo)
                                ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Del_operacion = 0;
                        ObtenerCheques(dgv1);
                        ActualizarRegistroActualPlanilla();
                        ActualizarRegistroActualPtoCobranza();
                        MostarTotalesCheque();
                    }
                  
                    //DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar esta operación?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //if (dr == DialogResult.Yes)
                    //{

                    //ChequesPlanillaTo chequePllaTo = ObtenerChequesPlanillaToEliminar();
                    //if (chequePllaTo != null)
                    //{
                    //    _ = BLCheque.EliminarCobranzaPlanilla(chequePllaTo)
                    //        ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //        : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //ObtenerCheques(dgv1);
                    //    ActualizarRegistroActualPlanilla();
                    //    ActualizarRegistroActualPtoCobranza();
                    //    MostarTotalesCheque();
                    //}
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ChequesPlanillaTo ObtenerChequesPlanillaToEliminar()
        {
            int id = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID"].Value);
            int estadoCheque = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ESTADO"].Value);
            bool flGenApl = Convert.ToBoolean(dgvCheques.CurrentRow.Cells["FL_GEN_APL"].Value);
            //Tipo_Operacion_Cobranza tipoOperacion;
            //switch (dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString())
            //{
            //    case Env_Rec_Dep: tipoOperacion = Tipo_Operacion_Cobranza.Env_Rec_Dep; break;
            //    case Deposito: tipoOperacion = Tipo_Operacion_Cobranza.Deposito; break;
            //    case Transferencia: tipoOperacion = Tipo_Operacion_Cobranza.Transferencia; break;
            //    default: throw new ArgumentException();
            //}
            return new ChequesPlanillaTo
            {
                TIPO_PAGO_TXT = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString(),
                ESTADO = (Resultado_Cheque)estadoCheque,
                ID_PAGO = id,
                FL_GEN_APL = flGenApl,
                DepositoChequeTo = new DepositoChequeTo
                {
                    IMPORTE = dgvCheques.CurrentRow.Cells["IMP_COBRADO"].Value.ToDecimal()
                },
                SeguimientoPlanillaTo = ObtenerSegumientoPlanillaParaEliminarCheque()
            };
        }

        

        private bool ValidarEliminarPago()
        {
            int id = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID"].Value);
            if (BLCheque.VerificarSiDepositoRegistradoTesoreria(id))
            {
                _ = MessageBox.Show("Este pago ya se encuentra registrado en tesorería, no se puede eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private SeguimientoPlanillaTo ObtenerSegumientoPlanillaParaEliminarCheque()
        {
            int idSeguimiento = Convert.ToInt32(dgvCheques.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            string nroPlanilla = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            string nroPllaEnv = dgv1.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
            decimal importeVerificado = Convert.ToDecimal(dgvCheques.CurrentRow.Cells["IMP_COBRADO"].Value);
            DataTable dt = BLCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPllaEnv, idSeguimiento);

            if (dt is null || dt.Rows.Count != 1)
            {
                _ = MessageBox.Show("Error al obtener datos de la planilla N°obts(" + dt.Rows.Count.ToString() + ")." + "\n Comuniquese con el administrador de sistemas",
                    "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new SeguimientoPlanillaTo
            {
                ID_SEGUIMIENTO = idSeguimiento,
                NRO_PLANILLA = nroPlanilla,
                NRO_PLLA_ENV = nroPllaEnv,
                ID_ESTADO = CHEQUE_CONFIRMADO,
                IMPORTE_EXC_INI = ObtenerImporteExcesoIni(),
                IMPORTE_EXC_DOC = ObtenerImporteExcesoDoc(),
                IMPORTE_VERIFICADO = ObtenerImporteTotalVerificado(),
                SALDO_X_COBRAR = ObtenerSaldoXCobrar()
            };

            decimal ObtenerImporteExcesoIni()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeVerificado);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteExcesoDoc()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeVerificado)
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? 0 : saldo * -1;
            }

            decimal ObtenerImporteTotalVerificado()
            {
                return Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeVerificado;
            }

            decimal ObtenerSaldoXCobrar()
            {
                decimal saldo = Convert.ToDecimal(dt.Rows[0]["IMPORTE_NETO_ENTIDAD"]) - (Convert.ToDecimal(dt.Rows[0]["IMP_VERIFICADO"]) - importeVerificado)
                    + Convert.ToDecimal(dt.Rows[0]["IMPORTE_REEMBOLSO"]);
                return saldo >= 0 ? saldo : 0;
            }
        }

        private void BtnVerCobranza_Click(object sender, EventArgs e)
        {
            if (dgv2.CurrentCell != null)
            {
                int idSeguimiento = Convert.ToInt32(dgv2.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                decimal impEjec = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMPORTE_EJECUTADO"].Value);
                decimal impCasillero = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMPORTE_CASILLERO"].Value);
                decimal impNetoPlanilla = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMP_NETO"].Value);
                decimal impCobrado = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMP_VERIFICADO"].Value);
                decimal saldo = Convert.ToDecimal(dgv2.CurrentRow.Cells["SALDO_ENTIDAD"].Value);
                decimal impExceso = Convert.ToDecimal(dgv2.CurrentRow.Cells["EXCESO_COBRANZA"].Value);
                decimal impAplicEnv = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMPORTE_APLICADO_ENV"].Value);
                decimal impAplicRec = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMPORTE_APLICADO_REC"].Value);
                decimal impReembolso = Convert.ToDecimal(dgv2.CurrentRow.Cells["IMPORTE_REEMBOLSO"].Value);
                string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                string nroPlanillaEnv = dgv2.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                string nroPlanillaCob = dgv2.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string ent_pag_che = dgv2.CurrentRow.Cells["IG"].Value.ToString();
                FinalizarCobranzaPlanilla frmFinalizarCobranzaPlla = new FinalizarCobranzaPlanilla(idSeguimiento, impEjec, impCasillero, impNetoPlanilla, impCobrado, saldo,
                    impExceso, impAplicEnv, impAplicRec, impReembolso, codPtoCob, nroPlanillaEnv, nroPlanillaCob, ent_pag_che, COD_USUARIO)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmFinalizarCobranzaPlla.EncabezadoForm
                (
                    dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString(),
                    dgv2.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString()
                );
                frmFinalizarCobranzaPlla.DesactivarOpciones();
                _ = frmFinalizarCobranzaPlla.ShowDialog();
            }
        }

        private void Dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void DgvPuntoCobranza_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPuntoCobranza.CurrentCell is null)
                return;
            codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
            ObtenerPlanillasXPuntoCobranza();
        }

        private void DgvPuntoCobranza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvPuntoCobranza.CurrentCell is null)
            //    return;
            //if (e.RowIndex >= 0)
            //    codPtoCob = dgvPuntoCobranza["COD_PTO_COB", e.RowIndex].Value.ToString();
            //ObtenerPlanillasXPuntoCobranza();
        }

        private void TbPrincipal_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tbPrincipal.TabPages[e.Index];

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            // Este sera el rectangulo que se dibujara sobre el titutlo del tab 
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);
            // Este sera el color por defecto del tab no seleccionado 
            SolidBrush sb = new SolidBrush(Color.AntiqueWhite);
            //> Este sera el color por defecto del text del tab no seleccionado
            SolidBrush solidBrush = new SolidBrush(Color.Blue);
            if (tbPrincipal.SelectedIndex == e.Index)
            {
                // color del tab que se selecciona
                sb.Color = Color.Teal;
                //> color del text del tab seleccionado
                solidBrush.Color = Color.White;
            }

            // aplica el color sobre el tabpage actual 
            g.FillRectangle(sb, e.Bounds);

            Font font = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);

            //escribe el texto que tenia el tab
            g.DrawString(tp.Text, font, solidBrush, headerRect, sf);
        }

        private void Dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            int idSeguimiento = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            if (dataGrid.Columns[e.ColumnIndex].Name == "IMP_RETENIDO")
            {
                string nroPllaEnv = dataGrid.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
                string nroPlanilla = dataGrid.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                string entPagChe = dataGrid.CurrentRow.Cells["IG"].Value.ToString();
                FrmVistaRetencion frmRetencion = new FrmVistaRetencion(nroPllaEnv, nroPlanilla, entPagChe)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                _ = frmRetencion.ShowDialog();
            }
            else if (dataGrid.Columns[e.ColumnIndex].Name == "IMPORTE_APLICADO_ENV" || dataGrid.Columns[e.ColumnIndex].Name == "IMPORTE_APLICADO_REC")
            {
                const bool modoInsert = false;
                Tipo_APL_SALDO tipoPlanillaAplic = dataGrid.Columns[e.ColumnIndex].Name == "IMPORTE_APLICADO_ENV" ? Tipo_APL_SALDO.Planilla_Imp_Exceso : Tipo_APL_SALDO.Planilla_Imp_x_cobrar;
                ListaPlanillasAplicarSaldo frmPlanillas = new ListaPlanillasAplicarSaldo(modoInsert, idSeguimiento, tipoPlanillaAplic)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                _ = frmPlanillas.ShowDialog();
            }
            else if (dataGrid.Columns[e.ColumnIndex].Name == "IMPORTE_REEMBOLSO")
            {
                FrmVistaReembolso frmReembolso = new FrmVistaReembolso(idSeguimiento)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                _ = frmReembolso.ShowDialog();
            }
        }

        private void CurrentCellDgvCheques()
        {
            if (dgvCheques.Rows.Count > 0)
            {
                IEnumerable<DataGridViewRow> row = dgvCheques.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells["ID"].Value.ToString() == idExCheque.ToString());
                if (row.Any())
                    dgvCheques.CurrentCell = dgvCheques["TIPO_OPERACION", row.Select(f => f.Index).FirstOrDefault()];
            }
        }

        private void ActualizarRegistroActualPlanilla()
        {
            string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
            //string nroPlanillaEnv = dgv1.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
            //int idSeguimiento = Convert.ToInt32(dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            DataTable dt = BLCheque.ListarPlanillasPendientesCheque(codPtoCob);//> BLCheque.ObtenerPlanillasPendientesCheque(codPtoCob, nroPlanillaEnv, idSeguimiento);
            if (dt != null && dt.Rows.Count > 0)
            {
                int io = 0;
                foreach (DataRow rw in dt.Rows)
                {
                    if (io > dgv1.Rows.Count - 1)
                        break;
                    DataGridViewRow row = dgv1.Rows[io];
                    if (Convert.ToInt32(row.Cells["ID_SEGUIMIENTO"].Value) == Convert.ToInt32(rw["ID_SEGUIMIENTO"]))
                    {
                        if (string.IsNullOrEmpty(rw["FECHA_CIERRE_COBRANZA"]?.ToString())) //> Aún no se a finalizado la cobranza
                        {
                            row.Cells["IMP_RETENIDO"].Value = rw["IMP_RETENIDO"];
                            row.Cells["AJUSTE"].Value = rw["AJUSTE"];
                            row.Cells["IMPORTE_NETO_ENTIDAD"].Value = rw["IMPORTE_NETO_ENTIDAD"];
                            row.Cells["IMP_VERIFICADO"].Value = rw["IMP_VERIFICADO"];
                            row.Cells["SALDO_ENTIDAD"].Value = rw["SALDO_ENTIDAD"];
                            row.Cells["EXCESO_COBRANZA"].Value = rw["IMPORTE_EXC_INI"];
                            row.Cells["IMPORTE_APLICADO_ENV"].Value = rw["IMPORTE_APLICADO_ENV"];
                            row.Cells["IMPORTE_APLICADO_REC"].Value = rw["IMPORTE_APLICADO_REC"];
                            row.Cells["IMPORTE_REEMBOLSO"].Value = rw["IMPORTE_REEMBOLSO"];
                            row.Cells["SALDO"].Value = Convert.ToDecimal(rw["SALDO"]) >= 0 ? Convert.ToDecimal(rw["SALDO"]) : Convert.ToDecimal(rw["SALDO"]) * -1;
                            row.Cells["TIPO_APL"].Value = rw["TIPO_APL"];
                        }
                    }
                    io += 1;
                }
            }
            else
            {
                _ = MessageBox.Show("Error al actualizar la fila actual, no se encontraron datos \n" +
                    "Comuniquese con el adminstrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAplicarDevolucionEnt_Click(object sender, EventArgs e)
        {
            decimal saldo = dgvCheques.CurrentRow.Cells["SALDO_PAGO"].Value.ToDecimal();
            decimal depositoplanilla = dgvCheques.CurrentRow.Cells["importe_propio_plla"].Value.ToDecimal();
            decimal importeaplicado = dgvCheques.CurrentRow.Cells["IMPORTE_APLICADO"].Value.ToDecimal();

            decimal devolucionentidad = dgvCheques.CurrentRow.Cells["DEVOLUCION"].Value.ToDecimal();
            //int id_seguimiento = dgvCheques.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32();
            //int id_pago = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32();



            if (devolucionentidad > 0)
            {
                MessageBox.Show("El registro ya cuenta con una devolución de " + devolucionentidad.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if ((saldo > 0) || (importeaplicado > 0) || (depositoplanilla > 0))
            {
                ChequesPlanillaTo chequeplanilla = new ChequesPlanillaTo
                {
                    ID_PAGO = 0,
                    SeguimientoPlanillaTo = new SeguimientoPlanillaTo
                    {
                        ID_SEGUIMIENTO = dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32(),
                        NRO_PLANILLA = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),  //NRO_PLLA_ENV



                        IMPORTE_NETO = dgvCheques.CurrentRow.Cells["IMP_COBRADO"].Value.ToDecimal(),

                        TIPO_PAGO = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString(),

                        PERIODO = dgv1.CurrentRow.Cells["PERIODO"].Value.ToString(),  //NRO_PLLA_ENV
                        ID_PAGO = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32(),

                        IMPORTE_EXC_DOC = (saldo > 0) ? saldo : (importeaplicado > 0) ? importeaplicado : 0,

                        SALDO_X_COBRAR = saldo,
                        CHEQUE_APLICADO_SALDO = (saldo > 0) ? 1 : (importeaplicado > 0) ? 2 : 0,
                        INHABILITAR = true,
                        TEXTODESCRIPTIVOGRILLA = "Marque los movimientos a anular antes de la 'Devolución a entidad'",
                        TEXTOMSJELIMINACION = "Ninguno"
                    }
                };

                FrmDevolucionExcesoEntidad frmdevolucion = new FrmDevolucionExcesoEntidad(chequeplanilla);
                //ListaPlanillasAplicarSaldo frmAplica = new ListaPlanillasAplicarSaldo(true, Tipo_APL_SALDO.Planilla_Imp_Exceso, se, idPago, tipoOperacionCobranza)
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }
                _ = frmdevolucion.ShowDialog();
                if (frmdevolucion.DialogResult == DialogResult.OK)
                {
                    ObtenerCheques(dgv1);
                    ActualizarRegistroActualPlanilla();
                }
            }
            else
            {
                MessageBox.Show("No es posible realizar devoluciones.\n El campo 'Saldo' o 'Aplicado a planilla' 0 'Cobro Planilla' deben ser mayor a 0", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //DataTable dt = BLCheque.ObtenerDespositoChequeXIdSeguimiento(43434, 43434);
            //string a = dt.Rows[0]["hhaha"].ToString();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private List<DevolucionExcesoEntidad> ObtenerDevolucionExcesoEntidadEliminar()
        {
            List<DevolucionExcesoEntidad> lista = new List<DevolucionExcesoEntidad>();

            lista.Add(new DevolucionExcesoEntidad
            {
                ID_SEGUIMIENTO = dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32(),
                ID_PAGO = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32(),
                TIPO_PAGO = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString(),

            });

            return lista;
        }

        private void btnEliminarDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCheques.CurrentCell != null)
                {

                    if (dgvCheques.CurrentRow.Cells["DEVOLUCION"].Value.ToDecimal() == 0)
                    {
                        _ = MessageBox.Show("No existen devoluciones por eliminar", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar esta devolución?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {

                        List<DevolucionExcesoEntidad> reg = ObtenerDevolucionExcesoEntidadEliminar();

                        if (BLCheque.EliminarDevolucionExcesoEntidad(reg))
                        {
                            DialogResult = DialogResult.OK;
                            //  ListarPlanillasSaldoXCobrar();
                            //ActualizarSaldoDisponible();
                            _ = MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ObtenerCheques(dgv1);
                            ActualizarRegistroActualPlanilla();
                        }
                        else
                            _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);











                        //ChequesPlanillaTo chequePllaTo = ObtenerChequesPlanillaToEliminar();
                        //if (chequePllaTo != null)
                        //{
                        //    _ = BLCheque.EliminarCobranzaPlanilla(chequePllaTo)
                        //        ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //        : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //ObtenerCheques(dgv1);
                        //ActualizarRegistroActualPlanilla();
                        //ActualizarRegistroActualPtoCobranza();
                        //MostarTotalesCheque();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarRegistroActualPtoCobranza()
        {
            string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
            DataTable dt = BLPuntoCobranza.ObtenerPtoCobranzaCheques(EmpresaSistema.CodPais, codPtoCob);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataGridViewRow row = dgvPuntoCobranza.CurrentRow;
                row.Cells["IMPORTE_NETO_ENTIDAD"].Value = dt.Rows[0]["IMPORTE_NETO_ENTIDAD"];
                row.Cells["IMP_COBRADO"].Value = dt.Rows[0]["IMP_COBRADO"];
                row.Cells["SALDO_ENTIDAD"].Value = dt.Rows[0]["SALDO_ENTIDAD"];
                row.Cells["EXCESO_COBRANZA"].Value = dt.Rows[0]["EXCESO_COBRANZA"];
                row.Cells["SALDO"].Value = dt.Rows[0]["SALDO"];
            }
            else
            {
                _ = MessageBox.Show("Error al actualizar la fila de Punto Cobranza, no se encontraron datos \n" +
                    "Comuniquese con el adminstrador del sistema", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Aplica el exceso(importe pagado de más) de un cheque/Depósito/Transferencia a otras planillas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAplicacionExcOtrasPllas_Click(object sender, EventArgs e)
        {
            if (!ValidarAplicarExcOtrosPllas())
                return;

            int idSeguimiento = dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32();
            string nroPlanillaEnv = dgv1.CurrentRow.Cells["NRO_PLLA_ENV"].Value.ToString();
            string nroPlanillaCob = dgv1.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
            string feAño = dgv1.CurrentRow.Cells["FE_AÑO"].Value.ToString();
            string feMes = dgv1.CurrentRow.Cells["FE_MES"].Value.ToString();
            string codPtoCobConsoliddo = dgv1.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString();
            int idPago = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32();
            decimal saldoPago = dgvCheques.CurrentRow.Cells["SALDO_PAGO"].Value.ToDecimal() + dgvCheques.CurrentRow.Cells["IMPORTE_APLICADO"].Value.ToDecimal();
            Tipo_Operacion_Cobranza tipoOperacionCobranza;
            string tipoMovimiento = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString();

            switch (tipoMovimiento)
            {
                case Env_Rec_Dep: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Env_Rec_Dep; break;
                case Deposito: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Deposito; break;
                case Transferencia: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Transferencia; break;
                default: throw new ArgumentException();
            }
            SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
            {
                ID_SEGUIMIENTO = idSeguimiento,
                NRO_PLLA_ENV = nroPlanillaEnv,
                NRO_PLANILLA = nroPlanillaCob,
                FE_AÑO = feAño,
                FE_MES = feMes,
                COD_PTO_COB_CONSOLIDADO = codPtoCobConsoliddo,
                IMPORTE_EXC_DOC = saldoPago
            };

            ListaPlanillasAplicarSaldo frmAplica = new ListaPlanillasAplicarSaldo(true, Tipo_APL_SALDO.Planilla_Imp_Exceso, se, idPago, tipoOperacionCobranza)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            _ = frmAplica.ShowDialog();
            if (frmAplica.DialogResult == DialogResult.OK)
            {
                ObtenerCheques(dgv1);
                ActualizarRegistroActualPlanilla();
            }
        }

        private bool ValidarAplicarExcOtrosPllas()
        {
            if (tbPrincipal.SelectedTab != tabPage1)
                return false;

            Tipo_Operacion_Cobranza tipoOperacionCobranza;
            string tipoMovimiento = dgvCheques.CurrentRow.Cells["TIPO"].Value.ToString();
            switch (tipoMovimiento)
            {
                case Env_Rec_Dep: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Env_Rec_Dep; break;
                case Deposito: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Deposito; break;
                case Transferencia: tipoOperacionCobranza = Tipo_Operacion_Cobranza.Transferencia; break;
                default: throw new ArgumentException();
            }

            if (Convert.ToInt32(dgvCheques.CurrentRow.Cells["ESTADO"].Value) == (int)Resultado_Cheque.Pendiente)
            {
                _ = MessageBox.Show("Este cheque aún estan pendiente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int idSeguimiento = dgv1.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32();
            int idPago = dgvCheques.CurrentRow.Cells["ID"].Value.ToInt32();

            DataTable dt = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia
                ? BLCheque.ObtenerDespositoChequeXIdSeguimiento(idSeguimiento, idPago)
                : BLCheque.ObtenerTransChequeXIdSeguimiento(idSeguimiento, idPago);


            if (dt == null || dt.Rows.Count == 0)
            {
                string message = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia ? "el depósito" : "la transferencia";
                _ = MessageBox.Show($"No se encontró {message} seleccionado. \n Cierre el formulario y vuelva a intentarlo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal importeVerificado = dt.Rows[0]["IMPORTE_VERIFICADO"].ToDecimal();
            decimal importePropioPlla = dt.Rows[0]["IMPORTE_PROPIO_PLLA"].ToDecimal();
            if (importeVerificado - importePropioPlla <= 0)
            {
                string message = tipoOperacionCobranza != Tipo_Operacion_Cobranza.Transferencia ? "Este depósito" : "Esta transferencia";
                _ = MessageBox.Show($"{message} no tiene importe exceso", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
