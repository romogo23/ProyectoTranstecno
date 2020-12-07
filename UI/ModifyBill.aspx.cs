using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;

namespace UI
{
    public partial class ModifyBill : System.Web.UI.Page
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdministerBills.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String idInvoice = Request["idInvoice"];
            String idInvoiceSupplier = "";
            User role = (User)Session["userWithRol"];
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            String paymentMethod = ddlPaymentsMethods.SelectedItem.ToString();
            UserManager userM = new UserManager();
            int idPaymentMethod = int.Parse(txtIdPaymentMethod.Text.ToString());
            //Console.WriteLine(idPaymentMethod);
            DateTime paymentDate = DateTime.Parse(txtPaymentDate.Text);

            if (idInvoice.Length < 10)
            {
                if (invCM.verifyInvoiceClient(int.Parse(idInvoice)) == 1)
                {
                    DOM.InvoiceClient invoice = invCM.loadInvoiceClientById(idInvoice);
                    if (paymentMethod == "Transferencia")
                    {
                        paymentMethod = "Transferen.";
                    }
                    invoice.payMethod = paymentMethod;
                    invoice.idPayMethod = idPaymentMethod;
                    invoice.paymentDate = paymentDate;

                    if (invCM.ModifyInvoiceClient(invoice))
                    {
                        userM.UserModifyInvoiceClient(role.username, int.Parse(idInvoice));
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
                    if (paymentMethod == "Transferencia")
                    {
                        paymentMethod = "Transferen.";
                    }
                    invoice.payMethod = paymentMethod;
                    invoice.idPayMethod = idPaymentMethod;
                    invoice.paymentDate = paymentDate;
                    if (invSM.ModifyInvoiceSupplier(invoice))
                    {
                        userM.UserModifyInvoiceSupplier(role.username, idInvoiceSupplier);
                        //Mensaje de exito
                        Response.Redirect("~/AdministerBills.aspx");
                    }


                }
            }
        }
    }
}