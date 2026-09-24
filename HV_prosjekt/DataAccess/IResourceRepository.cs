using HV_prosjekt.Models.Entities;

namespace HV_prosjekt.DataAccess
{
    public interface IResourceRepository
    {
        Resource? GetById(int id);
    }
}
