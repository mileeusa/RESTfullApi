namespace StevensPass.API.Models
{
    public class MountainPassStatus
    {
        public string MountainPassName { get; set; } = "";
        public bool IsEastboundOpen { get; set; }
        public bool IsWestboundOpen { get; set; }
        public int ElevationInFeet { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int TemperatureInFarenheit { get; set; }
        public string WeatherCondition { get; set; } = "";
        public string Summary { get; set; } = "";
        public DateTime LastUpdated { get; set; }
    }
}
