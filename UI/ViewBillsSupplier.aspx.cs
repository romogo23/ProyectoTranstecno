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
    public partial class ViewBillsSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySession();
            String idSupplier = Request["idSupplier"];
            InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
            invoiceSupplier(invoiceSupplierManager.LoadInvoiceSupplier(idSupplier), invoiceReceivingSupplierManager.LoadSupplier(idSupplier));
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
                if (role.rol < 0 || role.rol > 2)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        private void invoiceSupplier(List<DOM.InvoiceSupplier> invoiceSupplier, InvoiceReceivingSupplier invoiceReceivingSupplier)
        {

            lblName.Text = invoiceReceivingSupplier.nameSupplier;
            lblID.Text = "IDENTIFICACIÓN: " + invoiceReceivingSupplier.idSupplier;

            DataTable tblInvoiceSupplier = new DataTable();

            tblInvoiceSupplier.Columns.Add("Número de Factura");
            tblInvoiceSupplier.Columns.Add("Monto");
            tblInvoiceSupplier.Columns.Add("Estado");
            tblInvoiceSupplier.Columns.Add("Id Método pago");
            tblInvoiceSupplier.Columns.Add("MétodoPago");
            tblInvoiceSupplier.Columns.Add("Fecha Recordatorio");
            tblInvoiceSupplier.Columns.Add("Fecha Pago");

            foreach (DOM.InvoiceSupplier invoice in invoiceSupplier)
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

                tblInvoiceSupplier.Rows.Add(invoice.numberInvoice.ToString(), invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"), payMethod, invoice.reminderDate.ToString("dd/MM/yyyy"), invoice.paymentDate.ToString("dd/MM/yyyy").Replace("01/01/1900", "-"));
            }

            gdInvoiceSupplier.DataSource = tblInvoiceSupplier;
            gdInvoiceSupplier.DataBind();
        }

    }
}