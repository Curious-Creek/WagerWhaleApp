using Adapter.Competitions;
using Adapter.Identity;
using Ardalis.GuardClauses;
using Domain.Competitions;
using Domain.Identity;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddAdapters(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["ApiBaseUrl"]; 
        
        Guard.Against.NullOrEmpty(baseUrl, message: "ApiBaseUrl not found in configuration");

        Console.WriteLine($"ApiBaseUrl: {baseUrl}");

        //services.AddHttpClient<IWhaleApiAdapter>(client => client.BaseAddress = new Uri(baseUrl));
        
        services.AddHttpClient<ICompetitionsAdapter, CompetitionsAdapter>(client => client.BaseAddress = new Uri(baseUrl));
        services.AddHttpClient<IIdentityAdapter, IdentityAdapter>(client => client.BaseAddress = new Uri(baseUrl));

        AddMapsterConfig();
        
        return services;
    }

    private static void AddMapsterConfig()
    {
        TypeAdapterConfig<IdentityTokenDto, IdentityToken>.NewConfig()
            .MapWith(x => new IdentityToken(x.AccessToken, x.RefreshToken, DateTimeOffset.UtcNow.AddMilliseconds(x.ExpiresIn)));
    }
}