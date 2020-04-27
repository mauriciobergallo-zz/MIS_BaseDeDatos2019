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
    public class StudyPlanDetailRepository : EntityFrameworkRepository<StudyPlanDetail, StudyPlanDetailDto>, IStudyPlanDetailRepository
    {
        private readonly ISchoolAppDbContext _context;
        private readonly IMapper _mapper;
        
        public StudyPlanDetailRepository(IMapper mapper, ISchoolAppDbContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<StudyPlanDetail> ObtainDetailsByStudentPlanId(Guid id)
        {
            var data = _context.StudyPlanDetails
                .Include(x => x.subject)
                .Where(x => x.studyPlanId == id);
            return _mapper.Map<IEnumerable<StudyPlanDetail>>(data);
        }
    }
}