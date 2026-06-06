using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ReviewServices
{
    public interface IReviewService
    {
        List<Shift> GetCompletedShiftsForUser(int userId);
        bool HasUserReviewedShift(int userId, int shiftId);
        bool AddReview(int shiftId, int userId, int rating, string comment);
        double? GetAverageRatingForCamp(int campId);
    }
}