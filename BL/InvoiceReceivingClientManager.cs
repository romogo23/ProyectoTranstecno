using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;

namespace BL
{
    public class InvoiceReceivingClientManager
    {
        public Boolean InsertInvoiceReceivingClient(InvoiceReceivingClient invC)
        {
            DAOInvoiceReceivingClient daoIRC = new DAOInvoiceReceivingClient();
            return daoIRC.InsertInvoiceReceivingClient(invC);
           
        }


        public List<InvoiceReceivingClient> LoadClients(string name)
        {
            DAOInvoiceReceivingClient daoIRC = new DAOInvoiceReceivingClient();
            return daoIRC.LoadClients(name);

        }

        public InvoiceReceivingClient LoadClient(string idClient) 
        {
            DAOInvoiceReceivingClient daoIRC = new DAOInvoiceReceivingClient();
            return daoIRC.LoadClient(idClient);
        }
    }
}
