using CampAgency.WPF.Models.Entities;

namespace CampAgency.WPF.Services.AuthServices
{
    public interface IRegistrationService
    {
        (bool success, string message, User? user) Register(string login, string password, string fullName, string phone, string email);
    }
}