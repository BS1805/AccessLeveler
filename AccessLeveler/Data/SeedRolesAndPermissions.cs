using Microsoft.AspNetCore.Identity;
using AccessLeveler.Models;
namespace AccessLeveler.Data;
public class SeedRolesAndPermissions
{
    public static void SeedData(IServiceProvider serviceProvider, ApplicationDbContext context)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

      
        var roles = new string[] { "Admin", "Therapist", "Client" };
        foreach (var role in roles)
        {
            if (roleManager.FindByNameAsync(role).Result == null)
            {
                var newRole = new ApplicationRole(role);
                roleManager.CreateAsync(newRole).Wait();
            }
        }

        
        var permissions = new Permission[]
        {
            new Permission { Id = Guid.NewGuid(), PermissionName = "ViewAdminModule", Description = "Can view the Admin module" },
            new Permission { Id = Guid.NewGuid(), PermissionName = "ViewTherapistModule", Description = "Can view the Therapist module" },
            new Permission { Id = Guid.NewGuid(), PermissionName = "ViewClientModule", Description = "Can view the Client module" }
        };

        foreach (var permission in permissions)
        {
            if (!context.Permissions.Any(p => p.PermissionName == permission.PermissionName))
            {
                context.Permissions.Add(permission);
            }
        }

        context.SaveChanges();

               AssignPermissionsToRoles(roleManager, context);
    }

    private static void AssignPermissionsToRoles(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
    {
        var adminRole = roleManager.FindByNameAsync("Admin").Result;
        var therapistRole = roleManager.FindByNameAsync("Therapist").Result;
        var clientRole = roleManager.FindByNameAsync("Client").Result;

        var permissions = context.Permissions.ToList();

        if (adminRole != null)
        {
            foreach (var permission in permissions)
            {
                if (!context.RolePermissions.Any(rp => rp.RoleId == adminRole.Id && rp.PermissionId == permission.Id))
                {
                    context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = adminRole.Id,
                        PermissionId = permission.Id,
                        Role = adminRole,
                        Permission = permission
                    });
                }
            }
        }

        if (therapistRole != null)
        {
            foreach (var permission in permissions.Where(p => p.PermissionName != "ViewAdminModule"))
            {
                if (!context.RolePermissions.Any(rp => rp.RoleId == therapistRole.Id && rp.PermissionId == permission.Id))
                {
                    context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = therapistRole.Id,
                        PermissionId = permission.Id,
                        Role = therapistRole,
                        Permission = permission
                    });
                }
            }
        }

        if (clientRole != null)
        {
            foreach (var permission in permissions.Where(p => p.PermissionName == "ViewClientModule"))
            {
                if (!context.RolePermissions.Any(rp => rp.RoleId == clientRole.Id && rp.PermissionId == permission.Id))
                {
                    context.RolePermissions.Add(new RolePermission
                    {
                        RoleId = clientRole.Id,
                        PermissionId = permission.Id,
                        Role = clientRole,
                        Permission = permission
                    });
                }
            }
        }

        context.SaveChanges();
    }

}
