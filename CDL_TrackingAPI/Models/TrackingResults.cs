
namespace CDL_TrackingAPI.Models
{
    public class TrackingResults
    {
        public List<TrackingEvents> TrackingEvents { get; set; }
        public TrackingInformation TrackingInformation { get; set; }
        public mapInfo mapInfo { get; set; }
    }
}
