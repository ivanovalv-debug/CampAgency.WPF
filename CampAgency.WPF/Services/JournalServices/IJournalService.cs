using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.JournalServices
{
    public interface IJournalService
    {
        List<CampEvent> GetAllEvents();
        List<ShiftJournal> GetJournalByShiftId(int shiftId);
        bool AddJournalEntry(int shiftId, int childId, int campEventId, int operatorId, string note);
        List<Child> GetChildrenByShiftId(int shiftId);
        List<ShiftJournal> GetJournalByChildId(int childId);
        List<Child> GetChildrenByShiftAndEvent(int shiftId, string eventName);
    }
}