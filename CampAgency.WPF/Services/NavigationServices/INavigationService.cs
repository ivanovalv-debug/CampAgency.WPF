using System.ComponentModel;

namespace CampAgency.WPF.Services.NavigationServices
{
    public interface INavigationService : INotifyPropertyChanged
    {
        object? CurrentViewModel { get; }
        void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class;
    }

    public interface INavigationAware
    {
        void OnNavigatedTo(object? parameter);
    }
}