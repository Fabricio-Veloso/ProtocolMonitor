using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorPwa;
using Blazored.LocalStorage;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registro do WebSocketService
builder.Services.AddScoped<WebSocketService>();
builder.Services.AddBlazoredLocalStorage();


// Registro do HttpClient (como já estava)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();


await builder.Build().RunAsync();
