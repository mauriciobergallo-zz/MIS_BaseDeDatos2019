using System;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class StudyPlan : IEntity
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public IEnumerable<StudyPlanDetail> Details { get; set; }
    }
}