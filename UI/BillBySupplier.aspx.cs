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
    public partial class BillBySupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySession();
            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
            createContend(invoiceReceivingSupplierManager.LoadAllSuppliers());
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
            contentSuplierName.Controls.Clear();


            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();

            createContend(invoiceReceivingSupplierManager.LoadSuppliers(tbxInsertSupplierName.Text.Trim().ToString()));

        }

        private void createContend(List<InvoiceReceivingSupplier> invoiceReceivingSupplier)
        {
            //HtmlGenericControl createH3Code = new HtmlGenericControl("H3");
            //createH3Code.ID = "createH3Code";
            //createH3Code.InnerHtml = "Lista de clientes";

            HtmlGenericControl createDivCont = new HtmlGenericControl("DIV");
            createDivCont.ID = "createDivCont";
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            //createDivCont.Controls.Add(createH3Code);
            //createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "Black");
            createDiv.Style.Add(HtmlTextWriterStyle.Color, "White");
            //createDiv.Style.Add(HtmlTextWriterStyle.Padding, "20px");
            //createDiv.Attributes.Add("class", "col-sm-3 text-center");

            if (invoiceReceivingSupplier.Count > 0)
            {
                if (invoiceReceivingSupplier.Count > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        HtmlGenericControl createDetail = new HtmlGenericControl("a");
                        HtmlGenericControl createBr = new HtmlGenericControl("br");
                        createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                        createDetail.Attributes.Add("class", "clientDiv");
                        createDetail.Attributes.Add("href", "ViewBillsSupplier.aspx?idSupplier=" + invoiceReceivingSupplier[i].idSupplier);
                        createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span> " + invoiceReceivingSupplier[i].nameSupplier + "<br/>";

                        createDivCont.Controls.Add(createBr);
                        createDivCont.Controls.Add(createDetail);
                        createDiv.Controls.Add(createDivCont);
                    }
                }
                else
                {
                    foreach (InvoiceReceivingSupplier client in invoiceReceivingSupplier)
                    {

                        HtmlGenericControl createDetail = new HtmlGenericControl("a");
                        HtmlGenericControl createBr = new HtmlGenericControl("br");
                        createDetail.Style.Add(HtmlTextWriterStyle.Color, "White");
                        createDetail.Attributes.Add("class", "clientDiv");
                        createDetail.Attributes.Add("href", "ViewBillsSupplier.aspx?idSupplier=" + client.idSupplier);
                        createDetail.InnerHtml = "<span class='glyphicon glyphicon-info-sign'></span> " + client.nameSupplier + "<br/>";

                        createDivCont.Controls.Add(createBr);
                        createDivCont.Controls.Add(createDetail);
                        createDiv.Controls.Add(createDivCont);
                    }
                }

                contentSuplierName.Controls.Add(createDiv);

            }
            else
            {
                Response.Write("<script> alert('No se encontraron coincidencias') </script>");
                InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
                createContend(invoiceReceivingSupplierManager.LoadAllSuppliers());
            }

        }
    }
}