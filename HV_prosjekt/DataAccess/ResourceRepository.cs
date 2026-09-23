using _3_Semester_HV_prosjekt.Models.Entities;
using _3_Semester_HV_prosjekt.Models.ViewModels.Resource;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly Dictionary<int, Resource> _resources = new();
        private int _nextId = 1;

        public ResourceRepository()
        {
            // Initialize with some sample data
            Create(new ResourceViewModel { Name = "Resource 1", Description = "Description 1", Type = "Type A" });
            Create(new ResourceViewModel { Name = "Resource 2", Description = "Description 2", Type = "Type B" });
        }

        public Resource Create(ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var resource = new Resource
            {
                Id = _nextId++,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type
            };
            _resources[resource.Id] = resource;
            return resource;
        }
        
        public Resource? GetById(int id)
        {
            return _resources.GetValueOrDefault(id);
        }

        public IReadOnlyCollection<Resource> GetAll()
        {
            return _resources.Values.ToList().AsReadOnly();
        }
        public bool Update(int id, ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            if (!_resources.ContainsKey(id))
            {
                return false;
            }
            var resource = _resources[id];
            resource.Name = model.Name;
            resource.Description = model.Description;
            resource.Type = model.Type;
            return true;
        }

        public bool Delete(int id)
        {
            return _resources.Remove(id);
        }
    }
}
