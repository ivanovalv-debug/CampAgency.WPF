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