using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using Entidades;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmAsociarConceptosTesoreria : Form
    {
        public FrmAsociarConceptosTesoreria()
        {
            InitializeComponent();
        }

        private readonly comisionesBLL BLComision = new comisionesBLL();

        private CRUD crud;
        private Rectangle dragBoxFromMouseDown;

        private void FrmAsociarConceptosTesoreria_Load(object sender, EventArgs e)
        {
            StartControls();
            CrearColumnasDataGridView(dgvConcepto);
            CrearColumnasDataGridView(dgvConceptoAsoc);
            CargarCombobox();
            ListarAsociarConceptoTesoreria();
            ListarConcepto();
        }

        private void StartControls()
        {
            cboTipoAsociar.DropDownStyle = ComboBoxStyle.DropDownList;
            btnNuevo.StyleButtonFlat();
            btnGuardar.StyleButtonFlat();
            btnActualizar.StyleButtonFlat();
            btnCancelar.StyleButtonFlat();
            dgvConcepto.Style5(false, false, false, false, true, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect, false);
            dgvConceptoAsoc.Style5(false, false, false, false, true, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect, false);
            dgvTipoAsociacion.Style5(false, false, false, false, true, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True,
                DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.FullRowSelect, false);

            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtDescripcion.MaxLength = 100;
        }

        private void CargarCombobox()
        {
            DataTable dt = BLComision.ListarAsociarConceptoTesoreria();
            cboTipoAsociar.ValueMember = "ID_ASOCIAR";
            cboTipoAsociar.DisplayMember = "DESCRIPCION";
            cboTipoAsociar.DataSource = dt;
        }

        private void ObtenerCorrelativoIdAsociar()
        {
            txtCodigo.Text = BLComision.ObtenerCorrelativoIdAsociar().ToString();
        }

        private void CrearColumnasDataGridView(DataGridView dataGrid)
        {
            if (dataGrid != null)
            {
                var arrColumn = new[]
                {
                    new { name = "Id", HeaderText = "Id", with = 40, visible = false },
                    new { name = "Codigo", HeaderText = "Código", with = 50, visible = true },
                    new { name = "Descripcion", HeaderText = "Descripción", with = 190, visible = true },
                    new { name = "Destino", HeaderText = "Destino", with = 140, visible = true }
                };

                foreach (var item in arrColumn)
                {
                    _ = dataGrid.Columns.Add(new DataGridViewColumn
                    {
                        Name = item.name,
                        HeaderText = item.HeaderText,
                        Visible = item.visible,
                        Width = item.with,
                        SortMode = DataGridViewColumnSortMode.Automatic,
                        CellTemplate = new DataGridViewTextBoxCell()
                    });
                }
                dataGrid.AlingHeaderTextCenter();
            }
        }

        private void ListarAsociarConceptoTesoreria()
        {
            DataTable dt = BLComision.ListarAsociarConceptoTesoreria();
            dgvTipoAsociacion.DataSource = dt;
            RenameColumns();
            WidthColumns();
        }

        private void RenameColumns()
        {
            if (dgvTipoAsociacion.Columns.Count > 0)
            {
                dgvTipoAsociacion.Columns["ID_ASOCIAR"].HeaderText = "ID";
                dgvTipoAsociacion.Columns["DESCRIPCION"].HeaderText = "DESCRIPCIÓN";
            }
        }

        private void WidthColumns()
        {
            if (dgvTipoAsociacion.Columns.Count > 0)
            {
                dgvTipoAsociacion.Columns["ID_ASOCIAR"].Width = 50;
                dgvTipoAsociacion.Columns["DESCRIPCION"].Width = 150;
            }
        }

        private void ListarConcepto()
        {
            try
            {
                DataTable lstMaestroConcepto = MaestroConceptoBLL.Instancia.ListarSegundoNivel().AsEnumerable().OrderBy(x => x.Field<string>("DesCorta")).CopyToDataTable();
                DataTable lstMaestroConceptoPadre = MaestroConceptoBLL.Instancia.ListarPrimerNivel();
                if (dgvConcepto != null)
                {
                    DataRow conceptoPadre;
                    string descConceptoPadre;
                    foreach (DataRow item in lstMaestroConcepto.Rows)
                    {
                        conceptoPadre = lstMaestroConceptoPadre.AsEnumerable().SingleOrDefault(x => x.Field<int>("Id") == item["IdConceptoPadre"].ToInt32());
                        descConceptoPadre = conceptoPadre != null ? conceptoPadre["DesCorta"]?.ToString() : string.Empty;
                        _ = dgvConcepto.Rows.Add(item["Id"], item["Codigo"], item["DesCorta"], descConceptoPadre);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            crud = CRUD.Insertar;
            ObtenerCorrelativoIdAsociar();
            DisableEnableControls(true);
            LimpiarControles();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            crud = CRUD.Actualizar;
            DisableEnableControls(true);
        }

        private void DisableEnableControls(bool enabled)
        {
            txtDescripcion.Enabled = enabled;
            dgvTipoAsociacion.Enabled = !enabled;
        }

        private void LimpiarControles()
        {
            txtDescripcion.Text = string.Empty;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarGuardar())
                    return;

                if (crud == CRUD.Insertar)
                    RegistrarAsociarConceptoTesoreria();
                if (crud == CRUD.Actualizar)
                    ActualizarAsociarConceptoTesoreria();
                ListarAsociarConceptoTesoreria();
                DisableEnableControls(false);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void RegistrarAsociarConceptoTesoreria()
        {
            int idAsociar = BLComision.ValidarExistenciaAsociarConceptoTesoreria(txtCodigo.Text.ToInt32())
                ? BLComision.ObtenerCorrelativoIdAsociar()
                : txtCodigo.Text.ToInt32();
            string descripcion = txtDescripcion.Text.Trim();
            if (!BLComision.InsertarAsociarConceptoTesoreria(idAsociar, descripcion, 0, UsuarioSistema.Cod_usu))
            {
                _ = MessageBox.Show("Error al guardar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ActualizarAsociarConceptoTesoreria()
        {
            int idAsociar = txtCodigo.Text.ToInt32();
            string descripcion = txtDescripcion.Text.Trim();
            if (!BLComision.ActualizarAsociarConceptoTesoreria(idAsociar, descripcion, UsuarioSistema.Cod_usu))
            {
                _ = MessageBox.Show("Error al guardar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidarGuardar()
        {
            if (txtCodigo.Text.Length == 0)
            {
                _ = MessageBox.Show("Este registro no tiene un código, cierre el formulario y vuelva a abrir", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDescripcion.Text.Length == 0)
            {
                _ = MessageBox.Show("Ingrese la descripción", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void DgvTipoAsociacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    int idAsociar = txtCodigo.Text.ToInt32();
                    if (!BLComision.EliminarAsociarConceptoTesoreria(idAsociar))
                    {
                        _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ListarAsociarConceptoTesoreria();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            crud = CRUD.None;
            DisableEnableControls(false);
        }

        private void DgvTipoAsociacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipoAsociacion.CurrentRow != null)
            {
                txtCodigo.Text = dgvTipoAsociacion.CurrentRow.Cells["ID_ASOCIAR"].Value.ToString();
                txtDescripcion.Text = dgvTipoAsociacion.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            }
        }

        private void CboTipoAsociar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTipoAsociar.SelectedValue != null)
            {
                ListarAsociarConceptoTesoreriaXIdAsociar();
            }
        }

        private void ListarAsociarConceptoTesoreriaXIdAsociar()
        {
            try
            {
                DataTable lstMaestroConcepto = MaestroConceptoBLL.Instancia.ListarSegundoNivel().AsEnumerable().OrderBy(x => x.Field<string>("DesCorta")).CopyToDataTable();
                DataTable lstMaestroConceptoPadre = MaestroConceptoBLL.Instancia.ListarPrimerNivel();
                DataTable dt = BLComision.ListarAsociarConceptoTesoreriaXIdAsociar(cboTipoAsociar.SelectedValue.ToInt32());
                DataRow conceptoPadre;
                string descConceptoPadre;
                dgvConceptoAsoc.Rows.Clear();
                foreach (DataRow item in lstMaestroConcepto.Rows)
                {
                    if (dt.AsEnumerable().SingleOrDefault(x => x.Field<int>("ID_CONCEPTO") == item["Id"].ToInt32()) != null)
                    {
                        conceptoPadre = lstMaestroConceptoPadre.AsEnumerable().SingleOrDefault(x => x.Field<int>("Id") == item["IdConceptoPadre"].ToInt32());
                        descConceptoPadre = conceptoPadre != null ? conceptoPadre["DesCorta"]?.ToString() : string.Empty;
                        _ = dgvConceptoAsoc.Rows.Add(item["Id"], item["Codigo"], item["DesCorta"], descConceptoPadre);
                    }
                }
                EliminarConceptosRegistrados(dt);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        /// <summary>
        /// Elimina conceptos o subdestinos que ya han sido registrado del dgvConcepto para evitar que figure en la lista
        /// ya que se puede pensar que no esta registrado
        /// </summary>
        /// <param name="lista">Lista de conceptos ya registrados</param>
        private void EliminarConceptosRegistrados(DataTable dt)
        {
            if (dgvConcepto.Rows.Count == 0)
                return;
            if (dt == null)
                return;
            foreach (DataRow item in dt.Rows)
            {
                DataGridViewRow row = dgvConcepto.Rows.Cast<DataGridViewRow>().SingleOrDefault(x => x.Cells["Id"].Value.ToInt32() == item["ID_CONCEPTO"].ToInt32());
                if (row != null)
                    dgvConcepto.Rows.Remove(row);
            }
        }

        #region -- Arrastrar Fila de dgvConcepto -> dgvConcepto2 --
        private void DgvConcepto_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = dgvConcepto.HitTest(e.X, e.Y);
            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                if (dgvConcepto.CurrentRow != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DgvConcepto_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)
                    && dgvConcepto.CurrentRow != null)
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    _ = dgvConcepto.DoDragDrop(dgvConcepto.CurrentRow, DragDropEffects.Move);
                }
            }
        }

        private void DgvConcepto2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvConcepto2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvConcepto2_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvConceptoAsoc.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Move)
            {
                //> var hittest = dgvConcepto2.HitTest(clientPoint.X, clientPoint.Y);
                if (e.Data.GetData(typeof(DataGridViewRow)) is DataGridViewRow rw)
                {
                    if (rw.DataGridView.Name == dgvConceptoAsoc.Name)
                        return;

                    var dgvInfo = dgvConceptoAsoc.HitTest(clientPoint.X, clientPoint.Y);
                    if (dgvInfo.RowIndex > -1 && dgvInfo.ColumnIndex > -1)
                    {
                        dgvConceptoAsoc.Rows.Insert(dgvInfo.RowIndex, rw.CloneWithValues());
                        dgvConcepto.Rows.Remove(rw);
                        RegistrarConceptosAsociados(rw);
                    }
                    else
                    {
                        _ = dgvConceptoAsoc.Rows.Add(rw.CloneWithValues());
                        dgvConcepto.Rows.Remove(rw);
                        RegistrarConceptosAsociados(rw);
                    }
                }
            }
        }
        #endregion

        #region -- Arrastrar Fila de dgvConcepto2 -> dgvConcepto --
        private void DgvConcepto2_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = dgvConcepto.HitTest(e.X, e.Y);
            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                if (dgvConcepto.CurrentRow != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DgvConcepto2_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)
                    && dgvConceptoAsoc.CurrentRow != null)
                {
                    // Proceed with the drag and drop, passing in the list item.
                    _ = dgvConceptoAsoc.DoDragDrop(dgvConceptoAsoc.CurrentRow, DragDropEffects.Move);
                }
            }
        }

        private void DgvConcepto_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvConcepto_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DgvConcepto_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgvConcepto.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Move)
            {
                //> var hittest = dgvConcepto2.HitTest(clientPoint.X, clientPoint.Y);
                if (e.Data.GetData(typeof(DataGridViewRow)) is DataGridViewRow rw)
                {
                    if (rw.DataGridView.Name == dgvConcepto.Name)
                        return;

                    var dgvInfo = dgvConcepto.HitTest(clientPoint.X, clientPoint.Y);
                    if (dgvInfo.RowIndex > -1 && dgvInfo.ColumnIndex > -1)
                    {
                        dgvConcepto.Rows.Insert(dgvInfo.RowIndex, rw.CloneWithValues());
                        dgvConceptoAsoc.Rows.Remove(rw);
                        EliminarConceptosAsociados(rw);
                    }
                    else
                    {
                        _ = dgvConcepto.Rows.Add(rw.CloneWithValues());
                        dgvConceptoAsoc.Rows.Remove(rw);
                        EliminarConceptosAsociados(rw);
                    }
                }
            }
        }
        #endregion

        private void RegistrarConceptosAsociados(DataGridViewRow row)
        {
            if (!ValidarRegistrar())
                return;
            int idAsociar = cboTipoAsociar.SelectedValue.ToInt32();
            string descripcion = cboTipoAsociar.Text;
            int idConcepto = row.Cells[0].Value.ToInt32();
            if (!BLComision.InsertarAsociarConceptoTesoreria(idAsociar, descripcion, idConcepto, UsuarioSistema.Cod_usu))
            {
                _ = MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidarRegistrar()
        {
            if (!int.TryParse(cboTipoAsociar.SelectedValue?.ToString(), out _))
            {
                _ = MessageBox.Show("Primero seleccione una categoría a la cual asociar los conceptos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void EliminarConceptosAsociados(DataGridViewRow row)
        {
            if (!ValidarEliminar())
                return;

            int idAsociar = cboTipoAsociar.SelectedValue.ToInt32();
            int idConcepto = row.Cells[0].Value.ToInt32();
            if (!BLComision.EliminarAsociarConceptoTesoreria(idAsociar, idConcepto))
            {
                _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidarEliminar()
        {
            if (!int.TryParse(cboTipoAsociar.SelectedValue?.ToString(), out _))
            {
                _ = MessageBox.Show("Primero seleccione una categoría a la cual asociar los conceptos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                CargarCombobox();
            }
        }
    }
}
