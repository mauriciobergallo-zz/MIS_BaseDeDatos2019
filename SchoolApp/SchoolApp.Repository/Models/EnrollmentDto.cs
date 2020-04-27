using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class EnrollmentDto : IEntityDto
    {
        public Guid id { get; set; }
        [ForeignKey("studentId")]
        public Guid studentId { get; set; }
        public StudentDto student { get; set; }
        [ForeignKey("studyPlanId")]
        public Guid studyPlanId { get; set; }
        public StudyPlanDto studyPlan { get; set; }
    }
}