using System;
using System.Collections.Generic;

namespace HospitalSystem_Core.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public DateTime? LastLoginDetail { get; set; }
        public string Phone { get; set; }

        public virtual Register PhoneNavigation { get; set; }
    }
}
