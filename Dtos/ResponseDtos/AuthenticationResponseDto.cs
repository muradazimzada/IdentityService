namespace IdentityService.Dtos.ResponseDtos
{
    public class AuthenticationResponseDto
    {
        public required string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public int Code { get; set; }
    }

}
