namespace Baro.Views;

public partial class Invite : ContentPage
{
	public Invite()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync(new Uri("https://discord.com"));
    }
}