using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TanzEksp.Client;
using TanzEksp.Client.Auth;
using TanzEksp.Client.DI;
using TanzEksp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddClientServices(); // Register IOC service her

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CustomerService>(); // Den vil ikke køre medmindre jeg tilføjer customerService. Underligt når vi har AddClientServices. 
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


await builder.Build().RunAsync();
