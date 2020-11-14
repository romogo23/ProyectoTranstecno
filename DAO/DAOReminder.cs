using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOM;

namespace DAO
{
    public class DAOReminder
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString);

        public Boolean insertReminder(Remainder r)
        {
            String query = "INSERT INTO [dbo].RECORDATORIO(NUMERO_FACTURA_PROVEEDOR, NUMERO_FACTURA_CLIENTE, DESCRIPCION, NOMBRE_USUARIO,FECHA,CORREO) VALUES (@invoiceNumberClient,@invoiceNumberSupplier,@description, @username, @date, @email)";

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@invoiceNumberClient", r.invoiceNumberClient);
            comm.Parameters.AddWithValue("@invoiceNumberSupplier", r.invoiceNumberSupplier);
            comm.Parameters.AddWithValue("@description", r.description);
            comm.Parameters.AddWithValue("@username", r.userName);
            comm.Parameters.AddWithValue("@date", r.dateRemainder);
            comm.Parameters.AddWithValue("@email", r.email);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            comm.ExecuteNonQuery();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            return true;


        }

        public Boolean updateReminder(Remainder r)
        {
            String query = "UPDATE[dbo].[RECORDATORIO] SET FECHA = @date WHERE ID_RECORDATORIO = @idRemainder";
            if (verifyReminder(r.idRemainder) != 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@date", r.dateRemainder);
                comm.Parameters.AddWithValue("@idRemainder", r.idRemainder);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                return true;
            }
            else { return false; }
        }

        public Boolean deleteReminder(Remainder r)
        {

            String query = "DELETE FROM [dbo].[RECORDATORIO] WHERE ID_RECORDATORIO = @idRemainder";
            if (verifyReminder(r.idRemainder) != 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idRemainder", r.idRemainder);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                comm.ExecuteNonQuery();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                return true;
            }
            else { return false; }

        }

        public Remainder loadReminderById(int idRemainder)
        {
            String query = "SELECT * FROM RECORDATORIO WHERE ID_RECORDATORIO = @idRemainder";
            Remainder temp = new Remainder();
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;
            comm.Parameters.AddWithValue("@idRemainder", idRemainder);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //temp = new Remainder();
                }
            }
            else
            {
                temp = null;
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            return temp;
        }

        public List<Remainder> loadReminders()
        {
            String query = "SELECT * FROM RECORDATORIO";
            Remainder r;

            List<Remainder> reminderList = new List<Remainder>();

            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataReader reader;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //r = new Remainder(); Prgeuntar por la creación de los recordatorios
                    //reminderList.Add(r);
                }
            }
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            return reminderList;
        }
        private int verifyReminder(int idRemainder)
        {
            int existsU;
            string query = "SELECT COUNT(ID_RECORDATORIO) FROM RECORDATORIO WHERE ID_RECORDATORIO = @idRemainder";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@idRemainder", idRemainder);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            existsU = (int)comm.ExecuteScalar();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            return existsU;
        }
    }
}
