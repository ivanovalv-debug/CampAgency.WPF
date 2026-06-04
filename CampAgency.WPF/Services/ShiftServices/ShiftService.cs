using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.ShiftServices
{
    public class ShiftService : IShiftService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ShiftService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Shift> GetShiftsByCampId(int campId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Shifts
                .Include(s => s.Camp)
                .Where(s => s.CampId == campId)
                .OrderBy(s => s.StartDate)
                .ToList();
        }

        public List<Camp> GetAllCamps()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Camps.OrderBy(c => c.CampName).ToList();
        }

        public bool AddShift(int campId, DateOnly startDate, DateOnly endDate, int totalSeats, decimal price)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var shift = new Shift
                {
                    CampId = campId,
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalSeats = totalSeats,
                    Price = price
                };
                context.Shifts.Add(shift);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateShift(Shift shift)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Shifts.Find(shift.ShiftId);
            if (existing == null) return false;
            existing.CampId = shift.CampId;
            existing.StartDate = shift.StartDate;
            existing.EndDate = shift.EndDate;
            existing.TotalSeats = shift.TotalSeats;
            existing.Price = shift.Price;
            context.SaveChanges();
            return true;
        }

        public bool DeleteShift(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            var shift = context.Shifts.Find(shiftId);
            if (shift == null) return false;
            context.Shifts.Remove(shift);
            context.SaveChanges();
            return true;
        }
    }
}