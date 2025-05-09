using AccessLeveler.Models.Application_Models;

namespace AccessLeveler.Services;

public interface IUserService
{
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
}