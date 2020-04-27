using System;
using System.Collections.Generic;

namespace SchoolApp.Domain.Entities
{
    public class StudyPlanDetail : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public StudyPlan StudyPlan { get; set; }
    }
}