namespace SchoolApp.Models
{
    public class Enrollment : IEntity
    {
        public Student Student { get; set; }
        public StudyPlan StudyPlan { get; set; }
    }
}