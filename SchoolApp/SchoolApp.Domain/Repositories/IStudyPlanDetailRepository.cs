using System;
using System.Collections.Generic;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Repositories
{
    public interface IStudyPlanDetailRepository : IRepository<StudyPlanDetail>
    {
        IEnumerable<StudyPlanDetail> ObtainDetailsByStudentPlanId(Guid id);
    }
}