using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TUI.Places.Source;

namespace TUI.TimeZone.Source.Api.Google
{
    public class GoogleTimeZoneApi: ITimeZoneApi
    {
        private RestClient _client;
        private RestRequest _request;

        public GoogleTimeZoneApi()
        {
            this._client = new RestClient("https://maps.googleapis.com");
        }

        private static double ToTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        private GoogleTimeZone GetTimeZone(Location loc, DateTime utcDate)
        {
            this._request = new RestRequest("maps/api/timezone/json", Method.GET);
            this._request.AddParameter("location", loc.Latitude + "," + loc.Longitude);
            this._request.AddParameter("timestamp", ToTimestamp(utcDate));
            this._request.AddParameter("sensor", "false");
            var response = this._client.Execute<GoogleTimeZone>(this._request);
            return response.Data;
        }

        public Boolean GetLocalTime(Location departure, DateTime utcDate, ref DateTime localTime)
        {
            Thread.Sleep(1000); //add a sleep otherwise google thinks we are spamming
            var data = GetTimeZone(departure, utcDate);
            if (data == null)
            {
                return false;
            }

            localTime = GetLocalDateTime(data, utcDate);
            return true;
        }

        private static DateTime GetLocalDateTime(GoogleTimeZone timezone, DateTime utcDate)
        {
            return utcDate.AddSeconds(timezone.RawOffset + timezone.DstOffset);
        }
    }
}
