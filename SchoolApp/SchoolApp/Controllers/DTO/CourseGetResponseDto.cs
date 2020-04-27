using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name="studyPlan")]
    public class CourseGetResponseDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        
        [DataMember(Name = "studentsEnrolled")]
        public int StudentsEnrolled { get; set; }
        
        [DataMember(Name = "teacher")]
        public string Teacher { get; set; }
        
        [DataMember(Name = "subject")]
        public string Subject { get; set; }
    }
}