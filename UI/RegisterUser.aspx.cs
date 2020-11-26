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
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String userNameR = userNameRegister.Value.Trim();
            String passwordR = password.Value.Trim();
            String emailR = email.Value.Trim();
            UserManager uM = new UserManager();
            User u;

            if (userNameR != "" && emailR !="" && passwordR != "")
            {
                int i = uM.verifyUser(userNameR);
                if (i>0)
                {
                    Response.Write("<script> alert(" + "'El usuario ha sido registrado anteriormente'" + ") </script>");
                }
                else
                {
                    //if uM.insertUser = true, enviarlo a la pagina de exito
                    u = new User(userNameR, emailR, passwordR,int.Parse(rols.SelectedValue));
                    uM.insertUser(u);
                }
                }
            else {
                Response.Write("<script> alert(" + "'Datos Vacíos'" + ") </script>");
            }


            }
    }
}