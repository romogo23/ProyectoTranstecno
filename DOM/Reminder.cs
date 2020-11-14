using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class Reminder
    {
        public int idReminder { get; set; }
        public int invoiceNumberSupplier { get; set; }
        public int invoiceNumberClient { get; set; }
        public string description { get; set; }
        public string userName { get; set; }
        public DateTime dateReminder { get; set; }
        public string email { get; set; }

        public Reminder(int invoiceNumberSupplier, int invoiceNumberClient, string description, string userName,
                DateTime dateReminder, string email)
        {
            this.invoiceNumberSupplier = invoiceNumberSupplier;
            this.invoiceNumberClient = invoiceNumberClient;
            this.description = description;
            this.userName = userName;
            this.dateReminder = dateReminder;
            this.email = email;
        }

        public Reminder() { }
    }
}
