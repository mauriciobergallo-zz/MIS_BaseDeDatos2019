using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class CourseSecondaryTeacherDto : IEntityDto
    {
        public Guid id { get; set; }
        [ForeignKey("courseId")]
        public Guid courseId { get; set; }
        public CourseDto course { get; set; }
        [ForeignKey("secondaryTeacherId")]
        public Guid secondaryTeacherId { get; set; }
        public TeacherDto secondaryTeacher { get; set; }
    }
}