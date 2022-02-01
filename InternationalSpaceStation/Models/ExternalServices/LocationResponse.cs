using System.Text.Json.Serialization;

namespace InternationalSpaceStation.Models
{
    public class LocationResponse
    {
        public int? Timestamp { get; set; }
        [JsonPropertyName("iss_position")]
        public Position? Position { get; set; }
        public string? Message { get; set; }
    }

    public class Position
    {
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
