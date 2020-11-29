using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DOM;
using BL;
using System.Web.UI.HtmlControls;

namespace UI
{
    public partial class FilterByClient : System.Web.UI.Page
    {
        DataTable tblClients = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
            createContend(invoiceReceivingClientManager.LoadAllClients());


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            contentClientsName.Controls.Clear();


            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();

            createContend(invoiceReceivingClientManager.LoadClients(tbxInsertClientName.Text.Trim().ToString()));
            
        }

        private void createContend(List<InvoiceReceivingClient> invoiceReceivingClient) {
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


            foreach (InvoiceReceivingClient client in invoiceReceivingClient)
            {
                HtmlGenericControl createDetail = new HtmlGenericControl("a");
                createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                createDetail.Attributes.Add("href", "InvoiceClient.aspx?idClient=" + client.idClient);
                createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span>" + client.nameClient + "<br/>";

                createDivCont.Controls.Add(createDetail);
                createDiv.Controls.Add(createDivCont);


            }


            contentClientsName.Controls.Add(createDiv);

        }
    }
}