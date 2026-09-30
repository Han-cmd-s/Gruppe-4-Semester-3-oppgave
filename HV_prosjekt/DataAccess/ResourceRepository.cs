using HV_prosjekt.Models.Entities;
using HV_prosjekt.Models.ViewModels.Resource;

namespace HV_prosjekt.DataAccess
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly Dictionary<int, Resource> _resources = new();
        private int _nextId = 1;

        public ResourceRepository()
        {
            Create(new ResourceViewModel { Name = "Resource 1", Description = "Description 1", Type = Models.Entities.ResourceType.TypeA });
            Create(new ResourceViewModel { Name = "Resource 2", Description = "Description 2", Type = Models.Entities.ResourceType.TypeB });
        }

        public Resource Create(ResourceViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var resource = new Resource
            {
                Id = _nextId++,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
                Latitude = model.Latitude,
                Longitude = model.Longitude
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
            var existing = _resources[id];
            var updated = new Resource
            {
                Id = existing.Id,
                Name = model.Name,
                Description = model.Description,
                Type = model.Type,
                Address = existing.Address,
                City = existing.City,
                ZipCode = existing.ZipCode,
                OwnerTelephoneNumber = existing.OwnerTelephoneNumber,
                Latitude = model.Latitude ?? existing.Latitude,
                Longitude = model.Longitude ?? existing.Longitude
            };
            _resources[id] = updated;
            return true;
        }

        public bool Delete(int id)
        {
            return _resources.Remove(id);
        }
    }
}
