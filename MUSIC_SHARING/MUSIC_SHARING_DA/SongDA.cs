using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MUSIC_SHARING.MUSIC_SHARING.DA
{
    public class SongDA
    {
        SqlConnection conn = null;
        SqlCommand cm = null;
        SqlDataReader reader = null;

        // Define connection
        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            this.conn = new SqlConnection(connectionString);
            return conn;
        }

        // Close connection
        public void Close()
        {
            this.conn.Close();
            this.cm.Dispose();
            if (reader != null)
            {
                this.reader.Dispose();
            }
        }


        public DataTable GetData(string procedureName)
        {
            DataTable table = new DataTable();
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cm = new SqlCommand(procedureName, conn);
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cm.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex);
            }
            finally
            {
                conn.Close();
            }
            return table;
        }


        public DataTable GetData(string procedureName, List<SqlParameter> listParam)
        {
            DataTable table = new DataTable();
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();

                SqlCommand cm = new SqlCommand(procedureName, conn);
                if (listParam != null)
                {
                    foreach (SqlParameter p in listParam)
                    {
                        cm.Parameters.Add(p);
                    }
                }
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cm.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception Ex)
            {
                Console.Write(Ex);
            }
            finally
            {
                conn.Close();
            }
            return table;
        }


        public bool UpdateData(string procedureName, List<SqlParameter> listParam)
        {
            bool status = false;
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand cm = new SqlCommand(procedureName, conn);
                if (listParam != null)
                {
                    foreach (SqlParameter p in listParam)
                    {
                        cm.Parameters.Add(p);
                    }
                }
                cm.CommandType = CommandType.StoredProcedure;
                cm.ExecuteNonQuery();
                status = true;
            }
            catch (Exception Ex)
            {
                System.Diagnostics.Debug.WriteLine(Ex);
            }
            finally
            {
                conn.Close();
            }
            return status;
        }






    }
}