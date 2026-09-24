using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HV_prosjekt.DataAccess
{
    public class HV_prosjektDbContextFactory : IDesignTimeDbContextFactory<HV_prosjektDbContext>
    {
        public HV_prosjektDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_HV_prosjektdb")
                    ?? "server=localhost;Database=HV_prosjekt;user=root;password=;";

            var options = new DbContextOptionsBuilder<HV_prosjektDbContext>()
                .UseMySql(connectionString, ServerVersion.Parse("10.11.0-mariadb"))
                .Options;

            return new HV_prosjektDbContext(options);
        }
    }
}
