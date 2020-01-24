using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.ViewModel
{
    public class PhysicianViewModel
    {
        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianPosition { get; set; }
        public int PhysicianSSN { get; set; }
        public string Departments { get; set; }       
    }

    


}