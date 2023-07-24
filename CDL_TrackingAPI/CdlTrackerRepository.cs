using CDL_TrackingAPI.DbContexts;
using CDL_TrackingAPI.Models;
using CDL_TrackingAPI.Operator;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Runtime.Intrinsics.Arm;

namespace CDL_TrackingAPI
{
    public class CdlTrackerRepository : ICdlTrackerRepository
    {
        DBConnection db;
        public CdlTrackerRepository(DBConnection _dB)
        {
       db= _dB;
        }



        public async Task<TrackingResults> Tracking(string orderTrackingID)
        {
            TrackingResults result = new TrackingResults();
            TrackingInformation trackingInformation = new TrackingInformation();
            mapInfo mapInfo = new mapInfo();
            List<TrackingEvents> trackingEvents = new List<TrackingEvents>();
            SqlDataReader rdr;
            List<SqlParameter> param = new()
            {
                new SqlParameter()
                {
                    ParameterName = "@orderTrackingId",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = orderTrackingID
                },
            };

            List<CdlOrderTracking> cdltracker = new List<CdlOrderTracking>();
            List<GPS_Driver> Driver = new List<GPS_Driver>();

            if (db.CdlOrderTrackings != null)
            {
                try
                {

                    cdltracker = await db.CdlOrderTrackings.FromSqlRaw("EXEC [dbo].[sp_GetOrderTrackingInfo] @orderTrackingId", param.ToArray()).ToListAsync();
                    Driver = await db.GPS_Drivers.FromSqlRaw("EXEC [dbo].[sp_GetOrderTrackingInfoDriver] @orderTrackingId", param.ToArray()).ToListAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }






            if (cdltracker.Count > 0)
            {


                trackingInformation.Ordertrackingid = cdltracker[cdltracker.Count() - 1].OrderTrackingId;
                trackingInformation.referenceNumber = cdltracker[0].ReferenceNumber;
                trackingInformation.destinationCity = cdltracker[cdltracker.Count() - 1].DCity;
                trackingInformation.destinationZip = cdltracker[cdltracker.Count() - 1].DZip;
                trackingInformation.destinationState = cdltracker[cdltracker.Count() - 1].DState;
                trackingInformation.driverName = cdltracker[0].DriverName;
                trackingInformation.latestUpdate = cdltracker[0].TrackingEvents;
                trackingInformation.PODName = cdltracker[0].PODname;
                trackingInformation.SuppressOnCompletion = cdltracker[0].SuppressOnCompletion;
                trackingInformation.isAgent = cdltracker[cdltracker.Count() - 1].isAgent;
                trackingInformation.deliveryDate = cdltracker[0].DeliveryComplete;
                if ((cdltracker[cdltracker.Count() - 1].DCity != null) & (cdltracker[cdltracker.Count() - 1].DState != null))
                {
                    Geo geo = new Geo();
                    var GeoReturn = await geo.GeoLocation(cdltracker[cdltracker.Count() - 1].DCity + " " + cdltracker[cdltracker.Count() - 1].DStreet + " " + cdltracker[cdltracker.Count() - 1].DState + " " + cdltracker[cdltracker.Count() - 1].DZip);

                    trackingInformation.deliveryLocationLat = geo.Latitude;
                    trackingInformation.deliveryLocationLong = geo.Longitude;
                }
                trackingInformation.Exception = cdltracker[0].Exception;
                trackingInformation.ExceptionDetails = cdltracker[0].ExceptionDetails;

                foreach (var cd in cdltracker)
                {
                    

                    if (cd.TrackingEvents == "Driver en-route to delivery")
                    {
                        Geo chec = new Geo();
                        if (Driver.Count > 0)
                        {
                            mapInfo.DriverLat = Driver[0].Lat;
                            mapInfo.DriverLon = Driver[0].Long;

                            if ((cd.Lat != null) & (cd.Long != null))
                            {
                                var a = await chec.GeoAddress(cd.Lat, cd.Long);
                            }
                        }
                        else
                        {
                            mapInfo.DriverLat = cd.Lat;
                            mapInfo.DriverLon = cd.Long;
                        }
                        if (chec.City is not null)
                        {
                            trackingEvents.Add(new TrackingEvents
                            {
                                trackingEvent = cd.TrackingEvents,
                                trackingEventTimestamp = cd.aTimeStamp,
                                vpod = cd.Vpod,
                                eventCity = chec.City,
                                eventState = chec.State,
                                eventZip = chec.ZipCode


                            });

                        }
                        else
                        {
                            trackingEvents.Add(new TrackingEvents
                            {
                                trackingEvent = cd.TrackingEvents,
                                trackingEventTimestamp = cd.aTimeStamp,
                                vpod = cd.Vpod,
                                eventCity = cd.City,
                                eventState = cd.State,
                                eventZip = null


                            });
                        }


                    }
                    else

                    {
                        trackingEvents.Add(new TrackingEvents
                        {
                            trackingEvent = cd.TrackingEvents,
                            trackingEventTimestamp = cd.aTimeStamp,
                            vpod = cd.Vpod,
                            eventCity = cd.City,
                            eventState = cd.State,
                            eventZip = cd.DZip


                        });
                    }

                    //foreach (var dgp in Driver)
                    //{
                    //    mapInfo.DriverLat = dgp.Lat;
                    //    mapInfo.DriverLon = dgp.Long;
                    //}
                    //foreach (var dgp in Driver)
                    //{
                    //    mapInfo.DriverLat = dgp.Lat;
                    //    mapInfo.DriverLon = dgp.Long;
                    //}

                }
                result.mapInfo = mapInfo;
                result.TrackingInformation = trackingInformation;
                result.TrackingEvents = trackingEvents;
            }
            else { }
            return result;
        }

        public async Task<Boolean> Notification(NotificationModel notification)
        {

            List<SqlParameter> param = new()
            {

                new SqlParameter()
                { 
                    ParameterName = "@orderTrackingId",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = notification.orderTrackingId
                },
                 new SqlParameter()
                {
                    ParameterName = "@email",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = notification.email
                },
                  new SqlParameter()
                 {
                    ParameterName = "@phone",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = notification.phone
                }
                  ,
                  new SqlParameter()
                 {
                    ParameterName = "@onPod",
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = notification.onPod
                }
                  ,
                  new SqlParameter()
                 {
                    ParameterName = "@nextStopDelivery",
                    SqlDbType = System.Data.SqlDbType.TinyInt,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = notification.nextStopDelivery
                }

            };

Boolean statusreturn =false;
            List<sqlrespond>sqlrespond ;
            
                try
                {
                
                   sqlrespond= await db.sqlresponds.FromSqlRaw("EXEC [dbo].[sp_OrderTrackingNotificationSignup] @orderTrackingId, @email, @phone,@onPod,@nextStopDelivery", param.ToArray()).ToListAsync();

                
                    statusreturn = sqlrespond[0].id;
                
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());
                }
            return statusreturn;


        }

        public async Task<Boolean> DeliveryInstruction(DriverInstruction DriverInstruction)
        {

            List<SqlParameter> param = new()
            {

                new SqlParameter()
                {
                    ParameterName = "@orderTrackingId",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = DriverInstruction.orderTrackingId
                },
                 new SqlParameter()
                {
                    ParameterName = "@instruction",
                    SqlDbType = System.Data.SqlDbType.Char,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = DriverInstruction.Instruction
                }

            };

            Boolean statusreturn = false;
            List<sqlrespond> sqlrespond;

            try
            {

                sqlrespond = await db.sqlresponds.FromSqlRaw("EXEC [dbo].[sp_GetdeliveryInstruction] @orderTrackingId, @instruction", param.ToArray()).ToListAsync();


                statusreturn = sqlrespond[0].id;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            return statusreturn;


        }


    }
}
