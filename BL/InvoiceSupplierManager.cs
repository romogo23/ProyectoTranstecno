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
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.InsertInvoiceSupplier(invS);
        }

        public Boolean ModifyInvoiceSupplier(InvoiceSupplier invS)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.ModifyInvoiceSupplier(invS);
        }

      


        public Boolean CloseInvoiceSupplier(InvoiceSupplier invS)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.CloseInvoiceSupplier(invS);

        }

        public List<InvoiceSupplier> LoadInvoiceSupplier(string idSupplier)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.LoadInvoiceSupplier(idSupplier);

        }


        public List<InvoiceSupplier> LoadInvoiceSupplierBydate(DateTime iniDate, DateTime endDate)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.LoadInvoiceSupplierBydate(iniDate, endDate);

        }
    }
}
