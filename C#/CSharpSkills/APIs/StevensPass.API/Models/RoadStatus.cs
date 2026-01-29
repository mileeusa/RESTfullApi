namespace StevensPass.API.Models
{
    public class RoadStatus
    {
        public string PassName { get; set; } = "";
        public string Status { get; set; } = "";
        public string Conditions { get; set; } = "";
        public DateTime LastUpdated { get; set; }
    }
}
