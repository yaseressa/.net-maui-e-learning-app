namespace Baro.Views;

public partial class CourseLessons : ContentPage
{
    private List<Models.Lesson> lessons;
    private string Source;
    private string Name;

    public CourseLessons(List<Models.Lesson> lessons, string Source, string Name)
	{
        InitializeComponent();
        this.lessons = lessons;
        BindingContext = this;
        for(int i = 0; i < lessons.Count; i++)
        {
            lessons[i].lessonId = i + 1;
        }
        cv.ItemsSource = lessons;
        img.Source = Source;
        title.Text = Name + " Lessons";
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "arrow_broken_left.png"
        });

    }

    private void cv_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cv.SelectedItem != null)
        {
            var c = cv.SelectedItem as Models.Lesson;
            var lesson = new Lesson(c);
            Navigation.PushAsync(lesson);
            cv.SelectedItem = null;
        }

    }
}