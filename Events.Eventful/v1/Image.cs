using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Eventful.v1
{
    public class Image
    {
        public Small small { get; set; }
        public string width { get; set; }
        public object caption { get; set; }
        public Medium medium { get; set; }
        public string url { get; set; }
        public Thumb thumb { get; set; }
        public string height { get; set; }
    }
}
