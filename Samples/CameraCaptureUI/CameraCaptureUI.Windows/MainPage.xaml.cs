namespace CameraCaptureUI.Windows
{
    using System;

    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Controls;
    using global::Windows.UI.Xaml.Media.Imaging;

    using XPlat.Media.Capture;
    using XPlat.Storage;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CaptureImage_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI cameraCaptureUi = new CameraCaptureUI();
            cameraCaptureUi.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;

            try
            {
                IStorageFile file = await cameraCaptureUi.CaptureFileAsync(CameraCaptureUIMode.Photo);
                System.Diagnostics.Debug.WriteLine(file != null ? file.Path : "No image was captured.");

                if (file != null)
                {
                    this.OutputImage.Source = new BitmapImage(new Uri(file.Path));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}