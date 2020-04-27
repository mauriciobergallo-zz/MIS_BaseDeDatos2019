using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface IRegistrationAndEnrollmentInStudyPlanOfStudentService
    {
        Enrollment DoEnrollmentAndRegistration(Student student, StudyPlan studyPlan);
    }
}