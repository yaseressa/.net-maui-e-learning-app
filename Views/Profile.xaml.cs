using Baro.Database;
using Baro.Models;
using Baro.Services;

namespace Baro.Views;

public partial class Profile : ContentPage
{
	 
	public Profile()
	{
		InitializeComponent();
		

	}
    protected async override  void OnNavigatedTo(NavigatedToEventArgs args)
    {

        try
        {
            base.OnNavigatedTo(args);
            string[] pre = Preferences.Get("User", null).Split(':');
            User u = await UserService.GetUser(pre[0]);
            nameEdit.Text = u.name;
            emailEdit.Text = u.email;
        }catch(Exception ex) { DisplayAlert("hjjd", ex.Message, "js"); }

    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new EditPersonal(), true);
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