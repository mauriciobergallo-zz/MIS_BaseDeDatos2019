using System;
using System.Collections.Generic;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Repositories
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        IEnumerable<Enrollment> GetByStudyPlan(Guid studyPlanId);
        Enrollment GetByStudent(Guid studentId);
    }
}