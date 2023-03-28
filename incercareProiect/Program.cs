using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using MvcMovie.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcOmnivoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcOmnivoreContext") ?? throw new InvalidOperationException("Connection string 'MvcOmnivoreContext' not found.")));
builder.Services.AddDbContext<MvcVegetarianContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcVegetarianContext") ?? throw new InvalidOperationException("Connection string 'MvcVegetarianContext' not found.")));
builder.Services.AddDbContext<MvcPescatarianContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcPescatarianContext") ?? throw new InvalidOperationException("Connection string 'MvcPescatarianContext' not found.")));
builder.Services.AddDbContext<MvcVeganContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcVeganContext") ?? throw new InvalidOperationException("Connection string 'MvcVeganContext' not found.")));
builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();