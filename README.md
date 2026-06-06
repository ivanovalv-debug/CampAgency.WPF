# CampAgency.WPF - Project Documentation

## Content

1. [CampAgency.WPF](#campagency)
   1. [App.xaml](#app)
   2. [App.xaml.cs](#appxaml)
   3. [AssemblyInfo.cs](#assemblyinfo)
   4. [CampAgency.WPF.csproj](#campagencywpf)
   5. [MainWindow.xaml](#mainwindow)
   6. [MainWindow.xaml.cs](#mainwindowxaml)
2. [CampAgency.WPF\Converters](#converters)
   1. [InverseBooleanConverter.cs](#inversebooleanconverter)
3. [CampAgency.WPF\Data](#data)
   1. [AppDbContext.cs](#appdbcontext)
4. [CampAgency.WPF\Migrations](#migrations)
   1. [20260603135705_rebaseDatabase.cs](#20260603135705rebasedatabase)
   2. [20260603135705_rebaseDatabase.Designer.cs](#20260603135705rebasedatabasedesigner)
   3. [20260604155052_addAvaibleSeats.cs](#20260604155052addavaibleseats)
   4. [20260604155052_addAvaibleSeats.Designer.cs](#20260604155052addavaibleseatsdesigner)
   5. [20260604162616_addRegionsTable.cs](#20260604162616addregionstable)
   6. [20260604162616_addRegionsTable.Designer.cs](#20260604162616addregionstabledesigner)
   7. [AppDbContextModelSnapshot.cs](#appdbcontextmodelsnapshot)
5. [CampAgency.WPF\Models\Entities](#entities)
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
   15. [Region.cs](#region)
   16. [Shift.cs](#shift)
   17. [User.cs](#user)
   18. [UserRole.cs](#userrole)
6. [CampAgency.WPF\Services\AuthServices](#authservices)
   1. [AuthService.cs](#authservice)
   2. [IAuthService.cs](#iauthservice)
   3. [IRegistrationService.cs](#iregistrationservice)
   4. [RegistrationService.cs](#registrationservice)
7. [CampAgency.WPF\Services\ChildServices](#childservices)
   1. [ChildService.cs](#childservice)
   2. [IChildService.cs](#ichildservice)
8. [CampAgency.WPF\Services\DialogServices](#dialogservices)
   1. [DialogService.cs](#dialogservice)
   2. [IDialogService.cs](#idialogservice)
9. [CampAgency.WPF\Services\NavigationServices](#navigationservices)
   1. [INavigationService.cs](#inavigationservice)
   2. [NavigationService.cs](#navigationservice)
10. [CampAgency.WPF\Services\ShiftServices](#shiftservices)
   1. [IShiftCatalogService.cs](#ishiftcatalogservice)
   2. [IShiftService.cs](#ishiftservice)
   3. [ShiftCatalogService.cs](#shiftcatalogservice)
   4. [ShiftService.cs](#shiftservice)
11. [CampAgency.WPF\Services\UserServices](#userservices)
   1. [IUserService.cs](#iuserservice)
   2. [UserService.cs](#userservice)
12. [CampAgency.WPF\ViewModels](#viewmodels)
   1. [MainWindowViewModel.cs](#mainwindowviewmodel)
13. [CampAgency.WPF\ViewModels\Admin](#admin)
   1. [AdminDashboardViewModel.cs](#admindashboardviewmodel)
   2. [CampEditViewModel.cs](#campeditviewmodel)
   3. [CampsListViewModel.cs](#campslistviewmodel)
   4. [ShiftEditViewModel.cs](#shifteditviewmodel)
   5. [ShiftsListViewModel.cs](#shiftslistviewmodel)
   6. [UserEditViewModel.cs](#usereditviewmodel)
   7. [UsersListViewModel.cs](#userslistviewmodel)
14. [CampAgency.WPF\ViewModels\Auth](#auth)
   1. [LoginViewModel.cs](#loginviewmodel)
   2. [RegisterViewModel.cs](#registerviewmodel)
15. [CampAgency.WPF\ViewModels\Operator](#operator)
   1. [OperatorDashboardViewModel.cs](#operatordashboardviewmodel)
16. [CampAgency.WPF\ViewModels\Parent](#parent)
   1. [ChildEditViewModel.cs](#childeditviewmodel)
   2. [ChildListViewModel.cs](#childlistviewmodel)
   3. [MedicalNoteWrapper.cs](#medicalnotewrapper)
   4. [MyBookingsViewModel.cs](#mybookingsviewmodel)
   5. [ParentDashboardViewModel.cs](#parentdashboardviewmodel)
   6. [ShiftDetailsViewModel.cs](#shiftdetailsviewmodel)
   7. [ShiftsCatalogViewModel.cs](#shiftscatalogviewmodel)
17. [CampAgency.WPF\Views\Admin](#admin)
   1. [AdminDashboardView.xaml](#admindashboardview)
   2. [AdminDashboardView.xaml.cs](#admindashboardviewxaml)
   3. [CampEditView.xaml](#campeditview)
   4. [CampEditView.xaml.cs](#campeditviewxaml)
   5. [CampsListView.xaml](#campslistview)
   6. [CampsListView.xaml.cs](#campslistviewxaml)
   7. [ShiftEditView.xaml](#shifteditview)
   8. [ShiftEditView.xaml.cs](#shifteditviewxaml)
   9. [ShiftsListView.xaml](#shiftslistview)
   10. [ShiftsListView.xaml.cs](#shiftslistviewxaml)
   11. [UserEditView.xaml](#usereditview)
   12. [UserEditView.xaml.cs](#usereditviewxaml)
   13. [UsersListView.xaml](#userslistview)
   14. [UsersListView.xaml.cs](#userslistviewxaml)
18. [CampAgency.WPF\Views\Auth](#auth)
   1. [LoginView.xaml](#loginview)
   2. [LoginView.xaml.cs](#loginviewxaml)
   3. [RegisterView.xaml](#registerview)
   4. [RegisterView.xaml.cs](#registerviewxaml)
19. [CampAgency.WPF\Views\Operator](#operator)
   1. [OperatorDashboardView.xaml](#operatordashboardview)
   2. [OperatorDashboardView.xaml.cs](#operatordashboardviewxaml)
20. [CampAgency.WPF\Views\Parent](#parent)
   1. [ChildEditView.xaml](#childeditview)
   2. [ChildEditView.xaml.cs](#childeditviewxaml)
   3. [ChildListView.xaml](#childlistview)
   4. [ChildListView.xaml.cs](#childlistviewxaml)
   5. [MyBookingsView.xaml](#mybookingsview)
   6. [MyBookingsView.xaml.cs](#mybookingsviewxaml)
   7. [ParentDashboardView.xaml](#parentdashboardview)
   8. [ParentDashboardView.xaml.cs](#parentdashboardviewxaml)
   9. [ShiftDetailsView.xaml](#shiftdetailsview)
   10. [ShiftDetailsView.xaml.cs](#shiftdetailsviewxaml)
   11. [ShiftsCatalogView.xaml](#shiftscatalogview)
   12. [ShiftsCatalogView.xaml.cs](#shiftscatalogviewxaml)

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
             xmlns:vOperator="clr-namespace:CampAgency.WPF.Views.Operator"
             xmlns:converters="clr-namespace:CampAgency.WPF.Converters">
    <Application.Resources>
        <converters:InverseBooleanConverter x:Key="InverseBooleanConverter"/>

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
        <DataTemplate DataType="{x:Type vmParent:ChildListViewModel}">
            <vParent:ChildListView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmParent:ChildEditViewModel}">
            <vParent:ChildEditView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:ShiftsListViewModel}">
            <vAdmin:ShiftsListView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:UsersListViewModel}">
            <vAdmin:UsersListView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:ShiftEditViewModel}">
            <vAdmin:ShiftEditView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmAdmin:UserEditViewModel}">
            <vAdmin:UserEditView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmParent:ShiftsCatalogViewModel}">
            <vParent:ShiftsCatalogView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmParent:ShiftDetailsViewModel}">
            <vParent:ShiftDetailsView />
        </DataTemplate>
        <DataTemplate DataType="{x:Type vmParent:MyBookingsViewModel}">
            <vParent:MyBookingsView />
        </DataTemplate>
    </Application.Resources>
</Application>
```

---

## FILE 2: App.xaml.cs

<a id='appxaml'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CampAgency.WPF.Services.UserServices;
using CampAgency.WPF.ViewModels;
using CampAgency.WPF.ViewModels.Admin;
using CampAgency.WPF.ViewModels.Auth;
using CampAgency.WPF.ViewModels.Operator;
using CampAgency.WPF.ViewModels.Parent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<IChildService, ChildService>();
            services.AddSingleton<IShiftService, ShiftService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IShiftCatalogService, ShiftCatalogService>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<AdminDashboardViewModel>();
            services.AddTransient<CampsListViewModel>();
            services.AddTransient<CampEditViewModel>();
            services.AddTransient<ParentDashboardViewModel>();
            services.AddTransient<OperatorDashboardViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<ChildListViewModel>();
            services.AddTransient<ChildEditViewModel>();
            services.AddTransient<ShiftsListViewModel>();
            services.AddTransient<UsersListViewModel>();
            services.AddTransient<ShiftsListViewModel>();
            services.AddTransient<ShiftEditViewModel>();
            services.AddTransient<UsersListViewModel>();
            services.AddTransient<UserEditViewModel>();
            services.AddTransient<ShiftsCatalogViewModel>();
            services.AddTransient<ShiftDetailsViewModel>();
            services.AddTransient<MyBookingsViewModel>();

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

## CampAgency.WPF\Converters

<a id='converters'></a>

## FILE 7: InverseBooleanConverter.cs

<a id='inversebooleanconverter'></a>

```csharp
using System;
using System.Globalization;
using System.Windows.Data;

namespace CampAgency.WPF.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue) return !boolValue;
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue) return !boolValue;
            return false;
        }
    }
}
```

---

## CampAgency.WPF\Data

<a id='data'></a>

## FILE 8: AppDbContext.cs

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
        public virtual DbSet<Region> Regions { get; set; }
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
                entity.Property(e => e.ContactPhone).HasMaxLength(20);
                entity.Property(e => e.Rating).HasColumnType("decimal(3,2)");
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.HasOne(d => d.CampType).WithMany(p => p.Camps).HasForeignKey(d => d.CampTypeId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Region).WithMany(p => p.Camps).HasForeignKey(d => d.RegionId).OnDelete(DeleteBehavior.Restrict);
            });

            // Shift
            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => e.ShiftId);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.AvailableSeats).IsRequired();
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

            // Region
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId);
                entity.Property(e => e.RegionName).HasMaxLength(100).IsRequired();
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

## FILE 9: 20260603135705_rebaseDatabase.cs

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

## FILE 10: 20260603135705_rebaseDatabase.Designer.cs

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

## FILE 11: 20260604155052_addAvaibleSeats.cs

<a id='20260604155052addavaibleseats'></a>

```csharp
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addAvaibleSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Shifts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Shifts");
        }
    }
}

```

---

## FILE 12: 20260604155052_addAvaibleSeats.Designer.cs

<a id='20260604155052addavaibleseatsdesigner'></a>

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
    [Migration("20260604155052_addAvaibleSeats")]
    partial class addAvaibleSeats
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

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

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

## FILE 13: 20260604162616_addRegionsTable.cs

<a id='20260604162616addregionstable'></a>

```csharp
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampAgency.WPF.Migrations
{
    /// <inheritdoc />
    public partial class addRegionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Camps");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Camps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camps_RegionId",
                table: "Camps",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Camps_Regions_RegionId",
                table: "Camps",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camps_Regions_RegionId",
                table: "Camps");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Camps_RegionId",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Camps");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Camps",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}

```

---

## FILE 14: 20260604162616_addRegionsTable.Designer.cs

<a id='20260604162616addregionstabledesigner'></a>

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
    [Migration("20260604162616_addRegionsTable")]
    partial class addRegionsTable
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

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("CampId");

                    b.HasIndex("CampTypeId");

                    b.HasIndex("RegionId");

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

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"));

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

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

                    b.HasOne("CampAgency.WPF.Models.Entities.Region", "Region")
                        .WithMany("Camps")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CampType");

                    b.Navigation("Region");
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

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Region", b =>
                {
                    b.Navigation("Camps");
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

## FILE 15: AppDbContextModelSnapshot.cs

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

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("CampId");

                    b.HasIndex("CampTypeId");

                    b.HasIndex("RegionId");

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

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"));

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Shift", b =>
                {
                    b.Property<int>("ShiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShiftId"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

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

                    b.HasOne("CampAgency.WPF.Models.Entities.Region", "Region")
                        .WithMany("Camps")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CampType");

                    b.Navigation("Region");
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

            modelBuilder.Entity("CampAgency.WPF.Models.Entities.Region", b =>
                {
                    b.Navigation("Camps");
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

## FILE 16: Booking.cs

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

## FILE 17: BookingStatus.cs

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

## FILE 18: Camp.cs

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
        public int? RegionId { get; set; }
        public string? Address { get; set; }

        public virtual CampType CampType { get; set; } = null!;
        public virtual Region? Region { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
```

---

## FILE 19: CampType.cs

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

## FILE 20: Child.cs

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

## FILE 21: ChildMedicalNote.cs

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

## FILE 22: Document.cs

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

## FILE 23: DocumentStatus.cs

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

## FILE 24: DocumentType.cs

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

## FILE 25: Gender.cs

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

## FILE 26: MedicalNote.cs

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

## FILE 27: Payment.cs

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

## FILE 28: PaymentStatus.cs

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

## FILE 29: PaymentType.cs

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

## FILE 30: Region.cs

<a id='region'></a>

```csharp
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual ICollection<Camp> Camps { get; set; } = new List<Camp>();
    }
}
```

---

## FILE 31: Shift.cs

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
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }

        public virtual Camp Camp { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
```

---

## FILE 32: User.cs

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

## FILE 33: UserRole.cs

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

## CampAgency.WPF\Services\AuthServices

<a id='authservices'></a>

## FILE 34: AuthService.cs

<a id='authservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services.AuthServices
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

## FILE 35: IAuthService.cs

<a id='iauthservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services.AuthServices
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

## FILE 36: IRegistrationService.cs

<a id='iregistrationservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services.AuthServices
{
    public interface IRegistrationService
    {
        (bool success, string message, User? user) Register(string login, string password, string fullName, string phone, string email);
    }
}
```

---

## FILE 37: RegistrationService.cs

<a id='registrationservice'></a>

```csharp
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services.AuthServices
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

## CampAgency.WPF\Services\ChildServices

<a id='childservices'></a>

## FILE 38: ChildService.cs

<a id='childservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ChildServices
{
    public class ChildService : IChildService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ChildService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Child> GetChildrenByUserId(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Children
                .Include(c => c.Gender)
                .Include(c => c.ChildMedicalNotes).ThenInclude(cmn => cmn.MedicalNote)
                .Where(c => c.UserId == userId)
                .ToList();
        }

        public bool AddChild(int userId, string fullName, int genderId, DateOnly birthDate, List<int> medicalNoteIds)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var child = new Child
                {
                    UserId = userId,
                    FullName = fullName,
                    GenderId = genderId,
                    BirthDate = birthDate
                };
                context.Children.Add(child);
                context.SaveChanges(); // получаем ChildId

                foreach (var noteId in medicalNoteIds)
                {
                    context.ChildMedicalNotes.Add(new ChildMedicalNote
                    {
                        ChildId = child.ChildId,
                        MedicalNoteId = noteId
                    });
                }
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateChild(Child child, List<int> medicalNoteIds)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Children
                .Include(c => c.ChildMedicalNotes)
                .FirstOrDefault(c => c.ChildId == child.ChildId);
            if (existing == null) return false;

            existing.FullName = child.FullName;
            existing.GenderId = child.GenderId;
            existing.BirthDate = child.BirthDate;

            // Обновляем медицинские заметки: удаляем старые, добавляем новые
            existing.ChildMedicalNotes.Clear();
            foreach (var noteId in medicalNoteIds)
            {
                existing.ChildMedicalNotes.Add(new ChildMedicalNote
                {
                    ChildId = child.ChildId,
                    MedicalNoteId = noteId
                });
            }

            context.SaveChanges();
            return true;
        }

        public bool DeleteChild(int childId)
        {
            using var context = _contextFactory.CreateDbContext();
            var child = context.Children.Find(childId);
            if (child == null) return false;
            context.Children.Remove(child);
            context.SaveChanges();
            return true;
        }

        public List<Gender> GetGenders()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Genders.ToList();
        }

        public List<MedicalNote> GetMedicalNotes()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.MedicalNotes.ToList();
        }
    }
}
```

---

## FILE 39: IChildService.cs

<a id='ichildservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ChildServices
{
    public interface IChildService
    {
        List<Child> GetChildrenByUserId(int userId);
        bool AddChild(int userId, string fullName, int genderId, DateOnly birthDate, List<int> medicalNoteIds);
        bool UpdateChild(Child child, List<int> medicalNoteIds);
        bool DeleteChild(int childId);
        List<Gender> GetGenders();
        List<MedicalNote> GetMedicalNotes();
    }
}
```

---

## CampAgency.WPF\Services\DialogServices

<a id='dialogservices'></a>

## FILE 40: DialogService.cs

<a id='dialogservice'></a>

```csharp
using System.Windows;

namespace CampAgency.WPF.Services.DialogServices
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message, string title = "Информация")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowError(string message, string title = "Ошибка")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool ShowConfirmation(string message, string title = "Подтверждение")
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
```

---

## FILE 41: IDialogService.cs

<a id='idialogservice'></a>

```csharp
namespace CampAgency.WPF.Services.DialogServices
{
    public interface IDialogService
    {
        void ShowMessage(string message, string title = "Информация");
        void ShowError(string message, string title = "Ошибка");
        bool ShowConfirmation(string message, string title = "Подтверждение");
    }
}
```

---

## CampAgency.WPF\Services\NavigationServices

<a id='navigationservices'></a>

## FILE 42: INavigationService.cs

<a id='inavigationservice'></a>

```csharp
using System.ComponentModel;

namespace CampAgency.WPF.Services.NavigationServices
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

## FILE 43: NavigationService.cs

<a id='navigationservice'></a>

```csharp
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CampAgency.WPF.Services.NavigationServices
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

## CampAgency.WPF\Services\ShiftServices

<a id='shiftservices'></a>

## FILE 44: IShiftCatalogService.cs

<a id='ishiftcatalogservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ShiftServices
{
    public interface IShiftCatalogService
    {
        List<Shift> GetShiftsWithFilters(int? regionId, int? campTypeId, DateOnly? startDateFrom, DateOnly? startDateTo, decimal? minPrice, decimal? maxPrice);
        List<Region> GetAllRegions();
        Shift? GetShiftById(int shiftId);
        List<CampType> GetCampTypes();
        //List<string> GetRegions();
        bool CreateBooking(int childId, int shiftId);
        List<Booking> GetBookingsByUserId(int userId);
    }
}
```

---

## FILE 45: IShiftService.cs

<a id='ishiftservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ShiftServices
{
    public interface IShiftService
    {
        List<Shift> GetShiftsByCampId(int campId);
        List<Camp> GetAllCamps();
        bool AddShift(int campId, DateOnly startDate, DateOnly endDate, int totalSeats, decimal price);
        bool UpdateShift(Shift shift);
        bool DeleteShift(int shiftId);
    }
}
```

---

## FILE 46: ShiftCatalogService.cs

<a id='shiftcatalogservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ShiftServices
{
    public class ShiftCatalogService : IShiftCatalogService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShiftCatalogService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Shift> GetShiftsWithFilters(int? regionId, int? campTypeId, DateOnly? startDateFrom, DateOnly? startDateTo, decimal? minPrice, decimal? maxPrice)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Shifts
                .Include(s => s.Camp)
                    .ThenInclude(c => c.CampType)
                .Include(s => s.Camp)
                    .ThenInclude(c => c.Region)
                .Where(s => s.StartDate >= DateOnly.FromDateTime(DateTime.Today) && s.AvailableSeats > 0);

            if (regionId.HasValue && regionId.Value > 0)
                query = query.Where(s => s.Camp.RegionId == regionId.Value);
            if (campTypeId.HasValue && campTypeId.Value > 0)
                query = query.Where(s => s.Camp.CampTypeId == campTypeId.Value);
            if (startDateFrom.HasValue)
                query = query.Where(s => s.StartDate >= startDateFrom.Value);
            if (startDateTo.HasValue)
                query = query.Where(s => s.StartDate <= startDateTo.Value);
            if (minPrice.HasValue)
                query = query.Where(s => s.Price >= minPrice.Value);
            if (maxPrice.HasValue)
                query = query.Where(s => s.Price <= maxPrice.Value);

            return query.OrderBy(s => s.StartDate).ToList();
        }

        public List<Region> GetAllRegions()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Regions.OrderBy(r => r.RegionName).ToList();
        }

        public Shift? GetShiftById(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Shifts
                .Include(s => s.Camp)
                .ThenInclude(c => c.CampType)
                .FirstOrDefault(s => s.ShiftId == shiftId);
        }

        public List<CampType> GetCampTypes()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CampTypes.ToList();
        }

        //public List<string> GetRegions()
        //{
        //    using var context = _contextFactory.CreateDbContext();
        //    return context.Camps
        //        .Where(c => c.Region != null)
        //        .Select(c => c.Region!)
        //        .Distinct()
        //        .OrderBy(r => r)
        //        .ToList();
        //}

        public bool CreateBooking(int childId, int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var shift = context.Shifts.Find(shiftId);
                if (shift == null || shift.AvailableSeats <= 0) return false;

                // Проверяем, не забронировано ли уже на этого ребёнка эту смену
                var existing = context.Bookings.FirstOrDefault(b => b.ChildId == childId && b.ShiftId == shiftId);
                if (existing != null) return false;

                var bookingStatus = context.BookingStatuses.FirstOrDefault(bs => bs.BookingStatusName == "Ожидает подтверждения");
                if (bookingStatus == null) return false;

                var booking = new Booking
                {
                    ChildId = childId,
                    ShiftId = shiftId,
                    BookingStatusId = bookingStatus.BookingStatusId,
                    CreatedAt = DateTime.Now
                };
                context.Bookings.Add(booking);
                shift.AvailableSeats--;
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public List<Booking> GetBookingsByUserId(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Bookings
                .Include(b => b.Child)
                .Include(b => b.Shift)
                .ThenInclude(s => s.Camp)
                .Include(b => b.BookingStatus)
                .Where(b => b.Child.UserId == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToList();
        }
    }
}
```

---

## FILE 47: ShiftService.cs

<a id='shiftservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ShiftServices
{
    public class ShiftService : IShiftService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShiftService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Shift> GetShiftsByCampId(int campId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Shifts
                .Include(s => s.Camp)
                .Where(s => s.CampId == campId)
                .OrderBy(s => s.StartDate)
                .ToList();
        }

        public List<Camp> GetAllCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Camps.OrderBy(c => c.CampName).ToList();
        }

        public bool AddShift(int campId, DateOnly startDate, DateOnly endDate, int totalSeats, decimal price)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var shift = new Shift
                {
                    CampId = campId,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalSeats = totalSeats,
                    AvailableSeats = totalSeats,
                    Price = price
                };
                context.Shifts.Add(shift);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateShift(Shift shift)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Shifts.Find(shift.ShiftId);
            if (existing == null) return false;
            existing.CampId = shift.CampId;
            existing.StartDate = shift.StartDate;
            existing.EndDate = shift.EndDate;
            existing.TotalSeats = shift.TotalSeats;
            existing.Price = shift.Price;
            context.SaveChanges();
            return true;
        }

        public bool DeleteShift(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            var shift = context.Shifts.Find(shiftId);
            if (shift == null) return false;
            context.Shifts.Remove(shift);
            context.SaveChanges();
            return true;
        }
    }
}
```

---

## CampAgency.WPF\Services\UserServices

<a id='userservices'></a>

## FILE 48: IUserService.cs

<a id='iuserservice'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.UserServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        List<User> GetUsersByRole(string roleName);
        List<UserRole> GetAllRoles();
        User? GetUserById(int userId);
        bool AddUser(string login, string password, string fullName, string phone, string email, int roleId);
        bool UpdateUser(User user);
        bool ResetPassword(int userId, string newPassword);
        bool DeleteUser(int userId);
        bool IsLoginUnique(string login, int? excludeUserId = null);
    }
}
```

---

## FILE 49: UserService.cs

<a id='userservice'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<User> GetAllUsers()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole).ToList();
        }

        public List<User> GetUsersByRole(string roleName)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole)
                .Where(u => u.UserRole.RoleName == roleName)
                .ToList();
        }

        public List<UserRole> GetAllRoles()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.UserRoles.ToList();
        }

        public User? GetUserById(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.UserId == userId);
        }

        public bool AddUser(string login, string password, string fullName, string phone, string email, int roleId)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var user = new User
                {
                    Login = login,
                    PasswordHash = password, // TODO: хеширование
                    FullName = fullName,
                    Phone = phone,
                    Email = email,
                    UserRoleId = roleId
                };
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateUser(User user)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Users.Find(user.UserId);
            if (existing == null) return false;
            existing.FullName = user.FullName;
            existing.Phone = user.Phone;
            existing.Email = user.Email;
            existing.UserRoleId = user.UserRoleId;
            // Логин и пароль не меняем через этот метод
            context.SaveChanges();
            return true;
        }

        public bool ResetPassword(int userId, string newPassword)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.Users.Find(userId);
            if (user == null) return false;
            user.PasswordHash = newPassword; // TODO: хеширование
            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.Users.Find(userId);
            if (user == null) return false;
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }

        public bool IsLoginUnique(string login, int? excludeUserId = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Users.Where(u => u.Login == login);
            if (excludeUserId.HasValue)
                query = query.Where(u => u.UserId != excludeUserId.Value);
            return !query.Any();
        }
    }
}
```

---

## CampAgency.WPF\ViewModels

<a id='viewmodels'></a>

## FILE 50: MainWindowViewModel.cs

<a id='mainwindowviewmodel'></a>

```csharp
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.NavigationServices;
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

## FILE 51: AdminDashboardViewModel.cs

<a id='admindashboardviewmodel'></a>

```csharp
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class AdminDashboardViewModel : ObservableObject
    {
        private readonly INavigationService _navigation;
        public INavigationService NavigationService { get => _navigation; }

        public AdminDashboardViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            // При открытии дашборда сразу показываем список лагерей
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand]
        private void ShowCamps()
        {
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand]
        private void ShowShifts()
        {
            // TODO: создать ShiftsListViewModel и зарегистрировать
            _navigation.NavigateTo<ShiftsListViewModel>();
        }

        [RelayCommand]
        private void ShowUsers()
        {
            // TODO: создать UsersListViewModel и зарегистрировать
            _navigation.NavigateTo<UsersListViewModel>();
        }
    }
}
```

---

## FILE 52: CampEditViewModel.cs

<a id='campeditviewmodel'></a>

```csharp
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private string _campName = string.Empty;
        [ObservableProperty] private string _address = string.Empty;
        [ObservableProperty] private string _contactPhone = string.Empty;
        [ObservableProperty] private string _description = string.Empty;
        [ObservableProperty] private double? _rating;
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private CampType? _selectedCampType;
        [ObservableProperty] private ObservableCollection<Region> _regions = new();
        [ObservableProperty] private Region? _selectedRegion;

        private Camp? _currentCamp;
        private bool _isNew;

        public CampEditViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation, IDialogService dialogService)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadLookups();
            if (parameter is Camp camp)
            {
                _currentCamp = camp;
                _isNew = false;
                CampName = camp.CampName;
                Address = camp.Address ?? string.Empty;
                ContactPhone = camp.ContactPhone ?? string.Empty;
                Description = camp.Description ?? string.Empty;
                Rating = (double?)camp.Rating;
                SelectedCampType = camp.CampType;
                SelectedRegion = camp.Region;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                CampName = string.Empty;
                Address = string.Empty;
                ContactPhone = string.Empty;
                Description = string.Empty;
                Rating = null;
                SelectedCampType = null;
                SelectedRegion = null;
            }
        }

        private void LoadLookups()
        {
            using var context = _contextFactory.CreateDbContext();
            CampTypes = new ObservableCollection<CampType>(context.CampTypes.ToList());
            Regions = new ObservableCollection<Region>(context.Regions.OrderBy(r => r.RegionName).ToList());
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(CampName))
            {
                _dialogService.ShowError("Название лагеря обязательно для заполнения", "Ошибка");
                return;
            }
            if (SelectedCampType == null)
            {
                _dialogService.ShowError("Выберите тип учреждения", "Ошибка");
                return;
            }
            if (Rating.HasValue && (Rating.Value < 0 || Rating.Value > 5))
            {
                _dialogService.ShowError("Рейтинг должен быть в диапазоне от 0 до 5", "Ошибка");
                return;
            }

            using var context = _contextFactory.CreateDbContext();

            if (_isNew)
            {
                var newCamp = new Camp
                {
                    CampName = CampName,
                    Address = string.IsNullOrWhiteSpace(Address) ? null : Address,
                    ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone,
                    Description = string.IsNullOrWhiteSpace(Description) ? null : Description,
                    Rating = Rating.HasValue ? (decimal?)Rating.Value : null,
                    CampTypeId = SelectedCampType.CampTypeId,
                    RegionId = SelectedRegion?.RegionId
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                var campToUpdate = context.Camps.Find(_currentCamp!.CampId);
                if (campToUpdate != null)
                {
                    campToUpdate.CampName = CampName;
                    campToUpdate.Address = string.IsNullOrWhiteSpace(Address) ? null : Address;
                    campToUpdate.ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone;
                    campToUpdate.Description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                    campToUpdate.Rating = Rating.HasValue ? (decimal?)Rating.Value : null;
                    campToUpdate.CampTypeId = SelectedCampType.CampTypeId;
                    campToUpdate.RegionId = SelectedRegion?.RegionId;
                }
            }

            context.SaveChanges();
            _dialogService.ShowMessage(_isNew ? "Лагерь успешно добавлен" : "Данные лагеря обновлены", "Успех");
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<CampsListViewModel>();
    }
}
```

---

## FILE 53: CampsListViewModel.cs

<a id='campslistviewmodel'></a>

```csharp
using System.Collections.ObjectModel;
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampsListViewModel : ObservableObject
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();

        public CampsListViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation, IDialogService dialogService)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            _dialogService = dialogService;
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

            if (!_dialogService.ShowConfirmation($"Вы уверены, что хотите удалить лагерь \"{camp.CampName}\"?", "Удаление лагеря"))
                return;

            using var context = _contextFactory.CreateDbContext();
            var existing = context.Camps.Find(camp.CampId);
            if (existing != null)
            {
                context.Camps.Remove(existing);
                context.SaveChanges();
                LoadCamps();
                _dialogService.ShowMessage("Лагерь успешно удалён", "Успех");
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}
```

---

## FILE 54: ShiftEditViewModel.cs

<a id='shifteditviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class ShiftEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IShiftService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();
        [ObservableProperty] private Camp? _selectedCamp;
        [ObservableProperty] private DateTime? _startDate;
        [ObservableProperty] private DateTime? _endDate;
        [ObservableProperty] private int _totalSeats = 1;
        [ObservableProperty] private decimal _price;

        private Shift? _currentShift;
        private bool _isNew;

        public ShiftEditViewModel(IShiftService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadCamps();

            if (parameter is (Camp camp, Shift shift)) // кортеж
            {
                if (shift != null)
                {
                    _currentShift = shift;
                    _isNew = false;
                    SelectedCamp = shift.Camp;
                    StartDate = shift.StartDate.ToDateTime(TimeOnly.MinValue);
                    EndDate = shift.EndDate.ToDateTime(TimeOnly.MinValue);
                    TotalSeats = shift.TotalSeats;
                    Price = shift.Price;
                }
                else
                {
                    _currentShift = null;
                    _isNew = true;
                    SelectedCamp = camp;
                    StartDate = null;
                    EndDate = null;
                    TotalSeats = 1;
                    Price = 0;
                }
            }
            else
            {
                _isNew = true;
                SelectedCamp = null;
                StartDate = null;
                EndDate = null;
                TotalSeats = 1;
                Price = 0;
            }
        }

        private void LoadCamps()
        {
            var list = _shiftService.GetAllCamps();
            Camps = new ObservableCollection<Camp>(list);
        }

        [RelayCommand]
        private void Save()
        {
            if (SelectedCamp == null)
            {
                _dialogService.ShowError("Выберите лагерь", "Ошибка");
                return;
            }
            if (StartDate == null || EndDate == null)
            {
                _dialogService.ShowError("Укажите даты начала и окончания смены", "Ошибка");
                return;
            }
            if (StartDate >= EndDate)
            {
                _dialogService.ShowError("Дата начала должна быть раньше даты окончания", "Ошибка");
                return;
            }
            if (TotalSeats <= 0)
            {
                _dialogService.ShowError("Количество мест должно быть больше 0", "Ошибка");
                return;
            }
            if (Price < 0)
            {
                _dialogService.ShowError("Стоимость не может быть отрицательной", "Ошибка");
                return;
            }

            var startDateOnly = DateOnly.FromDateTime(StartDate.Value);
            var endDateOnly = DateOnly.FromDateTime(EndDate.Value);

            bool success;
            if (_isNew)
            {
                success = _shiftService.AddShift(SelectedCamp.CampId, startDateOnly, endDateOnly, TotalSeats, Price);
                if (success) _dialogService.ShowMessage("Смена добавлена", "Успех");
            }
            else
            {
                _currentShift!.CampId = SelectedCamp.CampId;
                _currentShift.StartDate = startDateOnly;
                _currentShift.EndDate = endDateOnly;
                _currentShift.TotalSeats = TotalSeats;
                _currentShift.Price = Price;
                success = _shiftService.UpdateShift(_currentShift);
                if (success) _dialogService.ShowMessage("Смена обновлена", "Успех");
            }

            if (success)
                _navigation.NavigateTo<ShiftsListViewModel>();
            else
                _dialogService.ShowError("Ошибка сохранения", "Ошибка");
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<ShiftsListViewModel>();
    }
}
```

---

## FILE 55: ShiftsListViewModel.cs

<a id='shiftslistviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class ShiftsListViewModel : ObservableObject
    {
        private readonly IShiftService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();
        [ObservableProperty] private Camp? _selectedCamp;
        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();

        public ShiftsListViewModel(IShiftService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadCamps();
        }

        private void LoadCamps()
        {
            var list = _shiftService.GetAllCamps();
            Camps = new ObservableCollection<Camp>(list);
            if (Camps.Any())
                SelectedCamp = Camps.First();
        }

        partial void OnSelectedCampChanged(Camp? value)
        {
            if (value != null)
                LoadShifts(value.CampId);
            else
                Shifts.Clear();
        }

        private void LoadShifts(int campId)
        {
            var list = _shiftService.GetShiftsByCampId(campId);
            Shifts = new ObservableCollection<Shift>(list);
        }

        [RelayCommand]
        private void AddShift()
        {
            if (SelectedCamp == null)
            {
                _dialogService.ShowError("Сначала выберите лагерь", "Ошибка");
                return;
            }
            _navigation.NavigateTo<ShiftEditViewModel>((SelectedCamp, (Shift?)null));
        }

        [RelayCommand]
        private void EditShift(Shift shift)
        {
            if (shift == null) return;
            _navigation.NavigateTo<ShiftEditViewModel>((shift.Camp, shift));
        }

        [RelayCommand]
        private void DeleteShift(Shift shift)
        {
            if (shift == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить смену с {shift.StartDate:dd.MM.yyyy} по {shift.EndDate:dd.MM.yyyy}?", "Удаление"))
                return;

            var success = _shiftService.DeleteShift(shift.ShiftId);
            if (success)
            {
                _dialogService.ShowMessage("Смена удалена", "Успех");
                if (SelectedCamp != null)
                    LoadShifts(SelectedCamp.CampId);
            }
            else
            {
                _dialogService.ShowError("Не удалось удалить смену", "Ошибка");
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}
```

---

## FILE 56: UserEditViewModel.cs

<a id='usereditviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class UserEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<UserRole> _roles = new();
        [ObservableProperty] private UserRole? _selectedRole;
        [ObservableProperty] private string _login = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _confirmPassword = string.Empty;
        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private string _phone = string.Empty;
        [ObservableProperty] private string _email = string.Empty;

        private User? _currentUser;
        private bool _isNew;

        public UserEditViewModel(IUserService userService, INavigationService navigation, IDialogService dialogService)
        {
            _userService = userService;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadRoles();
            if (parameter is User user)
            {
                _currentUser = user;
                _isNew = false;
                Login = user.Login;
                FullName = user.FullName;
                Phone = user.Phone ?? string.Empty;
                Email = user.Email ?? string.Empty;
                SelectedRole = user.UserRole;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
            else
            {
                _currentUser = null;
                _isNew = true;
                Login = string.Empty;
                FullName = string.Empty;
                Phone = string.Empty;
                Email = string.Empty;
                SelectedRole = null;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
        }

        private void LoadRoles()
        {
            var list = _userService.GetAllRoles();
            Roles = new ObservableCollection<UserRole>(list);
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                _dialogService.ShowError("Введите полное имя", "Ошибка");
                return;
            }
            if (SelectedRole == null)
            {
                _dialogService.ShowError("Выберите роль", "Ошибка");
                return;
            }
            if (_isNew)
            {
                if (string.IsNullOrWhiteSpace(Login))
                {
                    _dialogService.ShowError("Введите логин", "Ошибка");
                    return;
                }
                if (!_userService.IsLoginUnique(Login))
                {
                    _dialogService.ShowError("Логин уже существует", "Ошибка");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    _dialogService.ShowError("Введите пароль", "Ошибка");
                    return;
                }
                if (Password != ConfirmPassword)
                {
                    _dialogService.ShowError("Пароли не совпадают", "Ошибка");
                    return;
                }
                var success = _userService.AddUser(Login, Password, FullName, Phone, Email, SelectedRole.UserRoleId);
                if (success)
                    _dialogService.ShowMessage("Пользователь добавлен", "Успех");
                else
                {
                    _dialogService.ShowError("Ошибка добавления", "Ошибка");
                    return;
                }
            }
            else
            {
                // Обновляем только поля, которые можно менять
                _currentUser!.FullName = FullName;
                _currentUser.Phone = string.IsNullOrWhiteSpace(Phone) ? null : Phone;
                _currentUser.Email = string.IsNullOrWhiteSpace(Email) ? null : Email;
                _currentUser.UserRoleId = SelectedRole.UserRoleId;
                var success = _userService.UpdateUser(_currentUser);
                if (success)
                    _dialogService.ShowMessage("Данные обновлены", "Успех");
                else
                {
                    _dialogService.ShowError("Ошибка обновления", "Ошибка");
                    return;
                }
            }
            _navigation.NavigateTo<UsersListViewModel>();
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<UsersListViewModel>();
    }
}
```

---

## FILE 57: UsersListViewModel.cs

<a id='userslistviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class UsersListViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<User> _users = new();
        [ObservableProperty] private ObservableCollection<UserRole> _roles = new();
        [ObservableProperty] private UserRole? _selectedRoleFilter;
        [ObservableProperty] private string _searchText = string.Empty;

        public UsersListViewModel(IUserService userService, INavigationService navigation, IDialogService dialogService)
        {
            _userService = userService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            var list = _userService.GetAllRoles();
            Roles = new ObservableCollection<UserRole>(list);
            // Добавляем "Все" как null-фильтр
            Roles.Insert(0, new UserRole { UserRoleId = 0, RoleName = "Все" });
            SelectedRoleFilter = Roles.FirstOrDefault();
        }

        private void LoadUsers()
        {
            if (SelectedRoleFilter == null || SelectedRoleFilter.UserRoleId == 0)
                Users = new ObservableCollection<User>(_userService.GetAllUsers());
            else
                Users = new ObservableCollection<User>(_userService.GetUsersByRole(SelectedRoleFilter.RoleName));
        }

        partial void OnSelectedRoleFilterChanged(UserRole? value)
        {
            LoadUsers();
        }

        [RelayCommand]
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadUsers();
                return;
            }
            var all = _userService.GetAllUsers();
            var filtered = all.Where(u => u.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                          u.Login.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                          (u.Email?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ?? false))
                              .ToList();
            Users = new ObservableCollection<User>(filtered);
        }

        [RelayCommand]
        private void AddUser() => _navigation.NavigateTo<UserEditViewModel>(null);

        [RelayCommand]
        private void EditUser(User user) => _navigation.NavigateTo<UserEditViewModel>(user);

        [RelayCommand]
        private void ResetPassword(User user)
        {
            if (user == null) return;
            string newPassword = "Pass123!"; // временный пароль
            if (_dialogService.ShowConfirmation($"Сбросить пароль пользователю {user.FullName}? Новый пароль: {newPassword}", "Сброс пароля"))
            {
                if (_userService.ResetPassword(user.UserId, newPassword))
                    _dialogService.ShowMessage($"Пароль сброшен. Новый пароль: {newPassword}", "Успех");
                else
                    _dialogService.ShowError("Не удалось сбросить пароль", "Ошибка");
            }
        }

        [RelayCommand]
        private void DeleteUser(User user)
        {
            if (user == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить пользователя {user.FullName} (логин {user.Login})?", "Удаление"))
                return;
            var success = _userService.DeleteUser(user.UserId);
            if (success)
            {
                _dialogService.ShowMessage("Пользователь удалён", "Успех");
                LoadUsers();
            }
            else
                _dialogService.ShowError("Не удалось удалить пользователя", "Ошибка");
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}
```

---

## CampAgency.WPF\ViewModels\Auth

<a id='auth'></a>

## FILE 58: LoginViewModel.cs

<a id='loginviewmodel'></a>

```csharp
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.NavigationServices;
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

## FILE 59: RegisterViewModel.cs

<a id='registerviewmodel'></a>

```csharp
using CampAgency.WPF.Services;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Auth
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IRegistrationService _registrationService;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private string _login = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _confirmPassword = string.Empty;
        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private string _phone = string.Empty;
        [ObservableProperty] private string _email = string.Empty;
        [ObservableProperty] private string _errorMessage = string.Empty;

        public RegisterViewModel(IRegistrationService registrationService,
                                 INavigationService navigationService,
                                 IDialogService dialogService)
        {
            _registrationService = registrationService;
            _navigationService = navigationService;
            _dialogService = dialogService;
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
                _dialogService.ShowMessage(message, "Успех");
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

## FILE 60: OperatorDashboardViewModel.cs

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

## FILE 61: ChildEditViewModel.cs

<a id='childeditviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IChildService _childService;
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private DateTime? _birthDate;
        [ObservableProperty] private ObservableCollection<Gender> _genders = new();
        [ObservableProperty] private Gender? _selectedGender;
        [ObservableProperty] private ObservableCollection<MedicalNoteWrapper> _medicalNoteWrappers = new();

        private Child? _currentChild;
        private bool _isNew = true;

        public ChildEditViewModel(IChildService childService, IAuthService authService, IDialogService dialogService, INavigationService navigationService)
        {
            _childService = childService;
            _authService = authService;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadLookups();

            if (parameter is Child child)
            {
                _currentChild = child;
                _isNew = false;
                FullName = child.FullName;
                BirthDate = child.BirthDate.ToDateTime(TimeOnly.MinValue);
                SelectedGender = child.Gender;

                // Отмечаем выбранные медицинские заметки
                var existingMedicalNoteIds = child.ChildMedicalNotes.Select(cmn => cmn.MedicalNoteId).ToHashSet();
                foreach (var wrapper in MedicalNoteWrappers)
                {
                    wrapper.IsSelected = existingMedicalNoteIds.Contains(wrapper.MedicalNote.MedicalNoteId);
                }
            }
            else
            {
                _currentChild = null;
                _isNew = true;
                FullName = string.Empty;
                BirthDate = null;
                SelectedGender = null;
                foreach (var wrapper in MedicalNoteWrappers)
                    wrapper.IsSelected = false;
            }
        }

        private void LoadLookups()
        {
            Genders = new ObservableCollection<Gender>(_childService.GetGenders());
            var notes = _childService.GetMedicalNotes();
            MedicalNoteWrappers = new ObservableCollection<MedicalNoteWrapper>(
                notes.Select(n => new MedicalNoteWrapper { MedicalNote = n, IsSelected = false }));
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(FullName) || SelectedGender == null || BirthDate == null)
            {
                _dialogService.ShowError("Заполните ФИО, пол и дату рождения", "Ошибка");
                return;
            }

            var birthDateOnly = DateOnly.FromDateTime(BirthDate.Value);
            var selectedNoteIds = MedicalNoteWrappers.Where(w => w.IsSelected).Select(w => w.MedicalNote.MedicalNoteId).ToList();

            bool success;
            if (_isNew)
            {
                success = _childService.AddChild(_authService.CurrentUser!.UserId, FullName, SelectedGender.GenderId, birthDateOnly, selectedNoteIds);
                if (success) _dialogService.ShowMessage("Ребёнок успешно добавлен", "Успех");
            }
            else
            {
                _currentChild!.FullName = FullName;
                _currentChild.GenderId = SelectedGender.GenderId;
                _currentChild.BirthDate = birthDateOnly;
                success = _childService.UpdateChild(_currentChild, selectedNoteIds);
                if (success) _dialogService.ShowMessage("Данные обновлены", "Успех");
            }

            if (success)
                _navigationService.NavigateTo<ChildListViewModel>();
            else
                _dialogService.ShowError("Ошибка сохранения", "Ошибка");
        }

        [RelayCommand]
        private void Cancel() => _navigationService.NavigateTo<ChildListViewModel>();
    }
}
```

---

## FILE 62: ChildListViewModel.cs

<a id='childlistviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildListViewModel : ObservableObject
    {
        private readonly IChildService _childService;
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private ObservableCollection<Child> _children = new();

        public ChildListViewModel(IChildService childService, IAuthService authService, IDialogService dialogService, INavigationService navigationService)
        {
            _childService = childService;
            _authService = authService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            LoadChildren();
        }

        private void LoadChildren()
        {
            if (_authService.CurrentUser == null) return;
            var list = _childService.GetChildrenByUserId(_authService.CurrentUser.UserId);
            Children = new ObservableCollection<Child>(list);
        }

        [RelayCommand]
        private void AddChild() => _navigationService.NavigateTo<ChildEditViewModel>(null);

        [RelayCommand]
        private void EditChild(Child child) => _navigationService.NavigateTo<ChildEditViewModel>(child);

        [RelayCommand]
        private void BackToDashboard() => _navigationService.NavigateTo<ParentDashboardViewModel>();

        [RelayCommand]
        private async Task DeleteChild(Child child)
        {
            if (child == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить данные о ребёнке \"{child.FullName}\"?", "Удаление"))
                return;

            var success = _childService.DeleteChild(child.ChildId);
            if (success)
            {
                _dialogService.ShowMessage("Ребёнок удалён", "Успех");
                LoadChildren();
            }
            else
            {
                _dialogService.ShowError("Не удалось удалить ребёнка", "Ошибка");
            }
        }
    }
}
```

---

## FILE 63: MedicalNoteWrapper.cs

<a id='medicalnotewrapper'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CampAgency.WPF.ViewModels.Parent
{
    public class MedicalNoteWrapper : ObservableObject
    {
        public MedicalNote MedicalNote { get; set; } = null!;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
```

---

## FILE 64: MyBookingsViewModel.cs

<a id='mybookingsviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class MyBookingsViewModel : ObservableObject
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;
        private readonly IAuthService _authService;

        [ObservableProperty] private ObservableCollection<Booking> _bookings = new();

        public MyBookingsViewModel(IShiftCatalogService shiftService, INavigationService navigation, IDialogService dialogService, IAuthService authService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            _authService = authService;
            LoadBookings();
        }

        private void LoadBookings()
        {
            var currentUserId = _authService.CurrentUser?.UserId;
            if (currentUserId.HasValue)
            {
                var list = _shiftService.GetBookingsByUserId(currentUserId.Value);
                Bookings = new ObservableCollection<Booking>(list);
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<ParentDashboardViewModel>();
    }
}
```

---

## FILE 65: ParentDashboardViewModel.cs

<a id='parentdashboardviewmodel'></a>

```csharp
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ParentDashboardViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public ParentDashboardViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.NavigateTo<ChildListViewModel>(); // по умолчанию дети
        }

        [RelayCommand] private void ShowChildren() => _navigationService.NavigateTo<ChildListViewModel>();
        [RelayCommand] private void ShowShiftsCatalog() => _navigationService.NavigateTo<ShiftsCatalogViewModel>();
        [RelayCommand] private void ShowMyBookings() => _navigationService.NavigateTo<MyBookingsViewModel>();
    }
}
```

---

## FILE 66: ShiftDetailsViewModel.cs

<a id='shiftdetailsviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ShiftDetailsViewModel : ObservableObject, INavigationAware
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly IChildService _childService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;
        private readonly IAuthService _authService;

        [ObservableProperty] private Shift? _shift;
        [ObservableProperty] private ObservableCollection<Child> _myChildren = new();
        [ObservableProperty] private Child? _selectedChild;
        [ObservableProperty] private bool _isBookingInProgress;

        public ShiftDetailsViewModel(IShiftCatalogService shiftService, IChildService childService, INavigationService navigation, IDialogService dialogService, IAuthService authService)
        {
            _shiftService = shiftService;
            _childService = childService;
            _navigation = navigation;
            _dialogService = dialogService;
            _authService = authService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is int shiftId)
            {
                _shift = _shiftService.GetShiftById(shiftId);
                OnPropertyChanged(nameof(Shift));
                LoadChildren();
            }
        }

        private void LoadChildren()
        {
            if (_shift == null) return;
            // Предполагаем, что в AuthService есть CurrentUser
            var currentUserId = _authService.CurrentUser?.UserId;
            if (currentUserId.HasValue)
                MyChildren = new ObservableCollection<Child>(_childService.GetChildrenByUserId(currentUserId.Value));
        }

        [RelayCommand]
        private async Task BookShift()
        {
            if (_shift == null) return;
            if (SelectedChild == null)
            {
                _dialogService.ShowError("Выберите ребёнка для бронирования", "Ошибка");
                return;
            }
            if (!_dialogService.ShowConfirmation($"Забронировать смену в {_shift.Camp.CampName} для {SelectedChild.FullName}? Стоимость: {_shift.Price:C}", "Подтверждение бронирования"))
                return;

            IsBookingInProgress = true;
            try
            {
                var success = _shiftService.CreateBooking(SelectedChild.ChildId, _shift.ShiftId);
                if (success)
                {
                    _dialogService.ShowMessage("Бронирование создано. Статус: Ожидает подтверждения", "Успех");
                    _navigation.NavigateTo<ShiftsCatalogViewModel>();
                }
                else
                {
                    _dialogService.ShowError("Не удалось забронировать. Возможно, места уже закончились или ребёнок уже забронирован на эту смену.", "Ошибка");
                }
            }
            finally
            {
                IsBookingInProgress = false;
            }
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<ShiftsCatalogViewModel>();
    }
}
```

---

## FILE 67: ShiftsCatalogViewModel.cs

<a id='shiftscatalogviewmodel'></a>

```csharp
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ShiftsCatalogViewModel : ObservableObject
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private ObservableCollection<Region> _regions = new();


        // Фильтры
        [ObservableProperty] private Region? _selectedRegion;
        [ObservableProperty] private CampType? _selectedCampType;
        [ObservableProperty] private DateTime? _startDateFrom;
        [ObservableProperty] private DateTime? _startDateTo;
        [ObservableProperty] private string? _minPriceStr;
        [ObservableProperty] private string? _maxPriceStr;

        public ShiftsCatalogViewModel(IShiftCatalogService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadFilters();
            LoadShifts();
        }

        private void LoadFilters()
        {
            CampTypes = new ObservableCollection<CampType>(_shiftService.GetCampTypes());
            var regionList = _shiftService.GetAllRegions();
            Regions = new ObservableCollection<Region>(regionList);
        }

        private void LoadShifts()
        {
            decimal? minPrice = null, maxPrice = null;
            if (!string.IsNullOrWhiteSpace(MinPriceStr) && decimal.TryParse(MinPriceStr, out var min))
                minPrice = min;
            if (!string.IsNullOrWhiteSpace(MaxPriceStr) && decimal.TryParse(MaxPriceStr, out var max))
                maxPrice = max;

            DateOnly? fromDate = StartDateFrom.HasValue ? DateOnly.FromDateTime(StartDateFrom.Value) : null;
            DateOnly? toDate = StartDateTo.HasValue ? DateOnly.FromDateTime(StartDateTo.Value) : null;

            var list = _shiftService.GetShiftsWithFilters(
                SelectedRegion?.RegionId,
                SelectedCampType?.CampTypeId,
                fromDate,
                toDate,
                minPrice,
                maxPrice
            );
            Shifts = new ObservableCollection<Shift>(list);
        }

        [RelayCommand]
        private void ApplyFilters() => LoadShifts();

        [RelayCommand]
        private void ResetFilters()
        {
            SelectedRegion = null;
            SelectedCampType = null;
            StartDateFrom = null;
            StartDateTo = null;
            MinPriceStr = null;
            MaxPriceStr = null;
            LoadShifts();
        }

        [RelayCommand]
        private void ViewShiftDetails(Shift shift)
        {
            if (shift != null)
                _navigation.NavigateTo<ShiftDetailsViewModel>(shift.ShiftId);
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<ParentDashboardViewModel>();
    }
}
```

---

## CampAgency.WPF\Views\Admin

<a id='admin'></a>

## FILE 68: AdminDashboardView.xaml

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

        <TextBlock Grid.Row="0" Text="Панель администратора" 
                   FontSize="24" FontWeight="Bold" Margin="0,0,0,20"/>

        <!-- Кнопки меню с привязкой команд -->
        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Content="Управление лагерями" Command="{Binding ShowCampsCommand}" 
                    Width="150" Margin="5" Height="40"/>
            <Button Content="Управление сменами" Command="{Binding ShowShiftsCommand}" 
                    Width="150" Margin="5" Height="40"/>
            <Button Content="Пользователи" Command="{Binding ShowUsersCommand}" 
                    Width="150" Margin="5" Height="40"/>
        </StackPanel>

        <!-- Контент будет меняться через NavigationService -->
        <ContentControl Grid.Row="1" Content="{Binding _navigation.CurrentViewModel}" />
    </Grid>
</UserControl>
```

---

## FILE 69: AdminDashboardView.xaml.cs

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

## FILE 70: CampEditView.xaml

<a id='campeditview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.CampEditView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ScrollViewer VerticalScrollBarVisibility="Auto">
        <StackPanel Margin="20" Width="500">
            <TextBlock Text="Редактирование лагеря" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

            <TextBlock Text="Название*:" Margin="0,5"/>
            <TextBox Text="{Binding CampName}" Margin="0,5" Height="30"/>

            <TextBlock Text="Тип учреждения*:" Margin="0,10,0,5"/>
            <ComboBox ItemsSource="{Binding CampTypes}" SelectedItem="{Binding SelectedCampType}" 
                      DisplayMemberPath="CampTypeName" Margin="0,5" Height="30"/>

            <TextBlock Text="Регион:" Margin="0,10,0,5"/>
            <ComboBox ItemsSource="{Binding Regions}" SelectedItem="{Binding SelectedRegion}" 
                      DisplayMemberPath="RegionName" Margin="0,5" Height="30"/>

            <TextBlock Text="Адрес:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding Address}" Margin="0,5" Height="30"/>

            <TextBlock Text="Контактный телефон:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding ContactPhone}" Margin="0,5" Height="30"/>

            <TextBlock Text="Рейтинг (0-5):" Margin="0,10,0,5"/>
            <TextBox Text="{Binding Rating, StringFormat=N1}" Margin="0,5" Height="30"/>

            <TextBlock Text="Описание:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding Description}" Margin="0,5" Height="100" 
                     TextWrapping="Wrap" AcceptsReturn="True" VerticalScrollBarVisibility="Auto"/>

            <StackPanel Orientation="Horizontal" Margin="0,30,0,0" HorizontalAlignment="Right">
                <Button Content="Сохранить" Command="{Binding SaveCommand}" Width="120" Height="35" Margin="0,0,10,0"/>
                <Button Content="Отмена" Command="{Binding CancelCommand}" Width="120" Height="35"/>
            </StackPanel>
        </StackPanel>
    </ScrollViewer>
</UserControl>
```

---

## FILE 71: CampEditView.xaml.cs

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

## FILE 72: CampsListView.xaml

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
            <RowDefinition Height="Auto"/>
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
                <DataGridTextColumn Header="Тип" Binding="{Binding CampType.CampTypeName}" Width="120"/>
                <DataGridTextColumn Header="Регион" Binding="{Binding Region.RegionName}" Width="100"/>
                <DataGridTextColumn Header="Телефон" Binding="{Binding ContactPhone}" Width="120"/>
                <DataGridTextColumn Header="Рейтинг" Binding="{Binding Rating}" Width="70"/>
                <DataGridTemplateColumn Header="Действия" Width="120">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="✏️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.EditCampCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                                <Button Content="🗑️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.DeleteCampCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>

        <!-- Кнопка назад -->
        <Button Grid.Row="3" Content="← Назад" Command="{Binding BackToDashboardCommand}" 
                Width="120" Height="30" HorizontalAlignment="Left" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 73: CampsListView.xaml.cs

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

## FILE 74: ShiftEditView.xaml

<a id='shifteditview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.ShiftEditView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel Margin="20" Width="400">
        <TextBlock Text="Добавление / редактирование смены" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

        <TextBlock Text="Лагерь:" Margin="0,5"/>
        <ComboBox ItemsSource="{Binding Camps}" SelectedItem="{Binding SelectedCamp}" 
                  DisplayMemberPath="CampName" Margin="0,5" Height="30"/>

        <TextBlock Text="Дата начала:" Margin="0,10,0,5"/>
        <DatePicker SelectedDate="{Binding StartDate}" Margin="0,5" Height="30"/>

        <TextBlock Text="Дата окончания:" Margin="0,10,0,5"/>
        <DatePicker SelectedDate="{Binding EndDate}" Margin="0,5" Height="30"/>

        <TextBlock Text="Количество мест:" Margin="0,10,0,5"/>
        <TextBox Text="{Binding TotalSeats}" Margin="0,5" Height="30"/>

        <TextBlock Text="Стоимость путёвки:" Margin="0,10,0,5"/>
        <TextBox Text="{Binding Price}" Margin="0,5" Height="30"/>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Margin="0,30,0,0">
            <Button Content="Сохранить" Command="{Binding SaveCommand}" Width="100" Height="35" Margin="0,0,10,0"/>
            <Button Content="Отмена" Command="{Binding CancelCommand}" Width="100" Height="35"/>
        </StackPanel>
    </StackPanel>
</UserControl>
```

---

## FILE 75: ShiftEditView.xaml.cs

<a id='shifteditviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для ShiftEditView.xaml
    /// </summary>
    public partial class ShiftEditView : UserControl
    {
        public ShiftEditView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 76: ShiftsListView.xaml

<a id='shiftslistview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.ShiftsListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Управление сменами" FontSize="20" FontWeight="Bold" Margin="0,0,0,10"/>

        <StackPanel Grid.Row="1" Orientation="Horizontal" Margin="0,0,0,10">
            <TextBlock Text="Лагерь:" VerticalAlignment="Center" Margin="0,0,10,0"/>
            <ComboBox ItemsSource="{Binding Camps}" SelectedItem="{Binding SelectedCamp}" 
                      DisplayMemberPath="CampName" Width="250" Height="30" Margin="0,0,20,0"/>
            <Button Content="+ Добавить смену" Command="{Binding AddShiftCommand}" Width="150" Height="30"/>
        </StackPanel>

        <DataGrid Grid.Row="2" ItemsSource="{Binding Shifts}" AutoGenerateColumns="False" 
                  CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Начало" Binding="{Binding StartDate, StringFormat=dd.MM.yyyy}" Width="100"/>
                <DataGridTextColumn Header="Окончание" Binding="{Binding EndDate, StringFormat=dd.MM.yyyy}" Width="100"/>
                <DataGridTextColumn Header="Мест" Binding="{Binding TotalSeats}" Width="80"/>
                <DataGridTextColumn Header="Цена" Binding="{Binding Price, StringFormat=C}" Width="120"/>
                <DataGridTemplateColumn Header="Действия" Width="120">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="✏️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.EditShiftCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                                <Button Content="🗑️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.DeleteShiftCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>

        <Button Grid.Row="3" Content="← Назад" Command="{Binding BackToDashboardCommand}" 
                Width="120" Height="30" HorizontalAlignment="Left" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 77: ShiftsListView.xaml.cs

<a id='shiftslistviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для ShiftsListView.xaml
    /// </summary>
    public partial class ShiftsListView : UserControl
    {
        public ShiftsListView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 78: UserEditView.xaml

<a id='usereditview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.UserEditView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ScrollViewer VerticalScrollBarVisibility="Auto">
        <StackPanel Margin="20" Width="450">
            <TextBlock Text="Добавление / редактирование пользователя" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

            <TextBlock Text="Логин*:" Margin="0,5"/>
            <TextBox Text="{Binding Login}" IsEnabled="{Binding IsNew}" Margin="0,5" Height="30"/>
            <TextBlock Text="(только при создании)" FontSize="10" Foreground="Gray" Margin="0,-5,0,5"/>

            <TextBlock Text="Пароль*:" Margin="0,10,0,5"/>
            <PasswordBox x:Name="PasswordBox" Margin="0,5" Height="30" IsEnabled="{Binding IsNew}"/>
            <TextBlock Text="(только при создании)" FontSize="10" Foreground="Gray" Margin="0,-5,0,5"/>

            <TextBlock Text="Подтверждение пароля*:" Margin="0,10,0,5"/>
            <PasswordBox x:Name="ConfirmPasswordBox" Margin="0,5" Height="30" IsEnabled="{Binding IsNew}"/>

            <TextBlock Text="Полное имя*:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding FullName}" Margin="0,5" Height="30"/>

            <TextBlock Text="Телефон:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding Phone}" Margin="0,5" Height="30"/>

            <TextBlock Text="Email:" Margin="0,10,0,5"/>
            <TextBox Text="{Binding Email}" Margin="0,5" Height="30"/>

            <TextBlock Text="Роль*:" Margin="0,10,0,5"/>
            <ComboBox ItemsSource="{Binding Roles}" SelectedItem="{Binding SelectedRole}" 
                      DisplayMemberPath="RoleName" Margin="0,5" Height="30"/>

            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Margin="0,30,0,0">
                <Button Content="Сохранить" Command="{Binding SaveCommand}" Width="100" Height="35" Margin="0,0,10,0"/>
                <Button Content="Отмена" Command="{Binding CancelCommand}" Width="100" Height="35"/>
            </StackPanel>
        </StackPanel>
    </ScrollViewer>
</UserControl>
```

---

## FILE 79: UserEditView.xaml.cs

<a id='usereditviewxaml'></a>

```csharp
using System.Windows;
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Admin
{
    public partial class UserEditView : UserControl
    {
        public UserEditView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.Admin.UserEditViewModel vm)
            {
                PasswordBox.PasswordChanged += (s, _) => vm.Password = PasswordBox.Password;
                ConfirmPasswordBox.PasswordChanged += (s, _) => vm.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }
    }
}
```

---

## FILE 80: UsersListView.xaml

<a id='userslistview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Admin.UsersListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Управление пользователями" FontSize="20" FontWeight="Bold" Margin="0,0,0,10"/>

        <!-- Фильтры и поиск -->
        <StackPanel Grid.Row="1" Orientation="Horizontal" Margin="0,0,0,10">
            <TextBlock Text="Роль:" VerticalAlignment="Center" Margin="0,0,10,0"/>
            <ComboBox ItemsSource="{Binding Roles}" SelectedItem="{Binding SelectedRoleFilter}" 
                      DisplayMemberPath="RoleName" Width="150" Height="30" Margin="0,0,20,0"/>
            <TextBlock Text="Поиск:" VerticalAlignment="Center" Margin="0,0,10,0"/>
            <TextBox Text="{Binding SearchText, UpdateSourceTrigger=PropertyChanged}" Width="200" Height="30" Margin="0,0,10,0"/>
            <Button Content="🔍 Найти" Command="{Binding SearchCommand}" Width="100" Height="30" Margin="0,0,20,0"/>
            <Button Content="+ Добавить пользователя" Command="{Binding AddUserCommand}" Width="180" Height="30"/>
        </StackPanel>

        <!-- Таблица пользователей -->
        <DataGrid Grid.Row="2" ItemsSource="{Binding Users}" AutoGenerateColumns="False" 
                  CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Логин" Binding="{Binding Login}" Width="120"/>
                <DataGridTextColumn Header="ФИО" Binding="{Binding FullName}" Width="*"/>
                <DataGridTextColumn Header="Телефон" Binding="{Binding Phone}" Width="100"/>
                <DataGridTextColumn Header="Email" Binding="{Binding Email}" Width="150"/>
                <DataGridTextColumn Header="Роль" Binding="{Binding UserRole.RoleName}" Width="100"/>
                <DataGridTemplateColumn Header="Действия" Width="180">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="✏️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.EditUserCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                                <Button Content="🔑 Сброс пароля" Margin="2" 
                                        Command="{Binding DataContext.ResetPasswordCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                                <Button Content="🗑️" Width="30" Margin="2" 
                                        Command="{Binding DataContext.DeleteUserCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" 
                                        CommandParameter="{Binding}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>

        <Button Grid.Row="3" Content="← Назад" Command="{Binding BackToDashboardCommand}" 
                Width="120" Height="30" HorizontalAlignment="Left" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 81: UsersListView.xaml.cs

<a id='userslistviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для UsersListView.xaml
    /// </summary>
    public partial class UsersListView : UserControl
    {
        public UsersListView()
        {
            InitializeComponent();
        }
    }
}

```

---

## CampAgency.WPF\Views\Auth

<a id='auth'></a>

## FILE 82: LoginView.xaml

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

## FILE 83: LoginView.xaml.cs

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

## FILE 84: RegisterView.xaml

<a id='registerview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Auth.RegisterView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
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

## FILE 85: RegisterView.xaml.cs

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

## FILE 86: OperatorDashboardView.xaml

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

## FILE 87: OperatorDashboardView.xaml.cs

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

## FILE 88: ChildEditView.xaml

<a id='childeditview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ChildEditView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel Margin="20" Width="450">
        <TextBlock Text="Добавление / редактирование ребёнка" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

        <TextBlock Text="ФИО ребёнка*:" Margin="0,5"/>
        <TextBox Text="{Binding FullName}" Margin="0,5" Height="30"/>

        <TextBlock Text="Дата рождения*:" Margin="0,5"/>
        <DatePicker SelectedDate="{Binding BirthDate}" Margin="0,5" Height="30"/>

        <TextBlock Text="Пол*:" Margin="0,5"/>
        <ComboBox ItemsSource="{Binding Genders}" SelectedItem="{Binding SelectedGender}" DisplayMemberPath="GenderName" Margin="0,5" Height="30"/>

        <TextBlock Text="Медицинские заметки:" Margin="0,10,0,5"/>
        <ListBox ItemsSource="{Binding MedicalNoteWrappers}" Margin="0,5" Height="150">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding MedicalNote.MedicalNoteName}" IsChecked="{Binding IsSelected}" Margin="2"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right" Margin="0,20">
            <Button Content="Сохранить" Command="{Binding SaveCommand}" Width="100" Height="35" Margin="5"/>
            <Button Content="Отмена" Command="{Binding CancelCommand}" Width="100" Height="35" Margin="5"/>
        </StackPanel>
    </StackPanel>
</UserControl>
```

---

## FILE 89: ChildEditView.xaml.cs

<a id='childeditviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Parent
{
    /// <summary>
    /// Логика взаимодействия для ChildEditView.xaml
    /// </summary>
    public partial class ChildEditView : UserControl
    {
        public ChildEditView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 90: ChildListView.xaml

<a id='childlistview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ChildListView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <StackPanel Orientation="Horizontal" Margin="0,0,0,10">
            <TextBlock Text="Мои дети" FontSize="24" FontWeight="Bold" VerticalAlignment="Center"/>
            <Button Content="+ Добавить ребёнка" Command="{Binding AddChildCommand}" Width="150" Height="30" Margin="20,0,0,0" HorizontalAlignment="Right"/>
        </StackPanel>

        <DataGrid Grid.Row="1" ItemsSource="{Binding Children}" AutoGenerateColumns="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ФИО" Binding="{Binding FullName}" Width="*"/>
                <DataGridTextColumn Header="Пол" Binding="{Binding Gender.GenderName}" Width="100"/>
                <DataGridTextColumn Header="Дата рождения" Binding="{Binding BirthDate, StringFormat=dd.MM.yyyy}" Width="120"/>
                <DataGridTextColumn Header="Мед. заметки" Binding="{Binding ChildMedicalNotes.Count}" Width="100"/>
                <DataGridTemplateColumn Header="Действия" Width="120">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="✏️" Width="30" Margin="2" Command="{Binding DataContext.EditChildCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" CommandParameter="{Binding}"/>
                                <Button Content="🗑️" Width="30" Margin="2" Command="{Binding DataContext.DeleteChildCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" CommandParameter="{Binding}"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
        <Button Grid.Row="2" Content="Назад" Width="150" Height="30" HorizontalAlignment="Right" Margin="20,0,0,0" Command="{Binding BackToDashboardCommand}"/>
    </Grid>
</UserControl>
```

---

## FILE 91: ChildListView.xaml.cs

<a id='childlistviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Parent
{
    /// <summary>
    /// Логика взаимодействия для ChildListView.xaml
    /// </summary>
    public partial class ChildListView : UserControl
    {
        public ChildListView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 92: MyBookingsView.xaml

<a id='mybookingsview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.MyBookingsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Мои бронирования" FontSize="20" FontWeight="Bold" Margin="0,0,0,10"/>

        <DataGrid Grid.Row="1" ItemsSource="{Binding Bookings}" AutoGenerateColumns="False" CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Ребёнок" Binding="{Binding Child.FullName}" Width="150"/>
                <DataGridTextColumn Header="Лагерь" Binding="{Binding Shift.Camp.CampName}" Width="*"/>
                <DataGridTextColumn Header="Смена" Binding="{Binding Shift.StartDate, StringFormat=dd.MM.yyyy}" Width="100"/>
                <DataGridTextColumn Header="Статус" Binding="{Binding BookingStatus.BookingStatusName}" Width="120"/>
                <DataGridTextColumn Header="Дата бронирования" Binding="{Binding CreatedAt, StringFormat=dd.MM.yyyy HH:mm}" Width="130"/>
            </DataGrid.Columns>
        </DataGrid>

        <Button Grid.Row="2" Content="← Назад" Command="{Binding BackToDashboardCommand}" Width="120" Height="30" HorizontalAlignment="Left" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 93: MyBookingsView.xaml.cs

<a id='mybookingsviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Parent
{
    /// <summary>
    /// Логика взаимодействия для MyBookingsView.xaml
    /// </summary>
    public partial class MyBookingsView : UserControl
    {
        public MyBookingsView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 94: ParentDashboardView.xaml

<a id='parentdashboardview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ParentDashboardView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Личный кабинет родителя" FontSize="24" FontWeight="Bold" Margin="0,0,0,20"/>

        <StackPanel Grid.Row="0" Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Content="Мои дети" Command="{Binding ShowChildrenCommand}" Width="120" Margin="5" Height="30"/>
            <Button Content="Поиск смен" Command="{Binding ShowShiftsCatalogCommand}" Width="120" Margin="5" Height="30"/>
            <Button Content="Мои бронирования" Command="{Binding ShowMyBookingsCommand}" Width="150" Margin="5" Height="30"/>
        </StackPanel>

        <ContentControl Grid.Row="1" Content="{Binding NavigationService.CurrentViewModel}" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 95: ParentDashboardView.xaml.cs

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

## FILE 96: ShiftDetailsView.xaml

<a id='shiftdetailsview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ShiftDetailsView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel Margin="20" Width="500">
        <TextBlock Text="Детали смены" FontSize="20" FontWeight="Bold" Margin="0,0,0,20"/>

        <Border BorderBrush="LightGray" BorderThickness="1" Padding="10" Margin="0,0,0,20">
            <StackPanel>
                <TextBlock FontWeight="Bold" Text="{Binding Shift.Camp.CampName}" FontSize="16"/>
                <TextBlock Text="{Binding Shift.Camp.CampType.CampTypeName}" FontWeight="Light"/>
                <TextBlock Text="{Binding Shift.Camp.Region}"/>
                <TextBlock Text="Даты: " Margin="0,10,0,0"/>
                <TextBlock>
                    <Run Text="{Binding Shift.StartDate, StringFormat=dd.MM.yyyy}"/>
                    <Run Text=" - "/>
                    <Run Text="{Binding Shift.EndDate, StringFormat=dd.MM.yyyy}"/>
                </TextBlock>
                <TextBlock Text="Цена: " Margin="0,5,0,0"/>
                <TextBlock Text="{Binding Shift.Price, StringFormat=C}" Foreground="Green" FontWeight="Bold"/>
                <TextBlock Text="Осталось мест: " Margin="0,5,0,0"/>
                <TextBlock Text="{Binding Shift.AvailableSeats}"/>
                <TextBlock Text="Описание лагеря: " Margin="0,10,0,0"/>
                <TextBlock Text="{Binding Shift.Camp.Description}" TextWrapping="Wrap"/>
            </StackPanel>
        </Border>

        <TextBlock Text="Выберите ребёнка для бронирования:" Margin="0,0,0,5"/>
        <ComboBox ItemsSource="{Binding MyChildren}" SelectedItem="{Binding SelectedChild}" DisplayMemberPath="FullName" Margin="0,0,0,20" Height="30"/>

        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Content="Забронировать" Command="{Binding BookShiftCommand}" Width="120" Height="35" Margin="5" IsEnabled="{Binding IsBookingInProgress, Converter={StaticResource InverseBooleanConverter}}"/>
            <Button Content="Назад" Command="{Binding CancelCommand}" Width="100" Height="35" Margin="5"/>
        </StackPanel>
    </StackPanel>
</UserControl>
```

---

## FILE 97: ShiftDetailsView.xaml.cs

<a id='shiftdetailsviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Parent
{
    /// <summary>
    /// Логика взаимодействия для ShiftDetailsView.xaml
    /// </summary>
    public partial class ShiftDetailsView : UserControl
    {
        public ShiftDetailsView()
        {
            InitializeComponent();
        }
    }
}

```

---

## FILE 98: ShiftsCatalogView.xaml

<a id='shiftscatalogview'></a>

```xml
<UserControl x:Class="CampAgency.WPF.Views.Parent.ShiftsCatalogView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>

        <TextBlock Text="Каталог смен" FontSize="20" FontWeight="Bold" Margin="0,0,0,10"/>

        <!-- Панель фильтров -->
        <Border Grid.Row="1" BorderBrush="LightGray" BorderThickness="1" Padding="10" Margin="0,0,0,10">
            <StackPanel>
                <TextBlock Text="Фильтры" FontWeight="Bold"/>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="Регион:" Grid.Column="0" VerticalAlignment="Center" Margin="5"/>
                    <ComboBox ItemsSource="{Binding Regions}" SelectedItem="{Binding SelectedRegion}" DisplayMemberPath="RegionName" Margin="5" Height="30"/>
                    <TextBlock Text="Тип лагеря:" Grid.Column="2" VerticalAlignment="Center" Margin="5"/>
                    <ComboBox Grid.Column="3" ItemsSource="{Binding CampTypes}" SelectedItem="{Binding SelectedCampType}" DisplayMemberPath="CampTypeName" Margin="5" Height="30"/>
                </Grid>
                <Grid Margin="0,5,0,0">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="Дата от:" Grid.Column="0" VerticalAlignment="Center" Margin="5"/>
                    <DatePicker Grid.Column="1" SelectedDate="{Binding StartDateFrom}" Margin="5" Height="30"/>
                    <TextBlock Text="до:" Grid.Column="2" VerticalAlignment="Center" Margin="5"/>
                    <DatePicker Grid.Column="3" SelectedDate="{Binding StartDateTo}" Margin="5" Height="30"/>
                    <TextBlock Text="Цена от:" Grid.Column="4" VerticalAlignment="Center" Margin="5"/>
                    <TextBox Grid.Column="5" Text="{Binding MinPriceStr}" Margin="5" Height="30"/>
                </Grid>
                <Grid Margin="0,5,0,0">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="до:" Grid.Column="0" VerticalAlignment="Center" Margin="5"/>
                    <TextBox Grid.Column="1" Text="{Binding MaxPriceStr}" Margin="5" Height="30"/>
                    <Button Grid.Column="2" Content="Применить" Command="{Binding ApplyFiltersCommand}" Width="100" Height="30" Margin="5"/>
                    <Button Grid.Column="3" Content="Сбросить" Command="{Binding ResetFiltersCommand}" Width="100" Height="30" Margin="5"/>
                </Grid>
            </StackPanel>
        </Border>

        <!-- Список смен -->
        <DataGrid Grid.Row="2" ItemsSource="{Binding Shifts}" AutoGenerateColumns="False" 
                  CanUserAddRows="False" IsReadOnly="True">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Лагерь" Binding="{Binding Camp.CampName}" Width="*"/>
                <DataGridTextColumn Header="Тип" Binding="{Binding Camp.CampType.CampTypeName}" Width="100"/>
                <DataGridTextColumn Header="Регион" Binding="{Binding Camp.Region}" Width="120"/>
                <DataGridTextColumn Header="Дата начала" Binding="{Binding StartDate, StringFormat=dd.MM.yyyy}" Width="100"/>
                <DataGridTextColumn Header="Дата окончания" Binding="{Binding EndDate, StringFormat=dd.MM.yyyy}" Width="100"/>
                <DataGridTextColumn Header="Свободно мест" Binding="{Binding AvailableSeats}" Width="100"/>
                <DataGridTextColumn Header="Цена" Binding="{Binding Price, StringFormat=C}" Width="100"/>
                <DataGridTemplateColumn Header="Действие" Width="100">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="Подробнее" Command="{Binding DataContext.ViewShiftDetailsCommand, RelativeSource={RelativeSource AncestorType=UserControl}}" CommandParameter="{Binding}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>

        <Button Grid.Row="3" Content="← Назад" Command="{Binding BackToDashboardCommand}" Width="120" Height="30" HorizontalAlignment="Left" Margin="0,10,0,0"/>
    </Grid>
</UserControl>
```

---

## FILE 99: ShiftsCatalogView.xaml.cs

<a id='shiftscatalogviewxaml'></a>

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CampAgency.WPF.Views.Parent
{
    /// <summary>
    /// Логика взаимодействия для ShiftsCatalogView.xaml
    /// </summary>
    public partial class ShiftsCatalogView : UserControl
    {
        public ShiftsCatalogView()
        {
            InitializeComponent();
        }
    }
}

```

---

