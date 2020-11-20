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
        public string userName { get; set; }

        public Reminder(int invoiceNumberSupplier, int invoiceNumberClient, string description, string userName,
                DateTime dateReminder)
        {
            this.invoiceNumberSupplier = invoiceNumberSupplier;
            this.invoiceNumberClient = invoiceNumberClient;
            this.userName = userName;
        }

        public Reminder(int idReminder,int invoiceNumberSupplier, int invoiceNumberClient, string description, string userName,
                DateTime dateReminder)
        {
            this.idReminder = idReminder;
            this.invoiceNumberSupplier = invoiceNumberSupplier;
            this.invoiceNumberClient = invoiceNumberClient;
            this.userName = userName;
        }

        public Reminder() { }
    }
}
