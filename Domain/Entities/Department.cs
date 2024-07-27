namespace IdentityService.Domain.Entities
{
    public class Department : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

        public virtual ICollection<UserPosition> UserPositions { get; set; } = new List<UserPosition>();
    }
}
