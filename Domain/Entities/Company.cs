using Microsoft.AspNetCore.Connections;

namespace IdentityService.Domain.Entities
{
    public class Company : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

        public virtual ICollection<UserPosition> UserPositions { get; set; } = new List<UserPosition>();
    }
}
