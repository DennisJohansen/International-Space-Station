namespace InternationalSpaceStation.Models
{
    public class LocationOnWaterResponse
    {
        public string? Query { get; set; }
        public string? Request_id { get; set; }
        public float? Lat { get; set; }
        public float? Lon { get; set; }
        public bool? Water { get; set; }
    }
}