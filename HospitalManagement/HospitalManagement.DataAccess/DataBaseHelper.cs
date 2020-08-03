using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HospitalManagement.DataAccess
{
    public static class DataBaseHelper
    {
        static SqlConnection con;
        static SqlCommand com;
        static SqlDataReader reader;
        static DataSet ds;
        public static SqlConnection GetSqlConnectionByConnectionString(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        public static void GetExecuteNonQueryByStoredProcedure(string sStoredProcedure, string connectionString, List<SqlParameter> sqlParameters)
        {
            SqlCommand cmd = new SqlCommand();
            int result = 0;
            try
            {
                using (SqlConnection conn = GetSqlConnectionByConnectionString(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sStoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        cmd.Parameters.Add(sqlParameter);
                    }
                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            catch (Exception e)
            {
                Console.Write(e);
                result = 0;
            }
            // return result;
        }
        public static DataSet GetDataSetByStoredProcedure(string sStoredProcedure, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection conn = GetSqlConnectionByConnectionString(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sStoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return ds;
        }
        public static DataSet GetDataSetByStoredProcedure(string sStoredProcedure, string connectionString, List<SqlParameter> sqlParameters)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection conn = GetSqlConnectionByConnectionString(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sStoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        cmd.Parameters.Add(sqlParameter);
                    }
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return ds;
        }
        public static string GetExecuteNonQueryByStoredProcedureWithReturnValue(string sStoredProcedure, string connectionString, List<SqlParameter> sqlParameters)
        {
            SqlCommand cmd = new SqlCommand();
            string result = "";
            try
            {
                using (SqlConnection conn = GetSqlConnectionByConnectionString(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sStoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        cmd.Parameters.Add(sqlParameter);
                    }
                    cmd.Parameters.AddWithValue("@retvalue", "0");
                    cmd.Parameters["@retvalue"].Direction = ParameterDirection.Output;
                    cmd.Parameters["@retvalue"].Size = 1000;
                    cmd.Parameters["@retvalue"].SqlDbType = SqlDbType.VarChar;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    result = Convert.ToString(cmd.Parameters["@retvalue"].Value);

                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                result = "0";
            }
            return result;
        }

    }
}

