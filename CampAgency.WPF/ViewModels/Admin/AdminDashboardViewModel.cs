using CampAgency.WPF.Services.NavigationServices;
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