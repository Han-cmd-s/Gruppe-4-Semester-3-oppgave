using System.ComponentModel.DataAnnotations;

namespace _3_Semester_HV_prosjekt.Models.ViewModels.Resource
{
    public class ResourceViewModel
    {
        public int? Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;
    }
}