using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.ViewModels;

namespace HospitalSystem_Core.Business_Layer
{
    public interface IBusinessLayer
    {
        public bool RegisterUser(Register register);
        public bool VerifyUser(LoginVm login);
        public bool AddDoctor_Bl(Doctors doctors);
        public IEnumerable<Doctors> ListOfDoctor_Bl();
        public bool AddPatient_Bl(Patients patients);
        public IEnumerable<Patients> ListOfPatient_Bl();
        public bool DeleteDoctor_Bl(int id);
        public bool CheckNumber_Bl(string Number);
        public bool EditDoctorDetail_Bl(Doctors doctors);
        public bool EditPatientDetail_Bl(Patients patients);
        public bool InsertLoginTime_Bl(Login l);
        public UserDetailVm LoginDetail_Bl(string Phone);
    }
}
