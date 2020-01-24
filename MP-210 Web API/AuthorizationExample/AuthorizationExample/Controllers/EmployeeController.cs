using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthorizationExample.Models;

namespace AuthorizationExample.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/GetData")]
        public IEnumerable<Employee> LoadAllData()
        {
            using (masterEntities db=new masterEntities())
            {
                return db.Employees.ToList();
            }
        }
    }
}
