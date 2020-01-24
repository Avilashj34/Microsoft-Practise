using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace WebApiCRUD.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using(masterEntities entities=new masterEntities())
            {
                return entities.Employeee.ToList();
            }
        }

        public IEnumerable<Employee> Get(int id)
        {
            using (masterEntities entities = new masterEntities())
            {
                yield return entities.Employeee.FirstOrDefault(e => e.id == id);

            }
        }
    }
}
