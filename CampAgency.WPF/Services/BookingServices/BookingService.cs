using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public BookingService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Booking> GetBookingsWithFilters(int? statusId, int? campId, string? searchText)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Bookings
                .Include(b => b.Child)
                    .ThenInclude(c => c.User)
                .Include(b => b.Shift)
                    .ThenInclude(s => s.Camp)
                .Include(b => b.BookingStatus)
                .AsQueryable();

            if (statusId.HasValue && statusId > 0)
                query = query.Where(b => b.BookingStatusId == statusId);
            if (campId.HasValue && campId > 0)
                query = query.Where(b => b.Shift.CampId == campId);
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.ToLower();
                query = query.Where(b =>
                    b.Child.FullName.ToLower().Contains(searchText) ||
                    b.Child.User.FullName.ToLower().Contains(searchText) ||
                    b.Child.User.Email.ToLower().Contains(searchText)
                );
            }
            return query.OrderByDescending(b => b.CreatedAt).ToList();
        }

        public Booking? GetBookingById(int bookingId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Bookings
                .Include(b => b.Child)
                    .ThenInclude(c => c.User)
                .Include(b => b.Child)
                    .ThenInclude(c => c.Documents)
                        .ThenInclude(d => d.DocumentStatus)
                .Include(b => b.Shift)
                    .ThenInclude(s => s.Camp)
                        .ThenInclude(c => c.CampType)
                .Include(b => b.BookingStatus)
                .FirstOrDefault(b => b.BookingId == bookingId);
        }

        public bool UpdateBookingStatus(int bookingId, int newStatusId)
        {
            using var context = _contextFactory.CreateDbContext();
            var booking = context.Bookings.Find(bookingId);
            if (booking == null) return false;
            booking.BookingStatusId = newStatusId;
            context.SaveChanges();
            return true;
        }

        public bool UpdateDocumentStatus(int documentId, int newStatusId, string? operatorComment)
        {
            using var context = _contextFactory.CreateDbContext();
            var doc = context.Documents.Find(documentId);
            if (doc == null) return false;
            doc.DocumentStatusId = newStatusId;
            doc.OperatorComment = operatorComment;
            context.SaveChanges();
            return true;
        }

        public List<BookingStatus> GetAllBookingStatuses()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.BookingStatuses.ToList();
        }

        public List<Camp> GetAllCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Camps.OrderBy(c => c.CampName).ToList();
        }

        public List<DocumentStatus> GetAllDocumentStatuses()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.DocumentStatuses.ToList();
        }
    }
}