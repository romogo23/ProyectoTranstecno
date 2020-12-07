using BL;
using DOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class ViewBillsClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String idClient = Request["idClient"];
            InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
            invoiceClient(invoiceClientManager.LoadInvoiceClient(idClient), invoiceReceivingClientManager.LoadClient(idClient));
        }

        private void invoiceClient(List<DOM.InvoiceClient> invoiceClient, InvoiceReceivingClient invoiceReceivingClient)
        {

            lblName.Text = invoiceReceivingClient.nameClient;
            lblEmail.Text = "CORREO: " + invoiceReceivingClient.email;
            lblID.Text = "IDENTIFICACIÓN: " + invoiceReceivingClient.idClient;

            DataTable tblInvoiceClient = new DataTable();

            tblInvoiceClient.Columns.Add("Número de Factura");
            tblInvoiceClient.Columns.Add("Monto");
            tblInvoiceClient.Columns.Add("Estado");
            tblInvoiceClient.Columns.Add("Id Método pago");
            tblInvoiceClient.Columns.Add("MétodoPago");
            tblInvoiceClient.Columns.Add("Condición");
            tblInvoiceClient.Columns.Add("Fecha Recordatorio");
            tblInvoiceClient.Columns.Add("Fecha Pago");



            foreach (DOM.InvoiceClient invoice in invoiceClient)
            {
                string condition = invoice.condition.ToString();
                if (condition == "0")
                {
                    condition = "No pagado";
                }
                else
                {
                    condition = "Pagado";
                }

                string payMethod = invoice.payMethod.ToString();
                if (payMethod == "")
                {
                    payMethod = "-";
                }



                tblInvoiceClient.Rows.Add(invoice.numberInvoice.ToString(), invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"), payMethod, invoice.paymentCondition, invoice.reminderDate.ToString("dd/MM/yyyy"), invoice.paymentDate.ToString("dd/MM/yyyy").Replace("01/01/1900", "-"));



            }

            gdInvoiceClient.DataSource = tblInvoiceClient;
            gdInvoiceClient.DataBind();
        }
    }
}