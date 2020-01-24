using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HospitalManagementSystem.Models.ViewModel
{
    public class DepartmentViewModel
    {
        public string DepartmentName { get; set; }

        public int Count_Dept { get; set; }

        public IEnumerable<PhysicianViewModel> physicianList { get; set; }
        /*public DepartmentViewModel(){
            physicianList = new List<PhysicianViewModel>();
    }
        */
    }

    /*DepartmentViewModel[] ownersArray = JsonConvert.DeserializeObject<DepartmentViewModel[]>(string json);*/
}