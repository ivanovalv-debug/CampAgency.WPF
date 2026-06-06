using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.Input;

namespace CampAgency.WPF.ViewModels.Operator
{
    public partial class OperatorDashboardViewModel
    {
        private readonly INavigationService _navigation;
        public OperatorDashboardViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            _navigation.NavigateTo<BookingsListViewModel>();
        }

        [RelayCommand]
        private void ShowBookings() => _navigation.NavigateTo<BookingsListViewModel>();
    }
}