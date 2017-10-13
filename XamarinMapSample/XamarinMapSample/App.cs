using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinMapSample;

namespace XamarinMapSample
{
    public class App : Application
    {
        public App()
        {
            var tabs = new TabbedPage();

            // demonstrates the map control with zooming and map-types
            //  var page = new MapPage() { Title = "Map" };
            
            var page2 = new Views.PinPages() { Title = "MainPage" };
            var page1 = new PinPage() { Title = "Pin" };
            ///var page2 = new GeocoderPage() { Title = "GeoCode" };
            //var page3 = new MapAppPage() { Title = "Map App" };
         //   tabs.Children.Add(new NavigationPage (page) { Title = "Map/Zoom", Icon = "glyphish_74_location.png" });

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new NavigationPage (page2) { Title = "MainPage", Icon = "glyphish_07_map_marker.png" });

            // demonstrates the Geocoder class
            //  tabs.Children.Add(new NavigationPage (page2) { Title = "Geocode", Icon = "glyphish_13_target.png" });

            // opens the platform's native Map app
            // tabs.Children.Add(new NavigationPage(page3) { Title = "Map App", Icon = "glyphish_103_map.png" });



            MainPage = new XamarinMapSample.Views.PinPages();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
