using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;


namespace UI
{
    public partial class ManageInvoices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceClientManager invCM = new InvoiceClientManager();
            InvoiceSupplierManager invSM = new InvoiceSupplierManager();
            grdInvoices.DataSource = invCM.loadInvoicesClientT();
            //No sé si crear dos grid o qué
            grdInvoices.DataBind();
        }
    }
}