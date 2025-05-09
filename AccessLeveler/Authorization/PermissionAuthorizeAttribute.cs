using Microsoft.AspNetCore.Authorization;
namespace AccessLeveler.Authorization;


public class PermissionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement
{
    public string Permission { get; }

    public PermissionAuthorizeAttribute(string permission)
    {
        Permission = permission;
    }
}
