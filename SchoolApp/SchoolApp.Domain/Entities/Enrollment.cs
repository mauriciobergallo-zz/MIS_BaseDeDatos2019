using System;

namespace SchoolApp.Domain.Entities
{
    public class Enrollment : IEntity
    {
        public Guid Id { get; set; }
        public Student Student { get; set; }
        public StudyPlan StudyPlan { get; set; }
    }
}