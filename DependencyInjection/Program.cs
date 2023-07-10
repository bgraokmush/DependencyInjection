using DependencyInjection.Agent;
using DependencyInjection.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// DI - Dependency Injection
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddSingleton<IShopRepository, ShopRepository>();
builder.Services.AddTransient<PerformanceCounter>();

builder.Services.AddTransient<DataCollectorService>();


var app = builder.Build();

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
