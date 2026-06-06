using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.BookingServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Operator
{
    public partial class BookingsListViewModel : ObservableObject
    {
        private readonly IBookingService _bookingService;
        private readonly INavigationService _navigation;

        [ObservableProperty] private ObservableCollection<Booking> _bookings = new();
        [ObservableProperty] private ObservableCollection<BookingStatus> _statuses = new();
        [ObservableProperty] private ObservableCollection<Camp> _camps = new();

        [ObservableProperty] private BookingStatus? _selectedStatusFilter;
        [ObservableProperty] private Camp? _selectedCampFilter;
        [ObservableProperty] private string _searchText = string.Empty;

        public BookingsListViewModel(IBookingService bookingService, INavigationService navigation)
        {
            _bookingService = bookingService;
            _navigation = navigation;
            LoadFilters();
            LoadBookings();
        }

        private void LoadFilters()
        {
            var statusList = _bookingService.GetAllBookingStatuses();
            statusList.Insert(0, new BookingStatus { BookingStatusId = 0, BookingStatusName = "Все" });
            Statuses = new ObservableCollection<BookingStatus>(statusList);
            SelectedStatusFilter = Statuses.First();

            var campList = _bookingService.GetAllCamps();
            campList.Insert(0, new Camp { CampId = 0, CampName = "Все" });
            Camps = new ObservableCollection<Camp>(campList);
            SelectedCampFilter = Camps.First();
        }

        private void LoadBookings()
        {
            int? statusId = SelectedStatusFilter?.BookingStatusId == 0 ? null : SelectedStatusFilter?.BookingStatusId;
            int? campId = SelectedCampFilter?.CampId == 0 ? null : SelectedCampFilter?.CampId;
            var list = _bookingService.GetBookingsWithFilters(statusId, campId, SearchText);
            Bookings = new ObservableCollection<Booking>(list);
        }

        partial void OnSelectedStatusFilterChanged(BookingStatus? value) => LoadBookings();
        partial void OnSelectedCampFilterChanged(Camp? value) => LoadBookings();
        partial void OnSearchTextChanged(string value) => LoadBookings();

        [RelayCommand]
        private void ViewBooking(Booking booking) => _navigation.NavigateTo<BookingDetailsViewModel>(booking.BookingId);
    }
}