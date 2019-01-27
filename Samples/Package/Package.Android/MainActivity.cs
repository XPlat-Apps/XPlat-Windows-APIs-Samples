namespace Package.Android
{
    using System;
    using System.Text;

    using global::Android.App;
    using global::Android.Graphics;
    using global::Android.OS;
    using global::Android.Support.V7.App;
    using global::Android.Widget;

    using XPlat.ApplicationModel;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button getPackage;

        private TextView outputText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.activity_main);
        }

        protected override void OnResume()
        {
            if (this.getPackage != null)
            {
                this.getPackage.Click -= this.GetPackage_Click;
            }

            base.OnResume();

            this.getPackage = this.FindViewById<Button>(Resource.Id.GetPackage);
            this.outputText = this.FindViewById<TextView>(Resource.Id.OutputText);

            if (this.getPackage != null)
            {
                this.getPackage.Click += this.GetPackage_Click;
            }
        }

        private void GetPackage_Click(object sender, EventArgs e)
        {
            Package package = Package.Current;

            IPackageId packageId = package.Id;

            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Name: {packageId.Name}");
            builder.AppendLine($"Version: {this.GetVersionString(packageId.Version)}");
            builder.AppendLine($"FullName: {packageId.FullName}");
            builder.AppendLine($"DisplayName: {package.DisplayName}");
            builder.AppendLine($"InstalledLocation: {package.InstalledLocation.Path}");
            builder.AppendLine($"Logo: {package.Logo.AbsoluteUri}");
            builder.AppendLine($"IsDevelopmentMode: {package.IsDevelopmentMode}");
            builder.AppendLine($"InstalledDate: {package.InstalledDate:g}");

            this.outputText.Text = builder.ToString();
        }

        private string GetVersionString(PackageVersion version)
        {
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}