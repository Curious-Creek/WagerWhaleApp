using Domain.Errors;
using Domain.Identity;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMapster();

        TypeAdapterConfig<ValidationProblemDetails, DomainError>.NewConfig()
            .MapWith(x => new DomainError(
                "Validation error",
                x.Title,
                x.Status,
                x.Errors.Errors.Select(errorStr => new DomainError(errorStr, null, null, null)).ToList()));
        
        return services;
    }
}