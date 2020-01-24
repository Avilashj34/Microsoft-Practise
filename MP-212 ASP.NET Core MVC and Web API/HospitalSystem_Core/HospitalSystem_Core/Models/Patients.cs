using System;
using System.Collections.Generic;

namespace HospitalSystem_Core.Models
{
    public partial class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string HealthCondition { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
