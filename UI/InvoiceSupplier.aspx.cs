using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;
using BL;
using System.Web.UI.HtmlControls;
using System.Data;

namespace UI
{
    public partial class InvoiceSupplier : System.Web.UI.Page
    {
        private HtmlGenericControl tr = new HtmlGenericControl("tr");
        private HtmlGenericControl tbody = new HtmlGenericControl("tbody"); //add tbody tag

        protected void Page_Load(object sender, EventArgs e)
        {
            String idSupplier = Request["idSupplier"];
            InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
            invoiceSupplier(invoiceSupplierManager.LoadInvoiceSupplier(idSupplier), invoiceReceivingSupplierManager.LoadSupplier(idSupplier));
        }


        //private void createContend(List<DOM.InvoiceSupplier> invoiceSupplier, InvoiceReceivingSupplier invoiceReceivingSupplier)
        //{




        //    HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
        //    createDivCont.ID = "createDivCont";
        //    HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
        //    createDiv.ID = "createDiv";
        //    createDivCont.Controls.Add(createH3(invoiceReceivingSupplier.nameSupplier));
        //    createDivCont.Controls.Add(createH3("IDENTIFICACIÓN: " + invoiceReceivingSupplier.idSupplier));
        //    createDivCont.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    createDivCont.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");


        //    HtmlGenericControl table = new HtmlGenericControl("table"); //Table create



        //    table.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");
        //    table.Attributes.Add("class", "classname"); //assign class

        //    HtmlGenericControl thead = new HtmlGenericControl("thead"); // add thead tag

        //    createth("Número de Factura");
        //    createth("Monto");
        //    createth("Estado");
        //    createth("Id Método pago");
        //    createth("MétodoPago");
        //    createth("Fecha Recordatorio");
        //    createth("Fecha Pago");

        //    thead.Controls.Add(tr); // header row add in thead
        //    table.Controls.Add(thead); //thead add in table

        //    //for datatable row count loop
        //    foreach (DOM.InvoiceSupplier invoice in invoiceSupplier)
        //    {
        //        string condition = invoice.condition.ToString();
        //        if (condition == "0")
        //        {
        //            condition = "No pagado";
        //        }
        //        else
        //        {
        //            condition = "Pagado";
        //        }

        //        string payMethod = invoice.payMethod.ToString();
        //        if (payMethod == "")
        //        {
        //            payMethod = "-";
        //        }

        //        HtmlGenericControl dataTR = new HtmlGenericControl("tr");

        //        createtd(invoice.numberInvoice.ToString(), dataTR);
        //        createtd(invoice.money.ToString(), dataTR);
        //        createtd(condition, dataTR);
        //        createtd(invoice.idPayMethod.ToString().Replace("0", "-"), dataTR);
        //        createtd(payMethod, dataTR);
        //        createtd(invoice.reminderDate.ToString(), dataTR);
        //        createtd(invoice.paymentDate.ToString(), dataTR);



        //    }
        //    table.Controls.Add(tbody); // tbody all row will add in table.



        //    createDivCont.Controls.Add(table);
        //    createDiv.Controls.Add(createDivCont);




        //    contentInvoiceSupplier.Controls.Add(createDiv);
        //}


        //private void createth(string name)
        //{
        //    HtmlGenericControl th = new HtmlGenericControl("th"); // add column of header
        //    th.Style.Add(HtmlTextWriterStyle.PaddingRight, "60px");
        //    th.Style.Add(HtmlTextWriterStyle.PaddingLeft, "20px");
        //    th.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    th.InnerText = name;
        //    th.Attributes.Add("class", "classname");
        //    tr.Controls.Add(th);
        //}

        //private void createtd(String data, HtmlGenericControl dataTR)
        //{
        //    HtmlGenericControl td = new HtmlGenericControl("td"); // add column
        //    td.InnerText = data;
        //    td.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    td.Attributes.Add("class", "classname");
        //    dataTR.Controls.Add(td);//add every column in row
        //    tbody.Controls.Add(dataTR); //row will add in tbody tag
        //}

        //private HtmlGenericControl createH3(string data)
        //{
        //    HtmlGenericControl createH4Code = new HtmlGenericControl("H4");
        //    createH4Code.ID = "createH4Code";
        //    createH4Code.InnerHtml = data;
        //    return createH4Code;
        //}



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

                tblInvoiceSupplier.Rows.Add(invoice.numberInvoice.ToString(), invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"), payMethod, invoice.reminderDate.ToString(), invoice.paymentDate.ToString());
            }

            gdInvoiceSupplier.DataSource = tblInvoiceSupplier;
            gdInvoiceSupplier.DataBind();
        }


    }
}