using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts.Events
{
    public interface ISearchResult
    {
        List<IEvent> Events { get; set; }
        int TotalItems { get; set; }
    }
}
