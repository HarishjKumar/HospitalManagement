using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagement.DataAccess.User
{
    public class UsersDA
    {
        #region Get
        public static DataSet GetUsersByCriteria(int id, string name, string role, string searchText, string password, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Role", DbType = DbType.String, Value = role });
            sqlParameters.Add(new SqlParameter { ParameterName = "@SearchText", DbType = DbType.String, Value = searchText });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            return DataBaseHelper.GetDataSetByStoredProcedure("User_Get_ByCriteria", connectionString, sqlParameters);
        }
        //public static DataSet GetDepartmentsByCriteria(int id, string name, string connectionString)
        //{
        //    List<SqlParameter> sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
        //    sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
        //    return DataBaseHelper.GetDataSetByStoredProcedure("Department_Get_ByCriteria", connectionString, sqlParameters);
        //}

        #endregion

        #region Insert
        public static void InsertUser(string name, string password, string role, DateTime dateOfBirth, long number, string email, int experience, string address, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Role", DbType = DbType.String, Value = role });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Experience", DbType = DbType.Int32, Value = experience });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("User_Insert", connectionString, sqlParameters);
        }
        public static void InsertDepartment(string name, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Department_Insert", connectionString, sqlParameters);
        }
        #endregion

        #region Update
        public static void UpdateUser(int id,string name, string password, string role, DateTime dateOfBirth, long number, string email, int experience, string address, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Password", DbType = DbType.String, Value = password });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Role", DbType = DbType.String, Value = role });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Experience", DbType = DbType.Int32, Value = experience });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("User_Update", connectionString, sqlParameters);
        }
        public static void UpdateDepartment(int id,string name, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Name", DbType = DbType.String, Value = name });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Department_Update", connectionString, sqlParameters);
        }
        #endregion

        #region Delete
        public static void DeleteUser(int id, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("User_Delete_ById", connectionString, sqlParameters);
        }
        public static void DeleteDepartment(int id, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@Id", DbType = DbType.Int32, Value = id });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Department_Delete_ById", connectionString, sqlParameters);
        }

        #endregion
    }
}
