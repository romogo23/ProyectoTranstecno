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
        //string clientBillNumberCell = table.Rows[0][1].ToString();
        //string idClientCell = table.Rows[0][8].ToString();
        //string conditionClientCell = table.Rows[0][11].ToString();
        //string totalClientCell = table.Rows[0][24].ToString();
        //string dateClientCell = table.Rows[0][26].ToString();

        //string dateSupplierCell = table.Rows[0][3].ToString();
        //string supplierBillNumberCell = table.Rows[0][4].ToString();
        //string idSupplierCell = table.Rows[0][9].ToString();
        //string totalSupplierCell = table.Rows[0][23].ToString();

        private const string customerTemplateId = "# Factura";
        private const string customerId = "Cedula Receptor";
        private const string customerTemplateIndicator = "Condición de Venta";
        private const string customerTotal = "TotalFactura";
        private const string customerDate = "FechaVencimiento";

        private const string supplierDate = "FechaEmisionAceptacion";
        private const string supplierTemplateId = "ConsecutivoDocumento";
        private const string supplierId = "IdentificacionEmisor";
        private const string supplierTotal = "Total Colones";

        private DataTable table;
        private const string textEmpty = "Archivo vacío";
        private const string verifyFileXls = ".xls";
        private const string verifyFileXlsx = ".xlsx";
        private const string noExcelFile = "El archivo no es un archivo de excel";
        private const string noClientTemplateFile = "El archivo no contiene información de facturas de clientes";
        private const string noSupplierTemplateFile = "El archivo no contiene información de facturas de proveedores";


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
                lblInformationInvoice.Text = textEmpty;
            }

            //Get the file extension  
            string fileExtension = Path.GetExtension(FP.FileName);

            //If file is not in excel format then return  
            if (fileExtension != verifyFileXls && fileExtension != verifyFileXlsx)
            { 
                lblInformationInvoice.Text = noExcelFile;
            }
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
            //string clientBillNumberCell = table.Rows[0][1].ToString();
            //string idClientCell = table.Rows[0][8].ToString();
            //string conditionClientCell = table.Rows[0][11].ToString();
            //string totalClientCell = table.Rows[0][24].ToString();
            //string dateClientCell = table.Rows[0][26].ToString(); // PARA HACER LA VALIDACION DE SI ES UN ARCHIVO QUE POSEE FACTURAS!!

            string clientBillNumberCell = "";
            string idClientCell = "";
            string conditionClientCell = "";
            string totalClientCell = "";
            string dateClientCell = "";

            string dateSupplierCell = table.Rows[0][3].ToString();
            string supplierBillNumberCell = table.Rows[0][4].ToString();
            string idSupplierCell = table.Rows[0][9].ToString();
            string totalSupplierCell = table.Rows[0][23].ToString();

            if (clientBillNumberCell == customerTemplateId && idClientCell == customerId && conditionClientCell == customerTemplateIndicator 
                && totalClientCell == customerTotal && dateClientCell == customerDate)
            {

                for (int row = 1; row < table.Rows.Count; row++)
                {
                    InvoiceReceivingClientManager invoiceReceivingClientM = new InvoiceReceivingClientManager(); //LOS DE ABAJO SE PUEDEN CAMBIAR POR LAS VARIABLES
                    invoiceReceivingClientM.InsertInvoiceReceivingClient(new InvoiceReceivingClient(table.Rows[row][8].ToString(), table.Rows[row][9].ToString(), table.Rows[row][7].ToString()));
                    InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
                    //invoiceClientManager.InsertInvoiceClient(new InvoiceClient(int.Parse(table.Rows[row][1].ToString()), table.Rows[row][8].ToString(), DateTime.ParseExact(table.Rows[row][26].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture), 0, "", double.Parse(table.Rows[row][24].ToString()), 0, table.Rows[row][11].ToString()));

                }
            }
            else
            {
                if (dateSupplierCell == supplierDate && supplierBillNumberCell == supplierTemplateId && idSupplierCell == supplierId && 
                    totalSupplierCell == supplierTotal)
                {
                    for (int row1 = 1; row1 < table.Rows.Count; row1++)
                    {
                        InvoiceReceivingSupplierManager invoiceReceivingSupplierM = new InvoiceReceivingSupplierManager();
                        invoiceReceivingSupplierM.InsertInvoiceReceivingSupplier(new InvoiceReceivingSupplier(table.Rows[row1][9].ToString(), table.Rows[row1][10].ToString()));
                        InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
                        //invoiceSupplierManager.InsertInvoiceSupplier(new InvoiceSupplier(table.Rows[row1][4].ToString(), table.Rows[row1][9].ToString(), DateTime.ParseExact(table.Rows[row1][3].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture), 0, "", double.Parse(table.Rows[row1][23].ToString()), 0));

                    }
                }
                else
                {
                    lblInformationInvoice.Text = noSupplierTemplateFile;
                }
                lblInformationInvoice.Text = noClientTemplateFile;
            }
        }

    }
}
