# CampAgency.WPF - Project Documentation

## Content

1. [CampAgency.WPF](#campagency)
   1. [App.xaml](#app)
   2. [App.xaml.cs](#appxaml)
   3. [AssemblyInfo.cs](#assemblyinfo)
   4. [CampAgency.WPF.csproj](#campagencywpf)
   5. [MainWindow.xaml](#mainwindow)
   6. [MainWindow.xaml.cs](#mainwindowxaml)
2. [CampAgency.WPF\Data](#data)
   1. [AppDbContext.cs](#appdbcontext)
3. [CampAgency.WPF\Migrations](#migrations)
   1. [20260603135705_rebaseDatabase.cs](#20260603135705rebasedatabase)
   2. [20260603135705_rebaseDatabase.Designer.cs](#20260603135705rebasedatabasedesigner)
   3. [AppDbContextModelSnapshot.cs](#appdbcontextmodelsnapshot)
4. [CampAgency.WPF\Models\Entities](#entities)
   1. [Booking.cs](#booking)
   2. [BookingStatus.cs](#bookingstatus)
   3. [Camp.cs](#camp)
   4. [CampType.cs](#camptype)
   5. [Child.cs](#child)
   6. [ChildMedicalNote.cs](#childmedicalnote)
   7. [Document.cs](#document)
   8. [DocumentStatus.cs](#documentstatus)
   9. [DocumentType.cs](#documenttype)
   10. [Gender.cs](#gender)
   11. [MedicalNote.cs](#medicalnote)
   12. [Payment.cs](#payment)
   13. [PaymentStatus.cs](#paymentstatus)
   14. [PaymentType.cs](#paymenttype)
   15. [Shift.cs](#shift)
   16. [User.cs](#user)
   17. [UserRole.cs](#userrole)
5. [CampAgency.WPF\Services](#services)
   1. [AuthService.cs](#authservice)
   2. [IAuthService.cs](#iauthservice)
   3. [INavigationService.cs](#inavigationservice)
   4. [IRegistrationService.cs](#iregistrationservice)
   5. [NavigationService.cs](#navigationservice)
   6. [RegistrationService.cs](#registrationservice)
6. [CampAgency.WPF\ViewModels](#viewmodels)
   1. [MainWindowViewModel.cs](#mainwindowviewmodel)
7. [CampAgency.WPF\ViewModels\Admin](#admin)
   1. [AdminDashboardViewModel.cs](#admindashboardviewmodel)
   2. [CampEditViewModel.cs](#campeditviewmodel)
   3. [CampsListViewModel.cs](#campslistviewmodel)
8. [CampAgency.WPF\ViewModels\Auth](#auth)
   1. [LoginViewModel.cs](#loginviewmodel)
   2. [RegisterViewModel.cs](#registerviewmodel)
9. [CampAgency.WPF\ViewModels\Operator](#operator)
   1. [OperatorDashboardViewModel.cs](#operatordashboardviewmodel)
10. [CampAgency.WPF\ViewModels\Parent](#parent)
   1. [ParentDashboardViewModel.cs](#parentdashboardviewmodel)
11. [CampAgency.WPF\Views\Admin](#admin)
   1. [AdminDashboardView.xaml](#admindashboardview)
   2. [AdminDashboardView.xaml.cs](#admindashboardviewxaml)
   3. [CampEditView.xaml](#campeditview)
   4. [CampEditView.xaml.cs](#campeditviewxaml)
   5. [CampsListView.xaml](#campslistview)
   6. [CampsListView.xaml.cs](#campslistviewxaml)
12. [CampAgency.WPF\Views\Auth](#auth)
   1. [LoginView.xaml](#loginview)
   2. [LoginView.xaml.cs](#loginviewxaml)
   3. [RegisterView.xaml](#registerview)
   4. [RegisterView.xaml.cs](#registerviewxaml)
13. [CampAgency.WPF\Views\Operator](#operator)
   1. [OperatorDashboardView.xaml](#operatordashboardview)
   2. [OperatorDashboardView.xaml.cs](#operatordashboardviewxaml)
14. [CampAgency.WPF\Views\Parent](#parent)
   1. [ParentDashboardView.xaml](#parentdashboardview)
   2. [ParentDashboardView.xaml.cs](#parentdashboardviewxaml)

## FILE 1: Project Root

## CampAgency.WPF

<a id='campagency'></a>

## FILE 1: App.xaml

<a id='app'></a>

```xml
<Application x:Class="CampAgency.WPF.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vmAuth="clr-namespace:CampAgency.WPF.ViewModels.Auth"
             xmlns:vmAdmin="clr-namespace:CampAgency.WPF.ViewModels.Admin"
             xmlns:vmParent="clr-namespace:CampAgency.WPF.ViewModels.Parent"
             xmlns:vmOperator="clr-namespace:CampAgency.WPF.ViewModels.Operator"
             xmlns:vAuth="clr-namespace:CampAgency.WPF.Views.Auth"
             xmlns:vAdmin="clr-namespace:CampAgency.WPF.Views.Admin"
             xmlns:vParent="clr-namespace:CampAgency.WPF.Views.Parent"
             xmlns:vOperator="clr-namespace:CampAgency.WPF.Views.Operator">
    <Application.Resources>
        <DataTemplate DataType="{x:Type vmAuth:LoginViewModel}">
            <vAuth:LoginView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:AdminDashboardViewModel}">
            <vAdmin:AdminDashboardView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:CampsListViewModel}">
            <vAdmin:CampsListView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:CampEditViewModel}">
            <vAdmin:CampEditView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmParent:ParentDashboardViewModel}">
            <vParent:ParentDashboardView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmOperator:OperatorDashboardViewModel}">
            <vOperator:OperatorDashboardView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAuth:RegisterViewModel}">
            <vAuth:RegisterView />
        </DataTemplate>
    </Application.Resources>
</Application>
```

---

## FILE 2: App.xaml.cs

<a id='appxaml'></a>

```csharp
using System.Windows;
using CampAgency.WPF.Data;
using CampAgency.WPF.Services;
using CampAgency.WPF.ViewModels;
using CampAgency.WPF.ViewModels.Auth;
using CampAgency.WPF.ViewModels.Admin;
using CampAgency.WPF.ViewModels.Parent;
using CampAgency.WPF.ViewModels.Operator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CampAgency.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer("Data Source=.;Initial Catalog=CampAgencyDB;Integrated Security=true;TrustServerCertificate=True;"));

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IRegistrationService, RegistrationService>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<AdminDashboardViewModel>();
            services.AddTransient<CampsListViewModel>();
            services.AddTransient<CampEditViewModel>();
            services.AddTransient<ParentDashboardViewModel>();
            services.AddTransient<OperatorDashboardViewModel>();
            services.AddTransient<RegisterViewModel>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>(sp =>
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
```

---

## FILE 3: AssemblyInfo.cs

<a id='assemblyinfo'></a>

```csharp
using System.Windows;

[assembly:ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]

```

---

## FILE 4: CampAgency.WPF.csproj

<a id='campagencywpf'></a>

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
  </ItemGroup>

</Project>

```

---

## FILE 5: MainWindow.xaml

<a id='mainwindow'></a>

```xml
<Window x:Class="CampAgency.WPF.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:vmAuth="clr-namespace:CampAgency.WPF.ViewModels.Auth"
        xmlns:vAuth="clr-namespace:CampAgency.WPF.Views.Auth"
        Title="Агентство Детского Отдыха" Height="600" Width="900">

    <Window.Resources>
        <!-- ТЕСТОВЫЙ ШАБЛОН ПРЯМО В ОКНЕ -->
        <DataTemplate DataType="{x:Type vmAuth:LoginViewModel}">
            <vAuth:LoginView />
        </DataTemplate>
    </Window.Resources>

    <Grid>
        <DockPanel>
            <StackPanel DockPanel.Dock="Top" Orientation="Horizontal" Background="#FFDDDDDD" Margin="0,0,0,10">
                <TextBlock Text="{Binding UserInfo}" Margin="10" VerticalAlignment="Center" FontWeight="Bold"/>
                <Button Content="Выйти" Command="{Binding LogoutCommand}" Margin="10" HorizontalAlignment="Right"/>
            </StackPanel>

            <ContentControl Content="{Binding NavigationService.CurrentViewModel}" />
        </DockPanel>
    </Grid>
</Window>
```

---

## FILE 6: MainWindow.xaml.cs

<a id='mainwindowxaml'></a>

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CampAgency.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

```

---

## CampAgency.WPF\Data

<a id='data'></a>

## FILE 7: AppDbContext.cs

<a id='appdbcontext'></a>

```csharp
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
```

---

## CampAgency.WPF\Migrations

<a id='migrations'></a>

## FILE 8: 20260603135705_rebaseDatabase.cs

<a id='20260603135705rebasedatabase'></a>

```csharp
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class rebaseDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingStatuses",
                columns: table => new
                {
                    BookingStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatuses", x => x.BookingStatusId);
                });

            migrationBuilder.CreateTable(
                name: "CampTypes",
                columns: table => new
                {
                    CampTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampTypes", x => x.CampTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatuses",
                columns: table => new
                {
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatuses", x => x.DocumentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalNotes",
                columns: table => new
                {
                    MedicalNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalNoteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalNotes", x => x.MedicalNoteId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatuses",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PaymentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    CampId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampTypeId = table.Column<int>(type: "int", nullable: false),
                    CampName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.CampId);
                    table.ForeignKey(
                        name: "FK_Camps_CampTypes_CampTypeId",
                        column: x => x.CampTypeId,
                        principalTable: "CampTypes",
                        principalColumn: "CampTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Camps_CampId",
                        column: x => x.CampId,
                        principalTable: "Camps",
                        principalColumn: "CampId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_Children_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Children_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    BookingStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingStatuses_BookingStatusId",
                        column: x => x.BookingStatusId,
                        principalTable: "BookingStatuses",
                        principalColumn: "BookingStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildMedicalNotes",
                columns: table => new
                {
                    ChildMedicalNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalNoteId = table.Column<int>(type: "int", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildMedicalNotes", x => x.ChildMedicalNoteId);
                    table.ForeignKey(
                        name: "FK_ChildMedicalNotes_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildMedicalNotes_MedicalNotes_MedicalNoteId",
                        column: x => x.MedicalNoteId,
                        principalTable: "MedicalNotes",
                        principalColumn: "MedicalNoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentStatuses_DocumentStatusId",
                        column: x => x.DocumentStatusId,
                        principalTable: "DocumentStatuses",
                        principalColumn: "DocumentStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStatuses_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatuses",
                        principalColumn: "PaymentStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "PaymentTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStatusId",
                table: "Bookings",
                column: "BookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ChildId",
                table: "Bookings",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShiftId",
                table: "Bookings",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Camps_CampTypeId",
                table: "Camps",
                column: "CampTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildMedicalNotes_ChildId",
                table: "ChildMedicalNotes",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildMedicalNotes_MedicalNoteId",
                table: "ChildMedicalNotes",
                column: "MedicalNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_GenderId",
                table: "Children",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_UserId",
                table: "Children",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ChildId",
                table: "Documents",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentStatusId",
                table: "Documents",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStatusId",
                table: "Payments",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeId",
                table: "Payments",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CampId",
                table: "Shifts",
                column: "CampId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildMedicalNotes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "MedicalNotes");

            migrationBuilder.DropTable(
                name: "DocumentStatuses");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "PaymentStatuses");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "BookingStatuses");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Camps");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CampTypes");
        }
    }
}

```

---

## FILE 9: 20260603135705_rebaseDatabase.Designer.cs

<a id='20260603135705rebasedatabasedesigner'></a>

```csharp
// <auto-generated />
using System;
using CampAgency.WPF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260603135705_rebaseDatabase")]
    partial class rebaseDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("ChildId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.BookingStatus", b =>
                {
                    b.Property<int>("BookingStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingStatusId"));

                    b.Property<string>("BookingStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookingStatusId");

                    b.ToTable("BookingStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.Property<int>("CampId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampId"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CampName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CampTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampId");

                    b.HasIndex("CampTypeId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.CampType", b =>
                {
                    b.Property<int>("CampTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampTypeId"));

                    b.Property<string>("CampTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampTypeId");

                    b.ToTable("CampTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChildId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChildId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.ChildMedicalNote", b =>
                {
                    b.Property<int>("ChildMedicalNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChildMedicalNoteId"));

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalNoteId")
                        .HasColumnType("int");

                    b.HasKey("ChildMedicalNoteId");

                    b.HasIndex("ChildId");

                    b.HasIndex("MedicalNoteId");

                    b.ToTable("ChildMedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("DocumentId");

                    b.HasIndex("ChildId");

                    b.HasIndex("DocumentStatusId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentStatus", b =>
                {
                    b.Property<int>("DocumentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentStatusId"));

                    b.Property<string>("DocumentStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DocumentStatusId");

                    b.ToTable("DocumentStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeId"));

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.MedicalNote", b =>
                {
                    b.Property<int>("MedicalNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalNoteId"));

                    b.Property<string>("MedicalNoteName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MedicalNoteId");

                    b.ToTable("MedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("PaymentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentStatusId"));

                    b.Property<string>("PaymentStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentStatusId");

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTypeId"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("ShiftId");

                    b.HasIndex("CampId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("Bookings")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.Shift", "Shift")
                        .WithMany("Bookings")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookingStatus");

                    b.Navigation("Child");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.CampType", "CampType")
                        .WithMany("Camps")
                        .HasForeignKey("CampTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Gender", "Gender")
                        .WithMany("Children")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.User", "User")
                        .WithMany("Children")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.ChildMedicalNote", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("ChildMedicalNotes")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.MedicalNote", "MedicalNote")
                        .WithMany("ChildMedicalNotes")
                        .HasForeignKey("MedicalNoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("MedicalNote");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Document", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("Documents")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.DocumentStatus", "DocumentStatus")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("DocumentStatus");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Payment", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("PaymentStatus");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Camp", "Camp")
                        .WithMany("Shifts")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.CampType", b =>
                {
                    b.Navigation("Camps");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("ChildMedicalNotes");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentStatus", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Gender", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.MedicalNote", b =>
                {
                    b.Navigation("ChildMedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentType", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

```

---

## FILE 10: AppDbContextModelSnapshot.cs

<a id='appdbcontextmodelsnapshot'></a>

```csharp
// <auto-generated />
using System;
using CampAgency.WPF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<int>("BookingStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("BookingStatusId");

                    b.HasIndex("ChildId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.BookingStatus", b =>
                {
                    b.Property<int>("BookingStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingStatusId"));

                    b.Property<string>("BookingStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookingStatusId");

                    b.ToTable("BookingStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.Property<int>("CampId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampId"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CampName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CampTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Region")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampId");

                    b.HasIndex("CampTypeId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.CampType", b =>
                {
                    b.Property<int>("CampTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampTypeId"));

                    b.Property<string>("CampTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CampTypeId");

                    b.ToTable("CampTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChildId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChildId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.ChildMedicalNote", b =>
                {
                    b.Property<int>("ChildMedicalNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChildMedicalNoteId"));

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalNoteId")
                        .HasColumnType("int");

                    b.HasKey("ChildMedicalNoteId");

                    b.HasIndex("ChildId");

                    b.HasIndex("MedicalNoteId");

                    b.ToTable("ChildMedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("DocumentId");

                    b.HasIndex("ChildId");

                    b.HasIndex("DocumentStatusId");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentStatus", b =>
                {
                    b.Property<int>("DocumentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentStatusId"));

                    b.Property<string>("DocumentStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DocumentStatusId");

                    b.ToTable("DocumentStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentTypeId"));

                    b.Property<string>("DocumentTypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"));

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.MedicalNote", b =>
                {
                    b.Property<int>("MedicalNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalNoteId"));

                    b.Property<string>("MedicalNoteName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("MedicalNoteId");

                    b.ToTable("MedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("PaymentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentStatusId"));

                    b.Property<string>("PaymentStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentStatusId");

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentTypeId"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("ShiftId");

                    b.HasIndex("CampId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.BookingStatus", "BookingStatus")
                        .WithMany("Bookings")
                        .HasForeignKey("BookingStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("Bookings")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.Shift", "Shift")
                        .WithMany("Bookings")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookingStatus");

                    b.Navigation("Child");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.CampType", "CampType")
                        .WithMany("Camps")
                        .HasForeignKey("CampTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CampType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Gender", "Gender")
                        .WithMany("Children")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.User", "User")
                        .WithMany("Children")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.ChildMedicalNote", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("ChildMedicalNotes")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.MedicalNote", "MedicalNote")
                        .WithMany("ChildMedicalNotes")
                        .HasForeignKey("MedicalNoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("MedicalNote");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Document", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Child", "Child")
                        .WithMany("Documents")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.DocumentStatus", "DocumentStatus")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("DocumentStatus");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Payment", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CampAgency.WPF.Models.Entities.PaymentType", "PaymentType")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("PaymentStatus");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.Camp", "Camp")
                        .WithMany("Shifts")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.HasOne("CampAgency.WPF.Models.Entities.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Booking", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.BookingStatus", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Camp", b =>
                {
                    b.Navigation("Shifts");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.CampType", b =>
                {
                    b.Navigation("Camps");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Child", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("ChildMedicalNotes");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentStatus", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Gender", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.MedicalNote", b =>
                {
                    b.Navigation("ChildMedicalNotes");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentStatus", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.PaymentType", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.User", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

```

---

## CampAgency.WPF\Models\Entities

<a id='entities'></a>

## FILE 11: Booking.cs

<a id='booking'></a>

```csharp
using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int ChildId { get; set; }
        public int ShiftId { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Child Child { get; set; } = null!;
        public virtual Shift Shift { get; set; } = null!;
        public virtual BookingStatus BookingStatus { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
```

---

## FILE 12: BookingStatus.cs

<a id='bookingstatus'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class BookingStatus
    {
        public int BookingStatusId { get; set; }
        public string BookingStatusName { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
```

---

## FILE 13: Camp.cs

<a id='camp'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Camp
    {
        public int CampId { get; set; }
        public int CampTypeId { get; set; }
        public string CampName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ContactPhone { get; set; }
        public decimal? Rating { get; set; }
        public string? Region { get; set; }
        public string? Address { get; set; }

        public virtual CampType CampType { get; set; } = null!;
        public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
```

---

## FILE 14: CampType.cs

<a id='camptype'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class CampType
    {
        public int CampTypeId { get; set; }
        public string CampTypeName { get; set; } = null!;
        public virtual ICollection<Camp> Camps { get; set; } = new List<Camp>();
    }
}
```

---

## FILE 15: Child.cs

<a id='child'></a>

```csharp
using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Child
    {
        public int ChildId { get; set; }
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<ChildMedicalNote> ChildMedicalNotes { get; set; } = new List<ChildMedicalNote>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
```

---

## FILE 16: ChildMedicalNote.cs

<a id='childmedicalnote'></a>

```csharp
namespace CampAgency.WPF.Models.Entities
{
    public partial class ChildMedicalNote
    {
        public int ChildMedicalNoteId { get; set; }
        public int MedicalNoteId { get; set; }
        public int ChildId { get; set; }

        public virtual MedicalNote MedicalNote { get; set; } = null!;
        public virtual Child Child { get; set; } = null!;
    }
}
```

---

## FILE 17: Document.cs

<a id='document'></a>

```csharp
using System;
using System.Xml.Linq;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int ChildId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentStatusId { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Child Child { get; set; } = null!;
        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual DocumentStatus DocumentStatus { get; set; } = null!;
    }
}
```

---

## FILE 18: DocumentStatus.cs

<a id='documentstatus'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class DocumentStatus
    {
        public int DocumentStatusId { get; set; }
        public string DocumentStatusName { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
```

---

## FILE 19: DocumentType.cs

<a id='documenttype'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
```

---

## FILE 20: Gender.cs

<a id='gender'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
```

---

## FILE 21: MedicalNote.cs

<a id='medicalnote'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class MedicalNote
    {
        public int MedicalNoteId { get; set; }
        public string MedicalNoteName { get; set; } = null!;
        public virtual ICollection<ChildMedicalNote> ChildMedicalNotes { get; set; } = new List<ChildMedicalNote>();
    }
}
```

---

## FILE 22: Payment.cs

<a id='payment'></a>

```csharp
using System;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Price { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual PaymentType PaymentType { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; } = null!;
    }
}
```

---

## FILE 23: PaymentStatus.cs

<a id='paymentstatus'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class PaymentStatus
    {
        public int PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
```

---

## FILE 24: PaymentType.cs

<a id='paymenttype'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
```

---

## FILE 25: Shift.cs

<a id='shift'></a>

```csharp
using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public int CampId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int TotalSeats { get; set; }
        public decimal Price { get; set; }

        public virtual Camp Camp { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
```

---

## FILE 26: User.cs

<a id='user'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;
        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
```

---

## FILE 27: UserRole.cs

<a id='userrole'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
```

---

## CampAgency.WPF\Services

<a id='services'></a>

## FILE 28: AuthService.cs

<a id='authservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        public User? CurrentUser { get; private set; }

        public AuthService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool Login(string login, string password)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var user = context.Users.Include(u => u.UserRole)
                    .FirstOrDefault(u => u.Login == login && u.PasswordHash == password);
                if (user != null)
                {
                    CurrentUser = user;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void Logout() => CurrentUser = null;
    }
}
```

---

## FILE 29: IAuthService.cs

<a id='iauthservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services
{
    public interface IAuthService
    {
        User? CurrentUser { get; }
        bool Login(string login, string password);
        void Logout();
    }
}
```

---

## FILE 30: INavigationService.cs

<a id='inavigationservice'></a>

```csharp
using System.ComponentModel;

namespace CampAgency.WPF.Services
{
    public interface INavigationService : INotifyPropertyChanged
    {
        object? CurrentViewModel { get; }
        void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class;
    }

    public interface INavigationAware
    {
        void OnNavigatedTo(object? parameter);
    }
}
```

---

## FILE 31: IRegistrationService.cs

<a id='iregistrationservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services
{
    public interface IRegistrationService
    {
        (bool success, string message, User? user) Register(string login, string password, string fullName, string phone, string email);
    }
}
```

---

## FILE 32: NavigationService.cs

<a id='navigationservice'></a>

```csharp
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CampAgency.WPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private object? _currentViewModel;
        public event PropertyChangedEventHandler? PropertyChanged;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object? CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>();
            if (vm is INavigationAware aware)
            {
                aware.OnNavigatedTo(parameter);
            }
            CurrentViewModel = vm;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```

---

## FILE 33: RegistrationService.cs

<a id='registrationservice'></a>

```csharp
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public RegistrationService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public (bool success, string message, User? user) Register(string login, string password, string fullName, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(fullName))
                return (false, "Логин, пароль и ФИО обязательны для заполнения.", null);

            using var context = _contextFactory.CreateDbContext();

            // Проверяем уникальность логина
            if (context.Users.Any(u => u.Login == login))
                return (false, "Пользователь с таким логином уже существует.", null);

            // Находим роль "Родитель"
            var parentRole = context.UserRoles.FirstOrDefault(r => r.RoleName == "Родитель");
            if (parentRole == null)
                return (false, "В системе не определена роль 'Родитель'. Обратитесь к администратору.", null);

            var newUser = new User
            {
                Login = login,
                PasswordHash = password, // В будущем добавить хеширование
                FullName = fullName,
                Phone = phone,
                Email = email,
                UserRoleId = parentRole.UserRoleId
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return (true, "Регистрация успешна! Теперь вы можете войти.", newUser);
        }
    }
}
```

---

## CampAgency.WPF\ViewModels

<a id='viewmodels'></a>

## FILE 34: MainWindowViewModel.cs

<a id='mainwindowviewmodel'></a>

```csharp
using CampAgency.WPF.Services;
using CampAgency.WPF.ViewModels.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string _userInfo = "Не авторизован";
        public INavigationService NavigationService { get; }
        public IAuthService AuthService { get; }

        public MainWindowViewModel(INavigationService navigation, IAuthService auth)
        {
            NavigationService = navigation;
            AuthService = auth;
            NavigationService.NavigateTo<LoginViewModel>();
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (AuthService.CurrentUser != null)
                UserInfo = $"{AuthService.CurrentUser.FullName} ({AuthService.CurrentUser.UserRole?.RoleName ?? "нет роли"})";
            else
                UserInfo = "Не авторизован";
        }

        [RelayCommand]
        private void Logout()
        {
            AuthService.Logout();
            UpdateUserInfo();
            NavigationService.NavigateTo<LoginViewModel>();
        }
    }
}
```

---

## CampAgency.WPF\ViewModels\Admin

<a id='admin'></a>

## FILE 35: AdminDashboardViewModel.cs

<a id='admindashboardviewmodel'></a>

```csharp
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class AdminDashboardViewModel : ObservableObject
    {
        private readonly INavigationService _navigation;

        public AdminDashboardViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            // При открытии дашборда сразу показываем список лагерей
            _navigation.NavigateTo<CampsListViewModel>();
        }

        // Можно добавить кнопки для других разделов админки здесь
    }
}
```

---

## FILE 36: CampEditViewModel.cs

<a id='campeditviewmodel'></a>

```csharp
using System.Collections.ObjectModel;
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;

        [ObservableProperty] private string _campName = string.Empty;
        [ObservableProperty] private string _region = string.Empty;
        [ObservableProperty] private string _description = string.Empty;
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private CampType? _selectedCampType;

        private Camp? _currentCamp;
        private bool _isNew;

        public CampEditViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadCampTypes();
            if (parameter is Camp camp)
            {
                _currentCamp = camp;
                _isNew = false;
                CampName = camp.CampName;
                Region = camp.Region ?? string.Empty;
                Description = camp.Description ?? string.Empty;
                SelectedCampType = camp.CampType;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                CampName = string.Empty;
                Region = string.Empty;
                Description = string.Empty;
                SelectedCampType = null;
            }
        }

        private void LoadCampTypes()
        {
            using var context = _contextFactory.CreateDbContext();
            CampTypes = new ObservableCollection<CampType>(context.CampTypes.ToList());
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(CampName) || SelectedCampType == null) return;
            using var context = _contextFactory.CreateDbContext();
            if (_isNew)
            {
                var newCamp = new Camp
                {
                    CampName = CampName,
                    Region = Region,
                    Description = Description,
                    CampTypeId = SelectedCampType.CampTypeId,
                    Rating = 0
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                var campToUpdate = context.Camps.Find(_currentCamp!.CampId);
                if (campToUpdate != null)
                {
                    campToUpdate.CampName = CampName;
                    campToUpdate.Region = Region;
                    campToUpdate.Description = Description;
                    campToUpdate.CampTypeId = SelectedCampType.CampTypeId;
                }
            }
            context.SaveChanges();
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand] private void Cancel() => _navigation.NavigateTo<CampsListViewModel>();
    }
}
```

---

## FILE 37: CampsListViewModel.cs

<a id='campslistviewmodel'></a>

```csharp
using System.Collections.ObjectModel;
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampsListViewModel : ObservableObject
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();

        public CampsListViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            LoadCamps();
        }

        private void LoadCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = context.Camps.Include(c => c.CampType).ToList();
            Camps = new ObservableCollection<Camp>(list);
        }

        [RelayCommand] private void AddCamp() => _navigation.NavigateTo<CampEditViewModel>(null);
        [RelayCommand] private void EditCamp(Camp camp) => _navigation.NavigateTo<CampEditViewModel>(camp);

        [RelayCommand]
        private void DeleteCamp(Camp camp)
        {
            if (camp == null) return;
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Camps.Find(camp.CampId);
            if (existing != null)
            {
                context.Camps.Remove(existing);
                context.SaveChanges();
                LoadCamps();
            }
        }
    }
}
```

---

## CampAgency.WPF\ViewModels\Auth

<a id='auth'></a>

## FILE 38: LoginViewModel.cs

<a id='loginviewmodel'></a>

```csharp
using CampAgency.WPF.Services;
using CampAgency.WPF.ViewModels.Admin;
using CampAgency.WPF.ViewModels.Operator;
using CampAgency.WPF.ViewModels.Parent;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Auth
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private string _login = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _errorMessage = string.Empty;

        public LoginViewModel(IAuthService authService, INavigationService navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void ExecuteLogin()
        {
            if (_authService.Login(Login, Password))
            {
                ErrorMessage = string.Empty;
                var roleName = _authService.CurrentUser?.UserRole?.RoleName;
                switch (roleName)
                {
                    case "Родитель": _navigationService.NavigateTo<ParentDashboardViewModel>(); break;
                    case "Оператор": _navigationService.NavigateTo<OperatorDashboardViewModel>(); break;
                    case "Администратор": _navigationService.NavigateTo<AdminDashboardViewModel>(); break;
                    default: _navigationService.NavigateTo<LoginViewModel>(); break;
                }
            }
            else
            {
                ErrorMessage = "Неверный логин или пароль";
            }
        }

        [RelayCommand]
        private void GoToRegister()
        {
            _navigationService.NavigateTo<RegisterViewModel>();
        }
    }
}
```

---

## FILE 39: RegisterViewModel.cs

<a id='registerviewmodel'></a>

```csharp
using System.Windows;
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Auth
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IRegistrationService _registrationService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private string _login = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _confirmPassword = string.Empty;
        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private string _phone = string.Empty;
        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _errorMessage = string.Empty;

        public RegisterViewModel(IRegistrationService registrationService, INavigationService navigationService)
        {
            _registrationService = registrationService;
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void Register()
        {
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Пароли не совпадают";
                return;
            }

            var (success, message, _) = _registrationService.Register(Login, Password, FullName, Phone, Email);
            if (success)
            {
                MessageBox.Show(message, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Возвращаемся на экран входа
                _navigationService.NavigateTo<LoginViewModel>();
            }
            else
            {
                ErrorMessage = message;
            }
        }

        [RelayCommand]
        private void Cancel() => _navigationService.NavigateTo<LoginViewModel>();
    }
}
```

---

## CampAgency.WPF\ViewModels\Operator

<a id='operator'></a>

## FILE 40: OperatorDashboardViewModel.cs

<a id='operatordashboardviewmodel'></a>

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampAgency.WPF.ViewModels.Operator
{
    class OperatorDashboardViewModel
    {
    }
}

```

---

## CampAgency.WPF\ViewModels\Parent

<a id='parent'></a>

## FILE 41: ParentDashboardViewModel.cs

<a id='parentdashboardviewmodel'></a>

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampAgency.WPF.ViewModels.Parent
{
    class ParentDashboardViewModel
    {
    }
}

```

---

## CampAgency.WPF\Views\Admin

<a id='admin'></a>

## FILE 42: AdminDashboardView.xaml

<a id='admindashboardview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.AdminDashboardView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <!-- Заголовок -->
        <TextBlock Grid.Row="0" Text="Панель администратора" 
                   FontSize="24" FontWeight="Bold" Margin="0,0,0,20"/>

        <!-- Кнопки меню -->
        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Content="Управление лагерями" Width="150" Margin="5" Height="40"/>
            <Button Content="Управление сменами" Width="150" Margin="5" Height="40"/>
            <Button Content="Пользователи" Width="150" Margin="5" Height="40"/>
        </StackPanel>

        <!-- Область контента (пока заглушка) -->
        <Border Grid.Row="1" BorderBrush="Gray" BorderThickness="1" 
                Background="#F5F5F5" CornerRadius="5">
            <TextBlock Text="Выберите раздел из меню выше" 
                       HorizontalAlignment="Center" VerticalAlignment="Center" 
                       FontSize="16" Foreground="Gray"/>
        </Border>
    </Grid>
</UserControl>
```

---

## FILE 43: AdminDashboardView.xaml.cs

<a id='admindashboardviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Admin
{
    public partial class AdminDashboardView : UserControl
    {
        public AdminDashboardView()
        {
            InitializeComponent();
        }
    }
}
```

---

## FILE 44: CampEditView.xaml

<a id='campeditview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.CampEditView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel Margin="20" Width="400">
        <TextBlock Text="Редактирование лагеря" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

        <TextBlock Text="Название:" Margin="0,5"/>
        <TextBox Text="{Binding CampName}" Margin="0,5" Height="30"/>

        <TextBlock Text="Тип учреждения:" Margin="0,10,0,5"/>
        <ComboBox ItemsSource="{Binding CampTypes}" SelectedItem="{Binding SelectedCampType}" DisplayMemberPath="CampTypeName" Margin="0,5" Height="30"/>

        <TextBlock Text="Регион:" Margin="0,10,0,5"/>
        <TextBox Text="{Binding Region}" Margin="0,5" Height="30"/>

        <TextBlock Text="Описание:" Margin="0,10,0,5"/>
        <TextBox Text="{Binding Description}" Margin="0,5" Height="80" TextWrapping="Wrap" AcceptsReturn="True" VerticalScrollBarVisibility="Auto"/>

        <StackPanel Orientation="Horizontal" Margin="0,20,0,0" HorizontalAlignment="Right">
            <Button Content="Сохранить" Command="{Binding SaveCommand}" Width="100" Height="35" Margin="0,0,10,0"/>
            <Button Content="Отмена" Command="{Binding CancelCommand}" Width="100" Height="35"/>
        </StackPanel>
    </StackPanel>
</UserControl>
```

---

## FILE 45: CampEditView.xaml.cs

<a id='campeditviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Admin
{
    public partial class CampEditView : UserControl
    {
        public CampEditView()
        {
            InitializeComponent();
        }
    }
}
```

---

## FILE 46: CampsListView.xaml

<a id='campslistview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.CampsListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <Grid Grid.Row="0" Margin="0,0,0,10">
            <TextBlock Text="Список лагерей" FontSize="20" FontWeight="Bold" VerticalAlignment="Center"/>
            <Button Content="+ Добавить лагерь" Command="{Binding AddCampCommand}" Width="150" Height="30" HorizontalAlignment="Right"/>
        </Grid>

        <StackPanel Grid.Row="1" Orientation="Horizontal" Margin="0,0,0,10">
            <TextBlock Text="Поиск:" VerticalAlignment="Center" Margin="0,0,10,0"/>
            <TextBox Width="200" Height="25"/>
        </StackPanel>

        <DataGrid Grid.Row="2" ItemsSource="{Binding Camps}" AutoGenerateColumns="False" 
                  CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Название" Binding="{Binding CampName}" Width="*"/>
                <DataGridTextColumn Header="Регион" Binding="{Binding Region}" Width="150"/>
                <DataGridTextColumn Header="Рейтинг" Binding="{Binding Rating}" Width="80"/>
                <DataGridTemplateColumn Header="Действия" Width="150">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="✏️" Width="30" Margin="2" Command="{Binding DataContext.EditCampCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" CommandParameter="{Binding}"/>
                                <Button Content="🗑️" Width="30" Margin="2" Command="{Binding DataContext.DeleteCampCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" CommandParameter="{Binding}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
</UserControl>
```

---

## FILE 47: CampsListView.xaml.cs

<a id='campslistviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Admin
{
    public partial class CampsListView : UserControl
    {
        public CampsListView()
        {
            InitializeComponent();
        }
    }
}
```

---

## CampAgency.WPF\Views\Auth

<a id='auth'></a>

## FILE 48: LoginView.xaml

<a id='loginview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Auth.LoginView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Width="300">
        <TextBlock Text="Вход в систему" FontSize="24" Margin="0,0,0,20" HorizontalAlignment="Center"/>

        <TextBlock Text="Логин:" Margin="0,5"/>
        <TextBox Text="{Binding Login, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <TextBlock Text="Пароль:" Margin="0,5"/>
        <TextBox Text="{Binding Password, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <Button Content="Войти" Command="{Binding ExecuteLoginCommand}" Margin="0,20" Height="30"/>
        <Button Content="Зарегистрироваться" Command="{Binding GoToRegisterCommand}" Margin="0,5" Height="30" Background="LightGray"/>
        <TextBlock Text="{Binding ErrorMessage}" Foreground="Red" Margin="0,5"/>
    </StackPanel>
</UserControl>
```

---

## FILE 49: LoginView.xaml.cs

<a id='loginviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Auth
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}
```

---

## FILE 50: RegisterView.xaml

<a id='registerview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Auth.RegisterView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Width="350">
        <TextBlock Text="Регистрация нового пользователя" FontSize="24" Margin="0,0,0,20" HorizontalAlignment="Center"/>

        <TextBlock Text="Логин*:" Margin="0,5"/>
        <TextBox Text="{Binding Login, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <TextBlock Text="Пароль*:" Margin="0,5"/>
        <PasswordBox x:Name="PasswordBox" Margin="0,5" Height="30"/>

        <TextBlock Text="Подтверждение пароля*:" Margin="0,5"/>
        <PasswordBox x:Name="ConfirmPasswordBox" Margin="0,5" Height="30"/>

        <TextBlock Text="Полное имя*:" Margin="0,5"/>
        <TextBox Text="{Binding FullName, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <TextBlock Text="Телефон:" Margin="0,5"/>
        <TextBox Text="{Binding Phone, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <TextBlock Text="Email:" Margin="0,5"/>
        <TextBox Text="{Binding Email, UpdateSourceTrigger=PropertyChanged}" Margin="0,5" Height="30"/>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Center" Margin="0,20">
            <Button Content="Зарегистрироваться" Command="{Binding RegisterCommand}" Width="150" Height="35" Margin="5"/>
            <Button Content="Отмена" Command="{Binding CancelCommand}" Width="100" Height="35" Margin="5"/>
        </StackPanel>

        <TextBlock Text="{Binding ErrorMessage}" Foreground="Red" Margin="0,5" TextWrapping="Wrap" TextAlignment="Center"/>
        <TextBlock Text="* - обязательные поля" FontSize="11" Foreground="Gray" Margin="0,5" HorizontalAlignment="Center"/>
    </StackPanel>
</UserControl>
```

---

## FILE 51: RegisterView.xaml.cs

<a id='registerviewxaml'></a>

```csharp
using System.Windows;
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Auth
{
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Привязка паролей вручную, так как PasswordBox не поддерживает обычный Binding
            if (DataContext is ViewModels.Auth.RegisterViewModel vm)
            {
                PasswordBox.PasswordChanged += (s, _) => vm.Password = PasswordBox.Password;
                ConfirmPasswordBox.PasswordChanged += (s, _) => vm.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }
    }
}
```

---

## CampAgency.WPF\Views\Operator

<a id='operator'></a>

## FILE 52: OperatorDashboardView.xaml

<a id='operatordashboardview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Operator.OperatorDashboardView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="20">
        <TextBlock Text="Панель оператора" 
                   FontSize="24" FontWeight="Bold" 
                   HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</UserControl>
```

---

## FILE 53: OperatorDashboardView.xaml.cs

<a id='operatordashboardviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Operator
{
    public partial class OperatorDashboardView : UserControl
    {
        public OperatorDashboardView()
        {
            InitializeComponent();
        }
    }
}
```

---

## CampAgency.WPF\Views\Parent

<a id='parent'></a>

## FILE 54: ParentDashboardView.xaml

<a id='parentdashboardview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ParentDashboardView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="20">
        <TextBlock Text="Личный кабинет родителя" 
                   FontSize="24" FontWeight="Bold" 
                   HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</UserControl>
```

---

## FILE 55: ParentDashboardView.xaml.cs

<a id='parentdashboardviewxaml'></a>

```csharp
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Parent
{
    public partial class ParentDashboardView : UserControl
    {
        public ParentDashboardView()
        {
            InitializeComponent();
        }
    }
}
```

---

