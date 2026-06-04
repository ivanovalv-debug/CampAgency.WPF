using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class ShiftsListViewModel : ObservableObject
    {
        private readonly IShiftService _shiftService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();
        [ObservableProperty] private Camp? _selectedCamp;
        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();

        public ShiftsListViewModel(IShiftService shiftService, INavigationService navigation, IDialogService dialogService)
        {
            _shiftService = shiftService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadCamps();
        }

        private void LoadCamps()
        {
            var list = _shiftService.GetAllCamps();
            Camps = new ObservableCollection<Camp>(list);
            if (Camps.Any())
                SelectedCamp = Camps.First();
        }

        partial void OnSelectedCampChanged(Camp? value)
        {
            if (value != null)
                LoadShifts(value.CampId);
            else
                Shifts.Clear();
        }

        private void LoadShifts(int campId)
        {
            var list = _shiftService.GetShiftsByCampId(campId);
            Shifts = new ObservableCollection<Shift>(list);
        }

        [RelayCommand]
        private void AddShift()
        {
            if (SelectedCamp == null)
            {
                _dialogService.ShowError("Сначала выберите лагерь", "Ошибка");
                return;
            }
            _navigation.NavigateTo<ShiftEditViewModel>((SelectedCamp, (Shift?)null));
        }

        [RelayCommand]
        private void EditShift(Shift shift)
        {
            if (shift == null) return;
            _navigation.NavigateTo<ShiftEditViewModel>((shift.Camp, shift));
        }

        [RelayCommand]
        private void DeleteShift(Shift shift)
        {
            if (shift == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить смену с {shift.StartDate:dd.MM.yyyy} по {shift.EndDate:dd.MM.yyyy}?", "Удаление"))
                return;

            var success = _shiftService.DeleteShift(shift.ShiftId);
            if (success)
            {
                _dialogService.ShowMessage("Смена удалена", "Успех");
                if (SelectedCamp != null)
                    LoadShifts(SelectedCamp.CampId);
            }
            else
            {
                _dialogService.ShowError("Не удалось удалить смену", "Ошибка");
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}