namespace CampAgency.WPF.Models.Entities
{
    public partial class ChildMedicalNote
    {
        public int ChildMedicalNoteId { get; set; }
        public int MedicalNoteId { get; set; }
        public int ChildId { get; set; }

        public virtual MedicalNote MedicalNote { get; set; } = null!;
        public virtual Child Child { get; set; } = null!;
    }
}