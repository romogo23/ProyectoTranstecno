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
            VerifySession();
            String userName = Request["userName"];
            UserManager userMan = new UserManager();
            User user = userMan.loadUserByUserName(userName);
            if (!IsPostBack)
            {
                email.Value = user.email;
                password.Value = user.password;
                if (user.rol == 1)
                {
                    rols.SelectedIndex = 0;
                }
                else
                {
                    rols.SelectedIndex = 1;
                }
            }
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
                if (role.rol != 0 || role.rol != 1 || role.rol != 2)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
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

        //protected void newEvent()
        //{
        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
        //}

        //protected void email_TextChanged(object sender, EventArgs e)
        //{
        //    String vari = email.Text;
        //    password.Value = vari;
        //}
    }
}