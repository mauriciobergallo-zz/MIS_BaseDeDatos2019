using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Controllers.DTO;
using SchoolApp.Domain.Entities;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;
        
        public EnrollmentsController(IEnrollmentService enrollmentService, IEnrollmentRepository enrollmentRepository, 
            IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        // GET api/courses
        [HttpGet]
        public ActionResult<IEnumerable<EnrollmentGetResponseDto>> Get()
        {
            var entities = _enrollmentRepository.Get("student,studyPlan");
            return Ok(_mapper.Map<IEnumerable<EnrollmentGetResponseDto>>(entities));
        }
        
        // GET api/courses/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Enrollment>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var objectRequested = _enrollmentRepository.Get(idRequested, "student,studyPlan");
            if (objectRequested == null)
            {
                return NotFound();
            }

            return Ok(objectRequested);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post(EnrollmentPostRequestDto entity)
        {
            var newObject = _enrollmentService.Add(entity.StudentId, entity.StudyPlanId);
            return Redirect("/api/enrollments/" + newObject.Id);
        }
        
        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Enrollment entity)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var objectUpdated = _enrollmentRepository.Update(entity);
            if (objectUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/enrollments/" + objectUpdated.Id);
        }
        
        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            _enrollmentRepository.Delete(idRequested);
            
            return Accepted();
        }
    }
}