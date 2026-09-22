using _3_Semester_HV_prosjekt.Models.Entities;
using _3_Semester_HV_prosjekt.Models.ViewModels.Resource;
using Microsoft.EntityFrameworkCore;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    public class EfResourceRepository(_3_Semester_HV_prosjektDbContext dbcontext) : IResourceRepository
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

            dbcontext.Resources.Add(resource);
            dbcontext.SaveChanges();

            return resource;
        }
        public Resource? GetById(int id)
        {
            return dbContext.Resources.Find(id);
        }
        public IReadOnlyCollection<Resource> GetAll()
        {
            return dbContext.Resources.
                .AsNoTracking()
                .ToList()
                .asReadOnly();
        }
        public bool Update(int id, ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var reosurce = dbcontext.Resources.Find(id);
            if (resources is null)
            {
                return false;
            }

            resource.Name = model.Name;
            resource.Description = model.Description;
            resource.Type = model.Type;
            dbcontext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var resource = dbcontext.Resources.Find(id);
            if (resource is null)
            {
                return false;
            }
            dbcontext.Resources.Remove(resource);
            dbcontext.SaveChanges();
            return true;
        }
    }
}
