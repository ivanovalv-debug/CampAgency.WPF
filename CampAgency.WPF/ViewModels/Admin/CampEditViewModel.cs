using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows.Media;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private string _campName = string.Empty;
        [ObservableProperty] private string _region = string.Empty;
        [ObservableProperty] private string _address = string.Empty;
        [ObservableProperty] private string _contactPhone = string.Empty;
        [ObservableProperty] private string _description = string.Empty;
        [ObservableProperty] private double? _rating;
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private CampType? _selectedCampType;

        private Camp? _currentCamp;
        private bool _isNew;

        public CampEditViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation, IDialogService dialogService)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadCampTypes();
            if (parameter is Camp camp)
            {
                _currentCamp = camp;
                _isNew = false;
                CampName = camp.CampName;
                Region = camp.Region ?? string.Empty;
                Address = camp.Address ?? string.Empty;
                ContactPhone = camp.ContactPhone ?? string.Empty;
                Description = camp.Description ?? string.Empty;
                Rating = (double?)camp.Rating;
                SelectedCampType = camp.CampType;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                CampName = string.Empty;
                Region = string.Empty;
                Address = string.Empty;
                ContactPhone = string.Empty;
                Description = string.Empty;
                Rating = null;
                SelectedCampType = null;
            }
        }

        private void LoadCampTypes()
        {
            using var context = _contextFactory.CreateDbContext();
            CampTypes = new ObservableCollection<CampType>(context.CampTypes.ToList());
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(CampName))
            {
                _dialogService.ShowError("Название лагеря обязательно для заполнения", "Ошибка");
                return;
            }
            if (SelectedCampType == null)
            {
                _dialogService.ShowError("Выберите тип учреждения", "Ошибка");
                return;
            }
            if (Rating.HasValue && (Rating.Value < 0 || Rating.Value > 5))
            {
                _dialogService.ShowError("Рейтинг должен быть в диапазоне от 0 до 5", "Ошибка");
                return;
            }

            using var context = _contextFactory.CreateDbContext();

            if (_isNew)
            {
                var newCamp = new Camp
                {
                    CampName = CampName,
                    Region = string.IsNullOrWhiteSpace(Region) ? null : Region,
                    Address = string.IsNullOrWhiteSpace(Address) ? null : Address,
                    ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone,
                    Description = string.IsNullOrWhiteSpace(Description) ? null : Description,
                    Rating = Rating.HasValue ? (decimal?)Rating.Value : null,
                    CampTypeId = SelectedCampType.CampTypeId
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                var campToUpdate = context.Camps.Find(_currentCamp!.CampId);
                if (campToUpdate != null)
                {
                    campToUpdate.CampName = CampName;
                    campToUpdate.Region = string.IsNullOrWhiteSpace(Region) ? null : Region;
                    campToUpdate.Address = string.IsNullOrWhiteSpace(Address) ? null : Address;
                    campToUpdate.ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone;
                    campToUpdate.Description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                    campToUpdate.Rating = Rating.HasValue ? (decimal?)Rating.Value : null;
                    campToUpdate.CampTypeId = SelectedCampType.CampTypeId;
                }
            }

            context.SaveChanges();
            _dialogService.ShowMessage(_isNew ? "Лагерь успешно добавлен" : "Данные лагеря обновлены", "Успех");
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<CampsListViewModel>();
    }
}