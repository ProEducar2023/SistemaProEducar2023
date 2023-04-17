using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Presentacion.HELPERS.GenericMethod;
using static Presentacion.HELPERS.FormatDataGridViewColumns;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using System.Linq;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmComisiones : Form
    {
        private readonly personaBLL BLMaestroPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();
        private readonly comisionesBLL BLComisiones = new comisionesBLL();
        private readonly institucionesBLL BLInstitucion = new institucionesBLL();

        public FrmComisiones()
        {
            InitializeComponent();
        }

        private delegate void DelCargarDataGridView(DataView dv);
        private delegate void DelInvocarMetodo();

        private const string COD_NIVEL_DIR_NACIONAL = "01";
        private const string COD_NIVEL_DIR_VENTAS = "02";
        private const string COD_NIVEL_SUPERVISOR = "03";
        private const string COD_NIVEL_VENDEDOR = "04";
        private const string COL_NAME_NRO_CUOTA = "NRO_CUOTA";
        private const string CELL_VALUE_NOTHING = "-";
        private const string NAME_COLUMN1 = "IMPORTE";
        private const string NAME_COLUMN2 = "SI_COMISIONA";
        private const string NAME_COLUMN3 = "PORCENTAJE";
        private const string NAME_COLUMN4 = "BASE_IMPONIBLE";
        private const int ID_TIPO_COMISION_PORCENTAJE = 2;
        private const int MODIFICO_IMPORTE = 1;
        private const int MODIFICO_PORCENTAJE = 2;
        private const int MODIFICO_BASE_IMPONIBLE = 2;

        HELPERS.Forms.FrmLoading frmLoading;
        private TreeNode trNode;
        private string codDirNacional, codDirVentas, codSupervisor, codNivelMostrar, codPerMostrar;
        private DateTime fechaVigencia;
        private string valorInicial;
        private decimal importe;
        private int tipoModificacion;

        private void FrmComisiones_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarNivel();
            CargarPersonaXNivel();
            ListarComisiones();
            StyleDgvComision();
            ExpandirNodos();
            CargarNivelVenta();
            CargarPersonaXNivelVenta();
            CargarInstitucion();
        }

        private void StartControls()
        {
            btnNuevaComision.StyleButtonFlat();
            btnReporte.StyleButtonFlat();
            btnConfigurarComision.StyleButtonFlat();
            btnEliminar.StyleButtonFlat();

            cboNivelVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPersona.DropDownStyle = ComboBoxStyle.DropDownList;
            cboInstitucion.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvComisionConfNivelVenta.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                DataGridViewSelectionMode.CellSelect);
            dgvComisionConfInstitu.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize, DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells,
                DataGridViewSelectionMode.CellSelect);
        }

        private void CargarNivel()
        {
            DataTable dt = BLNivel.obtenerNivelBLL();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    _ = trvPersonas.Nodes.Add(new TreeNode
                    {
                        Tag = row["COD_NIVEL"].ToString(),
                        Text = row["DESC_NIVEL"].ToString(),
                        BackColor = Color.Teal,
                        ForeColor = Color.White
                    });
                }
            }
        }

        private void CargarPersonaXNivel()
        {
            DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaProgNivel();
            TreeNodeCollection lstNodo = trvPersonas.Nodes;
            foreach (DataRow row in dt.Rows)
            {
                foreach (TreeNode nodo in lstNodo)
                {
                    if (nodo.Tag.ToString() == row["COD_NIVEL"].ToString())
                    {
                        _ = nodo.Nodes.Add(new TreeNode
                        {
                            Tag = row["COD_PER"].ToString(),
                            Text = row["DESC_PER"].ToString()
                        });
                        break;
                    }
                }
            }
        }

        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL().Select("COD_NIVEL IN ('01', '02', '03')").CopyToDataTable();
            cboNivelVenta.ValueMember = "COD_NIVEL";
            cboNivelVenta.DisplayMember = "DESC_NIVEL";
            cboNivelVenta.DataSource = dt;
        }

        private void CargarPersonaXNivelVenta()
        {
            if (cboNivelVenta.SelectedValue != null)
            {
                DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
                cboPersona.ValueMember = "COD_PER";
                cboPersona.DisplayMember = "DESC_PER";
                cboPersona.DataSource = dt;
            }
        }

        private void CargarInstitucion()
        {
            DataTable dt = BLInstitucion.obtenerInstitucionesBLL();
            cboInstitucion.DataSource = dt;
            cboInstitucion.ValueMember = "COD_INST";
            cboInstitucion.DisplayMember = "DESC_CORTA";
        }

        private void InvisibleColumn(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvComision.Name)
            {
                if (dataGrid.Columns.Count > 0)
                {
                    dataGrid.InvisibleColumna2("COD_PER");
                    dataGrid.InvisibleColumna2("COD_NIVEL");
                    dataGrid.InvisibleColumna2("ID_TIPO_COMISION");
                    dataGrid.InvisibleColumna2("ID_TIPO_PLLA");
                }
            }

            if (dataGrid.Name == dgvComisionConfNivelVenta.Name)
            {
                string[] columnas = { "ID_COMISION_CONF", "COD_NIVEL_VEND", "COD_VEND" };
                dataGrid.InvisibleColumna(columnas);
            }

            if (dataGrid.Name == dgvComisionConfInstitu.Name)
            {
                string[] columnas = { "ID_COMISION_CONF", "COD_NIVEL_VEND", "COD_VEND", "ID_TIPO_COMISION", "SI_COMISIONA" };
                dataGrid.InvisibleColumna(columnas);
            }
        }

        private void RenamerHeaderText(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvComision.Name)
            {
                if (dataGrid.Columns.Count > 0)
                {
                    dataGrid.Columns["DESC_NIVEL"].HeaderText = "NIVEL";
                    dataGrid.Columns["DESC_PER"].HeaderText = "NOMBRE PERSONA";
                    dataGrid.Columns["DESC_TIPO_COMISION"].HeaderText = "TIPO COMISIÓN";
                    dataGrid.Columns["NRO_CUOTA"].HeaderText = "N° CUOTA";
                    dataGrid.Columns["COD_TIPO_PLLA"].HeaderText = "TIPO VENTA";
                }
            }

            if (dataGrid.Name == dgvComisionConfNivelVenta.Name)
            {
                if (dataGrid.Columns.Count > 0)
                {
                    dataGrid.Columns["DESC_NIVEL"].HeaderText = "NIVEL";
                    dataGrid.Columns["DESC_VEND"].HeaderText = "NOMBRE PERSONA";
                    dataGrid.Columns["DESC_TIPO_COMISION"].HeaderText = "TIPO COMISIÓN";
                    dataGrid.Columns["NRO_CUOTA"].HeaderText = "N° CUOTA";
                    dataGrid.Columns["COD_TIPO_PLLA"].HeaderText = "TIPO VENTA";
                    dataGrid.Columns["SI_COMISIONA"].HeaderText = "¿COMISIONA?";
                }
            }

            if (dataGrid.Name == dgvComisionConfInstitu.Name)
            {
                if (dataGrid.Columns.Count > 0)
                {
                    dataGrid.Columns["DESC_NIVEL"].HeaderText = "NIVEL";
                    dataGrid.Columns["DESC_VEND"].HeaderText = "NOMBRE PERSONA";
                    dataGrid.Columns["DESC_TIPO_COMISION"].HeaderText = "TIPO COMISIÓN";
                    dataGrid.Columns["NRO_CUOTA"].HeaderText = "N° CUOTA";
                    dataGrid.Columns["COD_TIPO_PLLA"].HeaderText = "TIPO VENTA";
                    dataGrid.Columns["BASE_IMPONIBLE"].HeaderText = "BASE IMPONIBLE";
                    dataGrid.Columns["PORCENTAJE"].HeaderText = " % ";
                    dataGrid.Columns["SI_COMISIONA"].HeaderText = "¿COMISIONA?";
                }
            }
        }

        private void WithColumn(DataGridView dataGrid)
        {
            if (dataGrid == null || dataGrid.Columns.Count == 0)
                return;
            if (dataGrid.Name == dgvComision.Name)
            {
                dataGrid.Columns["DESC_NIVEL"].Width = 100;
                dataGrid.Columns["DESC_PER"].Width = 150;
                dataGrid.Columns["DESC_TIPO_COMISION"].Width = 70;
                dataGrid.Columns["NRO_CUOTA"].Width = 50;
                dataGrid.Columns["COD_TIPO_PLLA"].Width = 50;
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    if (DateTime.TryParse(column.Name, out _))
                    {
                        column.Width = 65;
                    }
                }
            }

            if (dataGrid.Name == dgvComisionConfNivelVenta.Name)
            {
                dataGrid.Columns["DESC_NIVEL"].Width = 100;
                dataGrid.Columns["DESC_VEND"].Width = 150;
                dataGrid.Columns["DESC_TIPO_COMISION"].Width = 70;
                dataGrid.Columns["NRO_CUOTA"].Width = 50;
                dataGrid.Columns["IMPORTE"].Width = 80;
                dataGrid.Columns["COD_TIPO_PLLA"].Width = 50;
            }

            if (dataGrid.Name == dgvComisionConfInstitu.Name)
            {
                dataGrid.Columns["DESC_NIVEL"].Width = 100;
                dataGrid.Columns["DESC_VEND"].Width = 150;
                dataGrid.Columns["DESC_TIPO_COMISION"].Width = 70;
                dataGrid.Columns["NRO_CUOTA"].Width = 50;
                dataGrid.Columns["BASE_IMPONIBLE"].Width = 70;
                dataGrid.Columns["IMPORTE"].Width = 80;
                dataGrid.Columns["PORCENTAJE"].Width = 60;
                dataGrid.Columns["COD_TIPO_PLLA"].Width = 50;
            }
        }

        private void ReadOnlyColumns(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvComision.Name)
            {
                foreach (DataGridViewColumn column in dataGrid.Columns)
                {
                    if (DateTime.TryParse(column.Name, out _))
                        column.ReadOnly = false;
                    else
                        column.ReadOnly = true;
                }
            }

            if (dataGrid.Name == dgvComisionConfNivelVenta.Name)
            {
                dataGrid.ColumnsReadOnlyExcept(new string[] { "IMPORTE", "SI_COMISIONA" });
            }

            if (dataGrid.Name == dgvComisionConfInstitu.Name)
            {
                dataGrid.ColumnsReadOnlyExcept(new string[] { "IMPORTE", "PORCENTAJE", "BASE_IMPONIBLE", "SI_COMISIONA" });
            }
        }

        private void StyleDgvComision()
        {
            dgvComision.Font = new Font("Microsoft Sans Serif", 6.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvComision.AlingHeaderTextCenter();
            dgvComision.Style5(false, false, false, false, false, DataGridViewTriState.True, DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                DataGridViewTriState.True, DataGridViewAutoSizeRowsMode.AllCells, DataGridViewSelectionMode.CellSelect);
            dgvComision.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvComision.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void FormaterDataGridView()
        {
            InvisibleColumn(dgvComision);
            RenamerHeaderText(dgvComision);
            WithColumn(dgvComision);
            ReadOnlyColumns(dgvComision);
            ColorHeaderTextDgvComision();
            if (dgvComision != null && dgvComision.Columns.Count > 0)
            {
                dgvComision.Columns["COD_TIPO_PLLA"].Frozen = true;
            }
            dgvComision.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dgvComision.ColumnasAlinear(new string[] { "NRO_CUOTA", "COD_TIPO_PLLA" }, DataGridViewContentAlignment.MiddleCenter);
        }

        private void ColorHeaderTextDgvComision()
        {
            foreach (DataGridViewColumn column in dgvComision.Columns)
            {
                if (DateTime.TryParse(column.Name, out _))
                {
                    column.HeaderCell.Style.BackColor = Color.Teal;
                    column.HeaderCell.Style.ForeColor = Color.White;
                }
                else
                    column.HeaderCell.Style.BackColor = Color.DarkSeaGreen;
            }
        }

        private void AlignTextContentCell(DataGridView dataGrid)
        {
            if (dataGrid.Name == dgvComisionConfNivelVenta.Name)
            {
                string[] columnas = { "NRO_CUOTA", "COD_TIPO_PLLA" };
                dataGrid.ColumnasAlinear(columnas, DataGridViewContentAlignment.MiddleCenter);
            }

            if (dataGrid.Name == dgvComisionConfInstitu.Name)
            {
                string[] columnas = { "NRO_CUOTA", "COD_TIPO_PLLA", "PORCENTAJE" };
                dataGrid.ColumnasAlinear(columnas, DataGridViewContentAlignment.MiddleCenter);
            }

            dataGrid.AlignmentDecimalColumns();
        }

        private void ListarComisiones(string codNivel1 = "00", string codPer1 = "", string codNivel2 = "00", string codNivelMostrar = "00", string codPerMostrar = "00")
        {
            try
            {
                string codTipoPlanilla = ObtenerCodTipoPlanilla(tbComisiones);
                DataTable dt = BLComisiones.ListarComisiones(codNivel1, codPer1, codNivel2, codNivelMostrar, codPerMostrar, codTipoPlanilla);
                DataTable dt2 = dgvComision.Rows.Count > 0 ? dgvComision.ConvertToDataTable() : null;
                if (dt2 != null && dt2.Rows.Count > 0)
                    dt.Merge(dt2, true, MissingSchemaAction.Ignore);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //> RellenarValoresVaciosNulos(dt);
                    DataView dv = new DataView(dt)
                    {
                        Sort = "COD_NIVEL, DESC_PER"
                    };
                    CargarData(dv);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void CargarData(DataView dv)
        {
            if (InvokeRequired)
            {
                DelCargarDataGridView del = new DelCargarDataGridView(CargarData);
                object[] parameter = { dv };
                BeginInvoke(del, parameter);
            }
            else
            {
                //> Application.DoEvents();
                dgvComision.CellFormatting -= DgvComision_CellFormatting;
                dgvComision.Columns.Clear();
                dgvComision.AddRangeColumnsDataGridView(dv.ToTable(), true);
                dgvComision.AddRangeRowsDataGridView(dv.ToTable());
                FormaterDataGridView();
                PintarColorFila();
                dgvComision.CellFormatting += DgvComision_CellFormatting;
            }
        }

        private void ExpandirNodos()
        {
            foreach (TreeNode item in trvPersonas.Nodes)
            {
                item.Expand();
            }
            trvPersonas.Nodes[0].EnsureVisible();
        }

        private void BtnNuevaComision_Click(object sender, EventArgs e)
        {
            FrmRegistrarComision frmRegComision = new FrmRegistrarComision()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            _ = frmRegComision.ShowDialog();
            CargarTodosDatosComision();
        }

        private void TrvPersonas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            FiltroEnCascada(e);
        }

        private async void FiltroEnCascada(TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                HELPERS.Forms.FrmLoading frmLoading = new HELPERS.Forms.FrmLoading()
                {
                    Owner = this,
                    ShowInTaskbar = false
                };
                frmLoading.Show();
                codDirNacional = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_DIR_NACIONAL));
                codDirVentas = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_DIR_VENTAS));
                codSupervisor = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_SUPERVISOR));
                codNivelMostrar = e.Node.Parent != null ? e.Node.Parent.Tag.ToString() : e.Node.Tag.ToString();
                codPerMostrar = e.Node.Parent != null ? e.Node.Tag.ToString() : "0";

                codDirNacional = e.Node.Tag.ToString() == COD_NIVEL_DIR_NACIONAL ? COD_NIVEL_DIR_NACIONAL : codDirNacional;
                codDirVentas = e.Node.Tag.ToString() == COD_NIVEL_DIR_VENTAS ? COD_NIVEL_DIR_VENTAS : codDirVentas;
                codSupervisor = e.Node.Tag.ToString() == COD_NIVEL_SUPERVISOR ? COD_NIVEL_SUPERVISOR : codSupervisor;
                if (e.Node.Parent is null)
                    RemoveFilasDgvComision(e);
                EstablecerCheckNodosPadre(e);
                EstablecerCheckNodosHijoXNodoPadre(e);
                await Task.Run(() => ListarComisiones(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar, codPerMostrar));
                ListarNodoVendedoresXNodosPadre();
                frmLoading.Close();
            }
            else
            {
                RemoveFilasDgvComision(e);
                EstablecerCheckNodosPadre(e);
                EstablecerCheckNodosHijoXNodoPadre(e);
                ListarNodoVendedoresXNodosPadre();
            }
        }

        private void EstablecerCheckNodosHijoXNodoPadre(TreeViewEventArgs e)
        {
            trvPersonas.AfterCheck -= TrvPersonas_AfterCheck; //> Quitamos el evento para que al cambiar el estado check de los nodos no se active
            e.Node.Nodes.Cast<TreeNode>().ToList().ForEach(x => x.Checked = e.Node.Checked);
            trvPersonas.AfterCheck += TrvPersonas_AfterCheck; //> Agregamos el evento
        }

        private void EstablecerCheckNodosPadre(TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                List<TreeNode> nodosHijo = e.Node.Parent.Nodes.Cast<TreeNode>().Where(x => x.Checked == false).ToList();
                trvPersonas.AfterCheck -= TrvPersonas_AfterCheck;
                e.Node.Parent.Checked = !nodosHijo.Any();
                trvPersonas.AfterCheck += TrvPersonas_AfterCheck;
            }
        }

        private void RemoveFilasDgvComision(TreeViewEventArgs e)
        {
            if (e.Node.Parent is null)
            {
                var lista = dgvComision.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells["COD_NIVEL"].Value.ToString() == e.Node.Tag.ToString()).ToList();

                foreach (var item in lista)
                {
                    dgvComision.Rows.Remove(item);
                }
            }
            else
            {
                var lista = dgvComision.Rows.Cast<DataGridViewRow>()
                     .Where(x => x.Cells["COD_PER"].Value.ToString() == e.Node.Tag.ToString()
                     && x.Cells["COD_NIVEL"].Value.ToString() == e.Node.Parent.Tag.ToString()).ToList();

                foreach (var item in lista)
                {
                    dgvComision.Rows.Remove(item);
                }
            }
        }

        private void ListarNodoVendedoresXNodosPadre()
        {
            TreeNode nextNodo = trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_VENDEDOR);
            if (nextNodo != null)
            {
                string odDirNacional = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_DIR_NACIONAL));
                string codDirVentas = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_DIR_VENTAS));
                string codSupervisor = ObtenerCodigoNodo(trvPersonas.Nodes.Cast<TreeNode>().Single(x => x.Tag.ToString() == COD_NIVEL_SUPERVISOR));
                string codNivelMostrar = nextNodo.Tag.ToString();

                DataTable dt = BLMaestroPersona.ObtenerPersonaNivelVentaHijoXPadre(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar);
                List<TreeNode> lstNodoEliminar = new List<TreeNode>();
                DataRow rw;
                TreeNode tr;
                foreach (TreeNode node in nextNodo.Nodes)
                {
                    rw = dt.Rows.Cast<DataRow>().SingleOrDefault(x => x["COD_PER"].ToString() == node.Tag.ToString());
                    if (rw is null)
                        lstNodoEliminar.Add(node);
                }

                foreach (DataRow row in dt.Rows)
                {
                    tr = nextNodo.Nodes.Cast<TreeNode>().SingleOrDefault(x => x.Tag.ToString() == row["COD_PER"].ToString());
                    if (tr is null)
                    {
                        _ = nextNodo.Nodes.Add(new TreeNode
                        {
                            Tag = row["COD_PER"],
                            Text = row["DESC_PER"].ToString()
                        });
                    }
                }

                RemoveNodos(nextNodo, lstNodoEliminar);
                RemoveVendedoresDgvComision(lstNodoEliminar);
            }
        }

        private void RemoveNodos(TreeNode nextNodo, List<TreeNode> lstNodoEliminar)
        {
            foreach (TreeNode item in lstNodoEliminar)
            {
                nextNodo.Nodes.Remove(item);
            }
        }

        private void RemoveVendedoresDgvComision(List<TreeNode> lstNodoEliminar)
        {
            List<DataGridViewRow> lstRow = new List<DataGridViewRow>();
            foreach (TreeNode item in lstNodoEliminar)
            {
                lstRow.AddRange(dgvComision.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["COD_PER"].Value.ToString() == item.Tag.ToString()
                            && x.Cells["COD_NIVEL"].Value.ToString() == COD_NIVEL_VENDEDOR).ToList());
            }

            if (lstRow.Any())
            {
                foreach (DataGridViewRow row in lstRow)
                {
                    dgvComision.Rows.Remove(row);
                }
            }
        }

        private string ObtenerCodigoNodo(TreeNode treeNode)
        {
            string codPer = string.Empty;
            if (treeNode != null)
            {
                foreach (TreeNode item in treeNode.Nodes)
                {
                    if (item.Checked)
                    {
                        codPer += item.Tag.ToString() + ",";
                    }
                }
                codPer = string.IsNullOrEmpty(codPer) ? treeNode.Tag.ToString() : codPer;
            }
            return codPer;
        }

        private void TrvPersonas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    trNode = e.Node.Clone() as TreeNode;
                    ContextMenuStrip menu = new ContextMenuStrip();
                    _ = menu.Items.Add("Registrar").Name = "01";
                    menu.Click += MenuItem_Click;
                    e.Node.ContextMenuStrip = menu;
                    e.Node.ContextMenuStrip.Show();
                }
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarComision frmRegistrar = new FrmRegistrarComision()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frmRegistrar.btnGrabar.Click += FrmRegistrarComisionBtnGrabar_Click;
            frmRegistrar.MostrarNodoSeleccionado(trNode);
            _ = frmRegistrar.ShowDialog();
        }

        private void FrmRegistrarComisionBtnGrabar_Click(object sender, EventArgs e)
        {
            CargarTodosDatosComision();
        }

        private void DgvComision_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (DateTime.TryParse(dgvComision.Columns[e.ColumnIndex].Name, out _))
            {
                valorInicial = dgvComision[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
            }
        }

        private void DgvComision_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DateTime.TryParse(dgvComision.Columns[e.ColumnIndex].Name, out _))
                {
                    if (dgvComision[e.ColumnIndex, e.RowIndex].Value.ToString() != CELL_VALUE_NOTHING)
                    {
                        ActualizarImporteCell(e);
                    }
                    else
                    {
                        EliminarComisionCell(e);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        dgvComision[e.ColumnIndex, e.RowIndex].Value = "0";
                        _ = MessageBox.Show("Este registro ya existe, no se puede insertar duplicados", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                    ex.PrintException();
            }
        }

        private void ActualizarImporteCell(DataGridViewCellEventArgs e)
        {
            if (!decimal.TryParse(dgvComision[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
            {
                dgvComision[e.ColumnIndex, e.RowIndex].Value = valorInicial;
                _ = MessageBox.Show("Digite valores numericos o decimales", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Convert.ToDecimal(dgvComision[e.ColumnIndex, e.RowIndex].Value) < 0)
            {
                dgvComision[e.ColumnIndex, e.RowIndex].Value = valorInicial;
                _ = MessageBox.Show("Los valores digitados no deben ser negativos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComisionTo comTo = ObtenerComisionTo(e);
            _ = BLComisiones.ActualizarImpoteComisionMain(comTo)
                ? MessageBox.Show("Actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                : MessageBox.Show("Error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarComisionCell(DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(valorInicial) && valorInicial != CELL_VALUE_NOTHING)
            {
                try
                {
                    if (MessageBox.Show("Ud. a digitado un signo guión(-), esto significa que se va eliminar la comisión de la fecha y cuota digitada \n" +
                        "¿Esta Seguro de guardar los cambios?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ComisionTo comTo = ObtenerComisionToEliminar(e);
                        _ = BLComisiones.EliminarSoloUnaComision(comTo)
                            ? MessageBox.Show("Actualizado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        dgvComision[e.ColumnIndex, e.RowIndex].Value = valorInicial;
                }
                catch (Exception ex)
                {
                    ex.PrintException2();
                }
            }
        }

        private ComisionTo ObtenerComisionTo(DataGridViewCellEventArgs e)
        {
            return new ComisionTo
            {
                LstMaestroPersonaTo = ObtenerMaestroPersona(),
                PersonaTo = new personaTo { COD_PER = dgvComision.CurrentRow.Cells["COD_PER"].Value.ToString() },
                NivelTo = new nivelTo
                {
                    COD_NIVEL = dgvComision.CurrentRow.Cells["COD_NIVEL"].Value.ToString()
                },
                NroCuota = dgvComision.CurrentRow.Cells["NRO_CUOTA"].Value.ToString(),
                FechaIniVigencia = Convert.ToDateTime(dgvComision.Columns[e.ColumnIndex].Name),
                FechaFinVigencia = null,
                Importe = Convert.ToDecimal(dgvComision[e.ColumnIndex, e.RowIndex].Value),
                Porcentaje = 0,
                BaseImponible = 0,
                TipoComisionTo = new TipoComisionTo
                {
                    IdTipoComision = Convert.ToInt32(dgvComision.CurrentRow.Cells["ID_TIPO_COMISION"].Value)
                },
                LstTipoPlanillaTo = ObtenerTipoVentaSeleccionados(),
                TipoPlanillaTo = new tipoPlanillaCreacionTo
                {
                    CODIGO = dgvComision.CurrentRow.Cells["ID_TIPO_PLLA"].Value.ToString(),
                    COD_TIPO_PLLA = dgvComision.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString()
                },
                UsuarioCrea = UsuarioSistema.Cod_usu
            };
        }

        private ComisionTo ObtenerComisionToEliminar(DataGridViewCellEventArgs e)
        {
            return new ComisionTo
            {
                PersonaTo = new personaTo { COD_PER = dgvComision.CurrentRow.Cells["COD_PER"].Value.ToString() },
                NivelTo = new nivelTo
                {
                    COD_NIVEL = dgvComision.CurrentRow.Cells["COD_NIVEL"].Value.ToString()
                },
                NroCuota = dgvComision.CurrentRow.Cells["NRO_CUOTA"].Value.ToString(),
                FechaIniVigencia = Convert.ToDateTime(dgvComision.Columns[e.ColumnIndex].Name),
                TipoComisionTo = new TipoComisionTo
                {
                    IdTipoComision = Convert.ToInt32(dgvComision.CurrentRow.Cells["ID_TIPO_COMISION"].Value)
                },
                TipoPlanillaTo = new tipoPlanillaCreacionTo
                {
                    CODIGO = dgvComision.CurrentRow.Cells["ID_TIPO_PLLA"].Value.ToString(),
                    COD_TIPO_PLLA = dgvComision.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString()
                }
            };
        }

        private List<personaTo> ObtenerMaestroPersona()
        {
            List<personaTo> lista = new List<personaTo>
            {
                new personaTo
                {
                    COD_PER = dgvComision.CurrentRow.Cells["COD_PER"].Value.ToString()
                }
            };
            return lista;
        }

        private List<tipoPlanillaCreacionTo> ObtenerTipoVentaSeleccionados()
        {
            List<tipoPlanillaCreacionTo> lista = new List<tipoPlanillaCreacionTo>
            {
                new tipoPlanillaCreacionTo
                {
                    CODIGO = dgvComision.CurrentRow.Cells["ID_TIPO_PLLA"].Value.ToString(),
                    COD_TIPO_PLLA = dgvComision.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString()
                }
            };
            return lista;
        }

        private void DgvComision_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        private void DgvComision_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (DateTime.TryParse(dgvComision.Columns[e.ColumnIndex].Name, out _))
                {
                    if (decimal.TryParse(e.Value?.ToString(), out _))
                    {
                        e.Value = e.Value.FormatoMiles();
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        e.Value = CELL_VALUE_NOTHING;
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void RdbPP_Click(object sender, EventArgs e)
        {
            CargarTodosDatosComision();
        }

        private void DgvComision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar este registro?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ComisionTo comision = ObtenerComisionToEliminar();
                        _ = BLComisiones.EliminarComision(comision)
                            ? MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            : MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CargarTodosDatosComision();
                    }
                }
                catch (Exception ex)
                {
                    ex.PrintException2();
                }
            }
        }

        private void DgvComision_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvComision.Columns[e.ColumnIndex].Name == COL_NAME_NRO_CUOTA)
                {
                    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem
                    {
                        Text = "Eliminar",
                    };
                    toolStripItem1.Click += EliminarXNroCuota_Click;
                    MostrarContextMenuStripColumn(e, toolStripItem1);
                }
                else if (DateTime.TryParse(dgvComision.Columns[e.ColumnIndex].Name, out DateTime fechaVigencia))
                {
                    ToolStripMenuItem toolStripItem1 = new ToolStripMenuItem
                    {
                        Text = "Eliminar",
                    };
                    toolStripItem1.Click += EliminarXFechaVigencia;
                    this.fechaVigencia = fechaVigencia;
                    MostrarContextMenuStripColumn(e, toolStripItem1);
                }
            }
        }

        private void MostrarContextMenuStripColumn(DataGridViewCellMouseEventArgs e, ToolStripMenuItem toolStrip)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            dgvComision.Columns[e.ColumnIndex].ContextMenuStrip = menu;
            dgvComision.Columns[e.ColumnIndex].ContextMenuStrip.Items.Add(toolStrip);
            dgvComision.Columns[e.ColumnIndex].ContextMenuStrip.Show(Cursor.Position);
        }

        private void EliminarXNroCuota_Click(object sender, EventArgs e)
        {
            List<ComisionTo> lstComisionTo = ObtenerComisionEliminarXNroCuota();
            FrmEliminarComision frmEliminar = new FrmEliminarComision(lstComisionTo)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frmEliminar.Text = "Eliminar Comision X Nro de Cuota";
            frmEliminar.btnEliminar.Click += FrmEliminarComisionBtnEliminar_Click;
            _ = frmEliminar.ShowDialog();
        }

        private void EliminarXFechaVigencia(object sender, EventArgs e)
        {
            try
            {
                if (dgvComision.Rows.Count > 0)
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar todas las comisiones de esta fecha : " + fechaVigencia.ToShortDateString() + "?", "MESSAGE",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        List<ComisionTo> lstComisionTo = ObtenerComisionEliminarXNroCuota();
                        int result = BLComisiones.EliminarComisionXFechaVigencia(lstComisionTo, fechaVigencia);
                        _ = MessageBox.Show("Total registros eliminados: " + result.ToString(), "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTodosDatosComision();
                    }
                }
                else
                {
                    _ = MessageBox.Show("No hay datos en la lista para eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private void FrmEliminarComisionBtnEliminar_Click(object sender, EventArgs e)
        {
            CargarTodosDatosComision();
        }

        private List<ComisionTo> ObtenerComisionEliminarXNroCuota()
        {
            List<ComisionTo> lista = new List<ComisionTo>();
            foreach (DataGridViewRow row in dgvComision.Rows)
            {
                lista.Add(new ComisionTo
                {
                    PersonaTo = new personaTo { COD_PER = row.Cells["COD_PER"].Value.ToString() },
                    NivelTo = new nivelTo { COD_NIVEL = row.Cells["COD_NIVEL"].Value.ToString() },
                    TipoPlanillaTo = new tipoPlanillaCreacionTo
                    {
                        CODIGO = row.Cells["ID_TIPO_PLLA"].Value.ToString(),
                        COD_TIPO_PLLA = row.Cells["COD_TIPO_PLLA"].Value.ToString()
                    }
                });
            }
            return lista;
        }

        private ComisionTo ObtenerComisionToEliminar()
        {
            return new ComisionTo
            {
                PersonaTo = new personaTo
                {
                    COD_PER = dgvComision.CurrentRow.Cells["COD_PER"].Value.ToString()
                },
                NivelTo = new nivelTo
                {
                    COD_NIVEL = dgvComision.CurrentRow.Cells["COD_NIVEL"].Value.ToString()
                },
                NroCuota = dgvComision.CurrentRow.Cells["NRO_CUOTA"].Value.ToString(),
                TipoComisionTo = new TipoComisionTo
                {
                    IdTipoComision = Convert.ToInt32(dgvComision.CurrentRow.Cells["ID_TIPO_COMISION"].Value)
                },
                TipoPlanillaTo = new tipoPlanillaCreacionTo
                {
                    CODIGO = dgvComision.CurrentRow.Cells["ID_TIPO_PLLA"].Value.ToString(),
                    COD_TIPO_PLLA = dgvComision.CurrentRow.Cells["COD_TIPO_PLLA"].Value.ToString()
                }
            };
        }

        private string ObtenerCodTipoPlanilla(TabPage tb) =>
            tb.Controls.OfType<RadioButton>().ToList().Single(x => x.Checked).Tag.ToString();


        private string ObtenerCodNivelMostrar()
        {
            string nivel = string.Empty;
            foreach (TreeNode item in trvPersonas.Nodes)
            {
                if (item.Nodes.Cast<TreeNode>().Where(x => x.Checked).Any())
                {
                    nivel += item.Tag.ToString() + ",";
                }
            }
            return nivel;
        }

        private string ObtenerCodPerMostrar()
        {
            string codPer = string.Empty;
            foreach (var item in trvPersonas.Nodes)
            {
                TreeNode node = item as TreeNode;
                foreach (TreeNode item2 in node.Nodes)
                {
                    if (item2.Checked)
                    {
                        codPer += item2.Tag.ToString() + ",";
                    }
                }
            }
            return string.IsNullOrEmpty(codPer) ? "0" : codPer;
        }

        private async void CargarTodosDatosComision()
        {
            frmLoading = new HELPERS.Forms.FrmLoading();
            frmLoading.Show();
            dgvComision.Rows.Clear();
            codDirNacional = codDirNacional ?? "00";
            codDirVentas = codDirVentas ?? "00";
            codSupervisor = codSupervisor ?? "00";
            codNivelMostrar = ObtenerCodNivelMostrar();
            codPerMostrar = ObtenerCodPerMostrar();
            await Task.Run(() => ListarComisiones(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar, codPerMostrar));
            //>ListarComisiones(codDirNacional, codDirVentas, codSupervisor, codNivelMostrar, codPerMostrar);
            frmLoading.Close();
        }

        private void PintarColorFila()
        {
            bool chan = false;
            Color color1 = Color.LightGray;
            string codPer = string.Empty;
            foreach (DataGridViewRow row in dgvComision.Rows)
            {
                if (!chan && row.Cells["COD_PER"].Value.ToString() != codPer)
                {
                    chan = true;
                    codPer = row.Cells["COD_PER"].Value.ToString();
                }

                if (!chan || row.Cells["COD_PER"].Value.ToString() != codPer)
                {
                    chan = false;
                    codPer = row.Cells["COD_PER"].Value.ToString();
                    continue;
                }

                if (chan && row.Cells["COD_PER"].Value.ToString() == codPer)
                {
                    chan = true;
                    row.DefaultCellStyle.BackColor = color1;
                }
            }
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.Formulario.FrmRptComisiones frmRptcomision = new Reportes.Formulario.FrmRptComisiones
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmRptcomision.Show();
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            tabControl1.Style1TabPages(e);
        }

        private void BtnConfigurarComision_Click(object sender, EventArgs e)
        {
            FrmRegistrarComisionConfig frmComision = new FrmRegistrarComisionConfig
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmComision.ShowDialog();
            ListarFechaConfiguracion();
        }

        private void CboNivelVenta_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersonaXNivelVenta();
            ListarFechaConfiguracion();
        }

        private void CboPersona_SelectedValueChanged(object sender, EventArgs e)
        {
            ListarFechaConfiguracion();
        }

        private void ListarConfiguracionComision()
        {
            DataTable dt = null;
            if (dgvFechaConfNivelVenta.CurrentCell != null)
            {
                ComisionConfigTo to = new ComisionConfigTo
                {
                    PersonaSuperiTo = new personaTo
                    {
                        COD_PER = cboPersona.SelectedValue.ToString(),
                        NivelTo = new nivelTo { COD_NIVEL = cboNivelVenta.SelectedValue.ToString() }
                    },
                    FechaIniVigencia = dgvFechaConfNivelVenta.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime(),
                    TipoPlanillaTo = new tipoPlanillaCreacionTo { COD_TIPO_PLLA = ObtenerCodTipoPlanilla(tbConfigComNVenta) }
                };
                dt = BLComisiones.ListarConfiguracionComision(to);
            }
            CargarData(dgvComisionConfNivelVenta, dt);
        }

        private void CargarData(DataGridView dataGrid, DataTable dt)
        {
            dataGrid.Rows.Clear();
            if (dataGrid.Columns.Count == 0)
            {
                dataGrid.AddRangeColumnsDataGridView(dt, false);
                AjusteColumnasDgvComisionConf(dataGrid);
            }

            if (dataGrid.Columns.Count > 0)
            {
                dataGrid.AddRangeRowsDataGridView(dt);
            }
        }

        private void AjusteColumnasDgvComisionConf(DataGridView dataGrid)
        {
            InvisibleColumn(dataGrid);
            RenamerHeaderText(dataGrid);
            WithColumn(dataGrid);
            AlignTextContentCell(dataGrid);
            ReadOnlyColumns(dataGrid);

            dataGrid.ColorCabeceraDataGridView(Color.Teal, Color.White);
            dataGrid.AlingHeaderTextCenter();
        }

        private void ListarFechaConfiguracion()
        {
            if (cboNivelVenta.SelectedValue != null && cboPersona.SelectedValue != null)
            {
                DataTable dt = BLComisiones.ObtenerFechaIniVigenciaConfigComision(cboPersona.SelectedValue.ToString(), cboNivelVenta.SelectedValue.ToString());
                dgvFechaConfNivelVenta.DataSource = dt;
                AjusteColumnasDgvFechaConfiguracion();
            }
        }

        private void AjusteColumnasDgvFechaConfiguracion()
        {
            RenamerHeaderText();
            WithColumn();

            void RenamerHeaderText()
            {
                if (dgvFechaConfNivelVenta.Columns.Count > 0)
                {
                    dgvFechaConfNivelVenta.Columns["FECHA_INI_VIGENCIA"].HeaderText = "Fec.Ini. Vigencia";
                }
            }

            void WithColumn()
            {
                if (dgvFechaConfNivelVenta.Columns.Count > 0)
                {
                    dgvFechaConfNivelVenta.Columns["FECHA_INI_VIGENCIA"].Width = 120;
                }
            }
        }

        private void DgvComisionConf_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit | e.Context == DataGridViewDataErrorContexts.Parsing
                | e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                if (dgvComisionConfNivelVenta.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                {
                    if (!decimal.TryParse(dgvComisionConfNivelVenta[e.ColumnIndex, e.RowIndex].Value?.ToString(), out _))
                    {
                        _ = MessageBox.Show("Ingrese un valor válido", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void DgvComisionConf_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvComisionConfNivelVenta.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                {
                    if (ValidarDatosActualizarCellEndEdit(e))
                    {
                        ActualizarComisionConfi();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void DgvComisionConf_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvComisionConfNivelVenta.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                importe = dgvComisionConfNivelVenta[e.ColumnIndex, e.RowIndex].Value.ToDecimal();
        }

        private void RdbPP2_Click(object sender, EventArgs e)
        {
            ListarConfiguracionComision();
        }

        private void DgvComisionConf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComisionConfNivelVenta.Columns[e.ColumnIndex].Name == NAME_COLUMN2)
                ActualizarComisionConfi();
        }

        private void DgvFechaConfiguracion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFechaConfNivelVenta.CurrentRow != null)
            {
                ListarConfiguracionComision();
            }
        }

        private bool ValidarDatosActualizarCellEndEdit(DataGridViewCellEventArgs e)
        {
            if (dgvComisionConfNivelVenta.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
            {
                if (!decimal.TryParse(dgvComisionConfNivelVenta[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
                {
                    _ = MessageBox.Show("Ingrese un valor válido", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvComisionConfNivelVenta[e.ColumnIndex, e.RowIndex].Value = importe;
                    return false;
                }
            }
            return true;
        }

        private void ActualizarComisionConfi()
        {
            try
            {
                ComisionConfigTo to = ObtenerDatosComisionConfigToActualizar();
                if (!BLComisiones.ActualizarComisionConfig(to))
                    MessageBox.Show("Error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private ComisionConfigTo ObtenerDatosComisionConfigToActualizar()
        {
            return new ComisionConfigTo
            {
                IdComisionConfig = dgvComisionConfNivelVenta.CurrentRow.Cells["ID_COMISION_CONF"].Value.ToInt32(),
                Importe = dgvComisionConfNivelVenta.CurrentRow.Cells["IMPORTE"].Value.ToDecimal(),
                SiComisiona = dgvComisionConfNivelVenta.CurrentRow.Cells["SI_COMISIONA"].Value.ToBoolean(),
                UsuarioModifica = UsuarioSistema.Cod_usu
            };
        }

        private void DgvComisionConf_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvComisionConfNivelVenta.IsCurrentCellDirty)
            {
                _ = dgvComisionConfNivelVenta.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarEliminar())
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar los registros de la fecha seleccionada?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes)
                        return;

                    List<ComisionConfigTo> lstTo = ObtenerDatosEliminar();
                    if (BLComisiones.EliminarConfiguracionComision(lstTo))
                    {
                        ListarFechaConfiguracion();
                        dgvComisionConfNivelVenta.Rows.Clear();
                        _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        private bool ValidarEliminar()
        {
            if (dgvComisionConfNivelVenta.Rows.Count == 0)
                return false;
            return true;
        }

        private List<ComisionConfigTo> ObtenerDatosEliminar()
        {
            List<ComisionConfigTo> lista = new List<ComisionConfigTo>();
            foreach (DataGridViewRow row in dgvComisionConfNivelVenta.Rows)
            {
                lista.Add(new ComisionConfigTo
                {
                    IdComisionConfig = row.Cells["ID_COMISION_CONF"].Value.ToInt32()
                });
            }
            return lista;
        }

        private void BtnConfigurarComision2_Click(object sender, EventArgs e)
        {
            const int conf_x_institucion = 1;
            FrmRegistrarComisionConfig frmComision = new FrmRegistrarComisionConfig(conf_x_institucion)
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frmComision.ShowDialog();
            ListarFechaConfiguracionInstitu();
        }

        private void BtnEliminar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarEliminar2())
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar los registros de la fecha seleccionada?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes)
                        return;

                    List<ComisionConfigTo> lstTo = ObtenerDatosEliminar2();
                    if (BLComisiones.EliminarConfiguracionComision(lstTo))
                    {
                        ListarFechaConfiguracionInstitu();
                        dgvComisionConfInstitu.Rows.Clear();
                        _ = MessageBox.Show("Eliminado correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else _ = MessageBox.Show("Error al eliminar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
        }

        /// <summary>
        /// Validación para eliminar configuración de comsisiones por institución
        /// </summary>
        /// <returns></returns>
        private bool ValidarEliminar2()
        {
            if (dgvComisionConfInstitu.Rows.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Obtiene datos de configuración comisión por institución para eliminarlos
        /// </summary>
        /// <returns></returns>
        private List<ComisionConfigTo> ObtenerDatosEliminar2()
        {
            List<ComisionConfigTo> lista = new List<ComisionConfigTo>();
            foreach (DataGridViewRow row in dgvComisionConfInstitu.Rows)
            {
                lista.Add(new ComisionConfigTo
                {
                    IdComisionConfig = row.Cells["ID_COMISION_CONF"].Value.ToInt32()
                });
            }
            return lista;
        }

        private void CboInstitucion_SelectedValueChanged(object sender, EventArgs e)
        {
            ListarFechaConfiguracionInstitu();
        }

        /// <summary>
        /// Obtiene y muestra las fechas de configuración por institución
        /// </summary>
        private void ListarFechaConfiguracionInstitu()
        {
            if (cboInstitucion.SelectedValue != null)
            {
                DataTable dt = BLComisiones.ObtenerFechaIniVigenciaConfigComisionInstitu(cboInstitucion.SelectedValue.ToString());
                dgvFechaConfInstitu.DataSource = dt;
                AjusteColumnasDgvFechaConfiguracion();
            }
        }

        private void DgvFechaConfInstitu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFechaConfInstitu.CurrentRow != null)
            {
                ListarConfiguracionComisionInstitu();
            }
        }

        private void ListarConfiguracionComisionInstitu()
        {
            DataTable dt = null;
            if (dgvFechaConfInstitu.CurrentCell != null)
            {
                ComisionConfigTo to = new ComisionConfigTo
                {
                    InstitucionTo = new institucionesTo { COD_INST = cboInstitucion.SelectedValue.ToString() },
                    FechaIniVigencia = dgvFechaConfInstitu.CurrentRow.Cells["FECHA_INI_VIGENCIA"].Value.ToDateTime(),
                    TipoPlanillaTo = new tipoPlanillaCreacionTo { COD_TIPO_PLLA = ObtenerCodTipoPlanilla(tbConfigComInstitu) }
                };
                dt = BLComisiones.ListarConfiguracionComisionInstitu(to);
            }
            CargarData(dgvComisionConfInstitu, dt);
        }

        private void RdbPP3_Click(object sender, EventArgs e)
        {
            ListarConfiguracionComisionInstitu();
        }

        private void DgvComisionConfInstitu_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                importe = dgvComisionConfInstitu[e.ColumnIndex, e.RowIndex].Value.ToDecimal();
        }

        private void DgvComisionConfInstitu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN2)
                ActualizarComisionConfiInstitu();
        }

        private void DgvComisionConfInstitu_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit | e.Context == DataGridViewDataErrorContexts.Parsing
                | e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                {
                    if (!decimal.TryParse(dgvComisionConfInstitu[e.ColumnIndex, e.RowIndex].Value?.ToString(), out _))
                    {
                        _ = MessageBox.Show("Ingrese un valor válido", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void DgvComisionConfInstitu_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvComisionConfInstitu.IsCurrentCellDirty)
            {
                _ = dgvComisionConfInstitu.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvComisionConfInstitu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN1 || dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN3
                    || dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN4)
                {
                    EstablecerTipoCeldaModificada(e);
                    if (ValidarDatosActualizarXInstitucionCellEndEdit(e))
                    {
                        ActualizarComisionConfiInstitu();
                        DgvComisionConfInstitu_ActualizarFilaActual();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private void ActualizarComisionConfiInstitu()
        {
            try
            {
                ComisionConfigTo to = ObtenerDatosComisionConfigToInstituActualizar();
                if (!BLComisiones.ActualizarComisionConfig(to))
                    MessageBox.Show("Error al actualizar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ex.PrintException();
            }
        }

        private ComisionConfigTo ObtenerDatosComisionConfigToInstituActualizar()
        {
            decimal importe = 0;
            decimal porcentaje = 0;
            decimal baseImponible = dgvComisionConfInstitu.CurrentRow.Cells["BASE_IMPONIBLE"].Value.ToDecimal();
            CalcularImporteYPorcentaje(ref importe, ref porcentaje);
            return new ComisionConfigTo
            {
                IdComisionConfig = dgvComisionConfInstitu.CurrentRow.Cells["ID_COMISION_CONF"].Value.ToInt32(),
                Importe = importe,
                Porcentaje = porcentaje,
                BaseImponible = baseImponible,
                SiComisiona = dgvComisionConfInstitu.CurrentRow.Cells["SI_COMISIONA"].Value.ToBoolean(),
                UsuarioModifica = UsuarioSistema.Cod_usu,
            };
        }

        /// <summary>
        /// Si el tipo comisión es PORCENTAJE, entonces, si se modifica el importe calculamos el porcentaje 
        /// Si el tipo comisión es PORCENTAJE, entonces, si se modifica el porcentaje calculamos el importe
        /// Si el tipo de comisión es IMPORTE, en ese caso solo se devuelve el importe modificado y no se calcula nada
        /// </summary>
        /// <param name="_importe"></param>
        /// <param name="_porcentaje"></param>
        private void CalcularImporteYPorcentaje(ref decimal _importe, ref decimal _porcentaje)
        {
            decimal importe = dgvComisionConfInstitu.CurrentRow.Cells["IMPORTE"].Value.ToDecimal();
            decimal porcentaje = decimal.TryParse(dgvComisionConfInstitu.CurrentRow.Cells["PORCENTAJE"].Value?.ToString().Replace("%", ""), out decimal valor) ? valor : 0;
            decimal baseImponible = dgvComisionConfInstitu.CurrentRow.Cells["BASE_IMPONIBLE"].Value.ToDecimal();
            int tipoComision = dgvComisionConfInstitu.CurrentRow.Cells["ID_TIPO_COMISION"].Value.ToInt32();
            if (tipoComision == ID_TIPO_COMISION_PORCENTAJE)
            {
                _importe = tipoModificacion == MODIFICO_PORCENTAJE || tipoModificacion == MODIFICO_BASE_IMPONIBLE ? baseImponible * porcentaje / 100 : importe;
                _porcentaje = tipoModificacion == MODIFICO_IMPORTE ? (importe * 100 / baseImponible) : porcentaje;
            }
            else
            {
                _importe = importe;
                _porcentaje = 0;
            }
        }

        /// <summary>
        /// Establece el tipo de modificación según la celda modificada(IMPORTE, PORCENTAJE, BASE IMPONIBLE) y segpun esto calcular el importe o porcentaje
        /// </summary>
        /// <param name="e"></param>
        private void EstablecerTipoCeldaModificada(DataGridViewCellEventArgs e)
        {
            if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
                tipoModificacion = MODIFICO_IMPORTE;
            else if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN4)
                tipoModificacion = MODIFICO_BASE_IMPONIBLE;
            else
                tipoModificacion = MODIFICO_PORCENTAJE;
        }

        private bool ValidarDatosActualizarXInstitucionCellEndEdit(DataGridViewCellEventArgs e)
        {
            if (dgvComisionConfInstitu.Columns[e.ColumnIndex].Name == NAME_COLUMN1)
            {
                if (!decimal.TryParse(dgvComisionConfInstitu[e.ColumnIndex, e.RowIndex].Value.ToString(), out _))
                {
                    _ = MessageBox.Show("Ingrese un valor válido", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvComisionConfInstitu[e.ColumnIndex, e.RowIndex].Value = importe;
                    return false;
                }
            }
            return true;
        }

        private void DgvComisionConfInstitu_ActualizarFilaActual()
        {
            decimal importe = 0;
            decimal porcentaje = 0;
            CalcularImporteYPorcentaje(ref importe, ref porcentaje);
            dgvComisionConfInstitu.CurrentRow.Cells[NAME_COLUMN1].Value = importe;
            dgvComisionConfInstitu.CurrentRow.Cells[NAME_COLUMN3].Value = string.Concat(decimal.Round(porcentaje, 2), "%");
        }
    }
}
