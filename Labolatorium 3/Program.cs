using Labolatorium_3.Models;
using Labolatorium_3.Services;
using Laboratorium_3___App_ns.Models;
using EFData;
using Laboratorium_3___App_ns.Services;
using System;
// Usuniêto niewykorzystane przestrzenie nazw i poprawiono formatowanie

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);



// Poni¿ej konfiguracja DbContext u¿ywaj¹c po³¹czenia z appsettings.json oraz wskazuj¹c projekt migracji
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    

// Rejestracja serwisów
builder.Services.AddScoped<IContactService, MemoryContactService>();
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
builder.Services.AddControllersWithViews(); // Dodaje kontrolery i widoki do kontenera us³ug

var app = builder.Build();

// Konfiguracja pipeline'a ¿¹dañ HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // W³¹cza œcis³¹ politykê bezpieczeñstwa transportu
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
