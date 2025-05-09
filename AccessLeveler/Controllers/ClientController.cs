using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AccessLeveler.Controllers;


[Authorize(Roles = "Client")]
[AccessLeveler.Authorization.PermissionAuthorize("ViewClientModule")]
public class ClientController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}

