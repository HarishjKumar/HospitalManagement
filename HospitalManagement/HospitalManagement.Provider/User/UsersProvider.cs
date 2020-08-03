using HospitalManagement.DataAccess.User;
using HospitalManagement.Main.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HospitalManagement.Provider.User
{
    public class UsersProvider
    {
        #region Get
        public List<UserModel> GetUsersByCriteria(UserModel user, string connectionString)
        {
            List<UserModel> userList = new List<UserModel>();
            DataSet ds = UsersDA.GetUsersByCriteria(user.Id,user.Name,user.Role,user.SearchText,user.Password, connectionString);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return GetPatientFromDataTable(ds.Tables[0]);
            }
            return userList;
        }
        //public List<DepartmentModel> GetDepartmentByCriteria(DepartmentModel department, string connectionString)
        //{
        //    List<DepartmentModel> departmentList = new List<DepartmentModel>();
        //    DataSet ds = UsersDA.GetDepartmentsByCriteria(department.Id,department.Name, connectionString);
        //    return departmentList;
        //}
        #endregion

        #region Insert
        public void InsertUser(UserModel user, string connectionString)
        {
            UsersDA.InsertUser(user.Name,user.Password,user.Role,user.DateOfBirth,user.Number,user.Email,user.Experience,user.Address, connectionString);
        }
        public void InsertDepartment(DepartmentModel department, string connectionString)
        {
            UsersDA.InsertDepartment(department.Name, connectionString);
        }
        #endregion

        #region Update
        public void UpdateUser(UserModel user, string connectionString)
        {
            UsersDA.UpdateUser(user.Id,user.Name,user.Password,user.Role,user.DateOfBirth,user.Number,user.Email,user.Experience,user.Address, connectionString);
        }
        public void UpdateDepartment(DepartmentModel department, string connectionString)
        {
            UsersDA.UpdateDepartment(department.Id, department.Name, connectionString);
        }

        #endregion

        #region Delete
        public void DeleteUser(int id, string connectionString)
        {
            UsersDA.DeleteUser(id, connectionString);
        }
        public void DeleteDepartment(int id, string connectionString)
        {
            UsersDA.DeleteDepartment(id, connectionString);
        }

        #endregion

        #region TranslateToObject

        private static List<UserModel> GetPatientFromDataTable(DataTable dt)
        {
            List<UserModel> user = new List<UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                user.Add(GetUserFromDataRow(dr));
            }
            return user;
        }

        private static UserModel GetUserFromDataRow(DataRow dr)
        {
            return new UserModel
            {
                Id = string.IsNullOrEmpty(dr["Id"].ToString()) ? 0 : Convert.ToInt32(dr["Id"]),
                Name = string.IsNullOrEmpty(dr["Name"].ToString()) ? string.Empty : dr["Name"].ToString(),
                Password = string.IsNullOrEmpty(dr["Password"].ToString()) ? string.Empty : dr["Password"].ToString(),
                Email = string.IsNullOrEmpty(dr["Email"].ToString()) ? string.Empty : dr["Email"].ToString(),
                Number = string.IsNullOrEmpty(dr["Number"].ToString()) ? 0 : Convert.ToInt64(dr["Number"]),
                Address = string.IsNullOrEmpty(dr["Address"].ToString()) ? string.Empty : dr["Address"].ToString(),
                DateOfBirth = string.IsNullOrEmpty(dr["DateOfBirth"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dr["DateOfBirth"]),
                Role = string.IsNullOrEmpty(dr["Role"].ToString()) ? string.Empty : dr["Role"].ToString(),
                Experience = string.IsNullOrEmpty(dr["Experience"].ToString()) ? 0 : Convert.ToInt32(dr["Experience"]),
            };
        }

        #endregion
    }
}
