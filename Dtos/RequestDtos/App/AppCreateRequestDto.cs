namespace IdentityService.Dtos.RequestDtos.App
{
    public record class AppCreateRequestDto: BaseRequestDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
