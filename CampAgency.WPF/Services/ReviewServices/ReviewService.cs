using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ReviewService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Shift> GetCompletedShiftsForUser(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            // Находим все бронирования пользователя со статусом "Завершён" (BookingStatusId = 4)
            var completedBookings = context.Bookings
                .Include(b => b.Shift)
                    .ThenInclude(s => s.Camp)
                .Where(b => b.Child.UserId == userId && b.BookingStatusId == 4)
                .ToList();

            // Уникальные смены, по которым ещё нет отзыва от этого пользователя
            var existingReviews = context.Reviews.Where(r => r.UserId == userId).Select(r => r.ShiftId).ToHashSet();
            return completedBookings
                .Select(b => b.Shift)
                .Where(s => !existingReviews.Contains(s.ShiftId))
                .Distinct()
                .ToList();
        }

        public bool HasUserReviewedShift(int userId, int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Reviews.Any(r => r.UserId == userId && r.ShiftId == shiftId);
        }

        public bool AddReview(int shiftId, int userId, int rating, string comment)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var review = new Review
                {
                    ShiftId = shiftId,
                    UserId = userId,
                    Rating = rating,
                    Comment = comment,
                    CreatedAt = DateTime.Now
                };
                context.Reviews.Add(review);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public double? GetAverageRatingForCamp(int campId)
        {
            using var context = _contextFactory.CreateDbContext();
            var ratings = context.Reviews
                .Include(r => r.Shift)
                .Where(r => r.Shift.CampId == campId)
                .Select(r => r.Rating)
                .ToList();
            if (!ratings.Any()) return null;
            return ratings.Average();
        }
    }
}