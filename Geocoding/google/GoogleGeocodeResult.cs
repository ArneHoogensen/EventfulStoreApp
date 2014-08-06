using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts.Geocoding;


namespace Geocoding.google
{
    public class GoogleGeocodeResult : IGeocodeResult
    {
        public string FormattedAddress { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
