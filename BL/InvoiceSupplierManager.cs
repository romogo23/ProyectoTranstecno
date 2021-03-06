﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;
using DAO;
using System.Data;

namespace BL
{
    public class InvoiceSupplierManager
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

        public List<Reminder> LoadSupplierMonthReminder()
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.LoadMonthSupplierReminder();
        }

        public int verifyInvoiceSupplier(string numberInvoice)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.verifyInvoiceSupplier(numberInvoice);
        }

        public bool ModifyInvoiceSupplierPostpone(InvoiceSupplier invoice)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.ModifyInvoiceSupplierPostpone(invoice);
        }

        public InvoiceSupplier loadSupplierById(String idInvoice)
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.LoadInvoiceSupplierById(idInvoice);
        }
        public List<BillName> loadInvoicesSupplierT()
        {
            DAOInvoiceSupplier daoIS = new DAOInvoiceSupplier();
            return daoIS.loadInvoicesSupplierT();
        }
    }
}
