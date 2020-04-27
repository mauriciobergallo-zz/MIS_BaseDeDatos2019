using System;
using System.Collections.Generic;

namespace SchoolApp.Domain.Entities
{
    public class School : IEntity
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<StudyPlan> StudyPlans { get; set; }
        public Guid Id { get; set; }
    }
}