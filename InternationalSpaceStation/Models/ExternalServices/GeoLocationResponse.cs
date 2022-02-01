namespace InternationalSpaceStation.Models
{
    public class GeoLocationResponse
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string? Continent { get; set; }
        public string? LookupSource { get; set; }
        public string? ContinentCode { get; set; }
        public string? LocalityLanguageRequested { get; set; }
        public string? City { get; set; }
        public string? CountryName { get; set; }
        public string? Postcode { get; set; }
        public string? CountryCode { get; set; }
        public string? PrincipalSubdivision { get; set; }
        public string? PrincipalSubdivisionCode { get; set; }
        public string? PlusCode { get; set; }
        public string? Locality { get; set; }
        public LocalityInfo? LocalityInfo { get; set; }
    }

    public class LocalityInfo
    {
        public Administrative[]? Administrative { get; set; }
        public Informative[]? Informative { get; set; }
    }

    public class LocalityInfoBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Order { get; set; }
        public string? IsoCode { get; set; }
        public string? WikidataId { get; set; }
        public int? GeonameId { get; set; }
    }

    public class Administrative : LocalityInfoBase
    {
        public string? IsoName { get; set; }        
        public int? AdminLevel { get; set; }
    }

    public class Informative : LocalityInfoBase
    {        
    }
}
