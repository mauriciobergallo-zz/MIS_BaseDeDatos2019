using System;
using System.Linq;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Services.Implementations
{
    public class CourseGenerationService : ICourseGenerationService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudyPlanDetailRepository _studyPlanDetailRepository;

        public CourseGenerationService(ICourseRepository courseRepository, IStudyPlanRepository studyPlanRepository, 
            IStudyPlanDetailRepository studyPlanDetailRepository)
        {
            _courseRepository = courseRepository;
            _studyPlanDetailRepository = studyPlanDetailRepository;
        }

        public Course DoGenerateCourse(Teacher teacher, Subject subject, StudyPlan studyPlan)
        {
            // Validations:
            // - Schedule of Teacher
            // - Valid StudyPlan
            // - etc.
            
            var studyPlanDetails = _studyPlanDetailRepository
                .ObtainDetailsByStudentPlanId(studyPlan.Id)
                .ToList();
            
            if (studyPlanDetails.Count == 0)
                throw new Exception("No details for this StudyPlan");

            var studyPlanDetail = studyPlanDetails.FirstOrDefault(x => x.Subject.Id == subject.Id);
            if (studyPlanDetail == null)
                throw new Exception("No detail found for this StudyPlan and Subject.");

            var course = new Course {Id = new Guid(), HeadTeacher = teacher, Subject = subject, StudyPlanDetail = studyPlanDetail};

            var courseAdded = _courseRepository.Add(course);
            
            return courseAdded;
        }
    }
}