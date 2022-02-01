namespace InternationalSpaceStation.Core
{
    public class Settings
    {
        public Urls? Urls { get; set; }
    }

    public class Urls
    {
        public string? CurrentIISLocation { get; set; }
        public string? Geocode { get; set; }
        public string? OnWater { get; set; }        
    }
}
