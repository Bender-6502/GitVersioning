namespace GitVersioningTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object? sender, EventArgs e)
        {
            try
            {
                string details
                    = string.Format("Version: {0} Build {1}", AppInfo.Current.VersionString, AppInfo.Current.BuildString);

                this.DisplayAlert("Version Information", details, "OK");
            }
            catch (Exception)
            { }
        }
    }
}
