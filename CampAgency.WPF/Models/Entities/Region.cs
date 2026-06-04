using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual ICollection<Camp> Camps { get; set; } = new List<Camp>();
    }
}