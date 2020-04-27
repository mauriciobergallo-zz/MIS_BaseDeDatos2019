using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Controllers.DTO;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;
using SchoolApp.Repository.Models;

namespace SchoolApp.Controllers
{
    [Route("api/study-plans")]
    public class StudyPlansController : ControllerBase
    {
        private IStudyPlanRepository _studyPlanRepository;
        private IStudyPlanDetailRepository _studyPlanDetailRepository;
        private readonly IMapper _mapper;
        private readonly IStudyPlanService _studyPlanService;
        
        public StudyPlansController(IStudyPlanRepository studyPlanRepository, 
            IStudyPlanDetailRepository studyPlanDetailRepository,
            IMapper mapper, 
            IStudyPlanService studyPlanService)
        {
            _studyPlanRepository = studyPlanRepository;
            _studyPlanDetailRepository = studyPlanDetailRepository;
            _mapper = mapper;
            _studyPlanService = studyPlanService;
        }
        
        // GET api/study-plans
        [HttpGet]
        public ActionResult<List<StudyPlanDto>> Get()
        {
            try
            {
                var listOfStudyPlans = _studyPlanService.ObtainStudyPlans();
                var mappedStudyPlans = listOfStudyPlans.Select(ent => _mapper.Map<StudyPlanDto>(ent)).ToList();
                return new ActionResult<List<StudyPlanDto>>(mappedStudyPlans);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        // GET api/study-plans/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<StudyPlanDto>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
                return BadRequest("Invalid ID Format");

            var objectRequested = _studyPlanRepository.Get(idRequested);
            if (objectRequested == null)
                return NotFound();

            return Ok(_mapper.Map<StudyPlanDto>(objectRequested));
        }

        // POST api/study-plans
        [HttpPost]
        public IActionResult Post([FromBody] StudyPlanPostRequestDto dto)
        {
            if (dto.Id != Guid.Empty)
                return BadRequest("ID Parameter must be empty");

            var newObject = _studyPlanService.Add(dto.Name, dto.Year);
            return Redirect("/api/study-plans/" + newObject.Id);
        }
        
        // PUT api/study-plans/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] StudyPlanPostRequestDto dto)
        {
            if (!Guid.TryParse(id, out var idRequested))
                return BadRequest("Invalid ID Format");

            var objectUpdated = _studyPlanService.Update(_mapper.Map<StudyPlan>(dto));

            return Ok(_mapper.Map<StudyPlanDto>(objectUpdated));
        }
        
        // DELETE api/study-plans/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
                return BadRequest("Invalid ID Format");

            _studyPlanRepository.Delete(idRequested);
            
            return Accepted();
        }

        // GET api/study-plans/{id}/details
        [Route("{id}/details")]
        [HttpGet]
        public IActionResult GetDetails(string id)
        {
            if (!Guid.TryParse(id, out var studyPlanId))
                return BadRequest("Unable to parse the ID of the StudyPlan.");

            var entity = _studyPlanRepository.Get(studyPlanId, "details,details.subject");
            if (entity == null)
                return NotFound("Unable to find the Study Plan");

            var mappedEntities = _mapper.Map<IEnumerable<StudyPlanDetailGetResponseDto>>(entity.Details);
            return Ok(mappedEntities);
        }
        
        // GET api/study-plans/{idStudyPlan}/details/{id}
        [Route("{idStudyPlan}/details/{id}")]
        [HttpGet]
        public IActionResult GetDetails(string idStudyPlan, string id)
        {
            if (!Guid.TryParse(idStudyPlan, out var studyPlanId))
                return BadRequest("Unable to parse the ID of the StudyPlan.");
            
            if (!Guid.TryParse(id, out var studyPlanDetailId))
                return BadRequest("Unable to parse the ID of the StudyPlanDetail.");

            var entity = _studyPlanDetailRepository.Get(studyPlanDetailId, "subject");
            if (entity == null)
                return NotFound("Unable to find the Study Plan Detail");
            
            var mappedEntity = _mapper.Map<StudyPlanDetailDto>(entity);
            return Ok(mappedEntity);
        }
        
        // POST api/study-plans/{id}/details
        [Route("{id}/details")]
        [HttpPost]
        public IActionResult PostDetail(string id, [FromBody] StudyPlanDetailPostRequestDto dto)
        {
            if (!Guid.TryParse(id, out var studyPlanId))
                return BadRequest("Unable to parse the ID of the StudyPlan.");
            
            var newObject = _studyPlanService.AddNewDetail(studyPlanId, dto.Name, dto.SubjectId);
            return Redirect("/api/study-plans/" + id + "/details/" + newObject.Id);
        }
        
        // PUT api/study-plans/{id}/details
        [Route("{idStudyPlan}/details/{id}")]
        [HttpPut]
        public IActionResult PutDetail(string idStudyPlan, string id, [FromBody] StudyPlanDetailPostRequestDto dto)
        {
            if (!Guid.TryParse(idStudyPlan, out var studyPlanId))
                return BadRequest("Unable to parse the ID of the StudyPlan.");
            
            if (!Guid.TryParse(id, out var studyPlanDetailId))
                return BadRequest("Unable to parse the ID of the StudyPlanDetail.");

            var objectUpdated = _studyPlanService.UpdateDetail(studyPlanId, studyPlanDetailId, dto.Name, dto.SubjectId);
            if (objectUpdated == null)
                return NotFound();

            return Redirect("/api/study-plans/" + studyPlanId + "/details/" + studyPlanDetailId);
        }
        
        // DELETE api/study-plans/{idStudyPlan}/details/{id}
        [Route("{idStudyPlan}/details/{id}")]
        [HttpDelete]
        public IActionResult DeleteDetail(string idStudyPlan, string id)
        {
            if (!Guid.TryParse(idStudyPlan, out var studyPlanId))
                return BadRequest("Invalid ID Format for Study Plan");
            
            if (!Guid.TryParse(id, out var studyPlanDetailId))
                return BadRequest("Invalid ID Format for Study Plan Detail");

            _studyPlanDetailRepository.Delete(studyPlanDetailId);
            
            return Accepted();
        }
    }
}