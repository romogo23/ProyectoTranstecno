using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceSupplier
    {
        public Int64 numberInvoice { get; set; }
        public string idSupplier { get; set; }
        public DateTime paymentDate { get; set; }
        public int idPayMethod { get; set; }
        public string payMethod { get; set; }
        public double money { get; set; }
        public Byte condition { get; set; }

        public InvoiceSupplier(Int64 numberInvoice, string idSupplier, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Byte condition)
        {
            this.numberInvoice = numberInvoice;
            this.idSupplier = idSupplier;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
        }

        public InvoiceSupplier(Int64 numberInvoice, DateTime paymentDate, int idPayMethod, string payMethod )
        {
            this.numberInvoice = numberInvoice;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
        }
    }
}
