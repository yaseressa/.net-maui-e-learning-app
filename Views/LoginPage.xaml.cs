using Baro.Database;
using Baro.Models;
using Baro.Services;
using System.Text.RegularExpressions;

namespace Baro.Views;

public partial class LoginPage : ContentPage
{

    public LoginPage( )
	{
		InitializeComponent();
    }

    private async void Register(object sender, EventArgs e)
    {
        await LoginForm.FadeTo(0, 500);
        LoginForm.IsVisible = false;
        LoginText.IsVisible = false;
        RegisterForm.IsVisible = true;
        RegisterText.IsVisible = true;
        await RegisterForm.FadeTo(1, 500);
    }

    private async void Login(object sender, EventArgs e)
    {
        await RegisterForm.FadeTo(0, 500);
        RegisterForm.IsVisible = false;
        RegisterText.IsVisible = false;
        LoginText.IsVisible = true;
        LoginForm.IsVisible = true;
        await LoginForm.FadeTo(1, 500);
        var cs = await CourseService.GetCourses();


    }
    private async void RegisterUser(object sender, EventArgs e)
    {
        try
        {
            if (RgRePass.Text?.Length < 1 || RgPass.Text?.Length < 1 || RgEmail.Text?.Length < 1 || RgEmail.Text?.Length < 1) throw new InvalidDataException("Fill the Missing Fields. ");
            bool s = Regex.Match(RgEmail.Text?.Trim().ToLower() ?? "", @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])").Success;
            if (s)
            {
                if (RgRePass?.Text == RgPass?.Text)
                {
                    var token = await Authentication.Register(RgName.Text, RgEmail.Text, RgRePass.Text);
                    if (token != "")
                    {
                        RgName.Text = RgPass.Text = RgEmail.Text = RgRePass.Text = "";
                        await DisplayAlert("User Signed", "Now Try To Login", "Ok!");
                        await RegisterForm.FadeTo(0, 500);
                        RegisterForm.IsVisible = false;
                        RegisterText.IsVisible = false;
                        LoginText.IsVisible = true;
                        LoginForm.IsVisible = true;
                        await LoginForm.FadeTo(1, 500);
                    }
                    else
                    {
                        throw new InvalidDataException("User Already Exists Try to Login!!.");
                    }
                }
                else
                {
                    await DisplayAlert("Password Mismatch", "Two passwords doesnt match", "REWRITE");

                }
            }
            else
            {
                await DisplayAlert("Formatting Error", "Invalid Email Format.", "REWRITE");
            }
        }catch(InvalidDataException ex)
        {
            await DisplayAlert("Unexpected Error!", ex.Message, "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fill the Missing", ex.Message, "Ok");
        }
    }
    private async void LogUser(object sender, EventArgs e)
    {
        bool s = Regex.Match(LgEmail.Text?.Trim().ToLower() ?? "", @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])").Success;

        if (s)
        {
            Authentication.Login(LgEmail.Text, LgPass.Text);
            LgEmail.Text = LgPass.Text = "";

           
        }
        else
        {
            await DisplayAlert("Formatting Error", "Invalid Email Format.", "REWRITE");
        }
    }
}