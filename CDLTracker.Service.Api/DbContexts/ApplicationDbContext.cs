using CDLTracker.Service.Api.Models;
using CDLTracker.Service.Api.Models.old;
using Microsoft.EntityFrameworkCore;

namespace CDLTracker.Service.Api.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        #region Constructor And Member Variables
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CdlOrderTracking>? CdlTracker { get; set; }
        public DbSet<CdlTrackerOrderScans>? CdlTrackerOrderScansl { get; set; }
        public DbSet<CdlTrackerOrderGeolocation>? CdlTrackerOrderGeolocations { get; set; }
        public DbSet<CdlTrackerDeliverLocation>? CdlTrackerDeliverLocations { get; set; }
        public DbSet<OrdersBase>? ordersBases { get; set; }
        #endregion
    }
}
