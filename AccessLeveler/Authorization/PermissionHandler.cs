using AccessLeveler.Data;
using AccessLeveler.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AccessLeveler.Authorization;


public class PermissionHandler : AuthorizationHandler<PermissionAuthorizeAttribute>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public PermissionHandler(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizeAttribute requirement)
    {
        var user = await _userManager.GetUserAsync(context.User);
        if (user == null)
        {
            context.Fail();
            return;
        }

        
        var permissions = await GetUserPermissionsAsync(user);

        
        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
    }

    private async Task<IList<string>> GetUserPermissionsAsync(ApplicationUser user)
    {
        
        var roles = await _userManager.GetRolesAsync(user);

       
        var permissions = new List<string>();

        foreach (var role in roles)
        {
            
            var rolePermissions = await _context.RolePermissions
                .Where(rp => rp.Role.Name == role)
                .Select(rp => rp.Permission.PermissionName)
                .ToListAsync();

            permissions.AddRange(rolePermissions);
        }

        return permissions.Distinct().ToList(); 
    }
}
