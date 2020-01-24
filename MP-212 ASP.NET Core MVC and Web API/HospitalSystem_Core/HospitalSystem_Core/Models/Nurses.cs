﻿using System;
using System.Collections.Generic;

namespace HospitalSystem_Core.Models
{
    public partial class Nurses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime? Created { get; set; }
    }
}
