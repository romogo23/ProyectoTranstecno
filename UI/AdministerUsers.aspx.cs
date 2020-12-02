using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class AdministerUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserManager uM = new UserManager();
            grdUsers.DataSource = uM.loadUsersNames();
            grdUsers.DataBind();
        }
    }
}