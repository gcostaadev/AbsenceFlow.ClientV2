using AbsenceFlow.ClientV2;
using AbsenceFlow.ClientV2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7230/")
});

builder.Services.AddScoped<IColaboradorApiService, ColaboradorApiService>();
builder.Services.AddScoped<ISolicitacaoApiService, SolicitacaoApiService>();


await builder.Build().RunAsync();
