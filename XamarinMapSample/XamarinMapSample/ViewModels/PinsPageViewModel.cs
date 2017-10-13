using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XamarinMapSample.ViewModels
{
    public class PinsPageViewModel : ViewModelBase
    {
        private Pin _pin;
        private int _mapClickedCount;
        private int _pinClickedCount;
        private int _selectedPinChangedCount;
        private int _infoWindowClickedCount;
        private int _infoWindowLongClickedCount;
        private string _pinDragStatus;
        private string _pinAddress;
        Geocoder geoCoder = new Geocoder();
        public int MapClickedCount
        {
            get => _mapClickedCount;
            set => SetProperty(ref _mapClickedCount, value);
        }

        public int PinClickedCount
        {
            get => _pinClickedCount;
            set => SetProperty(ref _pinClickedCount, value);
        }

        public int SelectedPinChangedCount
        {
            get => _selectedPinChangedCount;
            set => SetProperty(ref _selectedPinChangedCount, value);
        }

        public int InfoWindowClickedCount
        {
            get => _infoWindowClickedCount;
            set => SetProperty(ref _infoWindowClickedCount, value);
        }

        public int InfoWindowLongClickedCount
        {
            get => _infoWindowLongClickedCount;
            set => SetProperty(ref _infoWindowLongClickedCount, value);
        }

        public string PinDragStatus
        {
            get => _pinDragStatus;
            set => SetProperty(ref _pinDragStatus,value);
        }

        public Pin Pin
        {
            get => _pin;
            set => SetProperty(ref _pin, value);
        }

        public string PinAddrss
        {
            get => _pinAddress;
            set => SetProperty(ref _pinAddress, value);
        }

        public ObservableCollection<Pin> Pins { get; set; }

        public Command<MapClickedEventArgs> MapClickedCommand => new Command<MapClickedEventArgs>(
            args =>
            {
                MapClickedCount++;
                Pin = new Pin
                {
                    Label = $"Pin{Pins.Count()}",
                    Position = args.Point
                };
                Pins?.Add(Pin);
            });

        public Command<PinClickedEventArgs> PinClickedCommand => new Command<PinClickedEventArgs>(
            args =>
            {
                PinClickedCount++;
                Pin = args.Pin;
            });

        public Command<SelectedPinChangedEventArgs> SelectedPinChangedCommand => new Command<SelectedPinChangedEventArgs>(
            args =>
            {
                SelectedPinChangedCount++;
                Pin = args.SelectedPin;
            });

        public Command<InfoWindowClickedEventArgs> InfoWindowClickedCommand => new Command<InfoWindowClickedEventArgs>(
            args =>
            {
                InfoWindowClickedCount++;
                Pin = args.Pin;
            });

        public Command<InfoWindowLongClickedEventArgs> InfoWindowLongClickedCommand => new Command<InfoWindowLongClickedEventArgs>(
            args =>
            {
                InfoWindowLongClickedCount++;
                Pin = args.Pin;
            });

        public Command<PinDragEventArgs> PinDragStartCommand => new Command<PinDragEventArgs>(
            args =>
            {
                PinDragStatus = "Start";
                Pin = args.Pin;
            });

        public Command<PinDragEventArgs> PinDraggingCommand => new Command<PinDragEventArgs>(
            args =>
            {
                PinDragStatus = "Dragging";
                Pin = args.Pin;
             
            });
       
        string location = string.Empty;
        public Command<PinDragEventArgs> PinDragEndCommand => new Command<PinDragEventArgs>(callfunAsync);
        

        public async void callfunAsync(PinDragEventArgs args)
        {
            PinDragStatus = "End";
            var position = new Xamarin.Forms.GoogleMaps.Position(args.Pin.Position.Latitude, args.Pin.Position.Longitude);
            var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            foreach (var address in possibleAddresses)
                location += address + "\n";
            foreach (var p in Pins)
            {
                p.Label = location;
            }
        }
    }
}
