using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class ShiftEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IShiftService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();
        [ObservableProperty] private Camp? _selectedCamp;
        [ObservableProperty] private DateTime? _startDate;
        [ObservableProperty] private DateTime? _endDate;
        [ObservableProperty] private int _totalSeats = 1;
        [ObservableProperty] private decimal _price;

        private Shift? _currentShift;
        private bool _isNew;

        public ShiftEditViewModel(IShiftService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadCamps();

            if (parameter is (Camp camp, Shift shift)) // кортеж
            {
                if (shift != null)
                {
                    _currentShift = shift;
                    _isNew = false;
                    SelectedCamp = shift.Camp;
                    StartDate = shift.StartDate.ToDateTime(TimeOnly.MinValue);
                    EndDate = shift.EndDate.ToDateTime(TimeOnly.MinValue);
                    TotalSeats = shift.TotalSeats;
                    Price = shift.Price;
                }
                else
                {
                    _currentShift = null;
                    _isNew = true;
                    SelectedCamp = camp;
                    StartDate = null;
                    EndDate = null;
                    TotalSeats = 1;
                    Price = 0;
                }
            }
            else
            {
                _isNew = true;
                SelectedCamp = null;
                StartDate = null;
                EndDate = null;
                TotalSeats = 1;
                Price = 0;
            }
        }

        private void LoadCamps()
        {
            var list = _shiftService.GetAllCamps();
            Camps = new ObservableCollection<Camp>(list);
        }

        [RelayCommand]
        private void Save()
        {
            if (SelectedCamp == null)
            {
                _dialogService.ShowError("Выберите лагерь", "Ошибка");
                return;
            }
            if (StartDate == null || EndDate == null)
            {
                _dialogService.ShowError("Укажите даты начала и окончания смены", "Ошибка");
                return;
            }
            if (StartDate >= EndDate)
            {
                _dialogService.ShowError("Дата начала должна быть раньше даты окончания", "Ошибка");
                return;
            }
            if (TotalSeats <= 0)
            {
                _dialogService.ShowError("Количество мест должно быть больше 0", "Ошибка");
                return;
            }
            if (Price < 0)
            {
                _dialogService.ShowError("Стоимость не может быть отрицательной", "Ошибка");
                return;
            }

            var startDateOnly = DateOnly.FromDateTime(StartDate.Value);
            var endDateOnly = DateOnly.FromDateTime(EndDate.Value);

            bool success;
            if (_isNew)
            {
                success = _shiftService.AddShift(SelectedCamp.CampId, startDateOnly, endDateOnly, TotalSeats, Price);
                if (success) _dialogService.ShowMessage("Смена добавлена", "Успех");
            }
            else
            {
                _currentShift!.CampId = SelectedCamp.CampId;
                _currentShift.StartDate = startDateOnly;
                _currentShift.EndDate = endDateOnly;
                _currentShift.TotalSeats = TotalSeats;
                _currentShift.Price = Price;
                success = _shiftService.UpdateShift(_currentShift);
                if (success) _dialogService.ShowMessage("Смена обновлена", "Успех");
            }

            if (success)
                _navigation.NavigateTo<ShiftsListViewModel>();
            else
                _dialogService.ShowError("Ошибка сохранения", "Ошибка");
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<ShiftsListViewModel>();
    }
}