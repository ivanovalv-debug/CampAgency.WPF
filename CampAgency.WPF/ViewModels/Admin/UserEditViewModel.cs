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
    public partial class UserEditViewModel : ObservableObject, INavigationAware
    {
        private readonly IUserService _userService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;

        [ObservableProperty] private ObservableCollection<UserRole> _roles = new();
        [ObservableProperty] private UserRole? _selectedRole;
        [ObservableProperty] private string _login = string.Empty;
        [ObservableProperty] private string _password = string.Empty;
        [ObservableProperty] private string _confirmPassword = string.Empty;
        [ObservableProperty] private string _fullName = string.Empty;
        [ObservableProperty] private string _phone = string.Empty;
        [ObservableProperty] private string _email = string.Empty;

        private User? _currentUser;
        private bool _isNew;

        public UserEditViewModel(IUserService userService, INavigationService navigation, IDialogService dialogService)
        {
            _userService = userService;
            _navigation = navigation;
            _dialogService = dialogService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            LoadRoles();
            if (parameter is User user)
            {
                _currentUser = user;
                _isNew = false;
                Login = user.Login;
                FullName = user.FullName;
                Phone = user.Phone ?? string.Empty;
                Email = user.Email ?? string.Empty;
                SelectedRole = user.UserRole;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
            else
            {
                _currentUser = null;
                _isNew = true;
                Login = string.Empty;
                FullName = string.Empty;
                Phone = string.Empty;
                Email = string.Empty;
                SelectedRole = null;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
        }

        private void LoadRoles()
        {
            var list = _userService.GetAllRoles();
            Roles = new ObservableCollection<UserRole>(list);
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(FullName))
            {
                _dialogService.ShowError("Введите полное имя", "Ошибка");
                return;
            }
            if (SelectedRole == null)
            {
                _dialogService.ShowError("Выберите роль", "Ошибка");
                return;
            }
            if (_isNew)
            {
                if (string.IsNullOrWhiteSpace(Login))
                {
                    _dialogService.ShowError("Введите логин", "Ошибка");
                    return;
                }
                if (!_userService.IsLoginUnique(Login))
                {
                    _dialogService.ShowError("Логин уже существует", "Ошибка");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    _dialogService.ShowError("Введите пароль", "Ошибка");
                    return;
                }
                if (Password != ConfirmPassword)
                {
                    _dialogService.ShowError("Пароли не совпадают", "Ошибка");
                    return;
                }
                var success = _userService.AddUser(Login, Password, FullName, Phone, Email, SelectedRole.UserRoleId);
                if (success)
                    _dialogService.ShowMessage("Пользователь добавлен", "Успех");
                else
                {
                    _dialogService.ShowError("Ошибка добавления", "Ошибка");
                    return;
                }
            }
            else
            {
                // Обновляем только поля, которые можно менять
                _currentUser!.FullName = FullName;
                _currentUser.Phone = string.IsNullOrWhiteSpace(Phone) ? null : Phone;
                _currentUser.Email = string.IsNullOrWhiteSpace(Email) ? null : Email;
                _currentUser.UserRoleId = SelectedRole.UserRoleId;
                var success = _userService.UpdateUser(_currentUser);
                if (success)
                    _dialogService.ShowMessage("Данные обновлены", "Успех");
                else
                {
                    _dialogService.ShowError("Ошибка обновления", "Ошибка");
                    return;
                }
            }
            _navigation.NavigateTo<UsersListViewModel>();
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<UsersListViewModel>();
    }
}