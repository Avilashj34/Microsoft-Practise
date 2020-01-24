using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment6_ASP.Net_MVC.Controllers
{
    public class HomeController : Controller
    {
        //http://www.webdevelopmenthelp.net/2016/10/asp-net-mvc-shopping-cart-part1.html
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}