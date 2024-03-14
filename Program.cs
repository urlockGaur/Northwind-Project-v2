using Microsoft.EntityFrameworkCore;

// Connection info stored in appsettings.json
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Register the DataContext service
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration["Data:Product:ConnectionString"]));
var app = builder.Build();

app.UseHttpsRedirection(); // redirect to secure encryption https
app.UseStaticFiles(); //allowing static files into the program
app.UseRouting(); //used to process the request

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
