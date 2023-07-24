using CDLTracker.Service.Api.Models;

namespace CDLTracker.Service.Api.Repository
{
    public interface ICdlTrackerRepository
    {
        Task<IEnumerable<Result>> Tracking(string orderTrackingID);
    }
}