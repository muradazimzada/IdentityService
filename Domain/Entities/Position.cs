namespace IdentityService.Domain.Entities
{
    public class Position : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UserPosition> UserPositions { get; set; } = new List<UserPosition>();
    }
}
