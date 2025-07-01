using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerce;
using ECommerce.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SnackbarService>();
builder.Services.AddSingleton<ProdutoService>();
builder.Services.AddSingleton<CarrinhoService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5287/") });
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
