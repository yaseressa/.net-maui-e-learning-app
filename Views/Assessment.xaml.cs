using Baro.Services;
using System.Collections.ObjectModel;

namespace Baro.Views;

public partial class Assessment : ContentPage
{
    public Assessment()
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