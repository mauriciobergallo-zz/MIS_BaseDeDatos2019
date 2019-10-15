using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Models;

namespace SchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private Repositories.IStudentRepository _studentRepository;
        public StudentsController(Repositories.IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Models.Student>> Get()
        {
            return Ok(_studentRepository.Get());
        }
        
        // GET api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Student>> Get(string id)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }

            var studentRequested = _studentRepository.Get(idRequested);
            if (studentRequested == null)
            {
                return NotFound();
            }

            return Ok(studentRequested);
        }

        // POST api/students
        [HttpPost]
        public IActionResult Post(Models.Student student)
        {
            var newStudent = _studentRepository.Add(student);
            return Redirect("/api/students/" + newStudent.Id);
        }
        
        // PUT api/students/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Models.Student student)
        {
            if (!Guid.TryParse(id, out var idRequested))
            {
                return BadRequest("Invalid ID Format");
            }
            
            var studentUpdated = _studentRepository.Update(student);
            if (studentUpdated == null)
            {
                return NotFound();
            }

            return Redirect("/api/students/" + studentUpdated.Id);
        }
        
        // PUT api/students/{id}
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