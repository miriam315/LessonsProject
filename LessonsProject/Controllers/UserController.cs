using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IDataContext _context { get; set; }
        public UserController(IDataContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == id)!;
            if(user!=null)
                return Ok(user);
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User value)
        {
            var u = _context.users.Find(x=>x.Id == value.Id);
            if (u != null)
                return Conflict();
            _context.users.Add(value);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User value)
        {
            var index = _context.users.FindIndex(u => u.Id == id);
            if (index >= 0)
            {
                _context.users[index].Name = value.Name;
                _context.users[index].Role = value.Role;
                _context.users[index].Email = value.Email;
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _context.users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.users.Remove(user);
                return Ok();
            }
            return BadRequest();
        }
    }
}
