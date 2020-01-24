using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.DataAcessLayer;
using HospitalSystem_Core.ViewModels;

namespace HospitalSystem_Core.Business_Layer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IDataLayer dataLayer;
        public BusinessLayer(IDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public bool VerifyUser(LoginVm login)
        {
            var res =dataLayer.VerifyUser(login);
            if (res == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool RegisterUser(Register register)
        {            
            return dataLayer.RegisterUser(register);
        }

        public bool AddDoctor_Bl(Doctors doctors)
        {
            return dataLayer.AddDoctor(doctors);
        }

        public IEnumerable<Doctors> ListOfDoctor_Bl()
        {
            return dataLayer.ListOfDoctor();
        }

        public bool AddPatient_Bl(Patients patients)
        {
            return dataLayer.AddPatient(patients);
        }

        public IEnumerable<Patients> ListOfPatient_Bl()
        {
            return dataLayer.ListOfPatient();
        }

        public bool DeleteDoctor_Bl(int id)
        {
            return dataLayer.DeleteDoctor(id);
        }

        public bool CheckNumber_Bl(string Number)
        {
            return dataLayer.CheckNumber(Number);
        }

        public bool EditDoctorDetail_Bl(Doctors doctors)
        {
            return dataLayer.EditDoctorDetail(doctors);
        }

        public bool EditPatientDetail_Bl(Patients patients)
        {
            return dataLayer.EditPatientDetail(patients);
        }

        public bool InsertLoginTime_Bl(Login l)
        {
            return dataLayer.InsertLoginTime(l);
        }

        public UserDetailVm LoginDetail_Bl(string Phone)
        {
            return dataLayer.LoginDetails(Phone);
        }
    }
}
