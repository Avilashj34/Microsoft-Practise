namespace HospitalManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Affilated_with
    {
        [Key]
        public int AffilatedId { get; set; }

        public int PhysicianId { get; set; }

        public int DepartmentId { get; set; }

        public bool PrimaryAffiliation { get; set; }

        public virtual Department Department { get; set; }

        public virtual Physician physician { get; set; }
    }
}
