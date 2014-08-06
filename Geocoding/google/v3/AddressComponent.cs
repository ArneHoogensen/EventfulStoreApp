using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geocoding.google.v3
{

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }
}
