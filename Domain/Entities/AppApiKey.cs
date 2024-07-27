using System.ComponentModel.DataAnnotations;

namespace IdentityService.Domain.Entities
{
    public class AppApiKey : BaseEntity
    {
        public Guid AppId { get; set; }

        public string ApiKey { get; set; } = string.Empty;

        public App App { get; set; }

    }
}
