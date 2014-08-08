using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts.Events;

namespace Events.Eventful
{
    public class EventfulSearchResult : ISearchResult
    {
        public List<IEvent> Events { get; set; }
        public int TotalItems { get; set; }
    }
}
