using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Data;
using ExcelDataReader;
using DOM;
using BL;

namespace WebApplication1
{
    public partial class ExcelTest : System.Web.UI.Page
    {
        private string customerIemplateIndicator = "Condición de Venta";
        private DataTable table;
        private string textEmpty= "vacio";
        private string verifyFileXls = ".xls";
        private string verifyFileXlsx = ".xlsx";
        private string noExcelFile = "no es de excel";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["table"] == null) {
                table = new DataTable();
            }
            else
            {
                table = (DataTable)ViewState["table"];
            }
        }

        protected void btnLoadInvoice_Click(object sender, EventArgs e)
        {
            if (FP.PostedFile.ContentLength <= 0)
            {
                lblInformationInvoice.Text = textEmpty ;
            }

            //Get the file extension  
            string fileExtension = Path.GetExtension(FP.FileName);

            //If file is not in excel format then return  
            if (fileExtension != verifyFileXls && fileExtension != verifyFileXlsx)
            { lblInformationInvoice.Text = noExcelFile; }
            else
            {

                string path = Server.MapPath("~/" + FP.FileName);
                //////saving the file inside the MyFolder of the server
                FP.SaveAs(path);
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        table = result.Tables[0];
                        grdInvoice.DataSource = table;
                        grdInvoice.DataBind();
                        btnUploadInvoice.Visible = true;
                        ViewState["table"] = table; 
                    }
                }
                File.Delete(path);
            }
        }

        protected void btnUploadInvoice_Click(object sender, EventArgs e)
        {
            string cell = table.Rows[0][11].ToString();
            if (cell == customerIemplateIndicator)
            {

                for (int row = 1; row < table.Rows.Count; row++)
                {
                    InvoiceReceivingClientManager invoiceReceivingClientM = new InvoiceReceivingClientManager();
                    invoiceReceivingClientM.InsertInvoiceReceivingClient(new InvoiceReceivingClient(table.Rows[row][8].ToString(), table.Rows[row][9].ToString(), table.Rows[row][7].ToString()));
                    InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
                    invoiceClientManager.InsertInvoiceClient(new InvoiceClient(int.Parse(table.Rows[row][1].ToString()), table.Rows[row][8].ToString(), DateTime.ParseExact(table.Rows[row][26].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture), 0, table.Rows[row][14].ToString(), double.Parse(table.Rows[row][24].ToString()), byte.Parse(table.Rows[row][10].ToString().Replace(table.Rows[row][10].ToString(), "0")), table.Rows[row][11].ToString()));

                }
            }
            else
            {


                for (int row1 = 1; row1 < table.Rows.Count; row1++)
                {
                    InvoiceReceivingSupplierManager invoiceReceivingSupplierM = new InvoiceReceivingSupplierManager();
                    invoiceReceivingSupplierM.InsertInvoiceReceivingSupplier(new InvoiceReceivingSupplier(table.Rows[row1][9].ToString(), "", table.Rows[row1][10].ToString()));
                    InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
                    invoiceSupplierManager.InsertInvoiceSupplier(new InvoiceSupplier(Int64.Parse(table.Rows[row1][2].ToString()), table.Rows[row1][6].ToString(), new DateTime(1753, 12, 12), 0, "", double.Parse(table.Rows[row1][23].ToString()), 0));

                }

            }
        }

    }
}
