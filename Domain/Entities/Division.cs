namespace IdentityService.Domain.Entities
{
    public class Division : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<UserPosition> UserPositions { get; set; } = new List<UserPosition>();
    }
}
