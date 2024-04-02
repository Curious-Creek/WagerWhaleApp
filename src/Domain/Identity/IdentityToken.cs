using Domain.Common;

namespace Domain.Identity;

public class IdentityToken(string AccessToken, string RefreshToken, DateTimeOffset ExpiresAt) : BaseEntity;