using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class ShiftsListViewModel : ObservableObject
    {
        private readonly INavigationService _navigation;

        public ShiftsListViewModel(INavigationService navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}