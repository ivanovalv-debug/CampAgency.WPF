using System.Collections.Generic;
using CampAgency.WPF.Models.Enums; 

namespace CampAgency.WPF.Models.Entities;

public partial class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    
    public UserRole Role { get; set; }

    public string FullName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();
}