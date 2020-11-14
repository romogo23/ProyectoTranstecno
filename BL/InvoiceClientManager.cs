using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;

namespace BL
{
    class InvoiceClientManager
    {
        public Boolean InsertInvoiceClient(InvoiceClient invC)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.InsertInvoiceClient(invC);

        }

        public Boolean ModifyInvoiceClient(InvoiceClient invC)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.ModifyInvoiceClient(invC);

        }


        public Boolean CloseInvoiceClient(InvoiceClient invC)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.CloseInvoiceClient(invC);

        }

        public List<InvoiceClient> LoadInvoiceClient(string idClient)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.LoadInvoiceClient(idClient);
        }


        public List<InvoiceClient> LoadInvoiceClientsBydate(DateTime iniDate, DateTime endDate)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.LoadInvoiceClientsBydate(iniDate, endDate);
        }
    }
}
