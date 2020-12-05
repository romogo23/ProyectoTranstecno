using BL;
using DOM;
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
            //VerifySession();
            UserManager uM = new UserManager();
            grdUsers.DataSource = uM.loadUsersNames();
            grdUsers.DataBind();
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
                if (role.rol != 0 && role.rol != 1)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}