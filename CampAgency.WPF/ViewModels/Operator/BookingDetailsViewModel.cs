using CampAgency.WPF.Models.Entities;
using CampAgency.WPF.Services.BookingServices;
using CampAgency.WPF.Services.DialogServices;
using CampAgency.WPF.Services.NavigationServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace CampAgency.WPF.ViewModels.Operator
{
    public partial class BookingDetailsViewModel : ObservableObject, INavigationAware
    {
        private readonly IBookingService _bookingService;
        private readonly INavigationService _navigation;
        private readonly IDialogService _dialog;

        [ObservableProperty] private Booking? _booking;
        [ObservableProperty] private ObservableCollection<BookingStatus> _availableStatuses = new();
        [ObservableProperty] private BookingStatus? _selectedStatus;
        [ObservableProperty] private string _operatorComment = string.Empty;

        public BookingDetailsViewModel(IBookingService bookingService, INavigationService navigation, IDialogService dialog)
        {
            _bookingService = bookingService;
            _navigation = navigation;
            _dialog = dialog;
        }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is int bookingId)
            {
                _booking = _bookingService.GetBookingById(bookingId);
                OnPropertyChanged(nameof(Booking));
                LoadStatuses();
                OperatorComment = string.Empty;
            }
        }

        private void LoadStatuses()
        {
            AvailableStatuses = new ObservableCollection<BookingStatus>(_bookingService.GetAllBookingStatuses());
            if (Booking != null)
                SelectedStatus = AvailableStatuses.FirstOrDefault(s => s.BookingStatusId == Booking.BookingStatusId);
        }

        [RelayCommand]
        private void UpdateBookingStatus()
        {
            if (SelectedStatus == null || Booking == null) return;
            if (SelectedStatus.BookingStatusId == Booking.BookingStatusId) return;

            if (_dialog.ShowConfirmation($"Изменить статус заявки на \"{SelectedStatus.BookingStatusName}\"?"))
            {
                if (_bookingService.UpdateBookingStatus(Booking.BookingId, SelectedStatus.BookingStatusId))
                {
                    _dialog.ShowMessage("Статус обновлён", "Успех");
                    OnNavigatedTo(Booking.BookingId);
                }
                else
                    _dialog.ShowError("Ошибка обновления статуса", "Ошибка");
            }
        }

        [RelayCommand]
        private void AcceptDocument(Document doc)
        {
            if (doc == null) return;
            if (_bookingService.UpdateDocumentStatus(doc.DocumentId, 2, OperatorComment)) // 2 = Проверен
            {
                _dialog.ShowMessage("Документ принят", "Успех");
                OnNavigatedTo(Booking?.BookingId);
            }
            else
                _dialog.ShowError("Ошибка", "Ошибка");
        }

        [RelayCommand]
        private void RejectDocument(Document doc)
        {
            if (doc == null) return;
            if (_dialog.ShowConfirmation($"Отклонить документ \"{doc.DocumentType?.DocumentTypeName}\"? Введите комментарий:", "Отклонение документа"))
            {
                // В простом варианте используем поле OperatorComment
                if (_bookingService.UpdateDocumentStatus(doc.DocumentId, 3, OperatorComment)) // 3 = Отклонён
                {
                    _dialog.ShowMessage("Документ отклонён", "Успех");
                    OnNavigatedTo(Booking?.BookingId);
                }
                else
                    _dialog.ShowError("Ошибка", "Ошибка");
            }
        }

        [RelayCommand]
        private void BackToList() => _navigation.NavigateTo<BookingsListViewModel>();
    }
}