using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ShiftsCatalogViewModel : ObservableObject
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private ObservableCollection<string> _regions = new();

        // Фильтры
        [ObservableProperty] private string? _selectedRegion;
        [ObservableProperty] private CampType? _selectedCampType;
        [ObservableProperty] private DateTime? _startDateFrom;
        [ObservableProperty] private DateTime? _startDateTo;
        [ObservableProperty] private string? _minPriceStr;
        [ObservableProperty] private string? _maxPriceStr;

        public ShiftsCatalogViewModel(IShiftCatalogService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadFilters();
            LoadShifts();
        }

        private void LoadFilters()
        {
            var types = _shiftService.GetCampTypes();
            CampTypes = new ObservableCollection<CampType>(types);
            var regions = _shiftService.GetRegions();
            Regions = new ObservableCollection<string>(regions);
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
                SelectedRegion,
                SelectedCampType?.CampTypeId,
                fromDate,
                toDate,
                minPrice,
                maxPrice
            );
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