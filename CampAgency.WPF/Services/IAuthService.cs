using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services
{
    public interface IAuthService
    {
        User? CurrentUser { get; }
        bool Login(string login, string password);
        void Logout();
    }
}