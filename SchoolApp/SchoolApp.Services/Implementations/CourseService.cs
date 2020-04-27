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
        private readonly ICourseGenerationService _courseGenerationService;

        public CourseService(IStudyPlanRepository studyPlanRepository, ISubjectRepository subjectRepository, 
            ITeacherRepository teacherRepository, ICourseGenerationService courseGenerationService)
        {
            _studyPlanRepository = studyPlanRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _courseGenerationService = courseGenerationService;
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
    }
}