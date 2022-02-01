using InternationalSpaceStation.Core;
using InternationalSpaceStation.Interfaces;
using InternationalSpaceStation.Models;
using Microsoft.Extensions.Options;

namespace InternationalSpaceStation.Services
{
    public class LocationService : ILocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<Settings> _settings;

        public LocationService(IHttpClientFactory httpClientFactory, IOptions<Settings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _settings = settings;
        }

        public async Task<LocationResponse?> GetCurrentIISLocation() => 
            await _httpClientFactory.CreateClient().GetFromJsonAsync<LocationResponse>(_settings?.Value?.Urls?.CurrentIISLocation);

        public async Task<GeoLocationResponse?> GetReverseGeocode(string? lat, string? lon, string? locale)
        {
            var url = $"{_settings?.Value?.Urls?.Geocode}?latitude={lat}&longitude={lon}&localityLanguage={locale}";
            return await _httpClientFactory.CreateClient().GetFromJsonAsync<GeoLocationResponse>(url);
        }

        public async Task<LocationOnWaterResponse?> GetOnWater(string? lat, string? lon)
        {
            var url = $"{_settings?.Value?.Urls?.OnWater}{lat},{lon}?access_token=1Zf9CgJ6wvhrJsoyxKZZ";
            return await _httpClientFactory.CreateClient().GetFromJsonAsync<LocationOnWaterResponse>(url);
        }
    }
}
