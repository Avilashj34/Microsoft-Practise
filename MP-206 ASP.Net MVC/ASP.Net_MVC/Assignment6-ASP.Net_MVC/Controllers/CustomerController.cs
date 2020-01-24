using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment6_ASP.Net_MVC.Models;
using Assignment6_ASP.Net_MVC.DataAccess;

namespace Assignment6_ASP.Net_MVC.Controllers
{
    public class CustomerController : Controller
    {
        readonly DataAccessLayer da = new DataAccessLayer();
        // GET: Customer
        [HttpPost]
        public ActionResult InsertCustomer(Customer objcustomer)
        {
            objcustomer.Birthdate = Convert.ToDateTime(objcustomer.Birthdate);
            if (ModelState.IsValid)
            {
                
                string result = da.InsertData(objcustomer);
                ViewData["result"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllCustomerDetail");
            }
            else
            {
                ModelState.AddModelError("","Error in saving data");
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllCustomerDetail()
        {
            Customer customer = new Customer();
            customer.ShowallCustomer= da.SelectAllData();
            return View(customer);
        }    
    
        public ActionResult ShowDetailById(string search)
        {
            Customer Customer = new Customer();
            Customer = da.SelectAllDataById(search);
            if (Customer == null)
            {
                ViewBag.Msg="Record Not Exist for Custumer With Id " + search;
                
                return View("Index");
            }
            else
            {
                return View(Customer);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Customer cust = new Customer();
            cust = da.SelectAllDataById(id);
            return View(cust);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            customer.Birthdate = (DateTime)customer.Birthdate;
            if (ModelState.IsValid)
            {
                string result = da.UpdateData(customer);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("","Error Occured");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {            
            return View(da.SelectAllDataById(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer obj)
        {
            string result = da.DeleteData(obj);
            ViewData["result"] = result;
            ModelState.Clear();
            ViewBag.Msg = "Deleted Customer with Id "+obj.CustomerID;
            return RedirectToAction("ShowAllCustomerDetail");
        }

        public ActionResult searchCustomer(string id)
        {
            return View();
        }

    }
}