namespace AccessLeveler.Models;
public class Permission
{
    public Guid Id { get; set; } 
    public required string PermissionName { get; set; }
    public required string Description { get; set; }
}
