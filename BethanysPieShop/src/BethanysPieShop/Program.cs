using BethanysPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// getting the service support -- ConfugureServices
var services = builder.Services;
services.AddControllersWithViews();
services.AddScoped<IPieRepository, MockPieRepository>();
services.AddScoped<ICategoryRepository, MockCategoryRepository>();

// added the configure pipeline
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//setting the route config
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoint.MapControllerRoute(
        name: "pie",
        pattern: "{controller=Pie}/{action=List}"
    );
});

app.Run();
