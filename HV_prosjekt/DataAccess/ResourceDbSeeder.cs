using HV_prosjekt.Models.Entities;

namespace HV_prosjekt.DataAccess
{
    public class ResourceDbSeeder
    {
        public static void Seed(HV_prosjektDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext);

            var seedResources = new[]
            {
                new Resource { Name = "Resource 1", Description = "Description 1", Type = "Type A" },
                new Resource { Name = "Resource 2", Description = "Description 2", Type = "Type B" },
                new Resource { Name = "Resource 3", Description = "Description 3", Type = "Type C" }
            };

            foreach (var seedResource in seedResources)
            {
                var resource = dbContext.Resources.FirstOrDefault(r => r.Id == seedResource.Id);

                if (resource is null)
                {
                    resource = new Resource { Id = seedResource.Id, };
                    dbContext.Resources.Add(resource);
                }

                resource.Name = seedResource.Name;
                resource.Description = seedResource.Description;
                resource.Type = seedResource.Type;
            }

            dbContext.SaveChanges();
        }
    }
}
