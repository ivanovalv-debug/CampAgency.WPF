using CampAgency.WPF.Services;
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

        // Можно добавить кнопки для других разделов админки здесь
    }
}