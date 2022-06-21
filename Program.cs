using OnlineShop.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));


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

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "home/index",
        defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllerRoute(
        name: "Editcategory",
        pattern: "danh-muc/chinh-sua/{id?}",
        defaults: new { controller = "Category", action = "EditCategory" });
    endpoints.MapControllerRoute(
        name: "listcategory",
        pattern: "danh-muc",
        defaults: new { controller = "Category", action = "Index" });
    endpoints.MapControllerRoute(
        name: "Addcategory",
        pattern: "danh-muc/them-moi",
        defaults: new { controller = "Category", action = "AddNewCategory" });

});

app.Run();
