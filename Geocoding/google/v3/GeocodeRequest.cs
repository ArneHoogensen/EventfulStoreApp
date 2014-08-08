using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Geocoding.google.v3
{
    /// <summary>
    /// Basic geocoding by address
    /// </summary>
    public class GeocodeRequest
    {
        /// <summary>
        /// The address that you want to geocode. 
        /// </summary>
        public string Address { get; set; }

        ///// <summary>
        ///// The latitude you want to geocode
        ///// </summary>
        //public double Latitude { get; set; }

        ///// <summary>
        ///// The longitude  you want to geocode
        ///// </summary>
        //public double Longitude { get; set; }

        //not implemented: components or sensor and all other optional parameters

        //http://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=true


        public GeocodeRequest()
        {
            this.BaseUrl = "http://maps.googleapis.com/maps/api/geocode/json?sensor=false&address=";
        }
        public string BaseUrl { get; set; }

        public string ToUrl()
        {
            return string.Format("{0}{1}",this.BaseUrl, this.Address);
        }
      
        public async Task<GeocodeResult> Search()
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage message = await httpClient.GetAsync(this.ToUrl());
                message.EnsureSuccessStatusCode();

                var response = await message.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<GeocodeResult>(response);
            }

        }


    }
}
