using BLL;
using Entidades;
using Presentacion.MOD_FACT_VTA.MOD_VTA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static Entidades.ConstClass;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.GenericMethod;

namespace SysSeguimiento
{
    public partial class SeguimientoPlanilla : Form
    {
        public static string COD_USUARIO { get; set; }
        public static SeguimientoPlanilla Instancia { get; set; }
        public SeguimientoPlanilla(string año, string mes, string COD_USU)
        {
            InitializeComponent();
            COD_USUARIO = COD_USU;
            Instancia = this;
        }

        private static readonly puntoCobranzaBLL BLPuntoCobranza = new puntoCobranzaBLL();
        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private int indexHistorial, indexEnvio, indexRecepcion, indexProceso, indexLista, indexLlamada;
        private static string codPtoCob;
        private DataTable dtPtoCobranzaPlanillasEjectadas;

        private const string COLUMN_NAME1 = "NoEjecutado";
        private const string COLUMN_NAME2 = "COD_PTO_COB";
        private const string COLUMN_NAME3 = "NRO_PLANILLA_COB";
        private const int ESTA_EJECUTADO = 1;

        private void SeguimientoPlanilla_Load(object sender, EventArgs e)
        {
            StartControls();
            ObtenerPtoCobranzaConPlanillasEjecutadas();
            ColumnasDataGridView(dgvConfirmEnvio);
            ColumnasDataGridView(dgvConfirmRecep);
            ColumnasDataGridView(dgvConfirmPro);
            ColumnasDataGridView(dgvLista);
            ColumnasDataGridView(dgvNoEjecutados);
            ColumnasDataGridView(dgvNoDescontado);
            ColumnasDataGridView(dgvDesctoConfirmado);
            FormatGridViewLlamada();
            FormatGridViewHistorialLlamadas();
            ListarPuntoCobranza();
            ListarLlamadasPendientes(ENVIADA);
        }

        private void StartControls()
        {
            dgvLlamadas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLlamadas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvLlamadas.DefaultCellStyle.Font = new Font(dgvLlamadas.Font, FontStyle.Regular);

            dgvHistorialLlamadas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHistorialLlamadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialLlamadas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvHistorialLlamadas.DefaultCellStyle.SelectionForeColor = Color.Blue;
        }

        private void ListarPuntoCobranza()
        {
            dgvPuntoCobranza.DataSource = BLPuntoCobranza.ObtenerPuntoCobranzaXPlanillasTrasnferidasBLL(EmpresaSistema.CodPais);

            if (dgvPuntoCobranza.Rows.Count > 0)
            {
                dgvPuntoCobranza.Columns["COD_PTO_COB"].HeaderText = "Cod";
                dgvPuntoCobranza.Columns["COD_PTO_COB"].Width = 40;
                dgvPuntoCobranza.Columns["DESC_PTO_COB"].HeaderText = "Descripción";
                dgvPuntoCobranza.Columns["DESC_PTO_COB"].Width = 175;
                dgvPuntoCobranza.Columns["Desc_dep"].HeaderText = "Departamento";
                dgvPuntoCobranza.Columns["Desc_dep"].Width = 120;
                dgvPuntoCobranza.Columns["Envio"].HeaderText = "Env";
                dgvPuntoCobranza.Columns["Envio"].Width = 40;
                dgvPuntoCobranza.Columns["Recepcion"].HeaderText = "Rec";
                dgvPuntoCobranza.Columns["Recepcion"].Width = 40;
                dgvPuntoCobranza.Columns["Procesamiento"].HeaderText = "Proc";
                dgvPuntoCobranza.Columns["Procesamiento"].Width = 40;
                dgvPuntoCobranza.Columns["N°"].Width = 25;
                dgvPuntoCobranza.Columns["CD"].HeaderText = "List";
                dgvPuntoCobranza.Columns["CD"].Width = 40;
                dgvPuntoCobranza.Columns["NoEjecutado"].HeaderText = "Ejec";
                dgvPuntoCobranza.Columns["NoEjecutado"].Width = 45;
                dgvPuntoCobranza.Columns["ND"].HeaderText = "N.Dsct";
                dgvPuntoCobranza.Columns["ND"].Width = 50;
                dgvPuntoCobranza.Columns["SD"].HeaderText = "S.Dsct";
                dgvPuntoCobranza.Columns["SD"].Width = 50;
                FormatGridPuntoCobranza();
            }

            DataGridViewRow row = dgvPuntoCobranza.Rows.Cast<DataGridViewRow>()
                 .Where(x => x.Cells["COD_PTO_COB"].Value.ToString() == codPtoCob).FirstOrDefault();
            if (row != null)
                dgvPuntoCobranza.CurrentCell = dgvPuntoCobranza["COD_PTO_COB", row.Index];
        }

        private void FormatGridPuntoCobranza()
        {
            dgvPuntoCobranza.MultiSelect = false;
            dgvPuntoCobranza.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvPuntoCobranza.RowHeadersVisible = false;
            dgvPuntoCobranza.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPuntoCobranza.DefaultCellStyle.SelectionForeColor = Color.Blue;
            dgvPuntoCobranza.DefaultCellStyle.Font = new Font(dgvPuntoCobranza.Font, FontStyle.Regular);
            dgvPuntoCobranza.EnableHeadersVisualStyles = false;
        }

        private void ListarPlanillas(string codPtoCob, DateTime fechaInicio, DateTime fechaFin, int acces)
        {
            DataTable dt = BLSeguimiento.ListarPlanillasPendientesEnviar(codPtoCob, fechaInicio, fechaFin, acces);
            if (dgvConfirmEnvio.Rows.Count > 0)
                dgvConfirmEnvio.CurrentCell = dgvConfirmEnvio["FE_SEGUI_PLAN", 0];
            AgregarFilasDataGridView(dgvConfirmEnvio, dt);
        }

        private void ColumnasDataGridView(DataGridView gridView)
        {
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IG",
                HeaderText = "TIPO",
                Width = 50
            });

            if (gridView.Name == dgvConfirmEnvio.Name)
            {
                _ = gridView.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    Name = "CHECK",
                    HeaderText = "CH",
                    Width = 30
                });
            }
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ESTADO",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB_CONSOLIDADO",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_INSTITUCION",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_CANAL_DSCTO",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA",
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_SEGUI_PLAN",
                HeaderText = "FEC.TRANSFER.",
                Width = 120,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_LLAMADA",
                HeaderText = "FEC.1° LLAM.",
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "EC",
                HeaderText = "X CORREO",
                Width = 80,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "EF",
                HeaderText = "X CORRESP",
                Width = 90,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_CORTA",
                HeaderText = "INSTITUCIÓN",
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_COB",
                HeaderText = "N° PLANILLA",
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES_AÑO",
                HeaderText = "PERIODO",
                Width = 70,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_ENVIO",
                HeaderText = "FEC.ELABOR.",
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_TIPO_PLANILLA",
                HeaderText = "TIPO PLAN.",
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_ENVIO",
                HeaderText = "IMP.PLAN.",
                Width = 70,
                ReadOnly = true
            });
            if (gridView.Name == dgvNoEjecutados.Name || gridView.Name == dgvLista.Name || gridView.Name == dgvDesctoConfirmado.Name)
            {
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IMP_DESCUENTO",
                    HeaderText = "IMP.DESC.",
                    Width = 70
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IMP_LISTADO",
                    HeaderText = "IMP.LIST.",
                    Width = 70
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PORCENTAJE_CASILLERO",
                    HeaderText = "% CASI.",
                    Width = 60
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IMP_CASILLERO",
                    HeaderText = "IMP.CASI.",
                    Width = 70
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "OTROS_DSCTOS",
                    HeaderText = "OTS.DSCT.",
                    Width = 70
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IMP_NETO",
                    HeaderText = "IMP.NETO",
                    Width = 70
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "FEC_RETOR_PLAN",
                    Visible = false
                });

                if (gridView.Name == dgvDesctoConfirmado.Name)
                {
                    _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "IMPORTE_CASILLERO_MAN",
                        Width = 70,
                        Visible = false
                    });
                    _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "IMPORTE_EJECUTADO",
                        Visible = false
                    });
                }
            }

            if (gridView.Name == dgvNoDescontado.Name)
            {
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "IMP_DESCUENTO",
                    HeaderText = "IMP.DESCT."
                });
                _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "OBSERVACION",
                    HeaderText = "MOTIVO",
                    Width = 200
                });
            }
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                HeaderText = "AÑO",
                Width = 50,
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                HeaderText = "MES",
                Width = 50,
                Visible = false,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CANT_CONTRATOS",
                HeaderText = "CONTRA.",
                Width = 70,
                ReadOnly = true
            });
            _ = gridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "T.Transcurrido",
                HeaderText = "TIEMPO",
                Width = 70,
                ReadOnly = true
            });

            AlignmentTextContent(gridView, "IG", DataGridViewContentAlignment.MiddleCenter);
        }

        private void AgregarFilasDataGridView(DataGridView grid, DataTable data)
        {
            if (data != null)
            {
                grid.Rows.Clear();
                if (grid.Name == dgvConfirmEnvio.Name)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        _ = grid.Rows.Add
                            (
                            row["TIPO"],
                            false,
                            row["ID_SEGUIMIENTO"],
                            row["ID_ESTADO"],
                            row["COD_PTO_COB_CONSOLIDADO"],
                            row["COD_INSTITUCION"],
                            row["COD_CANAL_DSCTO"],
                            row["TIPO_PLANILLA"],
                            row["FE_SEGUI_PLAN"],
                            string.IsNullOrEmpty(row["FECHA_LLAMADA"].ToString()) ? "" : Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                            row["EC"],
                            row["EF"],
                            row["DESC_CORTA"],
                            row["NRO_PLANILLA_COB"],
                            row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString(),
                            Convert.ToDateTime(row["FECHA_ENVIO"]).ToShortDateString(),
                            row["DESC_TIPO_PLANILLA"],
                            row["IMP_ENVIO"],
                            row["FE_AÑO"],
                            row["FE_MES"],
                            row["CANT_CONTRATOS"],
                            row["T.Transcurrido"]
                            );
                    }
                }
                else if (grid.Name == dgvLista.Name || grid.Name == dgvNoEjecutados.Name)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        _ = grid.Rows.Add
                            (
                            row["TIPO"],
                            row["ID_SEGUIMIENTO"],
                            row["ID_ESTADO"],
                            row["COD_PTO_COB_CONSOLIDADO"],
                            row["COD_INSTITUCION"],
                            row["COD_CANAL_DSCTO"],
                            row["TIPO_PLANILLA"],
                            row["FE_SEGUI_PLAN"],
                            string.IsNullOrEmpty(row["FECHA_LLAMADA"].ToString()) ? "" : Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                            row["EC"],
                            row["EF"],
                            row["DESC_CORTA"],
                            row["NRO_PLANILLA_COB"],
                            row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString(),
                            Convert.ToDateTime(row["FECHA_ENVIO"]).ToShortDateString(),
                            row["DESC_TIPO_PLANILLA"],
                            row["IMP_ENVIO"],
                            row["IMPORTE_DESCUENTO"],
                            row["IMPORTE_LISTADO"],
                            row["PORCENTAJE_CASILLERO"],
                            row["IMPORTE_CASILLERO"],
                            row["OTROS_DSCTOS"],
                            row["IMPORTE_NETO"],
                            row["FEC_RETOR_PLAN"],
                            row["FE_AÑO"],
                            row["FE_MES"],
                            row["CANT_CONTRATOS"],
                            row["T.Transcurrido"]
                            );
                    }
                }
                else if (grid.Name == dgvDesctoConfirmado.Name)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        _ = grid.Rows.Add
                            (
                            row["TIPO"],
                            row["ID_SEGUIMIENTO"],
                            row["ID_ESTADO"],
                            row["COD_PTO_COB_CONSOLIDADO"],
                            row["COD_INSTITUCION"],
                            row["COD_CANAL_DSCTO"],
                            row["TIPO_PLANILLA"],
                            row["FE_SEGUI_PLAN"],
                            string.IsNullOrEmpty(row["FECHA_LLAMADA"].ToString()) ? "" : Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                            row["EC"],
                            row["EF"],
                            row["DESC_CORTA"],
                            row["NRO_PLANILLA_COB"],
                            row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString(),
                            Convert.ToDateTime(row["FECHA_ENVIO"]).ToShortDateString(),
                            row["DESC_TIPO_PLANILLA"],
                            row["IMP_ENVIO"],
                            row["IMPORTE_DESCUENTO"],
                            row["IMPORTE_LISTADO"],
                            row["PORCENTAJE_CASILLERO"],
                            row["IMPORTE_CASILLERO"],
                            row["OTROS_DSCTOS"],
                            row["IMPORTE_NETO"],
                            row["FEC_RETOR_PLAN"],
                            row["IMPORTE_CASILLERO_MAN"],
                            row["IMPORTE_EJECUTADO"],
                            row["FE_AÑO"],
                            row["FE_MES"],
                            row["CANT_CONTRATOS"],
                            row["T.Transcurrido"]
                            );
                    }
                }
                else if (grid.Name == dgvNoDescontado.Name)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        _ = grid.Rows.Add
                            (
                            row["TIPO"],
                            row["ID_SEGUIMIENTO"],
                            row["ID_ESTADO"],
                            row["COD_PTO_COB_CONSOLIDADO"],
                            row["COD_INSTITUCION"],
                            row["COD_CANAL_DSCTO"],
                            row["TIPO_PLANILLA"],
                            row["FE_SEGUI_PLAN"],
                            string.IsNullOrEmpty(row["FECHA_LLAMADA"].ToString()) ? "" : Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                            row["EC"],
                            row["EF"],
                            row["DESC_CORTA"],
                            row["NRO_PLANILLA_COB"],
                            row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString(),
                            Convert.ToDateTime(row["FECHA_ENVIO"]).ToShortDateString(),
                            row["DESC_TIPO_PLANILLA"],
                            row["IMP_ENVIO"],
                            row["IMPORTE_DESCUENTO"],
                            row["OBSERVACION"],
                            row["FE_AÑO"],
                            row["FE_MES"],
                            row["CANT_CONTRATOS"],
                            row["T.Transcurrido"]
                            );
                    }
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        _ = grid.Rows.Add
                            (
                            row["TIPO"],
                            row["ID_SEGUIMIENTO"],
                            row["ID_ESTADO"],
                            row["COD_PTO_COB_CONSOLIDADO"],
                            row["COD_INSTITUCION"],
                            row["COD_CANAL_DSCTO"],
                            row["TIPO_PLANILLA"],
                            row["FE_SEGUI_PLAN"],
                            string.IsNullOrEmpty(row["FECHA_LLAMADA"].ToString()) ? "" : Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                            row["EC"],
                            row["EF"],
                            row["DESC_CORTA"],
                            row["NRO_PLANILLA_COB"],
                            row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString(),
                            Convert.ToDateTime(row["FECHA_ENVIO"]).ToShortDateString(),
                            row["DESC_TIPO_PLANILLA"],
                            row["IMP_ENVIO"],
                            row["FE_AÑO"],
                            row["FE_MES"],
                            row["CANT_CONTRATOS"],
                            row["T.Transcurrido"]
                            );
                    }
                }
            }
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
                Name = "DESC_TIPO",
                HeaderText = "Programado"
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_PTO_COB",
                HeaderText = "P. Cobranza",
                Width = 120
            });
            _ = dgvLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                HeaderText = "N.Planilla",
                Width = 77
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
                Width = 180,
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
                Width = 240
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

        private void FormatGridViewHistorialLlamadas()
        {
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                Visible = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_LLAMADA_BASE",
                Visible = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_ESTADO",
                Visible = false,
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA",
                Visible = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_LLAMADA",
                Visible = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ETAPA",
                HeaderText = "ETAPA",
                Width = 50
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA_CREACION",
                HeaderText = "F.REGISTRO",
                Width = 140
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_ESTADO",
                HeaderText = "TIPO",
                Width = 110,
                Frozen = false
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FECHA",
                HeaderText = "FECHA",
                Width = 80
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HORA",
                HeaderText = "HORA",
                Width = 55
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NOMBRE_INSTITUCION",
                HeaderText = "NOMBRE.INST.",
                Width = 140
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TELEFONO_INSTITUCION",
                HeaderText = "TLF.INST.",
                Width = 75
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NOMBRE",
                HeaderText = "NOMBRE RECEP.",
                Width = 150
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TELEFONO_RECEPTO",
                HeaderText = "TLF.RECEP.",
                Width = 75
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PROVEEDOR_COURIER",
                HeaderText = "PROV.COURIER",
                Width = 120
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TELEFONO_COURIER",
                HeaderText = "TLF.COURI.",
                Width = 75
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE_DESCUENTO",
                HeaderText = "IMP.DESCTA",
                Width = 75
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OBSERVACION",
                HeaderText = "OBSERVACIÓN",
                Width = 320,
            });
            _ = dgvHistorialLlamadas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO",
                Visible = false
            });

            HeaderTextColumnDataGridView(dgvHistorialLlamadas);
        }

        private void HeaderTextColumnDataGridView(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.HeaderCell.Style.Font = new Font(dataGridView.Font, FontStyle.Bold);
                }
            }
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
                    row["TIPO"].ToString() == TipoProgramadoCorreo ? "X Correo" : "X Corresp.",
                    row["DESC_PTO_COB"].ToString(),
                    row["NRO_PLANILLA"].ToString(),
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

            dgvLlamadas.Columns["DESC_TIPO"].Visible = idEstado == RECEPCIONADA;

            foreach (DataGridViewRow row in dgvLlamadas.Rows)
            {
                if (row.Cells["Day"].Value.ToString() == "0 días")
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            MostrarFormXEstadoSeguimiento();
            BackColorPuntoCobranza();
        }

        private void MostrarFormXEstadoSeguimiento()
        {
            if (tbPrincipal.SelectedIndex == 0)
            {
                if (dgvConfirmEnvio.CurrentCell is null)
                {
                    _ = MessageBox.Show("Seleccione una planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                indexEnvio = dgvConfirmEnvio.CurrentRow.Index;
                string estado = tbPrincipal.SelectedTab.Text;
                DataTable dtPlanilla = ObtenerPlanilla(dgvConfirmEnvio);
                MantenedorEnvioPlanillas seguimiento = new MantenedorEnvioPlanillas(estado, dtPlanilla)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                seguimiento.btnCerrarConfirmar.Click += CerrarConfirmar_Click;
                seguimiento.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                seguimiento.CodPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                _ = seguimiento.ShowDialog();
                ObtenerPlanillasXPuntoCobranza();
                ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                ObtenerHistorialSeguimiento();
            }
            else if (tbPrincipal.SelectedIndex == 1)
            {
                if (dgvConfirmRecep.CurrentCell is null)
                {
                    _ = MessageBox.Show("Seleccione una planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                indexRecepcion = dgvConfirmRecep.CurrentRow.Index;
                string estado = tbPrincipal.SelectedTab.Text;
                DataTable dtPlanilla = ObtenerPlanilla(dgvConfirmRecep);
                MantenedorRecepcionPlanilla seguimiento = new MantenedorRecepcionPlanilla(estado, dtPlanilla)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                seguimiento.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                seguimiento.btnCerrarConfirmar.Click += RecepcionCerrarConfirmar_Click;
                _ = seguimiento.ShowDialog();
                //> ObtenerPlanillasXPuntoCobranza();
                ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                ObtenerHistorialSeguimiento();
            }
            IndexLlamadas();
        }

        private DataTable ObtenerPlanilla(DataGridView grid)
        {
            DataTable dtPlanilla = new DataTable();
            _ = dtPlanilla.Columns.Add("ID_SEGUIMIENTO", typeof(string));
            _ = dtPlanilla.Columns.Add("NRO_PLANILLA_COB", typeof(string));
            _ = dtPlanilla.Columns.Add("COD_PTO_COB_CONSOLIDADO", typeof(string));
            _ = dtPlanilla.Columns.Add("TIPO_PLANILLA", typeof(string));
            _ = dtPlanilla.Columns.Add("FE_AÑO", typeof(string));
            _ = dtPlanilla.Columns.Add("FE_MES", typeof(string));
            _ = dtPlanilla.Columns.Add("COD_INSTITUCION", typeof(string));
            _ = dtPlanilla.Columns.Add("COD_CANAL_DSCTO", typeof(string));

            DataRow row = dtPlanilla.NewRow();
            row["ID_SEGUIMIENTO"] = grid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value;
            row["NRO_PLANILLA_COB"] = grid.CurrentRow.Cells["NRO_PLANILLA_COB"].Value;
            row["COD_PTO_COB_CONSOLIDADO"] = grid.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value;
            row["TIPO_PLANILLA"] = grid.CurrentRow.Cells["TIPO_PLANILLA"].Value;
            row["FE_AÑO"] = grid.CurrentRow.Cells["FE_AÑO"].Value;
            row["FE_MES"] = grid.CurrentRow.Cells["FE_MES"].Value;
            row["COD_INSTITUCION"] = grid.CurrentRow.Cells["COD_INSTITUCION"].Value;
            row["COD_CANAL_DSCTO"] = grid.CurrentRow.Cells["COD_CANAL_DSCTO"].Value;

            dtPlanilla.Rows.Add(row);
            return dtPlanilla;
        }

        public DataTable ObtenerPlanillaRecepcion()
        {
            DataTable dtPlanilla = new DataTable();
            _ = dtPlanilla.Columns.Add("ID_SEGUIMIENTO", typeof(string));
            _ = dtPlanilla.Columns.Add("NRO_PLANILLA_COB", typeof(string));
            _ = dtPlanilla.Columns.Add("COD_PTO_COB_CONSOLIDADO", typeof(string));
            _ = dtPlanilla.Columns.Add("TIPO_PLANILLA", typeof(string));
            _ = dtPlanilla.Columns.Add("FE_AÑO", typeof(string));
            _ = dtPlanilla.Columns.Add("FE_MES", typeof(string));

            if (dgvConfirmRecep.CurrentCell != null)
            {
                DataRow row = dtPlanilla.NewRow();
                row["ID_SEGUIMIENTO"] = dgvConfirmRecep.CurrentRow.Cells["ID_SEGUIMIENTO"].Value;
                row["NRO_PLANILLA_COB"] = dgvConfirmRecep.CurrentRow.Cells["NRO_PLANILLA_COB"].Value;
                row["COD_PTO_COB_CONSOLIDADO"] = dgvConfirmRecep.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value;
                row["TIPO_PLANILLA"] = dgvConfirmRecep.CurrentRow.Cells["TIPO_PLANILLA"].Value;
                row["FE_AÑO"] = dgvConfirmRecep.CurrentRow.Cells["FE_AÑO"].Value;
                row["FE_MES"] = dgvConfirmRecep.CurrentRow.Cells["FE_MES"].Value;

                dtPlanilla.Rows.Add(row);
            }
            return dtPlanilla;
        }

        private void RecepcionCerrarConfirmar_Click(object sender, EventArgs e)
        {
            ListarPuntoCobranza();
            ObtenerPlanillasXPuntoCobranza();
        }

        private void DgvPuntoCobranza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPuntoCobranza.CurrentCell is null)
                return;
            if (e.RowIndex >= 0)
                codPtoCob = dgvPuntoCobranza["COD_PTO_COB", e.RowIndex].Value.ToString();
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                ObtenerPlanillasXPuntoCobranza();
            }
            else if (e.ColumnIndex == 4)
            {
                if (tbPrincipal.SelectedIndex == 0)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 0;
            }
            else if (e.ColumnIndex == 5)
            {
                if (tbPrincipal.SelectedIndex == 1)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 1;
            }
            else if (e.ColumnIndex == 6)
            {
                if (tbPrincipal.SelectedIndex == 2)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 2;
            }
            else if (e.ColumnIndex == 7)
            {
                if (tbPrincipal.SelectedIndex == 3)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 3;
            }
            else if (e.ColumnIndex == 8)
            {
                if (tbPrincipal.SelectedIndex == 4)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 4;
                PintarCeldaDePlanillasEjecutadas();
            }
            else if (e.ColumnIndex == 9)
            {
                if (tbPrincipal.SelectedIndex == 5)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 5;
            }
            else if (e.ColumnIndex == 10)
            {
                if (tbPrincipal.SelectedIndex == 6)
                    ObtenerPlanillasXPuntoCobranza();
                else
                    tbPrincipal.SelectedIndex = 6;
            }

            BackColorPuntoCobranza();
            ObtenerHistorialSeguimiento();
        }

        private void ObtenerPlanillasXPuntoCobranza()
        {
            dgvHistorialLlamadas.Rows.Clear();
            try
            {
                if (dgvPuntoCobranza.CurrentCell != null)
                {
                    string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                    int acces = 0;
                    DataTable dt;
                    switch (tbPrincipal.SelectedIndex)
                    {
                        case 0: //> Envio
                            ListarPlanillas(codPtoCob, DateTime.Now, DateTime.Now, acces);
                            HeaderTextColumnDataGridView(dgvConfirmEnvio);
                            break;
                        case 1: //> Recepcion
                            dt = BLSeguimiento.ListarPlanillasXConfirmRecepcion(codPtoCob, DateTime.Now, DateTime.Now, acces);
                            AgregarFilasDataGridView(dgvConfirmRecep, dt);
                            HeaderTextColumnDataGridView(dgvConfirmRecep);
                            break;
                        case 2: //> Proceso
                            dt = BLSeguimiento.ListarPlanillasXConfirmarProcesamiento(codPtoCob, DateTime.Now, DateTime.Now, acces);
                            AgregarFilasDataGridView(dgvConfirmPro, dt);
                            HeaderTextColumnDataGridView(dgvConfirmPro);
                            break;
                        case 3: //> Lista
                            dt = BLSeguimiento.ListarPlanillasDescontadas(codPtoCob, acces);
                            AgregarFilasDataGridView(dgvLista, dt);
                            HeaderTextColumnDataGridView(dgvLista);
                            break;
                        case 4: //> No Ejecutado
                            dt = BLSeguimiento.ListarPlanillasDescontadasConfirmadas(codPtoCob, acces);
                            AgregarFilasDataGridView(dgvNoEjecutados, dt);
                            HeaderTextColumnDataGridView(dgvNoEjecutados);
                            break;
                        case 5: //> Si Descontado
                            dt = BLSeguimiento.ListarPlanillasEjecutadas(codPtoCob, acces);
                            AgregarFilasDataGridView(dgvDesctoConfirmado, dt);
                            HeaderTextColumnDataGridView(dgvDesctoConfirmado);
                            break;
                        case 6: //> No Descontado
                            dt = BLSeguimiento.ListarPlanillasNoDescontadas(codPtoCob, acces);
                            AgregarFilasDataGridView(dgvNoDescontado, dt);
                            HeaderTextColumnDataGridView(dgvNoDescontado);
                            break;
                    }

                    CurrentCell();
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void CurrentCell()
        {
            Control.ControlCollection control = tbPrincipal.SelectedTab.Controls;
            DataGridView gridView = control.OfType<DataGridView>().First();
            int index = 0;
            if (tbPrincipal.SelectedIndex == 0)
                index = indexEnvio;
            else if (tbPrincipal.SelectedIndex == 1)
                index = indexRecepcion;
            else if (tbPrincipal.SelectedIndex == 2)
                index = indexProceso;
            else if (tbPrincipal.SelectedIndex == 3)
                index = indexLista;

            if (gridView.CurrentCell != null && gridView.Rows.Count > index)
                gridView.CurrentCell = gridView["IG", index];
        }

        private void ObtenerCurrentIndex()
        {
            if (dgvConfirmEnvio.CurrentCell != null)
                indexEnvio = dgvConfirmEnvio.CurrentRow.Index;
            if (dgvConfirmRecep.CurrentCell != null)
                indexRecepcion = dgvConfirmRecep.CurrentRow.Index;
            if (dgvConfirmPro.CurrentCell != null)
                indexProceso = dgvConfirmPro.CurrentRow.Index;
            if (dgvLista.CurrentCell != null)
                indexLista = dgvLista.CurrentRow.Index;
        }

        private void BtnProgramarCall_Click(object sender, EventArgs e)
        {
            if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.SD)
                return;
            try
            {
                ToolStripButton button = sender as ToolStripButton;
                Control.ControlCollection control = tbPrincipal.SelectedTab.Controls;
                DataGridView gridView = control.OfType<DataGridView>().First();
                string nombrePuntoCobranza = "";
                ObtenerCurrentIndex();
                if (dgvPuntoCobranza.CurrentCell != null)
                    nombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                if (Convert.ToInt32(button.Tag) == 2 && dgvLlamadas.CurrentRow != null) //> Resultado Llamada
                {
                    nombrePuntoCobranza = dgvLlamadas.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                    if (Convert.ToDateTime(dgvLlamadas.CurrentRow.Cells["FECHA_LLAMADA"].Value) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                    {
                        int idSeguimiento = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                        int idEstado = ObtenerEstadoXTabPage();
                        string nroPlanilla = dgvLlamadas.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString();
                        string estado = tbPrincipal.SelectedTab.Text;
                        int idOption = Resultado;
                        int idLlamadaBase = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_LLAMADA"].Value);
                        int idPersona = string.IsNullOrEmpty(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value.ToString()) ? 0 : Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_PERSONA"].Value);
                        string tipoLlamada = dgvLlamadas.CurrentRow.Cells["TIPO"].Value.ToString();
                        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
                        ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloRegistrado, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estado, idLlamadaBase, tipoLlamada, idPersona)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        if (idEstado == DESCONTADA_CERRADA)
                        {
                            DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(new SeguimientoPlanillaTo
                            {
                                NRO_PLANILLA = dgvLista.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                                FE_AÑO = dgvLista.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                                FE_MES = dgvLista.CurrentRow.Cells["FE_MES"].Value.ToString(),
                                TIPO_PLANILLA = dgvLista.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString(),
                                COD_PTO_COB_CONSOLIDADO = dgvLista.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].ToString()
                            });
                            llamada.numImpListado.ReadOnly = dt.Rows.Count != 1;
                            llamada.numEnvio.Value = dgvLista.CurrentCell != null ? Convert.ToDecimal(dgvLista.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                            //> llamada.numImporte.Value = dgvConfirmCobrado.CurrentCell != null ? Convert.ToDecimal(dgvConfirmCobrado.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture) : 0;
                            //> llamada.numImpNeto.Value = dgvConfirmCobrado.CurrentCell != null ? Convert.ToDecimal(dgvConfirmCobrado.CurrentRow.Cells["IMP_NETO"].Value, culture) : 0;
                            llamada.ObtenerOtrosDsctos();
                            llamada.btnImporteListado.Tag = 1;
                        }
                        else if (idEstado == NO_EJECUTADO)
                        {
                            llamada.numEnvio.Value = dgvNoEjecutados.CurrentCell != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                            llamada.numImpListado.Value = dgvNoEjecutados.CurrentCell != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_LISTADO"].Value, culture) : 0;
                            //> llamada.ObtenerOtrosDsctos(dgvNoEjecutados.CurrentCell != null ? dgvNoEjecutados.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString() : string.Empty);
                            if (dgvNoEjecutados.CurrentCell != null)
                            {
                                llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvNoEjecutados.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
                                llamada.dtFechaTrans.Checked = true;
                                llamada.dtFechaTrans.Enabled = false;
                                llamada.chkSi.Checked = true;
                                DataTable dt = BLSeguimiento.ObtenerDatosEjecutados(
                                    dgvNoEjecutados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                                    dgvNoEjecutados.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(),
                                    dgvNoDescontado.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString(),
                                    dgvNoDescontado.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString(),
                                    dgvNoEjecutados.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString(),
                                    dgvNoEjecutados.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                                    dgvNoEjecutados.CurrentRow.Cells["FE_MES"].Value.ToString());
                                if (dt != null && dt.Rows.Count > 0)
                                    llamada.numImpEjec.Value = Convert.ToDecimal(dt.Rows[0]["IMP_RECEPCION_CTA_CTE"]);
                            }
                        }
                        _ = llamada.ShowDialog();
                        if (tbPrincipal.SelectedIndex == 1 || tbPrincipal.SelectedIndex == 2 || tbPrincipal.SelectedIndex == 3 || tbPrincipal.SelectedIndex == 4)
                        {
                            ListarPuntoCobranza();
                            ObtenerPlanillasXPuntoCobranza();
                            BackColorPuntoCobranza();
                        }
                        ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                        ObtenerHistorialSeguimiento();
                    }
                    else
                        _ = MessageBox.Show("Esta llamada no fue programada para el día de hoy", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (tbPrincipal.SelectedIndex != 0 && Convert.ToInt32(button.Tag) == 1 && gridView.CurrentCell != null) //> Otros Resultados
                {
                    int idSeguimiento = Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                    int idEstado = ObtenerEstadoXTabPage();
                    string nroPlanilla = gridView.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                    string estado = tbPrincipal.SelectedTab.Text;
                    int idOption = OtrosResultados;
                    int idLlamadaBase = 0;

                    ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloOtrosResultados, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estado, idLlamadaBase, TipoProgramadoOtros)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    _ = llamada.ShowDialog();
                    ObtenerPlanillasXPuntoCobranza();
                    ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                    ObtenerHistorialSeguimiento();
                }
                else if (tbPrincipal.SelectedIndex != 0 && Convert.ToInt32(button.Tag) == 3 && gridView.CurrentCell != null) //> Programar o Reprogramar
                {
                    int idSeguimiento = Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                    int idEstado = ObtenerEstadoXTabPage();
                    string nroPlanilla = gridView.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString();
                    string estado = tbPrincipal.SelectedTab.Text;
                    int idOption = string.IsNullOrEmpty(gridView.CurrentRow.Cells["FECHA_LLAMADA"].Value.ToString()) ? Programado : Reprogramado;
                    int idLlamadaBase = 0;
                    int act = idEstado == PROCESADA || idEstado == DESCONTADA ? 1 : 0;

                    ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloProgramado, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estado, idLlamadaBase)
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    llamada.act = act;
                    _ = llamada.ShowDialog();
                    ObtenerPlanillasXPuntoCobranza();
                    ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                    ObtenerHistorialSeguimiento();
                }
                IndexLlamadas();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerEstadoXTabPage()
        {
            if (tbPrincipal.SelectedIndex == 0) //> Enviado
                return ENVIADA;
            else if (tbPrincipal.SelectedIndex == 1) //> Recepción
                return RECEPCIONADA;
            else if (tbPrincipal.SelectedIndex == 2) //> Proceso
                return PROCESADA;
            else if (tbPrincipal.SelectedIndex == 3) //> Lista
                return DESCONTADA_CERRADA;
            else if (tbPrincipal.SelectedIndex == 4) //> No Ejecutado
                return NO_EJECUTADO;
            return 0;
        }

        private void ObtenerHistorialSeguimiento()
        {
            dgvHistorialLlamadas.Rows.Clear();
            bool act = true;
            if (tbPrincipal.SelectedIndex == 0 && dgvConfirmEnvio.CurrentCell != null) //> Envpío
            {
                int idSeguimiento = string.IsNullOrEmpty(dgvConfirmEnvio.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString()) ? 0 : Convert.ToInt32(dgvConfirmEnvio.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 1 && dgvConfirmRecep.CurrentCell != null) //> Recepción
            {
                int idSeguimiento = Convert.ToInt32(dgvConfirmRecep.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 2 && dgvConfirmPro.CurrentCell != null) //> Proceso
            {
                int idSeguimiento = Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 3 && dgvLista.CurrentCell != null) //> Lista
            {
                int idSeguimiento = Convert.ToInt32(dgvLista.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 4 && dgvNoEjecutados.CurrentCell != null) //> Ejecutado
            {
                int idSeguimiento = Convert.ToInt32(dgvNoEjecutados.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 5 && dgvDesctoConfirmado.CurrentCell != null) //> Si Descontado
            {
                int idSeguimiento = Convert.ToInt32(dgvDesctoConfirmado.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            else if (tbPrincipal.SelectedIndex == 6 && dgvNoDescontado.CurrentCell != null) //> No Descontado
            {
                int idSeguimiento = Convert.ToInt32(dgvNoDescontado.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                MostrarDatos(idSeguimiento);
            }
            MostrarDatosAdicionales();
            void MostrarDatos(int idSeguimiento)
            {
                foreach (DataRow row in BLSeguimiento.ObtenerHistorialSeguimiento(idSeguimiento).Rows)
                {
                    if (act)
                    {
                        idLlamada = Convert.ToInt32(row["ID"]);
                        act = false;
                    }
                    _ = dgvHistorialLlamadas.Rows.Add
                        (
                        row["ID"].ToString(),
                        row["ID_LLAMADA_BASE"].ToString(),
                        row["ID_SEGUIMIENTO"].ToString(),
                        row["ID_ESTADO"].ToString(),
                        row["NRO_PLANILLA"].ToString(),
                        row["TIPO_LLAMADA"].ToString(),
                        row["ETAPA"].ToString(),
                        row["FECHA_CREACION"].ToString(),
                        row["TIPO_ESTADO"].ToString(),
                        Convert.ToDateTime(row["FECHA_LLAMADA"]).ToShortDateString(),
                        row["HORA_LLAMADA"].ToString(),
                        row["NOMBRE_INST"].ToString(),
                        row["TLF_INST"].ToString(),
                        row["NOMBRES"].ToString(),
                        row["TELEFONO"].ToString(),
                        row["PROVEEDOR_COURIER"].ToString(),
                        row["TELEFONO_COURIER"].ToString(),
                        row["IMPORTE_DESCUENTO"].ToString(),
                        row["OBSERVACION"].ToString(),
                        row["TIPO"]
                        );
                }
            }

            foreach (DataGridViewRow row in dgvLlamadas.Rows)
            {
                dgvLlamadas.AutoResizeRow(row.Index, DataGridViewAutoSizeRowMode.AllCells);
            }

            if (dgvHistorialLlamadas.CurrentCell != null && dgvHistorialLlamadas.Rows.Count > indexHistorial)
                dgvHistorialLlamadas.CurrentCell = dgvHistorialLlamadas[6, indexHistorial];
        }

        private void TbPrincipal_Selected(object sender, TabControlEventArgs e)
        {
            ObtenerCurrentIndex();
            ObtenerPlanillasXPuntoCobranza();
            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
            ObtenerHistorialSeguimiento();
            MostrarDatosAdicionales();
            BackColorPuntoCobranza(false);
            IndexLlamadas();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            if (dgvConfirmRecep.CurrentCell is null)
            {
                _ = MessageBox.Show("Seleccione una planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BackEstadoSeguimiento back = new BackEstadoSeguimiento
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            back.EveClick += Back;
            _ = back.ShowDialog();
        }

        private void Back()
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de regresar al estado anterior esta planilla?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                if (tbPrincipal.SelectedIndex == 1)
                {
                    RegresarEstadoAnterior(dgvConfirmRecep, ENVIADA);
                    ListarPuntoCobranza();
                }
            }
        }

        private void RegresarEstadoAnterior(DataGridView grid, int idEstadoAnterior)
        {
            int idSeguimiento = Convert.ToInt32(grid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            int idEstado = Convert.ToInt32(grid.CurrentRow.Cells["ID_ESTADO"].Value);
            _ = BLSeguimiento.RegresarEstadoAnterior(idSeguimiento, idEstado, idEstadoAnterior)
                ? MessageBox.Show("El cambio se a efectuado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ObtenerPlanillasXPuntoCobranza();
        }

        private void TxtCodigoPC_TextChanged(object sender, EventArgs e)
        {
            const string nameColumn = "COD_PTO_COB";
            TextChangedPC(nameColumn, txtCodigoPC.Text.Trim());
        }

        private void TxtDescPC_TextChanged(object sender, EventArgs e)
        {
            const string nameColumn = "DESC_PTO_COB";
            TextChangedPC(nameColumn, txtDescPC.Text);
        }

        private void TextChangedPC(string nameColumn, string text)
        {
            IEnumerable<DataGridViewRow> row = dgvPuntoCobranza.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells[nameColumn].Value.ToString().Contains(text));
            if (row.Any())
                dgvPuntoCobranza.CurrentCell = dgvPuntoCobranza[0, row.Select(f => f.Index).FirstOrDefault()];
        }

        private void DgvConfirmRecep_SelectionChanged(object sender, EventArgs e)
        {
            ObtenerHistorialSeguimiento();
        }

        private void DgvConfirmRecep_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.Rows.Count == 0)
            {
                dgvHistorialLlamadas.Rows.Clear();
            }

            MostrarDatosAdicionales();
        }

        private void DgvConfirmRecep_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView.IsCurrentCellDirty)
            {
                _ = dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvLlamadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLlamadas.CurrentCell != null)
            {
                int estado = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_ESTADO"].Value);
                int idSeguimiento = Convert.ToInt32(dgvLlamadas.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                indexLlamada = idSeguimiento;
                string codPtoCob = dgvLlamadas.CurrentRow.Cells["COD_PTO_COB"].Value.ToString();
                IndexPuntoCobranza();
                if (estado == ENVIADA)
                {
                    if (tbPrincipal.SelectedIndex == 0)
                        ObtenerPlanillasXPuntoCobranza();
                    else
                        tbPrincipal.SelectedIndex = 0;
                    IndexDataGridView(dgvConfirmEnvio);
                }
                else if (estado == RECEPCIONADA)
                {
                    if (tbPrincipal.SelectedIndex == 1)
                        ObtenerPlanillasXPuntoCobranza();
                    else
                        tbPrincipal.SelectedIndex = 1;
                    IndexDataGridView(dgvConfirmRecep);
                }
                else if (estado == PROCESADA)
                {
                    if (tbPrincipal.SelectedIndex == 2)
                        ObtenerPlanillasXPuntoCobranza();
                    else
                        tbPrincipal.SelectedIndex = 2;
                    IndexDataGridView(dgvConfirmPro);
                }
                else if (estado == DESCONTADA_CERRADA)
                {
                    if (tbPrincipal.SelectedIndex == 3)
                        ObtenerPlanillasXPuntoCobranza();
                    else
                        tbPrincipal.SelectedIndex = 3;
                    IndexDataGridView(dgvLista);
                }
                BackColorPuntoCobranza();
                void IndexDataGridView(DataGridView grid)
                {
                    if (grid.Rows.Count > 0)
                    {
                        IEnumerable<DataGridViewRow> row = grid.Rows.Cast<DataGridViewRow>()
                            .Where(x => Convert.ToInt32(x.Cells["ID_SEGUIMIENTO"].Value) == idSeguimiento);
                        if (row.Any())
                        {
                            grid.CurrentCell = grid["NRO_PLANILLA_COB", row.Select(x => x.Index).FirstOrDefault()];
                            ObtenerHistorialSeguimiento();
                        }
                        else
                            _ = MessageBox.Show("No se encontró la planilla asociada a esta llamada en esta etapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        _ = MessageBox.Show("No se encontró la planilla asociada a esta llamada", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                void IndexPuntoCobranza()
                {
                    int index = dgvPuntoCobranza.Rows.Cast<DataGridViewRow>()
                        .Where(x => x.Cells["COD_PTO_COB"].Value.ToString() == codPtoCob)
                        .Select(f => f.Index).FirstOrDefault();
                    if (dgvPuntoCobranza.Rows.Count > 0)
                        dgvPuntoCobranza.CurrentCell = dgvPuntoCobranza[0, index];
                }
            }
        }

        private void IndexLlamadas()
        {
            int index = dgvLlamadas.Rows.Cast<DataGridViewRow>()
                .Where(x => Convert.ToInt32(x.Cells["ID_SEGUIMIENTO"].Value) == indexLlamada)
                .Select(f => f.Index).FirstOrDefault();
            if (dgvLlamadas.Rows.Count > 0)
                dgvLlamadas.CurrentCell = dgvLlamadas["NRO_PLANILLA", index];
        }

        private void CerrarConfirmar_Click(object sender, EventArgs e)
        {
            ListarPuntoCobranza();
        }

        private void DgvHistorialLlamadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorialLlamadas.CurrentCell is null)
                return;
            int idLlamadaBase = Convert.ToInt32(dgvHistorialLlamadas.CurrentRow.Cells["ID_LLAMADA_BASE"].Value);
            int id = Convert.ToInt32(dgvHistorialLlamadas.CurrentRow.Cells["ID"].Value);
            foreach (DataGridViewRow row in dgvHistorialLlamadas.Rows)
            {
                if (dgvHistorialLlamadas.CurrentRow.Cells["TIPO"].Value.ToString() == LlamadaProgramada ||
                   dgvHistorialLlamadas.CurrentRow.Cells["TIPO"].Value.ToString() == LlamadaReprogramada ||
                   dgvHistorialLlamadas.CurrentRow.Cells["TIPO"].Value.ToString() == LlamadaRegistrada)
                {
                    if (idLlamadaBase == Convert.ToInt32(row.Cells["ID"].Value) || id == Convert.ToInt32(row.Cells["ID_LLAMADA_BASE"].Value))
                    {
                        row.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void DgvConfirmEnvio_SelectionChanged(object sender, EventArgs e)
        {
            ObtenerHistorialSeguimiento();
        }

        private void SeguimientoPlanilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BLSeguimiento.ListarLlamadasPendientesPlla().Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Existe llamadas pendientes programadas para el día de hoy. \n" +
                    "¿Esta seguro de que desea salir?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
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
                        IndexLlamadas();
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ObtenerHistorialSeguimiento();
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

        private void BtnCerrarProceso_Click(object sender, EventArgs e)
        {
            if (dgvConfirmPro.CurrentCell != null)
            {
                DataTable dtCorreo = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), EnvioCorreo);
                DataTable dtCorrespondencia = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), EnvioFisico);
                if (dtCorreo != null && dtCorreo.Rows.Count > 0 && dtCorreo.Rows[0]["ENVIO_CORRESP"].ToString() == "SI" && (dtCorrespondencia == null || dtCorrespondencia.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe registrar un envío por correspondencia, ya que lo ha registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtCorrespondencia != null && dtCorrespondencia.Rows.Count > 0 && dtCorrespondencia.Rows[0]["ENVIO_CORRESP"].ToString() == "SI" && (dtCorreo == null || dtCorreo.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe registrar un envío por correo electrónico, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtRecepCorreo = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionCorreo);
                DataTable dtRecepCorrespondencia = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionFisico);
                if (dtCorreo != null && dtCorreo.Rows.Count > 0 && (dtRecepCorreo == null || dtRecepCorreo.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe registrar una recepción por correo electrónico, ya que lo ha registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtCorrespondencia != null && dtCorrespondencia.Rows.Count > 0 && (dtRecepCorrespondencia == null || dtRecepCorrespondencia.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe registrar una recepción por correspondencia, ya que lo ha registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtRecepCorreo != null && dtRecepCorreo.Rows.Count > 0 && (dtCorreo == null || dtCorreo.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe eliminar la recepción por correo electrónico, ya que en alguna etapa se ha eliminado el envío por correo electrónico", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtRecepCorrespondencia != null && dtRecepCorrespondencia.Rows.Count > 0 && (dtCorrespondencia == null || dtCorrespondencia.Rows.Count == 0))
                {
                    _ = MessageBox.Show("Debe eliminar la recepción por correspondencia, ya que en alguna etapa se ha eliminado el envío por correspondencia", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_ESTADO"].Value) == PROCESADA)
                {
                    if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value)).Rows.Count > 0)
                    {
                        _ = MessageBox.Show("Esta planilla tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        DialogResult dr = MessageBox.Show("¿Esta seguro de cerrar la etapa de proceso?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            SeguimientoPlanillaTo se = ObtenerDatosCerrarProceso();
                            _ = BLSeguimiento.InsertarHistorialSeguimiento(se)
                                ? MessageBox.Show("La etapa de proceso se a cerrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un error al cerrar la etapa de proceso", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ListarPuntoCobranza();
                            ObtenerPlanillasXPuntoCobranza();
                            ObtenerHistorialSeguimiento();
                        }
                    }
                    catch (Exception ex)
                    {
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    _ = MessageBox.Show("Aún no se a confirmado que esta planilla se haya procesado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BackColorPuntoCobranza();
            }
        }

        private SeguimientoPlanillaTo ObtenerDatosCerrarProceso()
        {
            return new SeguimientoPlanillaTo
            {
                ID_SEGUIMIENTO = Convert.ToInt32(dgvConfirmPro.CurrentRow.Cells["ID_SEGUIMIENTO"].Value),
                ID_ESTADO = DESCONTADA_CERRADA,
                USUARIO_CREA = COD_USUARIO
            };
        }

        private void BtnActualizarEnvio_Click(object sender, EventArgs e)
        {
            if (ObtenerDataGridView().CurrentRow != null)
            {
                ObtenerCurrentIndex();
                string estado = ObtenerTituloTabPage(ENVIADA);
                DataTable dtPlanilla = ObtenerData();

                MantenedorEnvioPlanillas envio = new MantenedorEnvioPlanillas(estado, dtPlanilla)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                envio.btnCerrarConfirmar.Click += RecepcionCerrarConfirmar_Click;
                envio.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                envio.EnabledButtons(false, ObtenerEstadoXTabPage());
                _ = envio.ShowDialog();
                ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                ObtenerPlanillasXPuntoCobranza();
                ObtenerHistorialSeguimiento();
                IndexLlamadas();
            }
        }

        private void BtnActualizarRecepcion_Click(object sender, EventArgs e)
        {
            if (ObtenerDataGridView().CurrentRow != null)
            {
                ObtenerCurrentIndex();
                string estado = ObtenerTituloTabPage(RECEPCIONADA);
                DataTable dtPlanilla = ObtenerData();
                MantenedorRecepcionPlanilla recepcion = new MantenedorRecepcionPlanilla(estado, dtPlanilla)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                recepcion.EnabledButtons(false);
                recepcion.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                recepcion.btnCerrarConfirmar.Click += RecepcionCerrarConfirmar_Click;
                _ = recepcion.ShowDialog();
                ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                ObtenerPlanillasXPuntoCobranza();
                ObtenerHistorialSeguimiento();
                IndexLlamadas();
            }
        }

        private DataGridView ObtenerDataGridView()
        {
            Control.ControlCollection control = tbPrincipal.SelectedTab.Controls;
            DataGridView gridView = control.OfType<DataGridView>().First();
            return gridView;
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

        private void DgvLlamadas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLlamadas.CurrentRow != null)
            {
                if (dgvLlamadas.CurrentRow.Cells["Day"].Value.ToString() == "0 días")
                {
                    dgvLlamadas.DefaultCellStyle.SelectionForeColor = Color.Blue;
                }
                else
                {
                    dgvLlamadas.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
            }
        }

        private void DgvPuntoCobranza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                e.Handled = true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (dgvDesctoConfirmado.CurrentCell != null)
            {
                DataTable dt = BLSeguimiento.ObtenerSeguimientoPlanillaXIdSeguimiento(Convert.ToInt32(dgvDesctoConfirmado.CurrentRow.Cells["ID_SEGUIMIENTO"].Value));
                if (!string.IsNullOrEmpty(dt.Rows[0]["FEC_RETOR_PLAN"].ToString()))
                {
                    _ = MessageBox.Show("Esta planilla ya fue transferida para su descuento en tesorería, por lo tanto, no se puede retroceder a la etapa anterior",
                        "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dr = MessageBox.Show("¿Esta seguro de que desea regresar esta planilla a la etapa anterior?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    RegresarEstadoAnterior(dgvDesctoConfirmado, DESCONTADA_CERRADA);
                    ListarPuntoCobranza();
                    ObtenerPlanillasXPuntoCobranza();
                    BackColorPuntoCobranza();
                }
            }
        }

        private void BtnBack2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de que desea regresar esta planilla a la etapa anterior?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int idSeguimiento = Convert.ToInt32(dgvNoDescontado.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                int idEstado = Convert.ToInt32(dgvNoDescontado.CurrentRow.Cells["ID_ESTADO"].Value);
                _ = BLSeguimiento.RegresarEstadoAnterior(idSeguimiento, idEstado, DESCONTADA_CERRADA)
                    ? MessageBox.Show("El cambio se a efectuado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListarPuntoCobranza();
                ObtenerPlanillasXPuntoCobranza();
                ObtenerHistorialSeguimiento();
                BackColorPuntoCobranza();
            }
        }

        private void DgvLlamadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int columnIndex = dgvLlamadas.CurrentCell.ColumnIndex;
                int rowIndex = dgvLlamadas.CurrentCell.RowIndex;
                DataGridViewCellEventArgs es = new DataGridViewCellEventArgs(columnIndex, rowIndex);
                DgvLlamadas_CellDoubleClick(sender, es);
            }
        }

        private void DgvConfirmEnvio_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvConfirmEnvio.IsCurrentCellDirty)
                dgvConfirmEnvio.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ListarPuntoCobranza();
            ObtenerPlanillasXPuntoCobranza();
            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
            BackColorPuntoCobranza();
            ObtenerHistorialSeguimiento();
        }

        private void MostrarDatosAdicionales()
        {
            Control.ControlCollection controls = tbPrincipal.SelectedTab.Controls;
            DataGridView gridView = (DataGridView)controls[0];
            ToolStrip toolStrip = controls.OfType<ToolStrip>().First();
            foreach (ToolStripLabel label in toolStrip.Items.OfType<ToolStripLabel>().ToList())
            {
                int tag = Convert.ToInt32(label.Tag);
                switch (tag)
                {
                    case 0:
                        label.Text = "Total Planillas : " + gridView.Rows.Count.ToString();
                        break;
                    case 1:
                        label.Text = "Llamadas Programadas : " + ObtenerCantLlamadasPendientes();
                        break;
                    default:
                        label.Text = "Resultado de Llamadas : " + ObtenerResultadoLlamada();
                        break;
                }
            }

            //> lblTotalCallPend.Text = "Llamadas Pendientes : " + dgvLlamadas.Rows.Count.ToString();

            //int ObtenerCantLlamadas()
            //{
            //    int cant = 0;
            //    foreach (DataGridViewRow row in dgvHistorialLlamadas.Rows)
            //    {
            //        if (row.Cells["TIPO"].Value.ToString() == LlamadaProgramada || row.Cells["TIPO"].Value.ToString() == LlamadaRegistrada)
            //        {
            //            cant++;
            //        }
            //    }
            //    return cant;
            //}

            int ObtenerCantLlamadasPendientes()
            {
                int cant = 0;
                if (gridView.CurrentCell != null)
                {
                    if (!string.IsNullOrEmpty(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToString()))
                    {
                        foreach (DataGridViewRow row in dgvLlamadas.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["ID_SEGUIMIENTO"].Value) == Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value))
                            {
                                cant++;
                            }
                        }
                    }
                }
                return cant;
            }

            int ObtenerResultadoLlamada()
            {
                int cant = 0;
                foreach (DataGridViewRow row in dgvHistorialLlamadas.Rows)
                {
                    if (row.Cells["TIPO"].Value.ToString() == LlamadaRegistrada)
                    {
                        cant++;
                    }
                }
                return cant;
            }
        }

        private void BtnRegistrarEjec_Click(object sender, EventArgs e)
        {
            if (dgvHistorialLlamadas.Rows.Count > 0)
            {
                DataGridViewRow row = dgvHistorialLlamadas.Rows.Cast<DataGridViewRow>()
                      .Where(x => Convert.ToInt32(x.Cells["ID"].Value) == idLlamada).SingleOrDefault();
                if (row != null)
                    dgvHistorialLlamadas.CurrentCell = dgvHistorialLlamadas["ETAPA", row.Index];
                int columnIndex = dgvHistorialLlamadas.CurrentCell.ColumnIndex;
                int rowIndex = dgvHistorialLlamadas.CurrentCell.RowIndex;
                DgvHistorialLlamadas_CellDoubleClick(sender, new DataGridViewCellEventArgs(columnIndex, rowIndex));
            }
        }

        private int idLlamada;
        private void DgvHistorialLlamadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorialLlamadas.Rows.Count > 0)
            {
                try
                {
                    string nombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                    int idOption = 3;
                    int id = Convert.ToInt32(dgvHistorialLlamadas.CurrentRow.Cells["ID"].Value);
                    int idSeguimiento = Convert.ToInt32(dgvHistorialLlamadas.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
                    int idEstado = Convert.ToInt32(dgvHistorialLlamadas.CurrentRow.Cells["ID_ESTADO"].Value);
                    string nroPlanilla = dgvHistorialLlamadas.CurrentRow.Cells["NRO_PLANILLA"].Value.ToString();
                    string tipo = dgvHistorialLlamadas.CurrentRow.Cells["TIPO"].Value.ToString();
                    string tipoLLamada = dgvHistorialLlamadas.CurrentRow.Cells["TIPO_LLAMADA"].Value.ToString();
                    indexHistorial = dgvHistorialLlamadas.CurrentRow.Index;
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
                    if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Envío)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada();
                                break;
                            case RECEPCIONADA:
                                Recepcionada_Procesada(true);
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Recepción)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                                Recepcionada_Procesada();
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Proceso)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                                Recepcionada_Procesada(true);
                                break;
                            case PROCESADA:
                                Recepcionada_Procesada();
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Lista)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                            case PROCESADA:
                            case DESCONTADA:
                                Recepcionada_Procesada(true);
                                break;
                            case DESCONTADA_CERRADA:
                            case NO_EJECUTADO:
                                Recepcionada_Procesada();
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.SD)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                            case PROCESADA:
                            case DESCONTADA:
                            case DESCONTADA_CERRADA:
                            case NO_EJECUTADO:
                                Recepcionada_Procesada();
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Ejecutado)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                            case PROCESADA:
                            case DESCONTADA:
                            case DESCONTADA_CERRADA:
                            case NO_EJECUTADO:
                                Recepcionada_Procesada(true);
                                break;
                        }
                    }
                    else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.ND)
                    {
                        switch (idEstado)
                        {
                            case ENVIADA:
                                Enviada(true);
                                break;
                            case RECEPCIONADA:
                            case PROCESADA:
                            case DESCONTADA:
                            case DESCONTADA_CERRADA:
                            case NO_EJECUTADO:
                                Recepcionada_Procesada(true);
                                break;
                        }
                    }

                    BackColorPuntoCobranza();
                    IndexLlamadas();
                    void Recepcionada_Procesada(bool acces = false)
                    {
                        if (tipo == LlamadaProgramada || tipo == LlamadaRegistrada || tipo == LlamadaReprogramada || tipo == OtrosResultado)
                        {
                            string estadoText = ObtenerTituloTabPage(idEstado);
                            string titulo;
                            if (tipo == LlamadaProgramada)
                                titulo = TituloProgramado;
                            else if (tipo == LlamadaReprogramada)
                                titulo = TituloReprogramar;
                            else if (tipo == LlamadaRegistrada)
                            {
                                idOption = ActualizarResultado;
                                titulo = TituloRegistrado;
                            }
                            else
                                titulo = TituloOtrosResultados;

                            ProgramarLlamada llamada = new ProgramarLlamada(idOption, titulo, idSeguimiento, idEstado, nroPlanilla, nombrePuntoCobranza, estadoText, id, tipoLLamada)
                            {
                                StartPosition = FormStartPosition.CenterScreen
                            };
                            llamada.EnabledButtons(acces);
                            if (idEstado == DESCONTADA || idEstado == DESCONTADA_CERRADA || idEstado == NO_EJECUTADO)
                            {
                                if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Lista)
                                {
                                    llamada.numEnvio.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(dgvLista.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                                    llamada.numImporte.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["IMP_DESCUENTO"].Value?.ToString()) ? 0 : dgvLista.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture) : 0;
                                    llamada.numImpListado.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["IMP_LISTADO"].Value?.ToString()) ? 0 : dgvLista.CurrentRow.Cells["IMP_LISTADO"].Value, culture) : 0;
                                    llamada.label21.Text = dgvLista.CurrentRow.Cells != null ? string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value?.ToString()) ? llamada.label21.Text : "Uso Casillero " + dgvLista.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value.ToString() + "% :" : llamada.label21.Text;
                                    llamada.numImpCasilleroAuto.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["IMP_CASILLERO"].Value?.ToString()) ? 0 : dgvLista.CurrentRow.Cells["IMP_CASILLERO"].Value, culture) : 0;
                                    llamada.numOtrosDescto.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["OTROS_DSCTOS"].Value?.ToString()) ? 0 : dgvLista.CurrentRow.Cells["OTROS_DSCTOS"].Value, culture) : 0;
                                    llamada.numImpNeto.Value = dgvLista.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvLista.CurrentRow.Cells["IMP_NETO"].Value?.ToString()) ? 0 : dgvLista.CurrentRow.Cells["IMP_NETO"].Value, culture) : 0;
                                    llamada.btnImporteListado.Tag = 1;
                                }
                                else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.SD)
                                {
                                    llamada.btnImporteListado.Tag = 2;
                                    llamada.Ejecutado = true;
                                    llamada.numEnvio.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                                    llamada.numImporte.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture) : 0;
                                    llamada.numImpListado.ReadOnly = true;
                                    llamada.numImpListado.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_LISTADO"].Value, culture) : 0;
                                    llamada.label21.Text = dgvNoEjecutados.CurrentRow.Cells != null ? string.IsNullOrEmpty(dgvNoEjecutados.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value?.ToString()) ? llamada.label21.Text : "Uso Casillero " + dgvNoEjecutados.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value.ToString() + "% :" : llamada.label21.Text;
                                    //> llamada.numImpCasilleroAuto.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["IMP_CASILLERO"].Value, culture) : 0;
                                    llamada.ObtenerOtrosDsctos();
                                    llamada.numOtrosDescto.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoEjecutados.CurrentRow.Cells["OTROS_DSCTOS"].Value, culture) : 0;
                                    llamada.numImpNeto.Value = dgvNoEjecutados.CurrentRow.Cells != null ? Convert.ToDecimal(string.IsNullOrEmpty(dgvNoEjecutados.CurrentRow.Cells["IMP_NETO"].Value.ToString()) ? 0 : dgvNoEjecutados.CurrentRow.Cells["IMP_NETO"].Value, culture) : 0;
                                    if (dgvNoEjecutados.CurrentCell != null && !string.IsNullOrEmpty(dgvNoEjecutados.CurrentRow.Cells["FEC_RETOR_PLAN"].Value?.ToString()))
                                    {
                                        llamada.dtFechaTrans.Checked = true;
                                        llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvNoEjecutados.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
                                        llamada.chkSi.Checked = true;
                                        llamada.chkSi.Enabled = false;
                                        llamada.chkNo.Enabled = false;
                                        llamada.chkNoSal.Enabled = false;
                                        llamada.chkOtros.Enabled = false;
                                        llamada.chkNoProcesado.Enabled = false;
                                        DataTable dt = BLSeguimiento.ObtenerDatosEjecutados(
                                            dgvNoEjecutados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["COD_INSTITUCION"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["COD_CANAL_DSCTO"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                                            dgvNoEjecutados.CurrentRow.Cells["FE_MES"].Value.ToString()
                                            );
                                        llamada.dtFechaTrans.Enabled = false;
                                        decimal totalImporteEjecutado = 0;
                                        if (dt != null && dt.Rows.Count > 0 && VerificarDatosEjecutadosXGrupo(ref totalImporteEjecutado))
                                        {
                                            llamada.SiEjecutado = true;
                                            llamada.numImpEjec.Value = totalImporteEjecutado;
                                        }
                                        DataTable dt2 = BLSeguimiento.ObtenerPlanillasXGrupo(new SeguimientoPlanillaTo
                                        {
                                            NRO_PLANILLA = dgvNoEjecutados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                                            FE_AÑO = dgvNoEjecutados.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                                            FE_MES = dgvNoEjecutados.CurrentRow.Cells["FE_MES"].Value.ToString(),
                                            TIPO_PLANILLA = dgvNoEjecutados.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString(),
                                            COD_PTO_COB_CONSOLIDADO = dgvNoEjecutados.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString()
                                        });
                                        llamada.numImpCasilleroAuto.ReadOnly = dt2.Rows.Count != 1;
                                        llamada.numImpCasilleroMan.ReadOnly = dt2.Rows.Count != 1;
                                    }
                                }
                                else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.Ejecutado)
                                {
                                    llamada.numEnvio.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                                    llamada.numImporte.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMP_DESCUENTO"].Value, culture) : 0;
                                    llamada.numImpListado.ReadOnly = true;
                                    llamada.numImpListado.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMP_LISTADO"].Value, culture) : 0;
                                    llamada.label21.Text = dgvDesctoConfirmado.CurrentRow.Cells != null ? string.IsNullOrEmpty(dgvDesctoConfirmado.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value?.ToString()) ? llamada.label21.Text : "Uso Casillero " + dgvDesctoConfirmado.CurrentRow.Cells["PORCENTAJE_CASILLERO"].Value.ToString() + "% :" : llamada.label21.Text;
                                    llamada.numImpCasilleroAuto.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMP_CASILLERO"].Value, culture) : 0;
                                    llamada.numOtrosDescto.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["OTROS_DSCTOS"].Value, culture) : 0;
                                    llamada.numImpNeto.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMP_NETO"].Value, culture) : 0;
                                    llamada.numImpEjec.Value = dgvDesctoConfirmado.CurrentCell != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMPORTE_EJECUTADO"].Value, culture) : 0;
                                    llamada.numImpCasilleroMan.Value = dgvDesctoConfirmado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvDesctoConfirmado.CurrentRow.Cells["IMPORTE_CASILLERO_MAN"].Value, culture) : 0;
                                    if (dgvDesctoConfirmado.CurrentCell != null && !string.IsNullOrEmpty(dgvDesctoConfirmado.CurrentRow.Cells["FEC_RETOR_PLAN"].Value?.ToString()))
                                    {
                                        llamada.dtFechaTrans.Checked = true;
                                        llamada.dtFechaTrans.Value = Convert.ToDateTime(dgvDesctoConfirmado.CurrentRow.Cells["FEC_RETOR_PLAN"].Value);
                                    }
                                    llamada.btnImporteListado.Tag = 3;
                                    llamada.ObtenerOtrosDsctos();
                                }
                                else if (tbPrincipal.SelectedIndex == (int)EtapaSeguiGrid.ND)
                                {
                                    llamada.numEnvio.Value = dgvNoDescontado.CurrentRow.Cells != null ? Convert.ToDecimal(dgvNoDescontado.CurrentRow.Cells["IMP_ENVIO"].Value, culture) : 0;
                                    llamada.chkNoSal.Checked = true;
                                    llamada.numImpListado.ReadOnly = true;
                                    llamada.numImpCasilleroAuto.ReadOnly = true;
                                    llamada.numOtrosDescto.ReadOnly = true;
                                    SeguimientoPlanillaTo se = BLSeguimiento.ObtenerSeguimientoPlanillaTo(Convert.ToInt32(dgvNoDescontado.CurrentRow.Cells["ID_SEGUIMIENTO"].Value));
                                    llamada.chkNoProcesado.Checked = se.ST_NO_PROCESADO;
                                    llamada.txtMotivo.Text = se.ST_NO_PROCESADO_OBS;
                                }
                            }
                            _ = llamada.ShowDialog();
                            if (ObtenerEstadoXTabPage() == DESCONTADA || ObtenerEstadoXTabPage() == DESCONTADA_CERRADA || ObtenerEstadoXTabPage() == NO_EJECUTADO)
                            {
                                ListarPuntoCobranza();
                                ObtenerPlanillasXPuntoCobranza();
                            }
                            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                            ObtenerHistorialSeguimiento();
                        }
                        else if (tipo == RecepcionCorreo || tipo == RecepcionFisico)
                        {
                            string estado = ObtenerTituloTabPage(idEstado);
                            DataTable dtPlanilla = ObtenerData();

                            MantenedorRecepcionPlanilla recepcion = new MantenedorRecepcionPlanilla(estado, dtPlanilla, id)
                            {
                                StartPosition = FormStartPosition.CenterScreen
                            };
                            recepcion.EnabledButtons(acces);
                            recepcion.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                            recepcion.btnCerrarConfirmar.Click += RecepcionCerrarConfirmar_Click;
                            _ = recepcion.ShowDialog();
                            ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                            ObtenerHistorialSeguimiento();
                        }
                    }

                    void Enviada(bool acces = false)
                    {
                        string estado = ObtenerTituloTabPage(idEstado);
                        DataTable dtPlanilla = ObtenerData();

                        MantenedorEnvioPlanillas envio = new MantenedorEnvioPlanillas(estado, dtPlanilla, id)
                        {
                            StartPosition = FormStartPosition.CenterScreen
                        };
                        envio.btnCerrarConfirmar.Click += RecepcionCerrarConfirmar_Click;
                        envio.NombrePuntoCobranza = dgvPuntoCobranza.CurrentRow.Cells["DESC_PTO_COB"].Value.ToString();
                        envio.EnabledButtons(acces, ObtenerEstadoXTabPage());
                        _ = envio.ShowDialog();
                        ListarLlamadasPendientes(ObtenerEstadoXTabPage());
                        ObtenerHistorialSeguimiento();
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataTable ObtenerData()
        {
            switch (tbPrincipal.SelectedIndex)
            {
                case 0: return ObtenerPlanilla(dgvConfirmEnvio);
                case 1: return ObtenerPlanilla(dgvConfirmRecep);
                case 2: return ObtenerPlanilla(dgvConfirmPro);
                case 3: return ObtenerPlanilla(dgvLista);
                case 4: return ObtenerPlanilla(dgvDesctoConfirmado);
                default: return ObtenerPlanilla(dgvNoDescontado);
            }
        }

        private string ObtenerTituloTabPage(int idEstado)
        {
            switch (idEstado)
            {
                case ENVIADA: return tbPrincipal.TabPages[0].Text;
                case RECEPCIONADA: return tbPrincipal.TabPages[1].Text;
                case PROCESADA: return tbPrincipal.TabPages[2].Text;
                case DESCONTADA: return tbPrincipal.TabPages[3].Text;
                case DESCONTADA_CERRADA: return tbPrincipal.TabPages[4].Text;
                default: return string.Empty;
            }
        }

        private void BackColorPuntoCobranza(bool act = true)
        {
            if (dgvPuntoCobranza.Rows.Count == 0)
                return;

            foreach (DataGridViewRow row in dgvPuntoCobranza.Rows)
            {
                if (row.Index != dgvPuntoCobranza.CurrentRow.Index)
                {
                    row.Cells["Envio"].Style.BackColor = Color.White;
                    row.Cells["Recepcion"].Style.BackColor = Color.White;
                    row.Cells["Procesamiento"].Style.BackColor = Color.White;
                    row.Cells["SD"].Style.BackColor = Color.White;
                    row.Cells["NoEjecutado"].Style.BackColor = Color.White;
                    row.Cells["ND"].Style.BackColor = Color.White;
                    row.Cells["CD"].Style.BackColor = Color.White;
                }
            }

            foreach (DataGridViewColumn column in dgvPuntoCobranza.Columns)
            {
                if (act && column.Index != dgvPuntoCobranza.CurrentCell.ColumnIndex)
                    dgvPuntoCobranza[column.Index, dgvPuntoCobranza.CurrentCell.RowIndex].Style.BackColor = Color.White;
                else if (tbPrincipal.SelectedIndex + 4 != column.Index)
                    dgvPuntoCobranza[column.Index, dgvPuntoCobranza.CurrentCell.RowIndex].Style.BackColor = Color.White;
            }

            if (act)
            {
                if (dgvPuntoCobranza.CurrentCell.ColumnIndex == 0 || dgvPuntoCobranza.CurrentCell.ColumnIndex == 1
                    || dgvPuntoCobranza.CurrentCell.ColumnIndex == 2 || dgvPuntoCobranza.CurrentCell.ColumnIndex == 3)
                    dgvPuntoCobranza[tbPrincipal.SelectedIndex + 4, dgvPuntoCobranza.CurrentCell.RowIndex].Style.BackColor = Color.SkyBlue;
                else
                    dgvPuntoCobranza[dgvPuntoCobranza.CurrentCell.ColumnIndex, dgvPuntoCobranza.CurrentCell.RowIndex].Style.BackColor = Color.SkyBlue;
            }
            else
                dgvPuntoCobranza[tbPrincipal.SelectedIndex + 4, dgvPuntoCobranza.CurrentCell.RowIndex].Style.BackColor = Color.SkyBlue;

            dgvPuntoCobranza.CurrentRow.DefaultCellStyle.SelectionBackColor = dgvPuntoCobranza[dgvPuntoCobranza.CurrentCell.ColumnIndex, dgvPuntoCobranza.CurrentRow.Index].Style.BackColor;
            dgvPuntoCobranza.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void BtnRetirarPorPla_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvConfirmEnvio.CurrentCell != null)
                {
                    List<planillaCabeceraTo> lstPlanillas = new List<planillaCabeceraTo>();
                    foreach (DataGridViewRow row in dgvConfirmEnvio.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["CHECK"].Value))
                        {
                            lstPlanillas.Add(new planillaCabeceraTo
                            {
                                FE_AÑO = row.Cells["FE_AÑO"].Value.ToString(),
                                FE_MES = row.Cells["FE_MES"].Value.ToString(),
                                NRO_PLANILLA_COB = row.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                                COD_PTO_COB_CONSOLIDADO = row.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString(),
                                TIPO_PLANILLA = row.Cells["TIPO_PLANILLA"].Value.ToString()
                            });
                        }
                    }

                    if (lstPlanillas.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar estas planillas de transferidos?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            _ = BLSeguimiento.RevertirTransferencia(lstPlanillas)
                                ? MessageBox.Show("Proceso ejecutado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                : MessageBox.Show("Ocurrió un error al ejecutar el proceso", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ListarPuntoCobranza();
                            ObtenerPlanillasXPuntoCobranza();
                            BackColorPuntoCobranza();
                        }
                    }
                    else
                    {
                        MostrarRevertirTransferencia();
                    }
                }
                else
                {
                    MostrarRevertirTransferencia();
                }

                void MostrarRevertirTransferencia()
                {
                    RevertirTransferencia transferencia = new RevertirTransferencia()
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    _ = transferencia.ShowDialog();
                    ListarPuntoCobranza();
                    ObtenerPlanillasXPuntoCobranza();
                    BackColorPuntoCobranza();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarDatosEjecutadosXGrupo(ref decimal totalImporteEjecutado)
        {
            bool act = false;
            SeguimientoPlanillaTo se = new SeguimientoPlanillaTo
            {
                NRO_PLANILLA = dgvNoEjecutados.CurrentRow.Cells["NRO_PLANILLA_COB"].Value.ToString(),
                FE_AÑO = dgvNoEjecutados.CurrentRow.Cells["FE_AÑO"].Value.ToString(),
                FE_MES = dgvNoEjecutados.CurrentRow.Cells["FE_MES"].Value.ToString(),
                TIPO_PLANILLA = dgvNoEjecutados.CurrentRow.Cells["TIPO_PLANILLA"].Value.ToString(),
                COD_PTO_COB_CONSOLIDADO = dgvNoEjecutados.CurrentRow.Cells["COD_PTO_COB_CONSOLIDADO"].Value.ToString()
            };
            DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
            foreach (DataRow row in dt.Rows)
            {
                if (!Convert.ToBoolean(row["APROBAR_RECEPCIONADO"]))
                    continue;
                else
                {
                    act = true;
                    totalImporteEjecutado += Convert.ToDecimal(row["IMPORTE_EJECUTADO"]);
                }
            }
            return act;
        }

        private void DgvPuntoCobranza_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PintarPtosDeCobranzaConPlanillasEjecutas(e);
        }

        private void ObtenerPtoCobranzaConPlanillasEjecutadas()
        {
            dtPtoCobranzaPlanillasEjectadas = BLSeguimiento.ObtenerPtoCobranzaConPlanillasEjecutadas(EmpresaSistema.CodPais);
        }

        /// <summary>
        /// Pinta las celdas de la columna [NoEjecutado] que tienen planillas ya ejecutadas en I_PLANILLAS
        /// </summary>
        /// <param name="e"></param>
        private void PintarPtosDeCobranzaConPlanillasEjecutas(DataGridViewCellFormattingEventArgs e)
        {
            if (dtPtoCobranzaPlanillasEjectadas == null || dtPtoCobranzaPlanillasEjectadas.Rows.Count == 0)
                return;
            DataRow rw;
            if (dgvPuntoCobranza.Columns[e.ColumnIndex].Name == COLUMN_NAME1)
            {
                string codPtoCob = dgvPuntoCobranza[COLUMN_NAME2, e.RowIndex].Value?.ToString();
                rw = dtPtoCobranzaPlanillasEjectadas.AsEnumerable().SingleOrDefault(x => x.Field<string>("COD_PTO_COB") == codPtoCob);
                if (rw != null)
                {
                    dgvPuntoCobranza[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Teal;
                    dgvPuntoCobranza[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Pinta la celda NRO_PLANILLA_COB del dgvNoEjecutados de las planillas ya ejecutadas para poder cerrar esta etapa
        /// </summary>
        private void PintarCeldaDePlanillasEjecutadas()
        {
            string codPtoCob = dgvPuntoCobranza.CurrentRow.Cells[COLUMN_NAME2].Value?.ToString();
            DataTable dt = BLSeguimiento.VerificarPlanillasAprobadoRecepcionado(EmpresaSistema.CodPais, codPtoCob);
            if (dt == null || dt.Rows.Count == 0)
                return;
            DataRow rw;
            foreach (DataGridViewRow row in dgvNoEjecutados.Rows)
            {
                rw = dt.AsEnumerable().SingleOrDefault(x => x.Field<string>("NRO_PLANILLA") == row.Cells[COLUMN_NAME3].Value.ToString() && x.Field<int>("APROBAR_RECEPCIONADO") == ESTA_EJECUTADO);
                if (rw != null)
                {
                    row.Cells[COLUMN_NAME3].Style.BackColor = Color.Teal;
                    row.Cells[COLUMN_NAME3].Style.ForeColor = Color.White;
                }
            }
        }

        private void BtnRetornarEtapa_Click(object sender, EventArgs e)
        {
            if (DataGridViewActual == null)
                return;
            if (!ValidarRetornarEtapa())
                return;
            DialogResult dr = MessageBox.Show("¿Esta seguro de que desea regresar esta planilla a la etapa de proceso?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                FrmConfirmar frmConfirmar = new FrmConfirmar(TIPO_CONFIRMAR.RETORNAR_ETAPA_PROCESO)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                frmConfirmar.EventClick += FrmConfirmar_EventClick;
                frmConfirmar.ShowDialog();
            }
        }

        private void FrmConfirmar_EventClick(object sender, EventArgs e)
        {
            int idSeguimiento = Convert.ToInt32(DataGridViewActual.CurrentRow.Cells["ID_SEGUIMIENTO"].Value);
            int idEstado = Convert.ToInt32(DataGridViewActual.CurrentRow.Cells["ID_ESTADO"].Value);
            _ = BLSeguimiento.RegresarEstadoAnterior(idSeguimiento, idEstado, ETAPA_PROCESO)
                ? MessageBox.Show("El cambio se a efectuado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ListarPuntoCobranza();
            ObtenerPlanillasXPuntoCobranza();
            ObtenerHistorialSeguimiento();
            BackColorPuntoCobranza();
        }

        private bool ValidarRetornarEtapa()
        {
            int idSeguimiento = DataGridViewActual.CurrentRow.Cells["ID_SEGUIMIENTO"].Value.ToInt32();
            if (BLSeguimiento.VerificarSiPlanillaTienePagosRegistrados(idSeguimiento))
            {
                _ = MessageBox.Show("Esta planilla ya tiene cobros registrados(cheques/depositos/Transferencias) en seguimiento cheques", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (BLSeguimiento.VerificarPlanillaTienePagosRegistradosTesoreria(idSeguimiento))
            {
                _ = MessageBox.Show("Esta planilla ya tiene cobros registrados(cheques/depositos/Transferencias) en tesorería", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene el dataGridView del tap page seleccionado
        /// </summary>
        public DataGridView DataGridViewActual
        {
            get
            {
                TabPage tb = tbPrincipal.SelectedTab;
                return tb.Controls.OfType<DataGridView>().FirstOrDefault(); ;
            }
        }
    }
}