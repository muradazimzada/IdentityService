namespace IdentityService.Domain.Entities
{
    public class Role: BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
