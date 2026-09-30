using HV_prosjekt.Models.Entities;
using HV_prosjekt.Models.ViewModels.Resource;
using Microsoft.EntityFrameworkCore;

namespace HV_prosjekt.DataAccess
{
    public class EfResourceRepository(HV_prosjektDbContext dbContext) : IResourceRepository
    {
        public Resource Create(ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var resource = new Resource
            {
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            dbContext.Resources.Add(resource);
            dbContext.SaveChanges();

            return resource;
        }
        public Resource? GetById(int id)
        {
            return dbContext.Resources.Find(id);
        }
        public IReadOnlyCollection<Resource> GetAll()
        {
            return dbContext.Resources
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }
        public bool Update(int id, ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var resource = dbContext.Resources.Find(id);
            if (resource is null)
            {
                return false;
            }

            // map allowed updatable fields
            var updated = new Resource
            {
                Id = resource.Id,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
                Address = resource.Address,
                City = resource.City,
                ZipCode = resource.ZipCode,
                OwnerTelephoneNumber = resource.OwnerTelephoneNumber,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };

            // EF: update entity
            dbContext.Entry(resource).CurrentValues.SetValues(updated);
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var resource = dbContext.Resources.Find(id);
            if (resource is null)
            {
                return false;
            }
            dbContext.Resources.Remove(resource);
            dbContext.SaveChanges();
            return true;
        }
    }
}
