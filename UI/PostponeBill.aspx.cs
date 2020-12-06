using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class PostponeBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String idInvoice = Request["idInvoice"];
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            DateTime paymentDate = DateTime.Parse(txtPaymentDate.Text);

            if (invCM.verifyInvoiceClient(int.Parse(idInvoice)) == 1)
            {
                DOM.InvoiceClient invoice = invCM.loadInvoiceClientById(idInvoice);
                invoice.paymentDate = paymentDate;

                if (invCM.ModifyInvoiceClient(invoice))
                {
                    //Mensaje de exito
                    Response.Redirect("~/AdministerBills.aspx");
                }

            }
            else
            {
                if (invSM.verifyInvoiceSupplier(idInvoice) == 1)
                {
                    DOM.InvoiceSupplier invoice = invSM.loadSupplierById(idInvoice);
                    invoice.paymentDate = paymentDate;
                    if (invSM.ModifyInvoiceSupplier(invoice))
                    {
                        //Mensaje de exito
                        Response.Redirect("~/AdministerBills.aspx");
                    }


                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdministerBills.aspx");
        }
    }
}