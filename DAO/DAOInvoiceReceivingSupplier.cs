using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOM;

namespace DAO
{
    public class DAOInvoiceReceivingSupplier
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);
        public Boolean InsertInvoiceReceivingSupplier(InvoiceReceivingSupplier invR)
        {
            if (VerifyInvoiceReceivingSupplier(invR.idSupplier) == 0)
            {
                String query = "INSERT INTO DESTINATARIO_FACTURA_PROVEEDOR(ID_PROVEEDOR, CORREO, NOMBRE) " +
                    "VALUES(@idProveedor,@email,@name)";

                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idProveedor", invR.idSupplier);
                comm.Parameters.AddWithValue("@email", invR.email);
                comm.Parameters.AddWithValue("@name", invR.nameSupplier);
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

        private int VerifyInvoiceReceivingSupplier(string id)
        {
            String query = "Select count(0) from DESTINATARIO_FACTURA_PROVEEDOR where ID_PROVEEDOR = @idProveedor";
            int verify;
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@idProveedor", id);
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

        public List<InvoiceReceivingSupplier> LoadSuppliers(int name)
        {
            String query = "Select * from DESTINATARIO_FACTURA_PROVEEDOR where NOMBRE like '%' + @name + '%'";
            List<InvoiceReceivingSupplier> listSuppliersName = new List<InvoiceReceivingSupplier>();
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
                    listSuppliersName.Add(new InvoiceReceivingSupplier((string)reader["ID_PROVEEDOR"], (string)reader["CORREO"], (string)reader["NOMBRE"]));
                }
            }


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }


            return listSuppliersName;
        }

    }
}
