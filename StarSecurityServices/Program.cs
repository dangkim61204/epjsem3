using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure database context
builder.Services.AddDbContext<ConnectDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connect")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // For development environment
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Serve static files

app.UseRouting();

app.UseAuthentication(); // Ensure this is before UseAuthorization
app.UseAuthorization();

// Cấu hình định tuyến cho Areas
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
