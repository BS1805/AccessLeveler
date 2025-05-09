using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
namespace AccessLeveler.Controllers;


[Authorize(Roles = "Admin")]
[AccessLeveler.Authorization.PermissionAuthorize("ViewAdminModule")]
public class AdminController : Controller
{
    
    public IActionResult Index()
    {
        
        return View();
    }
}