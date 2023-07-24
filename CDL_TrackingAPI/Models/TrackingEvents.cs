namespace CDL_TrackingAPI.Models
{
    public class TrackingEvents
    {

      public Guid? id {get;set;}

            public string? trackingEvent { get;set;}

           public DateTime? trackingEventTimestamp { get;set;}

        public byte[]? vpod { get; set;}
        public string? eventCity { get; set; }
        public string? eventState { get; set; }
        public string? eventZip { get; set; }
    }
}
