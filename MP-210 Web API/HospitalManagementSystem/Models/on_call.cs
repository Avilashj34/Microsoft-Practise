namespace HospitalManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class on_call
    {
        [Key]
        public int OnCallId { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] OnCallStart { get; set; }

        public int? NurseId_NurseId { get; set; }

        public virtual nurse nurse { get; set; }
    }
}
