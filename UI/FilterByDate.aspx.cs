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
    public partial class FilterByDate : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblendDate.Visible = false;
            lblStartDate.Visible = false;
            TxtStartDate.Visible = false;
            txtEndDate.Visible = false;
            btnSearch.Visible = false;

            InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
            InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
            invoiceClient(invoiceClientManager.LoadInvoiceClientsBydate( DateTime.Parse(TxtStartDate.Text), DateTime.Parse(txtEndDate.Text)));
            invoiceSupplier(invoiceSupplierManager.LoadInvoiceSupplierBydate(DateTime.Parse(TxtStartDate.Text), DateTime.Parse(txtEndDate.Text)));
        }


        //private void createContentClient(List<DOM.InvoiceClient> invoiceClient)
        //{



        //    HtmlGenericControl tr = new HtmlGenericControl("tr");

        //    HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
        //    createDivCont.ID = "createDivCont";
        //    HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
        //    createDiv.ID = "createDiv";
        //    createDivCont.Controls.Add(createH3("Facturas Clientes"));
        //    createDivCont.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    createDivCont.Style.Add(HtmlTextWriterStyle.Padding, "20px");



        //    HtmlGenericControl table = new HtmlGenericControl("table"); //Table create



        //    table.Attributes.Add("class", "classname"); //assign class

        //    HtmlGenericControl thead = new HtmlGenericControl("thead"); // add thead tag

        //    createth("Número de Factura", tr);
        //    createth("Nombre", tr);
        //    createth("identificacion", tr);
        //    createth("Monto", tr);
        //    createth("Estado", tr);
        //    createth("Id Método pago", tr);
        //    createth("MétodoPago", tr);
        //    createth("Condición", tr);
        //    createth("Fecha Recordatorio", tr);
        //    createth("Fecha Pago", tr);

        //    thead.Controls.Add(tr); // header row add in thead
        //    table.Controls.Add(thead); //thead add in table
        //    HtmlGenericControl tbody = new HtmlGenericControl("tbody");

        //    //for datatable row count loop
        //    foreach (DOM.InvoiceClient invoice in invoiceClient)
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
        //        InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
        //        InvoiceReceivingClient invoiceReceiving = invoiceReceivingClientManager.LoadClient(invoice.idClient);

        //        HtmlGenericControl dataTR = new HtmlGenericControl("tr");

        //        createtd(invoice.numberInvoice.ToString(), dataTR, tbody);
        //        createtd(invoiceReceiving.nameClient.ToString(), dataTR, tbody);
        //        createtd(invoice.idClient.ToString(), dataTR, tbody);
        //        createtd(invoice.money.ToString(), dataTR, tbody);
        //        createtd(condition, dataTR, tbody);
        //        createtd(invoice.idPayMethod.ToString().Replace("0", "-"), dataTR, tbody);
        //        createtd(payMethod, dataTR, tbody);
        //        createtd(invoice.paymentCondition, dataTR, tbody);
        //        createtd(invoice.reminderDate.ToString(), dataTR, tbody);
        //        createtd(invoice.paymentDate.ToString(), dataTR, tbody);



        //    }
        //    table.Controls.Add(tbody); // tbody all row will add in table.



        //    createDivCont.Controls.Add(table);
        //    createDivCont.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");
        //    createDiv.Controls.Add(createDivCont);




        //    contentInvoiceByDate.Controls.Add(createDiv);
        //}


        //private void createContentSuppliers(List<DOM.InvoiceSupplier> invoiceSupplier)
        //{

        //    HtmlGenericControl tr = new HtmlGenericControl("tr");

        //    HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
        //    createDivCont.ID = "createDivCont";
        //    HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
        //    createDiv.ID = "createDiv";
        //    createDivCont.Controls.Add(createH3("Facturas Proveedores"));
        //    createDivCont.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    createDivCont.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");


        //    HtmlGenericControl table = new HtmlGenericControl("table"); //Table create



        //    table.Attributes.Add("class", "classname"); //assign class

        //    HtmlGenericControl thead = new HtmlGenericControl("thead"); // add thead tag

        //    createth("Número de Factura", tr);
        //    createth("Nombre", tr);
        //    createth("identificacion", tr);
        //    createth("Monto", tr);
        //    createth("Estado", tr);
        //    createth("Id Método pago", tr);
        //    createth("MétodoPago", tr);
        //    createth("Fecha Recordatorio", tr);
        //    createth("Fecha Pago", tr);

        //    thead.Controls.Add(tr); // header row add in thead
        //    table.Controls.Add(thead); //thead add in table
        //    HtmlGenericControl tbody = new HtmlGenericControl("tbody");

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

        //        InvoiceReceivingSupplierManager invoiceReceivingSuppliertManager = new InvoiceReceivingSupplierManager();
        //        InvoiceReceivingSupplier invoiceReceiving = invoiceReceivingSuppliertManager.LoadSupplier(invoice.idSupplier);


        //        HtmlGenericControl dataTR = new HtmlGenericControl("tr");

        //        createtd(invoice.numberInvoice.ToString(), dataTR,tbody);
        //        createtd(invoiceReceiving.nameSupplier, dataTR, tbody);
        //        createtd(invoice.idSupplier, dataTR, tbody);
        //        createtd(invoice.money.ToString(), dataTR, tbody);
        //        createtd(condition, dataTR, tbody);
        //        createtd(invoice.idPayMethod.ToString().Replace("0", "-"), dataTR, tbody);
        //        createtd(payMethod, dataTR, tbody);
        //        createtd(invoice.reminderDate.ToString(), dataTR, tbody);
        //        createtd(invoice.paymentDate.ToString(), dataTR, tbody);



        //    }
        //    table.Controls.Add(tbody); // tbody all row will add in table.



        //    createDivCont.Controls.Add(table);
        //    createDiv.Controls.Add(createDivCont);




        //    contentInvoiceSupplier.Controls.Add(createDiv);
        //}


        //private void createth(string name, HtmlGenericControl tr)
        //{
        //    HtmlGenericControl th = new HtmlGenericControl("th"); // add column of header
        //    th.Style.Add(HtmlTextWriterStyle.Color, "White");
        //    th.InnerText = name;
        //    th.Attributes.Add("class", "classname");
        //    tr.Controls.Add(th);
        //}

        //private void createtd(String data, HtmlGenericControl dataTR, HtmlGenericControl tbody)
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



        private void invoiceClient(List<DOM.InvoiceClient> invoiceClient)
        {

            DataTable tblInvoiceClient = new DataTable();
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();

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