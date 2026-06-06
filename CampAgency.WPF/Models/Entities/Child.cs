using System;
using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Child
    {
        public int ChildId { get; set; }
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<ChildMedicalNote> ChildMedicalNotes { get; set; } = new List<ChildMedicalNote>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
        public virtual ICollection<ShiftJournal> ShiftJournals { get; set; } = new List<ShiftJournal>();
    }
}