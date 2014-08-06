using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Event.Tests
{
    [TestFixture]
    public class GeocodeTest
    {
        [Test]
        public void GeocodeColligoOffice_FullAddress()
        {
            Geocoding.google.GoogleGeocodeRequest request = new Geocoding.google.GoogleGeocodeRequest()
            {
                Address = "400-1152 Mainland St. Vancouver, BC V6B 4X2 Canada"
            };
            var results = request.Geocode();

            Assert.IsNotNull(results);
            Assert.IsNotNull(results.FormattedAddress);
            Assert.IsNotNull(results.Latitude);
            Assert.IsNotNull(results.Longitude);

        }

        [Test]
        public void GeocodeColligoOffice_PostalCode()
        {
            Geocoding.google.GoogleGeocodeRequest request = new Geocoding.google.GoogleGeocodeRequest()
            {
                Address = "V6B 4X2"
            };
            var results = request.Geocode();

            Assert.IsNotNull(results);
            Assert.IsNotNull(results.FormattedAddress);
            Assert.IsNotNull(results.Latitude);
            Assert.IsNotNull(results.Longitude);

        }



        //[Test]
        //public void DIGeocodeOffice_Full()
        //{
        //    var search = DI.Container.Current.Get<Contracts.Geocoding.IGeocodeRequest>();
        //    search.Address = "400-1152 Mainland St. Vancouver, BC V6B 4X2 Canada";

        //    var results = search.Geocode();
        //    Assert.IsNotNull(results);
        //    Assert.IsNotNull(results.FormattedAddress);
        //    Assert.IsNotNull(results.Latitude);
        //    Assert.IsNotNull(results.Longitude);

        //}
    }
}
