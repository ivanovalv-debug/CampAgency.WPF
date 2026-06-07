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
        [ObservableProperty] private ObservableCollection<ChildSelectionWrapper> _children = new();
        [ObservableProperty] private bool _isBookingInProgress;
        [ObservableProperty] private double? _averageRating;
        [ObservableProperty] private decimal _totalPrice;

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
                CalculateTotalPrice();
            }
        }

        partial void OnChildrenChanged(ObservableCollection<ChildSelectionWrapper> value)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (_shift == null) return;
            var selectedCount = Children.Count(c => c.IsSelected);
            TotalPrice = selectedCount * _shift.Price;
        }

        private void LoadChildren()
        {
            var currentUserId = _authService.CurrentUser?.UserId;
            if (currentUserId.HasValue)
            {
                var childrenList = _childService.GetChildrenByUserId(currentUserId.Value);
                var wrappers = childrenList.Select(c =>
                {
                    var wrapper = new ChildSelectionWrapper { Child = c, IsSelected = false };
                    wrapper.OnSelectionChanged += (s, e) => CalculateTotalPrice();
                    return wrapper;
                }).ToList();
                Children = new ObservableCollection<ChildSelectionWrapper>(wrappers);
            }
        }

        private void LoadAverageRating()
        {
            if (Shift?.Camp != null)
                AverageRating = _reviewService.GetAverageRatingForCamp(Shift.Camp.CampId);
        }

        [RelayCommand]
        private void BookShift()
        {
            if (_shift == null) return;

            var selectedChildren = Children.Where(c => c.IsSelected).Select(c => c.Child).ToList();
            if (!selectedChildren.Any())
            {
                _dialogService.ShowError("Выберите хотя бы одного ребёнка для бронирования", "Ошибка");
                return;
            }

            if (selectedChildren.Count > _shift.AvailableSeats)
            {
                _dialogService.ShowError($"Выбрано {selectedChildren.Count} детей, но свободно только {_shift.AvailableSeats} мест", "Ошибка");
                return;
            }

            var confirmationMessage = $"Забронировать смену в {_shift.Camp.CampName} для следующих детей:\n" +
                string.Join("\n", selectedChildren.Select(c => $"• {c.FullName}")) +
                $"\n\nИтоговая стоимость: {TotalPrice:C}";

            if (!_dialogService.ShowConfirmation(confirmationMessage, "Подтверждение бронирования"))
                return;

            IsBookingInProgress = true;
            try
            {
                var childIds = selectedChildren.Select(c => c.ChildId).ToList();
                var success = _shiftService.CreateBookings(childIds, _shift.ShiftId);
                if (success)
                {
                    _dialogService.ShowMessage("Бронирования созданы. Статус: Ожидает подтверждения", "Успех");
                    _navigation.NavigateTo<ShiftsCatalogViewModel>();
                }
                else
                {
                    _dialogService.ShowError("Не удалось забронировать. Возможно, места уже закончились или некоторые дети уже забронированы на эту смену.", "Ошибка");
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