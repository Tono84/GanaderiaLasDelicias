using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GanaderiaLasDelicias.Models
{
    public partial class SGGContext : DbContext
    {
        public SGGContext()
        {
        }

        public SGGContext(DbContextOptions<SGGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Bull> Bulls { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeePayment> EmployeePayments { get; set; } = null!;
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; } = null!;
        public virtual DbSet<EventLog> EventLogs { get; set; } = null!;
        public virtual DbSet<Feeding> Feedings { get; set; } = null!;
        public virtual DbSet<HealthRecord> HealthRecords { get; set; } = null!;
        public virtual DbSet<Herd> Herds { get; set; } = null!;
        public virtual DbSet<MedHistory> MedHistories { get; set; } = null!;
        public virtual DbSet<Milking> Milkings { get; set; } = null!;
        public virtual DbSet<Nutrition> Nutritions { get; set; } = null!;
        public virtual DbSet<NutritionHistory> NutritionHistories { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Pregnancy> Pregnancies { get; set; } = null!;
        public virtual DbSet<Treatment> Treatments { get; set; } = null!;

        public virtual DbSet<Schedule> Schedules { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=SGG;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Bull>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.SemenCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.AspNetUserId).HasMaxLength(450);

                entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NatId).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AspNetUserId)
                    .HasConstraintName("FK__Employee__AspNet__09A971A2");
            });

            modelBuilder.Entity<EmployeePayment>(entity =>
            {
                entity.ToTable("EmployeePayment");

                entity.Property(e => e.NetPay).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Emplo__0E6E26BF");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.EmployeePayments)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Payme__0F624AF8");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.HasKey(e => e.ErrorId)
                    .HasName("PK__ErrorLog__35856A2AB08BABF2");

                entity.ToTable("ErrorLog");

                entity.Property(e => e.AspNetUserId).HasMaxLength(450);

                entity.Property(e => e.ErrorDescription).HasMaxLength(255);

                entity.Property(e => e.ErrorMessage).HasMaxLength(255);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.ErrorLogs)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ErrorLog__AspNet__236943A5");
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EventLog__7944C810BB19E337");

                entity.ToTable("EventLog");

                entity.Property(e => e.AspNetUserId).HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EventDescription).HasMaxLength(255);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.EventLogs)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventLog__AspNet__2645B050");
            });

            modelBuilder.Entity<Feeding>(entity =>
            {
                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.Feedings)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COW");
            });

            modelBuilder.Entity<HealthRecord>(entity =>
            {
                entity.ToTable("HealthRecord");

                entity.Property(e => e.CheckupDate).HasColumnType("date");

                entity.Property(e => e.DiagnosisDate).HasColumnType("date");

                entity.Property(e => e.Dose).HasMaxLength(50);

                entity.Property(e => e.Frequency).HasMaxLength(50);

                entity.Property(e => e.HealthStatus).HasMaxLength(50);

                entity.Property(e => e.PrescribedMedication).HasMaxLength(50);

                entity.Property(e => e.StateChangeDate).HasColumnType("date");

                entity.Property(e => e.Treatment).HasMaxLength(50);

                entity.Property(e => e.VaccinationDate).HasColumnType("date");

                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.HealthRecords)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HealthRec__CowId__32AB8735");
            });

            modelBuilder.Entity<Herd>(entity =>
            {
                entity.HasKey(e => e.CowId)
                    .HasName("PK__Herd__E32F87086F973A68");

                entity.ToTable("Herd");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Race).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MedHistory>(entity =>
            {
                entity.ToTable("MedHistory");

                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.MedHistories)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedHistor__CowId__160F4887");

                entity.HasOne(d => d.Treatment)
                    .WithMany(p => p.MedHistories)
                    .HasForeignKey(d => d.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedHistor__Treat__17036CC0");
            });

            modelBuilder.Entity<Milking>(entity =>
            {
                entity.ToTable("Milking");

                entity.Property(e => e.FatContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LactoseContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MilkVolume).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MilkingDate).HasColumnType("date");

                entity.Property(e => e.ProteinContent).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.Milkings)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Milking__CowId__1F98B2C1");

                entity.HasOne(d => d.Milker)
                    .WithMany(p => p.Milkings)
                    .HasForeignKey(d => d.MilkerId)
                    .HasConstraintName("FK__Milking__MilkerI__208CD6FA");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.HasKey(e => e.NutritionPlanId)
                    .HasName("PK__Nutritio__013DA37D62C79602");

                entity.ToTable("Nutrition");

                entity.Property(e => e.Carbs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Minerals).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Protein).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Supplement).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Vitamins).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Water).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.Nutritions)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nutrition__CowId__19DFD96B");
            });

            modelBuilder.Entity<NutritionHistory>(entity =>
            {
                entity.HasKey(e => e.NutritionHisId)
                    .HasName("PK__Nutritio__FF29FA84A37B7EF8");

                entity.ToTable("NutritionHistory");

                entity.Property(e => e.DailyCarbs).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DailyMinerals).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DailyProtein).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DailySupplement).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DailyVitamins).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DailyWater).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.NutritionPlan)
                    .WithMany(p => p.NutritionHistories)
                    .HasForeignKey(d => d.NutritionPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nutrition__Nutri__1CBC4616");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayId)
                    .HasName("PK__Payment__EE8FCECFB2A3D467");

                entity.ToTable("Payment");

                entity.Property(e => e.Ccss)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("CCSS");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pregnancy>(entity =>
            {
                entity.ToTable("Pregnancy");

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.PregDate).HasColumnType("date");

                entity.HasOne(d => d.Bull)
                    .WithMany(p => p.Pregnancies)
                    .HasForeignKey(d => d.BullId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pregnancy__BullI__367C1819");

                entity.HasOne(d => d.Cow)
                    .WithMany(p => p.Pregnancies)
                    .HasForeignKey(d => d.CowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pregnancy__CowId__3587F3E0");
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatment");

                entity.Property(e => e.Dosis).HasMaxLength(50);

                entity.Property(e => e.Frequency).HasMaxLength(50);

                entity.Property(e => e.MedName).HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();

                entity.Property(e => e.WorkDays).HasMaxLength(50).IsRequired();

                entity.Property(e => e.OffDays).HasMaxLength(50).IsRequired();

                entity.Property(e => e.WorkHours).HasMaxLength(50).IsRequired();

                entity.Property(e => e.ShiftType).IsRequired();

                entity.Property(e => e.IsActive).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
