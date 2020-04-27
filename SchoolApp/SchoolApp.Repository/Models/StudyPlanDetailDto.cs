using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class StudyPlanDetailDto : IEntityDto
    {
        public Guid id { get; set; }
        public string name { get; set; }
        [ForeignKey("studyPlanId")]
        public Guid studyPlanId { get; set; }
        public StudyPlanDto studyPlan { get; set; }
        [ForeignKey("subjectId")]
        public Guid subjectId { get; set; }
        public SubjectDto subject { get; set; }
    }
}