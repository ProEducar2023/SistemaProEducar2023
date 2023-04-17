using BLL;
using Entidades;
using Presentacion.HELPERS;
using System;
using System.Data;
using System.Windows.Forms;
namespace Presentacion
{
    public partial class ICONOS : Form
    {
        string AÑO = "", MES = "", COD_MOD = "", TIPO_USU = "", COD_USU = "", COD_EMPRESA = "", NOM_EMPRESA = "", NOM_USU = "", COD_PAIS;
        DateTime FECHA_INI, FECHA_GRAL;
        //string con;
        //Properties.Settings s = new Properties.Settings();
        usuariosBLL usuBLL = new usuariosBLL();
        usuariosTo usuTo = new usuariosTo();
        empresaBLL empBLL = new empresaBLL();
        empresaTo empTo = new empresaTo();
        public ICONOS(string COD_EMPRESA, string COD_USU, string COD_PAIS)
        {
            InitializeComponent();
            this.COD_EMPRESA = COD_EMPRESA;
            this.COD_USU = COD_USU;
            this.COD_PAIS = COD_PAIS;
        }

        private void ICONOS_Load(object sender, EventArgs e)
        {
            empTo.Cod_Empresa = COD_EMPRESA;
            DataTable dtEmp = empBLL.obtenerEmpresa_x_CodBLL(empTo);
            if (dtEmp.Rows.Count > 0)
                NOM_EMPRESA = dtEmp.Rows[0]["Razon_Social"].ToString();
            //
            this.Text = "GESTION COMERCIAL                                                 EMPRESA : " + NOM_EMPRESA;
            usuTo.Cod_usu = COD_USU;
            DataTable dtUsu = usuBLL.obtenerUsuario_x_CodBLL(usuTo);
            if (dtUsu.Rows.Count > 0)
            {
                TIPO_USU = dtUsu.Rows[0]["Tipo"].ToString();
                NOM_USU = dtUsu.Rows[0]["Nick"].ToString();
            }
            //string conn = s.SERVIDOR;
            //con = @"server=" + conn + "; Database=BD_GCO03; User Id=miguel; Password=main"; //el servidor
        }
        public bool MOSTRAR_FECHA(string COD_MODULO)
        {
            bool flag = false;
            periodoBLL prdBLL = new periodoBLL();
            periodoTo prdTo = new periodoTo();
            prdTo.COD_MODULO = COD_MODULO;
            DataTable dt = prdBLL.hallarActivoBLL(prdTo);
            if (dt is null)
            {
                _ = _ = MessageBox.Show("Error al optener el período activo. \n Inténtelo otra vez.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return flag;
            }
            if (dt.Rows.Count > 0)
            {
                AÑO = dt.Rows[dt.Rows.Count - 1][0].ToString();
                MES = dt.Rows[dt.Rows.Count - 1][1].ToString();
                FECHA_INI = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][2]);
                FECHA_GRAL = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][3]);
                EstablecerPeriodoSistema();
            }
            flag = AÑO == "" ? false : true;
            return flag;
        }

        private void EstablecerPeriodoSistema()
        {
            GenericUtil.PeriodoSistema = new periodoTo
            {
                AÑO = AÑO,
                MES = MES,
                FECHA_INICIO = FECHA_INI
            };
        }

        private void BTN_ADM_Click(object sender, EventArgs e)
        {
            MOD_VTA.MODULO_ADM frm = new MOD_VTA.MODULO_ADM(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
            frm.Show();
        }

        private void BTN_COM_Click(object sender, EventArgs e)
        {
            COD_MOD = "ALM";//ALMACENES
            if (MOSTRAR_FECHA(COD_MOD))
            {
                MOD_VTA.MODULO_ALMACEN frm = new MOD_VTA.MODULO_ALMACEN(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE ALMACENES !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnFactCompras_Click(object sender, EventArgs e)
        {
            MOD_VTA.MODULO_FACT_COMPRAS frm = new MOD_VTA.MODULO_FACT_COMPRAS();
            frm.Show();
        }

        private void BTN_CXP_Click(object sender, EventArgs e)
        {
            COD_MOD = "COM";//COMISIONES
            if (MOSTRAR_FECHA(COD_MOD))
            {
                MOD_VTA.MODULO_CXP frm = new MOD_VTA.MODULO_CXP(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE COMISIONES !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void BTN_VTAS_Click(object sender, EventArgs e)
        {
            COD_MOD = "VTA";//VENTAS
            if (MOSTRAR_FECHA(COD_MOD))
            {
                MOD_VTA.MODULOS_VENTAS frm = new MOD_VTA.MODULOS_VENTAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE VENTAS !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnFactVentas_Click(object sender, EventArgs e)
        {
            COD_MOD = "FVT";
            if (MOSTRAR_FECHA(COD_MOD))
            {
                MOD_VTA.MODULO_FACT_VTAS frm = new MOD_VTA.MODULO_FACT_VTAS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE VENTAS !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void BTN_ALM_Click(object sender, EventArgs e)
        {
            COD_MOD = "COS";
            if (MOSTRAR_FECHA(COD_MOD))
            {
                INICIOS.MODULO_COS frm = new INICIOS.MODULO_COS(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE CUENTAS POR COBRAR !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void BTN_CXC_Click(object sender, EventArgs e)
        {
            COD_MOD = "CXC";
            if (MOSTRAR_FECHA(COD_MOD))
            {
                //MOD_VTA.MODULO_ALMACEN frm = new MOD_VTA.MODULO_ALMACEN(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD);
                INICIOS.MODULO_CXC frm = new INICIOS.MODULO_CXC(AÑO, MES, FECHA_INI, FECHA_GRAL, COD_MOD, TIPO_USU, COD_USU, NOM_EMPRESA, NOM_USU);
                frm.Show();
            }
            else
            {
                MessageBox.Show("NO EXISTE MES ACTIVO PARA EL MODULO DE CUENTAS POR COBRAR !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void ICONOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btnsalir_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Application.Exit();
        }

    }
}
