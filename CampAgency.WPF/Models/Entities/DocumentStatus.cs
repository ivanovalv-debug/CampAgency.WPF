using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class DocumentStatus
    {
        public int DocumentStatusId { get; set; }
        public string DocumentStatusName { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}