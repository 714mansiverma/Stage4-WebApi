using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandsOn4.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HandsOn4.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        // GET: api/<controller>
        private static List<Student> students = new List<Student>();
        [HttpGet(Name ="GetAllStudent")]
        public IActionResult Get()
        {
            return new ObjectResult(students);
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(students.FirstOrDefault(p => p.Id == id));
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateStudent")]
        public IActionResult Post([FromBody]Student student)
        {
            students.Add(student);
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}",Name = "UpdateStudent")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            students.FirstOrDefault(p => p.Id == id).Name=student.Name;
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}",Name ="DeleteStudent")]
        public IActionResult Delete(int id)
        {
            var _student = students.FirstOrDefault(p => p.Id == id);
            students.Remove(_student);
            return new NoContentResult();
        }
    }
}
