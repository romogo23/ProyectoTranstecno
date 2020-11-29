using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;

namespace BL
{
    public class InvoiceReceivingSupplierManager
    {

        public Boolean InsertInvoiceReceivingSupplier(InvoiceReceivingSupplier invR)
        {
            DAOInvoiceReceivingSupplier daoIRS = new DAOInvoiceReceivingSupplier();
            return daoIRS.InsertInvoiceReceivingSupplier(invR);
        }

 

        public List<InvoiceReceivingSupplier> LoadSuppliers(string name)
        {
            DAOInvoiceReceivingSupplier daoIRS = new DAOInvoiceReceivingSupplier();
            return daoIRS.LoadSuppliers(name);
        }

        public InvoiceReceivingSupplier LoadSupplier(string idSupplier) {
            DAOInvoiceReceivingSupplier daoIRS = new DAOInvoiceReceivingSupplier();
            return daoIRS.LoadSupplier(idSupplier);
        }

        public List<InvoiceReceivingSupplier> LoadAllSuppliers()
        {
            DAOInvoiceReceivingSupplier daoIRS = new DAOInvoiceReceivingSupplier();
            return daoIRS.LoadAllSuppliers();
        }

    }
}
