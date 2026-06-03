using Microsoft.EntityFrameworkCore;
using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext() { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<MedicalNote> MedicalNotes { get; set; }
        public virtual DbSet<ChildMedicalNote> ChildMedicalNotes { get; set; }
        public virtual DbSet<CampType> CampTypes { get; set; }
        public virtual DbSet<Camp> Camps { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatuses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CampAgencyDB;Integrated Security=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Login).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Login).IsUnique();
                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
                entity.Property(e => e.FullName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.HasOne(d => d.UserRole).WithMany(p => p.Users).HasForeignKey(d => d.UserRoleId).OnDelete(DeleteBehavior.Restrict);
            });

            // UserRole
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);
                entity.Property(e => e.RoleName).HasMaxLength(50).IsRequired();
            });

            // Child
            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasKey(e => e.ChildId);
                entity.Property(e => e.FullName).HasMaxLength(100).IsRequired();
                entity.HasOne(d => d.User).WithMany(p => p.Children).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Gender).WithMany(p => p.Children).HasForeignKey(d => d.GenderId).OnDelete(DeleteBehavior.Restrict);
            });

            // Gender
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId);
                entity.Property(e => e.GenderName).HasMaxLength(20).IsRequired();
            });

            // MedicalNote
            modelBuilder.Entity<MedicalNote>(entity =>
            {
                entity.HasKey(e => e.MedicalNoteId);
                entity.Property(e => e.MedicalNoteName).HasMaxLength(200).IsRequired();
            });

            // ChildMedicalNote
            modelBuilder.Entity<ChildMedicalNote>(entity =>
            {
                entity.HasKey(e => e.ChildMedicalNoteId);
                entity.HasOne(d => d.MedicalNote).WithMany(p => p.ChildMedicalNotes).HasForeignKey(d => d.MedicalNoteId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Child).WithMany(p => p.ChildMedicalNotes).HasForeignKey(d => d.ChildId).OnDelete(DeleteBehavior.Cascade);
            });

            // CampType
            modelBuilder.Entity<CampType>(entity =>
            {
                entity.HasKey(e => e.CampTypeId);
                entity.Property(e => e.CampTypeName).HasMaxLength(100).IsRequired();
            });

            // Camp
            modelBuilder.Entity<Camp>(entity =>
            {
                entity.HasKey(e => e.CampId);
                entity.Property(e => e.CampName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Region).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.ContactPhone).HasMaxLength(20);
                entity.Property(e => e.Rating).HasColumnType("decimal(3,2)");
                entity.HasOne(d => d.CampType).WithMany(p => p.Camps).HasForeignKey(d => d.CampTypeId).OnDelete(DeleteBehavior.Restrict);
            });

            // Shift
            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => e.ShiftId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Camp).WithMany(p => p.Shifts).HasForeignKey(d => d.CampId).OnDelete(DeleteBehavior.Cascade);
            });

            // DocumentType
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.DocumentTypeId);
                entity.Property(e => e.DocumentTypeName).HasMaxLength(100).IsRequired();
            });

            // DocumentStatus
            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.HasKey(e => e.DocumentStatusId);
                entity.Property(e => e.DocumentStatusName).HasMaxLength(50).IsRequired();
            });

            // Document
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocumentId);
                entity.Property(e => e.FilePath).HasMaxLength(255);
                entity.Property(e => e.TimeStamp).HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Child).WithMany(p => p.Documents).HasForeignKey(d => d.ChildId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents).HasForeignKey(d => d.DocumentTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.DocumentStatus).WithMany(p => p.Documents).HasForeignKey(d => d.DocumentStatusId).OnDelete(DeleteBehavior.Restrict);
            });

            // BookingStatus
            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.HasKey(e => e.BookingStatusId);
                entity.Property(e => e.BookingStatusName).HasMaxLength(50).IsRequired();
            });

            // PaymentType
            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);
                entity.Property(e => e.PaymentTypeName).HasMaxLength(50).IsRequired();
            });

            // PaymentStatus
            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusId);
                entity.Property(e => e.PaymentStatusName).HasMaxLength(50).IsRequired();
            });

            // Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TimeStamp).HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Booking).WithMany(p => p.Payments).HasForeignKey(d => d.BookingId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.PaymentType).WithMany(p => p.Payments).HasForeignKey(d => d.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Payments).HasForeignKey(d => d.PaymentStatusId).OnDelete(DeleteBehavior.Restrict);
            });

            // Booking
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(d => d.Child).WithMany(p => p.Bookings).HasForeignKey(d => d.ChildId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Shift).WithMany(p => p.Bookings).HasForeignKey(d => d.ShiftId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.BookingStatus).WithMany(p => p.Bookings).HasForeignKey(d => d.BookingStatusId).OnDelete(DeleteBehavior.Restrict);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}