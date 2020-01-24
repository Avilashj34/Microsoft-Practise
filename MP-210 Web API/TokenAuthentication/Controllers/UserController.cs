using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using TokenAuthenticationAssinment1.Models;

namespace TokenAuthenticationAssinment1.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/alldata")]
        public IHttpActionResult GetAllData()
        {
            using (TokenDbEntities db = new TokenDbEntities())
            {
                var user = db.UserMasters.ToList();
                return Ok(user);
            }
        }

        public IHttpActionResult GetResource4()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var data = identity.Claims.Select(c => c.Value);
            return Ok(data.ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role " + string.Join(",", roles.ToList()));
        }

        [Authorize(Roles ="SuperAdmin , Admin")]
        [HttpGet]
        [Route("api/resource2")]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            var name = identity.Name;
            return Ok("Hello name is : "+name+" Email is : "+Email);
        }


        [Authorize(Roles ="Admin, User")]
        [HttpGet]
        [Route("api/resource1")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roleclaim = identity.RoleClaimType;
            var role = identity.Claims.FirstOrDefault(c => c.Type == "Role").Value;
            return Ok("Hello "+roleclaim+" "+identity.Name+ " "+role);
        }

    }
}
