namespace Baro.Views;

public partial class Result : ContentPage
{

    public Result(int score, int nq)
	{
		InitializeComponent();
        pg.ProgressTo((double)score / nq, 250, Easing.Linear);
        ltext.Text = $"Your score is {score} out of {nq}";
        lpercent.Text = $"{100 * score / nq}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
} 