namespace IdentityService.Dtos.RequestDtos.Authentication
{
    public class UserAccessInfo
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<GrantedAccess> GrantedAccesses { get; set; }
    }
    public class GrantedAccess
    {
        public Guid AppId { get; set; }
        public IEnumerable<PageAccess> PageAccesses { get; set; }
    }

    public class PageAccess
    {
        public Guid PageId { get; set; }
        public IEnumerable<string> Accesses { get; set; }
    }

}
