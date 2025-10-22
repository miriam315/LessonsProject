using LessonsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LessonsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "ישראל כהן", Role = "teacher", Email = "israel@example.com" },
            new User { Id = 2, Name = "שרה לוי", Role = "student", Email = "sara@example.com" }
        };
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id)!;
            if(user!=null)
                return Ok(user);
            return NotFound();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            value.Id = users.Count + 1;
            users.Add(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var index = users.FindIndex(u => u.Id == id);
            if (index >= 0)
            {
                users[index].Name = value.Name;
                users[index].Role = value.Role;
                users[index].Email = value.Email;
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                users.Remove(user);
        }
    }
}
