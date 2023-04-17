using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentacion.HELPERS.ErrorPrint;
using static Presentacion.HELPERS.GenericUtil;
using static Presentacion.HELPERS.AppearanceUtil;
using static Presentacion.HELPERS.GenericMethod;
using BLL;
using Entidades;

namespace Presentacion.MOD_COMISIONES
{
    public partial class CFrmComisionInsitucionConf : UserControl
    {
        public CFrmComisionInsitucionConf()
        {
            InitializeComponent();
        }

        private readonly institucionesBLL BLInstitucion = new institucionesBLL();
        private readonly tipoPlanillaCreacionBLL BLTipoPlanilla = new tipoPlanillaCreacionBLL();
        private readonly comisionesBLL BLComisiones = new comisionesBLL();
        private readonly personaBLL BLMaestroPersona = new personaBLL();
        private DataTable dtTipoComision;

        private const int ID_TIPO_COMISION_PORCENTAJE = 2;
        private const int ID_TIPO_COMISION_IMPORTE = 1;

        private void CFrmComisionInsitucionConf_Load(object sender, EventArgs e)
        {
            StartControls();
            CargarInstitucion();
            CargarTipoComision();
            CargarTipoVenta();
        }

        private void StartControls()
        {
            btnGrabar.StyleButtonFlat();
            FormatoNumericUpDown(numImporteCom);
            FormatoNumericUpDown(numPorcentajeCom);
            FormatoNumericUpDown(numBaseImponible);
            FormatCombobox(cboInstitucion);
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

        private void CargarInstitucion()
        {
            DataTable dt = BLInstitucion.obtenerInstitucionesBLL();
            cboInstitucion.DataSource = dt;
            cboInstitucion.ValueMember = "COD_INST";
            cboInstitucion.DisplayMember = "DESC_CORTA";
        }

        private void CargarTipoComision()
        {
            dtTipoComision = BLComisiones.ListarTipoComision();
            cboTipoComision.DataSource = dtTipoComision;
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

        private void TxtNroCuota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNroCuota.FormatTxtNroCuota();
            }
        }

        private void TxtNroCuota_Leave(object sender, EventArgs e)
        {
            txtNroCuota.FormatTxtNroCuota();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarRegistrar())
                {
                    if (MessageBox.Show("¿Esta seguro de guardar los cambios?", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ComisionConfigTo comisionConfTo = ObtenerComisionConfigTo();
                        bool result = BLComisiones.RegistrarComisionConfig(comisionConfTo);
                        _ = result ? MessageBox.Show("Registrado Correctamente", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        : MessageBox.Show("Error al registrar la configuración", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.PrintException2();
            }
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

            if (dtTipoComision == null || dtTipoComision.Rows.Count == 0)
            {
                _ = MessageBox.Show("No existe tipos de comisión registrados en la base de datos", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private ComisionConfigTo ObtenerComisionConfigTo()
        {
            return new ComisionConfigTo
            {
                LstVendedores = ObtenerVendedoresXSuperior(),
                PersonaSuperiTo = null,
                InstitucionTo = new institucionesTo
                {
                    COD_INST = cboInstitucion.SelectedValue.ToString()
                },
                NroCuota = txtNroCuota.Text,
                FechaIniVigencia = dtFechaIniVigencia.Value,
                FechaFinVigencia = null,
                Importe = cboTipoComision.SelectedValue.ToInt32() == ID_TIPO_COMISION_PORCENTAJE ? numBaseImponible.Value * numPorcentajeCom.Value / 100 : numImporteCom.Value,
                Porcentaje = numPorcentajeCom.Value,
                BaseImponible = numBaseImponible.Value,
                TipoComisionTo = new TipoComisionTo
                {
                    IdTipoComision = cboTipoComision.SelectedValue.ToInt32()
                },
                LstTipoPlanillaTo = ObtenerTipoVentaSeleccionados(),
                SiComisiona = true,
                UsuarioCrea = UsuarioSistema.Cod_usu
            };
        }

        private List<personaTo> ObtenerVendedoresXSuperior()
        {
            List<personaTo> lista = new List<personaTo>();
            const string cod_nivel_vendedor = "04";
            DataTable dt = BLMaestroPersona.ObtenerMaestroPersonaXNivel(cod_nivel_vendedor);
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new personaTo
                {
                    COD_PER = row["COD_PER"].ToString(),
                    NivelTo = new nivelTo
                    {
                        COD_NIVEL = row["COD_NIVEL"].ToString()
                    }
                });
            }

            return lista;
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
    }
}
