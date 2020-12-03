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
    public partial class CofirmDeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String userName = Request["userName"];
            lblmsg.Text = "¿Está seguro que desea eliminar al usuario: " + userName + "?";
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            UserManager uM = new UserManager();
            User u = new User();
            u.username = Request["userName"];
            bool vari = uM.deleteUser(u);
            if (vari)
            {
                Response.Write("<script> alert(" + "'Usuario eliminado con exito'" + ") </script>");
                Response.Redirect("~/AdministerUsers.aspx");
            }
            else
            {
                Response.Write("<script> alert(" + "'Usuario no eliminado'" + ") </script>");
            }
            //if um.deleteUser = true redirect a una página, else a la de error
            //Response.Redirect("~/CategoryManagement.aspx");
        }

        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            Response.Write("<script> alert(" + "'Usuario no eliminado'" + ") </script>");
            Response.Redirect("~/AdministerUsers.aspx");
        }
    }
}