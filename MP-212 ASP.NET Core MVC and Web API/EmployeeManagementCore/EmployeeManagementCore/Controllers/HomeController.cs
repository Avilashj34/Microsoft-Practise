using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementCore.Models;

namespace EmployeeManagementCore.Controllers
{
    public class HomeController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string Index()
        {
            //return _employeeRepository.GetEmployee(1).Name;
            return null;
        }

        public JsonResult GetAll()
        {
            return Json(_employeeRepository.GetEmployee(1));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {

            return View();
        }

        public ActionResult EmployeeList() => View(_employeeRepository.GetAllEmployee());

    }
}