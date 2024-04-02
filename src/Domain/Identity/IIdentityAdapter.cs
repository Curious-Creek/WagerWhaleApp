using Domain.Errors;
using OneOf.Types;
using OneOf;

namespace Domain.Identity;

public interface IIdentityAdapter
{
    public Task<OneOf<Success, DomainError>> RegisterUserAsync(string email, string password);
    public Task<OneOf<IdentityToken, DomainError>> LoginUserAsync(string email, string password);
    public Task LogoutUserAsync();
}