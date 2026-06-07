using System;

namespace CampAgency.WPF.Models.Entities
{
    public partial class ShiftJournal
    {
        public int ShiftJournalId { get; set; }
        public int ChildId { get; set; }
        public int? ShiftId { get; set; }
        public int CampEventId { get; set; }
        public int OperatorId { get; set; }
        public string Note { get; set; } = null!;
        public DateTime TimeStamp { get; set; }

        public virtual Shift Shift { get; set; } = null!;
        public virtual Child Child { get; set; } = null!;
        public virtual CampEvent CampEvent { get; set; } = null!;
        public virtual User Operator { get; set; } = null!;
    }
}