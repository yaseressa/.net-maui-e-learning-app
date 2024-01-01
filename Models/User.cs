using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baro.Models
{
    public  class User
    {
        [AutoIncrement, PrimaryKey]
        public int userId { get; set; }
        [NotNull]
        public string name { get; set; }
        [NotNull]
        public string email { get; set; }
        [NotNull]
        public string password { get; set; }
        public List<Course> enrolledCourses {  get; set; }  
    }
}
