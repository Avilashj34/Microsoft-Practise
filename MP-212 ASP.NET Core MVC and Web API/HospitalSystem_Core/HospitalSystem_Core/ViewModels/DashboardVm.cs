using HospitalSystem_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem_Core.ViewModels
{
    public class UserDetailVm
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? LoginDetail { get; set; }
        public int? UserVerified { get; set; }
    }
    public class DashboardVm
    {
        public int Patients_count { get; set; }
        public int Doctors_count { get; set; }
        public int Nurses_count { get; set; }
        public UserDetailVm UserDetailVm { get; set; }
    }
}
