using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Presentacion.HELPERS;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class FrmRetornarPlanillasEtapa : Form
    {
        private readonly int idSeguimiento, idEstado;
        public FrmRetornarPlanillasEtapa(int idSeguimiento, int idEstado)
        {
            InitializeComponent();
            this.idEstado = idEstado;
            this.idSeguimiento = idSeguimiento;
        }

        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();

        private void FrmRetornarPlanillasEtapa_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarEtapas();
        }

        private void StartControls()
        {
            cboEtapa.DropDownStyle = ComboBoxStyle.DropDownList; 
        }

        private void CargarEtapas()
        {
            DataTable dt = BLSeguimiento.ListarEtapasPlanillaParaRetroceso(this.idEstado);
            cboEtapa.DataSource = dt;
            cboEtapa.ValueMember = "ID_ESTADO";
            cboEtapa.DisplayMember = "DESC_CORTA";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            FrmConfirmar frmConfirmar = new FrmConfirmar(TIPO_CONFIRMAR.RETORNAR_ETAPA_PROCESO)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frmConfirmar.EventClick += FrmConfirmar_EventClick;
            _ = frmConfirmar.ShowDialog(this);
        }

        private void FrmConfirmar_EventClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de que desea regresar esta planilla a la etapa anterior?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int idEstadoAnterior = cboEtapa.SelectedValue.ToInt32();
                _ = BLSeguimiento.RegresarEstadoAnterior(idSeguimiento, idEstado, idEstadoAnterior)
                    ? MessageBox.Show("El cambio se a efectuado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
