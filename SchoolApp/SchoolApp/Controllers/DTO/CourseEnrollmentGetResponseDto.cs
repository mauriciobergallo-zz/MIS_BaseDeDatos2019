using System;
using System.Runtime.Serialization;

namespace SchoolApp.Controllers.DTO
{
    [DataContract(Name = "courseEnrollment")]
    public class CourseEnrollmentGetResponseDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        [DataMember(Name = "studentId")]
        public Guid StudentId { get; set; }
        [DataMember(Name = "studentName")]
        public string StudentName { get; set; }
        [DataMember(Name = "enrollmentId")]
        public Guid EnrollmentId { get; set; }
    }
}