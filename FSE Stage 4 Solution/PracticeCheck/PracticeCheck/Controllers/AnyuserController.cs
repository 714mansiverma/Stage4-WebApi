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
    public class AnyuserController : ControllerBase
    {
        private DataConnect db = new DataConnect();

        // GET: api/<AnyuserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = db.MenuItem.ToList();
                return Ok(items);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
