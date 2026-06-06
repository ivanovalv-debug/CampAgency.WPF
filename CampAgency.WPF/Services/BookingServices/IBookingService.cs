using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.BookingServices
{
    public interface IBookingService
    {
        List<Booking> GetBookingsWithFilters(int? statusId, int? campId, string? searchText);
        Booking? GetBookingById(int bookingId);
        bool UpdateBookingStatus(int bookingId, int newStatusId);
        bool UpdateDocumentStatus(int documentId, int newStatusId, string? operatorComment);
        List<BookingStatus> GetAllBookingStatuses();
        List<Camp> GetAllCamps();
        List<DocumentStatus> GetAllDocumentStatuses();
    }
}