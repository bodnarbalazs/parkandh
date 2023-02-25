using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KHBackend.Models;

public partial class ParkContext : DbContext
{
    public ParkContext()
    {
    }

    public ParkContext(DbContextOptions<ParkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarPool> CarPools { get; set; }

    public virtual DbSet<CarPoolMember> CarPoolMembers { get; set; }

    public virtual DbSet<CarPoolRequest> CarPoolRequests { get; set; }

    public virtual DbSet<ParkRequest> ParkRequests { get; set; }

    public virtual DbSet<ParkingReservation> ParkingReservations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=khdataserver.database.windows.net;Initial Catalog=ParkHData;User ID=balazsbodnar;Password=KdtDon5M2001spy");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarPool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__car_pool__3213E83F25BDD0E8");

            entity.ToTable("car_pool");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Limit).HasColumnName("limit");

            entity.HasOne(d => d.Driver).WithMany(p => p.CarPools)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk");
        });

        modelBuilder.Entity<CarPoolMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("car_pool_members");

            entity.Property(e => e.CarPoolId).HasColumnName("car_pool_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CarPool).WithMany()
                .HasForeignKey(d => d.CarPoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk2");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk1");
        });

        modelBuilder.Entity<CarPoolRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("car_pool_requests");

            entity.Property(e => e.CarPoolId).HasColumnName("car_pool_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CarPool).WithMany()
                .HasForeignKey(d => d.CarPoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk4");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk3");
        });

        modelBuilder.Entity<ParkRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__park_req__3213E83F12BB53D3");

            entity.ToTable("park_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ParkRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk8");
        });

        modelBuilder.Entity<ParkingReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parking___3213E83FD1CD35F5");

            entity.ToTable("parking_reservations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("from_date");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Surrogated).HasColumnName("surrogated");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("to_date");

            entity.HasOne(d => d.Owner).WithMany(p => p.ParkingReservationOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("fk6");

            entity.HasOne(d => d.SurrogatedNavigation).WithMany(p => p.ParkingReservationSurrogatedNavigations)
                .HasForeignKey(d => d.Surrogated)
                .HasConstraintName("fk7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FAE0CFE0E");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coin).HasColumnName("coin");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("home_address");
            entity.Property(e => e.LastName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PrivateParking)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("private_parking");
            entity.Property(e => e.UserSettings)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_settings");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
