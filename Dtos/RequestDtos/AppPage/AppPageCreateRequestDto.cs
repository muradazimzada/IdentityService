namespace IdentityService.Dtos.RequestDtos.AppPage
{
    public record class AppPageCreateRequestDto: BaseRequestDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid AppId { get; set; }
    }
}
