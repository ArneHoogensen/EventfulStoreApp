using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts.Events
{
    public interface IEvent
    {
        string ImageUrl { get; set; }
        string Title { get; set; }
        string Venue { get; set; }
        string Artist { get; set; }
        DateTime Date { get; set; }
        string DisplayDate { get; }

    }
}
