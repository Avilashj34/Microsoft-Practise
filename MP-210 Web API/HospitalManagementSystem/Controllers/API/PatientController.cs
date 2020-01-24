using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HospitalManagementSystem.Models.ViewModel;
using System.Threading.Tasks;

using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers.API
{
    public class PatientController : ApiController
    {
        HospitalDb db = null;
        public PatientController()
        {
            db = new HospitalDb();
        }
        

        public IHttpActionResult Post([FromBody]Patient p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (db= new HospitalDb())
            {
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                db.Stays.Add(new Stay()
                {
                    Start_Time = BitConverter.GetBytes(Timestamp),
                    End_Time = DateTime.Now
                });
                db.patients.Add(new Patient()
                {
                    Name= "Patient1",
                    Address= "address1",
                    phone = 222,
                    PhysicianId =1,
                    Stay_StayId=1
                });
                
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
