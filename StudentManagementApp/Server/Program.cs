global using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Server.Context;
using Microsoft.AspNetCore.ResponseCompression;

//creates web application builder, used to configure and build web application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//registers services for controllers and views.
builder.Services.AddControllersWithViews();

//registers services for razor pages
builder.Services.AddRazorPages();

//configures db context for EF Core
builder.Services.AddDbContext<ApplicationDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builds web application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
