using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class BillName
    {
        public Int64 idInvoice { get; set; }
        public String idInvoiceSupplier { get; set; }
        public String clientName { get; set; }
        public double total { get; set; }
        public DateTime reminderDate { get; set; }
        public Byte state { get; set; }

        public BillName(Int64 idInvoice, String clientName, double total, DateTime reminderDate, Byte payMethod)
        {
            this.idInvoice = idInvoice;
            this.clientName = clientName;
            this.total = total;
            this.reminderDate = reminderDate;
            this.state = state;
        }

        public BillName(String idInvoiceSupplier, String clientName, double total, DateTime reminderDate, Byte payMethod)
        {
            this.idInvoiceSupplier = idInvoiceSupplier;
            this.clientName = clientName;
            this.total = total;
            this.reminderDate = reminderDate;
            this.state = state;
        }

        public BillName()
        {

        }
    }
}
