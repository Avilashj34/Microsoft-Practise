using System;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem_Core.ViewModels;
using AutoMapper;
using HospitalSystem_Core.Models;
using HospitalSystem_Core.Business_Layer;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Vereyon.Web;

namespace HospitalSystem_Core.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBusinessLayer user;
        public UserController(IMapper mapper, IBusinessLayer user)
        {
            _mapper = mapper;
            this.user = user;
        }
        [HttpGet]
        public IActionResult RegisterUser()
        {
            ViewBag.Message = TempData["Message"] as string;
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(RegisterVm registeruser)
        {
            if (VerifyOtp(registeruser.OTP)!=1)
            {
                ViewBag.Message = "Entered otp is incorrect";
            }

            if (user.CheckNumber_Bl(registeruser.Phone) == true)
            {
                ViewBag.Message = "Number Exist ";
                return View();
            }

            if (!Validation.CheckFullName(registeruser.Name))
            {
                ViewBag.Message = "Enter Your Full Name";
                return View();
            }
            Validation.ModifyName(registeruser.Name);
            Register register = _mapper.Map<RegisterVm, Register>(registeruser);
            register.UserVerified = 1;
            bool result = user.RegisterUser(register);
            if (result)
            {
                ViewBag.Success = "IsTrue";
                ViewBag.Message = "Registered Sucessfully";
            }
            else
            {
                ViewBag.Message = "Registration Failed";
            }
            return View();
        }

        public IActionResult LoginUser()
        {
            ViewBag.Success = "IsTrue";
            return View("RegisterUser");
        }

        [HttpPost]
        public IActionResult LoginUser(LoginVm login)
        {
            bool result = user.VerifyUser(login);
            if (result == true)
            {               
                HttpContext.Session.SetString("sessionName", login.Phone);
                /*using (var db = new DoctorDbContext())
                {
                    db.Register.Attach(register);
                    db.Entry(register).Property(r => r.LastLoginDetail).IsModified = true;
                    db.SaveChanges();
                }*/
                var l = new Login {Phone = login.Phone};
                bool res= user.InsertLoginTime_Bl(l);
                if (res == true)
                {                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Success = "IsTrue";
                    ViewBag.Message = "Login Failed";
                    return View("RegisterUser");
                }
            }
            else
            {
                ViewBag.Success = "IsTrue";
                ViewBag.Message = "Login Failed";
                return View("RegisterUser");
            }
        }

        public IActionResult EnterOtp()
        {
            return View();
        }

        
        public JsonResult SendOtp(string number)
        {
            
            int otpvalue = new Random().Next(1000,9999);
            var status = "";
            try
            {
                string recipient = number;
                string APIKey = "X0kW9swOvRA-4gfCAboYleHbFr41VamQj7YgNEfUvX";
                string message = "OTP to validate mobile no. is " + otpvalue + " .OTPs are SECRET. DO NOT disclose it to anyone.";
                string encodemessage = HttpUtility.UrlEncode(message);
                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    {
                        {"apikey",APIKey },
                        { "numbers",recipient},
                        { "message",encodemessage },
                        {"sender","TXTLCL" }
                    });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    //string result = "otp is "+otpvalue;
                    var jsonobject = JObject.Parse(result);
                    status = jsonobject["status"].ToString();
                    HttpContext.Session.SetString("CurrentOTP", otpvalue.ToString());

                }
                return Json(status);
            }
            catch (Exception e)
            {
                throw e;
            }
            /*var d = new { success = "success", phone = number };
            return Json(d);*/

        }

        [NonAction]
        public int VerifyOtp(string otp)
        {
            int result = 0;
            var SessionOTP=HttpContext.Session.GetString("CurrentOTP");
            if (SessionOTP==otp)
            {
                result = 1;
            }
            return result;
        }

        public IActionResult Profile()
        {                       
            return View();
        }
    }
}