using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class NurseController : Controller
    {
        // GET: Nurse
        HospitalDb db = new HospitalDb();
        nurse nurse = new nurse();
        public ActionResult Insert1()
        {
            db.nurses.Add(new nurse()
            {
                NurseName = "Aparna",
                NursePosition = "General ",
                NurseSSN = 2001
            });

            db.nurses.Add(new nurse()
            {
                NurseName = "Preeti",
                NursePosition = "Certified ",
                NurseSSN = 2002
            });

            db.nurses.Add(new nurse()
            {
                NurseName = "Reshma",
                NursePosition = "Practitioner",
                NurseSSN = 2003
            });

            db.SaveChanges();
            return View();
        }


        public ActionResult Insert()
        {
            db.departments.Add(new Department()
            {
                DepartmentName = "Cancer",
                physician = new Physician() { PhysicianName="Name9", PhysicianPosition="Eye Cancer", PhysicianSSN=1009}
            });
            db.SaveChanges();
            return View();
        }

    } 
}