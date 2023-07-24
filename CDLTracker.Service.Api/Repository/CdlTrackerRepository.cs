using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CDLTracker.Service.Api.DbContexts;
using CDLTracker.Service.Api.Operator;
using CDLTracker.Service.Api.Models;
using System.Collections.Generic;

namespace CDLTracker.Service.Api.Repository
{
    public class CdlTrackerRepository 
    {
        #region Constructor And Member variables
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CdlTrackerRepository(/*ApplicationDbContext db, IMapper mapper*/)
        {
           // _db = db;
            //_mapper = mapper;
        }
        #endregion

        #region Public Partner Methods
        //public async Task<IEnumerable<CdlOrderTrackingDto>> GetCdlOrderTrackingInfo(string orderTrackingID, Boolean isOrderTrackingid)
        //{           
        //    List<SqlParameter> param = new()
        //    {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@orderTrackingId",
        //            SqlDbType = System.Data.SqlDbType.VarChar,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = orderTrackingID
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName="@isOrderTrackingid",
        //            SqlDbType = System.Data.SqlDbType.Bit,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = isOrderTrackingid
        //        },
        //    };

        //    List<CdlOrderTracking> cdltracker = new List<CdlOrderTracking>();


        //    if (_db.CdlTracker != null)
        //    {
        //        try
        //        {

        //            cdltracker = await _db.CdlTracker.FromSqlRaw("EXEC [dbo].[sp_GetOrderTrackingInfo] @orderTrackingId, @isordertrackingid", param.ToArray()).ToListAsync();
        //            return _mapper.Map<List<CdlOrderTrackingDto>>(cdltracker); ;
        //        }
        //        catch (Exception ex )
        //        {
        //        }
        //    }
        //    return null;
        //}

        ////public async Task<IEnumerable<CdlTrackerOrderScansDto>> GetCdlOrderScans(string orderTrackingID, Boolean isOrderTrackingid)
        ////{
        ////    List<SqlParameter> param = new()
        ////    {
        ////        new SqlParameter()
        ////        {
        ////            ParameterName = "@orderTrackingId",
        ////            SqlDbType = System.Data.SqlDbType.VarChar,
        ////            Direction = System.Data.ParameterDirection.Input,
        ////            Value = orderTrackingID
        ////        },
        ////        new SqlParameter()
        ////        {
        ////            ParameterName="@isOrderTrackingid",
        ////            SqlDbType = System.Data.SqlDbType.Bit,
        ////            Direction = System.Data.ParameterDirection.Input,
        ////            Value = isOrderTrackingid
        ////        },
        ////    };

        ////    List<CdlTrackerOrderScans> cdlscans = new List<CdlTrackerOrderScans>();

        ////    if (_db.CdlTrackerOrderScansl != null)
        ////    {
        ////        try
        ////        {
        ////            cdlscans = await _db.CdlTrackerOrderScansl.FromSqlRaw("EXEC [dbo].[sp_GetOrderScans] @orderTrackingId, @isordertrackingid", param.ToArray()).ToListAsync();
        ////            if (cdlscans.Count > 0)
        ////                return _mapper.Map<List<CdlTrackerOrderScansDto>>(cdlscans);
        ////        }
        ////        catch (Exception)
        ////        {
        ////        }
        ////    }
        ////    return null;
        ////}
        ///
       public async Task<IEnumerable<Result>> Tracking(string orderTrackingID)
        {
            List<Result> result = new List<Result>();

            //List<TrackingEvents> trackingEvents = new List<TrackingEvents>();
            //List<mapInfo> mapInfo = new List<mapInfo>();
            //List<TrackingInformation> trackingInformation = new List<TrackingInformation>();
            //List<SqlParameter> sqlOrderBase = new();

           //List<SqlParameter> param = new()
           // {
           //     new SqlParameter()
           //     {
           //         ParameterName = "@orderTrackingId",
           //         SqlDbType = System.Data.SqlDbType.VarChar,
           //         Direction = System.Data.ParameterDirection.Input,
           //         Value = orderTrackingID
           //     }
           // };

           // Geo geo = new Geo();

           // await _db.ordersBases.FromSqlRaw("EXEC [dbo].[sp_GetOrderBase] @orderTrackingId", sqlOrderBase.ToArray()).ToListAsync();



            return result ;
        }
        
        
        //public async Task<IEnumerable<RespondInfo>> GetCdlOrderScans(string orderTrackingID)
        //{
        //    List<SqlParameter> param = new()
        //    {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@orderTrackingId",
        //            SqlDbType = System.Data.SqlDbType.VarChar,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = orderTrackingID
        //        }
        //    };

        //    List<CdlTrackerOrderScans> cdlscans = new List<CdlTrackerOrderScans>();
        //    List<RespondInfo> respondInf= new List<RespondInfo>();
        //    List<OrdersBase> baserespond = new List<OrdersBase>();
            
            


        //    if (_db.CdlTrackerOrderScansl != null)
        //    {
        //        try
        //        {
        //            cdlscans = await _db.CdlTrackerOrderScansl.FromSqlRaw("EXEC [dbo].[sp_GetOrderScans] @orderTrackingId", param.ToArray()).ToListAsync();

        //            List<SqlParameter> sqlOrderBase = new()
        //            {
        //                new SqlParameter()
        //                {
        //                    ParameterName = "@orderTrackingId",
        //                    SqlDbType = System.Data.SqlDbType.VarChar,
        //                    Direction = System.Data.ParameterDirection.Input,
        //                    Value = cdlscans[0].OrderTrackingId
        //                }
        //            };

        //            Geo geo = new Geo();
                    
        //            baserespond = await _db.ordersBases.FromSqlRaw("EXEC [dbo].[sp_GetOrderBase] @orderTrackingId", sqlOrderBase.ToArray()).ToListAsync();
        //            await geo.GeoLocation(baserespond[0].DCity+"+"+baserespond[0].DState+"+"+baserespond[0].DZip);
        //            //Change the grolocation for create the shiping
        //            if (cdlscans.Count > 0) {
        //                cdlscans[0].Long = geo.Longitude;
        //                cdlscans[0].Lat= geo.Latitude;
        //            }
        //            // Change the geolocation for Scan 
        //            if (cdlscans.Count > 1)
        //            {
        //                cdlscans[1].Long = geo.Longitude;
        //                cdlscans[1].Lat = geo.Latitude;
        //            }

        //            respondInf.Add(
        //        new RespondInfo
        //        {
        //            TrackingUpdate = cdlscans,
        //            DelCity = baserespond[0].DCity,
        //            DelState = baserespond[0].DState,
        //            Delzip = baserespond[0].DZip,
        //            DelLat = geo.Latitude,
        //            DelLong = geo.Longitude,
        //            PickUpCity = baserespond[0].PCity,
        //            PickUpState = baserespond[0].PState,
        //            PickUpzip = baserespond[0].PZip,
        //            PickUpLat = geo.Latitude,
        //            PickUpLong = geo.Longitude




        //        }
        //    );

        //            return respondInf;

        //            //if (cdlscans.Count > 0)
        //            //    return _mapper.Map<List<RespondInfo>>(cdlscans);
        //        }
        //        catch (Exception ex)
        //        {
                    
        //        }
        //    }
        //    return null;

            
        //}


        //public async Task<IEnumerable<CdlTrackerOrderGeolocationDto>> GetCdlGeolocation(string orderTrackingID, Boolean isOrderTrackingid)
        //{
        //    List<SqlParameter> param = new()
        //    {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@orderTrackingId",
        //            SqlDbType = System.Data.SqlDbType.VarChar,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = orderTrackingID
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName="@isOrderTrackingid",
        //            SqlDbType = System.Data.SqlDbType.Bit,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = isOrderTrackingid
        //        },
        //    };

        //    List<CdlTrackerOrderGeolocation> cdlgeolocation = new List<CdlTrackerOrderGeolocation>();

        //    if (_db.CdlTrackerOrderGeolocations != null)
        //    {
        //        try
        //        {
        //            cdlgeolocation = await _db.CdlTrackerOrderGeolocations.FromSqlRaw("EXEC [dbo].[sp_GetOrderGeolocation] @orderTrackingId, @isordertrackingid", param.ToArray()).ToListAsync();
        //            if (cdlgeolocation.Count>0)
        //                return _mapper.Map<List<CdlTrackerOrderGeolocationDto>>(cdlgeolocation); ;
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //    return null;
        //}

        //public async Task<IEnumerable<CdlTrackerDeliverLocationDto>> GetCdlDriverlocation(string orderTrackingID, Boolean isOrderTrackingid)
        //{
        //    List<SqlParameter> param = new()
        //    {
        //        new SqlParameter()
        //        {
        //            ParameterName = "@orderTrackingId",
        //            SqlDbType = System.Data.SqlDbType.VarChar,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = orderTrackingID
        //        },
        //        new SqlParameter()
        //        {
        //            ParameterName="@isOrderTrackingid",
        //            SqlDbType = System.Data.SqlDbType.Bit,
        //            Direction = System.Data.ParameterDirection.Input,
        //            Value = isOrderTrackingid
        //        },
        //    };

        //    List<CdlTrackerDeliverLocation> cdldriverlocation = new List<CdlTrackerDeliverLocation>();

        //    if (_db.CdlTrackerDeliverLocations != null)
        //    {
        //        try
        //        {
        //            cdldriverlocation = await _db.CdlTrackerDeliverLocations.FromSqlRaw("EXEC [dbo].[sp_GetOrderDeliverdLocation] @orderTrackingId, @isordertrackingid", param.ToArray()).ToListAsync();
        //            if (cdldriverlocation.Count>0)
        //                return _mapper.Map<List<CdlTrackerDeliverLocationDto>>(cdldriverlocation); ;
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //    return null;
        //}

        #endregion
    }
}
