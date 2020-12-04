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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userWithRol"] != null)
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager um = new UserManager();
            String userNameIn = userName.Value.Trim();
            String passwordIn = pwd.Value.Trim();

            if (userNameIn != "" || passwordIn != "")
            {
                //if (userNameIn.Length <= 50)
                //{
                //    if (passwordIn.Length <= 20)
                //    {
                        bool user = um.ValidateUser(userNameIn, passwordIn);
                        if (user == false)
                        {
                            Response.Write("<script> alert(" + "'Datos Incorrectos'" + ") </script>");
                        }
                        else
                        {
                            User userSesssion = um.loadUserByUserName(userNameIn);
                            Session["userWithRol"] = userSesssion;
                            if (userSesssion.rol == 0)
                            {
                                Response.Redirect("~/LoadTemplate.aspx");
                            }
                            if (userSesssion.rol == 1)
                            {
                                Response.Redirect("~/AdministerUsers.aspx");
                            }
                            if (userSesssion.rol == 2)
                            {
                                Response.Redirect("~/LoadTemplate.aspx");
                            }

                }
                //    }
                //    else
                //    {
                //        Response.Write("<script> alert(" + "'Contraseña muy larga'" + ") </script>");
                //    }
                //}
                //else
                //{
                //    Response.Write("<script> alert(" + "'Nombre de usuario muy largo'" + ") </script>");
                //}
            }
            else
            {
                Response.Write("<script> alert(" + "'Datos Vacíos'" + ") </script>");
            }
        }
    }
}