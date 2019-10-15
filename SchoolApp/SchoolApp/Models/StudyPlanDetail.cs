using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class StudyPlanDetail : IEntity
    {
        public string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}