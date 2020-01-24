using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.ViewModels;

namespace HospitalSystem_Core.DataAcessLayer
{
    public class DataLayer : IDataLayer
    {
        private readonly DoctorDbContext doctorDbContext;
        public DataLayer(DoctorDbContext doctorDbContext)
        {
            this.doctorDbContext = doctorDbContext;
        }

        public bool AddDoctor(Doctors doctors)
        {
            doctorDbContext.Add(doctors);
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPatient(Patients patients)
        {
            doctorDbContext.Patients.Add(patients);
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDoctor(int id)
        {
            Doctors doctors = doctorDbContext.Doctors.FirstOrDefault(d => d.Id == id);
            doctorDbContext.Doctors.Remove(doctors);
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Doctors> ListOfDoctor()
        {
            IEnumerable<Doctors> listOfDoctor = doctorDbContext.Doctors.ToList();
            if (listOfDoctor == null)
            {
                return null;
            }
            return listOfDoctor;
        }

        public IEnumerable<Patients> ListOfPatient()
        {
            return doctorDbContext.Patients.ToList();
        }

        public bool RegisterUser(Register register)
        {
            doctorDbContext.Register.Add(register);
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerifyUser(LoginVm login)
        {
            var user = doctorDbContext.Register.Where(l => l.Password == login.Password && l.Phone == login.Phone).Select(l => l).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool InsertLoginTime(Login l)
        {
            doctorDbContext.Login.Add(l);
            int i=doctorDbContext.SaveChanges();
            if (i==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckNumber(string number)
        {
            var result = doctorDbContext.Register.FirstOrDefault(r => r.Phone.Trim() == number.Trim());
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditDoctorDetail(Doctors doctors)
        {
            var dbresult = doctorDbContext.Doctors.FirstOrDefault(d => d.Phone == doctors.Phone);
            dbresult.Name = doctors.Name;
            dbresult.Email = doctors.Email;
            dbresult.Gender = doctors.Gender;
            /*dbresult.Phone = doctors.Phone;*/
            dbresult.Specialist = doctors.Specialist;
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            return false;
        }

        public bool EditPatientDetail(Patients patients)
        {
            var dbresult = doctorDbContext.Patients.FirstOrDefault(p => p.Phone == patients.Phone);
            dbresult.Name = patients.Name;
            //dbresult.Phone = patients.Phone;
            dbresult.Gender = patients.Gender;
            dbresult.HealthCondition = patients.HealthCondition;
            int i = doctorDbContext.SaveChanges();
            if (i == 1)
            {
                return true;
            }
            return false;
        }

        public UserDetailVm LoginDetails(string Phone)
        {
            var max = doctorDbContext.Login.Where(l => l.Phone==Phone);
            var d=new Login();
            if (max!=null)
            {
               d = max.OrderBy(l => l.Phone).Skip(1).FirstOrDefault();
            }           
            var log=doctorDbContext.Register.Join(doctorDbContext.Login, r=> r.Phone,l=> l.Phone,
                      (r,l)=>new { r,l}).Where(l=> l.r.Phone==l.l.Phone).Select(u=> new UserDetailVm 
                      {
                          LoginDetail=d.LastLoginDetail??null,
                          Phone=u.l.Phone,
                          Name=u.r.Name,
                          UserVerified=u.r.UserVerified
                      }).FirstOrDefault(l=> l.Phone== Phone);
            if (log==null)
            {
                return null;
            }
            else
            {
                return log;
            }
        }

        
    }
}
