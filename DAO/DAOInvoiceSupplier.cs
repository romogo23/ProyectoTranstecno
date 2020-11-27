﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOM;

namespace DAO
{
    public class DAOInvoiceSupplier
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);


        public Boolean InsertInvoiceSupplier(InvoiceSupplier invS)
        {
            
            if (verifyInvoiceSupplier(invS.numberInvoice) == 0)
            {

                String query = "INSERT INTO FACTURA_PROVEEDOR (NUMERO_FACTURA,ID_PROVEEDOR,FECHA_PAGO,ID_METODO_PAGO, METODO_PAGO," +
                 "MONTO, ESTADO, FECHA) VALUES(@numberInvoice, @idSupplier, @paymentDate, @idPayMethod, @payMethod, @money, @condition, @reminderDate)";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invS.numberInvoice);
                comm.Parameters.AddWithValue("@idSupplier", invS.idSupplier);
                comm.Parameters.AddWithValue("@paymentDate", invS.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invS.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invS.payMethod);
                comm.Parameters.AddWithValue("@money", invS.money);
                comm.Parameters.AddWithValue("@condition", invS.condition);
                comm.Parameters.AddWithValue("@reminderDate", invS.reminderDate);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Reminder> LoadMonthSupplierReminder()
        {
            List<Reminder> reminderSupplierList = new List<Reminder>();
            String query = "Select T1.FECHA_PAGO, T2.NOMBRE FROM FACTURA_PROVEEDOR T1 JOIN DESTINATARIO_FACTURA_PROVEEDOR T2 ON T1.ID_PROVEEDOR = T2.ID_PROVEEDOR;";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            SqlDataReader reader;
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reminderSupplierList.Add(new Reminder((DateTime)reader["FECHA_PAGO"], (String)reader["NOMBRE"]));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
            return reminderSupplierList;
        }

        public Boolean ModifyInvoiceSupplier(InvoiceSupplier invS)
        {
            if (verifyInvoiceSupplier(invS.numberInvoice) == 1)
            {

                String query = "Update FACTURA_PROVEEDOR set METODO_PAGO = @payMethod, ID_METODO_PAGO = @idPayMethod, FECHA_PAGO = @paymentDate where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invS.numberInvoice);
                comm.Parameters.AddWithValue("@paymentDate", invS.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invS.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invS.payMethod);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public int verifyInvoiceSupplier(string numberInvoice)
        {
            String query = " select count(*) from FACTURA_PROVEEDOR where NUMERO_FACTURA = @numberInvoice";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@numberInvoice", numberInvoice);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            int verify = (int)comm.ExecuteScalar();
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return verify;
        }


        public Boolean CloseInvoiceSupplier(InvoiceSupplier invS)
        {
            if (verifyInvoiceSupplier(invS.numberInvoice) == 1)
            {

                String query = "Update FACTURA_PROVEEDOR set METODO_PAGO = @payMethod, ID_METODO_PAGO = @idPayMethod, FECHA_PAGO = @paymentDate where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invS.numberInvoice);
                comm.Parameters.AddWithValue("@paymentDate", invS.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invS.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invS.payMethod);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<InvoiceSupplier> LoadInvoiceSupplier(string idSupplier)
        {
            String query = "Select * from FACTURA_PROVEEDOR where ID_PROVEEDOR = @ID_PROVEEDOR";
            List<InvoiceSupplier> listInvoiceSupplier = new List<InvoiceSupplier>();
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@ID_PROVEEDOR", idSupplier);
            SqlDataReader reader;

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listInvoiceSupplier.Add(new InvoiceSupplier((string)reader["NUMERO_FACTURA"], (string)reader["ID_PROVEEDOR"], (DateTime)reader["FECHA_PAGO"], (int)reader["ID_METODO_PAGO"], (string)reader["METODO_PAGO"], double.Parse(reader["MONTO"].ToString()), (Byte)reader["ESTADO"], (DateTime)reader["FECHA"]));
                }
            }


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }


            return listInvoiceSupplier;
        }


        public List<InvoiceSupplier> LoadInvoiceSupplierBydate(DateTime iniDate, DateTime endDate)
        {
            String query = "Select * from FACTURA_PROVEEDOR where FECHA_PAGO between @iniDate and @endDate";
            List<InvoiceSupplier> listInvoiceSupplier = new List<InvoiceSupplier>();
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@iniDate", iniDate);
            comm.Parameters.AddWithValue("@endDate", endDate);
            SqlDataReader reader;

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listInvoiceSupplier.Add(new InvoiceSupplier((string)reader["NUMERO_FACTURA"], (string)reader["ID_PROVEEDOR"], (DateTime)reader["FECHA_PAGO"], (int)reader["ID_METODO_PAGO"], (string)reader["METODO_PAGO"], double.Parse(reader["MONTO"].ToString()), (Byte)reader["ESTADO"], (DateTime)reader["FECHA"]));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return listInvoiceSupplier;
        }
    }
}
