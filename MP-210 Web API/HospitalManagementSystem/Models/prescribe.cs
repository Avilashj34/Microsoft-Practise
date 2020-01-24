namespace HospitalManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prescribe
    {
        [Key]
        public int PrescribesId { get; set; }

        public int PhysicianId { get; set; }

        public int PatientSSN { get; set; }

        public int Code { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] PrescribesDate { get; set; }

        public int AppointmentId { get; set; }

        public string PrescribesDose { get; set; }

        public string PrescribesNote { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Medication Medication { get; set; }

        public virtual Patient patient { get; set; }

        public virtual Physician physician { get; set; }
    }
}
