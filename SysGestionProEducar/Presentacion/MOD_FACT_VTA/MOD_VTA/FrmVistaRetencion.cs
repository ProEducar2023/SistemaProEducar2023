using BLL;
using Presentacion.HELPERS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmVistaRetencion : Form
    {
        private readonly ChequeBLL BLCheque;
        private readonly string nroPlanillaEnv, nroPlanilla, entPagChe;
        public FrmVistaRetencion(string nroPlanillaEnv, string nroPlanilla, string entPagChe)
        {
            InitializeComponent();
            BLCheque = new ChequeBLL();
            this.nroPlanillaEnv = nroPlanillaEnv;
            this.nroPlanilla = nroPlanilla;
            this.entPagChe = entPagChe;
        }

        private void FrmVistaRetencion_Load(object sender, EventArgs e)
        {
            StartControls();
            AgregarColumnasDgvRetencion();
            ListarRetencion();
            ColorCabeceraDataGridView();
        }

        private void StartControls()
        {
            dgvRetencion.Style4(false, false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, 
                DataGridViewTriState.False, DataGridViewAutoSizeRowsMode.None, Color.Blue, Color.White, DataGridViewSelectionMode.CellSelect);
        }

        private void AgregarColumnasDgvRetencion()
        {
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TAG",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_SEGUIMIENTO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID_RETENCION",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_COB",
                HeaderText = "N° Documet.",
                Width = 80,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PTO_COB",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_INSTITUCION",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_CANAL_DSCTO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_SUCURSAL",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_CLASE",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_AÑO_REF",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FE_MES_REF",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PERIODO",
                HeaderText = "Período",
                Width = 58,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA_DOC",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_DOCU",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MOTIVO_OTRAS_DEV_DSCTOS",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_LETRA",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_DEV",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_CONTRATO",
                HeaderText = "N° Contrato",
                Width = 80,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "COD_PER",
                HeaderText = "Cod.Per",
                Width = 70,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Visible = false
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DESC_PER",
                HeaderText = "Nombres",
                Width = 190,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TIPO_PLANILLA_DESC",
                HeaderText = "Tipo Planilla",
                Width = 120,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NRO_PLANILLA_DOC",
                HeaderText = "N° Plla.Reten.",
                Width = 95,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMPORTE",
                HeaderText = "Imp.Ini",
                Width = 60,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RETENCION",
                HeaderText = "Imp.Retenido",
                ValueType = typeof(decimal),
                Width = 90,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_RET_OTRA_PLLA",
                HeaderText = "Imp.Ret.otr.Plla",
                ValueType = typeof(decimal),
                Width = 95,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMP_DOC",
                Visible = false,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SALDO",
                HeaderText = "Sald.X.Ret",
                SortMode = DataGridViewColumnSortMode.NotSortable,
                Width = 75,
                ReadOnly = true
            });
            _ = dgvRetencion.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "STATUS_APROBADO",
                HeaderText = "Aprobado",
                Width = 70,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                ReadOnly = true
            });

            dgvRetencion.Columns["IMPORTE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["IMP_RETENCION"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["IMP_RET_OTRA_PLLA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["SALDO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvRetencion.Columns["STATUS_APROBADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ColorCabeceraDataGridView()
        {
            foreach (DataGridViewColumn column in dgvRetencion.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.SkyBlue;
            }
        }

        private void ListarRetencion()
        {
            try
            {
                DataTable dt = BLCheque.ObtenerDatosCierreCobrazaPlla(nroPlanillaEnv, nroPlanilla, entPagChe);
                dgvRetencion.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    int index;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["COD_PER"].ToString()))
                        {
                            index = dgvRetencion.Rows.Add();
                            DataGridViewRow newrow = dgvRetencion.Rows[index];
                            newrow.Cells["TAG"].Value = "*";
                            newrow.Cells["ID_SEGUIMIENTO"].Value = row["ID_SEGUIMIENTO"];
                            newrow.Cells["ID_RETENCION"].Value = row["ID_RENTENCION"];
                            newrow.Cells["TIPO_PLANILLA_DESC"].Value = row["TIPO_PLANILLA_DESC"];
                            newrow.Cells["NRO_PLANILLA_DOC"].Value = row["NRO_PLANILLA_DOC"];
                            newrow.Cells["NRO_PLANILLA_COB"].Value = row["NRO_PLANILLA_COB"];
                            newrow.Cells["COD_CANAL_DSCTO"].Value = row["COD_CANAL_DSCTO"];
                            newrow.Cells["COD_INSTITUCION"].Value = row["COD_INSTITUCION"];
                            newrow.Cells["TIPO_PLANILLA_DOC"].Value = row["TIPO_PLANILLA_DOC"];
                            newrow.Cells["COD_SUCURSAL"].Value = row["COD_SUCURSAL"];
                            newrow.Cells["COD_PTO_COB"].Value = row["COD_PTO_COB"];
                            newrow.Cells["MOTIVO_OTRAS_DEV_DSCTOS"].Value = "";
                            newrow.Cells["NRO_LETRA"].Value = "";
                            newrow.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                            newrow.Cells["FE_MES"].Value = row["FE_MES"];
                            newrow.Cells["NRO_CONTRATO"].Value = row["NRO_CONTRATO"];
                            newrow.Cells["COD_PER"].Value = row["COD_PER"];
                            newrow.Cells["DESC_PER"].Value = row["DESC_PER"];
                            newrow.Cells["IMPORTE"].Value = row["IMP_PLANILLA"];
                            newrow.Cells["IMP_DOC"].Value = row["IMP_PLANILLA"];
                            newrow.Cells["IMP_DEV"].Value = 0.00;
                            newrow.Cells["IMP_RETENCION"].Value = row["IMP_RETENIDO"];
                            newrow.Cells["IMP_RET_OTRA_PLLA"].Value = row["IMP_RET_OTRA_PLLA"];
                            newrow.Cells["PERIODO"].Value = row["FE_MES_REF"].ToString() + " - " + row["FE_AÑO_REF"].ToString();
                            newrow.Cells["SALDO"].Value = Convert.ToDecimal(row["IMP_PLANILLA"]) - Convert.ToDecimal(row["IMP_RETENIDO"]) - Convert.ToDecimal(row["IMP_RET_OTRA_PLLA"]);
                            newrow.Cells["STATUS_APROBADO"].Value = Convert.ToBoolean(row["STATUS_APROBADO"]);
                            newrow.Cells["FE_AÑO_REF"].Value = row["FE_AÑO_REF"];
                            newrow.Cells["FE_MES_REF"].Value = row["FE_MES_REF"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }
    }
}
