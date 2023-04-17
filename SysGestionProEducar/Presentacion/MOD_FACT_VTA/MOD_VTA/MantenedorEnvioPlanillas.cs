using BLL;
using Entidades;
using SysSeguimiento;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using static Entidades.ConstClass;
using System.Collections.Generic;
using static Presentacion.HELPERS.GenericMethod;

namespace Presentacion.MOD_FACT_VTA.MOD_VTA
{
    public partial class MantenedorEnvioPlanillas : Form
    {
        private readonly string estado;
        private readonly DataTable dtPlanilla;
        private readonly int idEnvio;
        public string NombrePuntoCobranza { get; set; }
        public string CodPtoCob { get; set; }

        public MantenedorEnvioPlanillas(string estado, DataTable dtPlanilla, int idEnvio = 0)
        {
            InitializeComponent();
            KeyDown += NextControl;
            this.dtPlanilla = dtPlanilla;
            this.estado = estado;
            this.idEnvio = idEnvio;
        }

        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();
        private readonly personaMaestroBLL BLMaestroPersona = new personaMaestroBLL();
        private readonly personaDireccionBLL BLDireccionPersona = new personaDireccionBLL();
        private readonly personaFonoBLL BLPersonaFono = new personaFonoBLL();

        private CRUD crudCorreo, crudFisico;
        private int access;
        private DataTable dtReceptorExistente;
        private List<personaMaestroTo> lstPersonaCatPllas;

        private void MantenedorEnvioPlanillas_Load(object sender, EventArgs e)
        {
            StartControls();
            ListarEnviosRegistrados();
            CargarReceptor();
            CargarPersonalPlla();
            CurrentCellXId();
        }

        private void StartControls()
        {
            lblNroPlanilla.Text += dtPlanilla.Rows[0]["NRO_PLANILLA_COB"].ToString();
            lblEstado.Text += estado;
            txtTelefono.MaxLength = 12;
            txtTelefono2.MaxLength = 12;
            txtTlfCourier.MaxLength = 12;
            txtTlfInst.MaxLength = 12;
            txtTlfInst2.MaxLength = 12;
            txtTlfRemitente.MaxLength = 12;

            lblEstadoRegistrar.Text += BLSeguimiento.ObtenerEstadoSeguimientoXId(ENVIADA).Rows[0]["DESC_ESTADO"].ToString();

            dgvEnvios.MultiSelect = false;
            dgvEnvios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnvios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEnvios2.MultiSelect = false;
            dgvEnvios2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnvios2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            crudCorreo = CRUD.None;
            crudFisico = CRUD.None;
            if (access == 0)
            {
                EnabledControls(1, false);
                EnabledControls(2, false);
            }

            Text += " | Punto Cobranza : " + string.Concat(CodPtoCob, " - ", NombrePuntoCobranza);

            ComboboxFormat(cboReceptor1);
            ComboboxFormat(cboReceptor2);
            ComboboxFormat(cboRemitente);
            ComboboxFormat(cboCourierTrans);
        }

        private void NextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void ComboboxFormat(ComboBox cbo)
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DropDownWidth = 250;
        }

        private void CurrentCellXId()
        {
            if (dgvEnvios.Rows.Count > 0)
            {
                int index = dgvEnvios.Rows.Cast<DataGridViewRow>()
                    .Where(x => Convert.ToInt32(x.Cells["ID_ENVIO"].Value) == idEnvio)
                    .Select(f => f.Index).FirstOrDefault();
                dgvEnvios.CurrentCell = dgvEnvios[5, index];
            }

            if (dgvEnvios2.Rows.Count > 0)
            {
                int index = dgvEnvios2.Rows.Cast<DataGridViewRow>()
                    .Where(x => Convert.ToInt32(x.Cells["ID_ENVIO"].Value) == idEnvio)
                    .Select(f => f.Index).FirstOrDefault();
                dgvEnvios2.CurrentCell = dgvEnvios2[5, index];
            }

            DgvEnvios_SelectionChanged(new object(), new EventArgs());
        }

        private void BtnGrabarSeguimiento_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            CRUD crud = button.Name == btnGrabarSeguimiento1.Name ? crudCorreo : crudFisico;
            if (crud == CRUD.None)
                return;
            if (button.Name == btnGrabarSeguimiento1.Name && crud == CRUD.Actualizar && rdbNo.Checked)
            {
                if (dgvEnvios2.Rows.Count > 0)
                {
                    _ = MessageBox.Show("No se puede guardar el envío por correspondencia en estado NO, ya que tiene envío de correspondencia registrados. \n " +
                        "Si desea grabar primero elimine dicho envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (button.Name == btnGrabar2.Name && crud == CRUD.Actualizar && rdbNo2.Checked)
            {
                if (dgvEnvios.Rows.Count > 0)
                {
                    _ = MessageBox.Show("No se puede guardar el envío por correo electrónico en estado NO, ya que tiene envío de correo electrónico registrados. \n " +
                        "Si desea grabar primero elimine dicho envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (dgvEnvios.CurrentCell != null || dgvEnvios2.CurrentCell != null)
            {
                DataGridView gridView = dgvEnvios.CurrentCell == null ? dgvEnvios2 : dgvEnvios;
                DataTable dtRecepCorreo = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionCorreo);
                DataTable dtRecepCorrespondencia = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionFisico);
                if (dtRecepCorreo != null && dtRecepCorreo.Rows.Count > 0 && !rdbSi2.Checked)
                {
                    _ = MessageBox.Show("No puede guardar el envío por correo electrónico en estado NO, ya que tiene registrado recepción por correo electrónico. \n" +
                        "Si desea proceder con dicho cambio, primero elimine la recepción por correo electrónico", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtRecepCorrespondencia != null && dtRecepCorrespondencia.Rows.Count > 0 && !rdbSi.Checked)
                {
                    _ = MessageBox.Show("No puede guardar el envío por correspondencia en estado NO, ya que tiene registrado recepción por correspondencia. \n" +
                        "Si desea proceder con dicho cambio, primero elimine la recepción por correspondencia", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (ValidarGrabar(button))
            {
                DialogResult dr = MessageBox.Show("¿Esta seguro de que desea guardar los cambios?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string _a = crud == CRUD.Insertar ? "Registrado " : "Actualizado ";
                        SeguimientoPlanillaTo se = ObtenerDatosGrabar(button);
                        _ = BLSeguimiento.GrabarSeguimientoPlanillaFase1(ref se, crud)
                            ? MessageBox.Show(_a + "Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        crudCorreo = button.Name == btnGrabarSeguimiento1.Name ? CRUD.None : crudCorreo;
                        crudFisico = button.Name != btnGrabarSeguimiento1.Name ? CRUD.None : crudFisico;
                        ListarEnviosRegistrados(se.ID_SEGUIMIENTO);
                        BtnCancelar_Click(sender, e);
                        DgvEnvios_SelectionChanged(sender, e);
                    }
                    catch (Exception ex)
                    {
                        crudCorreo = button.Name == btnGrabarSeguimiento1.Name ? CRUD.None : crudCorreo;
                        crudFisico = button.Name != btnGrabarSeguimiento1.Name ? CRUD.None : crudFisico;
                        _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private SeguimientoPlanillaTo ObtenerDatosGrabar(ToolStripButton button)
        {
            DataGridView dataGrid = button.Name == btnGrabarSeguimiento1.Name ? dgvEnvios : dgvEnvios2;
            return new SeguimientoPlanillaTo()
            {
                ID_SEGUIMIENTO = crudCorreo == CRUD.Actualizar || crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value) : 0,
                ID_ESTADO = ENVIADA, //> Planilla Enviada
                NRO_PLANILLA = dtPlanilla.Rows[0]["NRO_PLANILLA_COB"].ToString(),
                TIPO_PLANILLA = dtPlanilla.Rows[0]["TIPO_PLANILLA"].ToString(),
                FE_AÑO = dtPlanilla.Rows[0]["FE_AÑO"].ToString(),
                FE_MES = dtPlanilla.Rows[0]["FE_MES"].ToString(),
                COD_PTO_COB_CONSOLIDADO = dtPlanilla.Rows[0]["COD_PTO_COB_CONSOLIDADO"].ToString(),
                COD_INSTITUCION = dtPlanilla.Rows[0]["COD_INSTITUCION"].ToString(),
                COD_CANAL_DSCTO = dtPlanilla.Rows[0]["COD_CANAL_DSCTO"].ToString(),
                OBSERVACION = button.Name == btnGrabarSeguimiento1.Name ? txtObservacion.Text : txtObservacion2.Text,
                USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO,
                USUARIO_MODIFICA = SeguimientoPlanilla.COD_USUARIO,
                PersonaEnvio = new PersonaEnvioTo
                {
                    ID_PERSONA = crudCorreo == CRUD.Actualizar || crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_PERSONA"].Value) : 0,
                    CORREO = button.Name == btnGrabarSeguimiento1.Name ? txtCorreo.Text : txtCorreo2.Text,
                    NOMBRE = button.Name == btnGrabarSeguimiento1.Name ? txtNombre.Text : txtNombre2.Text,
                    APELLIDO = string.Empty,
                    TELEFONO = button.Name == btnGrabarSeguimiento1.Name ? txtTelefono.Text : txtTelefono2.Text,
                    AREA_LABOR = button.Name == btnGrabarSeguimiento1.Name ? txtAreaLabor.Text : txtAreaLabor2.Text,
                    PROVEEDOR_COURIER = button.Name != btnGrabarSeguimiento1.Name ? txtProveedor.Text : null,
                    TELEFONO_COURIER = button.Name != btnGrabarSeguimiento1.Name ? txtTlfCourier.Text : null,
                    DIRECCION_COURIER = button.Name != btnGrabarSeguimiento1.Name ? txtDireccion.Text : null
                },
                EmisorTo = button.Name == btnGrabarSeguimiento1.Name ? null : new PersonaEnvioTo
                {
                    ID_PERSONA = crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_REMITENTE"].Value) : 0,
                    NOMBRE = txtNombreRemitente.Text,
                    APELLIDO = string.Empty,
                    TELEFONO = txtTlfRemitente.Text,
                    AREA_LABOR = txtAreaLRemitente.Text
                },
                EnvioPlanilla = new EnvioPlanillaTo
                {
                    ID_ENVIO = crudCorreo == CRUD.Actualizar || crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_ENVIO"].Value) : 0,
                    DOC_ENVIO = button.Name != btnGrabarSeguimiento1.Name ? txtComprobante.Text : null,
                    FECHA_ENVIO = button.Name == btnGrabarSeguimiento1.Name ? dtFechaEnvio.Value : dtFechaEnvio2.Value,
                    HORA_ENVIO = button.Name == btnGrabarSeguimiento1.Name ? dtHoraEnvio.Value.ToString("HH:mm:ss") : dtHoraEnvio2.Value.ToString("HH:mm:ss"),
                    TIPO_ENVIO = button.Name == btnGrabarSeguimiento1.Name ? "EC" : "EF",
                    NOMBRE_INST = button.Name == btnGrabarSeguimiento1.Name ? txtNombreInst.Text.Trim() : txtNombreInst2.Text.Trim(),
                    TLF_INST = button.Name == btnGrabarSeguimiento1.Name ? txtTlfInst.Text.Trim() : txtTlfInst2.Text.Trim(),
                    ENVIO_CORRESP = button.Name == btnGrabarSeguimiento1.Name ? (rdbSi.Checked ? rdbSi.Text : rdbNo.Text) : (rdbSi2.Checked ? rdbSi2.Text : rdbNo2.Text)
                }
            };
        }

        private bool ValidarGrabar(ToolStripButton button)
        {
            if (button.Name == btnGrabarSeguimiento1.Name)
            {
                if (string.IsNullOrEmpty(txtCorreo.Text))
                {
                    _ = MessageBox.Show("Digite el correo del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtCorreo.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    _ = MessageBox.Show("Digite el nombre del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNombre.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    _ = MessageBox.Show("Digite el teléfono del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtTelefono.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAreaLabor.Text))
                {
                    _ = MessageBox.Show("Digite el área laboral del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtAreaLabor.Focus();
                    return false;
                }
                else if (!rdbSi.Checked && !rdbNo.Checked)
                {
                    _ = MessageBox.Show("Seleccione si se va realizar el envío por correspondencia", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtCorreo2.Text))
                {
                    _ = MessageBox.Show("Digite el correo del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtCorreo2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNombre2.Text))
                {
                    _ = MessageBox.Show("Digite el nombre del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNombre2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTelefono2.Text))
                {
                    _ = MessageBox.Show("Digite el teléfono del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtTelefono2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAreaLabor2.Text))
                {
                    _ = MessageBox.Show("Digite el área laboral del receptor", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtAreaLabor2.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtComprobante.Text))
                {
                    _ = MessageBox.Show("Digite el comprobante de pago", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtComprobante.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtNombreRemitente.Text))
                {
                    _ = MessageBox.Show("Digite el nombre del remitente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtNombreRemitente.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTlfRemitente.Text))
                {
                    _ = MessageBox.Show("Digite el teléfono del remitente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtTlfRemitente.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtAreaLRemitente.Text))
                {
                    _ = MessageBox.Show("Digite el área laboral del remitente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtAreaLRemitente.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtProveedor.Text))
                {
                    _ = MessageBox.Show("Digite el proveedor courier", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtProveedor.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtTlfCourier.Text))
                {
                    _ = MessageBox.Show("Digite el teléfono del courier", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtTlfCourier.Focus();
                    return false;
                }
                else if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    _ = MessageBox.Show("Digite la dirección del courier", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtDireccion.Focus();
                    return false;
                }
                else if (!rdbSi2.Checked && !rdbNo2.Checked)
                {
                    _ = MessageBox.Show("Seleccione si se va realizar el envío por correo electrónico", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void ListarEnviosRegistrados(int id_seguimento = 0)
        {
            int idSeguimiento = string.IsNullOrEmpty(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"].ToString()) ? id_seguimento : int.Parse(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"].ToString());
            dgvEnvios.DataSource = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(idSeguimiento, EnvioCorreo);

            foreach (DataGridViewColumn column in dgvEnvios.Columns)
            {
                if (column.Name != "FECHA_ENVIO")
                {
                    column.Visible = false;
                }
            }

            dgvEnvios2.DataSource = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(idSeguimiento, EnvioFisico);

            foreach (DataGridViewColumn column in dgvEnvios2.Columns)
            {
                if (column.Name != "FECHA_ENVIO")
                {
                    column.Visible = false;
                }
            }
            dgvEnvios.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            dgvEnvios2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            if (dgvEnvios.Rows.Count > 0)
                dgvEnvios.CurrentCell = dgvEnvios[5, 0];

            if (dgvEnvios2.Rows.Count > 0)
                dgvEnvios2.CurrentCell = dgvEnvios2[5, 0];
        }

        private void DgvEnvios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEnvios.CurrentCell != null && crudCorreo != CRUD.Insertar && crudCorreo != CRUD.Actualizar)
            {
                dtFechaEnvio.Value = Convert.ToDateTime(dgvEnvios.CurrentRow.Cells["FECHA_ENVIO"].Value);
                dtHoraEnvio.Value = Convert.ToDateTime("2000-1-1 " + dgvEnvios.CurrentRow.Cells["HORA_ENVIO"].Value);
                txtCorreo.Text = dgvEnvios.CurrentRow.Cells["CORREO"].Value.ToString();
                txtNombre.Text = dgvEnvios.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtTelefono.Text = dgvEnvios.CurrentRow.Cells["TELEFONO"].Value.ToString();
                txtAreaLabor.Text = dgvEnvios.CurrentRow.Cells["AREA_LABOR"].Value.ToString();
                txtObservacion.Text = dgvEnvios.CurrentRow.Cells["OBSERVACION"].Value.ToString();
                txtNombreInst.Text = dgvEnvios.CurrentRow.Cells["NOMBRE_INST"].Value.ToString();
                txtTlfInst.Text = dgvEnvios.CurrentRow.Cells["TLF_INST"].Value.ToString();
                rdbSi.Checked = dgvEnvios.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi.Text;
                rdbNo.Checked = dgvEnvios.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbNo.Text;
                toolStrip2.Enabled = access != 3 && rdbSi.Checked;
            }

            if (dgvEnvios2.CurrentCell != null && crudFisico != CRUD.Insertar && crudFisico != CRUD.Actualizar)
            {
                dtFechaEnvio2.Value = Convert.ToDateTime(dgvEnvios2.CurrentRow.Cells["FECHA_ENVIO"].Value);
                dtHoraEnvio2.Value = Convert.ToDateTime("2000-1-1 " + dgvEnvios2.CurrentRow.Cells["HORA_ENVIO"].Value);
                txtComprobante.Text = dgvEnvios2.CurrentRow.Cells["DOC_ENVIO"].Value?.ToString();
                txtCorreo2.Text = dgvEnvios2.CurrentRow.Cells["CORREO"].Value.ToString();
                txtNombre2.Text = dgvEnvios2.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtTelefono2.Text = dgvEnvios2.CurrentRow.Cells["TELEFONO"].Value.ToString();
                txtAreaLabor2.Text = dgvEnvios2.CurrentRow.Cells["AREA_LABOR"].Value.ToString();
                txtObservacion2.Text = dgvEnvios2.CurrentRow.Cells["OBSERVACION"].Value.ToString();
                txtProveedor.Text = dgvEnvios2.CurrentRow.Cells["PROVEEDOR_COURIER"].Value?.ToString();
                txtTlfCourier.Text = dgvEnvios2.CurrentRow.Cells["TELEFONO_COURIER"].Value?.ToString();
                txtDireccion.Text = dgvEnvios2.CurrentRow.Cells["DIRECCION_COURIER"].Value?.ToString();
                txtNombreRemitente.Text = dgvEnvios2.CurrentRow.Cells["NombreRemitente"].Value?.ToString();
                txtTlfRemitente.Text = dgvEnvios2.CurrentRow.Cells["TlfRemitente"].Value?.ToString();
                txtAreaLRemitente.Text = dgvEnvios2.CurrentRow.Cells["AreaRemitente"].Value?.ToString();
                txtNombreInst2.Text = dgvEnvios2.CurrentRow.Cells["NOMBRE_INST"].Value.ToString();
                txtTlfInst2.Text = dgvEnvios2.CurrentRow.Cells["TLF_INST"].Value.ToString();
                rdbSi2.Checked = dgvEnvios2.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi2.Text;
                rdbNo2.Checked = dgvEnvios2.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbNo2.Text;
                toolStrip1.Enabled = access != 3 && rdbSi2.Checked;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button.Name == btnNuevo1.Name)
            {
                if (dgvEnvios.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Solo esta permitido registrar un envió por correo electrónico", "MESSGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                EnabledControls(1, true);
                btnActualizar1.Enabled = false;
                btnNuevo1.Enabled = false;
                btnEliminar1.Enabled = false;
                crudCorreo = CRUD.Insertar;
                dgvEnvios.Enabled = false;
                LimpiarGrabar(1);
                if (dgvEnvios2.Rows.Count > 0)
                {
                    rdbSi.Checked = true;
                    rdbSi.Enabled = false;
                    rdbNo.Enabled = false;
                }

                _ = txtCorreo.Focus();
                CargarDatosInicialesInstitucion(txtNombreInst, txtTlfInst);
            }
            else
            {
                if (dgvEnvios2.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Solo esta permitido registrar un solo envió por correspondencia", "MESSGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                btnActualizar2.Enabled = false;
                btnNuevo2.Enabled = false;
                btnEliminar2.Enabled = false;
                EnabledControls(2, true);
                crudFisico = CRUD.Insertar;
                dgvEnvios2.Enabled = true;
                LimpiarGrabar(2);
                if (dgvEnvios.Rows.Count > 0)
                {
                    rdbSi2.Checked = true;
                    rdbSi2.Enabled = false;
                    rdbNo2.Enabled = false;
                }
                _ = txtComprobante.Focus();
                CargarDatosInicialesInstitucion(txtNombreInst2, txtTlfInst2);
                CargarDatosRemitente("02411");
                txtAreaLRemitente.Text = "PLANILLAS";
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            DataGridView dataGrid = button.Name == btnActualizar1.Name ? dgvEnvios : dgvEnvios2;
            if (dataGrid.Rows.Count > 0)
            {
                dataGrid.Enabled = false;
                if (button.Name == btnActualizar1.Name)
                {
                    EnabledControls(1, true);
                    btnActualizar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    crudCorreo = CRUD.Actualizar;
                }
                else
                {
                    btnActualizar2.Enabled = false;
                    btnNuevo2.Enabled = false;
                    btnEliminar2.Enabled = false;
                    EnabledControls(2, true);
                    crudFisico = CRUD.Actualizar;
                }
            }
            else
                _ = MessageBox.Show("No hay ningún envio registrado para actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            DataGridView dataGrid = button.Name == btnEliminar1.Name ? dgvEnvios : dgvEnvios2;
            if (dataGrid.CurrentCell is null)
            {
                _ = MessageBox.Show("Seleccione una registro para eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEnvios.CurrentCell != null || dgvEnvios2.CurrentCell != null)
            {
                DataGridView gridView = dgvEnvios.CurrentCell == null ? dgvEnvios2 : dgvEnvios;
                DataTable dtRecepCorreo = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionCorreo);
                DataTable dtRecepCorrespondencia = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(Convert.ToInt32(gridView.CurrentRow.Cells["ID_SEGUIMIENTO"].Value), RecepcionFisico);
                if (dtRecepCorreo != null && dtRecepCorreo.Rows.Count > 0 && button.Name == btnEliminar1.Name)
                {
                    _ = MessageBox.Show("No puede eliminar el envío por correo electrónico, ya que tiene registrado recepción por correo electrónico. \n" +
                        "Si desea proceder con dicho cambio, primero elimine la recepción por correo electrónico", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtRecepCorrespondencia != null && dtRecepCorrespondencia.Rows.Count > 0 && button.Name == btnEliminar2.Name)
                {
                    _ = MessageBox.Show("No puede eliminar el envío por correspondencia, ya que tiene registrado recepción por correspondencia. \n" +
                        "Si desea proceder con dicho cambio, primero elimine la recepción por correspondencia", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar este registro?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                SeguimientoPlanillaTo se = ObtenerDatosEliminar(dataGrid);
                _ = BLSeguimiento.GrabarSeguimientoPlanillaFase1(ref se, CRUD.Eliminar)
                    ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListarEnviosRegistrados();
                BtnCancelar_Click(sender, e);
                DgvEnvios_SelectionChanged(sender, e);
            }
        }


        private SeguimientoPlanillaTo ObtenerDatosEliminar(DataGridView dataGrid)
        {
            return new SeguimientoPlanillaTo()
            {
                PersonaEnvio = new PersonaEnvioTo
                {
                    ID_PERSONA = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_PERSONA"].Value)
                },
                EmisorTo = new PersonaEnvioTo
                {
                    ID_PERSONA = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_REMITENTE"].Value)
                },
                EnvioPlanilla = new EnvioPlanillaTo
                {
                    ID_ENVIO = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_ENVIO"].Value)
                }
            };
        }

        private void LimpiarGrabar(int act)
        {
            if (act == 1)
            {
                foreach (TextBox text in gbReceptor.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }

                txtObservacion.Clear();
            }
            else
            {
                txtComprobante.Clear();
                foreach (TextBox text in gbReceptor2.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }

                foreach (TextBox text in gbCourier.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }

                foreach (TextBox text in gbRemitente.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }

                foreach (TextBox text in gbInstitucion2.Controls.OfType<TextBox>().ToList())
                {
                    text.Clear();
                }

                txtObservacion2.Clear();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button.Name == btnCancelar1.Name || button.Name == btnGrabarSeguimiento1.Name)
            {
                EnabledControls(1, false);
                btnActualizar1.Enabled = true;
                btnNuevo1.Enabled = true;
                btnEliminar1.Enabled = true;
                crudCorreo = CRUD.None;
                dgvEnvios.Enabled = true;
                rdbSi.Checked = false;
                rdbNo.Checked = false;
            }
            else
            {
                btnActualizar2.Enabled = true;
                btnNuevo2.Enabled = true;
                btnEliminar2.Enabled = true;
                EnabledControls(2, false);
                crudFisico = CRUD.None;
                dgvEnvios2.Enabled = true;
                rdbSi2.Checked = false;
                rdbNo2.Checked = false;
            }
            DgvEnvios_SelectionChanged(sender, e);
        }

        private void BtnCerrarConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvEnvios.CurrentCell is null && dgvEnvios2.CurrentCell is null)
            {
                _ = MessageBox.Show("La planilla debe tener al menos un envío registrado. \n Seleccione uno", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (dgvEnvios.CurrentCell != null && dgvEnvios.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi.Text && dgvEnvios2.Rows.Count == 0)
            //{
            //    _ = MessageBox.Show("Debe registrar un envío por correspondencia, ya que lo a registrado como obligatorio", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (dgvEnvios2.CurrentCell != null && dgvEnvios2.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi2.Text && dgvEnvios.Rows.Count == 0)
            //{
            //    _ = MessageBox.Show("Debe registrar un envío por correo electrónico, ya que lo a registrado como obligatorio", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            DialogResult dr = MessageBox.Show("¿Esta seguro de cerrar esta etapa?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                SeguimientoPlanillaTo se = ObtenerDatosCerrar();
                _ = BLSeguimiento.CerrarSeguimientoPlanilla(se)
                    ? MessageBox.Show("La etapa de envío se ha cerrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al cerrar esta etapa", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private SeguimientoPlanillaTo ObtenerDatosCerrar()
        {
            DataGridView dataGrid = dgvEnvios.CurrentCell != null ? dgvEnvios : dgvEnvios2;
            return new SeguimientoPlanillaTo()
            {
                ID_SEGUIMIENTO = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value),
                ID_ESTADO = ENVIADO_CERRADO, //> Planilla enviada cerrada
                USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO,
                USUARIO_MODIFICA = SeguimientoPlanilla.COD_USUARIO
            };
        }

        private void DgvEnvios_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            gridView.Cursor = Cursors.Default;
        }

        private void DgvEnvios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (e.RowIndex >= 0 && dataGrid[0, e.RowIndex] != null)
                dataGrid.Cursor = Cursors.PanEast;
        }

        private void EnabledControls(int act, bool enabled)
        {
            if (act == 1)
            {
                dtFechaEnvio.Enabled = enabled;
                dtHoraEnvio.Enabled = enabled;
                gbReceptor.Enabled = enabled;
                txtObservacion.Enabled = enabled;
                gbInstitucion.Enabled = enabled;
                rdbSi.Enabled = enabled;
                rdbNo.Enabled = enabled;
            }
            else
            {
                dtFechaEnvio2.Enabled = enabled;
                dtHoraEnvio2.Enabled = enabled;
                gbReceptor2.Enabled = enabled;
                gbCourier.Enabled = enabled;
                txtComprobante.Enabled = enabled;
                txtObservacion2.Enabled = enabled;
                gbRemitente.Enabled = enabled;
                gbInstitucion2.Enabled = enabled;
                rdbSi2.Enabled = enabled;
                rdbNo2.Enabled = enabled;
            }
        }

        public void EnabledButtons(bool act, int idEstado)
        {
            if (act)
            {
                access = 1;
                lblEstadoRegistrar.Visible = false;
                btnCerrarConfirmar.Enabled = false;
                if (idEstado == RECEPCIONADA)
                {
                    EnabledControls(1, false);
                    EnabledControls(2, false);
                    toolStrip1.Enabled = true;
                    toolStrip2.Enabled = true;
                }
                else
                {
                    access = 3;
                    ReadOnlyTextBox(true);
                    toolStrip1.Enabled = false;
                    toolStrip2.Enabled = false;
                }
            }
            else
            {
                access = 2;
                EnabledControls(1, false);
                EnabledControls(2, false);
                btnCerrarConfirmar.Enabled = false;
                lblEstadoRegistrar.Visible = false;
            }
        }

        private void RdbNo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb.Name == rdbNo.Name)
            {
                toolStrip2.Enabled = !rdbNo.Checked;
            }
            else
            {
                toolStrip1.Enabled = !rdbNo2.Checked;
            }
        }

        private void DgvEnvios_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvEnvios.Rows.Count > 0)
            {
                rdbSi2.Checked = true;
                if (access != 1)
                    toolStrip2.Enabled = true;
                rdbSi2.Enabled = false;
                rdbNo2.Enabled = false;
            }

            if (dgvEnvios2.Rows.Count > 0)
            {
                rdbSi.Checked = true;
                if (access != 1)
                    toolStrip1.Enabled = true;
                rdbSi.Enabled = false;
                rdbNo.Enabled = false;
            }
        }

        private void MantenedorEnvioPlanillas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (access == 2 && dgvEnvios.CurrentCell != null && dgvEnvios.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi.Text && dgvEnvios2.Rows.Count == 0)
            {
                _ = MessageBox.Show("Debe registrar un envío por correspondencia, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //> e.Cancel = true;
            }

            if (access == 2 && dgvEnvios2.CurrentCell != null && dgvEnvios2.CurrentRow.Cells["ENVIO_CORRESP"].Value.ToString() == rdbSi2.Text && dgvEnvios.Rows.Count == 0)
            {
                _ = MessageBox.Show("Debe registrar un envío por correo electrónico, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //> e.Cancel = true;
            }
        }

        private void ReadOnlyTextBox(bool readonlyValue)
        {
            foreach (GroupBox group in Controls.OfType<GroupBox>().ToList())
            {
                foreach (Control control in group.Controls)
                {
                    if (control is TextBox text)
                    {
                        text.ReadOnly = readonlyValue;
                        text.BackColor = Color.White;
                    }

                    if (control is GroupBox groupBox)
                    {
                        foreach (TextBox text2 in groupBox.Controls.OfType<TextBox>().ToList())
                        {
                            text2.ReadOnly = readonlyValue;
                            text2.BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void CargarReceptor()
        {
            dtReceptorExistente = BLMaestroPersona.ObtenerPersonasXPuntoCobranza(CodPtoCob);
            if (dtReceptorExistente.Rows.Count > 0)
            {
                foreach (DataColumn column in dtReceptorExistente.Columns)
                {
                    column.AllowDBNull = true;
                    column.ReadOnly = false;
                }

                DataRow row = dtReceptorExistente.NewRow();
                row["ITEM"] = "0";
                row["NOMBRE"] = "Seleccione";

                dtReceptorExistente.Rows.InsertAt(row, 0);

                cboReceptor1.DataSource = dtReceptorExistente;
                cboReceptor1.DisplayMember = "NOMBRE";
                cboReceptor1.ValueMember = "ITEM";

                cboReceptor2.DataSource = dtReceptorExistente.Copy();
                cboReceptor2.DisplayMember = "NOMBRE";
                cboReceptor2.ValueMember = "ITEM";
            }
        }

        private void CboReceptor1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dtReceptorExistente != null)
            {
                DataRow row = dtReceptorExistente.Select("ITEM = '" + cboReceptor1.SelectedValue.ToString() + "'").FirstOrDefault();
                if (cboReceptor1.SelectedValue.ToString() == "0")
                {
                    txtCorreo.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtAreaLabor.Text = string.Empty;
                    return;
                }

                if (row != null && row.ItemArray.Length > 0)
                {
                    txtCorreo.Text = row["MAIL"].ToString();
                    txtNombre.Text = row["NOMBRE"].ToString();
                    txtTelefono.Text = row["TELEFONO"].ToString();
                    txtAreaLabor.Text = row["OBSERVACION"].ToString();
                }
            }
        }

        private void CboReceptor2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dtReceptorExistente != null)
            {
                DataRow row = dtReceptorExistente.Select("ITEM = '" + cboReceptor2.SelectedValue.ToString() + "'").FirstOrDefault();
                if (cboReceptor2.SelectedValue.ToString() == "0")
                {
                    txtCorreo2.Text = string.Empty;
                    txtNombre2.Text = string.Empty;
                    txtTelefono2.Text = string.Empty;
                    txtAreaLabor2.Text = string.Empty;
                    return;
                }

                if (row != null && row.ItemArray.Length > 0)
                {
                    txtCorreo2.Text = row["MAIL"].ToString();
                    txtNombre2.Text = row["NOMBRE"].ToString();
                    txtTelefono2.Text = row["TELEFONO"].ToString();
                    txtAreaLabor2.Text = row["OBSERVACION"].ToString();
                }
            }
        }

        private void CargarPersonalPlla()
        {
            lstPersonaCatPllas = BLSeguimiento.ObtenerMaestroPersonaCategoriaPllas();
            if (lstPersonaCatPllas != null && lstPersonaCatPllas.Count > 0)
            {
                lstPersonaCatPllas.Insert(0, new personaMaestroTo { COD_PER = "0", NOMBRE = "Seleccione" });
                cboRemitente.DataSource = lstPersonaCatPllas;
                cboRemitente.ValueMember = "COD_PER";
                cboRemitente.DisplayMember = "NOMBRE";

                cboCourierTrans.DataSource = lstPersonaCatPllas.CloneList();
                cboCourierTrans.ValueMember = "COD_PER";
                cboCourierTrans.DisplayMember = "NOMBRE";
            }
        }

        private void CargarDatosRemitente(string codPer)
        {
            if (lstPersonaCatPllas != null)
            {
                personaMaestroTo persona = lstPersonaCatPllas.Where(x => x.COD_PER == codPer).SingleOrDefault();
                if (persona != null)
                {
                    if (persona.COD_PER == "0")
                    {
                        txtNombreRemitente.Text = string.Empty;
                        txtTlfRemitente.Text = string.Empty;
                        txtAreaLRemitente.Text = string.Empty;
                        return;
                    }

                    txtNombreRemitente.Text = persona.NOMBRE;
                    DataTable dt = BLPersonaFono.obtenerPersonaFonoBLL(new personaFonoTo { COD_PER = persona.COD_PER });
                    txtTlfRemitente.Text = dt != null && dt.Rows.Count > 0 ? dt.Rows[0]["NRO_FONO"]?.ToString() : string.Empty;
                    txtAreaLRemitente.Text = string.Empty;
                }
            }
        }

        private void CboRemitente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string codPer = cboRemitente.SelectedValue.ToString();
            CargarDatosRemitente(codPer);
        }

        private void CboCourierTrans_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lstPersonaCatPllas != null)
            {
                personaMaestroTo persona = lstPersonaCatPllas.Where(x => x.COD_PER == cboCourierTrans.SelectedValue.ToString()).SingleOrDefault();
                if (persona != null)
                {
                    if (persona.COD_PER == "0")
                    {
                        txtProveedor.Text = string.Empty;
                        txtTlfCourier.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        return;
                    }

                    txtProveedor.Text = persona.NOMBRE;
                    DataTable dt = BLDireccionPersona.obtenerPersonaDireccionBLL(new personaDireccionTo { COD_PER = persona.COD_PER });
                    txtDireccion.Text = dt != null && dt.Rows.Count > 0 ? dt.Rows[0]["DIRECCION"]?.ToString() : string.Empty;
                    DataTable dt2 = BLPersonaFono.obtenerPersonaFonoBLL(new personaFonoTo { COD_PER = persona.COD_PER });
                    txtTlfCourier.Text = dt2 != null && dt2.Rows.Count > 0 ? dt2.Rows[0]["NRO_FONO"]?.ToString() : string.Empty;
                }
            }
        }

        private void CargarDatosInicialesInstitucion(TextBox txtInstitucion, TextBox txtTelefono)
        {
            txtInstitucion.Text = string.Concat(CodPtoCob, " - ", NombrePuntoCobranza);
            DataTable dt = BLPersonaFono.ObtenerTelefonoPuntoCobranzaFono(CodPtoCob);
            txtTelefono.Text = dt != null && dt.Rows.Count > 0 ? dt.Rows[0]["NRO_FONO"]?.ToString() : string.Empty;
        }
    }
}
