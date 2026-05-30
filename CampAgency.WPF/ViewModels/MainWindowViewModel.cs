using CampAgency.WPF.Services;
using CampAgency.WPF.ViewModels.Auth;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userInfo = "Не авторизован";

        public INavigationService NavigationService { get; }
        public IAuthService AuthService { get; }

        public MainWindowViewModel(INavigationService navigation, IAuthService auth)
        {
            NavigationService = navigation;
            AuthService = auth;

            // При запуске всегда показываем экран входа
            NavigationService.NavigateTo<LoginViewModel>();

            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (AuthService.CurrentUser != null)
            {
                UserInfo = $"{AuthService.CurrentUser.FullName} ({AuthService.CurrentUser.Role})";
            }
            else
            {
                UserInfo = "Не авторизован";
            }
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