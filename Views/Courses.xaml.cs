
using Baro.Services;

namespace Baro.Views
{
    public class CoursesData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string Description { get; set; }
    }

    public partial class Courses : ContentPage
    {
        public  Courses()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            List<Models.Course> courses = await CourseService.GetCourses();
            cv.ItemsSource = courses;

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

        }
    }
}