using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.EFCoreDbContext
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllergyPatient>()
                .HasOne(a=>a.Patient)
                .WithMany(b=>b.AllergyPatients)
                .HasForeignKey(c=>c.PatientId);
            modelBuilder.Entity<AllergyPatient>()
                .HasOne(a=>a.Allergy)
                .WithMany(b=>b.AllergyPatients)
                .HasForeignKey(c=>c.AllergiyId);

            modelBuilder.Entity<DoctorLanguage>()
                .HasOne(a=>a.Doctor)
                .WithMany(b=>b.DoctorLanguages)
                .HasForeignKey(c=>c.DoctorId);
            modelBuilder.Entity<DoctorLanguage>()
                .HasOne(a=>a.Language)
                .WithMany(b=>b.DoctorLanguages)
                .HasForeignKey(c=>c.LanguageId);

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(a=>a.Doctor)
                .WithMany(b=>b.DoctorSpecialties)
                .HasForeignKey(c=>c.DoctorId);
            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(a=>a.Specialty)
                .WithMany(b=>b.DoctorSpecialties)
                .HasForeignKey(c=>c.SpecialtyId);

            modelBuilder.Entity<DrugPrescription>()
                .HasOne(a=>a.Drug)
                .WithMany(b=>b.DrugPrescriptions)
                .HasForeignKey(c=>c.DrugId);
            modelBuilder.Entity<DrugPrescription>()
                .HasOne(a=>a.Prescription)
                .WithMany(b=>b.DrugPrescriptions)
                .HasForeignKey(c=>c.PrescriptionId);

            modelBuilder.Entity<LanguageNurse>()
                .HasOne(a=>a.Nurse)
                .WithMany(b=>b.LanguageNurses)
                .HasForeignKey(c=>c.NurseId);
            modelBuilder.Entity<LanguageNurse>()
                .HasOne(a=>a.Language)
                .WithMany(b=>b.LanguageNurses)
                .HasForeignKey(c=>c.LanguageId);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Drug>Drugs { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<AllergyPatient> AllergyPatients { get; set; }
        public DbSet<DoctorLanguage> DoctorLanguages { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<DrugPrescription> DrugPrescriptions { get; set; }
        public DbSet<LanguageNurse> LanguageNurses { get; set; }
    }
}
