using BLL;
using Entidades;
using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Entidades.ConstClass;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmInsertarImporteListado : Form
    {
        private const string IMPORTE_LISTADO = "IMPORTE_LISTADO";
        private const string FECHA_LISTADO = "FECHA_LISTADO";
        private const string ST_LISTADO = "ST_LISTADO";
        private const string ST_NO_PROCESADO = "ST_NO_PROCESADO";
        private readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private readonly SeguimientoPlanillaTo se;
        private readonly DataGridView gridView;
        private readonly int idEstado;
        private readonly string tag;

        public delegate void pasarImporteTotal(DataGridView gridView);
        public event pasarImporteTotal EventPasarTotal;

        public FrmInsertarImporteListado(SeguimientoPlanillaTo se, DataGridView gridView, int idEstado, string tag)
        {
            InitializeComponent();
            this.se = se;
            this.gridView = gridView;
            this.idEstado = idEstado;
            this.tag = tag;
        }

        private void FrmInsertarImporteListado_Load(object sender, EventArgs e)
        {
            FormatDataGridview();
            AddColumns();
            ListarPlanillas();
        }

        private void FormatDataGridview()
        {
            dgvPlanillas.EditMode = DataGridViewEditMode.EditOnKeystroke;
        }

        private void AddColumns()
        {
            bool readOnly = tag != "1";
            var columns = new[]
            {
                new { namColumn = "NRO_PLANILLA_COB", HeaderText = "N° PLANILLA", readOnly = true, visible = true},
                new { namColumn = "COD_INSTITUCION", HeaderText = "COD_INSTITUCION", readOnly = true, visible = false},
                new { namColumn = "COD_CANAL_DSCTO", HeaderText = "COD_CANAL_DSCTO", readOnly = true, visible = false},
                new { namColumn = "TIPO_PLANILLA", HeaderText = "TIPO_PLANILLA", readOnly = true, visible = false},
                new { namColumn = "COD_PTO_COB_CONSOLIDADO", HeaderText = "COD_PTO_COB_CONSOLIDADO", readOnly = true, visible = false},
                new { namColumn = "FE_AÑO", HeaderText = "FE_AÑO", readOnly = true, visible = false},
                new { namColumn = "FE_MES", HeaderText = "FE_MES", readOnly = true, visible = false},
                new { namColumn = "COD_GRUPO", HeaderText = "COD_GRUPO", readOnly = true, visible = false},
                new { namColumn = "CAB_GRUPO", HeaderText = "CAB_GRUPO", readOnly = true, visible = false},
                new { namColumn = "DESC_PTO_COB", HeaderText = "P. COBRANZA", readOnly = true, visible = true},
                new { namColumn = "CASILLERO_PORCENTAJE", HeaderText = "% CASILLERO", readOnly = true, visible = true},
                new { namColumn = "IMPORTE_ENVIADO", HeaderText = "IMPORTE ENVIADO", readOnly = true, visible = true},
                new { namColumn = "IMPORTE_LISTADO", HeaderText = "IMPORTE LISTADO", readOnly = false, visible = true},
                new { namColumn = "IMPORTE_EJECUTADO", HeaderText = "IMPORTE EJECUTADO", readOnly = true, visible = true},
                new { namColumn = "CASILLERO_AUTO", HeaderText = "CASILLERO AUTO", readOnly = true, visible = true},
                new { namColumn = "CASILLERO_MAN", HeaderText = "CASILLERO MAN", readOnly = false, visible = true},
                new { namColumn = "IMPORTE_NETO", HeaderText = "IMPORTE NETO", readOnly = true, visible = true},
                new { namColumn = "FECHA_LISTADO", HeaderText = "FECHA LISTADO", readOnly = false, visible = true},
                new { namColumn = "ST_NO_PROCESADO", HeaderText = "NO PROCESADO", readOnly = readOnly, visible = true},
                new { namColumn = "ST_LISTADO", HeaderText = "LISTADO", readOnly = readOnly, visible = true},
                new { namColumn = "APROBAR_RECEPCIONADO", HeaderText = "", readOnly = true, visible = false}
            };

            foreach (var a in columns)
            {
                if (a.namColumn != "ST_NO_PROCESADO" && a.namColumn != "ST_LISTADO")
                {
                    _ = dgvPlanillas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = a.namColumn,
                        HeaderText = a.HeaderText,
                        ReadOnly = a.readOnly,
                        Visible = a.visible
                    });
                }
                else
                {
                    _ = dgvPlanillas.Columns.Add(new DataGridViewCheckBoxColumn
                    {
                        Name = a.namColumn,
                        HeaderText = a.HeaderText,
                        ReadOnly = a.readOnly,
                        Visible = a.visible
                    });
                }
            }

            AjusteColumnasDecimal(dgvPlanillas, "IMPORTE_ENVIADO", 80);
            AjusteColumnasDecimal(dgvPlanillas, "IMPORTE_LISTADO", 80);
            AjusteColumnasDecimal(dgvPlanillas, "IMPORTE_EJECUTADO", 80);
            AjusteColumnasDecimal(dgvPlanillas, "CASILLERO_MAN", 80);
            AjusteColumnasDecimal(dgvPlanillas, "CASILLERO_AUTO", 80);
            AjusteColumnasDecimal(dgvPlanillas, "IMPORTE_NETO", 80);
            AjusteColumnasTextBox(dgvPlanillas, "DESC_PTO_COB", 200);
            AjusteColumnasTextBox(dgvPlanillas, "CASILLERO_PORCENTAJE", 70);
            AlignmentTextContent(dgvPlanillas, "NRO_PLANILLA_COB", DataGridViewContentAlignment.MiddleCenter);
            AlignmentTextContent(dgvPlanillas, "CASILLERO_PORCENTAJE", DataGridViewContentAlignment.MiddleCenter);
            AjusteColumnasTextBox(dgvPlanillas, "FECHA_LISTADO", 80);
            AlignmentTextContent(dgvPlanillas, "FECHA_LISTADO", DataGridViewContentAlignment.MiddleCenter);
            AjusteColumnasTextBox(dgvPlanillas, "ST_NO_PROCESADO", 85);
            AjusteColumnasTextBox(dgvPlanillas, "ST_LISTADO", 60);

            dgvPlanillas.AlingHeaderTextCenter();
        }

        private void ListarPlanillas()
        {
            DataTable dt = BLSeguimiento.ObtenerPlanillasXGrupo(se);
            int indexrow;
            foreach (DataRow row in dt.Rows)
            {
                indexrow = dgvPlanillas.Rows.Add();
                DataGridViewRow rw = dgvPlanillas.Rows[indexrow];
                rw.Cells["NRO_PLANILLA_COB"].Value = row["NRO_PLANILLA_COB"];
                rw.Cells["COD_INSTITUCION"].Value = row["COD_INSTITUCION"];
                rw.Cells["COD_CANAL_DSCTO"].Value = row["COD_CANAL_DSCTO"];
                rw.Cells["TIPO_PLANILLA"].Value = row["TIPO_PLANILLA"];
                rw.Cells["COD_PTO_COB_CONSOLIDADO"].Value = row["COD_PTO_COB_CONSOLIDADO"];
                rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                rw.Cells["FE_MES"].Value = row["FE_MES"];
                rw.Cells["CAB_GRUPO"].Value = row["CAB_GRUPO"];
                rw.Cells["COD_GRUPO"].Value = row["COD_GRUPO"];
                rw.Cells["IMPORTE_ENVIADO"].Value = row["IMP_ENVIO"];
                rw.Cells["IMPORTE_LISTADO"].Value = row["IMP_LISTADO"];
                rw.Cells["IMPORTE_EJECUTADO"].Value = row["IMPORTE_EJECUTADO"];
                rw.Cells["DESC_PTO_COB"].Value = row["DESC_PTO_COB"];
                rw.Cells["CASILLERO_PORCENTAJE"].Value = row["USO_CASILLERO_PORCENTAJE"];
                rw.Cells["CASILLERO_MAN"].Value = row["IMPORTE_CASILLERO_MAN"];
                rw.Cells["CASILLERO_AUTO"].Value = ObtenerCasilleroAuto
                                                    (
                                                        Convert.ToDecimal(row["USO_CASILLERO_IMPORTE"]),
                                                        Convert.ToDecimal(row["USO_CASILLERO_PORCENTAJE"]),
                                                        Convert.ToDecimal(row["IMPORTE_EJECUTADO"]),
                                                        Convert.ToBoolean(row["APROBAR_RECEPCIONADO"])
                                                    );
                rw.Cells["IMPORTE_NETO"].Value = decimal.Round(Convert.ToDecimal(rw.Cells["IMPORTE_EJECUTADO"].Value) - (Convert.ToDecimal(rw.Cells["CASILLERO_AUTO"].Value) + Convert.ToDecimal(rw.Cells["CASILLERO_MAN"].Value)), 2);
                rw.Cells["FECHA_LISTADO"].Value = string.IsNullOrEmpty(row["FEC_RETOR_PLAN"]?.ToString()) ? "" : Convert.ToDateTime(row["FEC_RETOR_PLAN"]).ToShortDateString();
                rw.Cells["ST_NO_PROCESADO"].Value = !string.IsNullOrEmpty(row["ST_NO_PROCESO"]?.ToString()) && Convert.ToBoolean(row["ST_NO_PROCESO"]);
                rw.Cells["ST_LISTADO"].Value = !string.IsNullOrEmpty(row["ST_LISTADO"]?.ToString()) && Convert.ToBoolean(row["ST_LISTADO"]);
                rw.Cells["APROBAR_RECEPCIONADO"].Value = string.IsNullOrEmpty(row["APROBAR_RECEPCIONADO"].ToString()) ? "0" : row["APROBAR_RECEPCIONADO"].ToString();
            }

            if (gridView != null)
            {
                foreach (DataGridViewRow row in dgvPlanillas.Rows)
                {
                    foreach (DataGridViewRow rw in gridView.Rows)
                    {
                        if (rw.Cells["NRO_PLANILLA_COB"].Value.ToString() == row.Cells["NRO_PLANILLA_COB"].Value.ToString())
                        {
                            row.Cells["IMPORTE_LISTADO"].Value = rw.Cells["IMPORTE_LISTADO"].Value;
                            row.Cells["CASILLERO_MAN"].Value = rw.Cells["CASILLERO_MAN"].Value;
                            row.Cells["FECHA_LISTADO"].Value = rw.Cells["FECHA_LISTADO"].Value;
                            row.Cells["ST_NO_PROCESADO"].Value = rw.Cells["ST_NO_PROCESADO"].Value;
                            row.Cells["ST_LISTADO"].Value = rw.Cells["ST_LISTADO"].Value;
                            break;
                        }
                    }
                }
            }

            MostrarTotal(lblTotalListado, "IMPORTE_LISTADO");
            MostrarTotal(lblTotalEjecutado, "IMPORTE_EJECUTADO");
            MostrarTotal(lblTotalEnviado, "IMPORTE_ENVIADO");
            MostrarTotal(lblTotalCasMan, "CASILLERO_MAN");
            MostrarTotal(lblTotalCasAuto, "CASILLERO_AUTO");
            MostrarTotal(lblTotalNeto, "IMPORTE_NETO");
        }

        private void DgvPlanillas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == IMPORTE_LISTADO)
            {
                if (tag != "1")
                {
                    _ = MessageBox.Show("El importe listado no se puede editar en esta estapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == FECHA_LISTADO)
            {
                if (tag != "1")
                {
                    _ = MessageBox.Show("La fecha listado no se puede editar en esta etapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == "CASILLERO_MAN")
            {
                if (tag != "2")
                {
                    _ = MessageBox.Show("El importe casillero manual no se puede editar en esta etapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void DgvPlanillas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == IMPORTE_LISTADO)
            {
                if (!decimal.TryParse(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value?.ToString(), out decimal _))
                {
                    dgvPlanillas[e.ColumnIndex, e.RowIndex].Value = 0;
                    _ = MessageBox.Show("Debe digitar solo valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MostrarTotal(lblTotalListado, IMPORTE_LISTADO);
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == "CASILLERO_MAN")
            {
                if (!decimal.TryParse(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value?.ToString(), out decimal _))
                {
                    dgvPlanillas[e.ColumnIndex, e.RowIndex].Value = 0;
                    _ = MessageBox.Show("Debe digitar solo valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ObtenerImporteNeto();
                    MostrarTotal(lblTotalCasMan, "CASILLERO_MAN");
                    MostrarTotal(lblTotalNeto, "IMPORTE_NETO");
                }
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == FECHA_LISTADO)
            {
                if (!DateTime.TryParse(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value?.ToString(), out DateTime _))
                {
                    dgvPlanillas[e.ColumnIndex, e.RowIndex].Value = "";
                    _ = MessageBox.Show("Debe digitar una fecha válida", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarAceptar())
            {
                EventPasarTotal(dgvPlanillas);
                Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void MostrarTotal(ToolStripLabel label, string nameColumn)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                total += Convert.ToDecimal(row.Cells[nameColumn].Value);
            }

            label.Text = label.Tag.ToString() + total.ToString("N2");
        }

        private decimal ObtenerCasilleroAuto(decimal importeCasillero, decimal casilleroPorcentaje, decimal importeEjecutado, bool st_aprob_recep)
        {
            //if (importeCasillero > 0)
            //    return decimal.Round(importeCasillero, 2);
            //else if (st_aprob_recep)
            //{
            //    return decimal.Round(importeEjecutado / 100 * casilleroPorcentaje, 2);
            //}
            //return 0;
            if (st_aprob_recep)
                return decimal.Round(importeEjecutado / 100 * casilleroPorcentaje, 2);
            return 0;
        }

        private void ObtenerImporteNeto()
        {
            dgvPlanillas.CurrentRow.Cells["IMPORTE_NETO"].Value = Convert.ToDecimal(dgvPlanillas.CurrentRow.Cells["IMPORTE_EJECUTADO"].Value) - (Convert.ToDecimal(dgvPlanillas.CurrentRow.Cells["CASILLERO_AUTO"].Value) + Convert.ToDecimal(dgvPlanillas.CurrentRow.Cells["CASILLERO_MAN"].Value));
        }

        private void DgvPlanillas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == IMPORTE_LISTADO)
            {
                if (e.Value != null)
                {
                    decimal a = Convert.ToDecimal(e.Value);
                    e.Value = Convert.ToDecimal(a.ToString("N2"));
                }
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == "CASILLERO_MAN")
            {
                if (e.Value != null)
                {
                    decimal a = Convert.ToDecimal(e.Value);
                    e.Value = Convert.ToDecimal(a.ToString("N2"));
                }
            }
        }

        private void DgvPlanillas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            //tb.KeyPress += new KeyPressEventHandler(DataGridViewTextBox_KeyPress);
            //tb.TextChanged += new EventHandler(dgvPlanillas_TextChanged);
            ////> e.Control.TextChanged += new EventHandler(dgvPlanillas_TextChanged);
            //e.Control.KeyPress += new KeyPressEventHandler(DataGridViewTextBox_KeyPress);
        }

        private void DataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //when i press enter,bellow code never run?
            if (dgvPlanillas.Columns[dgvPlanillas.CurrentCell.ColumnIndex].Name == FECHA_LISTADO)
            {
                if (e.KeyChar == (char)Keys.D2)
                {
                    dgvPlanillas.CurrentRow.Cells[FECHA_LISTADO].Value = "hola";
                    dgvPlanillas.EndEdit();
                    dgvPlanillas.BeginEdit(false);
                }
            }
        }

        private void DgvPlanillas_TextChanged(object sender, EventArgs e)
        {
            dgvPlanillas.CurrentRow.Cells[FECHA_LISTADO].Value = "hola";
            dgvPlanillas.EndEdit();
            if (!dgvPlanillas.IsCurrentCellInEditMode)
                dgvPlanillas.BeginEdit(false);
        }

        private void DgvPlanillas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanillas.Columns[e.ColumnIndex].Name == ST_LISTADO)
            {
                if (Convert.ToBoolean(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value))
                {
                    dgvPlanillas[ST_NO_PROCESADO, e.RowIndex].Value = false;
                    dgvPlanillas[IMPORTE_LISTADO, e.RowIndex].ReadOnly = false;
                    dgvPlanillas[FECHA_LISTADO, e.RowIndex].ReadOnly = false;
                }
            }
            else if (dgvPlanillas.Columns[e.ColumnIndex].Name == ST_NO_PROCESADO)
            {
                if (Convert.ToBoolean(dgvPlanillas[e.ColumnIndex, e.RowIndex].Value))
                {
                    dgvPlanillas[ST_LISTADO, e.RowIndex].Value = false;
                    dgvPlanillas[IMPORTE_LISTADO, e.RowIndex].Value = 0;
                    dgvPlanillas[IMPORTE_LISTADO, e.RowIndex].ReadOnly = true;
                    dgvPlanillas[FECHA_LISTADO, e.RowIndex].Value = string.Empty;
                    dgvPlanillas[FECHA_LISTADO, e.RowIndex].ReadOnly = true;
                }
            }
        }

        private void DgvPlanillas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPlanillas.IsCurrentCellDirty)
            {
                _ = dgvPlanillas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private bool ValidarAceptar()
        {
            foreach (DataGridViewRow row in dgvPlanillas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["ST_LISTADO"].Value))
                {
                    if (Convert.ToDecimal(row.Cells["IMPORTE_LISTADO"].Value) == 0)
                    {
                        _ = MessageBox.Show("Ingrese los importes de listado de las planillas que se han recibido el listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (string.IsNullOrEmpty(row.Cells["FECHA_LISTADO"].Value?.ToString()))
                    {
                        _ = MessageBox.Show("Ingrese la fecha de entrega de listado de las planillas que se han recibido el listado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
