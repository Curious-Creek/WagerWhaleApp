using System.Reflection;
using Blazor.ViewModels.ErrorViewModel;
using Domain.Errors;
using Mapster;

namespace Blazor.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddBlazor(this IServiceCollection services)
    {
        services.AddBlazorBootstrap();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        TypeAdapterConfig<DomainError, DomainErrorViewModel>.NewConfig()
            .MapWith(x => new DomainErrorViewModel(x.Message, x.Title, x.Status,
                x.Errors != null ? x.Errors.Select(y => new DomainErrorViewModel(y)).ToList() : null));
        
        TypeAdapterConfig<DomainErrorViewModel, DomainError>.NewConfig()
            .MapWith(x => new DomainError(x.Message, x.Title, x.Status,
                x.Errors.Select(y => new DomainError(y.Message, y.Title, y.Status, null)).ToList()));

        return services;
    }
}