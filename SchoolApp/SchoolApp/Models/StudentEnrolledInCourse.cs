namespace SchoolApp.Models
{
    public class StudentEnrolledInCourse : IEntity
    {
        public Student Student { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}