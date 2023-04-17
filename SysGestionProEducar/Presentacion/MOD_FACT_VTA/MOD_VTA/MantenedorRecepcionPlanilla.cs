using BLL;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Entidades.ConstClass;

namespace SysSeguimiento
{
    public partial class MantenedorRecepcionPlanilla : Form
    {
        private readonly string estado;
        private readonly int idRecepcion;
        private readonly DataTable dtPlanilla;
        public string NombrePuntoCobranza { get; set; }

        public MantenedorRecepcionPlanilla(string estado, DataTable dtPlanilla, int idRecepcion = 0)
        {
            InitializeComponent();
            KeyDown += NextControl;
            this.estado = estado;
            this.dtPlanilla = dtPlanilla;
            this.idRecepcion = idRecepcion;
        }

        private static readonly SeguimientoPlanillasBLL BLSeguimiento = new SeguimientoPlanillasBLL();
        private CRUD crudCorreo, crudFisico;
        private int access;
        private bool esEnvioXCorrespondencia, esEnvioXCorreo;

        private void RegistrarSeguimiento_Load(object sender, EventArgs e)
        {
            StartControls();
            MostrarDatosEnvio();
            ListarRecepcionRegistradas();
            CurrentCellXId();
        }

        private void StartControls()
        {
            lblNroPlanilla.Text += dtPlanilla.Rows[0]["NRO_PLANILLA_COB"].ToString();
            lblEstado.Text += estado;
            lblEstadoRegistrar.Text += BLSeguimiento.ObtenerEstadoSeguimientoXId(RECEPCIONADA).Rows[0]["DESC_ESTADO"].ToString();

            txtTelefono.MaxLength = 12;
            txtTelefono2.MaxLength = 12;

            btnGrabarSeguimiento.Cursor = Cursors.Hand;
            btnActualizar.Cursor = Cursors.Hand;
            btnNuevo.Cursor = Cursors.Hand;
            btnEliminar.Cursor = Cursors.Hand;
            btnCancelar.Cursor = Cursors.Hand;
            btnProgramarCall.Cursor = Cursors.Hand;
            btnRegistrarCall.Cursor = Cursors.Hand;
            btnCerrarConfirmar.Cursor = Cursors.Hand;

            dgvRecepcion.MultiSelect = false;
            dgvRecepcion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecepcion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRecepcion2.MultiSelect = false;
            dgvRecepcion2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecepcion2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            crudCorreo = CRUD.None;
            crudFisico = CRUD.None;
            if (access == 0)
            {
                EnabledControls(1, false);
                EnabledControls(2, false);
            }

            Text += " | Punto Cobranza : " + NombrePuntoCobranza;
        }

        private void NextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void CurrentCellXId()
        {
            if (dgvRecepcion.Rows.Count > 0)
            {
                int index = dgvRecepcion.Rows.Cast<DataGridViewRow>()
                    .Where(x => Convert.ToInt32(x.Cells["ID_RECEPCION"].Value) == idRecepcion)
                    .Select(f => f.Index).FirstOrDefault();
                dgvRecepcion.CurrentCell = dgvRecepcion[5, index];
                DgvRecepcion_SelectionChanged(new object(), new EventArgs());
            }

            if (dgvRecepcion2.Rows.Count > 0)
            {
                int index = dgvRecepcion2.Rows.Cast<DataGridViewRow>()
                    .Where(x => Convert.ToInt32(x.Cells["ID_RECEPCION"].Value) == idRecepcion)
                    .Select(f => f.Index).FirstOrDefault();
                dgvRecepcion2.CurrentCell = dgvRecepcion2[5, index];
                DgvRecepcion_SelectionChanged(new object(), new EventArgs());
            }
        }

        private void ListarRecepcionRegistradas(int idSeguimiento = 0)
        {
            idSeguimiento = idSeguimiento == 0 ? Convert.ToInt32(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"]) : idSeguimiento;
            dgvRecepcion.DataSource = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(idSeguimiento, RecepcionCorreo);

            foreach (DataGridViewColumn column in dgvRecepcion.Columns)
            {
                if (column.Name != "FECHA_RECEPCION" && column.Name != "HORA_RECEPCION")
                {
                    column.Visible = false;
                }
            }

            dgvRecepcion.Columns["FECHA_RECEPCION"].HeaderText = "F.RECEPCIÓN";
            dgvRecepcion.Columns["HORA_RECEPCION"].HeaderText = "H.RECEPCIÓN";

            dgvRecepcion.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            if (dgvRecepcion.Rows.Count > 0)
                dgvRecepcion.CurrentCell = dgvRecepcion[5, 0];

            dgvRecepcion2.DataSource = BLSeguimiento.ListarRecepcionPlanillasXTipoRecepcion(idSeguimiento, RecepcionFisico);

            foreach (DataGridViewColumn column in dgvRecepcion2.Columns)
            {
                if (column.Name != "FECHA_RECEPCION" && column.Name != "HORA_RECEPCION")
                {
                    column.Visible = false;
                }
            }

            dgvRecepcion2.Columns["FECHA_RECEPCION"].HeaderText = "F.RECEPCIÓN";
            dgvRecepcion2.Columns["HORA_RECEPCION"].HeaderText = "H.RECEPCIÓN";

            dgvRecepcion2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            if (dgvRecepcion2.Rows.Count > 0)
                dgvRecepcion2.CurrentCell = dgvRecepcion2[5, 0];

        }

        private void BtnGrabarSeguimiento_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            CRUD crud = button.Name == btnGrabarSeguimiento1.Name ? crudCorreo : crudFisico;
            if (crud == CRUD.None)
                return;
            if (ValidarGrabar(button))
            {
                DialogResult dr = MessageBox.Show("¿Esta seguro de que desea grabar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string _a = crud == CRUD.Insertar ? "Registrado " : "Actualizado ";
                        SeguimientoPlanillaTo se = ObtenerDatosGrabar(button);
                        _ = BLSeguimiento.GrabarSeguimientoPlanillaFase2(ref se, crud)
                            ? MessageBox.Show(_a + "Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Ocurrió un error inesperado", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        crud = CRUD.None;
                        ListarRecepcionRegistradas(se.ID_SEGUIMIENTO);
                        BtnCancelar_Click(sender, e);
                        DgvRecepcion_SelectionChanged(sender, e);
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
            DataGridView dataGird = button.Name == btnGrabarSeguimiento1.Name ? dgvRecepcion : dgvRecepcion2;
            return new SeguimientoPlanillaTo()
            {
                ID_SEGUIMIENTO = Convert.ToInt32(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"]),
                ID_ESTADO = RECEPCIONADA, //> Planilla Recepcionada
                NRO_PLANILLA = dtPlanilla.Rows[0]["NRO_PLANILLA_COB"].ToString(),
                TIPO_PLANILLA = dtPlanilla.Rows[0]["TIPO_PLANILLA"].ToString(),
                FE_AÑO = dtPlanilla.Rows[0]["FE_AÑO"].ToString(),
                FE_MES = dtPlanilla.Rows[0]["FE_MES"].ToString(),
                COD_PTO_COB_CONSOLIDADO = dtPlanilla.Rows[0]["COD_PTO_COB_CONSOLIDADO"].ToString(),
                OBSERVACION = txtObservacion.Text,
                USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO,
                USUARIO_MODIFICA = SeguimientoPlanilla.COD_USUARIO,
                PersonaEnvio = new PersonaEnvioTo
                {
                    ID_PERSONA = crudCorreo == CRUD.Actualizar || crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGird.CurrentRow.Cells["ID_PERSONA"].Value) : 0,
                    NOMBRE = button.Name == btnGrabarSeguimiento1.Name ? txtNombre.Text : txtNombre2.Text,
                    APELLIDO = string.Empty,
                    TELEFONO = button.Name == btnGrabarSeguimiento1.Name ? txtTelefono.Text : txtTelefono2.Text,
                    AREA_LABOR = button.Name == btnGrabarSeguimiento1.Name ? txtAreaLabor.Text : txtAreaLabor2.Text,
                },
                RecepcionPlanillaTo = new RecepcionPlanillaTo
                {
                    ID_RECEPCION = crudCorreo == CRUD.Actualizar || crudFisico == CRUD.Actualizar ? Convert.ToInt32(dataGird.CurrentRow.Cells["ID_RECEPCION"].Value) : 0,
                    FECHA_RECEPCION = button.Name == btnGrabarSeguimiento1.Name ? dtFechaRecepcion.Value : dtFechaRecepcion2.Value,
                    HORA_RECEPCION = button.Name == btnGrabarSeguimiento1.Name ? dtHoraRecepcion.Value.ToString("HH:mm:ss") : dtHoraRecepcion.Value.ToString("HH:mm:ss"),
                    AREA_RECEPCION = button.Name == btnGrabarSeguimiento1.Name ? txtAreaRepcion.Text : txtAreaRecepcion2.Text,
                    OBSERVACION = button.Name == btnGrabarSeguimiento1.Name ? txtObservacion.Text : txtObservacion2.Text,
                    TIPO_REPCION = button.Name == btnGrabarSeguimiento1.Name ? "RC" : "RF"
                }
            };
        }

        private bool ValidarGrabar(ToolStripButton button)
        {
            if (button.Name == btnGrabarSeguimiento1.Name)
            {
                if (string.IsNullOrEmpty(txtAreaRepcion.Text))
                {
                    _ = MessageBox.Show("Digite el área de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtAreaRepcion.Focus();
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
            }
            else
            {
                if (string.IsNullOrEmpty(txtAreaRecepcion2.Text))
                {
                    _ = MessageBox.Show("Digite el área de recepción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _ = txtAreaRecepcion2.Focus();
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
            }
            return true;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button.Name == btnNuevo1.Name)
            {
                if (dgvRecepcion.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Solo esta permitido registrar una sola recepción por correo electrónico", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                EnabledControls(1, true);
                btnActualizar1.Enabled = false;
                btnEliminar1.Enabled = false;
                btnNuevo1.Enabled = false;
                dgvRecepcion.Enabled = false;
                btnProgramarCall.Enabled = false;
                btnRegistrarCall.Enabled = false;
                crudCorreo = CRUD.Insertar;
                LimpiarGrabar(1);
                _ = txtAreaRepcion.Focus();
            }
            else
            {
                if (dgvRecepcion2.Rows.Count > 0)
                {
                    _ = MessageBox.Show("Solo esta permitido registrar una sola recepción por correspondencia", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                EnabledControls(2, true);
                btnActualizar2.Enabled = false;
                btnEliminar2.Enabled = false;
                btnNuevo2.Enabled = false;
                dgvRecepcion2.Enabled = false;
                btnProgramarCall.Enabled = false;
                btnRegistrarCall.Enabled = false;
                crudFisico = CRUD.Insertar;
                LimpiarGrabar(2);
                _ = txtAreaRecepcion2.Focus();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button.Name == btnActualizar1.Name)
            {
                if (dgvRecepcion.Rows.Count > 0)
                {
                    EnabledControls(1, true);
                    btnNuevo1.Enabled = false;
                    btnActualizar1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    dgvRecepcion.Enabled = false;
                    btnProgramarCall.Enabled = false;
                    btnRegistrarCall.Enabled = false;
                    crudCorreo = CRUD.Actualizar;
                }
                else
                    _ = MessageBox.Show("No hay ninguna recepción registrado para actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dgvRecepcion2.Rows.Count > 0)
                {
                    EnabledControls(2, true);
                    btnNuevo2.Enabled = false;
                    btnActualizar2.Enabled = false;
                    btnEliminar2.Enabled = false;
                    dgvRecepcion2.Enabled = false;
                    btnProgramarCall.Enabled = false;
                    btnRegistrarCall.Enabled = false;
                    crudFisico = CRUD.Actualizar;
                }
                else
                    _ = MessageBox.Show("No hay ninguna recepción registrado para actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            DataGridView gridView = button.Name == btnEliminar1.Name ? dgvRecepcion : dgvRecepcion2;
            if (gridView.CurrentCell is null)
            {
                _ = MessageBox.Show("Seleccione una registro para eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar este registro?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    SeguimientoPlanillaTo se = ObtenerDatosEliminar(gridView);
                    _ = BLSeguimiento.GrabarSeguimientoPlanillaFase2(ref se, CRUD.Eliminar)
                        ? MessageBox.Show("Eliminado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Ocurrió un error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ListarRecepcionRegistradas(se.ID_SEGUIMIENTO);
                    BtnCancelar_Click(sender, e);
                    DgvRecepcion_SelectionChanged(sender, e);
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private SeguimientoPlanillaTo ObtenerDatosEliminar(DataGridView gridView)
        {
            return new SeguimientoPlanillaTo()
            {
                PersonaEnvio = new PersonaEnvioTo
                {
                    ID_PERSONA = Convert.ToInt32(gridView.CurrentRow.Cells["ID_PERSONA"].Value)
                },
                RecepcionPlanillaTo = new RecepcionPlanillaTo
                {
                    ID_RECEPCION = Convert.ToInt32(gridView.CurrentRow.Cells["ID_RECEPCION"].Value)
                }
            };
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
                dgvRecepcion.Enabled = true;
                crudCorreo = CRUD.None;
            }
            else
            {
                EnabledControls(2, false);
                btnActualizar2.Enabled = true;
                btnNuevo2.Enabled = true;
                btnEliminar2.Enabled = true;
                dgvRecepcion2.Enabled = true;
                crudFisico = CRUD.None;
            }

            btnProgramarCall.Enabled = true;
            btnRegistrarCall.Enabled = true;
            DgvRecepcion_SelectionChanged(sender, e);
        }

        private void DgvRecepcion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecepcion.CurrentCell != null && crudCorreo != CRUD.Insertar && crudCorreo != CRUD.Actualizar)
            {
                dtFechaRecepcion.Value = Convert.ToDateTime(dgvRecepcion.CurrentRow.Cells["FECHA_RECEPCION"].Value);
                dtHoraRecepcion.Value = Convert.ToDateTime("2000-1-1 " + dgvRecepcion.CurrentRow.Cells["HORA_RECEPCION"].Value);
                txtAreaRepcion.Text = dgvRecepcion.CurrentRow.Cells["AREA_RECEPCION"].Value?.ToString();
                txtNombre.Text = dgvRecepcion.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtTelefono.Text = dgvRecepcion.CurrentRow.Cells["TELEFONO"].Value.ToString();
                txtAreaLabor.Text = dgvRecepcion.CurrentRow.Cells["AREA_LABOR"].Value.ToString();
                txtObservacion.Text = dgvRecepcion.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            }

            if (dgvRecepcion2.CurrentCell != null && crudFisico != CRUD.Insertar && crudFisico != CRUD.Actualizar)
            {
                dtFechaRecepcion2.Value = Convert.ToDateTime(dgvRecepcion2.CurrentRow.Cells["FECHA_RECEPCION"].Value);
                dtHoraRecepcion2.Value = Convert.ToDateTime("2000-1-1 " + dgvRecepcion2.CurrentRow.Cells["HORA_RECEPCION"].Value);
                txtAreaRecepcion2.Text = dgvRecepcion2.CurrentRow.Cells["AREA_RECEPCION"].Value?.ToString();
                txtNombre2.Text = dgvRecepcion2.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtTelefono2.Text = dgvRecepcion2.CurrentRow.Cells["TELEFONO"].Value.ToString();
                txtAreaLabor2.Text = dgvRecepcion2.CurrentRow.Cells["AREA_LABOR"].Value.ToString();
                txtObservacion2.Text = dgvRecepcion2.CurrentRow.Cells["OBSERVACION"].Value.ToString();
            }
        }

        private void LimpiarGrabar(int acc)
        {
            if (acc == 1)
            {
                txtAreaRepcion.Clear();
                txtObservacion.Clear();
            }
            else
            {
                txtAreaRecepcion2.Clear();
                txtObservacion2.Clear();
            }
        }

        private void BtnCerrarConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvRecepcion.CurrentCell is null && dgvRecepcion2.CurrentCell is null)
            {
                _ = MessageBox.Show("La planilla debe tener al menos una recepción registrada. \n Seleccione uno", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (esEnvioXCorrespondencia && dgvRecepcion2.Rows.Count == 0)
            //{
            //    _ = MessageBox.Show("Debe registrar una recepción por correspondencia, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (esEnvioXCorreo && dgvRecepcion.Rows.Count == 0)
            //{
            //    _ = MessageBox.Show("Debe registrar una recepción por correspondencia, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (dgvRecepcion.CurrentCell != null)
            {
                if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(Convert.ToInt32(dgvRecepcion.CurrentRow.Cells["ID_SEGUIMIENTO"].Value)).Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (dgvRecepcion2.CurrentCell != null)
            {
                if (BLSeguimiento.ListarLlamadasPendientesXIdSeguimiento(Convert.ToInt32(dgvRecepcion2.CurrentRow.Cells["ID_SEGUIMIENTO"].Value)).Rows.Count > 0)
                {
                    _ = MessageBox.Show("Esta planilla tiene aún llamadas programadas pendientes", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DialogResult dr = MessageBox.Show("¿Esta seguro de cerrar esta etapa?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                SeguimientoPlanillaTo se = ObtenerDatosCerrar();
                _ = BLSeguimiento.CerrarSeguimientoPlanilla(se)
                    ? MessageBox.Show("La etapa de recepción se ha cerrado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : MessageBox.Show("Ocurrió un error al cerrar la planilla", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private SeguimientoPlanillaTo ObtenerDatosCerrar()
        {
            DataGridView dataGrid = dgvRecepcion.CurrentCell == null ? dgvRecepcion2 : dgvRecepcion;
            return new SeguimientoPlanillaTo()
            {
                ID_SEGUIMIENTO = Convert.ToInt32(dataGrid.CurrentRow.Cells["ID_SEGUIMIENTO"].Value),
                ID_ESTADO = RECEPCIONADO_CERRADO, //> Planilla recepcionado cerrada
                USUARIO_CREA = SeguimientoPlanilla.COD_USUARIO
            };
        }

        private void BtnProgramarCall_Click(object sender, EventArgs e)
        {
            MostrarFormLLamda(1);
        }

        private void BtnRegistrarCall_Click(object sender, EventArgs e)
        {
            MostrarFormLLamda(2);
        }

        private void MostrarFormLLamda(int idOption)
        {
            if (dtPlanilla != null)
            {
                int idSeguimiento = Convert.ToInt32(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"]);
                int idEstado = RECEPCIONADA;
                string nroPlanilla = dtPlanilla.Rows[0]["NRO_PLANILLA_COB"].ToString();
                string estado = this.estado;
                const int idLlamadaBase = 0;
                ProgramarLlamada llamada = new ProgramarLlamada(idOption, TituloProgramado, idSeguimiento, idEstado, nroPlanilla, NombrePuntoCobranza, estado, idLlamadaBase)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                _ = llamada.ShowDialog();
            }
        }

        private void EnabledControls(int acc, bool enabled)
        {
            if (acc == 1)
            {
                gbReceptor.Enabled = enabled;
                dtFechaRecepcion.Enabled = enabled;
                dtHoraRecepcion.Enabled = enabled;
                txtAreaRepcion.Enabled = enabled;
            }
            else
            {
                gbReceptor2.Enabled = enabled;
                dtFechaRecepcion2.Enabled = enabled;
                dtHoraRecepcion2.Enabled = enabled;
                txtAreaRecepcion2.Enabled = enabled;
            }
        }

        public void EnabledButtons(bool act)
        {
            if (act)
            {
                access = 1;
                lblEstadoRegistrar.Visible = false;
                btnCerrarConfirmar.Enabled = false;
                EnabledControls(1, true);
                EnabledControls(2, true);
                toolStrip1.Enabled = false;
                toolStrip2.Enabled = false;
                ReadOnlyTextBox(true);
            }
            else
            {
                access = 2;
                lblEstadoRegistrar.Visible = false;
                btnCerrarConfirmar.Enabled = false;
                EnabledControls(1, false);
                EnabledControls(2, false);
                toolStrip1.Enabled = true;
                toolStrip2.Enabled = true;
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

        private void MantenedorRecepcionPlanilla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (access == 2 && esEnvioXCorrespondencia && dgvRecepcion2.Rows.Count == 0)
            {
                _ = MessageBox.Show("Debe registrar una recepción por correspondencia, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //> e.Cancel = true;
            }

            if (access == 2 && esEnvioXCorreo && dgvRecepcion.Rows.Count == 0)
            {
                _ = MessageBox.Show("Debe registrar una recepción por correspondencia, ya que lo a registrado como obligatorio en la etapa de envío", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //> e.Cancel = true;
            }
        }

        private void MostrarDatosEnvio()
        {
            DataTable dt = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(Convert.ToInt32(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"]), EnvioCorreo);
            if (dt != null && dt.Rows.Count > 0)
            {
                esEnvioXCorreo = true;
                txtNombre.Text = dt.Rows[0]["NOMBRE"].ToString();
                txtAreaLabor.Text = dt.Rows[0]["AREA_LABOR"].ToString();
                txtTelefono.Text = dt.Rows[0]["TELEFONO"].ToString();
            }
            else
                toolStrip1.Enabled = false;

            DataTable dt2 = BLSeguimiento.ListarEnvioSeguimientoPlanillaXTipoEnvio(Convert.ToInt32(dtPlanilla.Rows[0]["ID_SEGUIMIENTO"]), EnvioFisico);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                esEnvioXCorrespondencia = true;
                txtNombre2.Text = dt2.Rows[0]["NOMBRE"].ToString();
                txtAreaLabor2.Text = dt2.Rows[0]["AREA_LABOR"].ToString();
                txtTelefono2.Text = dt2.Rows[0]["TELEFONO"].ToString();
            }
            else
                toolStrip2.Enabled = false;
        }
    }
}
