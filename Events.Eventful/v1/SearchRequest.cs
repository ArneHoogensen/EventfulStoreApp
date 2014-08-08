using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;      

namespace Events.Eventful.v1
{
    public class SearchRequest
    {
        /// <summary>
        /// Application key provided by EventFul
        /// </summary>
        public string ApplicationKey { get; set; }


        /// <summary>
        /// The search keywords. (optional)
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// A location name to use in filtering the search results. Locations in the form "San Diego", "San Diego, TX", "London, United Kingdom", and "Calgary, Alberta, Canada" are accepted, as are postal codes ("92122") and venue IDs ("V0-001-000268633-5"). Common geocoordinate formats ("32.746682, -117.162741") are also accepted, but the "within" parameter is required in order to set a search radius. (optional)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Limit this list of results to a date range, specified by label or exact range. Currently supported labels include: "All", "Future", "Past", "Today", "Last Week", "This Week", "Next week", and months by name, e.g. "October". Exact ranges can be specified the form 'YYYYMMDD00-YYYYMMDD00', for example '2012042500-2012042700'; the last two digits of each date in this format are ignored. (optional)
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Limit the search results to this category ID. A list of categories may be specified separated by commas. See /categories/list for a list of categories and their IDs. (optional)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// If within is set and the "location" parameter resolves to a specific geolocation, the search will be restricted to the specified radius. If the "location" parameter does not resolve to a specific location, this parameter is ignored. (optional)
        /// </summary>
        public int? Within { get; set; }

        /// <summary>
        /// One of "mi" or "km", the units of the "within" parameter. Defaults to "mi".(optional)
        /// </summary>
        public string Units { get; set; }

        /// <summary>
        /// If count_only is set, an abbreviated version of the output will be returned. Only total_items and search_time elements are included in the result. (optional)
        /// </summary>
        public bool? CountOnly { get; set; }

        /// <summary>
        /// One of 'popularity', 'date', or 'relevance'. Default is 'relevance'. (optional)
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// One of 'ascending' or 'descending'. Default varies by sort_order. (optional)
        /// </summary>
        public string SortDirection { get; set; }

        /// <summary>
        /// The desired number of results per page. (optional)
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The desired page number. (optional)
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Sets the level of filtering for events marked as "mature" due to keywords in the title or description. One of 'all' (no filtering), 'normal', or 'safe'. 'Normal' mature filtering consists of words that are clearly profanities and inappropriate for younger audiences. 'Safe' mature filtering consists of all normal mature filtered words, as well as other terms that may be used as inappropriate innuendo. A 'safe' filter may eliminate events that are benign in nature, but contain questionable content based on keywords. Defaults to 'all'. (optional)
        /// </summary>
        public string Mature { get; set; }

        /// <summary>
        /// Indicates that optional sections should be included in the result XML. Multiple section names can be indicated, separated by commas (e.g. 'categories,links'). Sections include 'categories', 'price', and 'links'. (optional)
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// Base URL of EventFul Search Engine.  Default: http://api.eventful.com/json/events/search?
        /// </summary>
        public string BaseUrl { get; set; }

        public SearchRequest()
        {
            this.BaseUrl = "http://api.eventful.com/json/events/search?";
        }

        public string ToUrl()
        {
            StringBuilder url = new StringBuilder();
            url.Append(BaseUrl);
            url.Append(string.Format("app_key={0}&", ApplicationKey));
            if (!string.IsNullOrEmpty(Keywords)) url.Append(string.Format("keywords={0}&", Keywords));
            if (!string.IsNullOrEmpty(Location)) url.Append(string.Format("location={0}&", Location));
            if (!string.IsNullOrEmpty(Date)) url.Append(string.Format("date={0}&", Date));
            if (!string.IsNullOrEmpty(Category)) url.Append(string.Format("category={0}&", Category));
            if (Within != null && Within.HasValue) url.Append(string.Format("within={0}&", Within));
            if (!string.IsNullOrEmpty(Units)) url.Append(string.Format("units={0}&", Units));
            if (CountOnly != null && CountOnly.HasValue) url.Append(string.Format("count_only={0}&", CountOnly));
            if (!string.IsNullOrEmpty(SortOrder)) url.Append(string.Format("sort_order={0}&", SortOrder));
            if (!string.IsNullOrEmpty(SortDirection)) url.Append(string.Format("sort_direction={0}&", SortDirection));
            if (PageSize != null && PageSize.HasValue) url.Append(string.Format("page_size={0}&", PageSize));
            if (PageNumber != null && PageNumber.HasValue) url.Append(string.Format("page_number={0}&", PageNumber));
            if (!string.IsNullOrEmpty(Mature)) url.Append(string.Format("mature={0}&", Mature));
            if (!string.IsNullOrEmpty(Include)) url.Append(string.Format("include={0}&", Include));


            return url.ToString();

        }

        public async Task<SearchResults> Search()
        {
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage message = await httpClient.GetAsync(this.ToUrl());
                    message.EnsureSuccessStatusCode();

                    var response = await message.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SearchResults>(response);
                }
                //using (var webClient = new System.Net.WebClient())
                //{
                //    var json = webClient.DownloadString(this.ToUrl());
                //    using (var reader = new StringReader(json))
                //    {

                //        var ser = new Newtonsoft.Json.JsonSerializer();
                //        return (ser.Deserialize((reader as TextReader), typeof(SearchResults)) as SearchResults);
                //    }
                //}
            }
            catch (Exception)
            {
                return null;
            }

        }


    }
}