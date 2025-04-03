using BookApp.Components;
using BookApp.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient("BookApi", (sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<ApiSettings>>().Value;

    if (string.IsNullOrWhiteSpace(settings.BaseUrl))
    {
        throw new Exception("⚠️ L'URL de l'API est manquante dans la configuration !");
    }

    client.BaseAddress = new Uri(settings.BaseUrl);
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BookApi"));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
