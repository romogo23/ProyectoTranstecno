using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;
using System.Data;

namespace BL
{
    public class InvoiceClientManager
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

        public List<Reminder> LoadClientMonthReminder()
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.LoadMonthClientReminder();
        }

        public int verifyInvoiceClient(int numberInvoice)
        {
            DAOInvoiceClient iC = new DAOInvoiceClient();
            return iC.verifyInvoiceClient(numberInvoice);
        }
        public InvoiceClient loadInvoiceClientById(String idInvoice)
        {
            DAOInvoiceClient daoIC = new DAOInvoiceClient();
            return daoIC.LoadInvoiceClientById(int.Parse(idInvoice));
        }

        public List<BillName> loadInvoicesClientT()
        {
            DAOInvoiceClient daoIC = new DAOInvoiceClient();
            return daoIC.loadInvoicesClientT();
        }
    }
}
