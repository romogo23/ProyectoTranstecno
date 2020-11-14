using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;

namespace BL
{
    class InvoiceReceivingClientManager
    {
        public Boolean InsertInvoiceReceivingClient(InvoiceReceivingClient invC)
        {
            DAOInvoiceReceivingClient n = new DAOInvoiceReceivingClient();
            return n.InsertInvoiceReceivingClient(invC);
           
        }




        public List<InvoiceReceivingClient> LoadClients(string name)
        {
            DAOInvoiceReceivingClient n = new DAOInvoiceReceivingClient();
            return n.LoadClients(name);

        }
    }
}
