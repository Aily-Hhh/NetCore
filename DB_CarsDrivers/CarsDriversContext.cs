using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB_CarsDrivers
{
    public partial class CarsDriversContext : DbContext
    {
        public CarsDriversContext()
        {
        }

        public CarsDriversContext(DbContextOptions<CarsDriversContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarDriver> CarDrivers { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Viewcars20052007> Viewcars20052007s { get; set; } = null!;
        public virtual DbSet<Viewdriver> Viewdrivers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("host=localhost;port=3306;database=CarsDrivers;username=root;password=1183462", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.NumberCar)
                    .HasName("PRIMARY");

                entity.ToTable("cars");

                entity.Property(e => e.NumberCar).HasMaxLength(15);

                entity.Property(e => e.Brand).HasMaxLength(30);

                entity.Property(e => e.Color).HasMaxLength(60);

                entity.Property(e => e.Model).HasMaxLength(30);

                entity.Property(e => e.Vin)
                    .HasMaxLength(25)
                    .HasColumnName("VIN");

                entity.Property(e => e.YearOfRelease).HasColumnType("year");
            });

            modelBuilder.Entity<CarDriver>(entity =>
            {
                entity.HasKey(e => e.NumberCd)
                    .HasName("PRIMARY");

                entity.ToTable("car_driver");

                entity.HasIndex(e => e.NumberCar, "NumberCar");

                entity.HasIndex(e => e.NumberDrCertificate, "NumberDrCertificate");

                entity.Property(e => e.NumberCd).HasColumnName("NumberCD");

                entity.Property(e => e.NumberCar).HasMaxLength(15);

                entity.Property(e => e.NumberDrCertificate).HasMaxLength(20);

                entity.HasOne(d => d.NumberCarNavigation)
                    .WithMany(p => p.CarDrivers)
                    .HasForeignKey(d => d.NumberCar)
                    .HasConstraintName("car_driver_ibfk_1");

                entity.HasOne(d => d.NumberDrCertificateNavigation)
                    .WithMany(p => p.CarDrivers)
                    .HasForeignKey(d => d.NumberDrCertificate)
                    .HasConstraintName("car_driver_ibfk_2");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.NumberDrCertificate)
                    .HasName("PRIMARY");

                entity.ToTable("drivers");

                entity.Property(e => e.NumberDrCertificate).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Viewcars20052007>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewcars2005_2007");

                entity.Property(e => e.Brand).HasMaxLength(30);

                entity.Property(e => e.Color).HasMaxLength(60);

                entity.Property(e => e.Model).HasMaxLength(30);

                entity.Property(e => e.YearOfRelease).HasColumnType("year");
            });

            modelBuilder.Entity<Viewdriver>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viewdrivers");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.NumberDrCertificate).HasMaxLength(20);

                entity.Property(e => e.Patronymic).HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
