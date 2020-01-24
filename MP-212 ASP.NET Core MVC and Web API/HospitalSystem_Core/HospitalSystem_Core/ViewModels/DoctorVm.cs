using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem_Core.ViewModels
{
    public class DoctorVm
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is Required")]
        
        public string Gender { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Specialist is Required")]
        [DataType(DataType.Text)]
        public string Specialist { get; set; }
    }
}
