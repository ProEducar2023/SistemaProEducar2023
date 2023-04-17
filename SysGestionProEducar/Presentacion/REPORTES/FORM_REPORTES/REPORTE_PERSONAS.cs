using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace Presentacion.REPORTES.FORM_REPORTES
{
    public partial class REPORTE_PERSONAS : Form
    {
        HelpersBLL helBLL = new HelpersBLL();
        HelpersTo helTo = new HelpersTo();
        personaBLL perBLL = new personaBLL();
        personaTo perTo = new personaTo();
        BackgroundWorker bwExportar = new BackgroundWorker();
        string rutaExcel, archivoExcel;
        bool Exito;
        public REPORTE_PERSONAS()
        {
            InitializeComponent();
            bwExportar.WorkerReportsProgress = true;
            bwExportar.WorkerSupportsCancellation = true;
            bwExportar.DoWork += new DoWorkEventHandler(ExportarWork);
            bwExportar.ProgressChanged += new ProgressChangedEventHandler(ExportarProgress);
            bwExportar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ExportarComplete);
        }
        private void ExportarWork(object sender, DoWorkEventArgs e)
        {
            Exito = true;


        }
        private void ExportarProgress(object sender, ProgressChangedEventArgs e)
        {

        }
        private void ExportarComplete(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private void REPORTE_PERSONAS_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            CARGAR_CLASE();
            CARGAR_CATEGORIA();
            CARGAR_PAIS();
            CARGAR_DEPARTAMENTO();
            cbo_clase.Focus();
        }

        private void REPORTE_PERSONAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void CARGAR_CLASE()
        {
            DataTable dt = helBLL.obtenerClaseBLL();
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
            cbo_clase.SelectedIndex = -1;
        }
        private void CARGAR_CATEGORIA()
        {
            DataTable dt = helBLL.obtenerCategoriaBLL();
            cbo_cat.ValueMember = "COD_CAT";
            cbo_cat.DisplayMember = "DESC_CAT";
            cbo_cat.DataSource = dt;
            cbo_cat.SelectedIndex = -1;
        }
        private void CARGAR_PAIS()
        {
            DataTable dt = helBLL.obtenerPaisBLL();
            cbo_pais.ValueMember = "COD_PAIS";
            cbo_pais.DisplayMember = "DESC_PAIS";
            cbo_pais.DataSource = dt;
        }
        private void CARGAR_DEPARTAMENTO()
        {
            DataTable dt = helBLL.obtenerDepartamentoBLL();
            cbo_dep.ValueMember = "COD_DEP";
            cbo_dep.DisplayMember = "DESC_DEP";
            cbo_dep.DataSource = dt;
        }

        private void cbo_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589")
                    CARGAR_DEPARTAMENTO();
                else
                {
                    cbo_dep.SelectedIndex = -1;
                    cbo_pro.SelectedIndex = -1;
                    cbo_dist.SelectedIndex = -1;
                }
            }
        }
        private void cbo_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589" && cbo_dep.SelectedValue != null)
                    CARGAR_PROVINCIA();
                else
                    cbo_dep.SelectedIndex = -1;
            }
        }
        private void cbo_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_pais.SelectedValue != null)
            {
                if (cbo_pais.SelectedValue.ToString() == "9589" && cbo_dep.SelectedValue != null && cbo_pro.SelectedValue != null)
                    CARGAR_DISTRITO();
                else
                    cbo_dep.SelectedIndex = -1;
            }
        }
        private void CARGAR_PROVINCIA()
        {
            helTo.CODIGO = cbo_dep.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerPro_PaisBLL(helTo);
            cbo_pro.ValueMember = "COD_PRO";
            cbo_pro.DisplayMember = "DESC_PRO";
            cbo_pro.DataSource = dt;
        }
        private void CARGAR_DISTRITO()
        {
            helTo.CODIGO = cbo_dep.SelectedValue.ToString();
            helTo.CODIGO2 = cbo_pro.SelectedValue.ToString();
            DataTable dt = helBLL.obtenerDist_Pro_PaisBLL(helTo);
            cbo_dist.ValueMember = "COD_DIST";
            cbo_dist.DisplayMember = "DESC_DIST";
            cbo_dist.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BTN_SALIR_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_pantalla1_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;
            perTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
            perTo.COD_CAT = cbo_cat.SelectedValue.ToString();
            DataTable dt = perBLL.obtenerPersonaparaReporteBLL(perTo);
            if (dt.Rows.Count > 0)
            {
                List<personaTo> lper = new List<personaTo>();
                foreach (DataRow rw in dt.Rows)
                {
                    personaTo pers = new personaTo();
                    pers.COD_PER = rw["COD_PER"].ToString();
                    pers.DESC_PER = rw["DESC_PER"].ToString();
                    pers.NRO_DOC = rw["NRO_DOC"].ToString();
                    pers.NOM_COMERCIAL = rw["NOM_COMERCIAL"].ToString();
                    pers.DIRECCION = rw["DIRECCION"].ToString();
                    lper.Add(pers);
                }
                REPORTES.FORM_REP.REP_PERSONAL1 frm = new FORM_REP.REP_PERSONAL1();
                frm.Empresa = "EDICIONES AMERICANAS";
                frm.Clase = cbo_clase.Text;
                frm.Categoria = cbo_cat.Text;
                frm.lstper = lper;
                frm.Show();
            }
            else
            {
                MessageBox.Show("No se encontraron registros !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private bool validaPantalla()
        {
            bool result = true;
            if (cbo_clase.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de elegir la Clase", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (cbo_cat.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de elegir la Categoría", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            return result;
        }

        private void btn_archivo1_Click(object sender, EventArgs e)
        {
            if (!validaPantalla())
                return;
            if (!bwExportar.IsBusy)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    rutaExcel = fbd.SelectedPath;
                    tslblMensaje.Text = "Generando Archivo";
                    stEstado.Visible = true;
                    bwExportar.RunWorkerAsync();
                }
            }
        }
    }
}
