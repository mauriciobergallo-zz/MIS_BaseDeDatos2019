using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Course : IEntity
    {
        public IEnumerable<StudentEnrolledInCourse> StudentsEnrolled { get; set; }
        public Teacher HeadTeacher { get; set; }
        public IEnumerable<Teacher> SecondaryTeachers { get; set; }
        public Subject Subject { get; set; }
    }
}