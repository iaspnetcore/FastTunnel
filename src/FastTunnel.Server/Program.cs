using Microsoft.Extensions.Hosting.WindowsServices;


var webApplicationOptions = new WebApplicationOptions()

{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args,
    ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName
};


var builder = WebApplication.CreateBuilder(webApplicationOptions);

//come from:https://stackoverflow.com/questions/70571849/host-asp-net-6-in-a-windows-service
builder.Host.UseWindowsService();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



