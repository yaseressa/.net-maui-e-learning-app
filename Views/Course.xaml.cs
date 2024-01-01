using Baro.Models;
using Baro.Services;

namespace Baro.Views;

public partial class Course : ContentPage
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Source { get; set; }
    public int Id { get; set; }
    public List<Models.Lesson> Lessons { get; set; }
    public List<Models.Quiz> quizzes { get; set; }
    public string Page { get; }

    public Course(Models.Course course, string page)
	{
		InitializeComponent();
        this.Id = course.courseId;
        this.Name = course.name;
        this.Description = course.description;
        this.Source = course.imgSrc; 
        this.Lessons = course.lessons; 
        this.quizzes = course.quizzes;
        BindingContext = this;
        InitializeAsync();
        Page = page;
    }
   
    private async void InitializeAsync()
    {
        User c = await UserService.GetUser(Preferences.Get("User", null).Split(":")[0]);
        if (Page != "Assessment")
        {
            if (c.enrolledCourses.Where(course => course.name == this.Name).Any())
            {
                btn.Text = "Continue Learning";
            }
        }
        else
        {
            Q.IsVisible = true;
            btn.Text = "Start Quiz";
        }
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior
        {
            IconOverride = "arrow_broken_left.png"
        });

    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopModalAsync();
    }

    private async void Open(object sender, EventArgs e)
    {
        if (Page != "Assessment")
        {
            User c = await UserService.GetUser(Preferences.Get("User", null).Split(":")[0]);
            if (!c.enrolledCourses.Where(course => course.name == this.Name).Any())
            {
                await UserService.EnrollCourse(c.userId, this.Id);

            }
            if (Navigation.ModalStack.Contains(this))
            {
                await Navigation.PopModalAsync();
                await Shell.Current.Navigation.PushAsync(new CourseLessons(Lessons, Source, Name), true);

            }

        }
        else
        {
                        if (Navigation.ModalStack.Contains(this))
            {
                await Navigation.PopModalAsync();
                await Shell.Current.Navigation.PushAsync(new Question(this.quizzes), true);

            }
        }
    }
}