using AccessLeveler.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AccessLeveler.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser?> GetUserByIdAsync(string userId) 
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email) 
    {
        return await _userManager.FindByEmailAsync(email);
    }
}
