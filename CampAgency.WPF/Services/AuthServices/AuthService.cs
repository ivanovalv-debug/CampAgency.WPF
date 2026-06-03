using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        public User? CurrentUser { get; private set; }

        public AuthService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool Login(string login, string password)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var user = context.Users.Include(u => u.UserRole)
                    .FirstOrDefault(u => u.Login == login && u.PasswordHash == password);
                if (user != null)
                {
                    CurrentUser = user;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void Logout() => CurrentUser = null;
    }
}