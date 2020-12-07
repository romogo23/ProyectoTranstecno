using BL;
using DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class BillByClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySession();
            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
            createContend(invoiceReceivingClientManager.LoadAllClients());
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            contentClientsName.Controls.Clear();


            InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();

            createContend(invoiceReceivingClientManager.LoadClients(tbxInsertClientName.Text.Trim().ToString()));

        }

        private void createContend(List<InvoiceReceivingClient> invoiceReceivingClient)
        {
            //HtmlGenericControl createH3Code = new HtmlGenericControl("H3");
            //createH3Code.ID = "createH3Code";
            //createH3Code.InnerHtml = "Lista de clientes";
            //createH3Code.Style.Add("class", "tittle");

            HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
            createDivCont.ID = "createDivCont";
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            //createDivCont.Controls.Add(createH3Code);
            //createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");
            createDiv.Style.Add(HtmlTextWriterStyle.Color, "White");
            //createDiv.Style.Add(HtmlTextWriterStyle.MarginBottom, "20px");
            //createDiv.Attributes.Add("class", "col-md-3 text-center");

            if (invoiceReceivingClient.Count > 0)
            {
                if (invoiceReceivingClient.Count > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        HtmlGenericControl createDetail = new HtmlGenericControl("a");
                        HtmlGenericControl createBr = new HtmlGenericControl("br");
                        createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                        createDetail.Attributes.Add("class", "clientDiv");
                        createDetail.Attributes.Add("href", "ViewBillsClient.aspx?idSupplier=" + invoiceReceivingClient[i].idClient);
                        createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span> " + invoiceReceivingClient[i].nameClient + "<br/>";

                        createDivCont.Controls.Add(createBr);
                        createDivCont.Controls.Add(createDetail);
                        createDiv.Controls.Add(createDivCont);
                    }
                }
                else
                {

                    foreach (InvoiceReceivingClient client in invoiceReceivingClient)
                    {
                        HtmlGenericControl createDetail = new HtmlGenericControl("a");
                        HtmlGenericControl createBr = new HtmlGenericControl("br");
                        createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                        createDetail.Attributes.Add("class", "clientDiv");
                        createDetail.Attributes.Add("href", "ViewBillsClient.aspx?idClient=" + client.idClient);
                        createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span> " + client.nameClient + "<br/>";

                        createDivCont.Controls.Add(createBr);
                        createDivCont.Controls.Add(createDetail);
                        createDiv.Controls.Add(createDivCont);


                    }
                }


                contentClientsName.Controls.Add(createDiv);


            }
            else
            {
                Response.Write("<script> alert('No se encontraron coincidencias') </script>");
                InvoiceReceivingClientManager invoiceReceivingClientManager = new InvoiceReceivingClientManager();
                createContend(invoiceReceivingClientManager.LoadAllClients());
            }

        }
    }
}