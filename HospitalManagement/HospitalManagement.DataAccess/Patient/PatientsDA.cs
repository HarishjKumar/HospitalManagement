using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagement.DataAccess.Patient
{
    public class PatientsDA
    {
        #region Get
        public static DataSet GetPatientsByCriteria(int patientId, string patientName, string department, string consultant,string searchText, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientId", DbType = DbType.Int32, Value = patientId });
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientName", DbType = DbType.String, Value = patientName });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Department", DbType = DbType.String, Value = department });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Consultant", DbType = DbType.String, Value = consultant });
            sqlParameters.Add(new SqlParameter { ParameterName = "@SearchText", DbType = DbType.String, Value = searchText });
            return DataBaseHelper.GetDataSetByStoredProcedure("Patient_Get_ByCriteria", connectionString, sqlParameters);
        }

        #endregion

        #region Insert
        public static void InsertPatient(string patientName, string Gender, DateTime dateOfBirth, long number, string email, string address,string department,string consultant,int age,string typeOfConsultation, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientName", DbType = DbType.String, Value = patientName });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Gender", DbType = DbType.String, Value = Gender });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Department", DbType = DbType.String, Value = department });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Consultant", DbType = DbType.String, Value = consultant });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Age", DbType = DbType.Int32, Value = age });
            sqlParameters.Add(new SqlParameter { ParameterName = "@TypeOfConsultation", DbType = DbType.String, Value = typeOfConsultation });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Patient_Insert", connectionString, sqlParameters);
        }

        #endregion

        #region Update
        public static void UpdatePatient(int patientId,string patientName, string Gender, DateTime dateOfBirth, long number, string email, string address, string department, string consultant, int age, string typeOfConsultation, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientId", DbType = DbType.Int32, Value = patientId });
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientName", DbType = DbType.String, Value = patientName });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Gender", DbType = DbType.String, Value = Gender });
            sqlParameters.Add(new SqlParameter { ParameterName = "@DateOfBirth", DbType = DbType.DateTime, Value = dateOfBirth });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Number", DbType = DbType.Int64, Value = number });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Email", DbType = DbType.String, Value = email });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Address", DbType = DbType.String, Value = address });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Department", DbType = DbType.String, Value = department });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Consultant", DbType = DbType.String, Value = consultant });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Age", DbType = DbType.Int32, Value = age });
            sqlParameters.Add(new SqlParameter { ParameterName = "@TypeOfConsultation", DbType = DbType.String, Value = typeOfConsultation });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Patient_Update", connectionString, sqlParameters);
        }

        #endregion

        #region Delete
        public static void DeletePatient(int patientId, string connectionString)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@PatientId", DbType = DbType.Int32, Value = patientId });
            DataBaseHelper.GetExecuteNonQueryByStoredProcedure("Patient_Delete_ById", connectionString, sqlParameters);
        }

        #endregion
    }
}
