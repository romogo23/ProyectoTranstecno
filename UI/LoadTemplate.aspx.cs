using BL;
using DOM;
using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class LoadTemplate : System.Web.UI.Page
    {
        // PROBLEMAS CON ARCHIVOS QUE SE SUBEN CUANDO HAY ERROR, PROBLEMAS CON LOS BOTONES VISIBLES

        private const string customerTemplateId = "# Factura";
        private const string customerId = "Cedula Receptor";
        private const string customerTemplateIndicator = "Condición de Venta";
        private const string customerTotal = "TotalFactura";
        private const string customerDate = "FechaVencimiento";

        private const string supplierDate = "FechaEmisionAceptacion";
        private const string supplierTemplateId = "ConsecutivoDocumento";
        private const string supplierId = "IdentificacionEmisor";
        private const string supplierTotal = "Total Colones";

        private const string textEmpty = "Archivo vacío";
        private const string verifyFileXls = ".xls";
        private const string verifyFileXlsx = ".xlsx";
        private const string noExcelFile = "El archivo no es un archivo de excel";
        private const string noClientTemplateFile = "El archivo no contiene información de facturas de clientes";
        private const string noSupplierTemplateFile = "El archivo no contiene información de facturas de proveedores";

        private DataTable table;
        private Boolean isClient;
        private int failDateBillClient = 0;
        private int failDateBillSupplier = 0;

        private Hashtable _schedleData;

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySession();
            _schedleData = GetSchedule();

            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.MonthYear;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Left;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Top;
            Calendar1.DayStyle.Height = new Unit(75);
            Calendar1.DayStyle.Width = new Unit(100);
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.LightGray;
            btnUploadInvoice.Visible = false;
            if (ViewState["table"] == null)
            {
                table = new DataTable();
            }
            else
            {
                table = (DataTable)ViewState["table"];
            }

            if (ViewState["isClient"] == null)
            {
                isClient = new Boolean();
            }
            else
            {
                isClient = (Boolean)ViewState["isClient"];
            }
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
                if (role.rol < 0 && role.rol > 2)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        private Hashtable GetSchedule()
        {
            Hashtable schedule = new Hashtable();
            List<Reminder> reminderClientList = new List<Reminder>();
            List<Reminder> reminderSupplierList = new List<Reminder>();
            InvoiceClientManager clientMan = new InvoiceClientManager();
            InvoiceSupplierManager supplierMan = new InvoiceSupplierManager();

            reminderClientList = clientMan.LoadClientMonthReminder();
            reminderSupplierList = supplierMan.LoadSupplierMonthReminder();

            foreach (Reminder rem in reminderClientList)
            {
                schedule[rem.date.ToShortDateString()] = "Cliente: "  + rem.description;
            }
            foreach (Reminder remS in reminderSupplierList)
            {
                schedule[remS.date.ToShortDateString()] = "Proveedor: " + remS.description;
            }

            return schedule;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (_schedleData[e.Day.Date.ToShortDateString()] != null)
            {
                Literal lit = new Literal();
                lit.Text = "<br/>";
                e.Cell.Controls.Add(lit);

                Label lbl = new Label();
                lbl.Text = (String)_schedleData[e.Day.Date.ToShortDateString()];
                lbl.Font.Size = new FontUnit(FontSize.Smaller);
                lbl.ForeColor = System.Drawing.Color.DarkOrange;
                e.Cell.Controls.Add(lbl);
            }
        }

        protected void btnLoadInvoice_Click(object sender, EventArgs e)
        {
            lblInformationInvoice.Text = "";
            string clientBillNumberCell = "";
            string idClientCell = "";
            string conditionClientCell = "";
            string totalClientCell = "";
            string dateClientCell = ""; // PARA HACER LA VALIDACION DE SI ES UN ARCHIVO QUE POSEE FACTURAS!!

            string dateSupplierCell = "";
            string supplierBillNumberCell = "";
            string idSupplierCell = "";
            string totalSupplierCell = "";

            if (FP.PostedFile.ContentLength <= 0)
            {
                btnUploadInvoice.Visible = false;
                lblInformationInvoice.Text = textEmpty;
                
                
            }

            //Get the file extension  
            string fileExtension = Path.GetExtension(FP.FileName);

            //If file is not in excel format then return  
            if (fileExtension != verifyFileXls && fileExtension != verifyFileXlsx)
            {
                btnUploadInvoice.Visible = false;
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
                        btnUploadInvoice.Visible = false;

                       
                             if (table.Rows[0][1].ToString() == customerTemplateId)
                             {
                           // grdInvoice.DataSource = table;
                           // grdInvoice.DataBind();

                             ViewState["table"] = table;
                            isClient = true;
                            ViewState["isClient"] = isClient;
                            if (validateInvoice() == true)
                            {
                                btnUploadInvoice.Visible = true;
                            }

                             }
                            else
                           {
                            if (table.Rows[0][3].ToString() == supplierDate)
                             {
                            //grdInvoice.DataSource = table;
                            //grdInvoice.DataBind();

                            ViewState["table"] = table;
                             isClient = false;
                             ViewState["isClient"] = isClient;
                                if (validateInvoice() == true)
                                {
                                    btnUploadInvoice.Visible = true;
                                }
                                return;

                            }
                             else
                            {
                             btnUploadInvoice.Visible = false;
                            //Response.Write("<script> alert(" + "'El archivo no coincide con el formato de las plantillas'" + ") </script>");
                             lblInformationInvoice.Text = "El archivo no coincide con el formato de las plantillas";

                            return;

                            }
                            }

                        }
                }
                lblInformationInvoice.Text = "";
                File.Delete(path);
            }
        }


        protected void btnUploadInvoice_Click(object sender, EventArgs e)
        { //VALIDAR LA FECHA = 9999/99/99
            // VAIDAR EL NULL DE LA FECHA DE PAGO
            string clientBillNumberCell = "";
            string idClientCell = "";
            string conditionClientCell = "";
            string totalClientCell = "";
            string dateClientCell = ""; // PARA HACER LA VALIDACION DE SI ES UN ARCHIVO QUE POSEE FACTURAS!!

            string dateSupplierCell = "";
            string supplierBillNumberCell = "";
            string idSupplierCell = "";
            string totalSupplierCell = "";

            if (isClient == true)
            {
                clientBillNumberCell = table.Rows[0][1].ToString();
                idClientCell = table.Rows[0][8].ToString();
                conditionClientCell = table.Rows[0][11].ToString();
                totalClientCell = table.Rows[0][24].ToString();
                dateClientCell = table.Rows[0][26].ToString();
            }
            else
            {
                dateSupplierCell = table.Rows[0][3].ToString();
                supplierBillNumberCell = table.Rows[0][4].ToString();
                idSupplierCell = table.Rows[0][9].ToString();
                totalSupplierCell = table.Rows[0][23].ToString();
            }

            if (clientBillNumberCell == customerTemplateId && idClientCell == customerId && conditionClientCell == customerTemplateIndicator
                && totalClientCell == customerTotal && dateClientCell == customerDate)
            {
                for (int row = 1; row < table.Rows.Count; row++)
                {
                    DateTime dateBill = DateTime.ParseExact(table.Rows[row][26].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dateCompare = new DateTime(2100, 12, 30);

                    int result = DateTime.Compare(dateBill, dateCompare);

                    if (result < 0 && idClientCell.Length <= 35)
                    {
                        //relationship = "is earlier than";
                        InvoiceReceivingClientManager invoiceReceivingClientM = new InvoiceReceivingClientManager();
                        invoiceReceivingClientM.InsertInvoiceReceivingClient(new InvoiceReceivingClient(idClientCell, table.Rows[row][9].ToString(), table.Rows[row][7].ToString()));
                        InvoiceClientManager invoiceClientManager = new InvoiceClientManager();
                        invoiceClientManager.InsertInvoiceClient(new DOM.InvoiceClient(int.Parse(clientBillNumberCell), idClientCell, 0, "", double.Parse(totalClientCell), 0, conditionClientCell, DateTime.ParseExact(dateClientCell, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                    }
                    else
                    {
                        //relationship = "is later than";
                        failDateBillClient++;
                    }

                }
                lblInformationInvoice.Text = "Se ingresaron todas las facturas de cliente, y no se ingresaron " + failDateBillClient + " facturas fallidas por formato erróneo";
                return;
            }
            else //VALIDAR LO MISMO EU ARRIBA PARA LAS DE PROVEEDOR
            {
                if (dateSupplierCell == supplierDate && supplierBillNumberCell == supplierTemplateId && idSupplierCell == supplierId &&
                    totalSupplierCell == supplierTotal)
                {
                    for (int row1 = 1; row1 < table.Rows.Count; row1++)
                    {
                        DateTime dateBill = DateTime.ParseExact(table.Rows[row1][3].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime dateCompare = new DateTime(2100, 12, 30);

                        int result = DateTime.Compare(dateBill, dateCompare);

                        if (result < 0 && supplierBillNumberCell.Length <= 50 && idSupplierCell.Length <= 35)
                        {

                            InvoiceReceivingSupplierManager invoiceReceivingSupplierM = new InvoiceReceivingSupplierManager();
                            invoiceReceivingSupplierM.InsertInvoiceReceivingSupplier(new InvoiceReceivingSupplier(table.Rows[row1][9].ToString(), table.Rows[row1][10].ToString()));
                            InvoiceSupplierManager invoiceSupplierManager = new InvoiceSupplierManager();
                            invoiceSupplierManager.InsertInvoiceSupplier(new DOM.InvoiceSupplier(supplierBillNumberCell, idSupplierCell, 0, "", double.Parse(totalSupplierCell), 0, DateTime.ParseExact(dateSupplierCell, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
                        }
                        else
                        {
                            //relationship = "is later than";
                            failDateBillSupplier++;
                        }
                    }
                    lblInformationInvoice.Text = "Se ingresaron todas las facturas de proveedor, y no se ingresaron " + failDateBillSupplier + " facturas fallidas por formato erróneo";
                    return;
                }
                else
                {
                    lblInformationInvoice.Text = noSupplierTemplateFile;
                    return;
                }
                lblInformationInvoice.Text = noClientTemplateFile;
            }
        }



        private Boolean validateInvoice() { 
        
        
             string clientBillNumberCell = "";
            string idClientCell = "";
            string conditionClientCell = "";
            string totalClientCell = "";
            string dateClientCell = ""; // PARA HACER LA VALIDACION DE SI ES UN ARCHIVO QUE POSEE FACTURAS!!

            string dateSupplierCell = "";
            string supplierBillNumberCell = "";
            string idSupplierCell = "";
            string totalSupplierCell = "";

            if (isClient == true)
            {
                clientBillNumberCell = table.Rows[0][1].ToString();
                idClientCell = table.Rows[0][8].ToString();
                conditionClientCell = table.Rows[0][11].ToString();
                totalClientCell = table.Rows[0][24].ToString();
                dateClientCell = table.Rows[0][26].ToString();
            }
            else
            {
                dateSupplierCell = table.Rows[0][3].ToString();
                supplierBillNumberCell = table.Rows[0][4].ToString();
                idSupplierCell = table.Rows[0][9].ToString();
                totalSupplierCell = table.Rows[0][23].ToString();
            }

            if (clientBillNumberCell == customerTemplateId && idClientCell == customerId && conditionClientCell == customerTemplateIndicator
                && totalClientCell == customerTotal && dateClientCell == customerDate)
            {
               
                return true;
            }
            else //VALIDAR LO MISMO EU ARRIBA PARA LAS DE PROVEEDOR
            {
                if (dateSupplierCell == supplierDate && supplierBillNumberCell == supplierTemplateId && idSupplierCell == supplierId &&
                    totalSupplierCell == supplierTotal)
                {
                    return true;
                }
                else
                {
                    lblInformationInvoice.Text = noSupplierTemplateFile;
                    return false;
                }
                lblInformationInvoice.Text = noClientTemplateFile;
                return false;
            }
        
        }

    }
}