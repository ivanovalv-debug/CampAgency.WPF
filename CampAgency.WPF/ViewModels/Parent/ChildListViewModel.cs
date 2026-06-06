using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ChildListViewModel : ObservableObject
    {
        private readonly IChildService _childService;
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;

        [ObservableProperty] private ObservableCollection<Child> _children = new();

        public ChildListViewModel(IChildService childService, IAuthService authService, IDialogService dialogService, INavigationService navigationService)
        {
            _childService = childService;
            _authService = authService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            LoadChildren();
        }

        private void LoadChildren()
        {
            if (_authService.CurrentUser == null) return;
            var list = _childService.GetChildrenByUserId(_authService.CurrentUser.UserId);
            Children = new ObservableCollection<Child>(list);
        }

        [RelayCommand]
        private void AddChild() => _navigationService.NavigateTo<ChildEditViewModel>(null);

        [RelayCommand]
        private void EditChild(Child child) => _navigationService.NavigateTo<ChildEditViewModel>(child);

        [RelayCommand]
        private void BackToDashboard() => _navigationService.NavigateTo<ParentDashboardViewModel>();

        [RelayCommand]
        private async Task DeleteChild(Child child)
        {
            if (child == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить данные о ребёнке \"{child.FullName}\"?", "Удаление"))
                return;

            var success = _childService.DeleteChild(child.ChildId);
            if (success)
            {
                _dialogService.ShowMessage("Ребёнок удалён", "Успех");
                LoadChildren();
            }
            else
            {
                _dialogService.ShowError("Не удалось удалить ребёнка", "Ошибка");
            }
        }

        [RelayCommand]
        private void ManageDocuments(Child child) => _navigationService.NavigateTo<ChildDocumentsViewModel>(child);
    }
}