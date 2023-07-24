using System.ComponentModel.DataAnnotations;

namespace CDLTracker.Service.Api.Models.old
{
    public class CdlTrackerDeliverLocation
    {
        [Key]
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
