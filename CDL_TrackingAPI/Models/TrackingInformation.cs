namespace CDL_TrackingAPI.Models
{
    public class TrackingInformation
    {
        public decimal Ordertrackingid { get; set; }
        public string referenceNumber { get; set; }
        public string driverName { get; set; }
        public string latestUpdate{get;set;}
        public string destinationCity { get; set; }
        public string destinationState { get; set; }
        public string destinationZip { get; set; }
        public double deliveryLocationLong { get; set; }
        public double deliveryLocationLat { get; set; }
        public string Exception { get; set; }
        public string ExceptionDetails { get; set; }
        public string PODName { get; set; }
        public bool? SuppressOnCompletion { get; set; }
        public bool? isAgent { get; set;}
        public DateTime? deliveryDate { get; set; }
    }
}
