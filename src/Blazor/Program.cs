using Adapter.Common;
using Application.Common;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Blazor.Common;
using Domain.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services
    .AddBlazor()
    .AddAdapters(builder.Configuration)
    .AddDomain()
    .AddApplication();

await builder.Build().RunAsync();
