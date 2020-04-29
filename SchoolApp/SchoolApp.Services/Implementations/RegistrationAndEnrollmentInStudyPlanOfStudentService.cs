using System;
using System.Linq;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Services.Implementations
{
    public class RegistrationAndEnrollmentInStudyPlanOfStudentService : IRegistrationAndEnrollmentInStudyPlanOfStudentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public RegistrationAndEnrollmentInStudyPlanOfStudentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public Enrollment DoEnrollmentAndRegistration(Student student, StudyPlan studyPlan)
        {
            var existentEnrollment = _enrollmentRepository.GetByStudent(student.Id);
            if (existentEnrollment != null)
                throw new Exception("The Student is already Enrolled in another StudyPlan");
            
            var existentEnrollments = _enrollmentRepository.GetByStudyPlan(studyPlan.Id);
            if (existentEnrollments.Any(x => x.Student.Id == student.Id))
                throw new Exception("The Student is already Enrolled in this StudyPlan");
            
            var newEnrollment = new Enrollment() { Id = new Guid(), Student = student, StudyPlan = studyPlan};
            return _enrollmentRepository.Add(newEnrollment);
        }
    }
}