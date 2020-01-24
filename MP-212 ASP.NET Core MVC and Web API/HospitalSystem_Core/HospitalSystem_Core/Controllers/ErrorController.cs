using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem_Core.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the resource requested could not be found"; 
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry the resource requested could not be found";
                    break;
            }
            return View("NotFound");
        }

        
    }
}