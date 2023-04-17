using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using Entidades;
using System.Text;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmCuotaVigenciaDevolucion : Form
    {
        public FrmCuotaVigenciaDevolucion()
        {
            CenterToScreen();
            InitializeComponent();
        }

        private static FrmCuotaVigenciaDevolucion instancia;
        public static FrmCuotaVigenciaDevolucion Instancia()
        {
            if (instancia is null || instancia.IsDisposed)
                instancia = new FrmCuotaVigenciaDevolucion();
            return instancia;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        private CRUD crud;
        private void FrmCuotaVigenciaDevolucion_Load(object sender, EventArgs e)
        {
            StartControls();
            EnaDisbInputControls(false);
            ListarDescuentoCuotaVigencia();
        }

        private void StartControls()
        {
            txtNroCuota.MaxLength = 3;
            btnActualizar.StyleButtonFlat();
            btnEliminar.StyleButtonFlat();
            btnGrabar.StyleButtonFlat();
            btnNuevo.StyleButtonFlat();
            btnCancelar.StyleButtonFlat();
            btnMostrarMensaje.StyleButtonFlat();
            dgvLista.Style1();
        }

        private void EnaDisbInputControls(bool state)
        {
            txtNroCuota.Enabled = state;
            dtFechaVigencia.Enabled = state;
            btnGrabar.Enabled = state;
        }

        private void ListarDescuentoCuotaVigencia()
        {
            DataTable dt = BLComision.ListarDescuentoCuotaVigencia();
            CargarDgvLista(dt);
        }

        private void CargarDgvLista(DataTable dt)
        {
            dgvLista.Rows.Clear();
            if (dgvLista.Columns.Count == 0)
            {
                dgvLista.AddRangeColumnsDataGridView(dt, false);
                AjusteColumnas();
            }
            if (dgvLista.Columns.Count > 0)
                dgvLista.AddRangeRowsDataGridView(dt);
        }

        private void AjusteColumnas()
        {
            RenameColumns();
            WidthColumns();
            InvisibleColumns();
        }

        private void RenameColumns()
        {
            dgvLista.Columns["NRO_CUOTA"].HeaderText = "Nro Cuota";
            dgvLista.Columns["FECHA_INI_VIGENCIA"].HeaderText = "Período Vigencia";
            dgvLista.Columns["FECHA_INI_VIGENCIA"].DefaultCellStyle.Format = "MM/yyyy";
            dgvLista.Columns["FECHA_CREA"].HeaderText = "Fecha Creación";
        }

        private void WidthColumns()
        {
            dgvLista.Columns["NRO_CUOTA"].Width = 80;
            dgvLista.Columns["FECHA_INI_VIGENCIA"].Width = 80;
            dgvLista.Columns["FECHA_CREA"].Width = 120;
        }

        private void InvisibleColumns()
        {
            dgvLista.Columns["ID"].Visible = false;
            dgvLista.Columns["FECHA_FIN_VIGENCIA"].Visible = false;
            dgvLista.Columns["USUARIO_CREA"].Visible = false;
            dgvLista.Columns["USUARIO_MODIFICA"].Visible = false;
            dgvLista.Columns["FECHA_MODIFICA"].Visible = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            crud = CRUD.Insertar;
            EnaDisbInputControls(true);
            Op1();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentCell == null)
                return;
            crud = CRUD.Actualizar;
            EnaDisbInputControls(true);
            Op2();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentCell == null)
                return;

            if (MessageBox.Show("¿Esta seguro de eliminar este registro?", "MESSAGE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DescuentoCuotaVigenciaTo desTo = ObtenerDatosGrabar();
                _ = BLComision.EliminarDescuentoCuotaVigencia(desTo)
                        ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListarDescuentoCuotaVigencia();
            }
        }

        private void Op1()
        {
            txtNroCuota.Clear();
            txtNroCuota.Focus();
            dgvLista.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Op2()
        {
            txtNroCuota.Focus();
            dgvLista.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarGrabar())
                return;

            if (MessageBox.Show("¿Esta seguro de guardar los cambios?", "MESSAGE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DescuentoCuotaVigenciaTo desTo = ObtenerDatosGrabar();
                bool result = false;
                switch (crud)
                {
                    case CRUD.Insertar:
                        result = BLComision.InsertarDescuentoCuotaVigencia(desTo);
                        break;
                    case CRUD.Actualizar:
                        result = BLComision.ActualizarDescuentoCuotaVigencia(desTo);
                        break;
                    default:
                        _ = MessageBox.Show("Esta opción no existe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                _ = result
                    ? MessageBox.Show("Grabado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Error al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListarDescuentoCuotaVigencia();
                EnaDisbInputControls(false);
                Op3();
            }
        }

        private DescuentoCuotaVigenciaTo ObtenerDatosGrabar()
        {
            return new DescuentoCuotaVigenciaTo
            {
                ID = dgvLista.CurrentCell == null ? 0 : dgvLista.CurrentRow.Cells["ID"].Value.ToInt32(),
                NRO_CUOTA = txtNroCuota.Text,
                FECHA_INI_VIGENCIA = dtFechaVigencia.Value,
                FECHA_INI_VIGENCIA_ANT = dgvLista.CurrentCell == null ? DateTime.Now : dgvLista.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime(),
                USUARIO_CREA = UsuarioSistema.Cod_usu,
                USUARIO_MODIFICA = UsuarioSistema.Cod_usu
            };
        }

        private bool ValidarGrabar()
        {
            if (txtNroCuota.Text.Trim().Length == 0)
            {
                _ = MessageBox.Show("Ingrese el número de cuota", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (crud == CRUD.Insertar)
            {
                DescuentoCuotaVigenciaTo to = new DescuentoCuotaVigenciaTo
                {
                    NRO_CUOTA = txtNroCuota.Text,
                    FECHA_INI_VIGENCIA = dtFechaVigencia.Value
                };
                if (BLComision.ValidarExistenciaDescCuotaVigencia(to))
                {
                    _ = MessageBox.Show("Ya existe un registro con la misma fecha de vigencia ingresada", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void DgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentCell != null && dgvLista.Enabled)
            {
                txtNroCuota.Text = dgvLista.CurrentRow.Cells["NRO_CUOTA"].Value.ToString();
                dtFechaVigencia.Value = dgvLista.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime();
            }
        }

        private void TxtNroCuota_Leave(object sender, EventArgs e)
        {
            txtNroCuota.FormatTxtNroCuota();
        }

        private void TxtNroCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNroCuota.FormatTxtNroCuota();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Op3();
        }

        private void Op3()
        {
            btnGrabar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            dgvLista.Enabled = true;
            txtNroCuota.Enabled = false;
            dtFechaVigencia.Enabled = false;
        }

        private void BtnMostrarMensaje_Click(object sender, EventArgs e)
        {
            StringBuilder mensaje = new StringBuilder();
            _ = mensaje.Append("Esta configuración establecerá en SI_NO_DESCONTAR = N si la cantidad de cuotas cobradas es mayor o igual al \n" +
                    "registrado en el campo Nro. Cuota, esto va aplicar a los contratos procesados desde el periodo vigencia.");
            Label lbl1 = new Label
            {
                Text = mensaje.ToString(),
                AutoSize = true
            };
            Form frmMensaje = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Owner = this,
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                Text = "MENSAJES"
            };
            frmMensaje.AutoSize = true;
            frmMensaje.Controls.Add(lbl1);
            _ = frmMensaje.ShowDialog();
        }
    }
}
