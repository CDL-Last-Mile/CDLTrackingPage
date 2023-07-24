using CDLTracker.Service.Api.Models.old;
using System.Net.Http;
using System.Net.Http.Headers;


namespace CDLTracker.Service.Api.Operator

{
    public class Geo
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        IHttpClientFactory httpClientFactory;
        public Result returndata;
        public async Task GeoLocation(string Address)
        {
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address="+@Address+"&key=AIzaSyBLhyZEZM2mjHQvkdW2xWdniqbe5LxhC3A";
            
            using HttpResponseMessage respons = await API.APIClient.GetAsync(url);
            if (respons != null)
            {
    Rootobject con = await respons.Content.ReadAsAsync<Rootobject>();

                Latitude = con.results[0].geometry.location.lat;
                Longitude = con.results[0].geometry.location.lng;
            }
           





            
        }
    }
}
