using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
// Events.SearchTool.Commands;

namespace EventfulStoreApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            AddressValidationLabel = "A valid address is required";
            AddressValidationLabelVisible = true;
            RadiusValidationLabel = "Radius must be between 1 and 300";
            RadiusValidationLabelVisible = false;
            StartDate = DateTime.Now;
            StartDateValidationLabel = "A valid start date must be specified";
            StartDateValidationLabelVisible = false;
            EndDate = DateTime.Now.AddDays(1);
            EndDateValidationLabel = "A valid end date must be specified";
            EndDateValidationLabelVisible = false;
            Radius = 1;
            Category = "Music";
            SearchButtonEnabled = false;
            AddressInputEnabled = true;
            SearchingForEvents = false;
            GeoCoding = false;

            this._dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;

            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(SearchViewModel_PropertyChanged);

        }

        private void Validate()
        {
            SearchButtonEnabled = IsFormValid;
        }
        private bool IsAddressValid
        {
            get
            {
                if (string.IsNullOrEmpty(Address)) return false;
                return (GeocodeResults != null && !string.IsNullOrEmpty(GeocodeResults.FormattedAddress));
            }
        }
        private bool IsRadiusValid
        {
            get
            {
                return (Radius > 0 && Radius <= 300);
            }
        }
        private bool IsStartDateValid
        {
            get
            {
                if (StartDate.Date > EndDate.Date) return false;
                if (StartDate.Date < System.DateTime.Now.Date) return false;
                return true;
            }
        }
        private bool IsEndDateValid
        {
            get
            {
                if ((EndDate.Date - StartDate.Date).Days > 28) return false;
                if (StartDate.Date > EndDate) return false;
                if (EndDate.Date < System.DateTime.Now.Date) return false;
                return true;
            }
        }
        private bool IsFormValid
        {
            get
            {
                return IsAddressValid && IsRadiusValid && IsStartDateValid && IsEndDateValid;
            }
        }

        
        private void GeocodeAddress()
        {
            GeoCoding = true;
            Task.Factory.StartNew<Contracts.Geocoding.IGeocodeResult>(() =>
               {
                   AddressInputEnabled = false;
                   var request = DI.Container.Current.Get<Contracts.Geocoding.IGeocodeRequest>();
                   request.Address = Address;
                   return request.Geocode();
               }).ContinueWith((continuation) =>
               {
                   GeocodeResults = continuation.Result;
                   AddressInputEnabled = true;
                   GeoCoding = false;
               });
        }

        private String Geocodeddress = string.Empty;

        void SearchViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string changed = e.PropertyName;
            switch (changed)
            {
                case "GeocodeResults":
                    if (IsAddressValid)
                    {
                        Address = GeocodeResults.FormattedAddress.Replace(", ", ",\n");
                        Geocodeddress = Address;
                        AddressValidationLabelVisible = false;;
                    }
                    else
                    {
                        Address = "";
                        AddressValidationLabelVisible = true;
                    }
                    break;
                case "Address":
                    if (string.IsNullOrEmpty(Address))
                    {
                        AddressValidationLabelVisible = true;
                    }
                    else
                    {
                        if (Geocodeddress != Address) GeocodeAddress();
                    }
                    break;
                case "Radius":
                    RadiusValidationLabelVisible = !IsRadiusValid;
                    break;
                case "StartDate":
                case "EndDate":
                    StartDateValidationLabelVisible = !IsStartDateValid;
                    EndDateValidationLabelVisible = !IsEndDateValid;
                    break;
                case "Category":
                default:
                    break;
            }
            if (!changed.Contains("Enabled") && !changed.Contains("Visbile")) Validate();

        }

        string _address;
        public string Address { get { return _address; } set { _address = value; base.OnPropertyChangedAsync("Address"); } }

        string _addressValidationLabel;
        public string AddressValidationLabel { get { return _addressValidationLabel; } set { _addressValidationLabel = value; base.OnPropertyChangedAsync("AddressValidationLabel"); } }
        bool _addressValidationLabelVisible { get; set; }
        public bool AddressValidationLabelVisible { get { return _addressValidationLabelVisible; } set { _addressValidationLabelVisible = value; base.OnPropertyChangedAsync("AddressValidationLabelVisible"); } }

        bool _addressInputEnabled;
        public bool AddressInputEnabled { get { return _addressInputEnabled; } set { _addressInputEnabled = value; base.OnPropertyChangedAsync("AddressInputEnabled"); } }



        double _radius;
        public double Radius { get { return _radius; } set { _radius = value; base.OnPropertyChangedAsync("Radius"); } }

        string _radiusValidationLabel;
        public string RadiusValidationLabel { get { return _radiusValidationLabel; } set { _radiusValidationLabel = value; base.OnPropertyChangedAsync("RadiusValidationLabel"); } }
        bool _radiusValidationLabelVisible { get; set; }
        public bool RadiusValidationLabelVisible { get { return _radiusValidationLabelVisible; } set { _radiusValidationLabelVisible = value; base.OnPropertyChangedAsync("RadiusValidationLabelVisible"); } }

        DateTime _startDate;
        public DateTime StartDate { get { return _startDate; } set { _startDate = value; base.OnPropertyChangedAsync("StartDate"); } }

        string _startDateValidationLabel;
        public string StartDateValidationLabel { get { return _startDateValidationLabel; } set { _startDateValidationLabel = value; base.OnPropertyChangedAsync("StartDateValidationLabel"); } }
        bool _startDateValidationLabelVisible { get; set; }
        public bool StartDateValidationLabelVisible { get { return _startDateValidationLabelVisible; } set { _startDateValidationLabelVisible = value; base.OnPropertyChangedAsync("StartDateValidationLabelVisible"); } }

        DateTime _endDate;
        public DateTime EndDate { get { return _endDate; } set { _endDate = value; base.OnPropertyChangedAsync("EndDate"); } }

        string _endDateValidationLabel;
        public string EndDateValidationLabel { get { return _endDateValidationLabel; } set { _endDateValidationLabel = value; base.OnPropertyChangedAsync("EndDateValidationLabel"); } }
        bool _endDateValidationLabelVisible { get; set; }
        public bool EndDateValidationLabelVisible { get { return _endDateValidationLabelVisible; } set { _endDateValidationLabelVisible = value; base.OnPropertyChangedAsync("EndDateValidationLabelVisible"); } }

        string _category;
        public string Category { get { return _category; } set { _category = value; base.OnPropertyChangedAsync("Category"); } }

        Contracts.Geocoding.IGeocodeResult _geocodeResults { get; set; }
        public Contracts.Geocoding.IGeocodeResult GeocodeResults { get { return _geocodeResults; } set { _geocodeResults = value; base.OnPropertyChangedAsync("GeocodeResults"); } }

        //Contracts.Events.ISearchResult _eventSearchResults;
        //public Contracts.Events.ISearchResult EventSearchResults { get { return _eventSearchResults; } set { _eventSearchResults = value; base.OnPropertyChangedAsync("EventSearchResults"); } }

        bool _searchButtonEnabled;
        public bool SearchButtonEnabled { get { return _searchButtonEnabled; } set { _searchButtonEnabled = value; base.OnPropertyChangedAsync("SearchButtonEnabled"); } }

        bool _searchingForEvents;
        public bool SearchingForEvents { get { return _searchingForEvents; } set { _searchingForEvents = value; base.OnPropertyChangedAsync("SearchingForEvents"); } }
        bool _geoCoding;
        public bool GeoCoding { get { return _geoCoding; } set { _geoCoding = value; base.OnPropertyChangedAsync("GeoCoding"); } }

        //private DelegateCommand searchCommand;

        ///Commands
        ///
        //public ICommand SearchCommand
        //{
        //    get
        //    {
        //        if (searchCommand == null)
        //        {
        //            searchCommand = new DelegateCommand(SearchForEvents);
        //        }
        //        return searchCommand;
        //    }
        //}

        //public void SearchForEvents()
        //{
        //    SearchingForEvents = true;
        //    SearchButtonEnabled = false;
        //    var address = string.Format("{0}, {1}", GeocodeResults.Latitude, GeocodeResults.Longitude);
        //    Task.Factory.StartNew<Contracts.Events.ISearchResult>(() =>
        //    {
        //        var request = DI.Container.Current.Get<Contracts.Events.ISearch>();
        //        request.SecurityToken = App.EventfulAPIKey;
        //        request.SearchParameters = new Dictionary<string, object>();
        //        request.SearchParameters.Add("Location", address);
        //        request.SearchParameters.Add("Within", (int?)Radius);
        //        var date = string.Format("{0}-{1}", StartDate.ToString("yyyyMMdd00"), EndDate.ToString("yyyyMMdd00"));
        //        request.SearchParameters.Add("Date", date);
        //        request.SearchParameters.Add("Category", Category.ToLower().Replace(" ","_"));
        //        request.SearchParameters.Add("Units", "km");
        //        request.SearchParameters.Add("PageSize", (int?)int.MaxValue);

        //        return request.Search();
        //    }).ContinueWith((continuation) =>
        //    {
        //        EventSearchResults = continuation.Result;
        //        SearchButtonEnabled = true;
        //        SearchingForEvents = false;
        //    });
        //}
    }
}