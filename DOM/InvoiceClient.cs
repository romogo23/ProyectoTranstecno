using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public class InvoiceClient
    {
        public int numberInvoice { get; set; }
        public string idClient { get; set; }
        public DateTime paymentDate { get; set; }
        public int idPayMethod { get; set; }
        public string payMethod { get; set; }
        public double money { get; set; }
        public Byte condition { get; set; }
        public string paymentCondition { get; set; }

        public InvoiceClient(int numberInvoice, string idClient, DateTime paymentDate, int idPayMethod, string payMethod,
            double money, Byte condition, string paymentCondition)
        {
            this.numberInvoice = numberInvoice;
            this.idClient = idClient;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
            this.money = money;
            this.condition = condition;
            this.paymentCondition = paymentCondition;
        }

        public InvoiceClient(int numberInvoice, DateTime paymentDate, int idPayMethod, string payMethod)
        {
            this.numberInvoice = numberInvoice;
            this.paymentDate = paymentDate;
            this.idPayMethod = idPayMethod;
            this.payMethod = payMethod;
        }


        
    }
}
