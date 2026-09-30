using HV_prosjekt.DataAccess;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("HV_prosjektdb")
    ?? throw new InvalidOperationException(
        "the connection to 'HV_prosjektdb' was not configured. Run web app through Aspire.");

builder.Services.AddDbContext<HV_prosjektDbContext>(options =>
    options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 11, 0))));
builder.Services.AddScoped<IResourceRepository, EfResourceRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<HV_prosjektDbContext>();
        dbContext.Database.EnsureCreated();
        ResourceDbSeeder.Seed(dbContext);
    }
    catch (MySqlException ex)
    {
        throw new InvalidOperationException(
            "Could not connect to MySQL/MariaDB. Verify that the database server is running and that the Development connection string has the correct host, port, user, and password.",
            ex);
    }
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHttpsRedirection();
    app.UseHsts();

}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
