using Microsoft.AspNetCore.Identity;
using System;
namespace AccessLeveler.Models.Application_Models;
public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole(string roleName) : base(roleName) { }
}
