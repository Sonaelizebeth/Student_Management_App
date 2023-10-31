global using StudentManagementApp.DataShared; //makes the namespace accessible throughout the script.
global using StudentManagementApp.Client.Services.StudentService;
global using StudentManagementApp.Client.Pages;
global using StudentManagementApp.DataShared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting; //setting up blazor wasm app.
using StudentManagementApp.Client;
using System.Runtime.CompilerServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

/*registers the IStudentService interface and associates it with StudentService implementation enabling
DependencyAttribute injection*/
builder.Services.AddScoped<IStudentService, StudentService>();

/*registers the IDepartmentService interface and associates it with DepartmentService implementation enabling
DependencyAttribute injection*/
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

await builder.Build().RunAsync();
