using SchoolApp.Models;

namespace SchoolApp.Services
{
    public interface IRegistrationAndEnrollmentInStudyPlanOfStudentService
    {
        Enrollment DoEnrollmentAndRegistration(Student student, StudyPlan studyPlan);
    }
}