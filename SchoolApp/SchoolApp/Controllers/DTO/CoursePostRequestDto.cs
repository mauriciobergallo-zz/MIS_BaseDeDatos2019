using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "course")]
    public class CoursePostRequestDto
    {
        [DataMember(Name = "teacherId")]
        public Guid TeacherId { get; set; }
        [DataMember(Name = "subjectId")]
        public Guid SubjectId { get; set; }
        [DataMember(Name = "studyPlanId")]
        public Guid StudyPlanId { get; set; }
    }
}