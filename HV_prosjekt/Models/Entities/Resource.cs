namespace HV_prosjekt.Models.Entities;

/// <summary>
/// Represents a resource that can be located on the map.
/// Prefer init-only properties for immutable model state.
/// </summary>
public class Resource
{
    /// <summary>Primary key</summary>
    public int Id { get; init; }

    /// <summary>Human readable name</summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>Detailed description</summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>Type of resource. Use enum for static analysis.</summary>
    public ResourceType Type { get; init; } = ResourceType.Other;

    /// <summary>Optional street address</summary>
    public string Address { get; init; } = string.Empty;

    /// <summary>Optional city</summary>
    public string City { get; init; } = string.Empty;

    /// <summary>Optional zip code (4 chars)</summary>
    public string ZipCode { get; init; } = string.Empty;

    /// <summary>Optional owner telephone number</summary>
    public string OwnerTelephoneNumber { get; init; } = string.Empty;

    /// <summary>Optional latitude coordinate (nullable)</summary>
    public double? Latitude { get; init; }

    /// <summary>Optional longitude coordinate (nullable)</summary>
    public double? Longitude { get; init; }
}
