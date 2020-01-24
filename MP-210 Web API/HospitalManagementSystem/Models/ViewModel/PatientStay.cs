using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models.ViewModel
{
    public class PatientStay
    {
        public Patient patient { get; set; }
        public Stay stay { get; set; }
    }
}