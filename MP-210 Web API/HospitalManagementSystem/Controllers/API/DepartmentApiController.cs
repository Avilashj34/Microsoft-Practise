using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.ViewModel;

namespace HospitalManagementSystem.Controllers.API
{
    public class DepartmentApiController : ApiController
    {
        
        HospitalDb Db = null;

        public DepartmentApiController()
        {
            Db = new HospitalDb();
        }

        public IHttpActionResult Get()
        {
            using (Db = new HospitalDb())
            {
                List<DepartmentViewModel> departments = null;
                departments = Db.departments.Include("Physician").Select(d => new DepartmentViewModel()
                {

                    DepartmentName = d.DepartmentName,
                    /*physicianList = d.physician == null ? null : new PhysicianViewModel()
                    {
                        PhysicianName = d.physician.PhysicianName,
                        PhysicianPosition = d.physician.PhysicianPosition,
                        PhysicianSSN = d.physician.PhysicianSSN
                    }*/
                }).ToList<DepartmentViewModel>();

                if (departments.Count == 0)
                {
                    return NotFound();
                }
                return Ok(departments);
            }
        }

        [HttpGet]
        [Route("api/Dept")]
        public IHttpActionResult GetData()
        {
            using (Db = new HospitalDb())
            {
                List<DepartmentViewModel> departments = null;
                departments = Db.departments.Select(d => new DepartmentViewModel()
                {

                    DepartmentName = d.DepartmentName,
                    /*physician = d.physician == null ? null : new PhysicianViewModel()
                    {
                        PhysicianName = d.physician.PhysicianName,
                        PhysicianPosition = d.physician.PhysicianPosition,
                        PhysicianSSN = d.physician.PhysicianSSN
                    }*/
                }).ToList<DepartmentViewModel>();

                if (departments.Count == 0)
                {
                    return NotFound();
                }
                return Ok(departments);
            }
        }

        public async Task<IHttpActionResult> PostDepartment([FromBody]Department d)
        {
            using (Db= new HospitalDb())
            {
                Db.departments.Add(new Department()
                {  
                    DepartmentName = d.DepartmentName,
                    physician = new Physician()
                    {
                        PhysicianName = d.physician.PhysicianName,
                        PhysicianPosition= d.physician.PhysicianPosition,
                        PhysicianSSN = d.physician.PhysicianSSN
                    }
                });
                var save = await Db.SaveChangesAsync();
                return Ok("Added Data");
            }
        }

        [HttpGet]
        [Route("api/GetDeptData")]
        public  IHttpActionResult GetDeptData()
        {
            using (Db = new HospitalDb())
            {
                List<DepartmentViewModel> departments = null;
                departments =  Db.departments.Include("Physician").Select(d => new DepartmentViewModel()
                {

                    DepartmentName = d.DepartmentName,
                    /*physician = d.physician == null ? null : new PhysicianViewModel()
                    {
                        PhysicianName = d.physician.PhysicianName,
                        PhysicianPosition = d.physician.PhysicianPosition,
                        PhysicianSSN = d.physician.PhysicianSSN
                    }*/
                }).ToList();
                return Ok(departments);
            }
        }

        [HttpGet]
        [Route("api/GetDataByDept/{departmentname}")]
        public IList<DepartmentViewModel> GetDataByDept(string departmentname)
        {
            using (Db = new HospitalDb())
            {
                // Query Method
                var departments = (from d in Db.departments
                               where d.DepartmentName == departmentname
                               select new DepartmentViewModel()
                               {
                                   DepartmentName = d.DepartmentName,
                                   /*physician = d.physician == null ? null : new PhysicianViewModel()
                                   {
                                       PhysicianName = d.physician.PhysicianName,
                                       PhysicianPosition = d.physician.PhysicianPosition,
                                       PhysicianSSN = d.physician.PhysicianSSN
                                   }*/
                               });
                return departments.ToList();
            }
        }

        [HttpGet]
        [Route("api/GetFirstDeptData/{departmentname}")]
        public int GetFirstDeptData(string departmentname)
        {
            using (Db = new HospitalDb())
            {
                var dept = Db.departments.Where(x => x.DepartmentName.Equals(departmentname)).LastOrDefault();
                return dept.DepartmentId;
            }
            
        }

        [HttpGet]
        [Route("api/GetDeptInGroup")]
        public IEnumerable<string> GetDeptInGroup()
        {
            /*using(Db= new HospitalDb())
            {
                var l = Db.departments.GroupBy(x => x.DepartmentName);
                return l.Select(d => new DepartmentViewModel()).Select(x => x.physician.PhysicianName).ToList();
            }*/
            return null;
            
        }


        [HttpGet]
        [Route("api/GetInGroup")]
        public IHttpActionResult GetInGroup()
        {
            /*var departmentList = new List<DepartmentViewModel>();
            DepartmentViewModel department = new DepartmentViewModel();
            var result = from dt in Db.departments
                         group dt by dt.DepartmentName 
                         into eGroup
                         orderby eGroup.Key
                         select eGroup;

            foreach (IGrouping<string, DepartmentViewModel> group in result)
            {
                Console.WriteLine(group.Key);

                department.DepartmentName = group.Key;

                foreach (DepartmentViewModel p in group)
                {
                    Console.WriteLine(" " + p.physician.PhysicianName + " " + p.physician.PhysicianPosition);
                    department.physician.PhysicianName = p.physician.PhysicianName;
                    departmentList.Add(department);
                }
            }
            return Ok(departmentList);*/

            var l = Db.departments.GroupBy(x => x.DepartmentName, (key, group) =>
            new DepartmentViewModel()
            {
                DepartmentName = key,
                Count_Dept= group.Count(),
                physicianList = group.Select(p => new PhysicianViewModel()
                {
                    PhysicianId= p.physician.PhysicianId,
                    PhysicianName = p.physician.PhysicianName,
                    PhysicianPosition = p.physician.PhysicianPosition,
                    PhysicianSSN = p.physician.PhysicianSSN
                })
            });
            return Ok(l.ToList());
        }


    }
}
