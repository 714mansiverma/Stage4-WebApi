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
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataConnect db = new DataConnect();

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public bool Get(short id,[FromBody] string password)
        {
            try
            {
                var detail = db.User.Find(id);
                if (detail == null)
                    return false;
                else if (detail.Password == password)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] User user)
        {
            try
            {
                db.User.Add(user);
                db.SaveChanges();
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
