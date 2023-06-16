using AuthenAndAuthor.Filters;
using AuthenAndAuthor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDbContext<DataBaseContext>(opt => 
opt.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(options =>
                  {
                      options.LoginPath = "/Login";
                      options.AccessDeniedPath = "/AcessDenied";
                  });
var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
