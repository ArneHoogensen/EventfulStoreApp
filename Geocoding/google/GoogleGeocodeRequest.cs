using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts.Geocoding;

namespace Geocoding.google
{
    public class GoogleGeocodeRequest : IGeocodeRequest
    {
        public string Address { get; set; }

        public IGeocodeResult Geocode()
        {
            var request = new v3.GeocodeRequest();
            request.Address = this.Address;
            var result = request.Search();

            GoogleGeocodeResult r = new GoogleGeocodeResult();
            if (result.Result.results != null && result.Result.results.Count > 0)
            {
                var firstResult = result.Result.results[0];
                r.FormattedAddress = firstResult.formatted_address;
                r.Latitude = firstResult.geometry.location.lat;
                r.Longitude = firstResult.geometry.location.lng;
            }

            return r;
        }
    }
}
