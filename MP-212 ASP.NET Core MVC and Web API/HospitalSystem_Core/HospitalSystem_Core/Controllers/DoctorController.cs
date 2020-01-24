using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.ViewModels;
using AutoMapper;
using HospitalSystem_Core.Business_Layer;
using Microsoft.AspNetCore.Http;

namespace HospitalSystem_Core.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IBusinessLayer businessLayer;
        private readonly IMapper _mapper;
        public DoctorController(IBusinessLayer businessLayer, IMapper mapper)
        {
            this.businessLayer = businessLayer;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddNewDoctor()
        {
            return View();
        }
        [HttpPost]        
        public IActionResult AddNewDoctor(DoctorVm doctor)
        {
            Doctors doctors=   _mapper.Map<DoctorVm,Doctors>(doctor);
            bool result= businessLayer.AddDoctor_Bl(doctors);
            if (result == false)
            {
                ViewBag.Message = "Something went wrong";
                return View();
            }
            return RedirectToAction("ListOfDoctor","Doctor");
        }

        [HttpGet]
        public IActionResult ListOfDoctor()
        {
            if (HttpContext.Session.GetString("sessionName") ==null)
            {
                TempData["Message"] = "Session Expired! Login here";
                return RedirectToAction("RegisterUser","User");
            }
            var result=businessLayer.ListOfDoctor_Bl();
            return View(result);
        }

        public IActionResult GetDoctorDetailById(int id)
        {
            var result = businessLayer.ListOfDoctor_Bl().FirstOrDefault(d=> d.Id == id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = businessLayer.DeleteDoctor_Bl(id);
                if(result== true)
                {
                    return RedirectToAction("ListOfDoctor", "Doctor");
                }
                else
                {
                    ViewBag.Message = "Failed to delete. Please try again some time";
                    return View("ListOfDoctor");
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Doctors doctor =businessLayer.ListOfDoctor_Bl().FirstOrDefault(d => d.Id == id);
            DoctorVm doctor_vm =_mapper.Map<Doctors,DoctorVm>(doctor);
            return View(doctor_vm);
        }
        
        [HttpPost]
        public IActionResult Edit(DoctorVm doctorvm)
        {
            Doctors doctors=_mapper.Map<DoctorVm,Doctors>(doctorvm);
            if (businessLayer.EditDoctorDetail_Bl(doctors))
            {
                return RedirectToAction("ListOfDoctor", "Doctor");
            }
            ViewBag.Message = "Update Failed";
            return View();
        }
    }
}