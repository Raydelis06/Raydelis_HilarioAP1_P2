using Microsoft.EntityFrameworkCore;
using Raydelis_HilarioAP1_P2.Components;
using Raydelis_HilarioAP1_P2.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//Agrega cadena de conexion
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
//Inyecta el contexto
builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseSqlServer(ConStr));

//Inyecta bootstrap
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
