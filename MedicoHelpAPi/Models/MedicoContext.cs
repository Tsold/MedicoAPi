using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MedicoHelpAPi.Models
{
    public partial class MedicoContext : DbContext
    {
        public MedicoContext()
        {
        }

        public MedicoContext(DbContextOptions<MedicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<ClinicalService> ClinicalService { get; set; }
        public virtual DbSet<MedicalService> MedicalService { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WeekDays> WeekDays { get; set; }
        public virtual DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SqlConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("PK__Category__1AA1EC66D932200D");

                entity.Property(e => e.Idcategory)
                    .HasColumnName("IDCategory")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient)
                    .HasName("PK__Client__CDECAB2C49DBF8F5");

                entity.Property(e => e.Idclient)
                    .HasColumnName("IDClient")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__UserID__29572725");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.Idclinic)
                    .HasName("PK__Clinic__C47E9FB227FC1026");

                entity.Property(e => e.Idclinic)
                    .HasColumnName("IDClinic")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clinic__UserID__2C3393D0");
            });

            modelBuilder.Entity<ClinicalService>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("PK__Clinical__5049E73A63D36D0E");

                entity.Property(e => e.Idservice)
                    .HasColumnName("IDService")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idclinic).HasColumnName("IDClinic");

                entity.Property(e => e.MedicalServiceId).HasColumnName("MedicalServiceID");

                entity.Property(e => e.Preparation).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdclinicNavigation)
                    .WithMany(p => p.ClinicalService)
                    .HasForeignKey(d => d.Idclinic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClinicalS__IDCli__3A81B327");

                entity.HasOne(d => d.MedicalService)
                    .WithMany(p => p.ClinicalService)
                    .HasForeignKey(d => d.MedicalServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClinicalS__Medic__3B75D760");
            });

            modelBuilder.Entity<MedicalService>(entity =>
            {
                entity.HasKey(e => e.IdmedicalService)
                    .HasName("PK__MedicalS__CB9515A821B729AD");

                entity.Property(e => e.IdmedicalService)
                    .HasColumnName("IDMedicalService")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.MedicalService)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedicalSe__Subca__37A5467C");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.Idmeeting)
                    .HasName("PK__Meeting__4D42C9E38AE6661A");

                entity.Property(e => e.Idmeeting)
                    .HasColumnName("IDMeeting")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datefrom).HasColumnType("datetime");

                entity.Property(e => e.Dateto).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meeting__Service__656C112C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meeting)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Meeting__UserID__66603565");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Idrole)
                    .HasName("PK__Roles__A1BA16C469B3A327");

                entity.Property(e => e.Idrole)
                    .HasColumnName("IDRole")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.Idsubcategory)
                    .HasName("PK__Subcateg__49059B4674883CCC");

                entity.Property(e => e.Idsubcategory)
                    .HasColumnName("IDSubcategory")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.SubcategoryName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subcatego__Categ__30F848ED");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK__Users__EAE6D9DF98834E36");

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUser")
                    .HasMaxLength(128);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleID__267ABA7A");
            });

            modelBuilder.Entity<WeekDays>(entity =>
            {
                entity.HasKey(e => e.IdweekDays)
                    .HasName("PK__WeekDays__3C56FB41907893DB");

                entity.Property(e => e.IdweekDays)
                    .HasColumnName("IDWeekDays")
                    .ValueGeneratedNever();

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkingHours>(entity =>
            {
                entity.HasKey(e => e.IdavailableTimeFrame)
                    .HasName("PK__WorkingH__46B80DA66C94EAD1");

                entity.Property(e => e.IdavailableTimeFrame)
                    .HasColumnName("IDAvailableTimeFrame")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datefrom).HasColumnType("datetime");

                entity.Property(e => e.Dateto).HasColumnType("datetime");

                entity.Property(e => e.Idclinic).HasColumnName("IDClinic");

                entity.Property(e => e.WeekDayId).HasColumnName("WeekDayID");

                entity.HasOne(d => d.IdclinicNavigation)
                    .WithMany(p => p.WorkingHours)
                    .HasForeignKey(d => d.Idclinic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkingHo__IDCli__619B8048");

                entity.HasOne(d => d.WeekDay)
                    .WithMany(p => p.WorkingHours)
                    .HasForeignKey(d => d.WeekDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkingHo__WeekD__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
