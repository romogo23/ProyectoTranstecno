using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;
using BL;
using System.Data;

namespace UI
{
    public partial class InvoiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert_Click(object sender, EventArgs e)
        {
            InvoiceClient inV = new InvoiceClient(219, "3101005212", new DateTime(2019, 12, 27), 0, "Efectivo", 1370742.91, 0, "Credito");
            InvoiceClientManager inM = new InvoiceClientManager();
            inM.InsertInvoiceClient(inV);
            
        }

        protected void modify_Click(object sender, EventArgs e)
        {
            InvoiceClient inV = new InvoiceClient(216, new DateTime(2019, 12, 30), 0, "Cheque");
            InvoiceClientManager inM = new InvoiceClientManager();
            inM.ModifyInvoiceClient(inV);

        }

        protected void close_Click(object sender, EventArgs e)
        {
            InvoiceClient inV = new InvoiceClient(216, new DateTime(2019, 12, 30), 231, "Cheque");
            InvoiceClientManager inM = new InvoiceClientManager();
            inM.CloseInvoiceClient(inV);
        }

        protected void loadC_Click(object sender, EventArgs e)
        {
            InvoiceClientManager inM = new InvoiceClientManager();
            DataTable tbInvoice = new DataTable();
            DataTable tbInvoiceClient = new DataTable();
            InvoiceReceivingClientManager invRCM = new InvoiceReceivingClientManager();
            InvoiceReceivingClient client = invRCM.LoadClient("3101005212");

            tbInvoiceClient.Columns.Add("Nombre");
            tbInvoiceClient.Columns.Add("Identificacion");
            tbInvoiceClient.Columns.Add("correo");

            tbInvoiceClient.Rows.Add(client.nameClient, client.idClient, client.email);
            grdClient.DataSource = tbInvoiceClient;
            grdClient.DataBind();

            tbInvoice.Columns.Add("Número de Factura");
            tbInvoice.Columns.Add("Monto");
            tbInvoice.Columns.Add("Estado");
            tbInvoice.Columns.Add("Id Método de Pago");
            tbInvoice.Columns.Add("Método de Pago");
            tbInvoice.Columns.Add("Condición Pago");
            tbInvoice.Columns.Add("Fecha de Pago");

            List<InvoiceClient> orderList = inM.LoadInvoiceClient("3101005212");
            foreach (InvoiceClient invC in orderList)
            {

                tbInvoice.Rows.Add(invC.numberInvoice, invC.money, invC.condition, invC.idPayMethod, invC.payMethod, invC.paymentCondition, invC.paymentDate);
            }

            GridInvoice.DataSource = tbInvoice;
            GridInvoice.DataBind();
        }

        protected void loadDate_Click(object sender, EventArgs e)
        {
            InvoiceClientManager inM = new InvoiceClientManager();
            DataTable tbInvoice = new DataTable();

            tbInvoice.Columns.Add("Número de Factura");
            tbInvoice.Columns.Add("Monto");
            tbInvoice.Columns.Add("Estado");
            tbInvoice.Columns.Add("Id Método de Pago");
            tbInvoice.Columns.Add("Método de Pago");
            tbInvoice.Columns.Add("Condición Pago");
            tbInvoice.Columns.Add("Fecha de Pago");

            List<InvoiceClient> orderList = inM.LoadInvoiceClientsBydate(new DateTime(2019,01,01), new DateTime(2020, 12, 12));
            foreach (InvoiceClient invC in orderList)
            {

                tbInvoice.Rows.Add(invC.numberInvoice, invC.money, invC.condition, invC.idPayMethod, invC.payMethod, invC.paymentCondition, invC.paymentDate);
            }

            GridInvoice.DataSource = tbInvoice;
            GridInvoice.DataBind();
        }
    }
}