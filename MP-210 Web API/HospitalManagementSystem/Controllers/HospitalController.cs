using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class HospitalController : Controller
    {
        //private readonly HospitalDb db = new HospitalDb();
        // GET: Hospital
        public ActionResult Index()
        {
            /*db.physicians.ToList();
            db.departments.ToList();
            db.Affilated_with.ToList();
            db.Procedures.ToList();
            db.patients.ToList();
            
            db.nurses.ToList();
            db.Appointments.ToList();
            db.Medications.ToList();
            db.prescribes.ToList();
            db.blocks.ToList();
            db.Rooms.ToList();
            db.on_call.ToList();
            db.Stays.ToList();
            db.Undergoes.ToList();*/
            return View();
        }
    }
}