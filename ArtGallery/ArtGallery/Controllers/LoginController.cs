using Common.DTOs;
using Data.Interface;
using Data.Models;
using Data.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDbService _db;
        private readonly TokenService _tokenService;

        public LoginController(IDbService db, TokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UsernameOrEmail) || string.IsNullOrWhiteSpace(dto.Password))
            {
                return BadRequest("Invalid login request");
            }

            // Perform user authentication
            var user = await _db.GetByIdAsync<SignUp, SignUpDTO>(u => u.Username == dto.UsernameOrEmail && u.Password == dto.Password);

            if (user == null)
            {
                // Authentication failed
                return Unauthorized();
            }

            // Authentication succeeded - return a token or relevant information
            var token = _tokenService.GenerateToken(dto.UsernameOrEmail,dto.Password); // Replace with your token generation logic

            return Ok(new { Token = token, UserId = user.Id, UserName = user.Username });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
