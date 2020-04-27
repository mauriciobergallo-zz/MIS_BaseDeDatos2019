using System;
using System.Collections.Generic;
using System.Linq;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;
using SchoolApp.Repositories;

namespace SchoolApp.Services.Implementations
{
    public class StudyPlanService : IStudyPlanService
    {
        private readonly IStudyPlanRepository _studyPlanRepository;
        private readonly IStudyPlanDetailRepository _studyPlanDetailRepository;
        private readonly ISubjectRepository _subjectRepository;
        
        public StudyPlanService(IStudyPlanRepository studyPlanRepository, 
            IStudyPlanDetailRepository studyPlanDetailRepository, 
            ISubjectRepository subjectRepository)
        {
            _studyPlanRepository = studyPlanRepository;
            _studyPlanDetailRepository = studyPlanDetailRepository;
            _subjectRepository = subjectRepository;
        }

        public StudyPlan Add(string name, int year)
        {
            var newStudyPlan = new StudyPlan() { Id = new Guid(), Name = name, Year = year};
            return _studyPlanRepository.Add(newStudyPlan);
        }

        public StudyPlan Update(StudyPlan studyPlan)
        {
            var existentStudyPlan = _studyPlanRepository.Get(studyPlan.Id);
            if (existentStudyPlan == null)
                throw new Exception("There is no Study Plan with that ID");

            var updatedValue = _studyPlanRepository.Update(studyPlan);
            return updatedValue;
        }

        public StudyPlanDetail AddNewDetail(Guid studyPlanId, string name, Guid subjectId)
        {
            var studyPlan = _studyPlanRepository.Get(studyPlanId, "details,details.subject");
            if (studyPlan == null)
                throw new Exception("There is no StudyPlan with that ID");

            var subject = _subjectRepository.Get(subjectId);
            if (subject == null)
                throw new Exception("There is no Subject with that ID");
            
            if (studyPlan.Details.Any(x => x.Subject.Id == subjectId))
                throw new Exception("The StudyPlan already have this Subject in the Detail");
            
            var newDetail = new StudyPlanDetail {Id = new Guid(), Subject = subject, Name = name, StudyPlan = studyPlan};
            return _studyPlanDetailRepository.Add(newDetail);
        }

        public StudyPlanDetail UpdateDetail(Guid studyPlanId, Guid studyPlanDetailId, string name, Guid subjectId)
        {
            var existentStudyPlan = _studyPlanRepository.Get(studyPlanId, "details,details.subject");
            if (existentStudyPlan == null)
                throw new Exception("There is no Study Plan with that ID");
            
            var subject = _subjectRepository.Get(subjectId);
            if (subject == null)
                throw new Exception("There is no Subject with that ID");
            
            if (existentStudyPlan.Details.Any(x => x.Subject.Id == subjectId && x.Id != studyPlanDetailId))
                throw new Exception("The StudyPlan already have this Subject in the Detail");
            
            var updateStudyPlanDetail = new StudyPlanDetail()
            {
                Id = studyPlanDetailId, 
                Name = name, 
                Subject = subject, 
                StudyPlan = existentStudyPlan
            };

            return _studyPlanDetailRepository.Update(updateStudyPlanDetail);
        }

        public IEnumerable<StudyPlan> ObtainStudyPlans()
        {
            var entities = _studyPlanRepository.Get();
            entities.ToList().ForEach(x =>
            {
                x.Details = _studyPlanDetailRepository.ObtainDetailsByStudentPlanId(x.Id);
            });

            return entities;
        }
    }
}