using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts.Events;
using Events.Eventful.v1;

namespace Events.Eventful
{
    public class EventfulSearch : ISearch
    {
        public string SecurityToken { get; set; }
        public Dictionary<string, object> SearchParameters { get; set; }
        public ISearchResult Search()
        {
            var request = new Eventful.v1.SearchRequest()
            {
                ApplicationKey = SecurityToken
            };
            Type type = typeof(SearchRequest);
            

            if (SearchParameters != null)
            {
                foreach (var key in SearchParameters.Keys)
                {
                    var value = SearchParameters[key];
                    if (value != null)
                    {
                        var p = type.GetProperty(key);
                        if (p != null)
                        {
                            p.SetValue(request, value, null);
                        }
                    }
                }
            }

            var results = request.Search();
            EventfulSearchResult r = new EventfulSearchResult();
            var total = 0;
            if (int.TryParse(results.Result.total_items, out total))
            {
                r.TotalItems = total;
            }
            r.Events = new List<IEvent>();
            if (results.Result.events != null)
            {
                foreach (var e in results.Result.events.@event)
                {
                    string p = "Unknown";
                    if (e.performers != null && e.performers.Name != null) p = e.performers.Name;
                    string img = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/77/Guitar_Silhouette.png/462px-Guitar_Silhouette.png";
                    if (e.image != null)
                    {
                        if (e.image.thumb != null && e.image.thumb.url !=null)
                        {
                            img = e.image.thumb.url;
                        }
                        else if (e.image.small != null && e.image.small.url != null)
                        {
                            img = e.image.small.url;
                        }
                        else if (e.image.medium != null && e.image.medium.url != null)
                        {
                            img = e.image.medium.url;
                        }
                    }
                    System.DateTime dt = DateTime.MinValue;
                    System.DateTime.TryParse(e.start_time, out dt);
                    r.Events.Add(new EventfulEvent() { 
                        Artist = p,
                        Date = dt,
                        ImageUrl = img,
                        Title = e.title,
                        Venue = e.venue_name,
                    });
                }
            }

            return r;
        }
        
    }
}
