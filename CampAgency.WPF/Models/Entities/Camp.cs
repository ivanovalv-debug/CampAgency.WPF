using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Camp
    {
        public int CampId { get; set; }
        public int CampTypeId { get; set; }
        public string CampName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ContactPhone { get; set; }
        public decimal? Rating { get; set; }
        public int? RegionId { get; set; }
        public string? Address { get; set; }

        public virtual CampType CampType { get; set; } = null!;
        public virtual Region? Region { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }
}