using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace XamarinMapSample
{
  public  class MapManager
    {
        Geocoder geoCoder;
        private readonly Map _map;
        public MapManager(Map map)
        {
            this._map = map;
        }
        public async Task<IEnumerable<Position>> FindAddress(string addressQuery)
        {
             geoCoder = new Geocoder();
            var locations = await geoCoder.GetPositionsForAddressAsync(addressQuery);
            return locations;
        }
        public void ClearAllPins()
        {
            _map.Pins.Clear();
        }
        Pin pin = null;
        public async void AddLocationPins(IEnumerable<Position> positions)
        {
          
            foreach (var position in positions)
            {
               var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                foreach (var address in possibleAddresses)
                    pin = new Pin
                    {
                        Type = PinType.Generic,
                        Position = position,
                        IsDraggable = true,
                        Label = address + "\n"
            };
                _map.Pins.Add(pin);
            }
            if (null != pin)
            {
               FocusMapToPosition(pin.Position,100.0);
            }
        }
        public void FocusMapToPosition(Position position, double regionRadius)
        {
            var mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromMiles(regionRadius));
            this._map.MoveToRegion(mapSpan);
        }
        public  void RemovePin(double a, double b)
        {
            var position = new Position(a, b); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Generic,
                Position = position,
                Label = "",
                // Address = Address
            };
            _map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(5000)));
            _map.Pins.Remove(pin);
            pin = null;
        }
        public void SearchPin()
        {
        }
    }
}
