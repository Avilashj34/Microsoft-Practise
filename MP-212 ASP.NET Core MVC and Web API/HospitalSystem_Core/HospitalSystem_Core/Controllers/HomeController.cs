using Microsoft.AspNetCore.Mvc;
using HospitalSystem_Core.ViewModels;
using Microsoft.AspNetCore.Http;
using HospitalSystem_Core.Business_Layer;


namespace HospitalSystem_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessLayer businessLayer;

        public HomeController(IBusinessLayer _businessLayer)
        {
            businessLayer = _businessLayer;
        }

        public IActionResult Index()
        {
            string Phone = HttpContext.Session.GetString("sessionName");
            if (Phone == null)
            {
                return RedirectToAction("RegisterUser", "User");
            }
            DashboardVm dashboardVm = new DashboardVm()
            {
                Doctors_count = 6,
                Nurses_count = 12,
                Patients_count = 45,
                UserDetailVm= businessLayer.LoginDetail_Bl(Phone)
            };            
            return View(dashboardVm);
        }

        public IActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            HttpContext.Session.Remove("sessionName");
            HttpContext.Session.Clear();
            return RedirectToAction("RegisterUser","User");
        }
    }
}