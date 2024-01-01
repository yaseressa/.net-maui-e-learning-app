namespace Baro.Views;

public partial class Question : ContentPage
{
    private readonly List<Models.Quiz> quizzes;
    private List<RQuiz> rquizzes = new List<RQuiz>();
    private int currentIndex = 0;
    private int correctAnswers = 0;

    public Question(List<Models.Quiz> quizzes)
	{
		InitializeComponent();
        this.quizzes = quizzes;
        try
        {
            for (int i = 0; i < quizzes.Count; i++)
            {
                rquizzes.Add(new RQuiz
                {

                    quizId = quizzes[i].quizId,
                    question = quizzes[i].question,
                    answers = quizzes[i].answers.Split("\n"),
                    correct = quizzes[i].correct,
                });
            }
        }catch(Exception ex)
        {
            DisplayAlert("a", ex.Message, "ok");
        }
        corv.ItemsSource = this.rquizzes;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "arrow_broken_left.png"
        });

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        RQuiz si = corv.CurrentItem as RQuiz;
        if(si.answers.ToList().FindIndex( x => x == ((Button) sender).Text) + 1 == si.correct)
        {
            correctAnswers++;

        }

        currentIndex = (currentIndex + 1) % rquizzes.Count;
        if (currentIndex != 0)
        {
            corv.ScrollTo(currentIndex, position: ScrollToPosition.Center, animate: true);
            await pg.ProgressTo((double)currentIndex / (rquizzes.Count - 1), 250, Easing.Linear);
        }
        else
        {
            await Navigation.PopAsync();
            await Shell.Current.Navigation.PushModalAsync(new Result(correctAnswers, rquizzes.Count));
        }

    }


}


public class RQuiz
{
    public int quizId { get; set; }
    public string question { get; set; }
    public string[] answers { get; set; }
    public int correct { get; set; }
}