
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XamarinMapSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        double _lat;
        double _log ;
      Geocoder geoCoder;
        public Page1(double _aLat,double _aLog)
        {
            _lat = _aLat;
            _lat = _aLog;
            InitializeComponent();
            Title = "Address Page";
            geoCoder = new Geocoder();
            display(_lat, _lat);
        }
        public async void display(double a, double b)
        {
            var position = new Xamarin.Forms.GoogleMaps.Position(a, b);
            var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            foreach (var address in possibleAddresses)
                lblAddress.Text += address + "\n";
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}