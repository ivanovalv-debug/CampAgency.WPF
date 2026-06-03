using System.Windows;
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Auth
{
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            // Привязка паролей вручную, так как PasswordBox не поддерживает обычный Binding
            if (DataContext is ViewModels.Auth.RegisterViewModel vm)
            {
                PasswordBox.PasswordChanged += (s, _) => vm.Password = PasswordBox.Password;
                ConfirmPasswordBox.PasswordChanged += (s, _) => vm.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }
    }
}