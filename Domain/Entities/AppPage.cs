namespace IdentityService.Domain.Entities
{
    public class AppPage: BaseEntity
    {
        public required string Name { get; set; }   
        public string? Description { get; set; }

        public required Guid AppId { get; set; }

        public virtual App App { get; set; }
        public virtual ICollection<UserPageAccess> UserPageAccesses { get; set; } = new List<UserPageAccess>();
    }
}
