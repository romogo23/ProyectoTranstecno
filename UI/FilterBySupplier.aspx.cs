using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;
using BL;
using System.Web.UI.HtmlControls;

namespace UI
{
    public partial class FilterBySupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
            createContend(invoiceReceivingSupplierManager.LoadAllSuppliers());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            contentSuplierName.Controls.Clear();


            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();

            createContend(invoiceReceivingSupplierManager.LoadSuppliers(tbxInsertSupplierName.Text.Trim().ToString()));

        }

        private void createContend(List<InvoiceReceivingSupplier> invoiceReceivingSupplier)
        {
            HtmlGenericControl createH3Code = new HtmlGenericControl("H3");
            createH3Code.ID = "createH3Code";
            createH3Code.InnerHtml = "Lista de clientes";

            HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
            createDivCont.ID = "createDivCont";
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDivCont.Controls.Add(createH3Code);
            createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");
            createDiv.Style.Add(HtmlTextWriterStyle.Color, "White");
            createDiv.Style.Add(HtmlTextWriterStyle.Padding, "20px");
            createDiv.Attributes.Add("class", "col-sm-3 text-center");

            foreach (InvoiceReceivingSupplier client in invoiceReceivingSupplier)
            {

                HtmlGenericControl createDetail = new HtmlGenericControl("a");
                createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                createDetail.Attributes.Add("href", "InvoiceSupplier.aspx?idSupplier=" + client.idSupplier);
                createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span>" + client.nameSupplier+ "<br/>";

                createDivCont.Controls.Add(createDetail);
                createDiv.Controls.Add(createDivCont);
            }

            contentSuplierName.Controls.Add(createDiv);
        }

    }
}