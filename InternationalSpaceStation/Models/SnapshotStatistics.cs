using CsvHelper.Configuration.Attributes;

namespace InternationalSpaceStation.Models
{
    public class SnapshotStatistics
    {
        [Name("timestamp")]
        public long? Timestamp { get; set; }
        [Name("lat")]
        public float? Lat { get; set; }
        [Name("lon")]
        public float? Lon { get; set; }
        [Name("continent")]
        public string? Continent { get; set; }
        [Name("country")]
        public string? Country { get; set; }
        [Name("onWater")]
        public bool? OnWater { get; set; }
    }    
}
