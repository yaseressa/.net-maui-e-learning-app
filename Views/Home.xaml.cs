using Baro.Services;
using System.Collections.ObjectModel;

namespace Baro.Views;

public partial class Home : ContentPage
{
    private int currentIndex = 0;
    public class Poster
    {
        public string Src { get; set; }
        public string Description { get; set; }
    }
    public List<CoursesData> ECourses = new List<CoursesData>
    {
            new CoursesData
            {
                Id = 1,
                Name = "HTML",
                LName = "html.png",
                Description = "Lorem jskladddddddddddddddddddddnfs vfyvuhsudhvhhfhyuhgu usfhvhuhssdyghf uhfuhuhuhuyerjdufhgushufdhuhguh uhguihuighuifhdudhuhdsjhjdhgu ufhgufhduhhgytwhtuuydsuhtregy7dsguerhygyhfgufdshfughruthbh34gyg w8ertewuehyug76wre67ty4ty4gy43t2y2 44treueruty74yheursthehfdskjkffhurwywjdsnu78453829ytrkdhjbvhbcc gvhdcnjxnhd hxshdnjwnjdhwemdebueundbyrf3uhy4j3 fr7g6dsudeyrenurbvyunufvbhwegfvchcrcbud dybr22refrvgfheyudyfbe3byu"
            },
            new CoursesData
            {
                Id = 4,
                Name = "Java Programming",
                LName = "java.png",
                Description = "Lorem jskladddddddddddddddddddddnfs vfyvuhsudhvhhfhyuhgu usfhvhuhssdyghf uhfuhuhuhuyerjdufhgushufdhuhguh uhguihuighuifhdudhuhdsjhjdhgu ufhgufhduhhgytwhtuuydsuhtregy7dsguerhygyhfgufdshfughruthbh34gyg w8ertewuehyug76wre67ty4ty4gy43t2y2 44treueruty74yheursthehfdskjkffhurwywjdsnu78453829ytrkdhjbvhbcc gvhdcnjxnhd hxshdnjwnjdhwemdebueundbyrf3uhy4j3 fr7g6dsudeyrenurbvyunufvbhwegfvchcrcbud dybr22refrvgfheyudyfbe3byu"
            },
    };
    public List<CoursesData> courses = new List<CoursesData>
        {
            new CoursesData
            {
                Id = 1,
                Name = "HTML",
                LName = "html.png",
                Description = "Lorem jskladddddddddddddddddddddnfs vfyvuhsudhvhhfhyuhgu usfhvhuhssdyghf uhfuhuhuhuyerjdufhgushufdhuhguh uhguihuighuifhdudhuhdsjhjdhgu ufhgufhduhhgytwhtuuydsuhtregy7dsguerhygyhfgufdshfughruthbh34gyg w8ertewuehyug76wre67ty4ty4gy43t2y2 44treueruty74yheursthehfdskjkffhurwywjdsnu78453829ytrkdhjbvhbcc gvhdcnjxnhd hxshdnjwnjdhwemdebueundbyrf3uhy4j3 fr7g6dsudeyrenurbvyunufvbhwegfvchcrcbud dybr22refrvgfheyudyfbe3byu"
            },
                        new CoursesData
            {
                Id = 4,
                Name = "Java Programming",
                LName = "java.png",
                Description = "Lorem jskladddddddddddddddddddddnfs vfyvuhsudhvhhfhyuhgu usfhvhuhssdyghf uhfuhuhuhuyerjdufhgushufdhuhguh uhguihuighuifhdudhuhdsjhjdhgu ufhgufhduhhgytwhtuuydsuhtregy7dsguerhygyhfgufdshfughruthbh34gyg w8ertewuehyug76wre67ty4ty4gy43t2y2 44treueruty74yheursthehfdskjkffhurwywjdsnu78453829ytrkdhjbvhbcc gvhdcnjxnhd hxshdnjwnjdhwemdebueundbyrf3uhy4j3 fr7g6dsudeyrenurbvyunufvbhwegfvchcrcbud dybr22refrvgfheyudyfbe3byu"
            },
            new CoursesData
            {
                Id = 5,
                Name = "Go Programming",
                LName = "go.png",
                Description = "Lorem jskladddddddddddddddddddddnfs vfyvuhsudhvhhfhyuhgu usfhvhuhssdyghf uhfuhuhuhuyerjdufhgushufdhuhguh uhguihuighuifhdudhuhdsjhjdhgu ufhgufhduhhgytwhtuuydsuhtregy7dsguerhygyhfgufdshfughruthbh34gyg w8ertewuehyug76wre67ty4ty4gy43t2y2 44treueruty74yheursthehfdskjkffhurwywjdsnu78453829ytrkdhjbvhbcc gvhdcnjxnhd hxshdnjwnjdhwemdebueundbyrf3uhy4j3 fr7g6dsudeyrenurbvyunufvbhwegfvchcrcbud dybr22refrvgfheyudyfbe3byu"
            },
        
    new CoursesData
            {
                Id = 3,
                Name = "C# Programming",
                LName = "cs.png",
            },
            new CoursesData
            {
                Id = 2,
                Name = "CSS",
                LName = "css.png",
                Description = "This course is designed to provide a comprehensive introduction to Cascading Style Sheets (CSS) for web development. Participants will learn the fundamentals of styling HTML documents to create visually appealing and responsive web pages. The course includes hands-on exercises, projects, and real-world examples to reinforce learning."
            },

        };
    public List<Poster> posters = new List<Poster>
        {
            new Poster
            {
                Src = "learnposter.png",
                Description = "Never stop exploring, never stop growing."
            },
           new Poster
            {
                Src = "quize.png",
                Description = "The fun way to learn, challenge, and grow."
            },
        new Poster
            {
                Src = "composter.png",
                Description = "Support, inspire, achieve. Join our power Community"
            },
        };
    public Home()
	{
        InitializeComponent();
        corv.ItemsSource = this.posters;
        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            currentIndex = (currentIndex + 1) % posters.Count;
            corv.ScrollTo(currentIndex, position: ScrollToPosition.Center, animate: true);
            return true;
        });
    }
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        InitializeAsync();

    }

    private async void InitializeAsync()
    {
        List<Models.Course> courses = await CourseService.GetTrendingCourses();
        var ECourses = await UserService.GetUser(Preferences.Get("User", null).Split(":")[0]);
        cv.ItemsSource = courses;
        cv2.ItemsSource = ECourses.enrolledCourses;

    }
    private void cv_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cv.SelectedItem != null)
        {
            var c = cv.SelectedItem as Models.Course;
            var course = new Course(c, this.GetType().Name);
            Navigation.PushModalAsync(course);
            cv.SelectedItem = null;
        }

    }    private void cv2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cv2.SelectedItem != null)
        {
            var c = cv2.SelectedItem as Models.Course;
            var course = new Course(c, this.GetType().Name);
            Navigation.PushModalAsync(course);
            cv2.SelectedItem = null;
        }

    }
}