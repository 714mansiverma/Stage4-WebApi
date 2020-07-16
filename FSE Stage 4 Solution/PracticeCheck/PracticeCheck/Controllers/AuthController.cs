using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PracticeCheck.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeCheck.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DataConnect db = new DataConnect();
        
        // GET: api/<AuthController>
        [HttpGet]
        public IActionResult Get()
        {
            return JwtToken("-1");
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = db.User.Find(id);
            if (id == 1)
                return JwtToken("1");
            else if (person == null)
                return JwtToken("-1");
            else
                return JwtToken(id.ToString());
        }

        private IActionResult JwtToken(string id)
        {
            string role = "Customer";
            if (id == "-1")
            {
                return null;
            }
            else if (id == "1")
                role = "Admin";

            string key = "helloheroBaymax";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "mySystem",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
