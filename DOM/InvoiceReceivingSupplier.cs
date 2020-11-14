using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceReceivingSupplier
    {
        public string idSupplier { get; set; }
        public string email { get; set; }
        public string nameSupplier { get; set; }

        public InvoiceReceivingSupplier(string idClient, string email, string nameClient)
        {
            this.idSupplier = idClient;
            this.email = email;
            this.nameSupplier = nameClient;
        }

    }
}
