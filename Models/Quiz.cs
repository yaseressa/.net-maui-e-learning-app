using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baro.Models
{
    public class Quiz
    {
        public int quizId { get; set; }
        public string question { get; set; }
        public string answers { get; set; }
        public int correct { get; set; }
    }
}
