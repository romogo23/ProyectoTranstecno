using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class AdministerBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            grdInvoices.DataSource = invCM.loadInvoicesClientT();
            //No sé si crear dos grid o qué
            grdInvoices.DataBind();
        }

        protected void grdInvoices_RowCreated(object sender, GridViewRowEventArgs e)
        {
            grdInvoices.Columns[0].HeaderText = "Codigo de factura";
            grdInvoices.Columns[1].HeaderText = "Nombre de acredor";
        }
    }
}