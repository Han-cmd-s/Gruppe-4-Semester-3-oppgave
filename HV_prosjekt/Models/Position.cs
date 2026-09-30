namespace HV_prosjekt.Models;

/// <summary>
/// Represents a geographic position saved from the map.
/// Immutable value type for lightweight transport and in-memory use.
/// </summary>
public readonly record struct Position(int Id, double Latitude, double Longitude, DateTime CreatedAt);
