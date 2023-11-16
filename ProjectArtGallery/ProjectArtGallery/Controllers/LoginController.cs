// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Data.Interfaces;

namespace ProjectArtGallery.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRegistrationLoginService _registrationLoginService;
        public LoginController(IRegistrationLoginService registrationLoginService)
        {
            _registrationLoginService = registrationLoginService;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        // Inside your login controller
        public async Task<IActionResult> Login([FromBody] Login loginmodel)
        {
            User user = _registrationLoginService.GetUserByEmailOrUsername(loginmodel.UsernameOrEmail); // Retrieve the user by email or username
            if (user != null && BCrypt.Net.BCrypt.Verify(loginmodel.Password, user.Password))
            {
                // Password is valid, generate a JWT token and return it
                // You can use libraries like IdentityServer or JwtBearerAuthentication for this
                string jwtToken =_registrationLoginService.GenerateJwtToken(user); // Replace this with your JWT generation logic
                return Ok(new { token = jwtToken });
            }
            else
            {
                // Invalid credentials, return an error response
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }
        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
