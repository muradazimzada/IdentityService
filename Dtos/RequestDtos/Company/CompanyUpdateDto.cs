namespace IdentityService.Dtos.RequestDtos.Company
{
    public record class CompanyUpdateDto : BaseRequestDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
