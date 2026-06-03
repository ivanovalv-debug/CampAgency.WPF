using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class CampType
    {
        public int CampTypeId { get; set; }
        public string CampTypeName { get; set; } = null!;
        public virtual ICollection<Camp> Camps { get; set; } = new List<Camp>();
    }
}