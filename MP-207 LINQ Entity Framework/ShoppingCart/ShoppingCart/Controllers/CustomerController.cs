using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.ViewModel;
using ShoppingCart.Business;
using ShoppingCart.DataAcess;
using ShoppingCart.Models;


namespace ShoppingCart.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerBll customerBll;
        public CustomerController(ICustomerBll customerbll)
        {
            customerBll = customerbll;
        }

        // GET:  Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(Customer customerRegistration)
        {
            customerBll.SaveCustomerCredential(customerRegistration);
            return RedirectToAction("LoginCustomer", "Customer");
        }

        public ActionResult LoginCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCustomer(Customer login)
        {
            int i =customerBll.VerifyCredential(login);
            if (i!= 0) 
            {
                Session["username"] = login.UserName;
                return RedirectToAction("CustomerDashboard");
            }
            else
            {
                TempData["Message"] = "UserName and Password Not Matched";
                return View();
            }
            
        }

        
        public ActionResult CustomerDashboard()
        {
            if (Session["username"]!=null)
            {                
                IEnumerable<Product> productList = customerBll.ShowProduct();
                return View(productList);
            }
            else
            {
                TempData["Message"] = "Session Expired";
                return Redirect("LoginCustomer");
            }
            
        }

        
        public ActionResult AddToCart(int id,string name,int price)
        {
            
            string Sessionname = Session["username"].ToString();
            CartView pv = new CartView
            {
                Name = name,
                Price = price,
                Quantity = 1                
            };
            CartSingleton.GetInstance().addToCart().Add(id, pv);
            customerBll.InsertForeignValue(Sessionname,id,1);
            Session["cart"] = name;
            TempData["movetocart"] = "Move To Cart";
            return RedirectToAction("CustomerDashboard");
        }

        public ActionResult MoveToCart()
        {
            //int count = CustomerProduct.Count();
            //int count = CartSingleton.GetInstance().GetList().Count();
            if(Session["cart"] != null)
            {
                return View(CartSingleton.GetInstance().GetList());
            }
            return RedirectToAction("CustomerDashboard");
        }

        [HttpGet]
        public ActionResult MyOrder()
        {
            if (Session["username"] != null)
            {
                TempData["Message"] = Session["username"].ToString();
                var listoforderedcustomer = customerBll.Bl_GetCustomerDetailUsingUserName(Session["username"].ToString(),1);
                return View(listoforderedcustomer);
            }
            else
            {
                TempData["Message"] = "Session Expired";
                return Redirect("LoginCustomer");
            }
        }

        [HttpGet]
        public ActionResult MyCart()
        {
            if (Session["username"] != null)
            {
                TempData["Message"] = Session["username"].ToString();
                var listofcartcustomer=customerBll.Bl_GetCustomerDetailUsingUserName(Session["username"].ToString(), 0);
                //Session["order"] = listofcartcustomer.Select(c => c.ProductName).FirstOrDefault();
                return View(listofcartcustomer);
            }
            else
            {
                TempData["Message"] = "Session Expired";
                return Redirect("LoginCustomer");
            }                
        }

        public ActionResult Buy(string pname,int price)
        {          
            //var listofcartcustomer = customerBll.Bl_GetCustomerDetailUsingUserName(Session["username"].ToString(), 0);
            //var list = listofcartcustomer.Select(p => p.Price);
            Session["order"]=pname;
            customerBll.Bl_UpdateForeignKey(Session["username"].ToString(),pname);
            if (Session["order"]!=null)
            {
                TempData["price"] = price;
                return View();
            }
            else
            {
                return Redirect("LoginCustomer");
            }
                                
        }

        public ActionResult OrderAll()
        {            
            var listofcartcustomer = customerBll.Bl_GetCustomerDetailUsingUserName(Session["username"].ToString(), 0);
            var pricelist = listofcartcustomer.Select(p => p.Price);

            customerBll.Bl_UpdateAllForeignKey(Session["username"].ToString());
            if (Session["username"] != null)
            {
                return View(pricelist);
            }
            else
            {
                return Redirect("LoginCustomer");
            }
                      
        }
    }
}