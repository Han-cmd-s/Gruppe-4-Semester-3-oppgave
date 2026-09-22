using _3_Semester_HV_prosjekt.Models.Entities;

namespace _3_Semester_HV_prosjekt.DataAccess
{
    public interface IResourceRepository
    {
        Resource? GetById(int id);
    }
}
