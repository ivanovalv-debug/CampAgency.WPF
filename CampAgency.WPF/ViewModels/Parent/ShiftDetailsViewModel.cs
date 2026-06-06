using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.AuthServices;
using CampAgency.WPF.Services.ChildServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CampAgency.WPF.Services.ReviewServices;
using CampAgency.WPF.Services.ShiftServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Parent
{
    public partial class ShiftDetailsViewModel : ObservableObject, INavigationAware
    {
        private readonly IShiftCatalogService _shiftService;
        private readonly IChildService _childService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialogService;
        private readonly IAuthService _authService;
        private readonly IReviewService _reviewService;

        [ObservableProperty] private Shift? _shift;
        [ObservableProperty] private ObservableCollection<Child> _myChildren = new();
        [ObservableProperty] private Child? _selectedChild;
        [ObservableProperty] private bool _isBookingInProgress;
        [ObservableProperty] private double? _averageRating;

        public ShiftDetailsViewModel(IShiftCatalogService shiftService, IChildService childService, INavigationService navigation, IDialogService dialogService, IAuthService authService, IReviewService reviewService)
        {
            _shiftService = shiftService;
            _childService = childService;
            _navigation = navigation;
            _dialogService = dialogService;
            _authService = authService;
            _reviewService = reviewService;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is int shiftId)
            {
                _shift = _shiftService.GetShiftById(shiftId);
                OnPropertyChanged(nameof(Shift));
                LoadChildren();
                LoadAverageRating();
            }
        }

        private void LoadChildren()
        {
            if (_shift == null) return;
            // Предполагаем, что в AuthService есть CurrentUser
            var currentUserId = _authService.CurrentUser?.UserId;
            if (currentUserId.HasValue)
                MyChildren = new ObservableCollection<Child>(_childService.GetChildrenByUserId(currentUserId.Value));
        }
        private void LoadAverageRating()
        {
            if (Shift?.Camp != null)
                AverageRating = _reviewService.GetAverageRatingForCamp(Shift.Camp.CampId);
        }

        [RelayCommand]
        private async Task BookShift()
        {
            if (_shift == null) return;
            if (SelectedChild == null)
            {
                _dialogService.ShowError("Выберите ребёнка для бронирования", "Ошибка");
                return;
            }
            if (!_dialogService.ShowConfirmation($"Забронировать смену в {_shift.Camp.CampName} для {SelectedChild.FullName}? Стоимость: {_shift.Price:C}", "Подтверждение бронирования"))
                return;

            IsBookingInProgress = true;
            try
            {
                var success = _shiftService.CreateBooking(SelectedChild.ChildId, _shift.ShiftId);
                if (success)
                {
                    _dialogService.ShowMessage("Бронирование создано. Статус: Ожидает подтверждения", "Успех");
                    _navigation.NavigateTo<ShiftsCatalogViewModel>();
                }
                else
                {
                    _dialogService.ShowError("Не удалось забронировать. Возможно, места уже закончились или ребёнок уже забронирован на эту смену.", "Ошибка");
                }
            }
            finally
            {
                IsBookingInProgress = false;
            }
        }

        [RelayCommand]
        private void Cancel() => _navigation.NavigateTo<ShiftsCatalogViewModel>();
    }
}