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