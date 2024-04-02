using Domain.Users;
using MapsterMapper;
using OneOf.Types;

namespace Adapter.Users;

public class IdentityAdapter(HttpClient httpClient, IMapper mapper) : IUserAdapter
{
    public Task<OneOf<User, NotFound>> GetUserByEmail(string email)
    {
        httpClient.GetAsync()
    }
}