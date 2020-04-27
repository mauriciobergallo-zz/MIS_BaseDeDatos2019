using System.Collections.Generic;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface ICourseGenerationService
    {
        Course DoGenerateCourse(Teacher teacher, Subject subject, StudyPlan studyPlan);
    }
}