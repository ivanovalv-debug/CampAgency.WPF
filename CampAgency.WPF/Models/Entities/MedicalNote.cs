using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class MedicalNote
    {
        public int MedicalNoteId { get; set; }
        public string MedicalNoteName { get; set; } = null!;
        public virtual ICollection<ChildMedicalNote> ChildMedicalNotes { get; set; } = new List<ChildMedicalNote>();
    }
}