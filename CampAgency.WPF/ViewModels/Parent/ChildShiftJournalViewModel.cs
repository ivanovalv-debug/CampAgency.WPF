using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.JournalServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildShiftJournalViewModel : ObservableObject, INavigationAware
    {
        private readonly IJournalService _journalService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private Child? _child;
        [ObservableProperty] private ObservableCollection<ShiftJournal> _journalEntries = new();

        public ChildShiftJournalViewModel(IJournalService journalService, INavigationService navigation, IDialogService dialog)
        {
            _journalService = journalService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Child child)
            {
                _child = child;
                LoadJournal();
            }
            else
            {
                _dialog.ShowError("Не удалось загрузить данные ребёнка", "Ошибка");
                _navigation.NavigateTo<ChildListViewModel>();
            }
        }

        private void LoadJournal()
        {
            if (_child != null)
            {
                var entries = _journalService.GetJournalByChildId(_child.ChildId);
                JournalEntries = new ObservableCollection<ShiftJournal>(entries);
            }
        }

        [RelayCommand]
        private void BackToChildren() => _navigation.NavigateTo<ChildListViewModel>();
    }
}