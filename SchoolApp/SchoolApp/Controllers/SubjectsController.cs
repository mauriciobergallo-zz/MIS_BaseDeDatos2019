using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Controllers
{
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private Repositories.ISubjectRepository _subjectRepository;
        public SubjectsController(Repositories.ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        
        // GET api/subjects
        [HttpGet]
        public ActionResult<IEnumerable<Domain.Entities.Subject>> Get()
        {
            return Ok(_subjectRepository.Get());
        }
        
        // GET api/subjects/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Domain.Entities.Subject>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var objectRequested = _subjectRepository.Get(idRequested);
            if (objectRequested == null)
            {
                return NotFound();
            }

            return Ok(objectRequested);
        }

        // POST api/subjects
        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Subject entity)
        {
            var newObject = _subjectRepository.Add(entity);
            return Redirect("/api/subjects/" + newObject.Id);
        }
        
        // PUT api/subjects/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Domain.Entities.Subject entity)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var objectUpdated = _subjectRepository.Update(entity);
            if (objectUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/subjects/" + objectUpdated.Id);
        }
        
        // DELETE api/subjects/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            _subjectRepository.Delete(idRequested);
            
            return Accepted();
        }
    }
}