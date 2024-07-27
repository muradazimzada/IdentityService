namespace IdentityService.Dtos.RequestDtos.User
{
    public record class UserCreateRequest: BaseRequestDto
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string UserName { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
        public bool IsLocked { get; init; } = false;
        public bool AllowsTokenRefreshEnabled { get; init; } = false;
        public string? RefreshToken { get; init; }
        public List<Guid> UserPositionIds { get; init; } = [];
        public List<Guid> UserRoleIds { get; init; } = [];
        public List<Guid> UserPageAccessIds { get; init; } = [];
    }
}
