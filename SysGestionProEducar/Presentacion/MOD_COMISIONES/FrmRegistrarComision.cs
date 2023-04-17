using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;

namespace Presentacion.MOD_COMISIONES
{
    public partial class FrmRegistrarComision : Form
    {
        private readonly personaBLL BLMaestroPersona = new personaBLL();
        private readonly nivelBLL BLNivel = new nivelBLL();
        private readonly comisionesBLL BLComisiones = new comisionesBLL();
        private readonly tipoPlanillaCreacionBLL BLTipoPlanilla = new tipoPlanillaCreacionBLL();

        public FrmRegistrarComision()
        {
            InitializeComponent();
        }

        private bool acces;
        private int actRegistrar;

        private void FrmRegistrarComision_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarNivelVenta();
            CargarTipoComision();
            CargarTipoVenta();
            //CargarNivel();
            //CargarPersonaXNivel();
            ExpandirNodos();
        }

        private void StartControls()
        {
            btnGrabar.StyleButtonFlat();
            FormatoNumericUpDown(numImporteCom);
            FormatoNumericUpDown(numPorcentajeCom);
            FormatoNumericUpDown(numBaseImponible);
            FormatCombobox(cboNivelVenta);
            FormatCombobox(cboPersona);
            FormatCombobox(cboTipoComision);
            txtNroCuota.MaxLength = 3;
        }

        private void FormatoNumericUpDown(NumericUpDown numeric)
        {
            numeric.DecimalPlaces = 2;
            numeric.ThousandsSeparator = true;
            numeric.Maximum = 1000000000;
            numeric.Minimum = 0;
            numeric.Increment = 1;
            numeric.TextAlign = HorizontalAlignment.Right;
        }

        private void FormatCombobox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarNivelVenta()
        {
            DataTable dt = BLNivel.obtenerNivelBLL();
            cboNivelVenta.DataSource = dt;
            cboNivelVenta.ValueMember = "COD_NIVEL";
            cboNivelVenta.DisplayMember = "DESC_NIVEL";

            if (trvPersonas.Nodes.Count > 0)
                cboNivelVenta.SelectedValue = trvPersonas.Nodes.Cast<TreeNode>().FirstOrDefault(x => x.Checked).Tag;
        }

        private void CargarPersona()
        {
            DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
            foreach (DataColumn column in dt.Columns)
            {
                column.AllowDBNull = true;
            }
            DataRow row = dt.NewRow();
            row["COD_PER"] = "0";
            row["DESC_PER"] = "Todos";
            dt.Rows.InsertAt(row, 0);

            cboPersona.DataSource = dt;
            cboPersona.ValueMember = "COD_PER";
            cboPersona.DisplayMember = "DESC_PER";
        }

        private void CargarTipoComision()
        {
            DataTable dt = BLComisiones.ListarTipoComision();
            cboTipoComision.DataSource = dt;
            cboTipoComision.ValueMember = "ID_TIPO_COMISION";
            cboTipoComision.DisplayMember = "DESC_TIPO_COMISION";
        }

        private void CargarTipoVenta()
        {
            List<tipoPlanillaCreacionTo> lista = BLTipoPlanilla.ListarTipoVentaComision();
            if (lista != null)
            {
                foreach (tipoPlanillaCreacionTo item in lista)
                {
                    _ = trvTipoVenta.Nodes.Add(new TreeNode
                    {
                        Tag = item.CODIGO,
                        Text = item.COD_TIPO_PLLA
                    });
                }
            }
        }

        private void CboTipoPersona_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarPersona();
        }

        private void ExpandirNodos()
        {
            if (trvPersonas.Nodes.Count > 0)
            {
                foreach (TreeNode item in trvPersonas.Nodes)
                {
                    item.Expand();
                }
                trvPersonas.Nodes[0].EnsureVisible();
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarRegistrar())
                {
                    if (MessageBox.Show("¿Esta seguro de guardar los cambios?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ComisionTo comisionTo = ObtenerComisionTo();
                        _ = BLComisiones.GrabarComision(comisionTo)
                        ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al registrar", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        _ = MessageBox.Show("Este registro ya existe, no se puede insertar duplicados", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                        ex.PrintException();
                }
                else
                    ex.PrintException();
            }
        }

        private ComisionTo ObtenerComisionTo()
        {
            return new ComisionTo
            {
                LstMaestroPersonaTo = ObtenerMaestroPersona(),
                NivelTo = new nivelTo
                {
                    COD_NIVEL = cboNivelVenta.SelectedValue.ToString()
                },
                NroCuota = txtNroCuota.Text,
                FechaIniVigencia = dtFechaIniVigencia.Value,
                FechaFinVigencia = null,
                Importe = numImporteCom.Value,
                Porcentaje = numPorcentajeCom.Value,
                BaseImponible = numBaseImponible.Value,
                TipoComisionTo = new TipoComisionTo
                {
                    IdTipoComision = Convert.ToInt32(cboTipoComision.SelectedValue)
                },
                LstTipoPlanillaTo = ObtenerTipoVentaSeleccionados(),
                UsuarioCrea = UsuarioSistema.Cod_usu
            };
        }

        private List<personaTo> ObtenerMaestroPersona()
        {
            List<personaTo> lista = new List<personaTo>();
            if (actRegistrar == 0)
            {
                if (cboPersona.SelectedValue.ToString() == "0")
                {
                    DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(cboNivelVenta.SelectedValue.ToString());
                    foreach (DataRow row in dt.Rows)
                    {
                        lista.Add(new personaTo
                        {
                            COD_PER = row["COD_PER"].ToString()
                        });
                    }
                }
                else
                    lista.Add(new personaTo { COD_PER = cboPersona.SelectedValue.ToString() });
            }
            else if (actRegistrar == 1)
            {
                foreach (TreeNode item in trvPersonas.Nodes[0].Nodes)
                {
                    if (item.Checked)
                    {
                        lista.Add(new personaTo
                        {
                            COD_PER = item.Tag.ToString()
                        });
                    }
                }
            }

            return lista;
        }

        private bool ValidarRegistrar()
        {
            if (!trvTipoVenta.Nodes.Cast<TreeNode>().Where(x => x.Checked).Any())
            {
                _ = MessageBox.Show("Debe seleccionar al menos un tipo de venta", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (numImporteCom.Value < 0)
            {
                _ = MessageBox.Show("El importe de la comisión no deben ser negativo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (numPorcentajeCom.Value < 0)
            {
                _ = MessageBox.Show("El porcentaje de la comisión no deben ser negativo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (numBaseImponible.Value < 0)
            {
                _ = MessageBox.Show("El importe de base imponible de la comisión no deben ser negativo", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void TrvPersonas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SeleccionEnCascada(e);
        }

        private void SeleccionEnCascada(TreeViewEventArgs e)
        {
            if (!acces)
            {
                if (e.Node.Checked)
                {
                    EstablecerCheckNodosXNodoPadre(e);
                    ListarNodosHijosXNodoPadre(e, false);
                }
                else
                {
                    EstablecerCheckNodosXNodoPadre(e);
                    MostrarDatosOriginalesXNodo(e);
                }
            }
            acces = false;
        }

        private void EstablecerCheckNodosXNodoPadre(TreeViewEventArgs e)
        {
            foreach (TreeNode item in e.Node.Nodes)
            {
                acces = true;
                item.Checked = e.Node.Checked;
            }
        }

        private void ListarNodosHijosXNodoPadre(TreeViewEventArgs e, bool chk)
        {
            TreeNode nextNodo = e.Node.Parent != null ? e.Node.Parent.NextNode : e.Node.NextNode;
            if (nextNodo != null)
            {
                string codPerNivelPadre = string.Empty;
                if (e.Node.Parent == null)
                {
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        codPerNivelPadre += item.Tag.ToString() + ",";
                    }
                }
                else
                    codPerNivelPadre = e.Node.Tag.ToString();
                string codNivelPadre = e.Node.Parent != null ? e.Node.Parent.Tag.ToString() : e.Node.Tag.ToString();
                string codNivelHijo = nextNodo.Tag.ToString();
                DataTable dt = null; //> BLMaestroPersona.ObtenerPersonaNivelVentaHijoXPadre(codPerNivelPadre, codNivelPadre, codNivelHijo);
                List<TreeNode> lstNodoEliminar = new List<TreeNode>();
                DataRow rw;
                foreach (TreeNode node in nextNodo.Nodes)
                {
                    if (node != null)
                    {
                        rw = dt.Rows.Cast<DataRow>().SingleOrDefault(x => x["COD_PER"].ToString() == node.Tag.ToString());

                        if (rw is null)
                            lstNodoEliminar.Add(node);
                    }
                }
                RemoveNodos(nextNodo, lstNodoEliminar);
                nextNodo.Checked = chk;
            }
        }

        private List<tipoPlanillaCreacionTo> ObtenerTipoVentaSeleccionados()
        {
            List<tipoPlanillaCreacionTo> lista = new List<tipoPlanillaCreacionTo>();
            foreach (TreeNode item in trvTipoVenta.Nodes)
            {
                if (item.Checked)
                {
                    lista.Add(new tipoPlanillaCreacionTo
                    {
                        CODIGO = item.Tag.ToString(),
                        COD_TIPO_PLLA = item.Text
                    });
                }
            }
            return lista;
        }

        private void RemoveNodos(TreeNode nextNodo, List<TreeNode> lstNodoEliminar)
        {
            foreach (TreeNode item in lstNodoEliminar)
            {
                nextNodo.Nodes.Remove(item);
            }
        }

        private void MostrarDatosOriginalesXNodo(TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.NextNode != null)
            {
                TreeNode nextNodo = e.Node.Parent.NextNode;
                DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(nextNodo.Tag.ToString());
                List<TreeNode> arrNodos = new List<TreeNode>();
                TreeNode tr;
                foreach (DataRow row in dt.Rows)
                {
                    tr = nextNodo.Nodes.Cast<TreeNode>().SingleOrDefault(x => x.Tag.ToString() == row["COD_PER"].ToString());
                    if (tr is null)
                    {
                        arrNodos.Add(new TreeNode
                        {
                            Tag = row["COD_PER"].ToString(),
                            Text = row["DESC_PER"].ToString()
                        });
                    }
                }
                nextNodo.Nodes.AddRange(arrNodos.ToArray());
                nextNodo.Checked = false;
            }
        }

        private void TxtNroCuota_TextChanged(object sender, EventArgs e)
        {
            //> txtNroCuota.Text = txtNroCuota.
        }

        private void TxtNroCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormatTxtNroCuota();
            }
        }

        private void TxtNroCuota_Leave(object sender, EventArgs e)
        {
            FormatTxtNroCuota();
        }

        private void FormatTxtNroCuota()
        {
            try
            {
                int num = Convert.ToInt32(txtNroCuota.Text);
                if (!string.IsNullOrEmpty(txtNroCuota.Text))
                {
                    if (num <= 18)
                    {
                        txtNroCuota.Text = num.ToString().PadLeft(3, Convert.ToChar("0"));
                    }
                    else
                    {
                        _ = MessageBox.Show("El numero máximo de cuotas es 18", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNroCuota.Text = "000";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    txtNroCuota.Text = "000";
            }
        }

        internal void MostrarNodoSeleccionado(TreeNode trNode)
        {
            actRegistrar = 1;
            _ = trvPersonas.Nodes.Add(trNode);
            trNode.Checked = true;

            DeshabilitarCombobox();
        }

        private void DeshabilitarCombobox()
        {
            cboNivelVenta.Enabled = false;
            cboPersona.Enabled = false;
        }
    }
}
