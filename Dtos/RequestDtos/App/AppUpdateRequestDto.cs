namespace IdentityService.Dtos.RequestDtos.App
{
    public record class AppUpdateRequestDto: BaseRequestDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
