using CDL_TrackingAPI.Models;

namespace CDL_TrackingAPI
{
    public interface ICdlTrackerRepository
    {
        Task<TrackingResults> Tracking(string orderTrackingID);
        Task<Boolean> Notification(NotificationModel notification);
        Task<Boolean> DeliveryInstruction(DriverInstruction DriverInstruction);
    }
}