using BL;
using DOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class BillByDate : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifySession();
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
                if (role.rol != 0 || role.rol != 1 || role.rol != 2)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
            

            InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
            InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
            
            if (DateTime.Parse(TxtStartDate.Text) > DateTime.Parse(TxtStartDate.Text) || DateTime.Parse(txtEndDate.Text) < DateTime.Parse(TxtStartDate.Text)) {
                Response.Write("<script> alert(" + "'Las fechas ingresadas son invalidas'" + ") </script>");
              
            }
            else {
               
                List<DOM.InvoiceClient> listInvoiceClient = invoiceClientManager.LoadInvoiceClientsBydate(DateTime.Parse(TxtStartDate.Text), DateTime.Parse(txtEndDate.Text));
                List<DOM.InvoiceSupplier> listInvoiceSupplier = invoiceSupplierManager.LoadInvoiceSupplierBydate(DateTime.Parse(TxtStartDate.Text), DateTime.Parse(txtEndDate.Text));
                if (listInvoiceClient.Count > 0 && listInvoiceSupplier.Count > 0)
                {
                    invoiceClient(listInvoiceClient);
                    invoiceSupplier(listInvoiceSupplier);
                    changebuttons();
                }
                else {

                    if (listInvoiceClient.Count > 0)
                    {
                        invoiceClient(listInvoiceClient);
                        changebuttons();

                    }
                    else {

                        if (listInvoiceSupplier.Count > 0)
                        {

                            invoiceSupplier(listInvoiceSupplier);
                            changebuttons();
                        }
                        else {

                            Response.Write("<script> alert(" + "'No se encontraron coincidencias'" + ") </script>");
                        }
                    }
                }
              
            }
           
        }


        private void changebuttons() {
            lblendDate.Visible = false;
            lblStartDate.Visible = false;
            TxtStartDate.Visible = false;
            txtEndDate.Visible = false;
            btnSearch.Visible = false;
        }


        private void invoiceClient(List<DOM.InvoiceClient> invoiceClient)
        {

            DataTable tblInvoiceClient = new DataTable();
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
            lblBillClient.Text = "Facturas de Clientes";

            tblInvoiceClient.Columns.Add("Número de Factura");
            tblInvoiceClient.Columns.Add("Nombre");
            tblInvoiceClient.Columns.Add("identificacion");
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

                InvoiceReceivingClient invoiceReceiving = invoiceReceivingClientManager.LoadClient(invoice.idClient);
                tblInvoiceClient.Rows.Add(invoice.numberInvoice.ToString(), invoiceReceiving.nameClient.ToString(), invoice.idClient.ToString(), invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"), payMethod, invoice.paymentCondition, invoice.reminderDate.ToString(), invoice.paymentDate.ToString());



            }

            gdInvoiceClient.DataSource = tblInvoiceClient;
            gdInvoiceClient.DataBind();
        }

        private void invoiceSupplier(List<DOM.InvoiceSupplier> invoiceSupplier)
        {


            DataTable tblInvoiceSupplier = new DataTable();
            InvoiceReceivingSupplierManager invoiceReceivingSuppliertManager = new InvoiceReceivingSupplierManager();
            lblBillSupplier.Text = "Facturas de Proveedores";

            tblInvoiceSupplier.Columns.Add("Número de Factura");
            tblInvoiceSupplier.Columns.Add("Nombre");
            tblInvoiceSupplier.Columns.Add("identificacion");
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
                InvoiceReceivingSupplier invoiceReceiving = invoiceReceivingSuppliertManager.LoadSupplier(invoice.idSupplier);



                tblInvoiceSupplier.Rows.Add(invoice.numberInvoice.ToString(), invoiceReceiving.nameSupplier, invoice.idSupplier, invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"), payMethod, invoice.reminderDate.ToString(), invoice.paymentDate.ToString());
            }

            gdInvoiceSupplier.DataSource = tblInvoiceSupplier;
            gdInvoiceSupplier.DataBind();
        }
    }
}