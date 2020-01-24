namespace HospitalManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Appointment()
        {
            prescribes = new HashSet<Prescribe>();
        }

        public int AppointmentId { get; set; }

        public int Patientssn { get; set; }

        public int PhysicianId { get; set; }

        public int NurseId { get; set; }

        public DateTime? Start_Time { get; set; }

        public DateTime? End_Time { get; set; }

        public virtual nurse nurse { get; set; }

        public virtual Patient patient { get; set; }

        public virtual Physician physician { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescribe> prescribes { get; set; }
    }
}
