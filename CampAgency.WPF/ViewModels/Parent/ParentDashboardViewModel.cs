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
            // По умолчанию показываем список детей
            _navigationService.NavigateTo<ChildListViewModel>();
        }

        [RelayCommand]
        private void ShowChildren() => _navigationService.NavigateTo<ChildListViewModel>();

        // Здесь будут другие команды: смены, бронирования и т.д.
    }
}