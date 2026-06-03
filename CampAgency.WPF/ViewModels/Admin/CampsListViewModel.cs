using System.Collections.ObjectModel;
using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampsListViewModel : ObservableObject
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<Camp> _camps = new();

        public CampsListViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation, IDialogService dialogService)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadCamps();
        }

        private void LoadCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = context.Camps.Include(c => c.CampType).ToList();
            Camps = new ObservableCollection<Camp>(list);
        }

        [RelayCommand] private void AddCamp() => _navigation.NavigateTo<CampEditViewModel>(null);
        [RelayCommand] private void EditCamp(Camp camp) => _navigation.NavigateTo<CampEditViewModel>(camp);

        [RelayCommand]
        private void DeleteCamp(Camp camp)
        {
            if (camp == null) return;

            if (!_dialogService.ShowConfirmation($"Вы уверены, что хотите удалить лагерь \"{camp.CampName}\"?", "Удаление лагеря"))
                return;

            using var context = _contextFactory.CreateDbContext();
            var existing = context.Camps.Find(camp.CampId);
            if (existing != null)
            {
                context.Camps.Remove(existing);
                context.SaveChanges();
                LoadCamps();
                _dialogService.ShowMessage("Лагерь успешно удалён", "Успех");
            }
        }
    }
}