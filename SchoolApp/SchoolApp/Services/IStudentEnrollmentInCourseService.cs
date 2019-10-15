using SchoolApp.Models;

namespace SchoolApp.Services
{
    public interface IStudentEnrollmentInCourseService
    {
        StudentEnrolledInCourse DoEnrollment(Student student, StudyPlan studyPlan);
    }
}