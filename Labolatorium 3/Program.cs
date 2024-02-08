using Labolatorium_3.Models;
using Labolatorium_3.Services;
using Laboratorium_3___App_ns.Models;
using Laboratorium_3___App_ns.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Rejestracja serwisu IContactService z jego implementacj¹ MemoryContactService
builder.Services.AddScoped<IContactService, MemoryContactService>();

// Rejestracja serwisu IDateTimeProvider z jego implementacj¹ CurrentDateTimeProvider
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

