using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SingleWebApplicationDefaultAuth;
using SingleWebApplicationDefaultAuth.Code.Authentication;
using SingleWebApplicationDefaultAuth.Code.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore().AddScoped<AuthenticationStateProvider, AzureSwaAuthenticationStateProvider>();

builder.Services.AddTransient<UserDabRoleHeader>();
builder.Services.AddHttpClients(builder.Configuration);

await builder.Build().RunAsync();
