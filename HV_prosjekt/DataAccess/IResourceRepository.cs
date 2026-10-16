using HV_prosjekt.Models.Entities;
using HV_prosjekt.Models.ViewModels.Resource;

namespace HV_prosjekt.DataAccess
{
    public interface IResourceRepository
    {
        Resource Create(ResourceViewModel model);
        bool Delete(int id);
        IReadOnlyCollection<Resource> GetAll();
        Resource? GetById(int id);
        bool Update(int id, ResourceViewModel model);
    }
}