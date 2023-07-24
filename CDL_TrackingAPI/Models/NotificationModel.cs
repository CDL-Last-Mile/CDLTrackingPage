namespace CDL_TrackingAPI.Models
{
    public class NotificationModel
    {
        public string orderTrackingId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int onPod { get; set; }
        public int nextStopDelivery { get; set; }
    }
}
