using System.Net.Http.Json;
using Domain.Common;
using Domain.Errors;
using Domain.Events;
using Domain.Identity;
using Mapster;
using MapsterMapper;
using MediatR;
using OneOf.Types;
using OneOf;

namespace Adapter.Identity;

public class IdentityAdapter(HttpClient httpClient, IMapper mapper, IMediator mediator) : IIdentityAdapter
{
    public async Task<OneOf<Success, DomainError>> RegisterUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Register, new { email, password });

        if (!response.IsSuccessStatusCode)
        {
            var validationProblemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>(IdentityJsonSerializerOptions.Options) ?? throw new InvalidOperationException();
            return mapper.Map<DomainError>(validationProblemDetails);
        }
        
        return new Success();
    }

    public async Task<OneOf<IdentityToken, DomainError>> LoginUserAsync(string email, string password)
    {
        var response = await httpClient.PostAsJsonAsync(WhaleApiCatalog.Users.Login, new { email, password, useSessionCookies = true });
        
        if (!response.IsSuccessStatusCode)
        {
            var validationProblemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>(IdentityJsonSerializerOptions.Options) ?? throw new InvalidOperationException();
            return mapper.Map<DomainError>(validationProblemDetails);
        }

        var tokenDto = await response.Content.ReadFromJsonAsync<IdentityTokenDto>() ?? throw new InvalidOperationException();

        mediator.Publish(new UserLoginEvent());
        return tokenDto.Adapt<IdentityToken>();
    }

    public Task LogoutUserAsync()
    {
        throw new NotImplementedException();
    }
}