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

        public Boolean insertReminder(Reminder r)
        {
            String query = "INSERT INTO [dbo].RECORDATORIO(NUMERO_FACTURA_PROVEEDOR, NUMERO_FACTURA_CLIENTE, DESCRIPCION, NOMBRE_USUARIO,FECHA) VALUES (@invoiceNumberClient,@invoiceNumberSupplier,@description, @username, @date)";

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Connection = conn;
            comm.Parameters.AddWithValue("@invoiceNumberClient", r.invoiceNumberClient);
            comm.Parameters.AddWithValue("@invoiceNumberSupplier", r.invoiceNumberSupplier);
            comm.Parameters.AddWithValue("@username", r.userName);

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

        // ESTO SE HACE EN FACTURAS
        //public Boolean updateReminder(Reminder r)
        //{
        //    String query = "UPDATE[dbo].[RECORDATORIO] SET FECHA = @date WHERE ID_RECORDATORIO = @idRemainder";
        //    if (verifyReminder(r.idReminder) != 0)
        //    {
        //        SqlCommand comm = new SqlCommand(query, conn);
        //        comm.Connection = conn;
        //        comm.Parameters.AddWithValue("@date", r.dateReminder);
        //        comm.Parameters.AddWithValue("@idRemainder", r.idReminder);

        //        if (conn.State != ConnectionState.Open)
        //        {
        //            conn.Open();
        //        }
        //        comm.ExecuteNonQuery();
        //        if (conn.State != ConnectionState.Closed)
        //        {
        //            conn.Close();
        //        }
        //        return true;
        //    }
        //    else { return false; }
        //}

        public Boolean deleteReminder(Reminder r)
        {

            String query = "DELETE FROM [dbo].[RECORDATORIO] WHERE ID_RECORDATORIO = @idRemainder";
            if (verifyReminder(r.idReminder) != 0)
            {
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@idRemainder", r.idReminder);

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

        public Reminder loadReminderById(int idRemainder)
        {
            String query = "SELECT * FROM RECORDATORIO WHERE ID_RECORDATORIO = @idRemainder";
            Reminder temp = new Reminder();
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
                    temp = new Reminder(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5));
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

        public List<Reminder> loadReminders()
        {
            String query = "SELECT * FROM RECORDATORIO";
            Reminder r;

            List<Reminder> reminderList = new List<Reminder>();

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
                    r = new Reminder(); //Preguntar por la creación de los recordatorios
                    reminderList.Add(r);
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
