using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class School
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<StudyPlan> StudyPlans { get; set; }
    }
}