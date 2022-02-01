using InternationalSpaceStation.Models;

namespace InternationalSpaceStation.Interfaces
{
    public interface ILocationService
    {
        Task<LocationResponse?> GetCurrentIISLocation();
        Task<GeoLocationResponse?> GetReverseGeocode(string? lat, string? lon, string? locale = "da");
        Task<LocationOnWaterResponse?> GetOnWater(string? lat, string? lon);
    }
}
