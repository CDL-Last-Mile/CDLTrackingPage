using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CDL_TrackingAPI.Models
{
	

	
	public class CdlOrderTracking
    {
        [Key]
        public Int64 Id { get; set; }
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
        public Decimal? Lat { get; set; }
        public Decimal? Long { get; set; }
        ////public string? GeoLocation { get; set; }
        public string? DCity { get; set; }
        public string? DState { get; set; }

        public string? DZip { get; set; }
        public string? DStreet { get; set; }
        //public DateTime? ServerTimestamp { get; set; }
        public DateTime? aTimeStamp { get; set; }
        public string? PODname { get; set; }
        public bool? SuppressOnCompletion { get; set; }
        public bool? isAgent { get; set; }
    }


    public class GPS_Driver
    {
        [Key]
        public int Id { get; set; }
        public Decimal? Lat { get; set; }
        public Decimal? Long { get; set; }
    }
 
}
