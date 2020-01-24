using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.Business_Layer;
using Microsoft.AspNetCore.Http;

namespace HospitalSystem_Core.Controllers
{
    public class PatientController : Controller
    {
        private readonly IBusinessLayer businessLayer;
        public PatientController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        public IActionResult AddPatient()
        {
            /*if (HttpContext.Session.GetString("sessionName") == null)
            {
                ViewBag.Message = "Session expired";
                ViewBag.Success = "IsTrue";
                return View("RegisterUser");
            }*/
            return View();
        }

        [HttpPost]
        public IActionResult AddPatient(Patients patients)
        {
            bool result =businessLayer.AddPatient_Bl(patients);
            if (result)
            {
                ViewBag.Message = "Something Went Wrong";
                return View();
            }
            return RedirectToAction("GetPatientData");
        }

        public ViewResult GetParticularIdDetail(int id)
        {
            var patient = businessLayer.ListOfPatient_Bl().FirstOrDefault(p=> p.Id==id);
            if(patient == null)
            {
                Response.StatusCode = 404;
                ViewBag.Id = id;
                return View("PatientNotFound");
            }
            return View(patient);
        }

        public IActionResult GetPatientData()
        {            
            var result = businessLayer.ListOfPatient_Bl();
            return View(result);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Patients patients= businessLayer.ListOfPatient_Bl().FirstOrDefault(p=> p.Id == id);
            return View(patients);
        }

        [HttpPost]
        public IActionResult Edit(Patients patients)
        {
            if (businessLayer.EditPatientDetail_Bl(patients))
            {
                return RedirectToAction("GetPatientData", "Patients");
            }
            ViewBag.Message = "Update Failed";
            return View();

        }
    }
}