using Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Presentacion.HELPERS
{
    public static class GenericUtil
    {
        public static usuariosTo UsuarioSistema { get; internal set; }
        public static empresaTo EmpresaSistema { get; internal set; }
        public static periodoTo PeriodoSistema { get; internal set; }

        public static string ObtenerRutaReporteTareaje(string nombreReporte, Modulo modulo)
        {
            switch (modulo)
            {
                case Modulo.MOD_CXC: return string.Format("Presentacion.MOD_CXC.Reportes.ReportViewer.{0}.rdlc", nombreReporte);
                case Modulo.MOD_VTA: return string.Format("Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReportViewer.{0}.rdlc", nombreReporte);
                case Modulo.MOD_COMISIONES: return string.Format("Presentacion.MOD_COMISIONES.Reportes.ReportViewer.{0}.rdlc", nombreReporte);
                default: throw new Exception("No se proporcionó un modulo válido para obtener el reporte");
            }
        }

        public static string ObtenerRutaReporteTareaje_MOD_CXC(string nombreReporte)
        {
            return string.Format("Presentacion.MOD_CXC.Reportes.ReportViewer.{0}.rdlc", nombreReporte);
        }

        public static string ObtenerRutaReporteTareaje_MOD_FACT_VTA(string nombreReporte)
        {
            return string.Format("Presentacion.MOD_FACT_VTA.MOD_VTA.Reportes.ReportViewer.{0}.rdlc", nombreReporte);
        }

        public static Form CreateReportForm(string reporte, string dataSetName, DataTable table, params object[] values)
        {
            Form frm = new Form();
            //[DsTesoreria ds = new DsTesoreria();]
            ReportViewer rep = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            rep.LocalReport.ReportEmbeddedResource = reporte;
            rep.SetDisplayMode(DisplayMode.PrintLayout);
            rep.ZoomMode = ZoomMode.PageWidth;
            rep.LocalReport.EnableExternalImages = true;
            var parametros = ObtenerParametrosReporte(rep, values);
            rep.LocalReport.SetParameters(parametros);
            rep.LocalReport.DataSources.Clear();
            rep.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, table));
            rep.RefreshReport();
            frm.Controls.Add(rep);
            frm.WindowState = FormWindowState.Maximized;
            return frm;
        }

        public static Form CreateReportForm(ref ReportViewer reportViewer, string reporte, string dataSetName, DataTable table, params object[] values)
        {
            Form frm = new Form();
            //[DsTesoreria ds = new DsTesoreria();]
            ReportViewer rep = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            rep.LocalReport.ReportEmbeddedResource = reporte;
            rep.SetDisplayMode(DisplayMode.PrintLayout);
            rep.ZoomMode = ZoomMode.PageWidth;
            
            rep.LocalReport.EnableExternalImages = true;
            var parametros = ObtenerParametrosReporte(rep, values);
            rep.LocalReport.SetParameters(parametros);
            rep.LocalReport.DataSources.Clear();
            rep.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, table));
            frm.Controls.Add(rep);
            frm.WindowState = FormWindowState.Maximized;
            reportViewer = rep;
            return frm;
        }

        public static Form CreateReportForm(string reporte, string dataSetName, DataTable table, DisplayMode displayMode, ZoomMode zoomMode, params object[] values)
        {
            Form frm = new Form();
            //[DsTesoreria ds = new DsTesoreria();]
            ReportViewer rep = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            rep.LocalReport.ReportEmbeddedResource = reporte;
            rep.SetDisplayMode(displayMode);
            rep.ZoomMode = zoomMode;
            rep.LocalReport.EnableExternalImages = true;
            var parametros = ObtenerParametrosReporte(rep, values);
            rep.LocalReport.SetParameters(parametros);
            rep.LocalReport.DataSources.Clear();
            rep.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, table));
            rep.RefreshReport();
            frm.Controls.Add(rep);
            frm.WindowState = FormWindowState.Maximized;
            return frm;
        }

        private static List<ReportParameter> ObtenerParametrosReporte(ReportViewer reporte, params object[] values)
        {
            if (reporte is null)
            {
                throw new NullReferenceException();
            }
            List<ReportParameter> lista = new List<ReportParameter>();
            var Parametros = reporte.LocalReport.GetParameters();
            if (Parametros.Count > 0)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    lista.Add(new ReportParameter(Parametros[i].Name, values[i].ToString()));
                }
            }
            return lista;
        }

        private static List<ReportDataSource> lstReporDataSource;
        public static Form CreateReportSubInformeForm(string reporte, string dataSetName, DataTable table, Dictionary<string, DataTable> dicSubInforme, params object[] values)
        {
            Form frm = new Form();
            //[DsTesoreria ds = new DsTesoreria();]
            ReportViewer rep = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            rep.SetDisplayMode(DisplayMode.PrintLayout);
            rep.ZoomMode = ZoomMode.PageWidth;
            rep.LocalReport.ReportEmbeddedResource = reporte;
            rep.LocalReport.EnableExternalImages = true;
            var parametros = ObtenerParametrosReporte(rep, values);
            rep.LocalReport.SetParameters(parametros);
            rep.LocalReport.DataSources.Clear();
            rep.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, table));
            lstReporDataSource = ObtenerSubInformes(dicSubInforme);
            rep.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(Rep_SubReportProcessing);
            rep.RefreshReport();
            frm.Controls.Add(rep);
            frm.WindowState = FormWindowState.Maximized;
            return frm;
        }

        private static void Rep_SubReportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            foreach (ReportDataSource item in lstReporDataSource)
            {
                e.DataSources.Add(item);
            }
        }

        private static List<ReportDataSource> ObtenerSubInformes(Dictionary<string, DataTable> dicSubInforme)
        {
            List<ReportDataSource> lista = new List<ReportDataSource>();
            foreach (var item in dicSubInforme)
            {
                lista.Add(new ReportDataSource(item.Key, item.Value));
            }
            return lista;
        }

        public static string NombreMesCorta(this int mes)
        {
            string nombreMes = new DateTime(DateTime.Now.Year, mes, 1).ToString("MMM");
            string nombreMesUpper = nombreMes.Substring(0, 1) + nombreMes.Substring(1, nombreMes.Length - 1);
            return nombreMesUpper;
        }

        public static string NombreMes(this int mes)
        {
            string nombreMes = new DateTime(DateTime.Now.Year, mes, 1).ToString("MMMM");
            string nombreMesUpper = nombreMes.Substring(0, 1) + nombreMes.Substring(1, nombreMes.Length - 1);
            return nombreMesUpper;
        }

        /// <summary>
        /// Retorna el mes en formato de dos dígitos(01, 02, 03, 10)
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static string ToMonthString(this int mes) => mes < 10 ? string.Concat(0, mes) : mes.ToString();
    }
}
