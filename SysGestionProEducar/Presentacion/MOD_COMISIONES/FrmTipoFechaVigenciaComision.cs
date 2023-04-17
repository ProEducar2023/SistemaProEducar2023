using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using Entidades;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmTipoFechaVigenciaComision : Form
    {
        public FrmTipoFechaVigenciaComision()
        {
            CenterToScreen();
            InitializeComponent();
        }

        private static FrmTipoFechaVigenciaComision instancia;
        public static FrmTipoFechaVigenciaComision Instancia()
        {
            if (instancia is null || instancia.IsDisposed)
                instancia = new FrmTipoFechaVigenciaComision();
            return instancia;
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        private CRUD crud;
        private void FrmCuotaVigenciaDevolucion_Load(object sender, EventArgs e)
        {
            StartControls();
            EnaDisbInputControls(false);
            CargarTipoFecha();
            ListarTipoFechaVigenciaComision();
        }

        private void StartControls()
        {
            cboTipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            btnActualizar.StyleButtonFlat();
            btnEliminar.StyleButtonFlat();
            btnGrabar.StyleButtonFlat();
            btnNuevo.StyleButtonFlat();
            btnCancelar.StyleButtonFlat();
            dgvLista.Style1();
        }

        private void EnaDisbInputControls(bool state)
        {
            cboTipoFecha.Enabled = state;
            dtFechaVigencia.Enabled = state;
            btnGrabar.Enabled = state;
        }

        private void CargarTipoFecha()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            DataRow row = dt.NewRow();
            row["Id"] = 1;
            row["Descripcion"] = "Fecha Aprobación";

            DataRow row2 = dt.NewRow();
            row2["Id"] = 2;
            row2["Descripcion"] = "Fecha Contrato";

            dt.Rows.Add(row);
            dt.Rows.Add(row2);

            cboTipoFecha.DataSource = dt;
            cboTipoFecha.ValueMember = "Id";
            cboTipoFecha.DisplayMember = "Descripcion";
        }

        private void ListarTipoFechaVigenciaComision()
        {
            DataTable dt = BLComision.ListarTipoFechaVigenciaComision();
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
            dgvLista.Columns["DESC_TIPO_FECHA"].HeaderText = "Tipo Fecha";
            dgvLista.Columns["FECHA_INI_VIGENCIA"].HeaderText = "Fec.Ini. Vigencia";
            dgvLista.Columns["FECHA_FIN_VIGENCIA"].HeaderText = "Fec.Fin. Vigencia";
            dgvLista.Columns["FECHA_CREA"].HeaderText = "Fecha Creación";
        }

        private void WidthColumns()
        {
            dgvLista.Columns["DESC_TIPO_FECHA"].Width = 80;
            dgvLista.Columns["FECHA_INI_VIGENCIA"].Width = 80;
            dgvLista.Columns["FECHA_FIN_VIGENCIA"].Width = 80;
            dgvLista.Columns["FECHA_CREA"].Width = 120;
        }

        private void InvisibleColumns()
        {
            string[] columns = { "ID", "TIPO_FECHA", "USUARIO_CREA", "USUARIO_MODIFICA", "FECHA_MODIFICA", "ESTADO" };
            dgvLista.InvisibleColumna(columns);
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
                TipoVigenciaComision desTo = ObtenerDatosGrabar();
                _ = BLComision.EliminarTipoFechaVigenciaComision(desTo)
                        ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListarTipoFechaVigenciaComision();
            }
        }

        private void Op1()
        {
            dgvLista.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Op2()
        {
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
                TipoVigenciaComision desTo = ObtenerDatosGrabar();
                bool result = false;
                switch (crud)
                {
                    case CRUD.Insertar:
                        result = BLComision.InsertarTipoFechaVigenciaComision(desTo);
                        break;
                    case CRUD.Actualizar:
                        result = BLComision.ActualizarTipoFechaVigenciaComision(desTo);
                        break;
                    default:
                        _ = MessageBox.Show("Esta opción no existe", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                _ = result
                    ? MessageBox.Show("Grabado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Error al grabar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Op3();
                ListarTipoFechaVigenciaComision();
                EnaDisbInputControls(false);
            }
        }

        private TipoVigenciaComision ObtenerDatosGrabar()
        {
            return new TipoVigenciaComision
            {
                ID = dgvLista.CurrentCell == null ? 0 : dgvLista.CurrentRow.Cells["ID"].Value.ToInt32(),
                TIPO_FECHA = cboTipoFecha.SelectedValue.ToInt32(),
                DESC_TIPO_FECHA = cboTipoFecha.Text,
                FECHA_INI_VIGENCIA = dtFechaVigencia.Value,
                FECHA_INI_VIGENCIA_ANT = dgvLista.CurrentCell == null ? DateTime.Now : dgvLista.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime(),
                ESTADO = 1,
                USUARIO_CREA = UsuarioSistema.Cod_usu,
                USUARIO_MODIFICA = UsuarioSistema.Cod_usu
            };
        }

        private bool ValidarGrabar()
        {
            if (crud == CRUD.Insertar)
            {
                if (ValidarFechaVigenciaIni())
                {
                    _ = MessageBox.Show("Ya existe un registro con la misma fecha de vigencia ingresada", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool ValidarFechaVigenciaIni()
        {
            foreach(DataGridViewRow row in dgvLista.Rows)
            {
                if (row.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime() == dtFechaVigencia.Value)
                    return true;
            }
            return false;
        }

        private void DgvLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLista.CurrentCell != null && dgvLista.Enabled)
            {
                cboTipoFecha.SelectedValue = dgvLista.CurrentRow.Cells["TIPO_FECHA"].Value.ToString();
                dtFechaVigencia.Value = dgvLista.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime();
            }
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
            cboTipoFecha.Enabled = false;
            dtFechaVigencia.Enabled = false;
        }
    }
}
