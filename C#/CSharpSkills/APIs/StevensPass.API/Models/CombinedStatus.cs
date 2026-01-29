namespace StevensPass.API.Models
{
    public class CombinedStatus
    {
        public RoadStatus Road { get; set; } = new();
        public MountainPassStatus Mountain { get; set; } = new();
        public DateTime GeneratedAt { get; set; }
    }
}