using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IPC.Models.IPCEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
#nullable disable

namespace IPC.Data
{
    public partial class IPCContext : IdentityDbContext
    {
        private static IConfiguration Configuration;

        public IPCContext(DbContextOptions<IPCContext> options)
            : base(options)
        {
        }

        public void Getcon (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual DbSet<AllergyType> AllergyTypes { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<Allergies> Allergies { get; set; }
        public virtual DbSet<Constitutional> Constitutionals { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorWorksFor> DoctorWorksFors { get; set; }
        public virtual DbSet<DrugsList> DrugsLists { get; set; }
        public virtual DbSet<Enmt> Enmts { get; set; }
        public virtual DbSet<EnmtType> EnmtTypes { get; set; }
        public virtual DbSet<Eye> Eyes { get; set; }
        public virtual DbSet<FollowUp> FollowUps { get; set; }
        public virtual DbSet<HistoryType> HistoryTypes { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<LabReport> LabReports { get; set; }
        public virtual DbSet<LabTest> LabTests { get; set; }
        public virtual DbSet<MedicalHistory> MedicalHistories { get; set; }
        public virtual DbSet<MedicationHistory> MedicationHistories { get; set; }
        public virtual DbSet<MedicationType> MedicationTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientEmergencyDetail> PatientEmergencyDetails { get; set; }
        public virtual DbSet<PhysicalExam> PhysicalExams { get; set; }
        public virtual DbSet<PhysicalExamSubLevelType> PhysicalExamSubLevelTypes { get; set; }
        public virtual DbSet<PhysicalExamSubType> PhysicalExamSubTypes { get; set; }
        public virtual DbSet<PhysicalExamSubType1> PhysicalExamSubTypes1 { get; set; }
        public virtual DbSet<PhysicalExamType> PhysicalExamTypes { get; set; }
        public virtual DbSet<PresentIllness> PresentIllnesses { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<ReviewOfSystem> ReviewOfSystems { get; set; }
        public virtual DbSet<ReviewOfSystemType> ReviewOfSystemTypes { get; set; }
        public virtual DbSet<RosType> RosTypes { get; set; }
        public virtual DbSet<SocialHistory> SocialHistories { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Surgery> Surgeries { get; set; }
        public virtual DbSet<SurgeryHistory> SurgeryHistories { get; set; }
        public virtual DbSet<TblFile> TblFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vital> Vitals { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=BUSHAAN-TMU5UGH;Initial Catalog=IPC;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AllergyType>(entity =>
            {
                entity.Property(e => e.AllergyCode).IsFixedLength(true);
            });

            modelBuilder.Entity<Constitutional>(entity =>
            {
                entity.HasOne(d => d.TypeCodeNavigation)
                    .WithMany(p => p.Constitutionals)
                    .HasForeignKey(d => d.TypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Constitutional_ENMT_Types");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.SpecialityCode).IsFixedLength(true);

                entity.Property(e => e.Tp).IsFixedLength(true);

                entity.HasOne(d => d.SpecialityCodeNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Specialization");
            });

            modelBuilder.Entity<FollowUp>(entity =>
            {
                entity.Property(e => e.AppCall).IsFixedLength(true);

                entity.Property(e => e.FollMa).IsFixedLength(true);
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.Tp).IsFixedLength(true);
            });

            modelBuilder.Entity<MedicationHistory>(entity =>
            {
                entity.Property(e => e.Dose).IsFixedLength(true);

                entity.Property(e => e.Freq).IsFixedLength(true);

                entity.HasOne(d => d.MedCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MedCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medication_history_Medication_type");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medication_history_Patient");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Bloodgrp).IsFixedLength(true);

                entity.Property(e => e.Gender).IsFixedLength(true);

                entity.Property(e => e.Nic).IsFixedLength(true);

                entity.Property(e => e.Tp).IsFixedLength(true);
            });

            modelBuilder.Entity<PatientEmergencyDetail>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__PatientE__4D5CE4766B608DC3");
            });

            modelBuilder.Entity<PhysicalExam>(entity =>
            {
                entity.Property(e => e.PhysicalCode).IsUnicode(false);
            });

            modelBuilder.Entity<PhysicalExamSubLevelType>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.Subcode });

                entity.Property(e => e.Code).IsUnicode(false);

                entity.HasOne(d => d.CodeNavigation)
                    .WithMany(p => p.PhysicalExamSubLevelTypes)
                    .HasForeignKey(d => d.Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicalExam_Sub_Level_Types_PhysicalExam_SubTypes");
            });

            modelBuilder.Entity<PhysicalExamSubType>(entity =>
            {
                entity.HasKey(e => e.Subcode)
                    .HasName("PK_PhysicalExam_Sub_Types_1");

                entity.HasOne(d => d.ExamTypeNavigation)
                    .WithMany(p => p.PhysicalExamSubTypes)
                    .HasForeignKey(d => d.ExamType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicalExam_Sub_Types_PhysicalExam_Types");
            });

            modelBuilder.Entity<PhysicalExamSubType1>(entity =>
            {
                entity.Property(e => e.Subcode).IsUnicode(false);

                entity.HasOne(d => d.ExamTypeNavigation)
                    .WithMany(p => p.PhysicalExamSubType1s)
                    .HasForeignKey(d => d.ExamType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhysicalExam_SubTypes_PhysicalExam_Types");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecialityCode).IsFixedLength(true);
            });

            modelBuilder.Entity<SurgeryHistory>(entity =>
            {
                entity.HasOne(d => d.Doc)
                    .WithMany()
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_history_Doctor1");

                entity.HasOne(d => d.Hospital)
                    .WithMany()
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_history_Hospital");

                entity.HasOne(d => d.Patient)
                    .WithMany()
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_history_Patient");

                entity.HasOne(d => d.SurgicalCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SurgicalCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surgery_history_Surgery");
            });

            modelBuilder.Entity<TblFile>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Vital>(entity =>
            {
                entity.Property(e => e.Bloodpressure).IsFixedLength(true);

                entity.Property(e => e.Height).IsFixedLength(true);

                entity.Property(e => e.Po2).IsFixedLength(true);

                entity.Property(e => e.Pulse).IsFixedLength(true);

                entity.Property(e => e.Temp).IsFixedLength(true);

                entity.Property(e => e.Weight).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
