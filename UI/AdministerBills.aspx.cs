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
    public partial class AdministerBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            
            List<BillName> billWNameList = invCM.loadInvoicesClientT();
            List<BillName> supplierbillWNameList = invSM.loadInvoicesSupplierT();

            fillClientsGrd(billWNameList);
            fillSupplierGrd(supplierbillWNameList);

            //No sé si crear dos grid o qué

        }

        protected void grdInvoices_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        private void fillClientsGrd(List<BillName> billWNameList)
        {
            DataTable tblInvoiceClient = new DataTable();
            
            tblInvoiceClient.Columns.Add("idInvoice");
            tblInvoiceClient.Columns.Add("ClientName");
            tblInvoiceClient.Columns.Add("TotalBill");
            tblInvoiceClient.Columns.Add("PaymentDate");
            tblInvoiceClient.Columns.Add("State");

            foreach (BillName invoice in billWNameList)
            {
                string condition = invoice.state.ToString();
                if (condition == "0")
                {
                    condition = "No pagado";
                }
                else
                {
                    condition = "Pagado";
                }

                tblInvoiceClient.Rows.Add(invoice.idInvoice.ToString(), invoice.clientName.ToString(), invoice.total.ToString(), invoice.reminderDate, condition);

            }

            grdInvoices.DataSource = tblInvoiceClient;
            grdInvoices.DataBind();
        }

        private void fillSupplierGrd(List<BillName> supplierbillWNameList)
        {
            DataTable tblInvoiceSupplier = new DataTable();
            int cont = 1;

            tblInvoiceSupplier.Columns.Add("idInvoiceSupplier");
            tblInvoiceSupplier.Columns.Add("SupplierName");
            tblInvoiceSupplier.Columns.Add("TotalBillSupplier");
            tblInvoiceSupplier.Columns.Add("PaymentDateSupplier");
            tblInvoiceSupplier.Columns.Add("StateSupplier");

            foreach (BillName invoice in supplierbillWNameList)
            {
                string condition = invoice.state.ToString();
                if (condition == "0")
                {
                    condition = "No pagado";
                }
                else
                {
                    condition = "Pagado";
                }

                tblInvoiceSupplier.Rows.Add(cont, invoice.clientName.ToString(), invoice.total.ToString(), invoice.reminderDate, condition);
                cont++;

            }

            grdSuppliers.DataSource = tblInvoiceSupplier;
            grdSuppliers.DataBind();
        }
    }
}