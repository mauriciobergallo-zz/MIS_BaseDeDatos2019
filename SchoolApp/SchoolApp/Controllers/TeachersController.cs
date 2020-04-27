using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Controllers
{
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        private Domain.Repositories.ITeacherRepository _teacherRepository;
        public TeachersController(Domain.Repositories.ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        
        // GET api/teachers
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Entities.Teacher>> Get()
        {
            return Ok(_teacherRepository.Get());
        }
        
        // GET api/teachers/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Domain.Entities.Teacher>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var objectRequested = _teacherRepository.Get(idRequested);
            if (objectRequested == null)
            {
                return NotFound();
            }

            return Ok(objectRequested);
        }

        // POST api/teachers
        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Teacher entity)
        {
            var newObject = _teacherRepository.Add(entity);
            return Redirect("/api/teachers/" + newObject.Id);
        }
        
        // PUT api/teachers/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Domain.Entities.Teacher entity)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var objectUpdated = _teacherRepository.Update(entity);
            if (objectUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/teachers/" + objectUpdated.Id);
        }
        
        // DELETE api/teachers/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            _teacherRepository.Delete(idRequested);
            
            return Accepted();
        }
    }
}