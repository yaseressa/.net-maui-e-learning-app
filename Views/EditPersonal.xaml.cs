using Baro.Database;
using Baro.Models;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using Baro.Services;

namespace Baro.Views;

public partial class EditPersonal : ContentPage
{
	public EditPersonal()
	{
		InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

            Shell.SetBackButtonBehavior(this, new BackButtonBehavior
            {
                IconOverride = "arrow_broken_left.png"
            });
       
    }
    private async void ChangeEmail(object sender, EventArgs e)
    {
        try
        {
            bool s = Regex.Match(RgEmail.Text?.Trim().ToLower() ?? "", @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])").Success;
            if (s) { 
                if (RgEmail.Text != null && await DisplayAlert("Change Email", $"changing your email to `{RgEmail.Text}`", "Yes", "No!"))
                {
                    string[] pre = Preferences.Get("User", null).Split(':');
                    string name = pre[1], email = pre[0], id = pre[2], pass = pre[3];
                    await UserService.UpdateUser(Convert.ToInt32(id), new User {name = name, email = RgEmail.Text});
                    Authentication.SetPreferences(RgEmail.Text);
                }
            }
            else
            {
                await DisplayAlert("Formatting Error", "Invalid Email Format.", "REWRITE");

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fill the Missing", ex.Message, "Ok");
        }
    }
    private async void ChangeName(object sender, EventArgs e)
    {
        try
        {
            if (RgName.Text != null && await DisplayAlert("Change Name", $"changing your name to `{RgName.Text}`", "Yes", "No!"))
            {
                string[] pre = Preferences.Get("User", null).Split(':');
                string name = pre[1], email = pre[0], id = pre[2], pass = pre[3];
                await UserService.UpdateUser(Convert.ToInt32(id), new User {name = RgName.Text, email = email});
                Authentication.SetPreferences();

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fill the Missing", ex.Message, "Ok");
        }

    }
    private async void ChangePassword(object sender, EventArgs e)
    {
        try
        {
            if (RgPass.Text == RgRePass.Text)
            {
                if (await DisplayAlert("Change Password", $"changing your password to `{RgRePass.Text}`", "Yes", "No!"))
                {
                    string[] pre = Preferences.Get("User", null).Split(':');
                    string name = pre[1], email = pre[0], id = pre[2], pass = pre[3];
                    await UserService.UpdateUser(Convert.ToInt32(id), new User { name = name, email = email, password = RgRePass.Text});
                    Authentication.SetPreferences();
                }
            }
            else
            {
                await DisplayAlert("Password Mismatch", "Two passwords doesnt match", "refill");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fill the Missing", ex.Message, "Ok");
        }
    }
}