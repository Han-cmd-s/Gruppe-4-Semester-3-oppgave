using _3_Semester_HV_prosjekt.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("3_semester_HV_prosjektdb")
    ?? throw new InvalidOperationException(
        "the connection to '3_semester_HV_prosjektdb' was not configured. Run web app through Aspire.");

builder.Services.AddDbContext<_3_Semester_HV_prosjektDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IResourceRepository, EfResourceRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<_3_Semester_HV_prosjektDbContext>();
    dbContext.Database.EnsureCreated();
    ResourceDbSeeder.Seed(dbContext);
}
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
