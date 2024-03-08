using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutorial_ASP_NET_MVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Tutorial_ASP_NET_MVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tutorial_ASP_NET_MVCContext") ?? throw new InvalidOperationException("Connection string 'Tutorial_ASP_NET_MVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
