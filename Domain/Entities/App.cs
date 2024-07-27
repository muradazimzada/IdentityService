namespace IdentityService.Domain.Entities
{
    public class App : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<AppPage> AppPages { get; set; } = new List<AppPage>();
        public virtual AppApiKey AppApiKey { get; set; }

    }
}
