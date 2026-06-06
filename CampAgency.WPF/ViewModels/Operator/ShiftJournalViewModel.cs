using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.JournalServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Operator
{
    public partial class ShiftJournalViewModel : ObservableObject, INavigationAware
    {
        private readonly IJournalService _journalService;
        private readonly IShiftService _shiftService;
        private readonly IAuthService _authService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private ObservableCollection<Shift> _shifts = new();
        [ObservableProperty] private Shift? _selectedShift;
        [ObservableProperty] private ObservableCollection<Child> _children = new();
        [ObservableProperty] private ObservableCollection<CampEvent> _events = new();
        [ObservableProperty] private ObservableCollection<ShiftJournal> _journalEntries = new();

        [ObservableProperty] private Child? _selectedChild;
        [ObservableProperty] private CampEvent? _selectedEvent;
        [ObservableProperty] private string _note = string.Empty;

        public ShiftJournalViewModel(IJournalService journalService, IShiftService shiftService, IAuthService authService, INavigationService navigation, IDialogService dialog)
        {
            _journalService = journalService;
            _shiftService = shiftService;
            _authService = authService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadShifts();
            LoadEvents();
        }

        private void LoadShifts()
        {
            var list = _shiftService.GetAllCamps()
                .SelectMany(c => _shiftService.GetShiftsByCampId(c.CampId))
                .OrderBy(s => s.StartDate)
                .ToList();
            Shifts = new ObservableCollection<Shift>(list);
        }

        private void LoadEvents()
        {
            Events = new ObservableCollection<CampEvent>(_journalService.GetAllEvents());
        }

        partial void OnSelectedShiftChanged(Shift? value)
        {
            if (value != null)
            {
                var children = _journalService.GetChildrenByShiftId(value.ShiftId);
                Children = new ObservableCollection<Child>(children);
                LoadJournalEntries();
            }
            else
            {
                Children.Clear();
                JournalEntries.Clear();
            }
        }

        private void LoadJournalEntries()
        {
            if (SelectedShift != null)
            {
                var entries = _journalService.GetJournalByShiftId(SelectedShift.ShiftId);
                JournalEntries = new ObservableCollection<ShiftJournal>(entries);
            }
        }

        [RelayCommand]
        private void AddEntry()
        {
            if (SelectedChild == null)
            {
                _dialog.ShowError("Выберите ребёнка", "Ошибка");
                return;
            }
            if (SelectedEvent == null)
            {
                _dialog.ShowError("Выберите тип события", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Note))
            {
                _dialog.ShowError("Введите текст записи", "Ошибка");
                return;
            }

            var operatorId = _authService.CurrentUser?.UserId;
            if (!operatorId.HasValue)
            {
                _dialog.ShowError("Оператор не авторизован", "Ошибка");
                return;
            }

            var success = _journalService.AddJournalEntry(SelectedChild.ChildId, SelectedEvent.CampEventId, operatorId.Value, Note);
            if (success)
            {
                _dialog.ShowMessage("Запись добавлена", "Успех");
                LoadJournalEntries();
                Note = string.Empty;
                SelectedEvent = null;
                SelectedChild = null;
            }
            else
            {
                _dialog.ShowError("Не удалось добавить запись", "Ошибка");
            }
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<OperatorDashboardViewModel>();
    }
}