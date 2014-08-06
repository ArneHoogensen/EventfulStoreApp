using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts.Geocoding
{
    public interface IGeocodeRequest
    {
        string Address { get; set; }
        IGeocodeResult Geocode();
    }

    public interface IGeocodeResult
    {
        string FormattedAddress { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
