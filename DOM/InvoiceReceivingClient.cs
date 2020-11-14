using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceReceivingClient
    {
        public string idClient { get; set; }
        public string email { get; set; }
        public string nameClient { get; set; }

        public InvoiceReceivingClient(string idClient, string email, string nameClient)
        {
            this.idClient = idClient;
            this.email = email;
            this.nameClient = nameClient;
        }
    }
}
