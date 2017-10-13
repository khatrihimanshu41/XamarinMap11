using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace XamarinMapSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinPages : ContentPage
    {
        MapManager _mapManager;
        public PinPages()
        {
            InitializeComponent();
           
            _mapManager = new MapManager(googlemapp);
        }

        private async Task SearchPlace(string queryText)
        {
            var locations = await _mapManager.FindAddress(queryText);
            if (!locations.Any())
            {
                // await DisplayAlert("Place not found", "Search query could not find place.Please refine your search phrase.", "OK");
                return;
            }
            _mapManager.ClearAllPins();
            _mapManager.AddLocationPins(locations);
        }

        private async void SearchControl_SearchButtonPressed(object sender, EventArgs e)
        {
            var addressQuery = SearchControl.Text;
            var locations = await _mapManager.FindAddress(addressQuery);
            if (!locations.Any())
            {
                // await DisplayAlert("Place not found", "Search query could not find place.Please refine your search phrase.", "OK");
                return;
            }
            _mapManager.ClearAllPins();
            _mapManager.AddLocationPins(locations);
        } 

        //private async void btnGetLocation_Clicked(object sender, EventArgs e)
        //{
        //    if (lblLat.Text != "" && lblLog.Text != "")
        //    {
        //        double a = Convert.ToDouble(lblLat.Text);
        //        double b = Convert.ToDouble(lblLog.Text);
        //        Navigation.PushAsync(new Page1(a, b));
        //    }
        //    else
        //    {
        //        await DisplayAlert("Get Location", "Coordinates not found", "OK");
        //        return;
        //    }
        //}

        //private async void btnRemovePin_Clicked(object sender, EventArgs e)
        //{
        //    if (lblLat.Text != "" && lblLog.Text != "")
        //    {
        //        double a = Convert.ToDouble(lblLat.Text);
        //        double b = Convert.ToDouble(lblLog.Text);
        //        string lblPinName = lblName.Text;
        //        _mapManager.RemovePin(a, b);
        //    }
        //    else
        //    {
        //        await DisplayAlert("Remove Location", "Coordinates not found", "OK");
        //        return;
        //    }
        //}

        ////private void btnSeach_Clicked(object sender, EventArgs e)
        //{
        //    SearchPlace(searchQueryEntry.Text.Trim());
        //}
    }
}