using HV_prosjekt.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("hvprosjektdb")
    ?? throw new InvalidOperationException(
        "the connection to 'HVprosjektdb' was not configured. Run web app through Aspire.");

builder.Services.AddDbContext<HV_prosjektDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IResourceRepository, EfResourceRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HV_prosjektDbContext>();
    dbContext.Database.EnsureCreated();
    ResourceDbSeeder.Seed(dbContext);
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
