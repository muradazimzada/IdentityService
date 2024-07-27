using System.ComponentModel;

namespace IdentityService.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        [DefaultValue(false)]
        public bool IsLocked { get; set; }

        [DefaultValue(false)]
        public bool AllowsTokenRefreshEnabled { get; set; }

        public string? RefreshToken { get; set; }

        public virtual ICollection<UserPosition> UserPositions { get; set; } = new List<UserPosition>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public virtual ICollection<UserPageAccess> UserPageAccesses {  get; set; } = new List<UserPageAccess>();
         

    }
}
