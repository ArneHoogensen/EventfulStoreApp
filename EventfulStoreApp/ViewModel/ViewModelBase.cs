using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Windows.UI.Core;
using System.Threading.Tasks;

namespace EventfulStoreApp.ViewModels
{
    /// <summary>
    /// Provides common functionality for ViewModel classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        protected CoreDispatcher _dispatcher = null; 
  

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;

        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        protected async void OnPropertyChangedAsync(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {        
                await UIThreadAction(()=> handler(this, new PropertyChangedEventArgs(propertyName)));
            }

        }

        private async Task UIThreadAction(Action act)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => act.Invoke());
        }

    }
}
