using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.JournalServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace CampAgency.WPF.ViewModels.Operator
{
    public partial class ShiftAttendanceListViewModel : ObservableObject, INavigationAware
    {
        private readonly IShiftService _shiftService;
        private readonly IJournalService _journalService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();
        [ObservableProperty] private Shift? _selectedShift;
        [ObservableProperty] private ObservableCollection<Child> _arrivedChildren = new();
        [ObservableProperty] private ObservableCollection<Child> _departedChildren = new();

        public ShiftAttendanceListViewModel(IShiftService shiftService, IJournalService journalService, INavigationService navigation, IDialogService dialog)
        {
            _shiftService = shiftService;
            _journalService = journalService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadShifts();
        }

        private void LoadShifts()
        {
            var list = _shiftService.GetAllCamps()
                .SelectMany(c => _shiftService.GetShiftsByCampId(c.CampId))
                .OrderBy(s => s.StartDate)
                .ToList();
            Shifts = new ObservableCollection<Shift>(list);
        }

        partial void OnSelectedShiftChanged(Shift? value)
        {
            if (value != null)
            {
                LoadAttendance(value.ShiftId);
            }
            else
            {
                ArrivedChildren.Clear();
                DepartedChildren.Clear();
            }
        }

        private void LoadAttendance(int shiftId)
        {
            var arrived = _journalService.GetChildrenByShiftAndEvent(shiftId, "Заезд");
            var departed = _journalService.GetChildrenByShiftAndEvent(shiftId, "Выезд");
            ArrivedChildren = new ObservableCollection<Child>(arrived);
            DepartedChildren = new ObservableCollection<Child>(departed);
        }

        [RelayCommand]
        private void CopyArrivedList()
        {
            if (!ArrivedChildren.Any())
            {
                _dialog.ShowMessage("Список заехавших пуст", "Информация");
                return;
            }
            var text = string.Join("\n", ArrivedChildren.Select(c => $"{c.FullName} (родитель: {c.User.FullName}, тел: {c.User.Phone})"));
            Clipboard.SetText(text);
            _dialog.ShowMessage("Список заехавших скопирован в буфер обмена", "Успех");
        }

        [RelayCommand]
        private void CopyDepartedList()
        {
            if (!DepartedChildren.Any())
            {
                _dialog.ShowMessage("Список выехавших пуст", "Информация");
                return;
            }
            var text = string.Join("\n", DepartedChildren.Select(c => $"{c.FullName} (родитель: {c.User.FullName}, тел: {c.User.Phone})"));
            Clipboard.SetText(text);
            _dialog.ShowMessage("Список выехавших скопирован в буфер обмена", "Успех");
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<OperatorDashboardViewModel>();
    }
}