using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ReviewServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ShiftsCatalogViewModel : ObservableObject
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;
        private readonly IReviewService _reviewService;

        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private ObservableCollection<Region> _regions = new();

        // Фильтры
        [ObservableProperty] private Region? _selectedRegion;
        [ObservableProperty] private CampType? _selectedCampType;
        [ObservableProperty] private DateTime? _startDateFrom;
        [ObservableProperty] private DateTime? _startDateTo;
        [ObservableProperty] private string? _minPriceStr;
        [ObservableProperty] private string? _maxPriceStr;

        public ShiftsCatalogViewModel(IShiftCatalogService shiftService, INavigationService navigation, IDialogService dialogService, IReviewService reviewService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            _reviewService = reviewService;
            LoadFilters();
            LoadShifts();
        }

        private void LoadFilters()
        {
            CampTypes = new ObservableCollection<CampType>(_shiftService.GetCampTypes());
            var regionList = _shiftService.GetAllRegions();
            Regions = new ObservableCollection<Region>(regionList);
        }


        private void LoadShifts()
        {
            decimal? minPrice = null, maxPrice = null;
            if (!string.IsNullOrWhiteSpace(MinPriceStr) && decimal.TryParse(MinPriceStr, out var min))
                minPrice = min;
            if (!string.IsNullOrWhiteSpace(MaxPriceStr) && decimal.TryParse(MaxPriceStr, out var max))
                maxPrice = max;

            DateOnly? fromDate = StartDateFrom.HasValue ? DateOnly.FromDateTime(StartDateFrom.Value) : null;
            DateOnly? toDate = StartDateTo.HasValue ? DateOnly.FromDateTime(StartDateTo.Value) : null;

            var list = _shiftService.GetShiftsWithFilters(
                SelectedRegion?.RegionId,
                SelectedCampType?.CampTypeId,
                fromDate,
                toDate,
                minPrice,
                maxPrice
            );
            foreach (var shift in list)
            {
                shift.AverageRating = _reviewService.GetAverageRatingForCamp(shift.Camp.CampId);
            }
            Shifts = new ObservableCollection<Shift>(list);
        }

        [RelayCommand]
        private void ApplyFilters() => LoadShifts();

        [RelayCommand]
        private void ResetFilters()
        {
            SelectedRegion = null;
            SelectedCampType = null;
            StartDateFrom = null;
            StartDateTo = null;
            MinPriceStr = null;
            MaxPriceStr = null;
            LoadShifts();
        }

        [RelayCommand]
        private void ViewShiftDetails(Shift shift)
        {
            if (shift != null)
                _navigation.NavigateTo<ShiftDetailsViewModel>(shift.ShiftId);
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<ParentDashboardViewModel>();
    }
}