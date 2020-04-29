using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "courseEnrollment")]
    public class CourseEnrollmentPostRequestDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        [DataMember(Name = "courseId")]
        public Guid CourseId { get; set; }
        [DataMember(Name = "enrollmentId")]
        public Guid EnrollmentId { get; set; }
    }
}