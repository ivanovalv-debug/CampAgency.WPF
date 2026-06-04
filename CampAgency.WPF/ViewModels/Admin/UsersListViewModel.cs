using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.UserServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Admin
{
    public partial class UsersListViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<User> _users = new();
        [ObservableProperty] private ObservableCollection<UserRole> _roles = new();
        [ObservableProperty] private UserRole? _selectedRoleFilter;
        [ObservableProperty] private string _searchText = string.Empty;

        public UsersListViewModel(IUserService userService, INavigationService navigation, IDialogService dialogService)
        {
            _userService = userService;
            _navigation = navigation;
            _dialogService = dialogService;
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            var list = _userService.GetAllRoles();
            Roles = new ObservableCollection<UserRole>(list);
            // Добавляем "Все" как null-фильтр
            Roles.Insert(0, new UserRole { UserRoleId = 0, RoleName = "Все" });
            SelectedRoleFilter = Roles.FirstOrDefault();
        }

        private void LoadUsers()
        {
            if (SelectedRoleFilter == null || SelectedRoleFilter.UserRoleId == 0)
                Users = new ObservableCollection<User>(_userService.GetAllUsers());
            else
                Users = new ObservableCollection<User>(_userService.GetUsersByRole(SelectedRoleFilter.RoleName));
        }

        partial void OnSelectedRoleFilterChanged(UserRole? value)
        {
            LoadUsers();
        }

        [RelayCommand]
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadUsers();
                return;
            }
            var all = _userService.GetAllUsers();
            var filtered = all.Where(u => u.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                          u.Login.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                          (u.Email?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ?? false))
                              .ToList();
            Users = new ObservableCollection<User>(filtered);
        }

        [RelayCommand]
        private void AddUser() => _navigation.NavigateTo<UserEditViewModel>(null);

        [RelayCommand]
        private void EditUser(User user) => _navigation.NavigateTo<UserEditViewModel>(user);

        [RelayCommand]
        private void ResetPassword(User user)
        {
            if (user == null) return;
            string newPassword = "Pass123!"; // временный пароль
            if (_dialogService.ShowConfirmation($"Сбросить пароль пользователю {user.FullName}? Новый пароль: {newPassword}", "Сброс пароля"))
            {
                if (_userService.ResetPassword(user.UserId, newPassword))
                    _dialogService.ShowMessage($"Пароль сброшен. Новый пароль: {newPassword}", "Успех");
                else
                    _dialogService.ShowError("Не удалось сбросить пароль", "Ошибка");
            }
        }

        [RelayCommand]
        private void DeleteUser(User user)
        {
            if (user == null) return;
            if (!_dialogService.ShowConfirmation($"Удалить пользователя {user.FullName} (логин {user.Login})?", "Удаление"))
                return;
            var success = _userService.DeleteUser(user.UserId);
            if (success)
            {
                _dialogService.ShowMessage("Пользователь удалён", "Успех");
                LoadUsers();
            }
            else
                _dialogService.ShowError("Не удалось удалить пользователя", "Ошибка");
        }

        [RelayCommand]
        private void BackToDashboard() => _navigation.NavigateTo<AdminDashboardViewModel>();
    }
}