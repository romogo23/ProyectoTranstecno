using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;

namespace BL
{
    class InvoiceSupplierManager
    {
        public Boolean InsertInvoiceSupplier(InvoiceSupplier invS)
        {

            return true;
        }

        public Boolean ModifyInvoiceSupplier(InvoiceSupplier invS)
        {
            return true;
        }

      


        public Boolean CloseInvoiceSupplier(InvoiceSupplier invS)
        {
            return true;
        }

        public List<InvoiceSupplier> LoadInvoiceSupplier(string idSupplier)
        {
            return null;
        }


        public List<InvoiceSupplier> LoadInvoiceSupplierBydate(DateTime iniDate, DateTime endDate)
        {
            return null;
        }
    }
}
