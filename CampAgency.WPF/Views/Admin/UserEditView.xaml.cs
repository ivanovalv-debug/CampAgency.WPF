using System.Windows;
using System.Windows.Controls;

namespace CampAgency.WPF.Views.Admin
{
    public partial class UserEditView : UserControl
    {
        public UserEditView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.Admin.UserEditViewModel vm)
            {
                PasswordBox.PasswordChanged += (s, _) => vm.Password = PasswordBox.Password;
                ConfirmPasswordBox.PasswordChanged += (s, _) => vm.ConfirmPassword = ConfirmPasswordBox.Password;
            }
        }
    }
}