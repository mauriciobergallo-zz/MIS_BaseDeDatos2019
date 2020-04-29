using System;
using System.Runtime.Serialization;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Controllers.DTO
{
    [DataContract]
    public class StudentEnrolledInCourseGetResponseDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        [DataMember(Name = "course")]
        public CourseGetResponseDto Course { get; set; }
        [DataMember(Name = "enrollment")]
        public Enrollment Enrollment { get; set; }
    }
}