using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class CampsListViewModel : ObservableObject
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly INavigationService _navigation;

        [ObservableProperty]
        private ObservableCollection<Camp> _camps = new();

        public CampsListViewModel(IDbContextFactory<AppDbContext> contextFactory, INavigationService navigation)
        {
            _contextFactory = contextFactory;
            _navigation = navigation;
            LoadCamps();
        }

        private void LoadCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            var list = context.Camps.ToList();
            Camps = new ObservableCollection<Camp>(list);
        }

        [RelayCommand]
        private void AddCamp()
        {
            // Передаем null, чтобы открыть форму создания нового лагеря
            _navigation.NavigateTo<CampEditViewModel>(null);
        }

        [RelayCommand]
        private void EditCamp(Camp camp)
        {
            if (camp != null)
            {
                _navigation.NavigateTo<CampEditViewModel>(camp);
            }
        }

        [RelayCommand]
        private void DeleteCamp(Camp camp)
        {
            if (camp == null) return;

            // Простая проверка: нет ли активных смен? (можно добавить позже)

            using var context = _contextFactory.CreateDbContext();
            var existing = context.Camps.Find(camp.Id);
            if (existing != null)
            {
                context.Camps.Remove(existing);
                context.SaveChanges();
                LoadCamps(); // Перезагружаем список
            }
        }
    }
}