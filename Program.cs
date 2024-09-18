using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VCQRU.Data;
using VCQRU.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICodeService, CodeService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "productRegistration",
    pattern: "Products/{controller}/{action}/{id?}",
    defaults: new { controller = "Product", action = "Create" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=CodeGeneration}/{action=GenerateCodes}/{id?}");

app.MapControllerRoute(
    name: "generatedCodes",
    pattern: "Admin/{controller=CodeGeneration}/{action=GeneratedCodes}/{batchNo?}",
    defaults: new { controller = "CodeGeneration", action = "GeneratedCodes" });

// Add a route for the subscription page
app.MapControllerRoute(
    name: "subscription",
    pattern: "Services/Subscription",
    defaults: new { controller = "Subscription", action = "Index" } // Ensure SubscriptionController exists
);

app.MapControllerRoute(
    name: "codeVerification",
    pattern: "CodeVerification/{action=Index}/{id?}",
    defaults: new { controller = "CodeVerification", action = "Index" });

app.MapControllerRoute(
    name: "userRegistration",
    pattern: "{controller=UserRegistration}/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
