using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeCheck.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeCheck.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private DataConnect db = new DataConnect();
        // GET: api/<AdminController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = db.MenuItem.ToList();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = db.MenuItem.Find(id);
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<AdminController>
        [HttpPost]
        public IActionResult Post([FromBody]MenuItem item)
        {
            try
            {
                db.MenuItem.Add(item);
                db.SaveChanges();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }

        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]MenuItem item)
        {
            try
            {
                db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                db.MenuItem.Remove(db.MenuItem.Find(id));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
