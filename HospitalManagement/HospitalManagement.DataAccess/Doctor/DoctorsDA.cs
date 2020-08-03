using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagement.DataAccess.Doctor
{
    public class DoctorsDA
    {
        #region Get
        public static DataSet GetDoctorsByCriteria(int id,string name,string designation,string searchText,string password,string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Designation", DbType = DbType.String, Value = designation });
            sqlParameters.Add(new SqlParameter { ParameterName = "@SearchText", DbType = DbType.String, Value = searchText });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            return DataBaseHelper.GetDataSetByStoredProcedure("Doctor_Get_ByCriteria",connectionString,sqlParameters);
        }
        #endregion

        #region Insert
        public static void InsertDoctor(string name, string password, string designation, DateTime dateOfBirth,long number,string email,int experience,string address, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Designation", DbType = DbType.String, Value = designation });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Experience", DbType = DbType.Int32, Value = experience });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Doctor_Insert", connectionString, sqlParameters);
        }

        #endregion

        #region Update
        public static void UpdateDoctor(int id,string name, string password, string designation, DateTime dateOfBirth, long number, string email, int experience, string address, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Designation", DbType = DbType.String, Value = designation });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Experience", DbType = DbType.Int32, Value = experience });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Doctor_Update", connectionString, sqlParameters);
        }

        #endregion

        #region Delete
        public static void DeleteDoctor(int id, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Doctor_Delete_ById", connectionString, sqlParameters);
        }

        #endregion
    }
}
