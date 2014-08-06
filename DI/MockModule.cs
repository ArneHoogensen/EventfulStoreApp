using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;

namespace DI
{
    public class MockModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<Contracts.Events.ISearch>().To<Events.Mock.MockSearch>();
            //Bind<Contracts.Events.IEvent>().To<Events.Mock.MockEvent>();
            //Bind<Contracts.Events.ISearchResult>().To<Events.Mock.MockedSearchResult>();

            //Bind<Contracts.Geocoding.IGeocodeRequest>().To<Geocoding.Mock.MockGeocodeRequest>();
            //Bind<Contracts.Geocoding.IGeocodeResult>().To<Geocoding.Mock.MockGeocodeResult>();

        }
    }
}