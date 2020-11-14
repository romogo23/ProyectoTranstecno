using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceSupplier
    {
        public int numberInvoice { get; set; }
        public string idSupplier { get; set; }
        public DateTime paymentDate { get; set; }
        public int idPayMethod { get; set; }
        public string payMethod { get; set; }
        public double money { get; set; }
        public Boolean condition { get; set; }

        public InvoiceSupplier(int numberInvoice, string idSupplier, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Boolean condition)
        {
            this.numberInvoice = numberInvoice;
            this.idSupplier = idSupplier;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
        }
    }
}
