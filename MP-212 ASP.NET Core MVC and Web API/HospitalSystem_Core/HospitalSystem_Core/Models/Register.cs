using System;
using System.Collections.Generic;

namespace HospitalSystem_Core.Models
{
    public partial class Register
    {
        public Register()
        {
            Login = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? UserVerified { get; set; }
        public DateTime? Created { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
