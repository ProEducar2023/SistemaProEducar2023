using FacturacionElectronica;
using FacturacionElectronica.service.implement;
using FacturacionElectronica.service.interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.MOD_FACT_VTA
{
    public partial class FrmDetallesDocumentos : Form
    {
        List<dynamic> listaTickets;
        IIFacVtaService ifactService;

        public FrmDetallesDocumentos(List<dynamic> listaTickets)
        {
            InitializeComponent();
            ifactService = Injector.Get<IFacVtaServiceImpl>();
            this.listaTickets = listaTickets;
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            dgvInvoice.Rows.Clear();
            foreach (var item in listaTickets)
            {
                var invoice = ifactService.ListPendingInvoice(item.NroDoc, item.TipoDoc);
                dgvInvoice.Rows.Add(item.Id, invoice.CoSucursal, invoice.DesSucursal, invoice.CodClase, invoice.DesClase, invoice.CodDoc, invoice.NroDoc, invoice.FechaDoc, invoice.CodCliente, invoice.DesCliente, invoice.DocCliente, invoice.Observacion);
            }
        }
    }
}
