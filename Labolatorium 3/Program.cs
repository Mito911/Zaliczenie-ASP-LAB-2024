using Labolatorium_3.Models;
using Labolatorium_3.Services;
using Laboratorium_3___App_ns.Models;
using EFData;
using Laboratorium_3___App_ns.Services;
using System;
// Usuni�to niewykorzystane przestrzenie nazw i poprawiono formatowanie

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);



// Poni�ej konfiguracja DbContext u�ywaj�c po��czenia z appsettings.json oraz wskazuj�c projekt migracji
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    

// Rejestracja serwis�w
builder.Services.AddScoped<IContactService, MemoryContactService>();
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
builder.Services.AddControllersWithViews(); // Dodaje kontrolery i widoki do kontenera us�ug

var app = builder.Build();

// Konfiguracja pipeline'a ��da� HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // W��cza �cis�� polityk� bezpiecze�stwa transportu
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
