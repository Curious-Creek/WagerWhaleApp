namespace Adapter.Identity;

public sealed record IdentityTokenDto(string AccessToken, string RefreshToken, int ExpiresIn);