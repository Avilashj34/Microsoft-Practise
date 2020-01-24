using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.ViewModels;

namespace HospitalSystem_Core.DataAcessLayer
{
    public interface IDataLayer
    {
        public bool RegisterUser(Register register);
        public bool VerifyUser(LoginVm login);
        public bool AddDoctor(Doctors doctors);
        public IEnumerable<Doctors> ListOfDoctor();
        public bool AddPatient(Patients patients);
        public IEnumerable<Patients> ListOfPatient();
        public bool DeleteDoctor(int id);
        public bool CheckNumber(string Number);
        public bool EditDoctorDetail(Doctors doctors);
        public bool EditPatientDetail(Patients patients);
        public bool InsertLoginTime(Login l);
        public UserDetailVm LoginDetails(string Phone);
    }
}
