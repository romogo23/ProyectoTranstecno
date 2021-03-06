﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOM;
using System.Data;

namespace DAO
{
    public class DAOInvoiceClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);


        public Boolean InsertInvoiceClient(InvoiceClient invC)
        {
            if (verifyInvoiceClient((int)invC.numberInvoice) == 0)
            {
                

                String query = "INSERT INTO FACTURA_CLIENTE(NUMERO_FACTURA,ID_CLIENTE,FECHA_PAGO,ID_METODO_PAGO, METODO_PAGO," +
                 "MONTO,ESTADO, CONDICION_PAGO, FECHA) VALUES(@numberInvoice, @idClient, @paymentDate, @idPayMethod, @payMethod, @money, @condition, @paymentCondition, @reminderDate)";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invC.numberInvoice);
                comm.Parameters.AddWithValue("@idClient", invC.idClient);
                comm.Parameters.AddWithValue("@paymentDate", new DateTime(1900,01,01));
                comm.Parameters.AddWithValue("@idPayMethod", invC.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invC.payMethod);
                comm.Parameters.AddWithValue("@money", invC.money);
                comm.Parameters.AddWithValue("@condition", invC.condition);
                comm.Parameters.AddWithValue("@paymentCondition", invC.paymentCondition);
                comm.Parameters.AddWithValue("@reminderDate", invC.reminderDate);
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

        public bool ModifyInvoiceClientPostpone(InvoiceClient invoice)
        {
            if (verifyInvoiceClient((int)invoice.numberInvoice) == 1)
            {

                String query = "Update FACTURA_CLIENTE set FECHA = @reminderDate where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invoice.numberInvoice);
                comm.Parameters.AddWithValue("@reminderDate", invoice.paymentDate);
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

        public List<Reminder> LoadMonthClientReminder()
        {
            List<Reminder> reminderClientList = new List<Reminder>();
            String query = "Select T1.FECHA, T2.NOMBRE FROM FACTURA_CLIENTE T1 JOIN DESTINATARIO_FACTURA_CLIENTE T2 ON T1.ID_CLIENTE = T2.ID_CLIENTE;";
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
                    reminderClientList.Add(new Reminder((DateTime)reader["FECHA"], (String)reader["NOMBRE"]));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
            return reminderClientList;
        }

        public Boolean ModifyInvoiceClient(InvoiceClient invC)
        {
            if (verifyInvoiceClient((int)invC.numberInvoice) == 1)
            {

                String query = "Update FACTURA_CLIENTE set METODO_PAGO = @payMethod, ID_METODO_PAGO = @idPayMethod, FECHA_PAGO = @paymentDate, ESTADO = @condition where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invC.numberInvoice);
                comm.Parameters.AddWithValue("@paymentDate", invC.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invC.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invC.payMethod);
                comm.Parameters.AddWithValue("@condition", invC.condition);
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

        public int verifyInvoiceClient(int numberInvoice)
        {
                String query = "Select count(*) from FACTURA_CLIENTE where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice",numberInvoice);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                int verify = (int) comm.ExecuteScalar();
                 if (conn.State != System.Data.ConnectionState.Closed)
                 {
                    conn.Close();

                 }
            return verify;   
        }


        public Boolean CloseInvoiceClient(InvoiceClient invC)
        {
            if (verifyInvoiceClient((int)invC.numberInvoice) == 1)
            {

                String query = "Update FACTURA_CLIENTE set METODO_PAGO = @payMethod, ID_METODO_PAGO = @idPayMethod, FECHA_PAGO = @paymentDate where NUMERO_FACTURA = @numberInvoice";
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@numberInvoice", invC.numberInvoice);
                comm.Parameters.AddWithValue("@paymentDate", invC.paymentDate);
                comm.Parameters.AddWithValue("@idPayMethod", invC.idPayMethod);
                comm.Parameters.AddWithValue("@payMethod", invC.payMethod);
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

        public List<InvoiceClient> LoadInvoiceClient(string idClient)
        {
            String query = "Select * from FACTURA_CLIENTE where ID_CLIENTE = @ID_CLIENTE";
            List<InvoiceClient> listInvoiceClient = new List<InvoiceClient>();
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@ID_CLIENTE", idClient);
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
                    listInvoiceClient.Add(new InvoiceClient((Int64)reader["NUMERO_FACTURA"], (string)reader["ID_CLIENTE"], (DateTime)reader["FECHA_PAGO"], (int)reader["ID_METODO_PAGO"], (string)reader["METODO_PAGO"], double.Parse(reader["MONTO"].ToString()), (Byte) reader["ESTADO"], (string)reader["CONDICION_PAGO"], (DateTime)reader["FECHA"]));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return listInvoiceClient;
        }


        public List<InvoiceClient> LoadInvoiceClientsBydate(DateTime iniDate, DateTime endDate)
        {
            String query = "Select * from FACTURA_CLIENTE where FECHA between @iniDate and @endDate";
            List<InvoiceClient> listInvoiceClient = new List<InvoiceClient>();
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
                    listInvoiceClient.Add(new InvoiceClient((Int64)reader["NUMERO_FACTURA"], (string)reader["ID_CLIENTE"], (DateTime)reader["FECHA_PAGO"], (int)reader["ID_METODO_PAGO"], (string)reader["METODO_PAGO"], double.Parse(reader["MONTO"].ToString()), (Byte)reader["ESTADO"] , (string)reader["CONDICION_PAGO"], (DateTime)reader["FECHA"]));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return listInvoiceClient;
        }

        public InvoiceClient LoadInvoiceClientById(int idInvoice)
        {
            String query = "SELECT * FROM FACTURA_CLIENTE WHERE NUMERO_FACTURA = @idInvoice";
            InvoiceClient temp = new InvoiceClient();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@idInvoice", idInvoice);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    temp = new InvoiceClient((Int64)reader["NUMERO_FACTURA"], (string)reader["ID_CLIENTE"], (DateTime)reader["FECHA_PAGO"], (int)reader["ID_METODO_PAGO"], (string)reader["METODO_PAGO"], double.Parse(reader["MONTO"].ToString()), (Byte)reader["ESTADO"], (string)reader["CONDICION_PAGO"], (DateTime)reader["FECHA"]);

   //Int64 numberInvoice 0, string idClient  1,  DateTime paymentDate  2, int idPayMethod  3, string payMethod  4,double money  5, Byte condition  6, string paymentCondition 7, DateTime reminderDate 8
                    //new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3));
                }
            }
            else
            {
                temp = null;
            }
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return temp;
        }

        public List<BillName> loadInvoicesClientT()
        {
            List<BillName> tbl = new List<BillName>();
            SqlDataReader reader;
            String query = "SELECT dbo.FACTURA_CLIENTE.NUMERO_FACTURA, dbo.DESTINATARIO_FACTURA_CLIENTE.NOMBRE, dbo.FACTURA_CLIENTE.MONTO, dbo.FACTURA_CLIENTE.FECHA, dbo.FACTURA_CLIENTE.ESTADO FROM dbo.FACTURA_CLIENTE INNER JOIN dbo.DESTINATARIO_FACTURA_CLIENTE ON dbo.FACTURA_CLIENTE.ID_CLIENTE = dbo.DESTINATARIO_FACTURA_CLIENTE.ID_CLIENTE";
            SqlCommand comm = new SqlCommand(query, conn);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    tbl.Add(new BillName((Int64)reader["NUMERO_FACTURA"], (string) reader["NOMBRE"], double.Parse(reader["MONTO"].ToString()), (DateTime)reader["FECHA"], (Byte)reader["ESTADO"]));
                }
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();

            }
            return tbl;
        }
    }
}

