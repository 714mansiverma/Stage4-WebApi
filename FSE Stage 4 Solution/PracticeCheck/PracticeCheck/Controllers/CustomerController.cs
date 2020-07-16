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
    [Authorize(Roles ="Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private DataConnect db = new DataConnect();
        private MenuItemOperation menu = new MenuItemOperation();

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items=menu.MenuFilter();
                return Ok(items);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var items = menu.CartItemAccess(id);
                return Ok(items);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody]Cart cart)
        {
            try
            {
                db.Cart.Add(cart);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromBody] int itemid)
        {
            try
            {
                var items = menu.CartAccess(id);

                var del = items.First();

                foreach(var i in items)
                {
                    if (i.Item == itemid)
                    {
                        del = i;
                        break;
                    }
                }
                db.Cart.Remove(del);
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
