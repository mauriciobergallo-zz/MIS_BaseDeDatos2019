using System;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Domain.Services
{
    public interface IEnrollmentService
    {
        Enrollment Add(Guid studentId, Guid studyPlanId);
    }
}