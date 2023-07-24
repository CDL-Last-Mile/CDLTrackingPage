namespace CDLTracker.Service.Api.Models
{
    public class TrackingInformation
    {
        public int Ordertrackingid { get; set; }
        public string referenceNumber { get; set; }
        public string driverName { get; set; }
        public string latestUpdate{get;set;}
        public string destinationCity { get; set; }
        public string destinationState { get; set; }
        public string destinationZip { get; set; }
        public double deliveryLocationLong { get; set; }
        public double deliveryLocationLat { get; set; }
    }
}
