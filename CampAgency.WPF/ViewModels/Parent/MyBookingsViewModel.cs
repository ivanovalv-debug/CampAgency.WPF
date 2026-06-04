using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class MyBookingsViewModel : ObservableObject
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;
        private readonly IAuthService _authService;

        [ObservableProperty] private ObservableCollection<Booking> _bookings = new();

        public MyBookingsViewModel(IShiftCatalogService shiftService, INavigationService navigation, IDialogService dialogService, IAuthService authService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            _authService = authService;
            LoadBookings();
        }

        private void LoadBookings()
        {
            var currentUserId = _authService.CurrentUser?.UserId;
            if (currentUserId.HasValue)
            {
                var list = _shiftService.GetBookingsByUserId(currentUserId.Value);
                Bookings = new ObservableCollection<Booking>(list);
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<ParentDashboardViewModel>();
    }
}