using CDL_TrackingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CDL_TrackingAPI.DbContexts
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options): base(options) { }  


        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=172.24.32.132;database=XceleratorTest;User ID=CDL_Tracking;Password=nyc!123xyz;max pool size=200;Integrated Security=True;");
        //    }
        //    base.OnConfiguring(optionsBuilder);

        //}

        public DbSet<CdlOrderTracking> CdlOrderTrackings { get; set; }
        public DbSet<GPS_Driver> GPS_Drivers { get; set; }
        public DbSet<sqlrespond> sqlresponds { get; set; }

  
	}
}
