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
    public class StudyPlanRepository : EntityFrameworkRepository<StudyPlan, StudyPlanDto>, IStudyPlanRepository
    {
        private readonly IMapper _mapper;
        private readonly ISchoolAppDbContext _context;
        
        public StudyPlanRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        public new IEnumerable<StudyPlan> Get()
        {
            var dtos = _context.Set<StudyPlanDto>()
                //.Include(x => x.details)
                .ToList();
            return dtos.Select(dto => _mapper.Map<StudyPlan>(dto)).ToList();
        }

        public new StudyPlan Get(Guid id)
        {
            var dto = _context.Set<StudyPlanDto>()
                //.Include(x => x.details)
                .FirstOrDefault(x => x.id == id);
            return _mapper.Map<StudyPlan>(dto);
        }

        public new void Delete(Guid id)
        {
            _context.Set<StudyPlanDetailDto>()
                .RemoveRange(_context.Set<StudyPlanDetailDto>()
                    .Where(x => x.studyPlanId == id));

            _context.Set<StudyPlanDto>().Remove(_context.StudyPlans.First(x => x.id == id));

            _context.SaveChanges();
        }
    }
}