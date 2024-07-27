using IdentityService.Domain.Enums;

namespace IdentityService.Dtos.RequestDtos.Company
{
    public record class CompanyCreateDto : BaseRequestDto
    {
        public required string Name { get; set; }

        internal RecordStatus RecordStatus { get; set; } = RecordStatus.Active;
    }
}
