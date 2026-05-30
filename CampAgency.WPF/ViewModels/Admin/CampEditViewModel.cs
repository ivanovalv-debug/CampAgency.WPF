using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _region = string.Empty;

        [ObservableProperty]
        private string _description = string.Empty;

        private Camp? _currentCamp;
        private bool _isNew;

        public CampEditViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Camp camp)
            {
                _currentCamp = camp;
                _isNew = false;
                Name = camp.Name;
                Region = camp.Region;
                Description = camp.Description;
            }
            else
            {
                _currentCamp = null;
                _isNew = true;
                Name = string.Empty;
                Region = string.Empty;
                Description = string.Empty;
            }
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Name)) return;

            using var context = _contextFactory.CreateDbContext();

            if (_isNew)
            {
                var newCamp = new Camp
                {
                    Name = Name,
                    Region = Region,
                    Description = Description,
                    Rating = 0.0,
                    Type = 0 // Default to Camp
                };
                context.Camps.Add(newCamp);
            }
            else
            {
                // Fetch-Modify-Save
                var campToUpdate = context.Camps.Find(_currentCamp!.Id);
                if (campToUpdate != null)
                {
                    campToUpdate.Name = Name;
                    campToUpdate.Region = Region;
                    campToUpdate.Description = Description;
                }
            }

            context.SaveChanges();
            _navigation.NavigateTo<CampsListViewModel>();
        }

        [RelayCommand]
        private void Cancel()
        {
            _navigation.NavigateTo<CampsListViewModel>();
        }
    }
}