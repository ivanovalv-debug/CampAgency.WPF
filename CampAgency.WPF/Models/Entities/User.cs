using System.Collections.Generic;

namespace CampAgency.WPF.Models.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;
        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}