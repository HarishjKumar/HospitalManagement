using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagement.Main.Models
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Email { get; set; }
        public long Number { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Consultant { get; set; }
        public int Age { get; set; }
        public string TypeOfConsultation { get; set; }
        public string SearchText { get; set; }

    }
}