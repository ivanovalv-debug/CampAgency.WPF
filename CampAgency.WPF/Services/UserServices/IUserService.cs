using CampAgency.WPF.Models.Entities;
using System.Collections.Generic;

namespace CampAgency.WPF.Services.UserServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        List<User> GetUsersByRole(string roleName);
        List<UserRole> GetAllRoles();
        User? GetUserById(int userId);
        bool AddUser(string login, string password, string fullName, string phone, string email, int roleId);
        bool UpdateUser(User user);
        bool ResetPassword(int userId, string newPassword);
        bool DeleteUser(int userId);
        bool IsLoginUnique(string login, int? excludeUserId = null);
    }
}