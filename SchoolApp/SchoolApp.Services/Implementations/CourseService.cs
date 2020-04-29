using System;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;
using SchoolApp.Repositories;

namespace SchoolApp.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudyPlanRepository _studyPlanRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly ICourseGenerationService _courseGenerationService;
        private readonly IStudentEnrollmentInCourseService _studentEnrollmentService;

        public CourseService(IStudyPlanRepository studyPlanRepository, ISubjectRepository subjectRepository, 
            ITeacherRepository teacherRepository, ICourseGenerationService courseGenerationService, 
            ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository, 
            IStudentEnrollmentInCourseService studentEnrollmentService)
        {
            _studyPlanRepository = studyPlanRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _courseGenerationService = courseGenerationService;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _studentEnrollmentService = studentEnrollmentService;
        }

        public Course AddCourse(Guid teacherId, Guid subjectId, Guid studyPlanId)
        {
            // Validations
            var teacher = _teacherRepository.Get(teacherId);
            if (teacher == null)
                throw new Exception("No Teacher Found");
            
            var subject = _subjectRepository.Get(subjectId);
            if (subject == null)
                throw new Exception("No Subject Found");
            
            var studyPlan = _studyPlanRepository.Get(studyPlanId);
            if (studyPlan == null)
                throw new Exception("No StudyPlan Found");

            // Execution
            return _courseGenerationService.DoGenerateCourse(teacher, subject, studyPlan);
        }

        public StudentEnrolledInCourse EnrollStudent(Guid courseId, Guid enrollmentId)
        {
            var existentCourse = _courseRepository.Get(courseId);
            if (existentCourse == null)
                throw new Exception("There is no Course with the specified ID");

            var existentEnrollment = _enrollmentRepository.Get(enrollmentId);
            if (existentEnrollment == null)
                throw new Exception("There are no enrollments for the specified ID");
            
            return _studentEnrollmentService.DoEnrollment(existentCourse, existentEnrollment);
        }
    }
}