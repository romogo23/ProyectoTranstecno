using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int rol { get; set; }


        public User(string username, string email, string password, int rol) 
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.rol = rol;
        }

        public User()
        {
        
        }
    }
}
