using CampAgency.WPF.Services;
using CampAgency.WPF.ViewModels.Admin;
using CampAgency.WPF.ViewModels.Operator;
using CampAgency.WPF.ViewModels.Parent;
using CampAgency.WPF.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Windows;

namespace CampAgency.WPF.ViewModels.Auth
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string _login = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        public LoginViewModel(IAuthService authService, INavigationService navigationService)
        {
            _authService = authService;
            _navigationService = navigationService;
        }

        // Убрали CanExecute, теперь кнопка будет активна всегда
        [RelayCommand]
        private void ExecuteLogin()
        {
            MessageBox.Show($"Попытка входа: {Login} / {Password}", "Отладка");
            Debug.WriteLine($"=== КНОПКА НАЖАТА ===");

            try
            {
                if (_authService.Login(Login, Password))
                {
                    Debug.WriteLine("Вход успешен!");
                    ErrorMessage = string.Empty;

                    if (_authService.CurrentUser != null)
                    {
                        switch (_authService.CurrentUser.Role)
                        {
                            case UserRole.Parent:
                                _navigationService.NavigateTo<ParentDashboardViewModel>();
                                break;
                            case UserRole.Operator:
                                _navigationService.NavigateTo<OperatorDashboardViewModel>();
                                break;
                            case UserRole.Admin:
                                _navigationService.NavigateTo<AdminDashboardViewModel>();
                                break;
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Вход НЕ успешен!");
                    ErrorMessage = "Неверный логин или пароль";
                    MessageBox.Show("Ошибка входа! Проверьте логин/пароль", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Исключение: {ex.Message}", "Ошибка");
                Debug.WriteLine($"EXCEPTION: {ex.Message}");
            }
        }
    }
}