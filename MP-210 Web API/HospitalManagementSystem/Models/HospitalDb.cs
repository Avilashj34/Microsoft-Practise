namespace HospitalManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HospitalDb : DbContext
    {
        public HospitalDb()
            : base("name=HospitalDb")
        {
        }

        public virtual DbSet<Affilated_with> Affilated_with { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Block> blocks { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<nurse> nurses { get; set; }
        public virtual DbSet<on_call> on_call { get; set; }
        public virtual DbSet<Patient> patients { get; set; }
        public virtual DbSet<Physician> physicians { get; set; }
        public virtual DbSet<Prescribe> prescribes { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Stay> Stays { get; set; }
        public virtual DbSet<Undergo> Undergoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasMany(e => e.prescribes)
                .WithRequired(e => e.Appointment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medication>()
                .HasMany(e => e.prescribes)
                .WithRequired(e => e.Medication)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nurse>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.nurse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<nurse>()
                .HasMany(e => e.on_call)
                .WithOptional(e => e.nurse)
                .HasForeignKey(e => e.NurseId_NurseId);

            modelBuilder.Entity<nurse>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.nurse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<on_call>()
                .Property(e => e.OnCallStart)
                .IsFixedLength();

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.prescribes)
                .WithRequired(e => e.patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Stays)
                .WithRequired(e => e.patient)
                .HasForeignKey(e => e.PatientSSN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.prescribes)
                .WithRequired(e => e.physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Physician>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.physician)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prescribe>()
                .Property(e => e.PrescribesDate)
                .IsFixedLength();

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Procedure)
                .HasForeignKey(e => e.ProcedureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Stays)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stay>()
                .Property(e => e.Start_Time)
                .IsFixedLength();

            modelBuilder.Entity<Stay>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.Stay)
                .HasForeignKey(e => e.Stay_StayId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stay>()
                .HasMany(e => e.Undergoes)
                .WithRequired(e => e.Stay)
                .WillCascadeOnDelete(false);
        }
    }
}
