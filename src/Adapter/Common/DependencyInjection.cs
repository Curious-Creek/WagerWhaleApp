using Adapter.Competitions;
using Ardalis.GuardClauses;
using Domain.Competitions;
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
        
        services.AddHttpClient<ICompetitionsAdapter, CompetitionsAdapter>(client => client.BaseAddress = new Uri(baseUrl));
        return services;
    }
}