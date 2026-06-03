using System.Windows;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.NavigationServices;
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