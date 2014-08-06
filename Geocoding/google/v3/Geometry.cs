using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geocoding.google.v3
{
    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }
}
