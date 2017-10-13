using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace XamarinMapSample.Droid
{
    [Activity(Label = "XamarinMapSample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
                global::Xamarin.Forms.Forms.Init(this, bundle);
                Xamarin.FormsGoogleMaps.Init(this, bundle);
                LoadApplication(new App());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

