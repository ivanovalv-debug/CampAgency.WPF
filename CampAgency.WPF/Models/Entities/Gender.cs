using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class Gender
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    }
}