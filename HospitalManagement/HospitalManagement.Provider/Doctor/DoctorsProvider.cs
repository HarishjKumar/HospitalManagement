using HospitalManagement.DataAccess.Doctor;
using HospitalManagement.Main.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HospitalManagement.Provider.Doctor
{
    public class DoctorsProvider
    {
        #region Get
        public List<DoctorModel> GetDoctorsByCriteria(DoctorModel doctor,string connectionString)
        {
            List<DoctorModel> doctorsList = new List<DoctorModel>();
            DataSet ds = DoctorsDA.GetDoctorsByCriteria(doctor.Id,doctor.Name,doctor.Designation,doctor.SearchText,doctor.Password,connectionString);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return GetDoctorFromDataTable(ds.Tables[0]);
            }
            return doctorsList;
        }
        public DoctorModel GetDoctorByCriteria(DoctorModel doctor, string connectionString)
        {
            DoctorModel doctorDetails = new DoctorModel();
            DataSet ds = DoctorsDA.GetDoctorsByCriteria(doctor.Id, doctor.Name, doctor.Designation, doctor.SearchText, doctor.Password, connectionString);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return GetDoctorFromDataRow(ds.Tables[0].Rows[0]);
            }
            return doctorDetails;
        }
        #endregion

        #region Insert
        public void InsertDoctor(DoctorModel doctor,string connectionString)
        {
            DoctorsDA.InsertDoctor(doctor.Name, doctor.Password, doctor.Designation, doctor.DateOfBirth, doctor.Number, doctor.Email, doctor.Experience, doctor.Address, connectionString);
        }
        #endregion

        #region Update
        public void UpdateDoctor(DoctorModel doctor, string connectionString)
        {
            DoctorsDA.UpdateDoctor(doctor.Id,doctor.Name, doctor.Password, doctor.Designation, doctor.DateOfBirth, doctor.Number, doctor.Email, doctor.Experience, doctor.Address, connectionString);
        }

        #endregion

        #region Delete
        public void DeleteDoctor(int id, string connectionString)
        {
            DoctorsDA.DeleteDoctor(id, connectionString);
        }

        #endregion

        #region TranslateToObject

        private static List<DoctorModel> GetDoctorFromDataTable(DataTable dt)
        {
            List<DoctorModel> doctors = new List<DoctorModel>();
            foreach (DataRow dr in dt.Rows)
            {
                doctors.Add(GetDoctorFromDataRow(dr));
            }
            return doctors;
        }

        private static DoctorModel GetDoctorFromDataRow(DataRow dr)
        {
            return new DoctorModel
            {
                Id = string.IsNullOrEmpty(dr["Id"].ToString()) ? 0 : Convert.ToInt32(dr["Id"]),
                Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString(),
                Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? string.Empty : dr["Email"].ToString(),
                Password = string.IsNullOrEmpty(dr["Password"].ToString()) ? string.Empty : dr["Password"].ToString(),
                Number = string.IsNullOrEmpty(dr["Number"].ToString()) ? 0 : Convert.ToInt64(dr["Number"]),
                Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString(),
                DateOfBirth = string.IsNullOrEmpty(dr["DateOfBirth"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]),
                Experience = string.IsNullOrEmpty(dr["Experience"].ToString()) ? 0 : Convert.ToInt32(dr["Experience"]),
                Designation = string.IsNullOrEmpty(dr["Designation"].ToString()) ? string.Empty : dr["Designation"].ToString()
            };
        }

        #endregion

    }
}
