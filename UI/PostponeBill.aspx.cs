using BL;
using DOM;
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
            VerifySession();
        }

        private void VerifySession()
        {
            if (Session["userWithRol"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                User role = (User)Session["userWithRol"];
                if (role.rol < 0 || role.rol > 1)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String idInvoice = Request["idInvoice"];
            String idInvoiceSupplier = "";

            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            DateTime paymentDate = DateTime.Parse(txtPaymentDate.Text);

            if (idInvoice.Length < 10)
            {
                if (invCM.verifyInvoiceClient(int.Parse(idInvoice)) == 1)
                {
                    DOM.InvoiceClient invoice = invCM.loadInvoiceClientById(idInvoice);
                    invoice.paymentDate = paymentDate;

                    if (invCM.ModifyInvoiceClientPostpone(invoice))
                    {
                        //Mensaje de exito
                        Response.Redirect("~/AdministerBills.aspx");
                    }
                }
            }
            else
            {
                idInvoiceSupplier = idInvoice.Replace(" ", String.Empty);

                if (invSM.verifyInvoiceSupplier(idInvoiceSupplier) == 1)
                {
                    DOM.InvoiceSupplier invoice = invSM.loadSupplierById(idInvoiceSupplier);
                    invoice.paymentDate = paymentDate;
                    if (invSM.ModifyInvoiceSupplierPostpone(invoice))
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