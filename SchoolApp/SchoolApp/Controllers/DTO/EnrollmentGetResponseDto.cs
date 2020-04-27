using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "enrollment")]
    public class EnrollmentGetResponseDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        [DataMember(Name = "student")]
        public string Student { get; set; }
        [DataMember(Name = "studyPlan")]
        public string StudyPlan { get; set; }
    }
}