using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using PhotoOP.Services;

namespace PhotoOP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<IOrientationService>().Landscape();
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            if (!MediaPicker.IsCaptureSupported)
                return;
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions { Title = "Take A Picture" });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                photo.Source = ImageSource.FromStream(() => stream);
                
            }


        }
    }
}
