using System;
using System.Xml.Linq;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int ChildId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentStatusId { get; set; }
        public string? FilePath { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Child Child { get; set; } = null!;
        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual DocumentStatus DocumentStatus { get; set; } = null!;
    }
}