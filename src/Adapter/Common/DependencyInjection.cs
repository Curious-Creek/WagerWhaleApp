using Adapter.Competitions;
using Adapter.Users;
using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Competitions;
using Domain.Users;
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
        services.AddHttpClient<IUsersAdapter, UsersAdapter>(client => client.BaseAddress = new Uri(baseUrl));
        return services;
    }
}