using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ShiftServices
{
    public class ShiftCatalogService : IShiftCatalogService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShiftCatalogService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Shift> GetShiftsWithFilters(int? regionId, int? campTypeId, DateOnly? startDateFrom, DateOnly? startDateTo, decimal? minPrice, decimal? maxPrice)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Shifts
                .Include(s => s.Camp)
                    .ThenInclude(c => c.CampType)
                .Include(s => s.Camp)
                    .ThenInclude(c => c.Region)
                .Where(s => s.StartDate >= DateOnly.FromDateTime(DateTime.Today) && s.AvailableSeats > 0);

            if (regionId.HasValue && regionId.Value > 0)
                query = query.Where(s => s.Camp.RegionId == regionId.Value);
            if (campTypeId.HasValue && campTypeId.Value > 0)
                query = query.Where(s => s.Camp.CampTypeId == campTypeId.Value);
            if (startDateFrom.HasValue)
                query = query.Where(s => s.StartDate >= startDateFrom.Value);
            if (startDateTo.HasValue)
                query = query.Where(s => s.StartDate <= startDateTo.Value);
            if (minPrice.HasValue)
                query = query.Where(s => s.Price >= minPrice.Value);
            if (maxPrice.HasValue)
                query = query.Where(s => s.Price <= maxPrice.Value);

            return query.OrderBy(s => s.StartDate).ToList();
        }

        public List<Region> GetAllRegions()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Regions.OrderBy(r => r.RegionName).ToList();
        }

        public Shift? GetShiftById(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Shifts
                .Include(s => s.Camp)
                .ThenInclude(c => c.CampType)
                .FirstOrDefault(s => s.ShiftId == shiftId);
        }

        public List<CampType> GetCampTypes()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CampTypes.ToList();
        }


        public bool CreateBookings(List<int> childIds, int shiftId)
        {
            if (childIds == null || !childIds.Any()) return false;

            using var context = _contextFactory.CreateDbContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var shift = context.Shifts.Find(shiftId);
                if (shift == null || shift.AvailableSeats < childIds.Count) return false;

                var existingBookings = context.Bookings
                    .Where(b => b.ShiftId == shiftId && childIds.Contains(b.ChildId))
                    .Select(b => b.ChildId)
                    .ToHashSet();

                var newChildIds = childIds.Where(id => !existingBookings.Contains(id)).ToList();
                if (!newChildIds.Any()) return false;

                var bookingStatus = context.BookingStatuses.FirstOrDefault(bs => bs.BookingStatusName == "Ожидает подтверждения");
                if (bookingStatus == null) return false;

                foreach (var childId in newChildIds)
                {
                    var booking = new Booking
                    {
                        ChildId = childId,
                        ShiftId = shiftId,
                        BookingStatusId = bookingStatus.BookingStatusId,
                        CreatedAt = DateTime.Now
                    };
                    context.Bookings.Add(booking);
                }

                shift.AvailableSeats -= newChildIds.Count;
                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public List<Booking> GetBookingsByUserId(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Bookings
                .Include(b => b.Child)
                .Include(b => b.Shift)
                .ThenInclude(s => s.Camp)
                .Include(b => b.BookingStatus)
                .Where(b => b.Child.UserId == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToList();
        }
    }
}