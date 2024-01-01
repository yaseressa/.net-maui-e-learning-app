namespace Baro.Views;

public partial class Community : ContentPage
{
	public Community()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync(new Uri("https://discord.com"));
    }
}