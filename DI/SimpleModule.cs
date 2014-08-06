using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace DI
{
    public class SimpleModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<Contracts.Events.ISearch>().To<Events.Eventful.EventfulSearch>();
            //Bind<Contracts.Events.IEvent>().To<Events.Eventful.EventfulEvent>();
            //Bind<Contracts.Events.ISearchResult>().To<Events.Eventful.EventfulSearchResult>();

            Bind<Contracts.Geocoding.IGeocodeRequest>().To<Geocoding.google.GoogleGeocodeRequest>();
            Bind<Contracts.Geocoding.IGeocodeResult>().To<Geocoding.google.GoogleGeocodeResult>();

        }
    }
}