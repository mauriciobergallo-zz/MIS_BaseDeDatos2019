using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private Domain.Repositories.IStudentRepository _studentRepository;
        public StudentsController(Domain.Repositories.IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Entities.Student>> Get()
        {
            return Ok(_studentRepository.Get());
        }
        
        // GET api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Domain.Entities.Student>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var objectRequested = _studentRepository.Get(idRequested);
            if (objectRequested == null)
            {
                return NotFound();
            }

            return Ok(objectRequested);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post(Domain.Entities.Student entity)
        {
            var newObject = _studentRepository.Add(entity);
            return Redirect("/api/students/" + newObject.Id);
        }
        
        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Domain.Entities.Student entity)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var objectUpdated = _studentRepository.Update(entity);
            if (objectUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/students/" + objectUpdated.Id);
        }
        
        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            _studentRepository.Delete(idRequested);
            
            return Accepted();
        }
    }
}