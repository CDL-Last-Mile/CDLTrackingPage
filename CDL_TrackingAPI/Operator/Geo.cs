using CDL_TrackingAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CDL_TrackingAPI.Operator

{
    public class Geo
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        IHttpClientFactory httpClientFactory;
        public Result returndata;
        public async Task<bool> GeoLocation(string Address)
        {
            IConfiguration _Configuration = (IConfiguration)new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                               .AddEnvironmentVariables()
                               .Build();

            string APiKey = _Configuration.GetSection("APP:API_Google").Value;
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address="+@Address+"&key="+APiKey;
            
            using HttpResponseMessage respons = await API.APIClient.GetAsync(url);
            if (respons != null)
            {
                Rootobject con = await respons.Content.ReadAsAsync<Rootobject>();

                Latitude = con.results[0].geometry.location.lat;
                Longitude = con.results[0].geometry.location.lng;
                return true;
            }

            return false;

        }
        public async Task<bool> GeoAddress(Decimal? Lat, Decimal? Long)
        {
            IConfiguration _Configuration = (IConfiguration)new ConfigurationBuilder()
                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                               .AddEnvironmentVariables()
                               .Build();

            string APiKey = _Configuration.GetSection("APP:API_Google").Value;
            string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + Lat+","+Long + "&key=" + APiKey;

            using HttpResponseMessage respons = await API.APIClient.GetAsync(url);
            if (respons != null)
            {
                Rootobject con = await respons.Content.ReadAsAsync<Rootobject>();

                string[] address = con.results[0].formatted_address.Split(",");

                State = address[2].Split(" ")[1];
                City = address[1];
                ZipCode= address[2].Split(" ")[2];
                return true;
            }

            return false;





        }
    }
}
