using System.ComponentModel.DataAnnotations;

namespace CDLTracker.Service.Api.Models.old.Dto
{
    public class CdlTrackerOrderGeolocationDto
    {
        [Key]
        public Guid Id { get; set; }
        public decimal OrderTrackingId { get; set; }
        public int? EventId { get; set; }
        public string? Name { get; set; }
        public DateTime? ServerTimestamp { get; set; }
        public double? DiverGeolocationLat { get; set; }
        public double? DiverGeolocationLong { get; set; }
    }
}
