using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagement.Main.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Number { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public string Address { get; set; }
        public string SearchText { get; set; }

    }
}