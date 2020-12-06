﻿using System;
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
    public partial class InvoiceClient : System.Web.UI.Page
    {

        private HtmlGenericControl tr = new HtmlGenericControl("tr");
        private HtmlGenericControl tbody = new HtmlGenericControl("tbody"); //add tbody tag

        protected void Page_Load(object sender, EventArgs e)
        {
            String idClient = Request["idClient"];
            InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
            invoiceClient(invoiceClientManager.LoadInvoiceClient(idClient), invoiceReceivingClientManager.LoadClient(idClient));
        }

        //private void createContend(List<DOM.InvoiceClient> invoiceClient, InvoiceReceivingClient invoiceReceivingClient)
        //{
            



        //    HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
        //    createDivCont.ID = "createDivCont";
        //    HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
        //    createDiv.ID = "createDiv";
        //    createDivCont.Controls.Add(createH3(invoiceReceivingClient.nameClient));
        //    createDivCont.Controls.Add(createH3(invoiceReceivingClient.email));
        //    createDivCont.Controls.Add(createH3("IDENTIFICACIÓN: " + invoiceReceivingClient.idClient));
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
        //    createth("Condición");
        //    createth("Fecha Recordatorio");
        //    createth("Fecha Pago");

            

        //    thead.Controls.Add(tr); // header row add in thead
        //    table.Controls.Add(thead); //thead add in table

        //    //for datatable row count loop
        //    foreach (DOM.InvoiceClient invoice in invoiceClient)
        //    {
        //        string condition = invoice.condition.ToString();
        //        if (condition == "0") {
        //            condition = "No pagado";
        //        } else {
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
        //        createtd(invoice.paymentCondition, dataTR);
        //        createtd(invoice.reminderDate.ToString(), dataTR);
        //        createtd(invoice.paymentDate.ToString(), dataTR);



        //    }
        //    table.Controls.Add(tbody); // tbody all row will add in table.



        //    createDivCont.Controls.Add(table);
        //    createDiv.Controls.Add(createDivCont);




        //    //contentInvoiceClient.Controls.Add(createDiv);
        //}


        //private void createth(string name) {
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

        //private HtmlGenericControl createH3 (string data)
        //{
        //    HtmlGenericControl createH4Code = new HtmlGenericControl("H4");
        //    createH4Code.ID = "createH4Code";
        //    createH4Code.InnerHtml = data;
        //    return createH4Code;
        //}


        private void invoiceClient(List<DOM.InvoiceClient> invoiceClient, InvoiceReceivingClient invoiceReceivingClient) {

            lblName.Text= invoiceReceivingClient.nameClient;
            lblEmail.Text = invoiceReceivingClient.email;
            lblID.Text = "IDENTIFICACIÓN: " + invoiceReceivingClient.idClient;

            DataTable tblInvoiceClient = new DataTable();

            tblInvoiceClient.Columns.Add("Número de Factura");
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



                tblInvoiceClient.Rows.Add(invoice.numberInvoice.ToString(), invoice.money.ToString(), condition, invoice.idPayMethod.ToString().Replace("0", "-"),payMethod,invoice.paymentCondition, invoice.reminderDate.ToString(), invoice.paymentDate.ToString());



            }

            gdInvoiceClient.DataSource = tblInvoiceClient;
            gdInvoiceClient.DataBind();
        }

    }
}