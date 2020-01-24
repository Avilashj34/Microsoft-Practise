using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.ViewModel;
using System.Web.Mvc.Routing;

namespace HospitalManagementSystem.Controllers.API
{
    public class PhysicianController : ApiController
    {
        HospitalDb db;

        public PhysicianController()
        {
             db = new HospitalDb();  
        }
        
        [Authorize]
        public IHttpActionResult GetPhysicianDetail()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            using (db = new HospitalDb())
            {
                var result = db.physicians.Include("PhysicianPosition").Select(p => new PhysicianViewModel()
                {
                    PhysicianId= p.PhysicianId,
                    PhysicianName = p.PhysicianName,
                    PhysicianPosition = p.PhysicianPosition,
                    PhysicianSSN = p.PhysicianSSN
                }).ToList();
                if (result.Count == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }           
        }

        
        public IHttpActionResult PostPhysicianDetail(PhysicianViewModel pv)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var p = new Physician()
            {
                PhysicianName = pv.PhysicianName,
                PhysicianPosition = pv.PhysicianPosition,
                PhysicianSSN = pv.PhysicianSSN
            };
            db.physicians.Add(p);
            
            db.SaveChanges();
            int foreign_id = p.PhysicianId;           
            db.departments.Add(new Department() { DepartmentName=pv.Departments,PhysicianId= foreign_id });
            db.SaveChanges();            
            return CreatedAtRoute("DefaultApi", new { id = p.PhysicianId }, p);
        }

        public async Task<IHttpActionResult> DeletePhysician(int id)
        {
            if (id<0)
            {
                return BadRequest("Not a valid student id");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = db.physicians.Where(p => p.PhysicianId == id).FirstOrDefault();
            var result1 = db.physicians.Remove(result);
            //db.Entry(result).State=System.Data.Entity.EntityState.Deleted;
            var res=await db.SaveChangesAsync();
            return Ok(res);
        }


        
        /*[HttpGet]
        [Route("api/GetPhysicianInGroup")]
        public async Task<IHttpActionResult> PhysicianWithDeptInGroup()
        {
            var list = db.physicians.ToList();

            return Ok();
        }*/
    }
}
