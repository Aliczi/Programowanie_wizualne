using _145213.kdramasApp;
using _145213.kdramasApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DataMock>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();



// from terminal where .csproj is located run -> dotnet run seeddata
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataMock>();
        service.InitDataContext();
    }
}






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
