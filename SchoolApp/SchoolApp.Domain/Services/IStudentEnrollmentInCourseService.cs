using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface IStudentEnrollmentInCourseService
    {
        StudentEnrolledInCourse DoEnrollment(Course course, Enrollment enrollment);
    }
}