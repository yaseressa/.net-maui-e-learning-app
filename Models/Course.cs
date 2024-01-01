

namespace Baro.Models
{
    public class Course
    {
      public int courseId { get; set; }   
      public string name { get; set; }
      public string description { get; set; }
      public string imgSrc { get; set; }
      public List<Quiz> quizzes { get; set; }
      public List<Lesson> lessons { get; set; }
    }
}
