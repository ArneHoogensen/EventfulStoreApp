using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Eventful.v1
{
    public class Event
    {
        public object watching_count { get; set; }
        public object calendar_count { get; set; }
        public object comment_count { get; set; }
        public string region_abbr { get; set; }
        public string postal_code { get; set; }
        public object going_count { get; set; }
        public string all_day { get; set; }
        public string latitude { get; set; }
        public object groups { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string privacy { get; set; }
        public string city_name { get; set; }
        public object link_count { get; set; }
        public string longitude { get; set; }
        public string country_name { get; set; }
        public string country_abbr { get; set; }
        public string region_name { get; set; }
        public string start_time { get; set; }
        public object tz_id { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
        public string venue_display { get; set; }
        public object tz_country { get; set; }
        public Performers performers { get; set; }
        public string title { get; set; }
        public string venue_address { get; set; }
        public string geocode_type { get; set; }
        public object tz_olson_path { get; set; }
        public string recur_string { get; set; }
        public object calendars { get; set; }
        public string owner { get; set; }
        public object going { get; set; }
        public string country_abbr2 { get; set; }
        public Image image { get; set; }
        public string created { get; set; }
        public string venue_id { get; set; }
        public object tz_city { get; set; }
        public string stop_time { get; set; }
        public string venue_name { get; set; }
        public string venue_url { get; set; }
    }
}
