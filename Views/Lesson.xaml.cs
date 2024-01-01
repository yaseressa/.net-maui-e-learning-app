namespace Baro.Views;

public partial class Lesson : ContentPage
{
	public Lesson(Models.Lesson lesson)
	{
		InitializeComponent();
        BindingContext = lesson;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "arrow_broken_left.png"
        });

    }
}