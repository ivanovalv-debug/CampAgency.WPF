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

            services.AddTransient<LoginViewModel>();
            services.AddTransient<AdminDashboardViewModel>();
            services.AddTransient<CampsListViewModel>();
            services.AddTransient<CampEditViewModel>();
            services.AddTransient<ParentDashboardViewModel>();
            services.AddTransient<OperatorDashboardViewModel>();

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