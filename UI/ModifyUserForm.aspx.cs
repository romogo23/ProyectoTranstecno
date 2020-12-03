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
    public partial class ModifyUserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String userName = Request["userName"];
            UserManager userMan = new UserManager();
            User user = userMan.loadUserByUserName(userName);
            email.Value = user.email;
            password.Value = user.password;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script> alert(" + "'Usuario no modificado'" + ") </script>");
            Response.Redirect("~/AdministerUsers.aspx");
        }
    }
}