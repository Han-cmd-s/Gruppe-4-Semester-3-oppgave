using _3_Semester_HV_prosjekt.Models.Entities;
using _3_Semester_HV_prosjekt.Models.ViewModels.Resource;
using Microsoft.EntityFrameworkCore;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    public class EfResourceRepository(_3_Semester_HV_prosjektDbContext dbContext) : IResourceRepository
    {
        public Resource Create(ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var resource = new Resource
            {
                Name = model.Name,
                Description = model.Description,
                Type = model.Type
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

            resource.Name = model.Name;
            resource.Description = model.Description;
            resource.Type = model.Type;
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
