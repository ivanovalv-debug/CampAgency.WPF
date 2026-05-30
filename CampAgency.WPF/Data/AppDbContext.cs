using System;
using System.Collections.Generic;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace CampAgency.WPF.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Camp> Camps { get; set; }
    public virtual DbSet<Child> Children { get; set; }
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Shift> Shifts { get; set; }
    public virtual DbSet<User> Users { get; set; }

    // ❌ ЗАКОММЕНТИРУЙТЕ ИЛИ УДАЛИТЕ ЭТОТ МЕТОД
    // Конфигурация теперь осуществляется через IDbContextFactory в App.xaml.cs
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CampAgencyDB;Integrated Security=true;TrustServerCertificate=True");
        }
    }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC07124DBFEB");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Child).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK__Bookings__ChildI__440B1D61");

            entity.HasOne(d => d.Shift).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__Bookings__ShiftI__44FF419A");
        });

        modelBuilder.Entity<Camp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Camps__3214EC073B7D5D5E");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Rating).HasDefaultValueSql("((0.0))");
            entity.Property(e => e.Region).HasMaxLength(100);
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Children__3214EC0738155DAF");
            entity.Property(e => e.FullName).HasMaxLength(100);

            entity.HasOne(d => d.Parent).WithMany(p => p.Children)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Children__Parent__3A81B327");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC077BE3F47F");
            entity.Property(e => e.FilePath).HasMaxLength(255);

            entity.HasOne(d => d.Booking).WithMany(p => p.Documents)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Documents__Booki__47DBAE45");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shifts__3214EC07D9ABE519");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Camp).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.CampId)
                .HasConstraintName("FK__Shifts__CampId__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E4507711");
            entity.HasIndex(e => e.Login, "UQ__Users__5E55825BB45E28D1").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}