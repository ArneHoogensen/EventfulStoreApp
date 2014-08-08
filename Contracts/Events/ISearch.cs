using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts.Events
{
    public interface ISearch
    {

        string SecurityToken { get; set; }
        Dictionary<string, object> SearchParameters { get; set; }

        ISearchResult Search();
    }
}
