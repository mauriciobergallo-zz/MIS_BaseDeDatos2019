using System;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudyPlanRepository _studyPlanRepository;
        private readonly IRegistrationAndEnrollmentInStudyPlanOfStudentService _registrationAndEnrollmentService;

        public EnrollmentService(IStudyPlanRepository studyPlanRepository, IStudentRepository studentRepository, 
            IRegistrationAndEnrollmentInStudyPlanOfStudentService registrationAndEnrollmentService)
        {
            _studyPlanRepository = studyPlanRepository;
            _studentRepository = studentRepository;
            _registrationAndEnrollmentService = registrationAndEnrollmentService;
        }

        public Enrollment Add(Guid studentId, Guid studyPlanId)
        {
            // Validations
            var student = _studentRepository.Get(studentId);
            if (student == null)
                throw new Exception("No Student Found");
            
            var studyPlan = _studyPlanRepository.Get(studyPlanId);
            if (studyPlan == null)
                throw new Exception("No StudyPlan Found");

            return _registrationAndEnrollmentService.DoEnrollmentAndRegistration(student, studyPlan);
        }
    }
}