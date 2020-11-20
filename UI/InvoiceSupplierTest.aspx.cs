using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;
using BL;
using System.Data;

namespace UI
{
    public partial class InvoiceSupplierTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InvoiceReceivingSupplierManager invoiceReceivingSupplierManager = new InvoiceReceivingSupplierManager();
            invoiceReceivingSupplierManager.InsertInvoiceReceivingSupplier(new InvoiceReceivingSupplier("390159", "Soda Trompos"));

            //InvoiceSupplier inV = new InvoiceSupplier(0010900105781470, "390159", new DateTime(2019, 05, 11), 0, "", 3200, 0);
            //InvoiceSupplierManager inM = new InvoiceSupplierManager();
            //inM.InsertInvoiceSupplier(inV);


        }

        protected void Modify_Click(object sender, EventArgs e)
        {
            //InvoiceSupplier inV = new InvoiceSupplier(0010900105781470, new DateTime(2019, 12, 30), 0, "Cheque");
            //InvoiceSupplierManager inM = new InvoiceSupplierManager();
            //inM.ModifyInvoiceSupplier(inV);
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            //InvoiceSupplier inV = new InvoiceSupplier(0010900105781470, new DateTime(2019, 12, 30), 29, "Cheque");
            //InvoiceSupplierManager inM = new InvoiceSupplierManager();
            //inM.CloseInvoiceSupplier(inV);

        }

        protected void LoadSupplier_Click(object sender, EventArgs e)
        {
            InvoiceSupplierManager inM = new InvoiceSupplierManager();
            DataTable tbInvoice = new DataTable();
            DataTable tbInvoiceSupplier = new DataTable();
            InvoiceReceivingSupplierManager invRCM = new InvoiceReceivingSupplierManager();
            InvoiceReceivingSupplier supplier = invRCM.LoadSupplier("390159");

            tbInvoiceSupplier.Columns.Add("Nombre");
            tbInvoiceSupplier.Columns.Add("Identificacion");
            tbInvoiceSupplier.Columns.Add("correo");

            tbInvoiceSupplier.Rows.Add(supplier.nameSupplier, supplier.idSupplier);
            grdSupplier.DataSource = tbInvoiceSupplier;
            grdSupplier.DataBind();

            tbInvoice.Columns.Add("Número de Factura");
            tbInvoice.Columns.Add("Monto");
            tbInvoice.Columns.Add("Estado");
            tbInvoice.Columns.Add("Id Método de Pago");
            tbInvoice.Columns.Add("Método de Pago");
            tbInvoice.Columns.Add("Fecha de Pago");

            List<InvoiceSupplier> listInvoice = inM.LoadInvoiceSupplier("390159");
            foreach (InvoiceSupplier invS in listInvoice)
            {

                tbInvoice.Rows.Add(invS.numberInvoice, invS.money, invS.condition, invS.idPayMethod, invS.payMethod, invS.paymentDate);
            }

            grdInvoice.DataSource = tbInvoice;
            grdInvoice.DataBind();
        }

        protected void LoadByDate_Click(object sender, EventArgs e)
        {
            InvoiceSupplierManager inM = new InvoiceSupplierManager();
            DataTable tbInvoice = new DataTable();
            InvoiceReceivingSupplierManager invRCM = new InvoiceReceivingSupplierManager();
            grdSupplier.DataBind();

            tbInvoice.Columns.Add("Número de Factura");
            tbInvoice.Columns.Add("Monto");
            tbInvoice.Columns.Add("Estado");
            tbInvoice.Columns.Add("Id Método de Pago");
            tbInvoice.Columns.Add("Método de Pago");
            tbInvoice.Columns.Add("Fecha de Pago");

            List<InvoiceSupplier> listInvoice = inM.LoadInvoiceSupplierBydate(new DateTime(2019, 01, 01), new DateTime(2020, 12, 12));
            foreach (InvoiceSupplier invS in listInvoice)
            {

                tbInvoice.Rows.Add(invS.numberInvoice, invS.money, invS.condition, invS.idPayMethod, invS.payMethod, invS.paymentDate);
            }

            grdInvoice.DataSource = tbInvoice;
            grdInvoice.DataBind();
        }
    }
}