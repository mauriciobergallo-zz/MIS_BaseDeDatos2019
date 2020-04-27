using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Controllers.DTO;
using SchoolApp.Domain.Repositories;
using SchoolApp.Domain.Services;

namespace SchoolApp.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseGenerationService _courseGenerationService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper, ICourseGenerationService courseGenerationService, ICourseService courseService)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _courseGenerationService = courseGenerationService;
            _courseService = courseService;
        }
        
        // GET api/courses
        [HttpGet]
        public ActionResult<IEnumerable<CourseGetResponseDto>> Get()
        {
            var data = _courseRepository.Get("subject,headerTeacher,enrollments");
            return Ok(_mapper.Map<IEnumerable<CourseGetResponseDto>>(data));
        }
        
        // GET api/courses/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Domain.Entities.Course>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var objectRequested = _courseRepository.Get(idRequested, "subject,headerTeacher");
            if (objectRequested == null)
            {
                return NotFound();
            }

            return Ok(objectRequested);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post(CoursePostRequestDto entity)
        {
            var newObject = _courseService.AddCourse(entity.TeacherId, entity.SubjectId, entity.StudyPlanId);
            return Redirect("/api/courses/" + newObject.Id);
        }
        
        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Domain.Entities.Course entity)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var objectUpdated = _courseRepository.Update(entity);
            if (objectUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/courses/" + objectUpdated.Id);
        }
        
        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            _courseRepository.Delete(idRequested);
            
            return Accepted();
        }

    }
}