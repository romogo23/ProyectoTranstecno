using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOM;


namespace DAO
{
    public class DAOUser
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);

        public Boolean insertUser(User u)
        {
            
            String query = "INSERT INTO [dbo].USUARIO (NOMBRE_USUARIO,CORREO,CONTRASENNA,PERMISO) VALUES (@username,@email,@password,@rol)";
            if (verifyUser(u.username) == 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@username", u.username);
                comm.Parameters.AddWithValue("@email", u.email);
                comm.Parameters.AddWithValue("@password", u.password);
                comm.Parameters.AddWithValue("@rol", u.rol);

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

        public Boolean ValidateUser(string userName, string password)
        {
            SqlCommand cmd;
            string lookupPassword = null;

            //if ((null == userName) || (0 == userName.Length) || (userName.Length > 50))
            //{
            //    return false;
            //}

            //if ((null == password) || (6 == password.Length) || (password.Length > 20))
            //{
            //    return false;
            //}

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new SqlCommand("Select CONTRASENNA from USUARIO WHERE NOMBRE_USUARIO = @userName", conn);
                cmd.Parameters.AddWithValue("@userName", userName);

                lookupPassword = (string)cmd.ExecuteScalar();

                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            if (lookupPassword == null)
            {
                return false;
            }
            return (0 == string.Compare(lookupPassword, password, false));
        }

        public Boolean updateUser(User u)
        {
            
            String query = "UPDATE[dbo].[USUARIO] SET CORREO = @email, CONTRASENNA = @password, PERMISO = @rol WHERE NOMBRE_USUARIO = @username";
            if (verifyUser(u.username) != 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@username", u.username);
                comm.Parameters.AddWithValue("@email", u.email);
                comm.Parameters.AddWithValue("@password", u.password);
                comm.Parameters.AddWithValue("@rol", u.rol);

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


        public Boolean deleteUser(User u)
        {

            String query = "DELETE FROM [dbo].[USUARIO] WHERE NOMBRE_USUARIO = @username";
            if (verifyUser(u.username) != 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@username", u.username);
               

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



        public User loadUserByUserName(String username)
        {
            String query = "SELECT * FROM USUARIO WHERE NOMBRE_USUARIO = @username";
            User temp = new User();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@username", username);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    temp = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3));
                }
            }
            else {
                temp = null;
            }
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }

            return temp;

        }


        public DataTable loadUsersName() {
            DataTable tbl = new DataTable();
            SqlDataReader reader;
            String query = "SELECT NOMBRE_USUARIO FROM USUARIO";
            SqlCommand comm = new SqlCommand(query, conn);

         
            tbl.Columns.Add("UserName");
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    tbl.Rows.Add(Convert.ToString(reader.GetString(0)));
                }
            }
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return tbl;
        }

        public List<User> loadUsers()
        {
            String query = "SELECT * FROM USUARIO";
            User u;
            

            List<User> users = new List<User>();

            SqlCommand comm = new SqlCommand(query, conn);
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



                   
                    u = new User(reader["NOMBRE_USUARIO"].ToString(), reader["CORREO"].ToString(), reader["CONTRASENNA"].ToString(), int.Parse(reader["PERMISO"].ToString()));
              
                    users.Add(u);
                }
            }
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }



            return users;
        }




        public int verifyUser(string userName)
        {
            int existsU;
            string query = "SELECT COUNT(NOMBRE_USUARIO) FROM USUARIO WHERE NOMBRE_USUARIO = @username";
            SqlCommand comm2 = new SqlCommand(query, conn);
            comm2.Parameters.AddWithValue("@username", userName);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            existsU = (int)comm2.ExecuteScalar();


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return existsU;

        }

        private int verifyUserModifyInvoiceClient(string userName, Int64 invoiceNumber)
        {
            int existsU;
            string query = "Select count(*) from USUARIO_MODIFICA_FACTURA_CLIENTE where NUMERO_FACTURA = @NUMERO_FACTURA AND NOMBRE_USUARIO = @username";
            SqlCommand comm2 = new SqlCommand(query, conn);
            comm2.Parameters.AddWithValue("@username", userName);
            comm2.Parameters.AddWithValue("@NUMERO_FACTURA", invoiceNumber);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            existsU = (int)comm2.ExecuteScalar();


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return existsU;

        }




        public void UserModifyInvoiceClient(string userName, Int64 invoiceNumber)
        {
            if(verifyUserModifyInvoiceClient(userName, invoiceNumber) == 0) {
                string query = "INSERT INTO USUARIO_MODIFICA_FACTURA_CLIENTE  ([NUMERO_FACTURA] ,[NOMBRE_USUARIO]) VALUES (@InvoiceNumber, @User)";
                SqlCommand comm2 = new SqlCommand(query, conn);
                comm2.Parameters.AddWithValue("@User", userName);
                comm2.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                comm2.ExecuteNonQuery();


                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
            }


        }






        private int verifyUserModifyInvoiceSupplier(string userName, string invoiceNumber)
        {
            int existsU;
            string query = "Select count(*) from USUARIO_MODIFICA_FACTURA_PROVEEDOR where NUMERO_FACTURA = @NUMERO_FACTURA AND NOMBRE_USUARIO = @username";
            SqlCommand comm2 = new SqlCommand(query, conn);
            comm2.Parameters.AddWithValue("@username", userName);
            comm2.Parameters.AddWithValue("@NUMERO_FACTURA", invoiceNumber);
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            existsU = (int)comm2.ExecuteScalar();


            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();

            }
            return existsU;

        }




        public void UserModifyInvoiceSupplier(string userName, string invoiceNumber)
        {
            if (verifyUserModifyInvoiceSupplier(userName, invoiceNumber) == 0)
            {
                string query = "INSERT INTO USUARIO_MODIFICA_FACTURA_PROVEEDOR  ([NUMERO_FACTURA] ,[NOMBRE_USUARIO]) VALUES (@InvoiceNumber, @User)";
                SqlCommand comm2 = new SqlCommand(query, conn);
                comm2.Parameters.AddWithValue("@User", userName);
                comm2.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                comm2.ExecuteNonQuery();


                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();

                }
            }


        }




    }
}
