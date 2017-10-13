using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms;

namespace XamarinMapSample
{
    public class PinPage : ContentPage
    {
        Map map;

        public PinPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(36.9628066, -122.0194722), Distance.FromMiles(3))); // Santa Cruz golf course
            string Label = "Addrss Details";
            string Address = "Custom detail info";
            var position = new Position(36.9628066, -122.0194722); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = Label,
                Address = Address
            };
            map.Pins.Add(pin);
            // create buttons
            var morePins = new Button { Text = "Add more pins" };

            pin.Clicked += (sender, e) =>
            {
               
               // Navigation.PushAsync(new Page1(Label,Address));
                
            };
            morePins.Clicked += (sender, e) => {
                map.Pins.Add(new Pin
                {
                    Position = new Position(36.9641949, -122.0177232),
                    Label = "Lable1"
                });
                map.Pins.Add(new Pin
                {
                    Position = new Position(36.9571571, -122.0173544),
                    Label = "Lable12"
                });
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(36.9628066, -122.0194722), Distance.FromMiles(1.5)));

            };
            var reLocate = new Button { Text = "Re-center" };
            reLocate.Clicked += (sender, e) => {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(36.9628066, -122.0194722), Distance.FromMiles(3)));
            };
            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    morePins, reLocate
                }
            };

            // put the page together
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    map,
                    buttons
                }
            };
        }
    }
}