namespace InternationalSpaceStation.Models
{
    public class CurrentLocationResponse
    {
        public GeoLocationResponse? GeoLocation { get; set; }
        public bool? OnWater { get; set; }
        public object? Statistics { get; set; }
    }
}
