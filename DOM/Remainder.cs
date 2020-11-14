using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Remainder
    {
        public int idRemainder { get; set; }
        public int invoiceNumberSupplier { get; set; }
        public int invoiceNumberClient { get; set; }
        public string description { get; set; }
        public string userName { get; set; }
        public DateTime dateRemainder { get; set; }
        public string email { get; set; }

        public Remainder(int invoiceNumberSupplier, int invoiceNumberClient, string description, string userName,
                DateTime dateRemainder, string email)
        {
            this.invoiceNumberSupplier = invoiceNumberSupplier;
            this.invoiceNumberClient = invoiceNumberClient;
            this.description = description;
            this.userName = userName;
            this.dateRemainder = dateRemainder;
            this.email = email;
        }
    }
}
