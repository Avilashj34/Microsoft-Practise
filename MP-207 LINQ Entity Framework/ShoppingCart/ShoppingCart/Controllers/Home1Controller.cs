using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.ViewModel;
using ShoppingCart.Business;
using ShoppingCart.DataAcess;
using System.Web.Security;

namespace ShoppingCart.Controllers
{
    
    public class Home1Controller : Controller
    {
        //readonly ProductBll ProductBll = new ProductBll(new DbConnection());
        readonly ProductBll ProductBll;
        public Home1Controller(ProductBll ProductBll)
        {
            this.ProductBll = ProductBll;
        }
        // GET: Home1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adminlogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adminlogin(AdminView adminView)
        {
            if (adminView.Name == "Avilash" && adminView.Password == "Qwerty")
            {
                Session["admin"] = "Admin";
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                ViewBag.Message = "Admin Login Failed. Check Name and Password";
                return View();
            }
        }

        public ActionResult AdminDashboard()
        {
            if (Session["admin"] !=null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = "Login Again";
                return RedirectToAction("Adminlogin");
            }
        }

        public ActionResult CustomerOrderProduct()
        
        {
            if (Session["admin"] != null)
            {
                IEnumerable<CustomerOrderView> customerOrderList = ProductBll.Bl_ShowCustomerOrderList();
                return View(customerOrderList);
            }
            else
            {
                ViewBag.Message = "Something Went Wrong!!.\n Please Login Again";
                return Adminlogin();
            }
            
        }

        public ActionResult Logout()
        {
            if (Session["admin"] != null || Session["username"] != null)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon(); //Cancel the current session ehrn in a derived class
                return Redirect("Index");
            }
            return View("Index");
        }
    }
}