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
        public string nameSupplier { get; set; }

        public InvoiceReceivingSupplier(string idSupplier, string nameSupplier)
        {
            this.idSupplier = idSupplier;
            this.nameSupplier = nameSupplier;
        }

        public InvoiceReceivingSupplier()
        {
        }

    }
}
