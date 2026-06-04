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