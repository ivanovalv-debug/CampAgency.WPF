using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.JournalServices
{
    public class JournalService : IJournalService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public JournalService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<CampEvent> GetAllEvents()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CampEvents.ToList();
        }

        public List<ShiftJournal> GetJournalByShiftId(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.ShiftJournals
                .Include(j => j.Child)
                .Include(j => j.CampEvent)
                .Include(j => j.Operator)
                .Where(j => j.ShiftId == shiftId)
                .OrderByDescending(j => j.TimeStamp)
                .ToList();
        }

        public List<Child> GetChildrenByShiftId(int shiftId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Children
                .Include(c => c.User)
                .Where(c => c.Bookings.Any(b => b.ShiftId == shiftId))
                .ToList();
        }

        public bool AddJournalEntry(int shiftId, int childId, int campEventId, int operatorId, string note)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var entry = new ShiftJournal
                {
                    ShiftId = shiftId,
                    ChildId = childId,
                    CampEventId = campEventId,
                    OperatorId = operatorId,
                    Note = note,
                    TimeStamp = DateTime.Now
                };
                context.ShiftJournals.Add(entry);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Child> GetChildrenByShiftAndEvent(int shiftId, string eventName)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.ShiftJournals
                .Include(j => j.Child)
                    .ThenInclude(c => c.User)
                .Where(j => j.ShiftId == shiftId && j.CampEvent.EventName == eventName)
                .Select(j => j.Child)
                .Distinct()
                .ToList();
        }

        public List<ShiftJournal> GetJournalByChildId(int childId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.ShiftJournals
                .Include(j => j.Shift)
                    .ThenInclude(s => s.Camp)
                .Include(j => j.CampEvent)
                .Include(j => j.Operator)
                .Where(j => j.ChildId == childId)
                .OrderByDescending(j => j.TimeStamp)
                .ToList();
        }
    }
}