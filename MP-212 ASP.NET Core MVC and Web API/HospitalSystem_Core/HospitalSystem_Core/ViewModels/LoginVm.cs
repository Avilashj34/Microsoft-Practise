using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem_Core.ViewModels
{
    public class LoginVm
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password,ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
