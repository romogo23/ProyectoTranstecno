using DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DAOInvoiceReceivingClient
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString); 
        public Boolean InsertInvoiceReceivingClient(InvoiceReceivingClient invC)
        {
            if (VerifyInvoiceReceivingClient(invC.idClient) == 0)
            {
                String query = "INSERT INTO DESTINATARIO_FACTURA_CLIENTE(ID_CLIENTE, CORREO, NOMBRE) " +
                    "VALUES(@idClient,@email,@nameClient)";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idClient", invC.idClient);
                comm.Parameters.AddWithValue("@email", invC.email);
                comm.Parameters.AddWithValue("@nameClient", invC.nameClient);
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
            else {
                return false;
            }
        }

        private int VerifyInvoiceReceivingClient(string id)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_CLIENTE where ID_CLIENTE = @idClient ";
            int verify;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idClient", id);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            verify = comm.ExecuteNonQuery();
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return verify; 
        }



        public List<InvoiceReceivingClient> LoadClients(int name)
        {
            String query = "Select * from DESTINATARIO_FACTURA_CLIENTE where NOMBRE like '%' + @name + '%'";
            List<InvoiceReceivingClient> listClientsName = new List<InvoiceReceivingClient>();
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@name", name);
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
                    listClientsName.Add(new InvoiceReceivingClient((string)reader["ID_CLIENTE"], (string)reader["CORREO"], (string)reader["NOMBRE"]));
                }
            }


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }


            return listClientsName;
        }



    }
}
