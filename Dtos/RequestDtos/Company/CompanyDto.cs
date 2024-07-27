namespace IdentityService.Dtos.RequestDtos.Company
{
    public record class CompanyDto: BaseRequestDto
    {
        public Guid? Id { get; set; }
        public required string Name { get; set; }
    }
}
