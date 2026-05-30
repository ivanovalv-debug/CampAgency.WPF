using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services
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
            System.Diagnostics.Debug.WriteLine($"AuthService.Login вызван: {login} / {password}");

            try
            {
                using var context = _contextFactory.CreateDbContext();

                // Проверяем, есть ли вообще пользователи в базе
                var allUsers = context.Users.ToList();
                System.Diagnostics.Debug.WriteLine($"Всего пользователей в БД: {allUsers.Count}");
                foreach (var u in allUsers)
                {
                    System.Diagnostics.Debug.WriteLine($"  User: {u.Login} / {u.PasswordHash} / Role: {u.Role}");
                }

                // Ищем пользователя
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.PasswordHash == password);

                System.Diagnostics.Debug.WriteLine($"Найден пользователь: {user != null}");

                if (user != null)
                {
                    CurrentUser = user;
                    System.Diagnostics.Debug.WriteLine($"CurrentUser установлен: {user.FullName}");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ОШИБКА в AuthService.Login: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}