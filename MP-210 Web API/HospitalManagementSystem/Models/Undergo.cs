namespace HospitalManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Undergo
    {
        [Key]
        public int UndergoesId { get; set; }

        public int PatientSSN { get; set; }

        public int ProcedureId { get; set; }

        public int StayId { get; set; }

        public int PhysicianId { get; set; }

        public int NurseId { get; set; }

        public string Note { get; set; }

        public virtual nurse nurse { get; set; }

        public virtual Patient patient { get; set; }

        public virtual Physician physician { get; set; }

        public virtual Procedure Procedure { get; set; }

        public virtual Stay Stay { get; set; }
    }
}
