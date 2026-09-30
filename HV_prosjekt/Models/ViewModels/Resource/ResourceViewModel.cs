using System.ComponentModel.DataAnnotations;
using HV_prosjekt.Models.Entities;

namespace HV_prosjekt.Models.ViewModels.Resource
{
    /// <summary>
    /// View model used for creating/updating resources from the UI.
    /// Use init-only properties to avoid accidental mutation.
    /// </summary>
    public class ResourceViewModel
    {
        public int? Id { get; init; }

        [MaxLength(200)]
        public string Name { get; init; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; init; } = string.Empty;

        public ResourceType Type { get; init; } = ResourceType.Other;

        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
    }
}
