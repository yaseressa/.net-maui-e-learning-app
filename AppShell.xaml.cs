using Baro.Views;

namespace Baro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            if(Preferences.Get("User", null) != null) {
            CurrentItem = home;
                FlyoutBehavior = FlyoutBehavior.Flyout;
            }
        }

        private async  void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Profile)}");
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (await DisplayAlert("Logging Out", "Do you want to Logout", "Logout", "Cancel"))
            {
                Preferences.Remove("User");
                Preferences.Remove("Token");
                await Shell.Current.GoToAsync($"//Login");
                Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Disabled);
            }
        }
    }
}