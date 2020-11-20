using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceSupplier
    {
        public string numberInvoice { get; set; }
        public string idSupplier { get; set; }
        public DateTime paymentDate { get; set; }
        public int idPayMethod { get; set; }
        public string payMethod { get; set; }
        public double money { get; set; }
        public Byte condition { get; set; }
        public DateTime reminderDate { get; set; }

        public InvoiceSupplier(string numberInvoice, string idSupplier, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Byte condition, DateTime reminderDate)
        {
            this.numberInvoice = numberInvoice;
            this.idSupplier = idSupplier;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
            this.reminderDate = reminderDate;
        }

        //public InvoiceSupplier(string numberInvoice, DateTime paymentDate, int idPayMethod, string payMethod )
        //{
        //    this.numberInvoice = numberInvoice;
        //    this.paymentDate = paymentDate;
        //    this.idPayMethod = idPayMethod;
        //    this.payMethod = payMethod;
        //}
    }
}
