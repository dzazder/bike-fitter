using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BikeFitter.Web.Data;
using BikeFitter.Web.Services;
using BikeFitter.Web.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<RequestService>();
builder.Services.AddSingleton<Routes>();
builder.Services.AddSingleton<BrakeService>();
builder.Services.AddSingleton<CassetteService>();
builder.Services.AddSingleton<CranksetService>();
builder.Services.AddSingleton<ForkService>();
builder.Services.AddSingleton<DerailleurService>();
builder.Services.AddSingleton<ManufacturerService>();
builder.Services.AddSingleton<RimService>();
builder.Services.AddSingleton<ShifterService>();
builder.Services.AddSingleton<StemService>();
builder.Services.AddSingleton<TireService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
