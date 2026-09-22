using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    // <summary>
    /// Factory class for creating instances of the _3_Semester_HV_prosjektDbContext at design time.
    /// </summary>
    public class _3_Semester_HV_prosjektDbContextFactory : IDesignTimeDbContextFactory<_3_Semester_HV_prosjektDbContext>
    {
        public _3_Semester_HV_prosjektDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__3_semester_HV_prosjektdb")
                    ?? "server=localhost;Database=3_semester_HV_prosjekt;user=root;password=;";

            var options = new DbContextOptionsBuilder<_3_Semester_HV_prosjektDbContext>()
                .UseMySql(connectionString, ServerVersion.Parse("10.11.0-mariadb"))
                .Options;

            return new _3_Semester_HV_prosjektDbContext(options);
        }
    }
}
