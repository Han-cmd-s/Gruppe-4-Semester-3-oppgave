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
                new Resource { Name = "Resource 1", Description = "Description 1", Type = ResourceType.TypeA },
                new Resource { Name = "Resource 2", Description = "Description 2", Type = ResourceType.TypeB },
                new Resource { Name = "Resource 3", Description = "Description 3", Type = ResourceType.TypeC }
            };

            foreach (var seedResource in seedResources)
            {
                var resource = dbContext.Resources.FirstOrDefault(r => r.Id == seedResource.Id);

                if (resource is null)
                {
                    // create with same values
                    dbContext.Resources.Add(seedResource);
                }
                else
                {
                    // update values on existing resource
                    dbContext.Entry(resource).CurrentValues.SetValues(new
                    {
                        seedResource.Name,
                        seedResource.Description,
                        seedResource.Type,
                        seedResource.Address,
                        seedResource.City,
                        seedResource.ZipCode,
                        seedResource.OwnerTelephoneNumber,
                        seedResource.Latitude,
                        seedResource.Longitude
                    });
                }
            }

            dbContext.SaveChanges();
        }
    }
}
