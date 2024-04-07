using EmployeeManagment.Data;
using EmployeeManagment.Data.UserManagement;
using EmployeeManagment.Repositories;
using EmployeeManagment.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
   .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddTransient<IEmployeeServices, EmployeeService>();

builder.Services.AddScoped<PositionRepository>();
builder.Services.AddTransient<IPositionService, PositionService>();

builder.Services.AddScoped<EmployeePositionRepository>();
builder.Services.AddTransient<IEmployeePositionService, EmployeePositionService>();


var serviceProvider = builder.Services.BuildServiceProvider();
var logger = serviceProvider.GetService<ILogger<ApplicationUser>>();
builder.Services.AddSingleton(typeof(ILogger), logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}"); //routi i cili do te hapet sa ekzekutohet programi
app.MapRazorPages();

app.Run();
