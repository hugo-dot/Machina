using System;
using System.Collections.Generic;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Machina
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage(MediaFile file)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            faceImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStreamWithImageRotatedForExternalStorage();
                return stream;
            });
        }

        private void ContinueButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PopAsync();
        }
    }
}

