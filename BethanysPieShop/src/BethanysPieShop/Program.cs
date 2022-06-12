var builder = WebApplication.CreateBuilder(args);

// getting the service support -- ConfugureServices
var services = builder.Services;
services.AddControllersWithViews();

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
});

app.Run();
