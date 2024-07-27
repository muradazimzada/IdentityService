
namespace IdentityService.Domain.Entities
{
    public class UserPageAccess: BaseEntity
    {
        public required Guid AppPageId { get; set; }
        public required Guid UserId { get; set; }

        public bool IsAdmin
        {
            get
            {
                return ViewAccess && EditAccess && DeleteAccess && CreateAccess;
            }
            set
            {
                if (value)
                {
                    ViewAccess = true;
                    EditAccess = true;
                    DeleteAccess = true;
                    CreateAccess = true;
                }
                else
                {
                    ViewAccess = false;
                    EditAccess = false;
                    DeleteAccess = false;
                    CreateAccess = false;
                }
            }
        }

        public bool ViewAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool CreateAccess { get; set; }

        public virtual AppPage AppPage { get; set; }
        public virtual User User { get; set; }
    }
}
