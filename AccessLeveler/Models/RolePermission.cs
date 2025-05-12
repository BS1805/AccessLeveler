namespace AccessLeveler.Models;
public class RolePermission
{
    public Guid RoleId { get; set; }  
    public required ApplicationRole Role { get; set; } 

    public Guid PermissionId { get; set; }  
    public required Permission Permission { get; set; } 
}
