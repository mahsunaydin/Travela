using Microsoft.AspNetCore.Mvc.Authorization;
using Travela.DataAccessLayer.Context;
using Travela.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TravelaContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TravelaContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Login/Index";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
