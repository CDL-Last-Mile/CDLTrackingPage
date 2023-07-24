using AutoMapper.Internal.Mappers;

namespace CDLTracker.Service.Api.Models
{
    public class Result
    {
        public TrackingEvents TrackingEvents { get; set; }
        public TrackingInformation TrackingInformation { get; set; }
        public mapInfo mapInfo { get; set; }
    }
}
