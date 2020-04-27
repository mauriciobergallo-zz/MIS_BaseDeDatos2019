using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "enrollment")]
    public class EnrollmentPostRequestDto
    {
        [DataMember(Name = "id", IsRequired = false)]
        public Guid Id { get; set; }
        [DataMember(Name = "studentId")]
        public Guid StudentId { get; set; }
        [DataMember(Name = "studyPlanId")]
        public Guid StudyPlanId { get; set; }
    }
}