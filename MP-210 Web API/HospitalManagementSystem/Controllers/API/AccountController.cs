using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HospitalManagementSystem.Models.ViewModel;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers.API
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (Entities db = new Entities())
            {
                var result = db.Accounts.ToList();
                return Ok(result);
            }
        }

        
        [HttpPost]
        [Route("api/account/register")]
        public IHttpActionResult Post(AccountViewModel accountvm)
        {
            Account account = new Account
            {
                Email=accountvm.Email,
                Password= accountvm.Password
            };
            using (Entities db = new Entities())
            {
                db.Accounts.Add(account);
                int i=db.SaveChanges();
                if (i != 0)
                {
                    return Ok();
                }
                return BadRequest("Error while inserting data");
            }
        }

    }
}
