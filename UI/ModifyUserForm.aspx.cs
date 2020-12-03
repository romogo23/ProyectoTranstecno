﻿using BL;
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
            //email.Value = user.email;
            //password.Value = user.password;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            String passwordR = password.Value.Trim();
            String emailR = email.Value.Trim();
            UserManager uM = new UserManager();
            User u;
            String userName = Request["userName"];

            if (emailR != "" && passwordR != "")
            {
                if (emailR.Length <= 320)
                {
                    if (passwordR.Length <= 20)
                    {
                        u = new User(userName, emailR, passwordR, int.Parse(rols.SelectedValue));
                        uM.updateUser(u);
                        Response.Redirect("~/ModifySuccess.aspx");
                    }
                    else
                    {
                        Response.Write("<script> alert(" + "'Contraseña demasiado larga'" + ") </script>");
                    }
                }
                else
                {
                    Response.Write("<script> alert(" + "'Correo demasiado largo'" + ") </script>");
                }

            }
            else
            {

                Response.Write("<script> alert(" + "'Datos Vacíos'" + ") </script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Write("<script> alert(" + "'Usuario no modificado'" + ") </script>");
            Response.Redirect("~/AdministerUsers.aspx");
        }

        protected void newEvent(object sender, EventArgs e)
        {
            email.Value = "";
        }
    }
}