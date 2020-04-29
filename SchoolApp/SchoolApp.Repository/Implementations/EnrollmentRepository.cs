using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Repository.Contexts;
using SchoolApp.Repository.Models;

namespace SchoolApp.Repository.Implementations
{
    public class EnrollmentRepository : EntityFrameworkRepository<Enrollment, EnrollmentDto>, IEnrollmentRepository
    {
        private readonly ISchoolAppDbContext _context;
        private readonly IMapper _mapper;
        public EnrollmentRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Enrollment> GetByStudyPlan(Guid studyPlanId)
        {
            var enrollments = _context.Enrollments
                .Include(x => x.student)
                .Include(x => x.studyPlan)
                .Where(x => x.studyPlanId == studyPlanId);
            return _mapper.Map<IEnumerable<Enrollment>>(enrollments);
        }

        public Enrollment GetByStudent(Guid studentId)
        {
            var enrollment = _context.Enrollments
                .Include(x => x.student)
                .Include(x => x.studyPlan)
                .FirstOrDefault(x => x.studentId == studentId);
            return _mapper.Map<Enrollment>(enrollment);
        }
    }
}