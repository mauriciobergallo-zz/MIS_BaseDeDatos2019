using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApp.Repository.Models
{
    public class CourseDto : IEntityDto
    {
        public Guid id { get; set; }
        
        [ForeignKey("headerTeacherId")]
        public Guid headerTeacherId { get; set; }
        public TeacherDto headerTeacher { get; set; }
        
        [ForeignKey("subjectId")]
        public Guid subjectId { get; set; }
        public SubjectDto subject { get; set; }
        
        [ForeignKey("schoolId")]
        public Guid schoolId { get; set; }
        
        public virtual IEnumerable<StudentEnrolledInCourseDto> enrollments { get; set; }
    }
}