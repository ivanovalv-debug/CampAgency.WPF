namespace CampAgency.WPF.Models.Entities
{
    public partial class CampEvent
    {
        public int CampEventId { get; set; }
        public string EventName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ShiftJournal> ShiftJournals { get; set; } = new List<ShiftJournal>();
    }
}