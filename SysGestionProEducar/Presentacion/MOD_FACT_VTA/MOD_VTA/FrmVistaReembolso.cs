using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.ErrorPrint;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmVistaReembolso : Form
    {
        private readonly ChequeBLL BLCheque;

        private readonly int idSeguimiento;

        public FrmVistaReembolso(int idSeguimiento)
        {
            InitializeComponent();
            BLCheque = new ChequeBLL();
            this.idSeguimiento = idSeguimiento;
        }

        private void FrmListadoReembolso_Load(object sender, EventArgs e)
        {
            StartControls();
            AddColumnsReembolso();
            ListarReembolsos();
            ColorCabeceraDataGridView();
        }

        private void StartControls()
        {
            dgvReembolso.Style4(false, false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.False, DataGridViewAutoSizeRowsMode.None, Color.Blue, Color.White, DataGridViewSelectionMode.FullRowSelect);
        }

        private void AddColumnsReembolso()
        {
            var columns = new[]
            {
                new { name = "TAG", headerText = "TAG", readOnly = true },
                new { name = "#", headerText = "#", readOnly = true },
                new { name = "NRO_PLANILLA_DOC", headerText = "N° Plla Reembolso", readOnly = true },
                new { name = "FE_AÑO", headerText = "FE_AÑO", readOnly = true },
                new { name = "FE_MES", headerText = "FE_MES", readOnly = true },
                new { name = "PERIODO", headerText = "Período", readOnly = true },
                new { name = "IMPORTE", headerText = "Importe" , readOnly = false },
                //> new { name = "FECHA_PLANILLA_DOC", headerText = "Fecha Planilla", readOly = false },
                new { name = "STATUS_APROBADO", headerText = "Aprobado" , readOnly = true }
            };

            foreach (var item in columns)
            {
                if (item.name == "STATUS_APROBADO")
                {
                    dgvReembolso.Columns.Add(new DataGridViewCheckBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        ReadOnly = item.readOnly
                    });
                }
                else
                {
                    dgvReembolso.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = item.name,
                        HeaderText = item.headerText,
                        ReadOnly = item.readOnly
                    });
                }
            }

            dgvReembolso.AlingHeaderTextCenter();
            AlignmentTextContent(dgvReembolso, "#", DataGridViewContentAlignment.MiddleCenter);

            AjusteColumnasDecimal(dgvReembolso, "IMPORTE", 100);
            AjusteColumnasTextBox(dgvReembolso, "#", 30);

            //> AjustecolumnasFecha(dgvReembolsos, "FECHA_PLANILLA_DOC", 70);

            InvisibleColumna(dgvReembolso, "TAG");
            InvisibleColumna(dgvReembolso, "FE_AÑO");
            InvisibleColumna(dgvReembolso, "FE_MES");
        }

        private void ColorCabeceraDataGridView()
        {
            foreach (DataGridViewColumn column in dgvReembolso.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.SkyBlue;
            }
        }

        private void ListarReembolsos()
        {
            try
            {
                DataTable dt = BLCheque.ObtenerReembolsosXIdSeguimiento(idSeguimiento);
                int indexRow;
                dgvReembolso.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    indexRow = dgvReembolso.Rows.Add();
                    DataGridViewRow rw = dgvReembolso.Rows[indexRow];
                    rw.Cells["TAG"].Value = "-";
                    rw.Cells["#"].Value = ++indexRow;
                    rw.Cells["NRO_PLANILLA_DOC"].Value = row["NRO_PLANILLA_DOC"];
                    rw.Cells["FE_AÑO"].Value = row["FE_AÑO"];
                    rw.Cells["FE_MES"].Value = row["FE_MES"];
                    rw.Cells["PERIODO"].Value = row["FE_MES"].ToString() + " - " + row["FE_AÑO"].ToString();
                    rw.Cells["IMPORTE"].Value = row["IMPORTE_REEMBOLSO"];
                    rw.Cells["STATUS_APROBADO"].Value = Convert.ToDecimal(row["STATUS_CIERRE"]);
                }
            }
            catch (Exception ex)
            {
                PrintStackTrace(ex);
            }
        }
    }
}
