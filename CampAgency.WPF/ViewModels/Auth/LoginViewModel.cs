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