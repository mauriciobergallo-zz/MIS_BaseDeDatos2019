using System;

namespace SchoolApp.Domain.Entities
{
    public class StudentEnrolledInCourse : IEntity
    {
        public Guid Id { get; set; }
        public Course Course { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}