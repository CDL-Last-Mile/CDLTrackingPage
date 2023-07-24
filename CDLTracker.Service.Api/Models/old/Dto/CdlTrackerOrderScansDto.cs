using System.ComponentModel.DataAnnotations;

namespace CDLTracker.Service.Api.Models.old.Dto
{
    public class CdlTrackerOrderScansDto
    {
        [Key]
        public Guid Id { get; set; }
        public decimal OrderTrackingId { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? ShipmentCreated { get; set; }
        public string? TrackingEvents { get; set; }
        public DateTime? TarckingEventsTimestamp { get; set; }
        public DateTime? DeliveryComplete { get; set; }
        public byte[]? Vpod { get; set; }
        public string? Exception { get; set; }
        public string? ExceptionDetails { get; set; }
        public DateTime? ExceptionTimestamp { get; set; }
        public string? DriverName { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
    }
}
