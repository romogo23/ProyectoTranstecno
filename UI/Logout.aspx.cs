using BL;
using DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifySession();
            this.cmdSignOut.ServerClick += new System.EventHandler(this.cmdSignOut_ServerClick);
            if (!Page.IsPostBack)
            {
                UserManager sm = new UserManager();
                User user = (User)(Session["userWithRol"]);
                userName.InnerText = "Hola " + user.username;
            }
        }

        private void VerifySession()
        {
            if (Session["userWithRol"] == null)
                Response.Redirect("~/Login.aspx");
        }

        private void cmdSignOut_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["userWithRol"] = null;
            Response.Redirect("~/Login.aspx", true);
        }
    }
}