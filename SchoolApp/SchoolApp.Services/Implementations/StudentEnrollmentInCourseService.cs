using System;
using System.Linq;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Services.Implementations
{
    public class StudentEnrollmentInCourseService : IStudentEnrollmentInCourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentEnrolledInCourseRepository _studentEnrolledInCourseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IEnrollmentService _enrollmentService;
        
        public StudentEnrollmentInCourseService(ICourseRepository courseRepository, 
            IStudentEnrolledInCourseRepository studentEnrolledInCourseRepository, IEnrollmentService enrollmentService, 
            IEnrollmentRepository enrollmentRepository)
        {
            _courseRepository = courseRepository;
            _studentEnrolledInCourseRepository = studentEnrolledInCourseRepository;
            _enrollmentService = enrollmentService;
            _enrollmentRepository = enrollmentRepository;
        }

        public StudentEnrolledInCourse DoEnrollment(Course course, Enrollment enrollment)
        {
            var existentCourse = _courseRepository.Get(course.Id,
                "enrollments,enrollments.studentEnrolled,enrollments.studentEnrolled.student");
            if (existentCourse.StudentsEnrolled.ToList().Any(x => x.Enrollment.Id == enrollment.Id))
                throw new Exception("The Student is already Enrolled in this course");

            var existentEnrollment = _enrollmentRepository.Get(enrollment.Id,"student");
            var studentEnrolled = new StudentEnrolledInCourse() { Id = new Guid(), Course = existentCourse, 
                Enrollment = existentEnrollment};

            return _studentEnrolledInCourseRepository.Add(studentEnrolled);
        }
    }
}