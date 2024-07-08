using BlazorEcommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using MudBlazor.Services;
using BlazorEcommerce.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorEcommerce.Client.Authorization;
using BlazorEcommerce.Client.Services.LocationService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<EcommerceAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<EcommerceAuthenticationStateProvider>());
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILocationService, LocationService>();


await builder.Build().RunAsync();
