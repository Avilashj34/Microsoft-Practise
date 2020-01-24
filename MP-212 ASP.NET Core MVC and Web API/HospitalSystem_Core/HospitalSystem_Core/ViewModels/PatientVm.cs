using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem_Core.ViewModels
{
    public class PatientVm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "HealthCondition is Required")]
        public string HealthCondition { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
    }
}
