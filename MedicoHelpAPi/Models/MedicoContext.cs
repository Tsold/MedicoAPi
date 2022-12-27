﻿using System;
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
        public virtual DbSet<MedicalService> MedicalService { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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
                    .HasName("PK__Category__1AA1EC66892E9EA2");

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
                    .HasName("PK__Client__CDECAB2C7CF35A94");

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

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__UserID__3B75D760");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.Idclinic)
                    .HasName("PK__Clinic__C47E9FB25A475B55");

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

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clinic__UserID__3E52440B");
            });

            modelBuilder.Entity<MedicalService>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("PK__MedicalS__5049E73A1553CD97");

                entity.Property(e => e.Idservice)
                    .HasColumnName("IDService")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idclinic).HasColumnName("IDClinic");

                entity.Property(e => e.Preparation).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.ShortDes)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SubcategoryId).HasColumnName("SubcategoryID");

                entity.HasOne(d => d.IdclinicNavigation)
                    .WithMany(p => p.MedicalService)
                    .HasForeignKey(d => d.Idclinic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedicalSe__IDCli__45F365D3");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.MedicalService)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MedicalSe__Subca__46E78A0C");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Idrole)
                    .HasName("PK__Roles__A1BA16C48F8C6FF5");

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
                    .HasName("PK__Subcateg__49059B46B964A788");

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
                    .HasConstraintName("FK__Subcatego__Categ__4316F928");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK__Users__EAE6D9DF51A234A9");

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUser")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleID__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
