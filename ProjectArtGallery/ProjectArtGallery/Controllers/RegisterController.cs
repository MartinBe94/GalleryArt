using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectArtGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ArtGalleryContext _context;
        public RegisterController(ArtGalleryContext context)
        {
            _context = context;
        }
        // GET: api/<RegisterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDTO model)
        {
            
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                User user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = passwordHash
                };

                // Replace 'YourDbContext' with your actual DbContext class name
                {
                    _context.Users.AddAsync(user);
                    _context.SaveChangesAsync(); // Save the user to the database
                }

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Registration failed. Please try again." });
            }
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
