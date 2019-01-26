namespace CameraCaptureUI.Android
{
    using System;

    using global::Android.App;
    using global::Android.Graphics;
    using global::Android.OS;

    using global::Android.Support.V7.App;
    using global::Android.Widget;

    using Java.Net;

    using XPlat.Media.Capture;
    using XPlat.Storage;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button captureImage;

        private ImageView outputImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnResume()
        {
            if (this.captureImage != null)
            {
                this.captureImage.Click -= this.CaptureImage_Click;
            }

            base.OnResume();

            this.captureImage = this.FindViewById<Button>(Resource.Id.CaptureImage);
            this.outputImage = this.FindViewById<ImageView>(Resource.Id.OutputImage);

            if (this.captureImage != null)
            {
                this.captureImage.Click += this.CaptureImage_Click;
            }
        }

        private async void CaptureImage_Click(object sender, EventArgs e)
        {
            CameraCaptureUI cameraCaptureUi = new CameraCaptureUI(this);
            cameraCaptureUi.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;

            try
            {
                IStorageFile file = await cameraCaptureUi.CaptureFileAsync(CameraCaptureUIMode.Photo);
                System.Diagnostics.Debug.WriteLine(file != null ? file.Path : "No image was captured.");

                if (file != null)
                {
                    Bitmap bitmap = BitmapFactory.DecodeFile(file.Path);
                    this.outputImage.SetImageBitmap(bitmap);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}