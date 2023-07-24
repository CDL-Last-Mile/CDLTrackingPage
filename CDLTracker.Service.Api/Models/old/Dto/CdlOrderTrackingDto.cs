using System.ComponentModel.DataAnnotations;

namespace CDLTracker.Service.Api.Models.old.Dto
{
    public class CdlOrderTrackingDto
    {
        [Key]
        public Guid Id { get; set; }
        public decimal OrderTrackingId { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime? ShipmentCreated { get; set; }
        public string? TrackingEvents { get; set; }
        public DateTime? DeliveryComplete { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public byte[]? Vpod { get; set; }
        public string? Exception { get; set; }
        public string? ExceptionDetails { get; set; }
        public string? DriverName { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }
        //public string? GeoLocation { get; set; }
        public DateTime? ServerTimestamp { get; set; }
    }
}
