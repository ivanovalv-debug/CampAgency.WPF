using CampAgency.WPF.Data;
using CampAgency.WPF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampAgency.WPF.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<User> GetAllUsers()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole).ToList();
        }

        public List<User> GetUsersByRole(string roleName)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole)
                .Where(u => u.UserRole.RoleName == roleName)
                .ToList();
        }

        public List<UserRole> GetAllRoles()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.UserRoles.ToList();
        }

        public User? GetUserById(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Users.Include(u => u.UserRole).FirstOrDefault(u => u.UserId == userId);
        }

        public bool AddUser(string login, string password, string fullName, string phone, string email, int roleId)
        {
            try
            {
                using var context = _contextFactory.CreateDbContext();
                var user = new User
                {
                    Login = login,
                    PasswordHash = password, // TODO: хеширование
                    FullName = fullName,
                    Phone = phone,
                    Email = email,
                    UserRoleId = roleId
                };
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool UpdateUser(User user)
        {
            using var context = _contextFactory.CreateDbContext();
            var existing = context.Users.Find(user.UserId);
            if (existing == null) return false;
            existing.FullName = user.FullName;
            existing.Phone = user.Phone;
            existing.Email = user.Email;
            existing.UserRoleId = user.UserRoleId;
            // Логин и пароль не меняем через этот метод
            context.SaveChanges();
            return true;
        }

        public bool ResetPassword(int userId, string newPassword)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.Users.Find(userId);
            if (user == null) return false;
            user.PasswordHash = newPassword; // TODO: хеширование
            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            using var context = _contextFactory.CreateDbContext();
            var user = context.Users.Find(userId);
            if (user == null) return false;
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }

        public bool IsLoginUnique(string login, int? excludeUserId = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Users.Where(u => u.Login == login);
            if (excludeUserId.HasValue)
                query = query.Where(u => u.UserId != excludeUserId.Value);
            return !query.Any();
        }
    }
}