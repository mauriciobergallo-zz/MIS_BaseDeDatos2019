using System;
using System.Collections.Generic;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface IStudyPlanService
    {
        StudyPlan Add(string name, int year);
        StudyPlan Update(StudyPlan studyPlan);
        StudyPlanDetail AddNewDetail(Guid studyPlanId, string name, Guid subjectId);
        StudyPlanDetail UpdateDetail(Guid studyPlanId, Guid studyPlanDetailId, string name, Guid subjectId);
        IEnumerable<StudyPlan> ObtainStudyPlans();
    }
}