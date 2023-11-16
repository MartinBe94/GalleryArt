using Common.DTOs;
using Data.Interface;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IDbService _db;

        public SignUpController(IDbService db) => _db = db;


        // GET: api/<SignUpController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignUpController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignUpController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] SignUpDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var signUp = await _db.AddAsync<SignUp, SignUpDTO>(dto);

                var success = await _db.SaveChangesAsync();
                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<SignUp>(signUp), signUp);
            }
            catch
            {
            }

            return Results.BadRequest();
        }

        // PUT api/<SignUpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignUpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
