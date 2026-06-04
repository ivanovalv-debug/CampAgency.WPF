using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.ShiftServices
{
    public interface IShiftCatalogService
    {
        List<Shift> GetShiftsWithFilters(int? regionId, int? campTypeId, DateOnly? startDateFrom, DateOnly? startDateTo, decimal? minPrice, decimal? maxPrice);
        List<Region> GetAllRegions();
        Shift? GetShiftById(int shiftId);
        List<CampType> GetCampTypes();
        //List<string> GetRegions();
        bool CreateBooking(int childId, int shiftId);
        List<Booking> GetBookingsByUserId(int userId);
    }
}