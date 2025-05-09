using AccessLeveler.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessLeveler.Controllers;

[Authorize(Roles = "Therapist")]
[AccessLeveler.Authorization.PermissionAuthorize("ViewTherapistModule")]
public class TherapistController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
