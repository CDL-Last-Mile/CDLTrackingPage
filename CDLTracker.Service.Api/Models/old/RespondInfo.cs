namespace CDLTracker.Service.Api.Models.old
{
    public class RespondInfo
    {
        public IEnumerable<CdlTrackerOrderScans> TrackingUpdate { get; set; }
        public double? PickUpLat { get; set; }
        public double? PickUpLong { get; set; }
        public string? PickUpCity { get; set; }
        public string? PickUpState { get; set; }
        public string? PickUpzip { get; set; }

        public double? DelLat { get; set; }
        public double? DelLong { get; set; }
        public string? DelCity { get; set; }
        public string? DelState { get; set; }
        public string? Delzip { get; set; }
    }
}
