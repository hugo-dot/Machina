using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;


namespace Machina
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void StartButtonClicked(object sender, EventArgs e)
        {
            StartButtonClickedAsync();
           
        }
        private async Task StartButtonClickedAsync()
        {
            
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

            //await DisplayAlert("File Location", file.Path, "OK");

            // image.Source = ImageSource.FromStream(() =>
            // {
            //    var stream = file.GetStream();
            //  return stream;
            //});
            await Navigation.PushAsync(new ScannerPage(file)); 
        }
    }
}
