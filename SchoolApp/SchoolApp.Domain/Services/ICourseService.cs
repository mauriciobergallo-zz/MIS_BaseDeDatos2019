using System;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface ICourseService
    {
        Course AddCourse(Guid teacherId, Guid subjectId, Guid studyPlanId);
    }
}