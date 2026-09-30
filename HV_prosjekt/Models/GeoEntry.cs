namespace HV_prosjekt.Models;

/// <summary>
/// In-memory GeoJSON entry.
/// </summary>
public readonly record struct GeoEntry(int Id, string Title, string GeoJson, DateTime CreatedAt);
