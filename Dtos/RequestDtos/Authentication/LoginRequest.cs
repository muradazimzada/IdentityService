namespace IdentityService.Dtos.RequestDtos.Authentication
{
    public record class LoginRequest
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}
