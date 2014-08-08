using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Eventful.v1
{
    public class SearchResults
    {
        public object last_item { get; set; }
        public string total_items { get; set; }
        public object first_item { get; set; }
        public string page_number { get; set; }
        public string page_size { get; set; }
        public object page_items { get; set; }
        public string search_time { get; set; }
        public string page_count { get; set; }
        public Events events { get; set; }
    }
}
