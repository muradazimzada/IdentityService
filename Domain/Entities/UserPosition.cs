namespace IdentityService.Domain.Entities
{
    public class UserPosition : BaseEntity
    {
        public required Guid UserId { get; set; }
        public virtual User User { get; set; }

        public required Guid PositionId { get; set; }
        public virtual Position Position { get; set; }

        public required Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public Guid? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public Guid? DivisionId { get; set; }
        public virtual Division? Division { get; set; }
    }
}

