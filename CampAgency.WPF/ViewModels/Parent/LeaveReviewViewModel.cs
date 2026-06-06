using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ReviewServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class LeaveReviewViewModel : ObservableObject, INavigationAware
    {
        private readonly IReviewService _reviewService;
        private readonly IAuthService _authService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private ObservableCollection<Shift> _completedShifts = new();
        [ObservableProperty] private Shift? _selectedShift;
        [ObservableProperty] private int _rating = 5;
        [ObservableProperty] private string _comment = string.Empty;

        public LeaveReviewViewModel(IReviewService reviewService, IAuthService authService, INavigationService navigation, IDialogService dialog)
        {
            _reviewService = reviewService;
            _authService = authService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (_authService.CurrentUser != null)
            {
                var shifts = _reviewService.GetCompletedShiftsForUser(_authService.CurrentUser.UserId);
                CompletedShifts = new ObservableCollection<Shift>(shifts);
                SelectedShift = CompletedShifts.FirstOrDefault();
            }
        }

        [RelayCommand]
        private void SubmitReview()
        {
            if (SelectedShift == null)
            {
                _dialog.ShowError("Выберите смену для отзыва", "Ошибка");
                return;
            }
            if (Rating < 1 || Rating > 5)
            {
                _dialog.ShowError("Оценка должна быть от 1 до 5", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Comment))
            {
                _dialog.ShowError("Введите текст отзыва", "Ошибка");
                return;
            }

            var userId = _authService.CurrentUser!.UserId;
            if (_reviewService.HasUserReviewedShift(userId, SelectedShift.ShiftId))
            {
                _dialog.ShowError("Вы уже оставляли отзыв на эту смену", "Ошибка");
                return;
            }

            if (_reviewService.AddReview(SelectedShift.ShiftId, userId, Rating, Comment))
            {
                _dialog.ShowMessage("Спасибо за отзыв!", "Успех");
                _navigation.NavigateTo<ParentDashboardViewModel>();
            }
            else
            {
                _dialog.ShowError("Не удалось сохранить отзыв", "Ошибка");
            }
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<ParentDashboardViewModel>();
    }
}