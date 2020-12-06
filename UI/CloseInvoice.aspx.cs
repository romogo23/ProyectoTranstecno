﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DOM;

namespace UI
{
    public partial class CloseInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String idInvoice = Request["idInvoice"];
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            String paymentMethod = ddlPaymentsMethods.SelectedItem.ToString();
            //Console.WriteLine(txtIdPaymentMethod.Text.ToString());
            int idPaymentMethod = int.Parse(txtIdPaymentMethod.Text.ToString());
            //Console.WriteLine(idPaymentMethod);
            DateTime paymentDate = DateTime.Parse(txtPaymentDate.Text);

            if (invCM.verifyInvoiceClient(int.Parse(idInvoice)) == 1)
            {
                DOM.InvoiceClient invoice = invCM.loadInvoiceClientById(idInvoice);
                invoice.payMethod = paymentMethod;
                invoice.idPayMethod = idPaymentMethod;
                invoice.paymentDate = paymentDate;
                invoice.condition = 1;

                if (invCM.ModifyInvoiceClient(invoice))
                {
                    //Mensaje de exito
                    Response.Redirect("~/ManageInvoices.aspx");
                }

            }
            else
            {
                if (invSM.verifyInvoiceSupplier(idInvoice) == 1)
                {
                    DOM.InvoiceSupplier invoice = invSM.loadSupplierById(idInvoice);
                    invoice.payMethod = paymentMethod;
                    invoice.idPayMethod = idPaymentMethod;
                    invoice.paymentDate = paymentDate;
                    invoice.condition = 1;

                    if (invSM.ModifyInvoiceSupplier(invoice))
                    {
                        //Mensaje de exito
                        Response.Redirect("~/ManageInvoices.aspx");
                    }


                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManageInvoices.aspx");
        }
    }
}