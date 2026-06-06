using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private string _campName = string.Empty;
        [ObservableProperty] private string _address = string.Empty;
        [ObservableProperty] private string _contactPhone = string.Empty;
        [ObservableProperty] private string _description = string.Empty;
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private CampType? _selectedCampType;
        [ObservableProperty] private ObservableCollection<Region> _regions = new();
        [ObservableProperty] private Region? _selectedRegion;

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
            LoadLookups();
            if (parameter is Camp camp)
            {
                _currentCamp = camp;
                _isNew = false;
                CampName = camp.CampName;
                Address = camp.Address ?? string.Empty;
                ContactPhone = camp.ContactPhone ?? string.Empty;
                Description = camp.Description ?? string.Empty;
                SelectedCampType = camp.CampType;
                SelectedRegion = camp.Region;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                CampName = string.Empty;
                Address = string.Empty;
                ContactPhone = string.Empty;
                Description = string.Empty;
                SelectedCampType = null;
                SelectedRegion = null;
            }
        }

        private void LoadLookups()
        {
            using var context = _contextFactory.CreateDbContext();
            CampTypes = new ObservableCollection<CampType>(context.CampTypes.ToList());
            Regions = new ObservableCollection<Region>(context.Regions.OrderBy(r => r.RegionName).ToList());
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

            using var context = _contextFactory.CreateDbContext();

            if (_isNew)
            {
                var newCamp = new Camp
                {
                    CampName = CampName,
                    Address = string.IsNullOrWhiteSpace(Address) ? null : Address,
                    ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone,
                    Description = string.IsNullOrWhiteSpace(Description) ? null : Description,
                    CampTypeId = SelectedCampType.CampTypeId,
                    RegionId = SelectedRegion?.RegionId
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                var campToUpdate = context.Camps.Find(_currentCamp!.CampId);
                if (campToUpdate != null)
                {
                    campToUpdate.CampName = CampName;
                    campToUpdate.Address = string.IsNullOrWhiteSpace(Address) ? null : Address;
                    campToUpdate.ContactPhone = string.IsNullOrWhiteSpace(ContactPhone) ? null : ContactPhone;
                    campToUpdate.Description = string.IsNullOrWhiteSpace(Description) ? null : Description;
                    campToUpdate.CampTypeId = SelectedCampType.CampTypeId;
                    campToUpdate.RegionId = SelectedRegion?.RegionId;
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