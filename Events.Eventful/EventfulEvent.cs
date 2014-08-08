using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Eventful
{
    public class EventfulEvent : Contracts.Events.IEvent
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string DisplayDate
        {
            get
            {
                if (Date == null) return "";
                return Date.ToString("MM/dd/yy, dddd");
            }
        }
    }
}