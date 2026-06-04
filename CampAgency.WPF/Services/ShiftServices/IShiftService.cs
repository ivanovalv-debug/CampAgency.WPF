using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ShiftServices
{
    public interface IShiftService
    {
        List<Shift> GetShiftsByCampId(int campId);
        List<Camp> GetAllCamps();
        bool AddShift(int campId, DateOnly startDate, DateOnly endDate, int totalSeats, decimal price);
        bool UpdateShift(Shift shift);
        bool DeleteShift(int shiftId);
    }
}