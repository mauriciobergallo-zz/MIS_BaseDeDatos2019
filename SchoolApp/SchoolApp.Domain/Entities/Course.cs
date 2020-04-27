using System;
using System.Collections.Generic;

namespace SchoolApp.Domain.Entities
{
    public class Course : IEntity
    {
        public Guid Id { get; set; }
        public IEnumerable<StudentEnrolledInCourse> StudentsEnrolled { get; set; }
        public Teacher HeadTeacher { get; set; }
        public IEnumerable<Teacher> SecondaryTeachers { get; set; }
        public Subject Subject { get; set; }
        public StudyPlanDetail StudyPlanDetail { get; set; }
        public School School { get; set; }
    }
}