using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem_Core.ViewModels
{
    public class RegisterVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[0-9]",ErrorMessage ="Enter Number ")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"[0-9]", ErrorMessage = "Otp is required ")]
        public string OTP { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@@$!%*?&])[A-Za-z\d@@$!%*?&]{8,}$", ErrorMessage ="Password should contain letter, Number and special character")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
