namespace Package.Windows
{
    using System.Text;

    using global::Windows.UI.Xaml;
    using global::Windows.UI.Xaml.Controls;

    using XPlat.ApplicationModel;

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void GetPackage_Click(object sender, RoutedEventArgs e)
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

            this.OutputText.Text = builder.ToString();
        }

        private string GetVersionString(PackageVersion version)
        {
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}