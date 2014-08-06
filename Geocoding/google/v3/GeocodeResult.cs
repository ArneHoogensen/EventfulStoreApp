using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geocoding.google.v3
{
    public class GeocodeResult
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}
