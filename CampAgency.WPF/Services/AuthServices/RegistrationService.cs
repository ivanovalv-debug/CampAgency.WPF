using System.Linq;
using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampAgency.WPF.Services.AuthServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public RegistrationService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public (bool success, string message, User? user) Register(string login, string password, string fullName, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(fullName))
                return (false, "Логин, пароль и ФИО обязательны для заполнения.", null);

            using var context = _contextFactory.CreateDbContext();

            // Проверяем уникальность логина
            if (context.Users.Any(u => u.Login == login))
                return (false, "Пользователь с таким логином уже существует.", null);

            // Находим роль "Родитель"
            var parentRole = context.UserRoles.FirstOrDefault(r => r.RoleName == "Родитель");
            if (parentRole == null)
                return (false, "В системе не определена роль 'Родитель'. Обратитесь к администратору.", null);

            var newUser = new User
            {
                Login = login,
                PasswordHash = password, // В будущем добавить хеширование
                FullName = fullName,
                Phone = phone,
                Email = email,
                UserRoleId = parentRole.UserRoleId
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return (true, "Регистрация успешна! Теперь вы можете войти.", newUser);
        }
    }
}