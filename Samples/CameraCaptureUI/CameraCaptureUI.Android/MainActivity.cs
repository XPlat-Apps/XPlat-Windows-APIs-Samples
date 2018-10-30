namespace CameraCaptureUI.Android
{
    using System;

    using global::Android.App;

    using global::Android.OS;

    using global::Android.Support.V7.App;
    using global::Android.Widget;

    using XPlat.Media.Capture;
    using XPlat.Storage;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button captureImageButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnResume()
        {
            if (this.captureImageButton != null)
            {
                this.captureImageButton.Click -= this.OnCaptureImageClick;
            }

            base.OnResume();

            this.captureImageButton = this.FindViewById<Button>(Resource.Id.capture_image_button);

            if (this.captureImageButton != null)
            {
                this.captureImageButton.Click += this.OnCaptureImageClick;
            }
        }

        private async void OnCaptureImageClick(object sender, EventArgs e)
        {
            CameraCaptureUI dialog = new CameraCaptureUI(this);
            dialog.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;

            try
            {
                IStorageFile file = await dialog.CaptureFileAsync(CameraCaptureUIMode.Photo);
                System.Diagnostics.Debug.WriteLine(file != null ? file.Path : "No image was captured.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}