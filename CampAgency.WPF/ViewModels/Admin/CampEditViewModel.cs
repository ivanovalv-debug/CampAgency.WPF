using System.Collections.ObjectModel;
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;

        [ObservableProperty] private string _campName = string.Empty;
        [ObservableProperty] private string _region = string.Empty;
        [ObservableProperty] private string _description = string.Empty;
        [ObservableProperty] private ObservableCollection<CampType> _campTypes = new();
        [ObservableProperty] private CampType? _selectedCampType;

        private Camp? _currentCamp;
        private bool _isNew;

        public CampEditViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
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
                Description = camp.Description ?? string.Empty;
                SelectedCampType = camp.CampType;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                CampName = string.Empty;
                Region = string.Empty;
                Description = string.Empty;
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
            if (string.IsNullOrWhiteSpace(CampName) || SelectedCampType == null) return;
            using var context = _contextFactory.CreateDbContext();
            if (_isNew)
            {
                var newCamp = new Camp
                {
                    CampName = CampName,
                    Region = Region,
                    Description = Description,
                    CampTypeId = SelectedCampType.CampTypeId,
                    Rating = 0
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                var campToUpdate = context.Camps.Find(_currentCamp!.CampId);
                if (campToUpdate != null)
                {
                    campToUpdate.CampName = CampName;
                    campToUpdate.Region = Region;
                    campToUpdate.Description = Description;
                    campToUpdate.CampTypeId = SelectedCampType.CampTypeId;
                }
            }
            context.SaveChanges();
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand] private void Cancel() => _navigation.NavigateTo<CampsListViewModel>();
    }
}