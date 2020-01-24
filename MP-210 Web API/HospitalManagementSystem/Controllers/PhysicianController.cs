using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.ViewModel;

namespace HospitalManagementSystem.Controllers
{
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPhysician()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhysician(PhysicianViewModel p)
        {           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                var postTask = client.PostAsJsonAsync<PhysicianViewModel>("Physician", p);
                /*Here we used .wait till then the task will cmptd*/
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AddPhysician");
                }
            }
            ModelState.AddModelError(string.Empty,"Server error");
            return View();
        }

        public ActionResult GetPhysician()
        {
            IEnumerable<Physician> p = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                var response = client.GetAsync("Physician");
                /* GetAsync() method is asynchronous and returns a Task. Task.wait()
                 * suspends the execution until GetAsync() method completes the execution and returns a result.*/
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<IList<Physician>>();
                    readtask.Wait();
                    p = readtask.Result;
                }
                else
                {
                    p = Enumerable.Empty<Physician>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return View(p);
        }

        public ActionResult DeletePhysician(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                var response = client.DeleteAsync("Physician/"+id.ToString());
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetPhysician");
                }
                return RedirectToAction("Index");
            }           
        }

        public ActionResult DepartmentWithPhysician()
        {
            IEnumerable<DepartmentViewModel> departmentlist = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                var response = client.GetAsync("GetInGroup");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<IList<DepartmentViewModel>>();
                    readtask.Wait();
                    departmentlist = readtask.Result;
                }
                else
                {
                    departmentlist = Enumerable.Empty<DepartmentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return View(departmentlist);
        }
    }
}