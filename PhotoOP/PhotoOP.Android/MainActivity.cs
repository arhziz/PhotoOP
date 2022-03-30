using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using PhotoOP.Services;
using Xamarin.Forms;
using static PhotoOP.Droid.MainActivity;

[assembly: Xamarin.Forms.Dependency(typeof(OrientationService))]
namespace PhotoOP.Droid
{
    [Activity(Label = "PhotoOP", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class OrientationService : IOrientationService
        {
            public void Landscape()
            {
                ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Landscape;
            }

            public void Portrait()
            {
                ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Portrait;
            }
        }
    }
}