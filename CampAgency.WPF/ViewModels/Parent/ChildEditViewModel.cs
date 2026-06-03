using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IChildService _childService;
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private DateTime? _birthDate;
        [ObservableProperty] private ObservableCollection<Gender> _genders = new();
        [ObservableProperty] private Gender? _selectedGender;
        [ObservableProperty] private ObservableCollection<MedicalNote> _allMedicalNotes = new();
        [ObservableProperty] private ObservableCollection<MedicalNote> _selectedMedicalNotes = new();

        private Child? _currentChild;
        private bool _isNew = true;

        public ChildEditViewModel(IChildService childService, IAuthService authService, IDialogService dialogService, INavigationService navigationService)
        {
            _childService = childService;
            _authService = authService;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadLookups();
            if (parameter is Child child)
            {
                _currentChild = child;
                _isNew = false;
                FullName = child.FullName;
                BirthDate = child.BirthDate.ToDateTime(TimeOnly.MinValue);
                SelectedGender = child.Gender;
                // Здесь можно загрузить выбранные медзаметки для редактирования, но для упрощения оставим
            }
            else
            {
                _currentChild = null;
                _isNew = true;
                FullName = string.Empty;
                BirthDate = null;
                SelectedGender = null;
                SelectedMedicalNotes.Clear();
            }
        }

        private void LoadLookups()
        {
            Genders = new ObservableCollection<Gender>(_childService.GetGenders());
            AllMedicalNotes = new ObservableCollection<MedicalNote>(_childService.GetMedicalNotes());
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(FullName) || SelectedGender == null || BirthDate == null)
            {
                _dialogService.ShowError("Заполните ФИО, пол и дату рождения", "Ошибка");
                return;
            }

            var birthDateOnly = DateOnly.FromDateTime(BirthDate.Value);
            var medicalNoteIds = SelectedMedicalNotes.Select(n => n.MedicalNoteId).ToList();

            bool success;
            if (_isNew)
            {
                success = _childService.AddChild(_authService.CurrentUser!.UserId, FullName, SelectedGender.GenderId, birthDateOnly, medicalNoteIds);
                if (success) _dialogService.ShowMessage("Ребёнок успешно добавлен", "Успех");
            }
            else
            {
                _currentChild!.FullName = FullName;
                _currentChild.GenderId = SelectedGender.GenderId;
                _currentChild.BirthDate = birthDateOnly;
                success = _childService.UpdateChild(_currentChild);
                if (success) _dialogService.ShowMessage("Данные обновлены", "Успех");
            }

            if (success)
                _navigationService.NavigateTo<ChildListViewModel>();
            else
                _dialogService.ShowError("Ошибка сохранения", "Ошибка");
        }

        [RelayCommand]
        private void Cancel() => _navigationService.NavigateTo<ChildListViewModel>();
    }
}