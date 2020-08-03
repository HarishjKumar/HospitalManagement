using HospitalManagement.DataAccess.Patient;
using HospitalManagement.Main.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HospitalManagement.Provider.Patient
{
    public class PatientsProvider
    {
        #region Get
        public List<PatientModel> GetPatientsByCriteria(PatientModel patient, string connectionString)
        {
            List<PatientModel> patientList = new List<PatientModel>();
            DataSet ds = PatientsDA.GetPatientsByCriteria(patient.PatientId,patient.PatientName,patient.Department,patient.Consultant,patient.SearchText,connectionString);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return GetPatientFromDataTable(ds.Tables[0]);
            }
            return patientList;
        }
        public PatientModel GetPatientByCriteria(PatientModel patient, string connectionString)
        {
            PatientModel patientDetails = new PatientModel();
            DataSet ds = PatientsDA.GetPatientsByCriteria(patient.PatientId, patient.PatientName, patient.Department, patient.Consultant, patient.SearchText, connectionString);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return GetPatientFromDataRow(ds.Tables[0].Rows[0]);
            }
            return patientDetails;
        }
        #endregion

        #region Insert
        public void InsertPatient(PatientModel patient, string connectionString)
        {
            PatientsDA.InsertPatient(patient.PatientName,patient.Gender,patient.DateOfBirth,patient.Number,patient.Email,patient.Address,patient.Department,patient.Consultant,patient.Age,patient.TypeOfConsultation, connectionString);
        }
        #endregion

        #region Update
        public void UpdatePatient(PatientModel patient, string connectionString)
        {
            PatientsDA.UpdatePatient(patient.PatientId,patient.PatientName,patient.Gender,patient.DateOfBirth,patient.Number,patient.Email,patient.Address,patient.Department,patient.Consultant,patient.Age,patient.TypeOfConsultation, connectionString);
        }

        #endregion

        #region Delete
        public void DeletePatient(int patientId, string connectionString)
        {
            PatientsDA.DeletePatient(patientId, connectionString);
        }

        #endregion

        #region TranslateToObject

        private static List<PatientModel> GetPatientFromDataTable(DataTable dt)
        {
            List<PatientModel> patient = new List<PatientModel>();
            foreach (DataRow dr in dt.Rows)
            {
                patient.Add(GetPatientFromDataRow(dr));
            }
            return patient;
        }

        private static PatientModel GetPatientFromDataRow(DataRow dr)
        {
            return new PatientModel
            {
                PatientId = string.IsNullOrEmpty(dr["PatientId"].ToString()) ? 0 : Convert.ToInt32(dr["PatientId"]),
                PatientName = string.IsNullOrEmpty(dr["PatientName"].ToString()) ? string.Empty : dr["PatientName"].ToString(),
                Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? string.Empty : dr["Email"].ToString(),
                Number = string.IsNullOrEmpty(dr["Number"].ToString()) ? 0 : Convert.ToInt64(dr["Number"]),
                Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString(),
                DateOfBirth = string.IsNullOrEmpty(dr["DateOfBirth"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]),
                Gender = string.IsNullOrEmpty(dr["Gender"].ToString()) ? string.Empty : dr["Gender"].ToString(),
                Department = string.IsNullOrEmpty(dr["Department"].ToString()) ? string.Empty : dr["Department"].ToString(),
                Consultant = string.IsNullOrEmpty(dr["Consultant"].ToString()) ? string.Empty : dr["Consultant"].ToString(),
                Age = string.IsNullOrEmpty(dr["Age"].ToString()) ? 0 : Convert.ToInt32(dr["Age"]),
                TypeOfConsultation = string.IsNullOrEmpty(dr["TypeOfConsultation"].ToString()) ? string.Empty : dr["TypeOfConsultation"].ToString(),
            };
        }

        #endregion

    }
}
