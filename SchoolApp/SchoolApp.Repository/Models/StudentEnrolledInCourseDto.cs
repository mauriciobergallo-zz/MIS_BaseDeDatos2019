using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class StudentEnrolledInCourseDto : IEntityDto
    {
        public Guid id { get; set; }
        [ForeignKey("courseId")]
        public Guid courseId { get; set; }
        public CourseDto course { get; set; }
        [ForeignKey("studentEnrolledId")]
        public Guid studentEnrolledId { get; set; }
        public EnrollmentDto studentEnrolled { get; set; }
    }
}